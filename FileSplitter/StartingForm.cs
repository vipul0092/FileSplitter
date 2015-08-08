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
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();

            settings = new SettingsForm();
            aboutApp = new AboutApplication();
        }

        private void mainForm_FileWorkDone(object sender, EventArgs_Classes.FileWorkDoneEventArgs e)
        {
            this.Show();
        }

        fileSplitter mainForm;
        AboutApplication aboutApp;
        SettingsForm settings;
        FolderOpsForm folderForm;

        void setCoordintes(ref fileSplitter form)
        {
           // form.DesktopLocation = this.DesktopLocation;
        }

        void setCoordintes(ref SettingsForm form)
        {
           // form.DesktopLocation = this.DesktopLocation;
        }

        void setCoordintes(ref FolderOpsForm form)
        {
            //form.DesktopLocation = this.DesktopLocation;
        }

        private void pictureJoinFiles_MouseEnter(object sender, EventArgs e)
        {
            buttonJoinFiles.BackgroundImage = global::FileSplitter.Properties.Resources.JoinFileSelected;
            Application.DoEvents();
        }

        private void pictureJoinFiles_MouseLeave(object sender, EventArgs e)
        {
            buttonJoinFiles.BackgroundImage = global::FileSplitter.Properties.Resources.JoinFileUnselected;
            Application.DoEvents();
        }

        private void pictureSplitFiles_MouseEnter(object sender, EventArgs e)
        {
            buttonSplitFiles.BackgroundImage = global::FileSplitter.Properties.Resources.SplitFileSelected; Application.DoEvents();
        }

        private void pictureSplitFiles_MouseLeave(object sender, EventArgs e)
        {
            buttonSplitFiles.BackgroundImage = global::FileSplitter.Properties.Resources.SplitFileUnselected; Application.DoEvents();
        }

        private void pictureAbout_MouseEnter(object sender, EventArgs e)
        {
            buttonAbout.BackgroundImage = global::FileSplitter.Properties.Resources.AboutSelected; Application.DoEvents();
        }

        private void pictureAbout_MouseLeave(object sender, EventArgs e)
        {
            buttonAbout.BackgroundImage = global::FileSplitter.Properties.Resources.AboutUnselected; Application.DoEvents();
        }

        private void pictureExit_MouseEnter(object sender, EventArgs e)
        {
           buttonExit.BackgroundImage = global::FileSplitter.Properties.Resources.ExitSelected; Application.DoEvents();
        }

        private void pictureExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = global::FileSplitter.Properties.Resources.ExitUnselected; Application.DoEvents();
        }

        private void pictureExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureJoinFiles_Click(object sender, EventArgs e)
        {
            this.Hide(); mainForm = null;
            mainForm = new fileSplitter(); mainForm.Height = 428; setCoordintes(ref mainForm);
            mainForm.FileWorkDone += new fileSplitter.FileWorkDoneHandler(mainForm_FileWorkDone);
            mainForm.ShowForm(2, settings.GetSettings());
        }

        private void pictureSplitFiles_Click(object sender, EventArgs e)
        {
            this.Hide(); mainForm = null;
            mainForm = new fileSplitter(); mainForm.Height = 428; setCoordintes(ref mainForm);
            mainForm.FileWorkDone += new fileSplitter.FileWorkDoneHandler(mainForm_FileWorkDone);
            mainForm.ShowForm(1, settings.GetSettings());
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            aboutApp.ShowDialog();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            settings = null;
            settings = new SettingsForm(); setCoordintes(ref settings);
            settings.ShowDialog(this);
        }

        private void buttonSettings_MouseEnter(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = global::FileSplitter.Properties.Resources.Settings2; Application.DoEvents();
        }

        private void buttonSettings_MouseLeave(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = global::FileSplitter.Properties.Resources.Settings; Application.DoEvents();
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderOpsForm form = new FolderOpsForm(); setCoordintes(ref form);
            form.Show();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            this.Hide(); folderForm = null;
            folderForm = new FolderOpsForm();
            folderForm.FolderFormClosed += folderForm_FolderFormClosed; setCoordintes(ref folderForm);
            folderForm.Show();
        }

        void folderForm_FolderFormClosed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
