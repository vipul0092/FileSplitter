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
    public class FolderJoinWorker : BackgroundWorker
    {
        FolderMetaData mdata;
        string foldername;
        string fname;
        int bufferSize;

        public long TotalSize { get { return mdata.TotalSize; } }
        public int NoOfFiles { get { return mdata.FileList.Count; } }
        public FolderJoinWorker(string filename, int bufsize)
        {
            foldername = FileUtilities.GetFolderNameFromFilepath(filename);
            fname = FileUtilities.GetFileNameOnlyFromFilepath(filename);
            mdata = FileUtilities.ReadFolderMetaFile(foldername, fname);
            this.bufferSize = bufsize;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            if (mdata != null)
            {
                Queue<FolderInfo> queue = new Queue<FolderInfo>(); FolderInfo pfolder; string wfolder = foldername + fname;
                queue.Enqueue(mdata.RecFolderInfo); string ppath = "";
                Directory.SetCurrentDirectory(foldername);
                Directory.CreateDirectory(fname);
                while (queue.Count != 0)
                {
                    pfolder = queue.Dequeue(); ppath = wfolder + pfolder.RelativePath; ppath.TrimEnd('\\');
                    Directory.SetCurrentDirectory(ppath);
                    foreach (FolderInfo folder in pfolder.FoldersInfo)
                    {   Directory.CreateDirectory(folder.Foldername); queue.Enqueue(folder); }

                    foreach(FileInfo file in pfolder.FilesInside)
                    { ExtractFileFromSplitfile(file, ppath, this.foldername, this.fname, this.bufferSize); }

                }
            }

            base.OnDoWork(e);
        }

        public int ExtractFileFromSplitfile(FileInfo file, string saveFolder, string splitFilesLocation, string fname, int bufsize)
        {
            int retcode = 0; FileStream fread, fwrite; byte[] buffer; long psnum, psbytesread, pfbyteswritten;
            long rem;
            try { fwrite = File.Open(saveFolder + file.FileName, FileMode.Create, FileAccess.ReadWrite); }
            catch { retcode = 1; return retcode; } //retcode=1 means File cant be written

            try { fread = File.Open(splitFilesLocation + fname + ".vipf" + file.SplitPieceStart, FileMode.Open, FileAccess.Read); }
            catch { retcode = 2; fwrite.Close();  return retcode; } //retcode=2 means files cant be read

            fread.Seek(file.ByteStart, SeekOrigin.Begin); psnum = file.SplitPieceStart; psbytesread = file.ByteStart; pfbyteswritten = 0;

            while(pfbyteswritten != file.Size)
            {
                if(psnum == file.SplitPieceEnd)
                {
                    if(file.Size-pfbyteswritten < bufsize)
                    {   buffer = null; buffer = new byte[file.Size - pfbyteswritten];   }
                    else
                    {   buffer = null; buffer = new byte[bufsize];  }

                    psbytesread += fread.Read(buffer, 0, buffer.Length);
                    fwrite.Write(buffer, 0, buffer.Length); pfbyteswritten += buffer.Length;
                }
                else
                {
                    rem = fread.Length - psbytesread;
                    if(rem == 0)
                    {
                        fread.Close(); fread = null; psnum++;
                        fread = File.Open(splitFilesLocation + fname + ".vipf" + psnum, FileMode.Open, FileAccess.Read);
                        psbytesread = 0; rem = fread.Length; continue;
                    }
                    
                    if(rem < bufsize)
                    { buffer = null; buffer = new byte[rem];  }
                    else
                    { buffer = null; buffer = new byte[bufsize]; }

                    psbytesread += fread.Read(buffer, 0, buffer.Length);
                    fwrite.Write(buffer, 0, buffer.Length); pfbyteswritten += buffer.Length;
                }
            }
            if (fread != null) { fread.Close(); fread = null; }
            fwrite.Close(); fwrite = null;
           
            return retcode;
        }



    }
}
