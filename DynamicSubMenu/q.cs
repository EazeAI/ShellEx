using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DynamicSubMenus
{
    public static class RecentStack
    {
        public static string configPath = @"c:\cnf\recent.conf";
        public static Stack<LastItem> Items = new Stack<LastItem>();

        //public string Save()
        //{
        //    string rVal = string.Empty;
        //    foreach (LastItem item in Items)
        //    { 
        //        item.menu
        //    }

        //    //return rVal;
        //}

        public static void Read()
        {
            if (!File.Exists(configPath)) return;

            try
            {
                StringBuilder builder = new StringBuilder();
                string text = System.IO.File.ReadAllText(configPath);
                string[] lines = System.IO.File.ReadAllLines(configPath);
                builder.AppendLine("Read recent list as >>> " + text);
                //config.Clear();
                Items.Clear();
                foreach (string line in lines)
                {

                    builder.AppendLine("Line: " + line);

                    string[] items = line.Split(new char[] { '?' });

                    if (items.Length > 0)
                    {
                        //config.Add(items[0], items[1]);
                        Items.Push(new LastItem(items[0], items[1]));
                    }
                    builder.AppendLine(items[0] + ">>>" + items[1]);
                }
                //MessageBox.Show(builder.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //return false;
            }
            //return true;
        
        }

        public static void Save()
        {
            try
            {
                //if (!Directory.Exists(configPath))
                //    using (File.Create(configPath)) { }

                List<string> items = new List<string>();
                StringBuilder builder = new StringBuilder();
                foreach (LastItem item in Items)
                {
                    items.Add(item.menu + "?" + item.path);
                    builder.AppendLine(item.menu + "?" + item.path);
                }
                //MessageBox.Show("Save" + builder.ToString());
                System.IO.File.WriteAllLines(configPath, items.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public static void Add(LastItem item)
        {
            foreach (LastItem i in Items)
            {
                if (i.path.Equals(item.path, StringComparison.OrdinalIgnoreCase))
                    return;
            }

            Items.Push(item);
        }

    }

    public class LastItem
    {
        public string menu;
        public string path;

        public LastItem(string m, string p)
        {
            menu = m;
            path = p;
        }
    }
}
