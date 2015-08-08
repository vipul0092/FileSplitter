using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using FileSplitter.EventArgs_Classes;
using FileSplitter.Hashing;
using FileSplitter.Misc_Forms;
using System.Diagnostics;


namespace FileSplitter
{
    public enum CheckSumMethod { Adler32 = 1, CRC32 = 2, MurMurHash3 = 3, Null = 0 };
    public enum SettingsSaveMethod { Registry = 1, INI = 2, Null = 0 };

    public partial class fileSplitter : Form
    {
        public fileSplitter()
        {
            InitializeComponent();            
        }

        FileUtilities fileToSplit;
        AppSettings settings;
        FolderSplitWorker folderSplit;
        ProgressForm progress;

        long buffer; //Size of the buffer used in processing files
        int checkCode; //Code telling the CheckSum Method to be Used in checking files
        string saveDirectory; //Member used to store save path for joined file
        bool IsSplitCancelled = false; //To check if splitting has been cancelled
        int joinStatus=0; //1 -> Join operation cancelled, 2 -> Hash Check Cancelled, 3 -> Hash Check Failed, 4 -> Success w/o Hash Calc, 0 -> Success
        bool IsFolder = false; // To Tell the form that Folder Split Operation is to be Done

        #region Public Members and Methods

        public delegate void FileWorkDoneHandler(object sender, FileWorkDoneEventArgs e);
        public event FileWorkDoneHandler FileWorkDone;

        public delegate void FolderWorkDoneHandler(object sender, EventArgs e);
        public event FolderWorkDoneHandler FolderWorkDone;

        public void ShowForm(int param, AppSettings settings=null)
        {
            //Update values according to the settings recieved
            this.settings = settings; this.buffer = (long)settings.Buffer;
            this.checkCode = (int)settings.CheckSumType; labelHashType.Text = "(" + settings.CheckSumType.ToString() + ")";
            this.Show();

            if (param == 1) //File Split
            { browseButton.Enabled = buttonCalcMD5.Enabled = groupBox1.Enabled = true; tabMain.SelectedTab = tabSplitFile; tabJoinFiles.Dispose(); comboBoxFileSize.SelectedIndex = 0; }
            else if (param == 2) // File Join
            { buttonJoinSplitFiles.Enabled = progressBarFileJoin.Enabled = true; tabMain.SelectedTab = tabJoinFiles; tabSplitFile.Dispose(); }
            else if (param == 3) // Folder Split/Join Form
            {
                tabJoinFiles.Dispose();
                labelSelect.Text = "Select the Folder whose contents are to be Split..."; lSize.Text = "Total Files Size:";
                infoHeaderLabel.Text = "Folder Details and Set Split Options";
                fileSizeLabel.Location = new Point(160, fileSizeLabel.Location.Y); tabSplitFile.Text = "SPLIT FOLDER CONTENTS";
                lChecksum.Visible = buttonCalcMD5.Visible = false; buttonSplitFile.Location = new Point(230, 316); buttonSplitFile.Size = new Size(226, 33);
                buttonSplitFile.Text = "SPLIT FOLDER CONTENTS"; IsFolder = true; browseButton.Enabled = true; labelHashType.Visible = false;
                browseButton_Click(null, null); groupBox1.Enabled = true;
            }
        }
        public void CancelSplitFolderTask()
        {
            folderSplit.CancelAsync();
        }

        #endregion

        #region Private Control Related and Other Methods

        private void fileInfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void labelCustom_Click(object sender, EventArgs e)
        {

        }

        private void labelMD5Show_Click(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = IsFolder?splitFolder.ShowDialog():openFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                comboBoxCustomSize.Items.Clear();
                if (!IsFolder)
                {
                    filePathLabel.Text = openFileDialog.FileName;
                    fileToSplit = new FileUtilities(openFileDialog.FileName, openFileDialog.InitialDirectory);
                    buttonCalcMD5.Enabled = true; labelMD5Show.Visible = false;
                    fileSizeLabel.Text = fileToSplit.FileSize; string t = fileToSplit.OrigFileName;

                    if (fileToSplit.MaxFileSize == "GB")
                    { comboBoxCustomSize.Items.Add("B"); comboBoxCustomSize.Items.Add("KB"); comboBoxCustomSize.Items.Add("MB"); comboBoxCustomSize.Items.Add("GB"); }
                    else if (fileToSplit.MaxFileSize == "MB")
                    { comboBoxCustomSize.Items.Add("B"); comboBoxCustomSize.Items.Add("KB"); comboBoxCustomSize.Items.Add("MB"); }
                    else if (fileToSplit.MaxFileSize == "KB")
                    { comboBoxCustomSize.Items.Add("B"); comboBoxCustomSize.Items.Add("KB"); }
                    else if (fileToSplit.MaxFileSize == "B")
                    { comboBoxCustomSize.Items.Add("B"); }
                }

                else
                {
                    filePathLabel.Text = splitFolder.SelectedPath;
                    folderSplit = null;
                    folderSplit = new FolderSplitWorker(splitFolder.SelectedPath, (int)buffer);
                    folderSplit.AccumulateFolderInfo(); folderSplit.ReportSplitProgress +=folderSplit_ReportSplitProgress;
                    folderSplit.SplittingDone +=folderSplit_SplittingDone;
                    fileSizeLabel.Text = FileUtilities.GetStringFromActualSize((float)folderSplit.TotalSize);
                    comboBoxCustomSize.Items.Add("B"); comboBoxCustomSize.Items.Add("KB"); comboBoxCustomSize.Items.Add("MB"); comboBoxCustomSize.Items.Add("GB"); 
                }

                 comboBoxCustomSize.SelectedIndex = 0; customSizeBox.Text = "1";
                 this.customSizeBox.TextChanged += new System.EventHandler(this.customSizeBox_TextChanged);
                 this.comboBoxCustomSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomSize_SelectedIndexChanged);
            
