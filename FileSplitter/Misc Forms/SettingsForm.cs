using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSplitter;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FileSplitter.EventArgs_Classes;

namespace FileSplitter.Misc_Forms
{
    
    public partial class SettingsForm : Form
    {
        
        public SettingsForm()
        {
            InitializeComponent();
            checkedListBoxBuffer.SetItemChecked(0, true);
            checkedListBoxFilecheck.SetItemChecked(0, true);
            checkedListBoxSettingsave.SetItemChecked(0, true);
        }

        AppSettings settings;

        #region Public Methods

        public void SaveSettings()
        {
            settings = new AppSettings(GetBufferSize(), GetCheck(), GetSet());
            if (GetSet() == SettingsSaveMethod.Registry) { SaveSettingsInRegistry(settings); if (CheckINI()) File.Delete(Environment.CurrentDirectory + "\\Settings.ini"); }
            else if (GetSet() == SettingsSaveMethod.INI) { SaveSettingsInFile(settings); if (RegAccess.CheckRegistry()) RegAccess.CleanRegistry(); }
            else { SaveSettingsInRegistry(settings); if (CheckINI()) File.Delete(Environment.CurrentDirectory + "\\Settings.ini"); }
        }

        public AppSettings GetSettings()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\Settings.ini")){ GetSettingsFromFile(); }
            else if (RegAccess.CheckRegistry()) { settings = RegAccess.GetSettingsFromRegistry(); }
            else { settings = new AppSettings(8192, CheckSumMethod.CRC32, SettingsSaveMethod.Registry); }

            return settings;
        }

       
        #endregion

        #region Private Methods

        private int GetBufferSize()
        { 
            int buffer = 0,i;

            for(i=0; i<9;i++){ if (checkedListBoxBuffer.GetItemChecked(i)) { break; } }
            if (i != 8) buffer = 8192 * (int)Math.Pow(2, i); else buffer = 8192;

            return buffer;
        }

        private bool CheckINI()
        { return File.Exists(Environment.CurrentDirectory + "\\Settings.ini"); }

        private CheckSumMethod GetCheck()
        {
            CheckSumMethod check = 0; int i;

            for (i = 0; i < 4; i++)
            {
                if (checkedListBoxFilecheck.GetItemChecked(i)) { break; }
            }

            switch (i)
            {
                case 0:
                    {
                        check = CheckSumMethod.Adler32;
                        break;
                    }
                case 1:
                    {
                        check = CheckSumMethod.CRC32;
                        break;
                    }
                case 2:
                    {
                        check = CheckSumMethod.MurMurHash3;
                        break;
                    }
                case 3:
                    {
                        check = CheckSumMethod.Adler32;
                        break;
                    }
                
                default:
                    {
                        check = CheckSumMethod.CRC32;
                        break;
                    }
            }

            return check;
        }

        private SettingsSaveMethod GetSet()
        {
            SettingsSaveMethod file = 0; int i;

            for (i = 0; i < 3; i++)
            {
                if (checkedListBoxSettingsave.GetItemChecked(i)) { break; }
            }

            switch (i)
            {
                case 0:
                    {
                        file = SettingsSaveMethod.Registry;
                        break;
                    }
                case 1:
                    {
                        file = SettingsSaveMethod.INI;
                        break;
                    }
                case 2:
                    {
                        file = SettingsSaveMethod.Registry;
                        break;
                    }

                default:
                    {
                        file = SettingsSaveMethod.Registry;
                        break;
                    }
            }

            return file;
        }

        private void SaveSettingsInRegistry(AppSettings settings)
        {           
            RegAccess.SaveSettingsinRegistry(settings);
        }

        private void SaveSettingsInFile(AppSettings settings)
        {
            using (Stream output = File.Create(Environment.CurrentDirectory + "\\Settings.ini"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, settings);
            }
        }

        private void GetSettingsFromFile()
        {
            using (Stream input = File.Open(Environment.CurrentDirectory + "\\Settings.ini", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                settings = (AppSettings)formatter.Deserialize(input);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBoxBuffer_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index, i;
            if (e.NewValue == CheckState.Checked)
            {
                for (i = 0; i < 9; i++) { if(i != index) checkedListBoxBuffer.SetItemChecked(i, false); }
            }
            
        }

        private void checkedListBoxFilecheck_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index, i;
            if (e.NewValue == CheckState.Checked)
            {
                for (i = 0; i < 4; i++) { if (i != index) checkedListBoxFilecheck.SetItemChecked(i, false); }
            }
            
        }

        private void checkedListBoxSettingsave_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index, i;
            if (e.NewValue == CheckState.Checked)
            {
                for (i = 0; i < 3; i++) { if (i != index) checkedListBoxSettingsave.SetItemChecked(i, false); }
            }
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            if (checkedListBoxBuffer.CheckedIndices.Count == 0) checkedListBoxBuffer.SetItemChecked(0, true);
            if (checkedListBoxFilecheck.CheckedIndices.Count == 0) checkedListBoxFilecheck.SetItemChecked(1, true);
            if (checkedListBoxSettingsave.CheckedIndices.Count == 0) checkedListBoxSettingsave.SetItemChecked(0, true);

            SaveSettings();
            this.Close();
        }

        #endregion

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            settings = GetSettings();
            checkedListBoxBuffer.SetItemChecked((int)(Math.Log((settings.Buffer / 8192),2)), true);
            checkedListBoxFilecheck.SetItemChecked((int)settings.CheckSumType - 1, true);
            checkedListBoxSettingsave.SetItemChecked((int)settings.SettingsSaveType - 1, true);
            
        }
    }
}
