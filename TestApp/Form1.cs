using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            DynamicSubMenus.CmdModule cmd = new DynamicSubMenus.CmdModule();
            IEnumerable<string> files = new string[] 
            { 
                @"C:\dump\gras\pzy-i-11-DSCxxxxx\pzy.be\i\x\IMG_1926.jpg",
                 @"C:\dump\gras\pzy-i-11-DSCxxxxx\pzy.be\i\x\IMG_1927.jpg",
                  @"C:\dump\gras\pzy-i-11-DSCxxxxx\pzy.be\i\x\IMG_1928.jpg"
            };

            cmd.InitCmd(@"NOPE::MOVE::C:\wspace\test\dest", files);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            DynamicSubMenus.Config cfg = new DynamicSubMenus.Config();
            cfg.ShowConfig();
        }
    }
}
