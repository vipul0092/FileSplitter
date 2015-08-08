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
    public class FolderSplitWorker :  BackgroundWorker
    {
        string _folder;
        string stlocation;
        int bufsize;
        long splitsize;
        FileFolderInfoExtractor folder;

        public delegate void SplitProgressUpdateHandler(object sender, SplitProgressUpdateEventArgs e);
        public delegate void SplittingDoneHandler(object sender, EventArgs e);

        public event SplitProgressUpdateHandler ReportSplitProgress;
        public event SplittingDoneHandler SplittingDone;

        public long TotalSize { get { if (folder != null) return folder.TotalSize; else return 0; } }
        public int NoOfFiles { get { if (folder != null) return folder.NoOfFiles; else return 0; } }
        public string RootFolder { get { return _folder; } }
        public long SplitSize { get { return splitsize; } }
        public string StorageLocation { get { return stlocation; } }
        public string FileName { get { return folder.recInfo.Foldername; } }

        

        public FolderSplitWorker(string folderName, int buffersize, long splitsize=0)
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            _folder = folderName; folder = null;
            this.bufsize = buffersize; this.splitsize = splitsize;
            stlocation = "";
        }

        public void AccumulateFolderInfo()
        {
            folder = new FileFolderInfoExtractor(_folder);
            folder.AccumulateAllInfo();
        }

        public void setSaveLocation(string location)
        { stlocation = location; }

        public void setSplitSize(long size)
        { splitsize = size; }

        public void setNoOfFiles(int num) { folder.NoOfFiles = num; }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            byte[] buffer; int[] data = { 0, 0, 0 };
            FileInfo pfile; int pfnum = 0; long pfbytesread = 0; int psnum = 0; long psbyteswritten = 0;
            long rem = 0; FileStream fwrite, fread; long totalread = 0; fwrite = null; long totalwritten = 0;
            long nfiles = TotalSize / splitsize;
            if(folder != null && splitsize != 0)
            {
                for(int i=0; i<folder.filesInfo.Count; i++)
                {
                    if (this.CancellationPending == true) { break; }
                    pfile = folder.filesInfo.ElementAt<FileInfo>(pfnum); pfnum++; fread=null;
                    fread = File.OpenRead(pfile.FullPath); pfbytesread = 0;
                    pfile.SplitPieceStart = psnum==0?psnum:psnum-1; pfile.ByteStart = psbyteswritten;

                    while(pfbytesread != fread.Length)
                    {
                        if(this.CancellationPending == true) { break; }
                        buffer = null;
                        if (fread.Length - pfbytesread < bufsize) buffer = new byte[fread.Length - pfbytesread];
                        else buffer = new byte[bufsize];

                        pfbytesread += fread.Read(buffer, 0, buffer.Length); totalread += buffer.Length;

                        if(psbyteswritten + buffer.Length < splitsize)
                        {
                            if (fwrite == null)
                            { 
                                fwrite = File.Open(stlocation + folder.recInfo.Foldername + ".vipf" + psnum, FileMode.Create, FileAccess.ReadWrite); psnum++;
                                if (psnum-1== nfiles) splitsize = TotalSize - (nfiles * splitsize);
                            }
                            fwrite.Write(buffer, 0, buffer.Length);
                            psbyteswritten += buffer.Length; totalwritten += buffer.Length;
                            ReportProgress(psnum, nfiles, totalwritten, psbyteswritten, splitsize);
                        }
                        else
                        {
                            rem = splitsize - psbyteswritten;
                            if (fwrite == null)
                            { 
                                fwrite = File.Open(stlocation + folder.recInfo.Foldername + ".vipf" + psnum, FileMode.Create, FileAccess.ReadWrite); psnum++;
                                if (psnum-1 == nfiles) splitsize = TotalSize - (nfiles * splitsize);
                            }
                            fwrite.Write(buffer, 0, (int)rem); fwrite.Close(); psbyteswritten += rem;  totalwritten += rem;
                            ReportProgress(psnum, nfiles, totalwritten, psbyteswritten, splitsize);

                            while(buffer.Length-rem > splitsize)
                            {
                                fwrite = null; psbyteswritten = 0;
                                fwrite = File.Open(stlocation + folder.recInfo.Foldername + ".vipf" + psnum, FileMode.Create, FileAccess.ReadWrite); psnum++;
                                if (psnum-1 == nfiles) splitsize = TotalSize - (nfiles * splitsize);
                                fwrite.Write(buffer, (int)rem, (int)splitsize); fwrite.Close();
                                rem += splitsize; psbyteswritten += splitsize; totalwritten += splitsize;
                                ReportProgress(psnum, nfiles, totalwritten, psbyteswritten, splitsize);
                            }

                            if (buffer.Length != rem)
                            {
                                fwrite = null; psbyteswritten = 0;
                                fwrite = File.Open(stlocation + folder.recInfo.Foldername + ".vipf" + psnum, FileMode.Create, FileAccess.ReadWrite); psnum++;
                                if (psnum - 1 == nfiles) splitsize = TotalSize - (nfiles * splitsize);
                                fwrite.Write(buffer, (int)rem, (int)(buffer.Length - rem));
                                psbyteswritten += buffer.Length - rem; totalwritten += (buffer.Length-rem);
                                ReportProgress(psnum, nfiles, totalwritten, psbyteswritten, splitsize);
                            }
                        }
                    }
                    pfile.ByteEnd = psbyteswritten-1; pfile.SplitPieceEnd = psnum==0?psnum:psnum-1; fread.Close();
                    if(this.CancellationPending == true)
                    { if (fread != null) { fread.Close(); fread = null; } if (fwrite != null) { fwrite.Close(); fwrite = null; } break; }
                }
                if(this.CancellationPending != true)
                    FileUtilities.CreateFolderMetaFile(new FolderMetaData(folder.NoOfFiles, folder.TotalSize, folder.folderInfo, folder.folderHash, folder.filesInfo, folder.fileHash, folder.recInfo), stlocation, folder.recInfo.Foldername);
            }

            base.OnDoWork(e);
        }

        void ReportProgress(int psnum, long nfiles, long totalwritten, long psbyteswritten, long splitsize)
        {
            int[] data = { 0, 0, 0 };
            if (TotalSize % splitsize != 0) nfiles++;
            data[0] = psnum; data[1] = (int)nfiles; data[2] = (int)(((float)totalwritten / (float)folder.TotalSize) * 100);
            this.ReportProgress((int)(((float)psbyteswritten / (float)splitsize) * 100), data);
        }

        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            SplittingDone(this, null);
            base.OnRunWorkerCompleted(e);
        }

        protected override void OnProgressChanged(ProgressChangedEventArgs e)
        {
            int[] data = (int[])e.UserState;
            ReportSplitProgress(this, new SplitProgressUpdateEventArgs(data[0], data[1], e.ProgressPercentage, data[2]));
            base.OnProgressChanged(e);
        }

    }
}
