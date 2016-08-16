using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DynamicSubMenus
{
    public partial class CompareForm : Form
    {
        public string Choice = string.Empty;
        Image sourceImg = null;
        Image destImg = null;
        public CompareForm()
        {
            InitializeComponent();
        }

        public void Show(string source, string dest, string unique)
        {
            sourceImg = Image.FromFile(source);
            sourceImage.SizeMode = PictureBoxSizeMode.StretchImage;
            if (sourceImg != null)
                sourceImage.Image = sourceImg;
            FileInfo sourceInfo = new FileInfo(source);
            sourceCreatedOn.Text = sourceInfo.CreationTime.ToString("o");
            sourceModifiedOn.Text = sourceInfo.LastWriteTime.ToString("o");
            sourceSize.Text = FormatSize(sourceInfo.Length, sourceImg);

            destImg = Image.FromFile(dest);
            destImage.SizeMode = PictureBoxSizeMode.StretchImage;
            if (destImg != null)
                destImage.Image = destImg;
            FileInfo destInfo = new FileInfo(dest);
            destCreatedOn.Text = destInfo.CreationTime.ToString("o");
            destModifiedOn.Text = destInfo.LastWriteTime.ToString("o");
            destSize.Text = FormatSize(destInfo.Length, destImg);

            newName.Text = unique;

            Choice = string.Empty;

            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choice = "write";
            this.Continue();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            Choice = "rename";
            this.Continue();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Choice = "skip";
            this.Continue();
        }

        private void Continue()
        {
            sourceImg.Dispose();
            sourceImage.Image = null;
            destImg.Dispose();
            destImage.Image = null;
            this.Hide();
        }

        private string FormatSize(long size, Image img)
        {
            //return size.ToString() + " / " + (1024*1024).ToString();
            string sizeS = "";
            if (size > 1024 * 1024)
                sizeS = Math.Round(size / (1024.0 * 1024.0), 2).ToString() + " Mb";
            else if (size > 1024)
                sizeS = Math.Round(size / (1024.0), 2).ToString() + " Kb";
            else
                sizeS = size.ToString() + " b";

            if (img != null)
                sizeS = sizeS + String.Format("[{0} h x {1} w]", img.Height, img.Width);

            return sizeS;


        }
    }
}
