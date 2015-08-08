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

namespace FileSplitter.Misc_Forms
{
    public partial class ProgressForm : Form
    {
        bool IsSplitCancelled;
        string savePath;
        FolderSplitWorker eventThrower;

        public delegate void CloseFormHandler(object sender, CloseProgressFormEventArgs e);
        public event CloseFormHandler CloseProgressForm;
        public ProgressForm(ref FolderSplitWorker splitWorkerObject, string fileSavePath="")
        {
            InitializeComponent();
            savePath = fileSavePath; this.eventThrower = splitWorkerObject; IsSplitCancelled = false;
            eventThrower.ReportSplitProgress += SplitProgressHandler;
            eventThrower.SplittingDone += SplitCompletedHandler;
        }

        private void SplitProgressHandler(object sender, SplitProgressUpdateEventArgs e)
        {
            progressBarCurrentSplitFile.Value += e.CurrentSplitFilePercentage - progressBarCurrentSplitFile.Value; labelCurrentPerc.Text = e.CurrentSplitFilePercentage.ToString() + "%";
            progressBarOverallSplitFiles.Value += e.TotalSplitPercentage - progressBarOverallSplitFiles.Value; labelOverallPerc.Text = progressBarOverallSplitFiles.Value.ToString() + "%";
            labelCurrentFileProcess.Text = e.CurrentSplitFileNum + "/" + e.TotalSplitFiles;
        }

        private void SplitCompletedHandler(object sender, EventArgs e)
        {
            if (IsSplitCancelled == false)
            { 
                buttonOK.Enabled = true; buttonCancel.Enabled = false;
            }
            else if (IsSplitCancelled == true)
            {
                string ext1, ext2; int i = 0;            
                ext1 = ".vipf"; ext2 = ".vipfmeta";

                while (File.Exists(savePath + ext1 + i.ToString())) { File.Delete(savePath + ext1 + i.ToString()); i++; }
                if (File.Exists(savePath + ext2)) { File.Delete(savePath + ext2); }
                CloseProgressForm(null, new CloseProgressFormEventArgs(true));
                this.Close();
            }
            IsSplitCancelled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            IsSplitCancelled = true;
            eventThrower.CancelAsync();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CloseProgressForm(null, new CloseProgressFormEventArgs(false));
            this.Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {

        }

    }
}
