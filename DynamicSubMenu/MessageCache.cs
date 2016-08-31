using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DynamicSubMenus
{
    public partial class MessageCache : Form
    {
        StringBuilder buf = new StringBuilder();
        int count = 0;
        static MessageCache inst = null;

        public static MessageCache Instance()
        {
            if (inst == null)
                inst = new MessageCache();
            return inst;
        }

        public MessageCache()
        {
            InitializeComponent();
        }

        public void Add(string s)
        {
            buf.AppendLine(count.ToString().PadLeft(3, '0') + "  " + s);
            count++;
            //MessageBox.Show(s);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            count = 0;
            buf.Clear();
            this.Hide();
        }

        public void Show(string msg)
        {
            lblMessage.Text = msg;
            txtMessageArea.Text = buf.ToString();
            this.Show();
        }
    }
}
