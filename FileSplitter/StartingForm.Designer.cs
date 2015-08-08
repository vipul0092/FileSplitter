using Microsoft.VisualBasic;

namespace FileSplitter
{
    partial class StartingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingForm));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSplitFiles = new System.Windows.Forms.Button();
            this.buttonJoinFiles = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(161, 405);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(299, 99);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.pictureExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.pictureExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.pictureExit_MouseLeave);
            // 
            // buttonSplitFiles
            // 
            this.buttonSplitFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSplitFiles.BackgroundImage")));
            this.buttonSplitFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSplitFiles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSplitFiles.Location = new System.Drawing.Point(5, 170);
            this.buttonSplitFiles.Name = "buttonSplitFiles";
            this.buttonSplitFiles.Size = new System.Drawing.Size(299, 99);
            this.buttonSplitFiles.TabIndex = 6;
            this.buttonSplitFiles.UseVisualStyleBackColor = true;
            this.buttonSplitFiles.Click += new System.EventHandler(this.pictureSplitFiles_Click);
            this.buttonSplitFiles.MouseEnter += new System.EventHandler(this.pictureSplitFiles_MouseEnter);
            this.buttonSplitFiles.MouseLeave += new System.EventHandler(this.pictureSplitFiles_MouseLeave);
            // 
            // buttonJoinFiles
            // 
            this.buttonJoinFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonJoinFiles.BackgroundImage")));
            this.buttonJoinFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonJoinFiles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonJoinFiles.Location = new System.Drawing.Point(323, 170);
            this.buttonJoinFiles.Name = "buttonJoinFiles";
            this.buttonJoinFiles.Size = new System.Drawing.Size(299, 99);
            this.buttonJoinFiles.TabIndex = 7;
            this.buttonJoinFiles.UseVisualStyleBackColor = true;
            this.buttonJoinFiles.Click += new System.EventHandler(this.pictureJoinFiles_Click);
            this.buttonJoinFiles.MouseEnter += new System.EventHandler(this.pictureJoinFiles_MouseEnter);
            this.buttonJoinFiles.MouseLeave += new System.EventHandler(this.pictureJoinFiles_MouseLeave);
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAbout.BackgroundImage")));
            this.buttonAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAbout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAbout.Location = new System.Drawing.Point(323, 285);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(299, 99);
            this.buttonAbout.TabIndex = 8;
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            this.buttonAbout.MouseEnter += new System.EventHandler(this.pictureAbout_MouseEnter);
            this.buttonAbout.MouseLeave += new System.EventHandler(this.pictureAbout_MouseLeave);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSettings.BackgroundImage")));
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSettings.Location = new System.Drawing.Point(491, 77);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(69, 68);
            this.buttonSettings.TabIndex = 9;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            this.buttonSettings.MouseEnter += new System.EventHandler(this.buttonSettings_MouseEnter);
            this.buttonSettings.MouseLeave += new System.EventHandler(this.buttonSettings_MouseLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFolder
            // 
            this.buttonFolder.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.buttonFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFolder.ForeColor = System.Drawing.Color.Brown;
            this.buttonFolder.Location = new System.Drawing.Point(12, 285);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(299, 99);
            this.buttonFolder.TabIndex = 11;
            this.buttonFolder.Text = "FOLDER RELATED";
            this.buttonFolder.UseVisualStyleBackColor = false;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(625, 516);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonJoinFiles);
            this.Controls.Add(this.buttonSplitFiles);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartingForm";
            this.Load += new System.EventHandler(this.StartingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSplitFiles;
        private System.Windows.Forms.Button buttonJoinFiles;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonFolder;
    }
}