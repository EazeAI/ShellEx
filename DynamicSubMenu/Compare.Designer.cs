namespace DynamicSubMenus
{
    partial class CompareForm
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
            this.sourceImage = new System.Windows.Forms.PictureBox();
            this.destImage = new System.Windows.Forms.PictureBox();
            this.sourceFile = new System.Windows.Forms.Label();
            this.sourceSize = new System.Windows.Forms.Label();
            this.sourceCreatedOn = new System.Windows.Forms.Label();
            this.sourceModifiedOn = new System.Windows.Forms.Label();
            this.destModifiedOn = new System.Windows.Forms.Label();
            this.destCreatedOn = new System.Windows.Forms.Label();
            this.destSize = new System.Windows.Forms.Label();
            this.destFile = new System.Windows.Forms.Label();
            this.overwriteButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.newName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destImage)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceImage
            // 
            this.sourceImage.Location = new System.Drawing.Point(3, 2);
            this.sourceImage.Name = "sourceImage";
            this.sourceImage.Size = new System.Drawing.Size(402, 387);
            this.sourceImage.TabIndex = 0;
            this.sourceImage.TabStop = false;
            // 
            // destImage
            // 
            this.destImage.Location = new System.Drawing.Point(411, 2);
            this.destImage.Name = "destImage";
            this.destImage.Size = new System.Drawing.Size(401, 387);
            this.destImage.TabIndex = 1;
            this.destImage.TabStop = false;
            // 
            // sourceFile
            // 
            this.sourceFile.AutoSize = true;
            this.sourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceFile.Location = new System.Drawing.Point(0, 392);
            this.sourceFile.Name = "sourceFile";
            this.sourceFile.Size = new System.Drawing.Size(90, 17);
            this.sourceFile.TabIndex = 2;
            this.sourceFile.Text = "Source File";
            // 
            // sourceSize
            // 
            this.sourceSize.AutoSize = true;
            this.sourceSize.Location = new System.Drawing.Point(3, 417);
            this.sourceSize.Name = "sourceSize";
            this.sourceSize.Size = new System.Drawing.Size(115, 13);
            this.sourceSize.TabIndex = 3;
            this.sourceSize.Text = "00 Kb [ width x height ]";
            // 
            // sourceCreatedOn
            // 
            this.sourceCreatedOn.AutoSize = true;
            this.sourceCreatedOn.Location = new System.Drawing.Point(3, 433);
            this.sourceCreatedOn.Name = "sourceCreatedOn";
            this.sourceCreatedOn.Size = new System.Drawing.Size(61, 13);
            this.sourceCreatedOn.TabIndex = 4;
            this.sourceCreatedOn.Text = "Created On";
            // 
            // sourceModifiedOn
            // 
            this.sourceModifiedOn.AutoSize = true;
            this.sourceModifiedOn.Location = new System.Drawing.Point(2, 450);
            this.sourceModifiedOn.Name = "sourceModifiedOn";
            this.sourceModifiedOn.Size = new System.Drawing.Size(64, 13);
            this.sourceModifiedOn.TabIndex = 5;
            this.sourceModifiedOn.Text = "Modified On";
            // 
            // destModifiedOn
            // 
            this.destModifiedOn.AutoSize = true;
            this.destModifiedOn.Location = new System.Drawing.Point(411, 450);
            this.destModifiedOn.Name = "destModifiedOn";
            this.destModifiedOn.Size = new System.Drawing.Size(64, 13);
            this.destModifiedOn.TabIndex = 9;
            this.destModifiedOn.Text = "Modified On";
            // 
            // destCreatedOn
            // 
            this.destCreatedOn.AutoSize = true;
            this.destCreatedOn.Location = new System.Drawing.Point(411, 433);
            this.destCreatedOn.Name = "destCreatedOn";
            this.destCreatedOn.Size = new System.Drawing.Size(61, 13);
            this.destCreatedOn.TabIndex = 8;
            this.destCreatedOn.Text = "Created On";
            // 
            // destSize
            // 
            this.destSize.AutoSize = true;
            this.destSize.Location = new System.Drawing.Point(411, 417);
            this.destSize.Name = "destSize";
            this.destSize.Size = new System.Drawing.Size(115, 13);
            this.destSize.TabIndex = 7;
            this.destSize.Text = "00 Kb [ width x height ]";
            // 
            // destFile
            // 
            this.destFile.AutoSize = true;
            this.destFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destFile.Location = new System.Drawing.Point(408, 392);
            this.destFile.Name = "destFile";
            this.destFile.Size = new System.Drawing.Size(121, 17);
            this.destFile.TabIndex = 6;
            this.destFile.Text = "Destination File";
            // 
            // overwriteButton
            // 
            this.overwriteButton.Location = new System.Drawing.Point(737, 469);
            this.overwriteButton.Name = "overwriteButton";
            this.overwriteButton.Size = new System.Drawing.Size(75, 23);
            this.overwriteButton.TabIndex = 10;
            this.overwriteButton.Text = "&Overwrite";
            this.overwriteButton.UseVisualStyleBackColor = true;
            this.overwriteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "&Skip";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(583, 469);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 12;
            this.btnRename.Text = "&Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(183, 471);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(397, 20);
            this.newName.TabIndex = 13;
            this.newName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 495);
            this.Controls.Add(this.newName);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.overwriteButton);
            this.Controls.Add(this.destModifiedOn);
            this.Controls.Add(this.destCreatedOn);
            this.Controls.Add(this.destSize);
            this.Controls.Add(this.destFile);
            this.Controls.Add(this.sourceModifiedOn);
            this.Controls.Add(this.sourceCreatedOn);
            this.Controls.Add(this.sourceSize);
            this.Controls.Add(this.sourceFile);
            this.Controls.Add(this.destImage);
            this.Controls.Add(this.sourceImage);
            this.Name = "CompareForm";
            this.Text = "Compare Files";
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourceImage;
        private System.Windows.Forms.PictureBox destImage;
        private System.Windows.Forms.Label sourceFile;
        private System.Windows.Forms.Label sourceSize;
        private System.Windows.Forms.Label sourceCreatedOn;
        private System.Windows.Forms.Label sourceModifiedOn;
        private System.Windows.Forms.Label destModifiedOn;
        private System.Windows.Forms.Label destCreatedOn;
        private System.Windows.Forms.Label destSize;
        private System.Windows.Forms.Label destFile;
        private System.Windows.Forms.Button overwriteButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox newName;
    }
}