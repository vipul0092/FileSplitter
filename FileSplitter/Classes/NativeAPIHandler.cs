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
using System.Runtime.InteropServices;
using FileSplitter.Misc_Forms;
using System.Diagnostics;
namespace FileSplitter
{
    /// <summary>
    /// Class importing all the required Win32 methods and using them in methods
    /// </summary>
    public class NativeAPIHandler
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern uint ExtractIconEx(string fileName, int iconIndex, IntPtr[] iconLarge, IntPtr[] iconSmall, uint nIcons);

        [DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr Icon);

        public static Icon GetIconForExtension(string fileParams)
        {
            string fileName = fileParams.Split(',')[0]; string index = fileParams.Split(',')[1]; int iconIndex = 0;
            int.TryParse(index, out iconIndex);
            IntPtr[] iLarge = new IntPtr[1] { IntPtr.Zero }; IntPtr[] iSmall = new IntPtr[1] { IntPtr.Zero };

            try { ExtractIconEx(fileName, iconIndex, iLarge, iSmall, 1); }
            catch { iLarge[0] = iSmall[0] = IntPtr.Zero; }

            if (iSmall[0] != IntPtr.Zero) return (Icon)Icon.FromHandle(iSmall[0]).Clone();
            else return null;
        }

    }
}
