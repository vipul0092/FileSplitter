using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSplitter.Misc_Forms;

namespace FileSplitter
{
    public partial class FolderOpsForm : Form
    {
        public FolderOpsForm()
        {
            InitializeComponent();
        }

        fileSplitter splitForm;
        FileFolderInfoExtractor extractor;

        public delegate void FolderFormCloseHandler(object sender, EventArgs e);
        public event FolderFormCloseHandler FolderFormClosed;

        private void FolderOpsForm_Load(object sender, EventArgs e)
        {
            // Fixing Bitmaps to make their background transparent
            Bitmap[] imgs = new Bitmap[4];
            imgs[0] = new System.Drawing.Bitmap(global::FileSplitter.Properties.Resources.Add);
            imgs[1] = new System.Drawing.Bitmap(global::FileSplitter.Properties.Resources.Extract);
            imgs[2] = new System.Drawing.Bitmap(global::FileSplitter.Properties.Resources.ExtractAll);
            imgs[3] = new System.Drawing.Bitmap(global::FileSplitter.Properties.Resources.Open);

            foreach (Bitmap image in imgs)
                image.MakeTransparent(Color.White);

            buttonSplit.Image = imgs[0]; buttonOpen.Image = imgs[3]; buttonExtract.Image = imgs[1]; buttonExtractAll.Image = imgs[2];
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {          
        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            splitForm = null; this.Hide();
            splitForm = new fileSplitter(); splitForm.Height = 428;
            splitForm.FolderWorkDone += splitForm_FolderWorkDone;
            splitForm.ShowForm(3, (new SettingsForm()).GetSettings());
        }

        void splitForm_FolderWorkDone(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FolderSplitWorker f = new FolderSplitWorker("E:\\Downloads\\", 8192, 419430400);
            //f.AccumulateFolderInfo();
            //f.setSaveLocation("D:\\");

            FolderJoinWorker f = new FolderJoinWorker("D:\\Downloads.vipf0", 8192);
            f.RunWorkerAsync();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            FolderFormClosed(this, null);
            base.OnFormClosing(e);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if(openSplitFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
            }
        }

        private void fbdSplit_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
