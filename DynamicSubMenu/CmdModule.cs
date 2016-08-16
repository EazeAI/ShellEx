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
            MessageBox.Show("menu selected: " + tag);
            config.InitConfig();

            if (String.IsNullOrEmpty(config.Set["anchor"].ToString()))
                MessageBox.Show("Source anchor is not fixed");
            else if (String.IsNullOrEmpty(config.Set["dest"].ToString()))
                MessageBox.Show("Destination is not fixed");
            else
            {

                //ToolStripMenuItem sndr = (ToolStripMenuItem)sender;
                //string sourceDir = Directory.GetCurrentDirectory();
                string action = tag.Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[0];
                string destDir = tag.Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1];
                MessageBox.Show(String.Format("Performing {0} to {1}", action, destDir));
                PerformAction(files, destDir, action);
            }
        }

        protected void PerformAction(IEnumerable<string> files, string dest, string action)
        {
            if (action == "NEW")
            {
                string folderName = Prompt.ShowDialog("Directory Name:", "New Directory");
                Directory.CreateDirectory(Path.Combine(dest, folderName));
                return;
            }

            //  Builder for the output.
            var builder = new StringBuilder();

            //  Go through each file.
            foreach (var filePath in files)
            {
                //ToDO move logic here
                //   compile source and dest complete file paths
                //   check directories and files
                //   file exists show diffeent form
                //   get new name on rename
                //   move file to dest

                string newPath = filePath.Replace(config.Set["anchor"].ToString(), config.Set["dest"].ToString());
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
                            DoAction(filePath, newPath, action);
                            break;

                        case "rename":
                            DoAction(filePath, uniquePath, action);
                            break;

                    }
                }
                else
                    DoAction(filePath, newPath, action);

                //MessageBox.Show(String.Format("%s: %s > %s", action, filePath, newPath));


                builder.AppendLine(string.Format("{0}", Path.GetFileName(filePath)));
            }
            //builder.AppendLine(action + " >>> " + source + " to " + dest);

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

            MessageBox.Show(String.Format("{0}: {1} > {2}", action, source, dest));
        }
    }
}
