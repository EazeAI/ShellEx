using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System.Collections.Generic;

using System.Linq;
using System;
using System.Collections;

namespace DynamicSubMenus
{
    
    // <summary>
    // The SubMenuExtension is an example shell context menu extension,
    // implemented with SharpShell. It loads the menu dynamically
    // files.
    // </summary>
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    //[COMServerAssociation(AssociationType.Directory)]
    public class DynamicSubMenuExtension : SharpContextMenu
    {
        private string anchorPath = null;
        private string destPath = null;
        private Config config = null;

        //  lets create the menu strip.
        private ContextMenuStrip menu = new ContextMenuStrip();

        // <summary>
        // Determines whether the menu item can be shown for the selected item.
        // </summary>
        // <returns>
        //   <c>true</c> if item can be shown for the selected item for this instance.; otherwise, <c>false</c>.
        // </returns>
        protected override bool CanShowMenu()
        {
            
            //  We can show the item only for a single selection.
            if (SelectedItemPaths.Count() == 1)
            {
                this.UpdateMenu();
                return true;
            }
            else
            {
                return false;
            }
        }

        // <summary>
        // Creates the context menu. This can be a single menu item or a tree of them.
        // Here we create the menu based on the type of item
        // </summary>
        // <returns>
        // The context menu for the shell context menu.
        // </returns>
        protected override ContextMenuStrip CreateMenu()
        {
            config = new Config();
            config.InitConfig();

            menu.Items.Clear();
            FileAttributes attr = File.GetAttributes(SelectedItemPaths.First());

            // check if the selected item is a directory
            if (attr.HasFlag(FileAttributes.Directory)) 
            {
                this.MenuFiles();
            }
            else
            {
                this.MenuFiles();
            }

            // return the menu item
            return menu;
        }

        // <summary>
        // Updates the context menu. 
        // </summary>
        private void UpdateMenu()
        {
            // release all resources associated to existing menu
            menu.Dispose();
            menu = CreateMenu();
        }


        // <summary>
        // Creates the context menu when the selected item is of file type.
        // </summary>
        protected void MenuFiles()
        {
            ToolStripMenuItem anchorMenu;
            ToolStripMenuItem destMenu;
            ToolStripSeparator seperatorMenu = new ToolStripSeparator();

            anchorMenu = new ToolStripMenuItem 
            {
                Text = "Source Anchor",
                Image = Properties.Resources.file_icon
            };
            anchorMenu.Click += AnchorItem;

            destMenu = new ToolStripMenuItem
            {
                Text = "Destination",
                Image = Properties.Resources.file_icon
            };
            destMenu.Click += DestItem;

            ToolStripMenuItem moveMenu;
            moveMenu = new ToolStripMenuItem
            {
                Text = "Move...",
                Image = Properties.Resources.file_icon
            };

            ToolStripMenuItem copyMenu;
            copyMenu = new ToolStripMenuItem
            {
                Text = "Copy...",
                Image = Properties.Resources.file_icon
            };

            BuildRecent(copyMenu, moveMenu);
            BuildMenu(copyMenu, moveMenu, config.Set["dest"].ToString());

            menu.Items.Clear();
            menu.Items.Add(seperatorMenu);

            menu.Items.Add(anchorMenu);
            menu.Items.Add(destMenu);

            menu.Items.Add(moveMenu);
            menu.Items.Add(copyMenu);

            menu.Items.Add(seperatorMenu);
        }

        protected void BuildRecent(ToolStripMenuItem copyMenu, ToolStripMenuItem moveMenu)
        {
            RecentStack.Read();
            foreach (LastItem item in RecentStack.Items)
            {
                string dispItem = GetDispItem(item);

                ToolStripMenuItem mnuRecentMove = new ToolStripMenuItem(dispItem);
                mnuRecentMove.Click += MenuSelected;
                mnuRecentMove.Tag = "RECENT::MOVE::" + item.path;
                moveMenu.DropDownItems.Add(mnuRecentMove); 
                
                ToolStripMenuItem mnuRecentCopy = new ToolStripMenuItem(dispItem);
                mnuRecentCopy.Click += MenuSelected;
                mnuRecentCopy.Tag = "RECENT::COPY::" + item.path;
                copyMenu.DropDownItems.Add(mnuRecentCopy);
            }

            ToolStripSeparator seperatorMenu1 = new ToolStripSeparator();
            moveMenu.DropDownItems.Add(seperatorMenu1);

            ToolStripSeparator seperatorMenu2 = new ToolStripSeparator();
            copyMenu.DropDownItems.Add(seperatorMenu2);
        }

