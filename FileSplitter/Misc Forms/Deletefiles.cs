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
using FileSplitter.Hashing;
using FileSplitter.Misc_Forms;
using System.Diagnostics;


namespace FileSplitter
{
    public partial class Deletefiles : Form
    {
        public Deletefiles()
        {
            InitializeComponent();
        }

        public void ShowAndDelFiles(FileUtilities fileToSplit)
        {
            this.Show(); 
            int i = 0;
            while (File.Exists(fileToSplit.FileSavePath + ".vip" + i.ToString())) { File.Delete(fileToSplit.FileSavePath + ".vip" + i.ToString()); i++; }
            if (File.Exists(fileToSplit.FileSavePath + ".vipmeta")) { File.Delete(fileToSplit.FileSavePath + ".vipmeta"); }
                    
        }

    }
}
