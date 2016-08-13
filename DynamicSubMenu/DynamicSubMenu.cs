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
            InitConfig();

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

        protected Hashtable config = new Hashtable();
        protected string configPath = @"c:\cnf\menu.conf";

        protected void InitConfig()
        {
            MessageBox.Show("Init config");
            if (!ReadConfig())
            {
                MessageBox.Show("Read failed");
                config.Add("anchor", "");
                config.Add("dest", "");
            }
            ShowConfig();

        }

        protected void ShowConfig()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DictionaryEntry de in config)
            {
                builder.AppendLine("Key="+de.Key + "==:==Value=" + de.Value);
            }
            MessageBox.Show("Config content...\r\n" + builder.ToString());
        }

        protected void SaveConfig()
        {
            try
            {
                List<string> items = new List<string>();
                StringBuilder builder = new StringBuilder();
                foreach (DictionaryEntry de in config)
                {
                    items.Add(de.Key + "?" + de.Value);
                    builder.AppendLine(de.Key + "?" + de.Value);
                }
                MessageBox.Show("Save" + builder.ToString());
                System.IO.File.WriteAllLines(configPath, items.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        
        }

        protected bool ReadConfig()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                string text = System.IO.File.ReadAllText(configPath);
                string[] lines = System.IO.File.ReadAllLines(configPath);
                builder.AppendLine("Read config as >>> " + text );

                foreach (string line in lines)
                {
                    
                    builder.AppendLine("Line: " + line);
                    config.Clear();
                    string[] items = line.Split(new char[]{'?'});

                    if(items.Length > 0)
                    {
                        config.Add(items[0], items[1]);
                    }
                    builder.AppendLine(items[0] + ">>>" + items[1]);
                }
                MessageBox.Show(builder.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
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
                Text = "Anchor",
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

            BuildMenu(copyMenu, moveMenu, @"D:\tests\dest");

            menu.Items.Clear();
            menu.Items.Add(seperatorMenu);

            menu.Items.Add(anchorMenu);
            menu.Items.Add(destMenu);

            menu.Items.Add(copyMenu);
            menu.Items.Add(moveMenu);

            menu.Items.Add(seperatorMenu);
        }

        // <summary>
        // Creates the context menu when the selected item is a folder.
        // </summary>
        //protected void MenuDirectory()
        //{
        //    ToolStripMenuItem moveMenu;
        //    moveMenu = new ToolStripMenuItem
        //    {
        //        Text = "Move Files...",
        //        Image = Properties.Resources.Folder_icon
        //    };

        //    ToolStripMenuItem copyMenu;
        //    copyMenu = new ToolStripMenuItem
        //    {
        //        Text = "Copy Files...",
        //        Image = Properties.Resources.Folder_icon
        //    };
        //            ToolStripMenuItem SubMenu1;
        //            SubMenu1 = new ToolStripMenuItem
        //            {
        //                Text = "DirSubMenu1",
        //                Image = Properties.Resources.Folder_icon
        //            };

        //            var SubMenu2 = new ToolStripMenuItem
        //            {
        //                Text = "DirSubMenu2",
        //                Image = Properties.Resources.Folder_icon
        //            };
        //            SubMenu2.DropDownItems.Clear();
        //            SubMenu2.Click += ShowItemName;

        //                    var SubSubMenu1 = new ToolStripMenuItem
        //                    {
        //                        Text = "DirSubSubMenu1",
        //                        Image = Properties.Resources.Folder_icon
        //                    };
        //                    SubSubMenu1.Click += ShowItemName;

        //    // Lets attach the submenus to the main menu
        //    SubMenu1.DropDownItems.Add(SubSubMenu1);
        //    moveMenu.DropDownItems.Add(SubMenu1);
        //    moveMenu.DropDownItems.Add(SubMenu2);

        //    menu.Items.Clear();
        //    menu.Items.Add(moveMenu);
        //}

        protected void BuildMenu(ToolStripMenuItem copyMenu, ToolStripMenuItem moveMenu, String dir)
        {
            if (copyMenu.DropDownItems.Count == 0)
            {
                ToolStripMenuItem mnuAddFolder = new ToolStripMenuItem("New Folder");
                mnuAddFolder.Click += MenuSelected;
                mnuAddFolder.Tag = "NEW::" + dir;
                copyMenu.DropDownItems.Add(mnuAddFolder);

                ToolStripMenuItem mnuCopyFile = new ToolStripMenuItem("Copy");
                mnuCopyFile.Click += MenuSelected;
                mnuCopyFile.Tag = "COPY::" + dir;
                copyMenu.DropDownItems.Add(mnuCopyFile);

                ToolStripSeparator seperatorMenu = new ToolStripSeparator();
                copyMenu.DropDownItems.Add(seperatorMenu);
            }

            if (moveMenu.DropDownItems.Count == 0)
            {
                ToolStripMenuItem mnuAddFolder = new ToolStripMenuItem("New Folder");
                mnuAddFolder.Click += MenuSelected;
                mnuAddFolder.Tag = "NEW::" + dir;
                moveMenu.DropDownItems.Add(mnuAddFolder);

                ToolStripMenuItem mnuCopyFile = new ToolStripMenuItem("Copy");
                mnuCopyFile.Click += MenuSelected;
                mnuCopyFile.Tag = "MOVE::" + dir;
                moveMenu.DropDownItems.Add(mnuCopyFile);

                ToolStripSeparator seperatorMenu = new ToolStripSeparator();
                moveMenu.DropDownItems.Add(seperatorMenu);
            }

            try
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    ToolStripMenuItem mnuCopy = new ToolStripMenuItem(d.Substring(d.LastIndexOf("\\") + 1));
                    mnuCopy.Click += MenuSelected;
                    mnuCopy.Tag = "DIR::" + d;
                    copyMenu.DropDownItems.Add(mnuCopy);

                    ToolStripMenuItem mnuMove = new ToolStripMenuItem(d.Substring(d.LastIndexOf("\\") + 1));
                    mnuCopy.Click += MenuSelected;
                    mnuCopy.Tag = "DIR::" + d;
                    moveMenu.DropDownItems.Add(mnuCopy);

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
            config["anchor"] = SelectedItemPaths.ToList()[0].ToString();
            MessageBox.Show("Anchor set to " + config["anchor"]);
            ShowConfig();
            SaveConfig();
        }

        private void DestItem(object sender, EventArgs e)
        {
            config["dest"] = SelectedItemPaths.ToList()[0].ToString();
            MessageBox.Show("Dest fixed to " + config["dest"]);
            ShowConfig();
            SaveConfig();
        }

        // <summary>
        // Shows name of selected files.
        // </summary>
        //private void MenuSelected(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(this.anchorPath))
        //        MessageBox.Show("Location anchor is not fixed");
        //    else
        //    {
        //        ToolStripMenuItem sndr = (ToolStripMenuItem)sender;
        //        string souceDir = Directory.GetCurrentDirectory();
        //        string destDir = sndr.Tag.ToString();
        //        PerformAction(SelectedItemPaths, souceDir, destDir, Action.Copy);
        //    }
        //}

        private void MenuSelected(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.anchorPath))
                MessageBox.Show("Location anchor is not fixed");
            else if (String.IsNullOrEmpty(this.destPath))
                MessageBox.Show("Destination is not fixed");
            else
            {
                ToolStripMenuItem sndr = (ToolStripMenuItem)sender;
                string souceDir = Directory.GetCurrentDirectory();
                string action = sndr.Tag.ToString().Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[0];
                string destDir = sndr.Tag.ToString();
                PerformAction(SelectedItemPaths, souceDir, destDir, action);
            }
        }

        protected void PerformAction(IEnumerable<string> items, string source, string dest, string action)
        {
            //  Builder for the output.
            var builder = new StringBuilder();

            //  Go through each file.
            foreach (var filePath in SelectedItemPaths)
            {
                //ToDO move logic here
                //   compile source and dest complete file paths
                //   check directories and files
                //   file exists show diffeent form
                //   get new name on rename
                //   move file to dest


                builder.AppendLine(string.Format("{0}", Path.GetFileName(filePath)));
            }
            builder.AppendLine(action + " >>> " + source + " to " + dest);

            //  Show the ouput.
            MessageBox.Show(builder.ToString());

            CompareForm form = new CompareForm();
            form.Show();
        }
    }

    enum Action
    {
        Copy,
        Move,
        New
    }
}