        public string GetDispItem(LastItem item)
        {
            string thisPath = item.path.Replace(config.Set["dest"].ToString(), "");
            string[] segs = thisPath.Split(new char[] { '\\' });
            string rVal = string.Empty;

            for (int i = 0; i < segs.Length; i++)
            {
                rVal = rVal + segs[i] + ">";
            }
            return rVal;

        }
        protected void BuildMenu(ToolStripMenuItem copyMenu, ToolStripMenuItem moveMenu, String dir)
        {
            if (moveMenu.DropDownItems.Count == 0)
            {
                ToolStripMenuItem mnuNewFolder = new ToolStripMenuItem("New");
                mnuNewFolder.Click += MenuSelected;
                mnuNewFolder.Tag = "NEW::NOPE::" + dir;
                moveMenu.DropDownItems.Add(mnuNewFolder);

                ToolStripMenuItem mnuAddFolder = new ToolStripMenuItem("New + Move");
                mnuAddFolder.Click += MenuSelected;
                mnuAddFolder.Tag = "NEW::MOVE::" + dir;
                moveMenu.DropDownItems.Add(mnuAddFolder);

                ToolStripMenuItem mnuCopyFile = new ToolStripMenuItem("Move");
                mnuCopyFile.Click += MenuSelected;
                mnuCopyFile.Tag = "NOPE::MOVE::" + dir;
                moveMenu.DropDownItems.Add(mnuCopyFile);

                ToolStripSeparator seperatorMenu = new ToolStripSeparator();
                moveMenu.DropDownItems.Add(seperatorMenu);
            } 
            
            if (copyMenu.DropDownItems.Count == 0)
            {
                ToolStripMenuItem mnuNewFolder = new ToolStripMenuItem("New");
                mnuNewFolder.Click += MenuSelected;
                mnuNewFolder.Tag = "NEW::NOPE::" + dir;
                copyMenu.DropDownItems.Add(mnuNewFolder);

                ToolStripMenuItem mnuAddFolder = new ToolStripMenuItem("New + Copy");
                mnuAddFolder.Click += MenuSelected;
                mnuAddFolder.Tag = "NEW::COPY::" + dir;
                copyMenu.DropDownItems.Add(mnuAddFolder);

                ToolStripMenuItem mnuCopyFile = new ToolStripMenuItem("Copy");
                mnuCopyFile.Click += MenuSelected;
                mnuCopyFile.Tag = "NOPE::COPY::" + dir;
                copyMenu.DropDownItems.Add(mnuCopyFile);

                ToolStripSeparator seperatorMenu = new ToolStripSeparator();
                copyMenu.DropDownItems.Add(seperatorMenu);
            }

            try
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    ToolStripMenuItem mnuMove = new ToolStripMenuItem(d.Substring(d.LastIndexOf("\\") + 1));
                    mnuMove.Click += MenuSelected;
                    mnuMove.Tag = "DIR::" + d;
                    moveMenu.DropDownItems.Add(mnuMove); 
                    
                    ToolStripMenuItem mnuCopy = new ToolStripMenuItem(d.Substring(d.LastIndexOf("\\") + 1));
                    mnuCopy.Click += MenuSelected;
                    mnuCopy.Tag = "DIR::" + d;
                    copyMenu.DropDownItems.Add(mnuCopy);

                    BuildMenu(mnuCopy, mnuMove, d);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AnchorItem(object sender, EventArgs e)
        {
            config.Set["anchor"] = Path.GetDirectoryName(SelectedItemPaths.ToList()[0].ToString());
            MessageBox.Show("Anchor set to " + config.Set["anchor"]);
            config.ShowConfig();
            config.SaveConfig();
        }

        private void DestItem(object sender, EventArgs e)
        {
            config.Set["dest"] = Path.GetDirectoryName(SelectedItemPaths.ToList()[0].ToString());
            MessageBox.Show("Dest fixed to " + config.Set["dest"]);
            config.ShowConfig();
            config.SaveConfig();
        }

        private void MenuSelected(object sender, EventArgs e)
        {
            CmdModule cmd = new CmdModule();
            cmd.InitCmd(((ToolStripMenuItem)sender).Tag.ToString(), SelectedItemPaths);
        }
    }

    enum Action
    {
        Copy,
        Move,
        New
    }
}