                 radioCustomSize.Checked = true; radioPredefSizes.Checked = false; radioNoOfFiles.Checked = false;
            }
        }

        private void folderSplit_SplittingDone(object sender, EventArgs e)
        {
            backgroundWorkerSplit_RunWorkerCompleted(null, null);
        }

        private void folderSplit_ReportSplitProgress(object sender, SplitProgressUpdateEventArgs e)
        {
            progressBarCurrentSplitFile.Value += e.CurrentSplitFilePercentage - progressBarCurrentSplitFile.Value; labelCurrentPerc.Text = e.CurrentSplitFilePercentage.ToString() + "%";
            progressBarOverallSplitFiles.Value += e.TotalSplitPercentage - progressBarOverallSplitFiles.Value; labelOverallPerc.Text = progressBarOverallSplitFiles.Value.ToString() + "%";
            labelCurrentFileProcess.Text = e.CurrentSplitFileNum + "/" + e.TotalSplitFiles;
        }
       
        private void buttonCalcMD5_Click(object sender, EventArgs e)
        {
            if (fileToSplit != null)
            {
                if (((Button)sender).Text == "Calculate")
                {
                    backgroundWorkerHash.RunWorkerAsync(fileToSplit); ((Button)sender).Text = "Cancel Operation";
                     labelMD5Show.Visible = true; labelHashProgress.BorderStyle = BorderStyle.FixedSingle;
                    labelMD5Show.Text = fileToSplit.MD5Sum;
                }
                else
                {
                    backgroundWorkerHash.CancelAsync();
                }
            }
        }
        
        private void radioPredefSizes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPredefSizes.Checked == true)
            {
                labelNewPredefSize.Enabled = true; comboBoxFileSize.Enabled = true;
                labelCustomSize.Enabled = false; customSizeBox.Enabled = false; comboBoxCustomSize.Enabled = false;
                labelFilesToSplit.Enabled = false; splitFilesReqd.Enabled = false;
                buttonSetOption.Enabled = true; buttonViewSplitDetails.Enabled = false; buttonSplitFile.Enabled = false;
                buttonSetOption_Click(null, null);
            }
        }     

        private void radioCustomSize_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCustomSize.Checked == true)
            {
                labelNewPredefSize.Enabled = false; comboBoxFileSize.Enabled = false;
                labelCustomSize.Enabled = true; customSizeBox.Enabled = true; comboBoxCustomSize.Enabled = true;
                labelFilesToSplit.Enabled = false; splitFilesReqd.Enabled = false;
                buttonSetOption.Enabled = true; buttonViewSplitDetails.Enabled = false; buttonSplitFile.Enabled = false;
                buttonSetOption_Click(null, null);
            }
        }

        private void radioNoOfFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNoOfFiles.Checked == true)
            {
                labelNewPredefSize.Enabled = false; comboBoxFileSize.Enabled = false;
                labelCustomSize.Enabled = false; customSizeBox.Enabled = false; comboBoxCustomSize.Enabled = false;
                labelFilesToSplit.Enabled = true; splitFilesReqd.Enabled = true;
                buttonSetOption.Enabled = true; buttonViewSplitDetails.Enabled = true; //buttonSplitFile.Enabled = true;
                buttonSetOption_Click(null, null);
            }
        }

        private void buttonSetOption_Click(object sender, EventArgs e)
        {
            float splitSize = 0, tmp=0; int success=0;
            if (fileToSplit != null || folderSplit != null)
            {
                if (radioPredefSizes.Checked == true)
                {
                    if (comboBoxFileSize.SelectedItem != null)
                    {
                        if (comboBoxFileSize.SelectedIndex == 0) { splitSize = 1024; }
                        else if (comboBoxFileSize.SelectedIndex == 1) { splitSize = 1048576; }
                        else if (comboBoxFileSize.SelectedIndex == 2) { splitSize = 104857600; }
                        else if (comboBoxFileSize.SelectedIndex == 3) { splitSize = 702545920; }
                        else if (comboBoxFileSize.SelectedIndex == 4) { splitSize = 1073741824; }
                        else if (comboBoxFileSize.SelectedIndex == 5) { splitSize = 2147483648; }
                        else if (comboBoxFileSize.SelectedIndex == 6) { splitSize = 4939212390; }
                        else if (comboBoxFileSize.SelectedIndex == 7) { splitSize = 9126805504; }
                        else success = 1;
                    }
                    else success = 1;
                }

                else if (radioCustomSize.Checked == true)
                {
                    if (float.TryParse(customSizeBox.Text, out tmp) == true)
                    {
                        if (comboBoxCustomSize.SelectedItem != null)
                        {
                            if (comboBoxCustomSize.SelectedIndex == 0) { splitSize = tmp; }
                            else if (comboBoxCustomSize.SelectedIndex == 1) { splitSize = tmp * 1024; }
                            else if (comboBoxCustomSize.SelectedIndex == 2) { splitSize = tmp * 1048576; }
                            else if (comboBoxCustomSize.SelectedIndex == 3) { splitSize = tmp * 1073741824; }
                            else success = 1;
                        }
                        else success = 1;
                    }
                }

                else if (radioNoOfFiles.Checked == true)
                {
                    splitSize = (IsFolder?this.folderSplit.TotalSize:(long) fileToSplit.ActualFileSize) /(long) splitFilesReqd.Value;
                    if (!IsFolder) fileToSplit.NoOfSplitFiles = (int)splitFilesReqd.Value;
                    else folderSplit.setNoOfFiles((int)splitFilesReqd.Value);
                }

                float t = IsFolder ? folderSplit.TotalSize : fileToSplit.ActualFileSize;
                if (splitSize < t && splitSize != 0)
                {
                    if (!IsFolder) fileToSplit.FileSplitSize = splitSize; else folderSplit.setSplitSize((long)splitSize);
                    buttonSetOption.Enabled = false; buttonViewSplitDetails.Enabled = true;
                    buttonViewSplitDetails.ForeColor = Color.Green; buttonViewSplitDetails.Text = "View Details About Files To Be Generated"; //buttonSplitFile.Enabled = true; 
                    if (radioNoOfFiles.Checked == false && success == 0) 
                    { 
                        if(!IsFolder)
                            fileToSplit.NoOfSplitFiles = (int)((Int64)(fileToSplit.ActualFileSize) / (Int64)(fileToSplit.FileSplitSize)) + 1;
                        else
                            folderSplit.setNoOfFiles((int)(folderSplit.TotalSize/folderSplit.SplitSize)+1);
                    }
                }
                else 
                {
                    buttonViewSplitDetails.Enabled = false; buttonViewSplitDetails.ForeColor = Color.Red;
                    buttonViewSplitDetails.Text = "Invalid Split file size data entered";
                    //MessageBox.Show("Incorrect Size Selected!\n\n\t\tReason:\nSplit Size is greater than or equal to Actual File Size, Select a Lower value or It is Zero!\n\tOR\nNo File Split Size Option Selected (B, KB, MB etc.)!", "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Hand); fileToSplit.FileSplitSize = 0; fileToSplit.NoOfSplitFiles = 0; buttonSplitFile.Enabled = false; 
                }
                    
            }
        }

        private void buttonViewSplitDetails_Click(object sender, EventArgs e)
        {
            if (fileToSplit != null) MessageBox.Show("No. Of Files To Be Generated: " + fileToSplit.NoOfSplitFiles.ToString() + "\n\nSize Of Each Split File: " + FileUtilities.GetStringFromActualSize(fileToSplit.FileSplitSize), "Split Files Information", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            else if(folderSplit != null) MessageBox.Show("No. Of Files To Be Generated: " + folderSplit.NoOfFiles + "\n\nSize Of Each Split File: " + FileUtilities.GetStringFromActualSize(folderSplit.SplitSize), "Split Files Information", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);            
        }

        private void comboBoxFileSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioPredefSizes_CheckedChanged(sender, e);
            buttonSetOption_Click(sender, e);
        }

        private void customSizeBox_TextChanged(object sender, EventArgs e)
        {
            radioCustomSize_CheckedChanged(sender, e);
            buttonSetOption_Click(sender, e);
        }

        private void comboBoxCustomSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioCustomSize_CheckedChanged(sender, e);
            buttonSetOption_Click(sender, e);
        }

        private void splitFilesReqd_ValueChanged(object sender, EventArgs e)
        {
            radioNoOfFiles_CheckedChanged(sender, e);
        }

        private void saveSplitFiles_Click(object sender, EventArgs e)
        {
            if (fileToSplit != null || folderSplit != null)
            {
                if (saveFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!IsFolder) fileToSplit.FileSavePath = saveFolderDialog.SelectedPath + "\\" + fileToSplit.OrigFileName;
                    else folderSplit.setSaveLocation(saveFolderDialog.SelectedPath);
                    labelSaveFolder.Text = "Split Files Saved here:-  " + saveFolderDialog.SelectedPath;
                    buttonSplitFile.Enabled = true; labelSaveFolder.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void buttonSplitFile_Click(object sender, EventArgs e)
        {
            //Disable All Controls
            browseButton.Enabled = false; buttonCalcMD5.Enabled = false; radioCustomSize.Enabled = false; radioNoOfFiles.Enabled = false; radioPredefSizes.Enabled = false;
            groupBox1.Enabled = false; saveSplitFiles.Enabled = saveSplitFilesSame.Enabled = false; buttonSplitFile.Enabled = false;

            if (!IsFolder)
            {
                //Show the GroupBox
                groupBoxSplitProgress.Visible = true; groupBoxSplitProgress.Enabled = true;
                SlideFormUpDown(0);
                backgroundWorkerSplit.RunWorkerAsync(fileToSplit);
            }
            else
            {
                progress = null;
                progress = new ProgressForm(ref folderSplit, folderSplit.StorageLocation+folderSplit.FileName);
                progress.CloseProgressForm += progress_CloseProgressForm;
                folderSplit.RunWorkerAsync(); this.Hide();
                progress.ShowDialog();             
            }
        }

        void progress_CloseProgressForm(object sender, CloseProgressFormEventArgs e)
        {
            buttonSplitFile.Enabled = true;
            browseButton.Enabled = true; groupBox1.Enabled = true; saveSplitFiles.Enabled = true; saveSplitFilesSame.Enabled = true;
            radioCustomSize.Enabled = radioNoOfFiles.Enabled = radioPredefSizes.Enabled = true; buttonSplitFile.Enabled = false;
            labelSaveFolder.Text = "";

            if (!(e.isCancelClose)) { this.Close(); }
            else this.Show();
            //FolderWorkDone(this, null);
        }

        // param = 0 -> Slide Down, 1 -> Slide Up
        private void SlideFormUpDown(int param)
        {
            switch (param)
            {
                case 0:
                    {
                        timerSlide.Tag = "SlideDown";
                        timerSlide.Start();
                        break;
                    }
                case 1:
                    {
                        timerSlide.Tag = "SlideUp";
                        timerSlide.Start();
                        break;
                    }
            }
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            if ((string)timerSlide.Tag == "SlideDown")
            {
                this.Height += 4;
                if (this.Height >= 610) { this.Height = 610; timerSlide.Stop(); }
            }
            else if ((string)timerSlide.Tag == "SlideUp")
            {
                this.Height -= 4;
                if (this.Height <= 428) { this.Height = 428; timerSlide.Stop(); }
            }
        }

        private void groupBoxSplitProgress_Enter(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            groupBoxSplitProgress.Visible = false; SlideFormUpDown(1);
            DialogResult res = MessageBox.Show("Splitting of Files Done and MetaFile Generated.\n Press \"OK\" to go to the folder where files have been generated.\n Press \"Cancel\" to go to Main Form. ", "SPLITTING DONE!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            

            if (res == System.Windows.Forms.DialogResult.Cancel)
            { FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(true, false);
              FileWorkDone(this, props);
              this.Close();
            }
            else if (res == System.Windows.Forms.DialogResult.OK)
            {
                string path = fileToSplit.FileSavePath;
                Process.Start("explorer.exe", path.Substring(0, path.LastIndexOf('\\')));
                
                FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(true, false);
                FileWorkDone(this, props);
                this.Close();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!IsFolder)
            {
                FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(false, true);
                FileWorkDone(this, props);
            }
            else FolderWorkDone(this, null);
            base.OnClosing(e);
        }

        private void backgroundWorkerHash_DoWork(object sender, DoWorkEventArgs e)
        {
            FileUtilities fSplit = ((FileUtilities)e.Argument); float currentHashProg=0; int success = 0;
            fSplit.CheckSumType = (CheckSumMethod)checkCode;
            CRC32 crchash = new CRC32(); FileStream fOpen; byte[] buffer = new byte[8192];
            HashAlgorithm crc32 = (HashAlgorithm)(crchash); long bytesHashed = 0;
            Adler32 adler32 = new Adler32(); MurmurHash3 murmurhash3 = new MurmurHash3();

            //************************************* Start Hashing *****************************************************

            if (checkCode == 2)
            {
                //------------------------------------ CRC32 Calculation For a file ---------------------------------------
                crc32.Initialize();
                using (fOpen = File.Open(fSplit.FilePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    while (bytesHashed != fOpen.Length)
                    {
                        if (backgroundWorkerHash.CancellationPending) { success = 1; break; }
                        if (fOpen.Length - bytesHashed < 8192)
                        { buffer = new byte[fOpen.Length - bytesHashed]; bytesHashed += fOpen.Read(buffer, 0, buffer.Length); }
                        else
                            bytesHashed += fOpen.Read(buffer, 0, buffer.Length);

                        ((CRC32)crc32).CalcHashBuffer(buffer, 0, buffer.Length);

                        currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;
                        backgroundWorkerHash.ReportProgress((int)currentHashProg);
                    }
                }

                if (success == 0)
                    fSplit.MD5Sum = ((CRC32)crc32).CalcHashFinal();
                else
                    fSplit.MD5Sum = "";
                //------------------------------------------------------------------------------------------------------
            }
            else if (checkCode == 1)
            {
                //========================= Adler32 Calculation for a File =============================================

                using (fOpen = File.Open(fSplit.FilePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    adler32.m_unChecksumValue = Adler32.AdlerStart;
                    byte[] bytesBuff = new byte[Adler32.AdlerBuff];
                    while (bytesHashed != fOpen.Length)
                    {
                        if (backgroundWorkerHash.CancellationPending) { success = 1; break; }

                        if (fOpen.Length - bytesHashed < 0x400)
                            bytesBuff = new byte[fOpen.Length - bytesHashed];


                        if (!adler32.MakeForBuff(bytesBuff, adler32.m_unChecksumValue))
                        {
                            adler32.m_unChecksumValue = 0;
                        }
                        else
                        {
                            bytesHashed += bytesBuff.Length;
                            currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;
                            backgroundWorkerHash.ReportProgress((int)currentHashProg);
                        }
                    }
                }

                if (success == 0) fSplit.MD5Sum = BitConverter.ToString(BitConverter.GetBytes(adler32.ChecksumValue), 0).Replace("-", "");
                else fSplit.MD5Sum = "";

                //======================================================================================================
            }
            else if (checkCode == 3)
            {
                //+++++++++++++++++++++++++++ MurmurHash3 Calculation of a File ++++++++++++++++++++++++++++++++++++++++

                buffer = new byte[4]; int prevProg = -1;
                using (fOpen = File.Open(fSplit.FilePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    while (bytesHashed != fOpen.Length)
                    {
                        if (backgroundWorkerHash.CancellationPending) { success = 1; break; }
                        if (fOpen.Length - bytesHashed < 4)
                        { buffer = new byte[fOpen.Length - bytesHashed]; bytesHashed += fOpen.Read(buffer, 0, buffer.Length); }
                        else
                            bytesHashed += fOpen.Read(buffer, 0, buffer.Length);

                        murmurhash3.CalcHashBuffer(buffer);
                        currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;

                        if (prevProg != (int)currentHashProg)
                            backgroundWorkerHash.ReportProgress((int)currentHashProg);

                        prevProg = (int)currentHashProg;
                    }
                }
                murmurhash3.Hash ^= murmurhash3.StreamLength;
                murmurhash3.Hash = MurmurHash3.fmix(murmurhash3.Hash);

                if (success == 0)
                    fSplit.MD5Sum = murmurhash3.GetHashString();
                else
                    fSplit.MD5Sum = "";

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            }
            else fSplit.MD5Sum = "";
         }

        private void backgroundWorkerHash_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelHashProgress.Text = e.ProgressPercentage.ToString() + " %";        
        }

        private void backgroundWorkerHash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                buttonCalcMD5.Text = "Calculate"; labelHashProgress.Text = ""; labelHashProgress.BorderStyle = BorderStyle.None;
                labelMD5Show.BorderStyle = BorderStyle.FixedSingle; labelMD5Show.Text = fileToSplit.MD5Sum;
            }
            else if(e.Cancelled == true)
            {
                labelHashProgress.BorderStyle = BorderStyle.None; buttonCalcMD5.Text = "Calculate"; labelMD5Show.BorderStyle = BorderStyle.FixedSingle; labelMD5Show.Text = "OPERATION CANCELLED!";
            }
        }

        private void backgroundWorkerSplit_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1800);
            FileUtilities fSplit = ((FileUtilities)e.Argument);

            byte[] tmpStorage; int splitFiles = fSplit.NoOfSplitFiles; int success = 0;          
            int i = 0; long timesToRun = 0, bytesRead = 0, _bytesRead=0, lastFileSize=0; //fileProgressForm.Show(this); timerUpdateSplitForm.Start();
           
            if (fSplit.FileSplitSize != 0)
            {

                FileStream fOpenOrig = File.OpenRead(fSplit.FilePath); FileStream fOpenNew;
                for (i = 0; i < splitFiles - 1; i++)
                {
                    fOpenNew = File.Open(fSplit.FileSavePath + ".vip" + i.ToString(), FileMode.Create, FileAccess.ReadWrite);
                    bytesRead = 0; fSplit.CurrentFileNumber = i + 1;
                    if ((Int64)fSplit.FileSplitSize > buffer)
                    {
                        timesToRun = ((Int64)fSplit.FileSplitSize / buffer) + 1;
                        while (timesToRun > 1)
                        {
                            if (backgroundWorkerSplit.CancellationPending) { success = 1; break; } tmpStorage=null;
                            tmpStorage = new byte[buffer];
                            bytesRead += fOpenOrig.Read(tmpStorage, 0, (int)buffer);
                            fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                            fSplit.TotalDataSplit += buffer; timesToRun--;
                            backgroundWorkerSplit.ReportProgress((int)(((float)bytesRead / (float)fSplit.FileSplitSize) * 100), fSplit);
                        }
                        if (success == 1) { fOpenNew.Close();  break; }
                        tmpStorage = new byte[(Int64)fSplit.FileSplitSize - bytesRead];
                        bytesRead += fOpenOrig.Read(tmpStorage, 0, tmpStorage.Length);
                        fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                        fSplit.TotalDataSplit += tmpStorage.Length;
                        backgroundWorkerSplit.ReportProgress((int)(((float)bytesRead / (float)fSplit.FileSplitSize) * 100), fSplit);
                        
                        fOpenNew.Close();

                    }
                    else
                    {
                        if (backgroundWorkerSplit.CancellationPending) { success = 1; fOpenNew.Close(); goto mid; }
                        tmpStorage = new byte[(Int64)fSplit.FileSplitSize];
                        bytesRead += fOpenOrig.Read(tmpStorage, 0, (int)fSplit.FileSplitSize);
                        fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                        fSplit.TotalDataSplit += tmpStorage.Length;
                        backgroundWorkerSplit.ReportProgress((int)(((float)bytesRead / (float)fSplit.FileSplitSize) * 100), fSplit);
                        
                         fOpenNew.Close();
                    }
                }

            mid:
                if (success == 1) goto end;
                fOpenNew = File.Open(fSplit.FileSavePath + ".vip" + i.ToString(), FileMode.Create, FileAccess.ReadWrite);
                bytesRead = i * (Int64)fSplit.FileSplitSize; fSplit.CurrentFileNumber = i + 1; lastFileSize = fOpenOrig.Length - bytesRead;
                if (((Int64)fOpenOrig.Length - bytesRead) > buffer)
                {
                    timesToRun = (((Int64)fOpenOrig.Length - bytesRead) / buffer) + 1;
                    while (timesToRun > 1)
                    {
                        if (backgroundWorkerSplit.CancellationPending) { success = 1; break; }
                        tmpStorage = new byte[(Int64)buffer];
                        bytesRead += fOpenOrig.Read(tmpStorage, 0, (int)buffer);
                        fOpenNew.Write(tmpStorage, 0, tmpStorage.Length); _bytesRead += tmpStorage.Length;
                        fSplit.TotalDataSplit += tmpStorage.Length;
                        backgroundWorkerSplit.ReportProgress((int)(((float)_bytesRead / (float)lastFileSize) * 100), fSplit);
                        
                        timesToRun--;
                    }
                    if (success == 1) { fOpenNew.Close();  goto end; }
                    tmpStorage = new byte[(Int64)fOpenOrig.Length - bytesRead];
                    bytesRead += fOpenOrig.Read(tmpStorage, 0, tmpStorage.Length);
                    fOpenNew.Write(tmpStorage, 0, tmpStorage.Length); _bytesRead += tmpStorage.Length;
                    fSplit.TotalDataSplit += tmpStorage.Length;
                    backgroundWorkerSplit.ReportProgress((int)(((float)_bytesRead / (float)lastFileSize) * 100), fSplit);
                        
                    fOpenNew.Close();
                }
                else
                {
                    if (backgroundWorkerSplit.CancellationPending) { success = 1; fOpenNew.Close(); goto end; }
                    tmpStorage = new byte[(Int64)fOpenOrig.Length - bytesRead];
                    bytesRead += fOpenOrig.Read(tmpStorage, 0, tmpStorage.Length);
                    fOpenNew.Write(tmpStorage, 0, tmpStorage.Length); _bytesRead += tmpStorage.Length;
                    fSplit.TotalDataSplit += tmpStorage.Length;
                    backgroundWorkerSplit.ReportProgress((int)(((float)_bytesRead / (float)lastFileSize) * 100), fSplit);
                    
                    fOpenNew.Close();
                }

            end:
                
                fOpenOrig.Close();
            }
        }

        private void backgroundWorkerSplit_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FileUtilities fSplit = ((FileUtilities)e.UserState);
            progressBarCurrentSplitFile.Value += e.ProgressPercentage - progressBarCurrentSplitFile.Value; labelCurrentPerc.Text = e.ProgressPercentage.ToString() + "%";
            progressBarOverallSplitFiles.Value += (int)(((float)fSplit.TotalDataSplit / fSplit.ActualFileSize) * 100) - progressBarOverallSplitFiles.Value; labelOverallPerc.Text = progressBarOverallSplitFiles.Value.ToString() + "%";
            labelCurrentFileProcess.Text = fSplit.CurrentFileNumber.ToString() + "/" + fSplit.NoOfSplitFiles.ToString();
        }

        private void backgroundWorkerSplit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IsSplitCancelled == false)
            {
                if (!IsFolder) { fileToSplit.GenerateMetaFile(); fileToSplit.IsFinished = true; }
                buttonOK.Enabled = true; buttonCancel.Enabled = false;
            }
            else if (IsSplitCancelled == true)
            {
                int i = 0; string ext1, ext2;
                /*DialogResult res = MessageBox.Show("Split Operation Cancelled!\n\nDo you want to delete the partially created split files ?", "OPERATION CANCELLED", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {   */
                if (!IsFolder) { ext1 = ".vip"; ext2 = ".vipmeta"; } else { ext1 = ".vipf"; ext2 = ".vipfmeta"; }

                    while (File.Exists(fileToSplit.FileSavePath + ext1 + i.ToString())) { File.Delete(fileToSplit.FileSavePath + ext1 + i.ToString()); i++; }
                    if (File.Exists(fileToSplit.FileSavePath + ext2)) { File.Delete(fileToSplit.FileSavePath + ext2); }
                   /* MessageBox.Show("Partially Split Files Deleted!", "Files Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/                
                FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(false, true);
                FileWorkDone(this, props);
                this.Close();
            }
            IsSplitCancelled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to cancel the Split Operation?", "Cancel Splitting?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!IsFolder) backgroundWorkerSplit.CancelAsync(); else folderSplit.CancelAsync();
                IsSplitCancelled = true; groupBoxSplitProgress.Visible = false;
            }
        }

        private void buttonJoinSplitFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = ".vip0 File|*.vip0";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string directoryName = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('\\') + 1);
                string startingFile = openFileDialog.FileName; saveDirectory = directoryName;
                string fileName = startingFile.Substring(startingFile.LastIndexOf('\\') + 1, startingFile.LastIndexOf('.') - startingFile.LastIndexOf('\\') - 1);
                FileMetaData fileData = FileUtilities.ReadBackMetaFile(saveDirectory, fileName);
                buttonJoinSplitFiles.Enabled = false; buttonJoinCancel.Enabled = true; fileToSplit = new FileUtilities("1", "2"); fileToSplit.OrigFileFullSavePath = saveDirectory + fileData.OriginalFileName;
                fileToSplit.ActualFileSize = fileData.OrigFileSize; 


                labelFile.Text = fileData.OriginalFileName; labelFileSize.Text = FileUtilities.GetStringFromActualSize(fileToSplit.ActualFileSize); labelNumSplit.Text = fileData.NoOfSplitFiles.ToString();
                if (fileData.FileCheckSum != "NC") labelChecksum.Text = fileData.FileCheckSum + "  [ " + fileData.CheckSumType.ToString() + " ]"; else labelChecksum.Text = "Not Calculated During Split";
                backgroundWorkerJoin.RunWorkerAsync(openFileDialog.FileName);
            }
            openFileDialog.Filter = "";
        }

        private void backgroundWorkerJoin_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = ((string)e.Argument);string directoryName = file.Substring(0, file.LastIndexOf('\\') + 1); 
            string startingFile = file; saveDirectory = directoryName;
            long origSize = 0;


            byte[] bufferStorage; long bytesCopied = 0, timesToRun = 0, bytesRead = 0, singleFileSize = 0; FileStream fOpenSplit;
            string fileName = startingFile.Substring(startingFile.LastIndexOf('\\') + 1, startingFile.LastIndexOf('.') - startingFile.LastIndexOf('\\') - 1);
            FileMetaData fileData = FileUtilities.ReadBackMetaFile(saveDirectory, fileName); origSize = fileData.OrigFileSize;
            FileStream fOpenOrig = File.Create(saveDirectory + fileData.OriginalFileName); file="join";

            int i = 0; origSize = fileData.OrigFileSize;
            for (i = 0; i < fileData.NoOfSplitFiles; i++)
            {
                if (backgroundWorkerJoin.CancellationPending) { joinStatus = 1; goto checksum; }
                fOpenSplit = File.Open(saveDirectory + fileName + ".vip" + i.ToString(), FileMode.Open, FileAccess.Read);
                bytesRead = 0; singleFileSize = fOpenSplit.Length;
                if (fOpenSplit.Length > buffer)
                {
                    bufferStorage = new byte[buffer];
                    timesToRun = (Int64)(fOpenSplit.Length / buffer) + 1;
                    while (timesToRun > 1)
                    {
                        if (backgroundWorkerJoin.CancellationPending) { joinStatus = 1; break; }
                        bytesRead += fOpenSplit.Read(bufferStorage, 0, bufferStorage.Length);
                        fOpenOrig.Write(bufferStorage, 0, bufferStorage.Length);
                        bytesCopied += buffer;
                        backgroundWorkerJoin.ReportProgress((int)(((float)(bytesCopied) / (float)(origSize)) * 100),file);
                        timesToRun--;
                    }
                    if (joinStatus == 1) { fOpenSplit.Close(); goto checksum; }
                    bufferStorage = new byte[fOpenSplit.Length - bytesRead];
                    bytesRead += fOpenSplit.Read(bufferStorage, 0, bufferStorage.Length);
                    fOpenOrig.Write(bufferStorage, 0, bufferStorage.Length); bytesCopied += bufferStorage.Length;
                    backgroundWorkerJoin.ReportProgress((int)(((float)(bytesCopied) / (float)(origSize)) * 100),file);

                    fOpenSplit.Close();
                }
                else
                {
                    if (backgroundWorkerJoin.CancellationPending) { fOpenSplit.Close(); joinStatus = 1; goto checksum; }
                    bufferStorage = new byte[fOpenSplit.Length];
                    bytesRead += fOpenSplit.Read(bufferStorage, 0, bufferStorage.Length);
                    fOpenOrig.Write(bufferStorage, 0, bufferStorage.Length); bytesCopied += bufferStorage.Length;
                    backgroundWorkerJoin.ReportProgress((int)(((float)(bytesCopied) / (float)(origSize)) * 100),file);
                    fOpenSplit.Close();
                }
            }

        checksum:
            fOpenOrig.Close();


            string hash = "";
            if (fileData.FileCheckSum == "NC")
            { if(joinStatus != 1) joinStatus = 4; }
            else if (joinStatus != 1)
            {
                if (MessageBox.Show("Joining of Files Done and Original File Generated.\n\nDo you want to check the generated file for integrity?\n( Whether it has been correctly generated or not )", "File Integrity Check", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    file = "check";
                    float currentHashProg = 0; int check = (int)fileData.CheckSumType;
                    CRC32 crchash = new CRC32(); FileStream fOpen; byte[] buffer = new byte[8192];
                    HashAlgorithm crc32 = (HashAlgorithm)(crchash); long bytesHashed = 0;
                    Adler32 adler32 = new Adler32(); MurmurHash3 murmurhash3 = new MurmurHash3();

                    //************************************* Start Hashing *****************************************************

                    if (check == 2)
                    {
                        //------------------------------------ CRC32 Calculation For a file ---------------------------------------
                        crc32.Initialize();
                        using (fOpen = File.Open(saveDirectory + fileData.OriginalFileName, FileMode.Open, FileAccess.ReadWrite))
                        {
                            while (bytesHashed != fOpen.Length)
                            {
                                if (backgroundWorkerJoin.CancellationPending) { joinStatus = 2; break; }
                                if (fOpen.Length - bytesHashed < 8192)
                                { buffer = new byte[fOpen.Length - bytesHashed]; bytesHashed += fOpen.Read(buffer, 0, buffer.Length); }
                                else
                                    bytesHashed += fOpen.Read(buffer, 0, buffer.Length);

                                ((CRC32)crc32).CalcHashBuffer(buffer, 0, buffer.Length);

                                currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;
                                backgroundWorkerJoin.ReportProgress((int)currentHashProg, file);
                            }
                        }

                        if (joinStatus == 0)
                            hash = ((CRC32)crc32).CalcHashFinal();
                        else
                            hash = "";
                        //------------------------------------------------------------------------------------------------------
                    }
                    else if (check == 1)
                    {
                        //========================= Adler32 Calculation for a File =============================================

                        using (fOpen = File.Open(saveDirectory + fileData.OriginalFileName, FileMode.Open, FileAccess.ReadWrite))
                        {
                            adler32.m_unChecksumValue = Adler32.AdlerStart;
                            byte[] bytesBuff = new byte[Adler32.AdlerBuff];
                            while (bytesHashed != fOpen.Length)
                            {
                                if (backgroundWorkerJoin.CancellationPending) { joinStatus = 2; break; }

                                if (fOpen.Length - bytesHashed < 0x400)
                                    bytesBuff = new byte[fOpen.Length - bytesHashed];


                                if (!adler32.MakeForBuff(bytesBuff, adler32.m_unChecksumValue))
                                {
                                    adler32.m_unChecksumValue = 0;
                                }
                                else
                                {
                                    bytesHashed += bytesBuff.Length;
                                    currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;
                                    backgroundWorkerJoin.ReportProgress((int)currentHashProg);
                                }
                            }
                        }

                        if (joinStatus == 0) hash = BitConverter.ToString(BitConverter.GetBytes(adler32.ChecksumValue), 0).Replace("-", "");
                        else hash = "";

                        //======================================================================================================
                    }
                    else if (check == 3)
                    {
                        //+++++++++++++++++++++++++++ MurmurHash3 Calculation of a File ++++++++++++++++++++++++++++++++++++++++

                        buffer = new byte[4]; int prevProg = -1;
                        using (fOpen = File.Open(saveDirectory + fileData.OriginalFileName, FileMode.Open, FileAccess.ReadWrite))
                        {
                            while (bytesHashed != fOpen.Length)
                            {
                                if (backgroundWorkerJoin.CancellationPending) { joinStatus = 2; break; }
                                if (fOpen.Length - bytesHashed < 4)
                                { buffer = new byte[fOpen.Length - bytesHashed]; bytesHashed += fOpen.Read(buffer, 0, buffer.Length); }
                                else
                                    bytesHashed += fOpen.Read(buffer, 0, buffer.Length);

                                murmurhash3.CalcHashBuffer(buffer);
                                currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;

                                if (prevProg != (int)currentHashProg)
                                    backgroundWorkerJoin.ReportProgress((int)currentHashProg);

                                prevProg = (int)currentHashProg;
                            }
                        }
                        murmurhash3.Hash ^= murmurhash3.StreamLength;
                        murmurhash3.Hash = MurmurHash3.fmix(murmurhash3.Hash);

                        if (joinStatus == 0)
                            hash = murmurhash3.GetHashString();
                        else
                            hash = "";

                        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    }
                }
                else joinStatus = 2;
                
                if (hash != fileData.FileCheckSum && hash != null && hash != ""){ joinStatus = 3; }
            }


        }

        private void backgroundWorkerJoin_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if ((string)e.UserState == "join")
            {
                progressBarFileJoin.Value += e.ProgressPercentage - progressBarFileJoin.Value;
                labelTotal.Text = progressBarFileJoin.Value.ToString() + " %";                
            }
            else if ((string)e.UserState == "check")
            {
                if (progressBarFileJoin.Value == 100)
                { progressBarFileJoin.Value = 0; labelTotal.Text = "0 %"; labelProgressName.Text = "HASH CALCULATION PROGRESS"; }

                progressBarFileJoin.Value += e.ProgressPercentage - progressBarFileJoin.Value;
                labelTotal.Text = progressBarFileJoin.Value.ToString() + " %"; 
            }
        }

        private void backgroundWorkerJoin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            switch (joinStatus)
            {
                case 1: // Join Operation Cancelled
                    {
                        
                        if (File.Exists(fileToSplit.OrigFileFullSavePath)) File.Delete(fileToSplit.OrigFileFullSavePath);
                        FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(false, true);
                        FileWorkDone(this, props);
                        this.Close();
                        break;
                    }
                case 2: // Hash Check Cancelled
                    {
                        ShowMessage("File Integrity Check Has Been Cancelled. \n\nPress \"Yes\" to go to the folder where the Original File has been created\nand \"No\" to return to the Main Form. ", "Integrity Check Cancelled");
                        break;
                    }
                case 3: // Hash Check Failed
                    {
                        ShowMessage("The File integrity check has failed. The File created may not work correctly.\n\n Press \"Yes\" to go to the folder where the Original File has been generated.\n Press \"No\" to go to Main Form.  ", "Integrity Check Failed");
                        break;
                    }
                case 0: // Success
                    {
                        ShowMessage("File Integrity has been verified. File checksums match.\n\nPress \"Yes\" to go to the folder where the Original File has been created\nand \"No\" to return to the Main Form. ", "Integrity Verified");
                        break;
                    }
                case 4: // Success w/o Hash Check
                    {
                        ShowMessage("Joining of Files Done and Original File Generated.\n\nPress \"Yes\" to go to the folder where the Original File has been created\nand \"No\" to return to the Main Form. ", "Joining Complete");
                        break;
                    }
            }
        }

        private void ShowMessage(string message, string  caption)
        {
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start("explorer.exe", saveDirectory);

                FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(false, true);
                FileWorkDone(this, props);
                this.Close();
            }
            else
            {
                FileWorkDoneEventArgs props = new FileWorkDoneEventArgs(false, true);
                FileWorkDone(this, props);
                this.Close();
            }
        }

        private void buttonJoinCancel_Click(object sender, EventArgs e)
        {
            string msg="", caption="";
            if (labelProgressName.Text == "FILE JOIN PROGRESS"){ msg="Do you really want to cancel the Join Operation?\nYou will be returned to the Main Form."; caption =  "Cancel Joining?"; }
            else if (labelProgressName.Text == "HASH CALCULATION PROGRESS") { msg = "Do you really want to cancel the File Integrity Check?\n\nNOTE: It'll not be \"sure\" that the generated file is exactly like the original."; caption = "Cancel File Check?"; }
            
            if (MessageBox.Show(msg,caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                backgroundWorkerJoin.CancelAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Height == 480)
                SlideFormUpDown(0);
            else if (this.Height == 718)
                SlideFormUpDown(1);
        }

        private void saveSplitFilesSame_Click(object sender, EventArgs e)
        {
            if (fileToSplit != null || folderSplit != null)
            {
                if (!IsFolder) fileToSplit.FileSavePath = fileToSplit.FileDefDirectory + "\\" + fileToSplit.OrigFileName;
                else folderSplit.setSaveLocation(folderSplit.RootFolder);
                labelSaveFolder.Text = "Split Files Saved here:-  " + (IsFolder?folderSplit.RootFolder:fileToSplit.FileDefDirectory);
                labelSaveFolder.BorderStyle = BorderStyle.FixedSingle;
                buttonSplitFile.Enabled = true;
            }
        }

        #endregion


    }
}
