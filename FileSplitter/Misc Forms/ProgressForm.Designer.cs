namespace FileSplitter.Misc_Forms
{
    partial class ProgressForm
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
            this.progressBarCurrentSplitFile = new System.Windows.Forms.ProgressBar();
            this.progressBarOverallSplitFiles = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentFileProcess = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCurrentPerc = new System.Windows.Forms.Label();
            this.labelOverallPerc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarCurrentSplitFile
            // 
            this.progressBarCurrentSplitFile.Location = new System.Drawing.Point(69, 34);
            this.progressBarCurrentSplitFile.Name = "progressBarCurrentSplitFile";
            this.progressBarCurrentSplitFile.Size = new System.Drawing.Size(509, 15);
            this.progressBarCurrentSplitFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCurrentSplitFile.TabIndex = 2;
            // 
            // progressBarOverallSplitFiles
            // 
            this.progressBarOverallSplitFiles.Location = new System.Drawing.Point(69, 147);
            this.progressBarOverallSplitFiles.Name = "progressBarOverallSplitFiles";
            this.progressBarOverallSplitFiles.Size = new System.Drawing.Size(509, 15);
            this.progressBarOverallSplitFiles.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarOverallSplitFiles.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(231, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Split Files Save Progress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Overall Split Files Save Progress";
            // 
            // labelCurrentFileProcess
            // 
            this.labelCurrentFileProcess.BackColor = System.Drawing.Color.White;
            this.labelCurrentFileProcess.Location = new System.Drawing.Point(316, 76);
            this.labelCurrentFileProcess.Name = "labelCurrentFileProcess";
            this.labelCurrentFileProcess.Size = new System.Drawing.Size(167, 22);
            this.labelCurrentFileProcess.TabIndex = 8;
            this.labelCurrentFileProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current File Number Being Processed : ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(364, 186);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(169, 186);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK!";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "0%";
            // 
            // labelCurrentPerc
            // 
            this.labelCurrentPerc.AutoSize = true;
            this.labelCurrentPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPerc.Location = new System.Drawing.Point(584, 34);
            this.labelCurrentPerc.Name = "labelCurrentPerc";
            this.labelCurrentPerc.Size = new System.Drawing.Size(21, 13);
            this.labelCurrentPerc.TabIndex = 14;
            this.labelCurrentPerc.Text = "0%";
            // 
            // labelOverallPerc
            // 
            this.labelOverallPerc.AutoSize = true;
            this.labelOverallPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverallPerc.Location = new System.Drawing.Point(584, 147);
            this.labelOverallPerc.Name = "labelOverallPerc";
            this.labelOverallPerc.Size = new System.Drawing.Size(21, 13);
            this.labelOverallPerc.TabIndex = 15;
            this.labelOverallPerc.Text = "0%";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 221);
            this.ControlBox = false;
            this.Controls.Add(this.labelOverallPerc);
            this.Controls.Add(this.labelCurrentPerc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrentFileProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBarOverallSplitFiles);
            this.Controls.Add(this.progressBarCurrentSplitFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProgressForm";
            this.Text = "Split Progress";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarCurrentSplitFile;
        private System.Windows.Forms.ProgressBar progressBarOverallSplitFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentFileProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCurrentPerc;
        private System.Windows.Forms.Label labelOverallPerc;

    }
}