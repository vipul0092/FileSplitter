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
using System.Runtime.Serialization.Formatters.Binary;
using FileSplitter.EventArgs_Classes;
using Microsoft.Win32;
using FileSplitter.Hashing;

namespace FileSplitter
{
    /// <summary>
    /// Class providing all the access and functionality to Windows Registry
    /// </summary>
    public class RegAccess
    {
        static RegistryKey sysreg;

        /// <summary>
        /// Saves Settings in Windows Registry corresponding to the data passed
        /// </summary>
        /// <param name="settings">AppSettings object containing all the settings data</param>
        public static void SaveSettingsinRegistry(AppSettings settings)
        {
            using (sysreg = Registry.CurrentUser.CreateSubKey("Software\\SplitterViP"))
            {
                sysreg.SetValue("Buffer Size", settings.Buffer.ToString(), RegistryValueKind.String);
                sysreg.SetValue("Checksum Method", ((int)settings.CheckSumType).ToString(), RegistryValueKind.String);
                sysreg.SetValue("Settings Save Method",((int) settings.SettingsSaveType).ToString(), RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Gets Settings from Windows Registry and returns the settings
        /// </summary>
        /// <returns>AppSettings object containing the settings data</returns>
        public static AppSettings GetSettingsFromRegistry()
        {
            AppSettings settings; int buffer; CheckSumMethod check; SettingsSaveMethod set;
            try
            {
                using (sysreg = Registry.CurrentUser.OpenSubKey("Software\\SplitterViP"))
                {
                    buffer = int.Parse((string)sysreg.GetValue("Buffer Size",8192));
                    check = (CheckSumMethod)int.Parse((string)sysreg.GetValue("Checksum Method", "CRC32"));
                    set = (SettingsSaveMethod)int.Parse((string)sysreg.GetValue("Settings Save Method", "Registry"));
                    settings = new AppSettings(buffer, check, set);
                }
            
            }
            catch (System.ArgumentNullException Exp)
            {
                MessageBox.Show(Exp.Message, "Registry Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings = null;
            }

            return settings;
        }

        public static bool CheckRegistry()
        {
            try { using (sysreg = Registry.CurrentUser.OpenSubKey("Software\\SplitterViP")) { if (sysreg != null) return true; else return false; } }
            catch (System.ArgumentNullException) { return false; }
        }

        public static string[] GetExtInfo(string extension)
        {
            string keyval=""; string[] retInfo = new string[2];
            using (sysreg = Registry.ClassesRoot.OpenSubKey(extension))
            {
                string[] keys = sysreg.GetValueNames(); 
                foreach (string key in keys)
                {
                    if (key == null || key == "") { keyval = (string)sysreg.GetValue(key, ""); break; }
                }
            }

            if (keyval == null || keyval == "") { retInfo[1] = (extension.Remove(0, 1)).ToUpper() + " File"; retInfo[0] = "Other"; }
            else if (keyval.Contains(',')) { retInfo[0] = keyval; retInfo[1] = (extension.Remove(0, 1)).ToUpper() + " File"; }
            else
            {
                using (sysreg = Registry.ClassesRoot.OpenSubKey(keyval))
                {
                    string[] keys = sysreg.GetValueNames();
                    foreach (string key in keys)
                    {
                        if (key == null || key == "") { retInfo[1] = (string)sysreg.GetValue(key); break; }
                    }
                }
                using(sysreg = Registry.ClassesRoot.OpenSubKey(keyval + "\\DefaultIcon"))
                {
                    string[] keys = sysreg.GetValueNames();
                    foreach (string key in keys)
                    {
                        if (key == null || key == "") { retInfo[0] = (string)sysreg.GetValue(key); break; }
                    }
                }
            }
            return retInfo;
        }

        public static void CleanRegistry() { Registry.CurrentUser.DeleteSubKey("Software\\SplitterViP"); }
    }
}
