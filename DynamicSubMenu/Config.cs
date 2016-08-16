using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace DynamicSubMenus
{
    public  class Config
    {
        protected Hashtable config = new Hashtable();
        protected string configPath = @"c:\cnf\menu.conf";

        public Hashtable Set 
        {
            get
            {
                return config;
            }
        }

        public void InitConfig()
        {
            //MessageBox.Show("Init config");
            if (!ReadConfig())
            {
                //MessageBox.Show("Read failed");
                config.Add("anchor", "");
                config.Add("dest", "");
            }
            ShowConfig();

        }

        public void ShowConfig()
        {
            //StringBuilder builder = new StringBuilder();
            //foreach (DictionaryEntry de in config)
            //{
            //    builder.AppendLine("Key=" + de.Key + "==:==Value=" + de.Value);
            //}
            //MessageBox.Show("Config content...\r\n" + builder.ToString());
        }

        public void SaveConfig()
        {
            try
            {
                //if (!Directory.Exists(configPath))
                //    using (File.Create(configPath)) { }

                List<string> items = new List<string>();
                StringBuilder builder = new StringBuilder();
                foreach (DictionaryEntry de in config)
                {
                    items.Add(de.Key + "?" + de.Value);
                    builder.AppendLine(de.Key + "?" + de.Value);
                }
                //MessageBox.Show("Save" + builder.ToString());
                System.IO.File.WriteAllLines(configPath, items.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        protected bool ReadConfig()
        {
            if (!File.Exists(configPath)) return false;

            try
            {
                StringBuilder builder = new StringBuilder();
                string text = System.IO.File.ReadAllText(configPath);
                string[] lines = System.IO.File.ReadAllLines(configPath);
                builder.AppendLine("Read config as >>> " + text);
                config.Clear();
                foreach (string line in lines)
                {

                    builder.AppendLine("Line: " + line);

                    string[] items = line.Split(new char[] { '?' });

                    if (items.Length > 0)
                    {
                        config.Add(items[0], items[1]);
                    }
                    builder.AppendLine(items[0] + ">>>" + items[1]);
                }
                //MessageBox.Show(builder.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }

    }
}
