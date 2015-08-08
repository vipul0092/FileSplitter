using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSplitter
{
    /// <summary>
    /// Class used for storing the Application settings in a file
    /// </summary>
    [Serializable]
    public partial class AppSettings
    {

        #region Private members
        int buffer;
        CheckSumMethod checkType;
        SettingsSaveMethod settingType;
        #endregion

        #region Public Members
        public int Buffer
        { get { return buffer; } }

        public CheckSumMethod CheckSumType
        { get { return checkType; } }

        public SettingsSaveMethod SettingsSaveType
        { get { return settingType; } }

        #endregion

        public AppSettings(int buffer, CheckSumMethod check, SettingsSaveMethod set)
        { this.buffer = buffer; this.checkType = check; this.settingType = set; }

    }
}
