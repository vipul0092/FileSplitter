namespace FileSplitter
{
    partial class FolderOpsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderOpsForm));
            this.buttonSplit = new System.Windows.Forms.Button();
            this.lvDisplay = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iListLV = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.buttonExtractAll = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.fbdSplit = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.openSplitFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonSplit
            // 
            this.buttonSplit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSplit.Image = ((System.Drawing.Image)(resources.GetObject("buttonSplit.Image")));
            this.buttonSplit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSplit.Location = new System.Drawing.Point(84, 12);
            this.buttonSplit.Name = "buttonSplit";
            this.buttonSplit.Size = new System.Drawing.Size(85, 83);
            this.buttonSplit.TabIndex = 0;
            this.buttonSplit.Text = "SPLIT FOLDER";
            this.buttonSplit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSplit.UseVisualStyleBackColor = true;
            this.buttonSplit.Click += new System.EventHandler(this.buttonSplit_Click);
            // 
            // lvDisplay
            // 
            this.lvDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvDisplay.Location = new System.Drawing.Point(12, 101);
            this.lvDisplay.Name = "lvDisplay";
            this.lvDisplay.Size = new System.Drawing.Size(669, 351);
            this.lvDisplay.SmallImageList = this.iListLV;
            this.lvDisplay.TabIndex = 3;
            this.lvDisplay.UseCompatibleStateImageBehavior = false;
            this.lvDisplay.View = System.Windows.Forms.View.Details;
            this.lvDisplay.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 205;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 89;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 104;
            // 
            // iListLV
            // 
            this.iListLV.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iListLV.ImageSize = new System.Drawing.Size(16, 16);
            this.iListLV.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(693, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // buttonExtract
            // 
            this.buttonExtract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExtract.Image = ((System.Drawing.Image)(resources.GetObject("buttonExtract.Image")));
            this.buttonExtract.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonExtract.Location = new System.Drawing.Point(387, 12);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(85, 83);
            this.buttonExtract.TabIndex = 5;
            this.buttonExtract.Text = "EXTRACT FILE/FOLDER";
            this.buttonExtract.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExtract.UseVisualStyleBackColor = true;
            // 
            // buttonExtractAll
            // 
            this.buttonExtractAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExtractAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonExtractAll.Image")));
            this.buttonExtractAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonExtractAll.Location = new System.Drawing.Point(523, 12);
            this.buttonExtractAll.Name = "buttonExtractAll";
            this.buttonExtractAll.Size = new System.Drawing.Size(85, 83);
            this.buttonExtractAll.TabIndex = 6;
            this.buttonExtractAll.Text = "EXTRACT ALL";
            this.buttonExtractAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExtractAll.UseVisualStyleBackColor = true;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpen.Image = global::FileSplitter.Properties.Resources.Open;
            this.buttonOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonOpen.Location = new System.Drawing.Point(234, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(85, 83);
            this.buttonOpen.TabIndex = 7;
            this.buttonOpen.Text = "OPEN SPLIT FILE";
            this.buttonOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // fbdSplit
            // 
            this.fbdSplit.HelpRequest += new System.EventHandler(this.fbdSplit_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openSplitFile
            // 
            this.openSplitFile.FileName = "openFileDialog1";
            // 
            // FolderOpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 487);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonExtractAll);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvDisplay);
            this.Controls.Add(this.buttonSplit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FolderOpsForm";
            this.Text = "FOLDER SPLITTING AND JOINING";
            this.Load += new System.EventHandler(this.FolderOpsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSplit;
        private System.Windows.Forms.ListView lvDisplay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Button buttonExtractAll;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ImageList iListLV;
        private System.Windows.Forms.FolderBrowserDialog fbdSplit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openSplitFile;
    }
}