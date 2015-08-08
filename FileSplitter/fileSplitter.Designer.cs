namespace FileSplitter
{
    partial class fileSplitter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileSplitter));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxSplitProgress = new System.Windows.Forms.GroupBox();
            this.labelCurrentPerc = new System.Windows.Forms.Label();
            this.labelOverallPerc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.progressBarOverallSplitFiles = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCurrentFileProcess = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarCurrentSplitFile = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerHash = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSplit = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerJoin = new System.ComponentModel.BackgroundWorker();
            this.timerSlide = new System.Windows.Forms.Timer(this.components);
            this.saveFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabJoinFiles = new System.Windows.Forms.TabPage();
            this.buttonJoinCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelChecksum = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.labelNumSplit = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelFinalPerc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelProgressName = new System.Windows.Forms.Label();
            this.progressBarFileJoin = new System.Windows.Forms.ProgressBar();
            this.buttonJoinSplitFiles = new System.Windows.Forms.Button();
            this.tabSplitFile = new System.Windows.Forms.TabPage();
            this.labelSaveFolder = new System.Windows.Forms.Label();
            this.lChecksum = new System.Windows.Forms.Label();
            this.lSize = new System.Windows.Forms.Label();
            this.saveSplitFilesSame = new System.Windows.Forms.Button();
            this.buttonSetOption = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelHashType = new System.Windows.Forms.Label();
            this.labelHashProgress = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonViewSplitDetails = new System.Windows.Forms.Button();
            this.labelFilesToSplit = new System.Windows.Forms.Label();
            this.labelCustomSize = new System.Windows.Forms.Label();
            this.labelNewPredefSize = new System.Windows.Forms.Label();
            this.radioNoOfFiles = new System.Windows.Forms.RadioButton();
            this.comboBoxFileSize = new System.Windows.Forms.ComboBox();
            this.radioCustomSize = new System.Windows.Forms.RadioButton();
            this.customSizeBox = new System.Windows.Forms.TextBox();
            this.comboBoxCustomSize = new System.Windows.Forms.ComboBox();
            this.radioPredefSizes = new System.Windows.Forms.RadioButton();
            this.splitFilesReqd = new System.Windows.Forms.NumericUpDown();
            this.labelMD5Show = new System.Windows.Forms.Label();
            this.buttonSplitFile = new System.Windows.Forms.Button();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.saveSplitFiles = new System.Windows.Forms.Button();
            this.buttonCalcMD5 = new System.Windows.Forms.Button();
            this.fileInfoLabel = new System.Windows.Forms.Label();
            this.infoHeaderLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.splitFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxSplitProgress.SuspendLayout();
            this.tabJoinFiles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabSplitFile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFilesReqd)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Open the File to be split...";
            // 
            // groupBoxSplitProgress
            // 
            this.groupBoxSplitProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxSplitProgress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSplitProgress.BackColor = System.Drawing.Color.LightBlue;
            this.groupBoxSplitProgress.Controls.Add(this.labelCurrentPerc);
            this.groupBoxSplitProgress.Controls.Add(this.labelOverallPerc);
            this.groupBoxSplitProgress.Controls.Add(this.label7);
            this.groupBoxSplitProgress.Controls.Add(this.label6);
            this.groupBoxSplitProgress.Controls.Add(this.buttonCancel);
            this.groupBoxSplitProgress.Controls.Add(this.buttonOK);
            this.groupBoxSplitProgress.Controls.Add(this.progressBarOverallSplitFiles);
            this.groupBoxSplitProgress.Controls.Add(this.label3);
            this.groupBoxSplitProgress.Controls.Add(this.labelCurrentFileProcess);
            this.groupBoxSplitProgress.Controls.Add(this.label2);
            this.groupBoxSplitProgress.Controls.Add(this.progressBarCurrentSplitFile);
            this.groupBoxSplitProgress.Controls.Add(this.label1);
            this.groupBoxSplitProgress.Enabled = false;
            this.groupBoxSplitProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSplitProgress.Location = new System.Drawing.Point(3, 391);
            this.groupBoxSplitProgress.Name = "groupBoxSplitProgress";
            this.groupBoxSplitProgress.Size = new System.Drawing.Size(733, 180);
            this.groupBoxSplitProgress.TabIndex = 30;
            this.groupBoxSplitProgress.TabStop = false;
            this.groupBoxSplitProgress.Text = "PROGRESS OF SPLIT OPERATION";
            this.groupBoxSplitProgress.Visible = false;
            this.groupBoxSplitProgress.Enter += new System.EventHandler(this.groupBoxSplitProgress_Enter);
            // 
            // labelCurrentPerc
            // 
            this.labelCurrentPerc.AutoSize = true;
            this.labelCurrentPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPerc.Location = new System.Drawing.Point(607, 35);
            this.labelCurrentPerc.Name = "labelCurrentPerc";
            this.labelCurrentPerc.Size = new System.Drawing.Size(21, 13);
            this.labelCurrentPerc.TabIndex = 12;
            this.labelCurrentPerc.Text = "0%";
            // 
            // labelOverallPerc
            // 
            this.labelOverallPerc.AutoSize = true;
            this.labelOverallPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverallPerc.Location = new System.Drawing.Point(607, 128);
            this.labelOverallPerc.Name = "labelOverallPerc";
            this.labelOverallPerc.Size = new System.Drawing.Size(21, 13);
            this.labelOverallPerc.TabIndex = 11;
            this.labelOverallPerc.Text = "0%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "0%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "0%";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(373, 147);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(213, 147);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK!";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // progressBarOverallSplitFiles
            // 
            this.progressBarOverallSplitFiles.Location = new System.Drawing.Point(92, 126);
            this.progressBarOverallSplitFiles.Name = "progressBarOverallSplitFiles";
            this.progressBarOverallSplitFiles.Size = new System.Drawing.Size(509, 15);
            this.progressBarOverallSplitFiles.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarOverallSplitFiles.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Overall Split Files Save Progress";
            // 
            // labelCurrentFileProcess
            // 
            this.labelCurrentFileProcess.BackColor = System.Drawing.Color.White;
            this.labelCurrentFileProcess.Location = new System.Drawing.Point(434, 65);
            this.labelCurrentFileProcess.Name = "labelCurrentFileProcess";
            this.labelCurrentFileProcess.Size = new System.Drawing.Size(167, 22);
            this.labelCurrentFileProcess.TabIndex = 4;
            this.labelCurrentFileProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current File Number Being Processed : ";
            // 
            // progressBarCurrentSplitFile
            // 
            this.progressBarCurrentSplitFile.Location = new System.Drawing.Point(92, 35);
            this.progressBarCurrentSplitFile.Name = "progressBarCurrentSplitFile";
            this.progressBarCurrentSplitFile.Size = new System.Drawing.Size(509, 15);
            this.progressBarCurrentSplitFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCurrentSplitFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Split File Save Progress";
            // 
            // backgroundWorkerHash
            // 
            this.backgroundWorkerHash.WorkerReportsProgress = true;
            this.backgroundWorkerHash.WorkerSupportsCancellation = true;
            this.backgroundWorkerHash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerHash_DoWork);
            this.backgroundWorkerHash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerHash_ProgressChanged);
            this.backgroundWorkerHash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerHash_RunWorkerCompleted);
            // 
            // backgroundWorkerSplit
            // 
            this.backgroundWorkerSplit.WorkerReportsProgress = true;
            this.backgroundWorkerSplit.WorkerSupportsCancellation = true;
            this.backgroundWorkerSplit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSplit_DoWork);
            this.backgroundWorkerSplit.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSplit_ProgressChanged);
            this.backgroundWorkerSplit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSplit_RunWorkerCompleted);
            // 
            // backgroundWorkerJoin
            // 
            this.backgroundWorkerJoin.WorkerReportsProgress = true;
            this.backgroundWorkerJoin.WorkerSupportsCancellation = true;
            this.backgroundWorkerJoin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerJoin_DoWork);
            this.backgroundWorkerJoin.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerJoin_ProgressChanged);
            this.backgroundWorkerJoin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerJoin_RunWorkerCompleted);
            // 
            // timerSlide
            // 
            this.timerSlide.Interval = 20;
            this.timerSlide.Tick += new System.EventHandler(this.timerSlide_Tick);
            // 
            // saveFolderDialog
            // 
            this.saveFolderDialog.Description = "Select The Folder to save the split files";
            // 
            // tabJoinFiles
            // 
            this.tabJoinFiles.Controls.Add(this.buttonJoinCancel);
            this.tabJoinFiles.Controls.Add(this.panel1);
            this.tabJoinFiles.Controls.Add(this.labelTotal);
            this.tabJoinFiles.Controls.Add(this.labelFinalPerc);
            this.tabJoinFiles.Controls.Add(this.label5);
            this.tabJoinFiles.Controls.Add(this.labelProgressName);
            this.tabJoinFiles.Controls.Add(this.progressBarFileJoin);
            this.tabJoinFiles.Controls.Add(this.buttonJoinSplitFiles);
            this.tabJoinFiles.Location = new System.Drawing.Point(4, 22);
            this.tabJoinFiles.Name = "tabJoinFiles";
            this.tabJoinFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabJoinFiles.Size = new System.Drawing.Size(725, 360);
            this.tabJoinFiles.TabIndex = 1;
            this.tabJoinFiles.Text = "JOIN FILES";
            this.tabJoinFiles.UseVisualStyleBackColor = true;
            // 
            // buttonJoinCancel
            // 
            this.buttonJoinCancel.Enabled = false;
            this.buttonJoinCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJoinCancel.ForeColor = System.Drawing.Color.Red;
            this.buttonJoinCancel.Location = new System.Drawing.Point(314, 219);
            this.buttonJoinCancel.Name = "buttonJoinCancel";
            this.buttonJoinCancel.Size = new System.Drawing.Size(93, 26);
            this.buttonJoinCancel.TabIndex = 34;
            this.buttonJoinCancel.Text = "CANCEL";
            this.buttonJoinCancel.UseVisualStyleBackColor = true;
            this.buttonJoinCancel.Click += new System.EventHandler(this.buttonJoinCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelChecksum);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.labelFileSize);
            this.panel1.Controls.Add(this.labelNumSplit);
            this.panel1.Controls.Add(this.labelFile);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(38, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 56);
            this.panel1.TabIndex = 33;
            // 
            // labelChecksum
            // 
            this.labelChecksum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChecksum.Location = new System.Drawing.Point(393, 33);
            this.labelChecksum.Name = "labelChecksum";
            this.labelChecksum.Size = new System.Drawing.Size(214, 13);
            this.labelChecksum.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(303, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "File CheckSum:";
            // 
            // labelFileSize
            // 
            this.labelFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileSize.Location = new System.Drawing.Point(75, 33);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(214, 13);
            this.labelFileSize.TabIndex = 5;
            // 
            // labelNumSplit
            // 
            this.labelNumSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumSplit.Location = new System.Drawing.Point(407, 10);
            this.labelNumSplit.Name = "labelNumSplit";
            this.labelNumSplit.Size = new System.Drawing.Size(214, 13);
            this.labelNumSplit.TabIndex = 4;
            // 
            // labelFile
            // 
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFile.Location = new System.Drawing.Point(75, 10);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(214, 13);
            this.labelFile.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "No. Of Split Files: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "File Size: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "File Name: ";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(623, 180);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(24, 13);
            this.labelTotal.TabIndex = 32;
            this.labelTotal.Text = "0 %";
            // 
            // labelFinalPerc
            // 
            this.labelFinalPerc.AutoSize = true;
            this.labelFinalPerc.Location = new System.Drawing.Point(610, 125);
            this.labelFinalPerc.Name = "labelFinalPerc";
            this.labelFinalPerc.Size = new System.Drawing.Size(0, 13);
            this.labelFinalPerc.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "0 %";
            // 
            // labelProgressName
            // 
            this.labelProgressName.AutoSize = true;
            this.labelProgressName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgressName.Location = new System.Drawing.Point(311, 125);
            this.labelProgressName.Name = "labelProgressName";
            this.labelProgressName.Size = new System.Drawing.Size(133, 15);
            this.labelProgressName.TabIndex = 2;
            this.labelProgressName.Text = "FILE JOIN PROGRESS";
            // 
            // progressBarFileJoin
            // 
            this.progressBarFileJoin.Enabled = false;
            this.progressBarFileJoin.Location = new System.Drawing.Point(83, 157);
            this.progressBarFileJoin.Name = "progressBarFileJoin";
            this.progressBarFileJoin.Size = new System.Drawing.Size(564, 20);
            this.progressBarFileJoin.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarFileJoin.TabIndex = 1;
            // 
            // buttonJoinSplitFiles
            // 
            this.buttonJoinSplitFiles.Enabled = false;
            this.buttonJoinSplitFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJoinSplitFiles.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonJoinSplitFiles.Location = new System.Drawing.Point(191, 18);
            this.buttonJoinSplitFiles.Name = "buttonJoinSplitFiles";
            this.buttonJoinSplitFiles.Size = new System.Drawing.Size(327, 32);
            this.buttonJoinSplitFiles.TabIndex = 0;
            this.buttonJoinSplitFiles.Text = "SELECT FIRST OF THE SPLIT FILES TO JOIN";
            this.buttonJoinSplitFiles.UseVisualStyleBackColor = true;
            this.buttonJoinSplitFiles.Click += new System.EventHandler(this.buttonJoinSplitFiles_Click);
            // 
            // tabSplitFile
            // 
            this.tabSplitFile.Controls.Add(this.labelSaveFolder);
            this.tabSplitFile.Controls.Add(this.lChecksum);
            this.tabSplitFile.Controls.Add(this.lSize);
            this.tabSplitFile.Controls.Add(this.saveSplitFilesSame);
            this.tabSplitFile.Controls.Add(this.buttonSetOption);
            this.tabSplitFile.Controls.Add(this.button1);
            this.tabSplitFile.Controls.Add(this.labelHashType);
            this.tabSplitFile.Controls.Add(this.labelHashProgress);
            this.tabSplitFile.Controls.Add(this.groupBox1);
            this.tabSplitFile.Controls.Add(this.labelMD5Show);
            this.tabSplitFile.Controls.Add(this.buttonSplitFile);
            this.tabSplitFile.Controls.Add(this.fileSizeLabel);
            this.tabSplitFile.Controls.Add(this.saveSplitFiles);
            this.tabSplitFile.Controls.Add(this.buttonCalcMD5);
            this.tabSplitFile.Controls.Add(this.fileInfoLabel);
            this.tabSplitFile.Controls.Add(this.infoHeaderLabel);
            this.tabSplitFile.Controls.Add(this.browseButton);
            this.tabSplitFile.Controls.Add(this.filePathLabel);
            this.tabSplitFile.Controls.Add(this.labelSelect);
            this.tabSplitFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSplitFile.Location = new System.Drawing.Point(4, 22);
            this.tabSplitFile.Name = "tabSplitFile";
            this.tabSplitFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabSplitFile.Size = new System.Drawing.Size(725, 360);
            this.tabSplitFile.TabIndex = 0;
            this.tabSplitFile.Text = "SPLIT A FILE";
            this.tabSplitFile.UseVisualStyleBackColor = true;
            // 
            // labelSaveFolder
            // 
            this.labelSaveFolder.Location = new System.Drawing.Point(67, 254);
            this.labelSaveFolder.Name = "labelSaveFolder";
            this.labelSaveFolder.Size = new System.Drawing.Size(600, 23);
            this.labelSaveFolder.TabIndex = 36;
            // 
            // lChecksum
            // 
            this.lChecksum.AutoSize = true;
            this.lChecksum.Location = new System.Drawing.Point(61, 105);
            this.lChecksum.Name = "lChecksum";
            this.lChecksum.Size = new System.Drawing.Size(70, 15);
            this.lChecksum.TabIndex = 35;
            this.lChecksum.Text = "CheckSum:";
            // 
            // lSize
            // 
            this.lSize.AutoSize = true;
            this.lSize.Location = new System.Drawing.Point(61, 75);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(57, 15);
            this.lSize.TabIndex = 34;
            this.lSize.Text = "File Size:";
            // 
            // saveSplitFilesSame
            // 
            this.saveSplitFilesSame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSplitFilesSame.Location = new System.Drawing.Point(351, 285);
            this.saveSplitFilesSame.Name = "saveSplitFilesSame";
            this.saveSplitFilesSame.Size = new System.Drawing.Size(298, 25);
            this.saveSplitFilesSame.TabIndex = 33;
            this.saveSplitFilesSame.Text = "Select Same Folder as the File";
            this.saveSplitFilesSame.UseVisualStyleBackColor = true;
            this.saveSplitFilesSame.Click += new System.EventHandler(this.saveSplitFilesSame_Click);
            // 
            // buttonSetOption
            // 
            this.buttonSetOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetOption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buttonSetOption.Location = new System.Drawing.Point(517, 75);
            this.buttonSetOption.Name = "buttonSetOption";
            this.buttonSetOption.Size = new System.Drawing.Size(95, 23);
            this.buttonSetOption.TabIndex = 21;
            this.buttonSetOption.Text = "SET OPTION";
            this.buttonSetOption.UseVisualStyleBackColor = true;
            this.buttonSetOption.Visible = false;
            this.buttonSetOption.Click += new System.EventHandler(this.buttonSetOption_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelHashType
            // 
            this.labelHashType.Location = new System.Drawing.Point(134, 105);
            this.labelHashType.Name = "labelHashType";
            this.labelHashType.Size = new System.Drawing.Size(104, 18);
            this.labelHashType.TabIndex = 31;
            // 
            // labelHashProgress
            // 
            this.labelHashProgress.Location = new System.Drawing.Point(385, 101);
            this.labelHashProgress.Name = "labelHashProgress";
            this.labelHashProgress.Size = new System.Drawing.Size(59, 23);
            this.labelHashProgress.TabIndex = 30;
            this.labelHashProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonViewSplitDetails);
            this.groupBox1.Controls.Add(this.labelFilesToSplit);
            this.groupBox1.Controls.Add(this.labelCustomSize);
            this.groupBox1.Controls.Add(this.labelNewPredefSize);
            this.groupBox1.Controls.Add(this.radioNoOfFiles);
            this.groupBox1.Controls.Add(this.comboBoxFileSize);
            this.groupBox1.Controls.Add(this.radioCustomSize);
            this.groupBox1.Controls.Add(this.customSizeBox);
            this.groupBox1.Controls.Add(this.comboBoxCustomSize);
            this.groupBox1.Controls.Add(this.radioPredefSizes);
            this.groupBox1.Controls.Add(this.splitFilesReqd);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(64, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 121);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select A Split File Option...";
            // 
            // buttonViewSplitDetails
            // 
            this.buttonViewSplitDetails.Enabled = false;
            this.buttonViewSplitDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewSplitDetails.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonViewSplitDetails.Location = new System.Drawing.Point(339, 59);
            this.buttonViewSplitDetails.Name = "buttonViewSplitDetails";
            this.buttonViewSplitDetails.Size = new System.Drawing.Size(246, 23);
            this.buttonViewSplitDetails.TabIndex = 22;
            this.buttonViewSplitDetails.Text = "View Details About Files To Be Generated";
            this.buttonViewSplitDetails.UseVisualStyleBackColor = true;
            this.buttonViewSplitDetails.Click += new System.EventHandler(this.buttonViewSplitDetails_Click);
            // 
            // labelFilesToSplit
            // 
            this.labelFilesToSplit.AutoSize = true;
            this.labelFilesToSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilesToSplit.Location = new System.Drawing.Point(25, 95);
            this.labelFilesToSplit.Name = "labelFilesToSplit";
            this.labelFilesToSplit.Size = new System.Drawing.Size(129, 15);
            this.labelFilesToSplit.TabIndex = 20;
            this.labelFilesToSplit.Text = "No. Of Files to Split to: ";
            // 
            // labelCustomSize
            // 
            this.labelCustomSize.AutoSize = true;
            this.labelCustomSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomSize.Location = new System.Drawing.Point(25, 59);
            this.labelCustomSize.Name = "labelCustomSize";
            this.labelCustomSize.Size = new System.Drawing.Size(105, 15);
            this.labelCustomSize.TabIndex = 19;
            this.labelCustomSize.Text = "Custom File Size: ";
            // 
            // labelNewPredefSize
            // 
            this.labelNewPredefSize.AutoSize = true;
            this.labelNewPredefSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPredefSize.Location = new System.Drawing.Point(25, 19);
            this.labelNewPredefSize.Name = "labelNewPredefSize";
            this.labelNewPredefSize.Size = new System.Drawing.Size(149, 15);
            this.labelNewPredefSize.TabIndex = 17;
            this.labelNewPredefSize.Text = "New File Size To Split To: ";
            // 
            // radioNoOfFiles
            // 
            this.radioNoOfFiles.AutoSize = true;
            this.radioNoOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNoOfFiles.Location = new System.Drawing.Point(6, 95);
            this.radioNoOfFiles.Name = "radioNoOfFiles";
            this.radioNoOfFiles.Size = new System.Drawing.Size(25, 19);
            this.radioNoOfFiles.TabIndex = 18;
            this.radioNoOfFiles.TabStop = true;
            this.radioNoOfFiles.Text = "\r\n";
            this.radioNoOfFiles.UseVisualStyleBackColor = true;
            this.radioNoOfFiles.CheckedChanged += new System.EventHandler(this.radioNoOfFiles_CheckedChanged);
            // 
            // comboBoxFileSize
            // 
            this.comboBoxFileSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFileSize.FormattingEnabled = true;
            this.comboBoxFileSize.Items.AddRange(new object[] {
            "1.0 KB",
            "1.0 MB",
            "100 MB",
            "670 MB (CD)",
            "1 GB",
            "2 GB",
            "4.6 GB (Single Layer DVD)",
            "8.5 GB (Dual Layer DVD)"});
            this.comboBoxFileSize.Location = new System.Drawing.Point(175, 15);
            this.comboBoxFileSize.Name = "comboBoxFileSize";
            this.comboBoxFileSize.Size = new System.Drawing.Size(159, 23);
            this.comboBoxFileSize.TabIndex = 8;
            this.comboBoxFileSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileSize_SelectedIndexChanged);
            // 
            // radioCustomSize
            // 
            this.radioCustomSize.AutoSize = true;
            this.radioCustomSize.Location = new System.Drawing.Point(6, 57);
            this.radioCustomSize.Name = "radioCustomSize";
            this.radioCustomSize.Size = new System.Drawing.Size(25, 19);
            this.radioCustomSize.TabIndex = 17;
            this.radioCustomSize.TabStop = true;
            this.radioCustomSize.Text = "\r\n";
            this.radioCustomSize.UseVisualStyleBackColor = true;
            this.radioCustomSize.CheckedChanged += new System.EventHandler(this.radioCustomSize_CheckedChanged);
            // 
            // customSizeBox
            // 
            this.customSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customSizeBox.Location = new System.Drawing.Point(145, 57);
            this.customSizeBox.Name = "customSizeBox";
            this.customSizeBox.Size = new System.Drawing.Size(68, 21);
            this.customSizeBox.TabIndex = 10;
            this.customSizeBox.Text = "0.0";
            this.customSizeBox.TextChanged += new System.EventHandler(this.customSizeBox_TextChanged);
            // 
            // comboBoxCustomSize
            // 
            this.comboBoxCustomSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomSize.FormattingEnabled = true;
            this.comboBoxCustomSize.Location = new System.Drawing.Point(223, 57);
            this.comboBoxCustomSize.Name = "comboBoxCustomSize";
            this.comboBoxCustomSize.Size = new System.Drawing.Size(52, 23);
            this.comboBoxCustomSize.TabIndex = 15;
            // 
            // radioPredefSizes
            // 
            this.radioPredefSizes.AutoSize = true;
            this.radioPredefSizes.Location = new System.Drawing.Point(6, 19);
            this.radioPredefSizes.Name = "radioPredefSizes";
            this.radioPredefSizes.Size = new System.Drawing.Size(25, 19);
            this.radioPredefSizes.TabIndex = 16;
            this.radioPredefSizes.TabStop = true;
            this.radioPredefSizes.Text = "\r\n";
            this.radioPredefSizes.UseVisualStyleBackColor = true;
            this.radioPredefSizes.CheckedChanged += new System.EventHandler(this.radioPredefSizes_CheckedChanged);
            // 
            // splitFilesReqd
            // 
            this.splitFilesReqd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitFilesReqd.Location = new System.Drawing.Point(166, 95);
            this.splitFilesReqd.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.splitFilesReqd.Name = "splitFilesReqd";
            this.splitFilesReqd.Size = new System.Drawing.Size(47, 21);
            this.splitFilesReqd.TabIndex = 11;
            this.splitFilesReqd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.splitFilesReqd.ValueChanged += new System.EventHandler(this.splitFilesReqd_ValueChanged);
            // 
            // labelMD5Show
            // 
            this.labelMD5Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMD5Show.ForeColor = System.Drawing.Color.Red;
            this.labelMD5Show.Location = new System.Drawing.Point(469, 101);
            this.labelMD5Show.Name = "labelMD5Show";
            this.labelMD5Show.Size = new System.Drawing.Size(198, 23);
            this.labelMD5Show.TabIndex = 7;
            this.labelMD5Show.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMD5Show.Click += new System.EventHandler(this.labelMD5Show_Click);
            // 
            // buttonSplitFile
            // 
            this.buttonSplitFile.Enabled = false;
            this.buttonSplitFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSplitFile.Location = new System.Drawing.Point(230, 316);
            this.buttonSplitFile.Name = "buttonSplitFile";
            this.buttonSplitFile.Size = new System.Drawing.Size(226, 33);
            this.buttonSplitFile.TabIndex = 28;
            this.buttonSplitFile.Text = "SPLIT FILE";
            this.buttonSplitFile.UseVisualStyleBackColor = true;
            this.buttonSplitFile.Click += new System.EventHandler(this.buttonSplitFile_Click);
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSizeLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.fileSizeLabel.Location = new System.Drawing.Point(124, 75);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(49, 15);
            this.fileSizeLabel.TabIndex = 5;
            this.fileSizeLabel.Text = "0.0 KB";
            // 
            // saveSplitFiles
            // 
            this.saveSplitFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSplitFiles.Location = new System.Drawing.Point(64, 285);
            this.saveSplitFiles.Name = "saveSplitFiles";
            this.saveSplitFiles.Size = new System.Drawing.Size(275, 25);
            this.saveSplitFiles.TabIndex = 26;
            this.saveSplitFiles.Text = "Select Different Folder for Split Files";
            this.saveSplitFiles.UseVisualStyleBackColor = true;
            this.saveSplitFiles.Click += new System.EventHandler(this.saveSplitFiles_Click);
            // 
            // buttonCalcMD5
            // 
            this.buttonCalcMD5.Enabled = false;
            this.buttonCalcMD5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcMD5.Location = new System.Drawing.Point(258, 101);
            this.buttonCalcMD5.Name = "buttonCalcMD5";
            this.buttonCalcMD5.Size = new System.Drawing.Size(81, 23);
            this.buttonCalcMD5.TabIndex = 25;
            this.buttonCalcMD5.Text = "Calculate";
            this.buttonCalcMD5.UseVisualStyleBackColor = true;
            this.buttonCalcMD5.Click += new System.EventHandler(this.buttonCalcMD5_Click);
            // 
            // fileInfoLabel
            // 
            this.fileInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileInfoLabel.Location = new System.Drawing.Point(49, 73);
            this.fileInfoLabel.Name = "fileInfoLabel";
            this.fileInfoLabel.Size = new System.Drawing.Size(629, 208);
            this.fileInfoLabel.TabIndex = 24;
            // 
            // infoHeaderLabel
            // 
            this.infoHeaderLabel.AutoSize = true;
            this.infoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoHeaderLabel.Location = new System.Drawing.Point(46, 56);
            this.infoHeaderLabel.Name = "infoHeaderLabel";
            this.infoHeaderLabel.Size = new System.Drawing.Size(215, 17);
            this.infoHeaderLabel.TabIndex = 23;
            this.infoHeaderLabel.Text = "File Details And Set Split Options";
            // 
            // browseButton
            // 
            this.browseButton.Enabled = false;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(539, 20);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(110, 31);
            this.browseButton.TabIndex = 22;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // filePathLabel
            // 
            this.filePathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathLabel.Location = new System.Drawing.Point(49, 27);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(484, 20);
            this.filePathLabel.TabIndex = 21;
            // 
            // labelSelect
            // 
            this.labelSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelect.Location = new System.Drawing.Point(49, 12);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(484, 15);
            this.labelSelect.TabIndex = 20;
            this.labelSelect.Text = "Select The File To Split...";
            this.labelSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSplitFile);
            this.tabMain.Controls.Add(this.tabJoinFiles);
            this.tabMain.Location = new System.Drawing.Point(3, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(733, 386);
            this.tabMain.TabIndex = 20;
            // 
            // splitFolder
            // 
            this.splitFolder.Description = "Select The Folder whose contents are to be split";
            // 
            // fileSplitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 572);
            this.Controls.Add(this.groupBoxSplitProgress);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fileSplitter";
            this.groupBoxSplitProgress.ResumeLayout(false);
            this.groupBoxSplitProgress.PerformLayout();
            this.tabJoinFiles.ResumeLayout(false);
            this.tabJoinFiles.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabSplitFile.ResumeLayout(false);
            this.tabSplitFile.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFilesReqd)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBoxSplitProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarCurrentSplitFile;
        private System.Windows.Forms.Label label2;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ProgressBar progressBarOverallSplitFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCurrentFileProcess;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerHash;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSplit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCurrentPerc;
        private System.Windows.Forms.Label labelOverallPerc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorkerJoin;
        private System.Windows.Forms.Timer timerSlide;
        private System.Windows.Forms.FolderBrowserDialog saveFolderDialog;
        private System.Windows.Forms.TabPage tabJoinFiles;
        private System.Windows.Forms.Button buttonJoinCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelChecksum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Label labelNumSplit;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelFinalPerc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelProgressName;
        private System.Windows.Forms.ProgressBar progressBarFileJoin;
        private System.Windows.Forms.Button buttonJoinSplitFiles;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        //private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.TabPage tabSplitFile;
        private System.Windows.Forms.Button saveSplitFilesSame;
        private System.Windows.Forms.Button buttonSetOption;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelHashType;
        private System.Windows.Forms.Label labelHashProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonViewSplitDetails;
        private System.Windows.Forms.Label labelFilesToSplit;
        private System.Windows.Forms.Label labelCustomSize;
        private System.Windows.Forms.Label labelNewPredefSize;
        private System.Windows.Forms.RadioButton radioNoOfFiles;
        private System.Windows.Forms.ComboBox comboBoxFileSize;
        private System.Windows.Forms.RadioButton radioCustomSize;
        private System.Windows.Forms.TextBox customSizeBox;
        private System.Windows.Forms.ComboBox comboBoxCustomSize;
        private System.Windows.Forms.RadioButton radioPredefSizes;
        private System.Windows.Forms.NumericUpDown splitFilesReqd;
        private System.Windows.Forms.Label labelMD5Show;
        private System.Windows.Forms.Button buttonSplitFile;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.Button saveSplitFiles;
        private System.Windows.Forms.Button buttonCalcMD5;
        private System.Windows.Forms.Label fileInfoLabel;
        private System.Windows.Forms.Label infoHeaderLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Label lChecksum;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label labelSaveFolder;
        private System.Windows.Forms.FolderBrowserDialog splitFolder;
    }
}

