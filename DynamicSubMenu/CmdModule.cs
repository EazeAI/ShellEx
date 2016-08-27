using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DynamicSubMenus
{
    public class CmdModule
    {
        Config config = new Config();
        CompareForm comparer = new CompareForm();

        public void InitCmd(string tag, IEnumerable<string> files)
        {
            try
            {
                MessageBox.Show("Command Init: " + tag);
                config.InitConfig();

                if (String.IsNullOrEmpty(config.Set["anchor"].ToString()))
                    MessageBox.Show("Source anchor is not fixed");
                else if (String.IsNullOrEmpty(config.Set["dest"].ToString()))
                    MessageBox.Show("Destination is not fixed");
                else
                {

                    //ToolStripMenuItem sndr = (ToolStripMenuItem)sender;
                    //string sourceDir = Directory.GetCurrentDirectory();
                    string action1 = tag.Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string action2 = tag.Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    string destDir = tag.Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[2];
                    //MessageBox.Show(String.Format("Performing {0}:{1} to {2}", action1, action2, destDir));
                    PerformAction(files, destDir, action1, action2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        protected void PerformAction(IEnumerable<string> files, string dest, string action1, string action2)
        {
            if (action1 == "NEW")
            {
                string folderName = Prompt.ShowDialog("Directory Name:", "New Directory");
                dest = Path.Combine(dest, folderName);
                Directory.CreateDirectory(dest);
                //return;
                // Do not return let it process the second part of the action (action2)
            }

            //  Builder for the output.
            var builder = new StringBuilder();
            int count = 0;

            //  Go through each file.
            foreach (var filePath in files)
            {
                //ToDO move logic here
                //   compile source and dest complete file paths
                //   check directories and files
                //   file exists show diffeent form
                //   get new name on rename
                //   move file to dest

                // donot include blog directory
                //string tail = filePath.Replace(config.Set["anchor"].ToString(), "");
                //tail = tail.Replace(Enclose(tail, @"\", @"\"), "");
                //string newPath = dest + @"\" + tail;


                //include blog directory
                string newPath = dest + filePath.Replace(config.Set["anchor"].ToString(), "");

                //int endOfBase = newPath.IndexOf(dest, 0) + 1;
                //string exclusionPart = newPath.Substring(endOfBase, newPath.IndexOf('/', endOfBase));
                //newPath = newPath.Replace(exclusionPart, "");

                if (File.Exists(newPath))
                {
                    string uniquePath = FileModule.GetUniqueFileName(newPath);
                    comparer.Show(filePath, newPath, uniquePath);
                    string choice = comparer.Choice;
                    switch (choice)
                    {
                        case "skip":
                            break;

                        case "write":
                            DoAction(filePath, newPath, action2);
                            count++;
                            break;

                        case "rename":
                            DoAction(filePath, uniquePath, action2);
                            count++;
                            break;

                    }
                }
                else
                {
                    DoAction(filePath, newPath, action2);
                    count++;
                }

                //MessageBox.Show(String.Format("%s: %s > %s", action, filePath, newPath));
                //RecentStack.Items.Push(new LastItem("", Path.GetDirectoryName(dest)));
                RecentStack.Add(new LastItem("", dest));
                RecentStack.Save();

                //builder.AppendLine(string.Format("{0}", Path.GetFileName(filePath)));
            }
            builder.AppendLine(String.Format("{0} >>> {1} file(s) to {2}", action2, count, dest));
            
            //  Show the ouput.
            MessageBox.Show(builder.ToString());
        }

        protected void DoAction(string source, string dest, string action)
        {
            FileModule.EnsureFilePath(dest);
            switch (action)
            { 
                case "COPY":
                    File.Copy(source, dest, true);
                    break;

                case "MOVE":
                    File.Move(source, dest);
                    break;
            }



            //MessageBox.Show(String.Format("{0}: {1} > {2}", action, source, dest));
        }

        protected string Enclose(string str, string from, string to)
        {

            int pFrom = str.IndexOf(from);
            int pTo = str.IndexOf(to, pFrom+from.Length);

            String result = str.Substring(pFrom, pTo - pFrom);

            return result;
        }
    }
}
