namespace DynamicSubMenus
{
    partial class MessageCache
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessageArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOk.Location = new System.Drawing.Point(0, 441);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(948, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(76, 15);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Something";
            // 
            // txtMessageArea
            // 
            this.txtMessageArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageArea.Location = new System.Drawing.Point(0, 15);
            this.txtMessageArea.Multiline = true;
            this.txtMessageArea.Name = "txtMessageArea";
            this.txtMessageArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessageArea.Size = new System.Drawing.Size(948, 426);
            this.txtMessageArea.TabIndex = 3;
            // 
            // MessageCache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 464);
            this.Controls.Add(this.txtMessageArea);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnOk);
            this.Name = "MessageCache";
            this.Text = "MessageCache";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessageArea;
    }
}