namespace FileSplitter.Misc_Forms
{
    partial class SettingsForm
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
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabBufferSize = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxBuffer = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabCheckSumAlgo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxFilecheck = new System.Windows.Forms.CheckedListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabSettingsSave = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBoxSettingsave = new System.Windows.Forms.CheckedListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlSettings.SuspendLayout();
            this.tabBufferSize.SuspendLayout();
            this.tabCheckSumAlgo.SuspendLayout();
            this.tabSettingsSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSettings.Controls.Add(this.tabBufferSize);
            this.tabControlSettings.Controls.Add(this.tabCheckSumAlgo);
            this.tabControlSettings.Controls.Add(this.tabSettingsSave);
            this.tabControlSettings.HotTrack = true;
            this.tabControlSettings.Location = new System.Drawing.Point(1, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(354, 337);
            this.tabControlSettings.TabIndex = 0;
            // 
            // tabBufferSize
            // 
            this.tabBufferSize.Controls.Add(this.label1);
            this.tabBufferSize.Controls.Add(this.checkedListBoxBuffer);
            this.tabBufferSize.Controls.Add(this.textBox1);
            this.tabBufferSize.Location = new System.Drawing.Point(4, 22);
            this.tabBufferSize.Name = "tabBufferSize";
            this.tabBufferSize.Padding = new System.Windows.Forms.Padding(3);
            this.tabBufferSize.Size = new System.Drawing.Size(346, 311);
            this.tabBufferSize.TabIndex = 0;
            this.tabBufferSize.Text = "Buffer Size";
            this.tabBufferSize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(35, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "SELECT BUFFER SIZE : ";
            // 
            // checkedListBoxBuffer
            // 
            this.checkedListBoxBuffer.CheckOnClick = true;
            this.checkedListBoxBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxBuffer.FormattingEnabled = true;
            this.checkedListBoxBuffer.Items.AddRange(new object[] {
            "8 KB",
            "16 KB",
            "32 KB",
            "64 KB",
            "128 KB",
            "256 KB",
            "512 KB",
            "1 MB",
            "Select Automatically For Me"});
            this.checkedListBoxBuffer.Location = new System.Drawing.Point(38, 117);
            this.checkedListBoxBuffer.Name = "checkedListBoxBuffer";
            this.checkedListBoxBuffer.Size = new System.Drawing.Size(266, 166);
            this.checkedListBoxBuffer.TabIndex = 2;
            this.checkedListBoxBuffer.ThreeDCheckBoxes = true;
            this.checkedListBoxBuffer.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxBuffer_ItemCheck);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox1.Location = new System.Drawing.Point(38, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(266, 49);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Select the Buffer Size to be used while splitting and joining files.";
            // 
            // tabCheckSumAlgo
            // 
            this.tabCheckSumAlgo.Controls.Add(this.label2);
            this.tabCheckSumAlgo.Controls.Add(this.checkedListBoxFilecheck);
            this.tabCheckSumAlgo.Controls.Add(this.textBox2);
            this.tabCheckSumAlgo.Location = new System.Drawing.Point(4, 22);
            this.tabCheckSumAlgo.Name = "tabCheckSumAlgo";
            this.tabCheckSumAlgo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckSumAlgo.Size = new System.Drawing.Size(346, 311);
            this.tabCheckSumAlgo.TabIndex = 1;
            this.tabCheckSumAlgo.Text = "File CheckSum Method";
            this.tabCheckSumAlgo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(39, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "SELECT FILE CHECKSUM METHOD : ";
            // 
            // checkedListBoxFilecheck
            // 
            this.checkedListBoxFilecheck.CheckOnClick = true;
            this.checkedListBoxFilecheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxFilecheck.FormattingEnabled = true;
            this.checkedListBoxFilecheck.Items.AddRange(new object[] {
            "Adler-32 CheckSum  ( Fast )",
            "CRC-32 CheckSum  ( Faster )",
            "MurMurHash3 CheckSum  ( Slowest )",
            "Select Automatically For Me"});
            this.checkedListBoxFilecheck.Location = new System.Drawing.Point(42, 154);
            this.checkedListBoxFilecheck.Name = "checkedListBoxFilecheck";
            this.checkedListBoxFilecheck.Size = new System.Drawing.Size(266, 76);
            this.checkedListBoxFilecheck.TabIndex = 3;
            this.checkedListBoxFilecheck.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxFilecheck_ItemCheck);
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox2.Location = new System.Drawing.Point(42, 22);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(266, 49);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Select The File Verification Mechanism used while splitting and joining files.";
            // 
            // tabSettingsSave
            // 
            this.tabSettingsSave.Controls.Add(this.label3);
            this.tabSettingsSave.Controls.Add(this.checkedListBoxSettingsave);
            this.tabSettingsSave.Controls.Add(this.textBox3);
            this.tabSettingsSave.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsSave.Name = "tabSettingsSave";
            this.tabSettingsSave.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsSave.Size = new System.Drawing.Size(346, 311);
            this.tabSettingsSave.TabIndex = 2;
            this.tabSettingsSave.Text = "Settings Save Method";
            this.tabSettingsSave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(40, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "SELECT SETTINGS SAVE METHOD : ";
            // 
            // checkedListBoxSettingsave
            // 
            this.checkedListBoxSettingsave.CheckOnClick = true;
            this.checkedListBoxSettingsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxSettingsave.FormattingEnabled = true;
            this.checkedListBoxSettingsave.Items.AddRange(new object[] {
            "Windows Registry",
            ".ini File",
            "Select Automatically For Me"});
            this.checkedListBoxSettingsave.Location = new System.Drawing.Point(43, 135);
            this.checkedListBoxSettingsave.Name = "checkedListBoxSettingsave";
            this.checkedListBoxSettingsave.Size = new System.Drawing.Size(266, 58);
            this.checkedListBoxSettingsave.TabIndex = 4;
            this.checkedListBoxSettingsave.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxSettingsave_ItemCheck);
            // 
            // textBox3
            // 
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox3.Location = new System.Drawing.Point(43, 31);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(266, 49);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Select the Method to Save the Application Settings on your System.";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOK.Location = new System.Drawing.Point(69, 352);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(205, 352);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(357, 387);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "APPLICATION SETTINGS";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControlSettings.ResumeLayout(false);
            this.tabBufferSize.ResumeLayout(false);
            this.tabBufferSize.PerformLayout();
            this.tabCheckSumAlgo.ResumeLayout(false);
            this.tabCheckSumAlgo.PerformLayout();
            this.tabSettingsSave.ResumeLayout(false);
            this.tabSettingsSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabBufferSize;
        private System.Windows.Forms.TabPage tabCheckSumAlgo;
        private System.Windows.Forms.TabPage tabSettingsSave;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckedListBox checkedListBoxBuffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxFilecheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBoxSettingsave;
    }
}