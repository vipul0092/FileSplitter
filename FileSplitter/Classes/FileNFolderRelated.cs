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
using System.Drawing.Text;


namespace FileSplitter
{
    /// <summary>
    /// Contains Information about an Extension
    /// </summary>
    public struct ExtensionInfo
    {
        string extension;
        public Icon ExtensionIcon;
        public string ExtensionInfoText;

        public ExtensionInfo(string extension, Icon icon, string info)
        { this.extension = extension; ExtensionIcon = icon; ExtensionInfoText = info; }
    }

    /// <summary>
    /// Class for miscellaneous File and Folder information extraction and other tasks
    /// </summary>
    public class FileFolderInfoExtractor
    {
        int id;
        int fid;
        string rootFolder;
        string _relPath;
        public FolderInfo recInfo;
        public Dictionary<string, int> folderHash;
        public Dictionary<string, int> fileHash;
        public List<FolderInfo> folderInfo;
        public List<FileInfo> filesInfo;
        static bool isUpdated;

        public long TotalSize { get; set; }
        public int NoOfFiles { get; set; }

       // public string RootFolder { get { return rootFolder; } }

        public FileFolderInfoExtractor(string folder)
        { rootFolder = folder; fid = 0; id = 0; TotalSize = 0; NoOfFiles = 0; _relPath = "\\"; folderHash = new Dictionary<string, int>(); folderInfo = new List<FolderInfo>(); fileHash = new Dictionary<string, int>(); filesInfo = new List<FileInfo>(); }

        FolderInfo GetFolderInfo(string folder, FolderInfo info, string relPath)
        {       
            relPath += ( folder.Substring(folder.LastIndexOf('\\') + 1, folder.Length - folder.LastIndexOf('\\') - 1) + "\\" ); 

            FolderInfo finfo = GetFilesAndFoldersinFolder(id, folder, relPath);

            foreach (string subfolder in finfo.FolderInside) 
            { 
                FolderInfo t = GetFolderInfo(subfolder, finfo, relPath);
            }
            folderInfo.Add(finfo); folderHash.Add(relPath, id); id++;
            if (info != null) info.FoldersInfo.Add(finfo);
            else info = finfo;

            return info;
        }
        FolderInfo GetFilesAndFoldersinFolder(int id, string folder, string relativePath)
        {
            List<string> folders = (List<string>)Directory.EnumerateDirectories(folder).ToList<string>();
            List<string> files = (List<string>)Directory.EnumerateFiles(folder).ToList<string>();
            List<FileInfo> fileInfo = new List<FileInfo>();

            foreach (string file in files)
            {
                FileInfo t = new FileInfo(fid, /*folder + "\\" +*/ file, folder.Substring(folder.LastIndexOf('\\') + 1, folder.Length - folder.LastIndexOf('\\') - 1), relativePath, (new System.IO.FileInfo(file)).Length);
                fileInfo.Add(t); TotalSize += t.Size;
                fileHash.Add(t.RelativePath + t.FileName, fid); filesInfo.Add(t);
                fid++; 
            }

            return new FolderInfo(id, folders, folder.Substring(folder.LastIndexOf('\\') + 1, folder.Length - folder.LastIndexOf('\\') - 1), fileInfo, relativePath);
        }

        public int AccumulateAllInfo()
        { 
            int success=0;
            recInfo = GetFolderInfo(rootFolder, null, ""); string foldername = rootFolder;//.Remove(rootFolder.Length - 1);
            NoOfFiles = fileHash.Count; recInfo.SetRootFolderName(rootFolder.Substring(foldername.LastIndexOf('\\') + 1, foldername.Length - foldername.LastIndexOf('\\') - 1));
            return success;
        }

        #region Public Static Methods
        public static ExtensionInfo GetInfoForExtension(string extension)
        {
            string[] extInfo= RegAccess.GetExtInfo(extension);
            Icon extIcon = NativeAPIHandler.GetIconForExtension(extInfo[0]);

            return new ExtensionInfo(extension, extIcon, extInfo[1]);
        }

        
        #endregion
    }

    [Serializable]
    /// <summary>
    /// Class to encapsulate the Information about a file
    /// </summary>
    public class FileInfo
    {
        string relPath;
        string fullPath;
        int splitPcStrt;
        int splitPcEnd;
        int fid;
        long byteStrt;
        long byteEnd;
        string fileName;
        string parentFolderName;

        public string RelativePath { get { return relPath; } }
        public string FullPath { get { return fullPath; } }
        public int SplitPieceStart { get { return splitPcStrt; } set { splitPcStrt = value; } }
        public int SplitPieceEnd { get { return splitPcEnd; } set { splitPcEnd = value; } }
        public long ByteStart { get { return byteStrt; } set { byteStrt = value; }  }
        public long ByteEnd { get { return byteEnd; } set { byteEnd = value; } }
        public string FileName { get { return fileName; } }
        public string ParentFolderName { get { return parentFolderName; } }
        public long Size { get; set; }
        public long FileID { get { return fid; } }

        /// <summary>
        /// Creates a new object of the FileInfo class for a specific file
        /// </summary>
        /// <param name="fullpath">Full system path to the file</param>
        /// <param name="parentFolder">The folder the file is in</param>
        /// <param name="relPath">Relative path of the file in the folders</param>
        public FileInfo(int fid, string fullpath, string parentFolder, string relPath, long size = 0)
        {
            fullPath = fullpath; parentFolderName = parentFolder; this.relPath = relPath; this.fid = fid;
            fileName = fullpath.Substring(fullpath.LastIndexOf('\\') + 1, fullpath.Length - fullpath.LastIndexOf('\\') - 1);
            Size = size;
        }
    }

    [Serializable]
    /// <summary>
    /// Class to encapsulate the Information about a folder
    /// </summary>
    public class FolderInfo
    {
        int id;
        string relpath;
        List<string> folders;
        string folderName;
        List<FileInfo> files;
        List<FolderInfo> folderinfo;

        public string RelativePath { get { return relpath;  } }
        public int ID { get { return id; } }
        public List<string> FolderInside { get { return folders; } }
        public string Foldername { get { return folderName; } }
        public List<FileInfo> FilesInside { get { return files; }}
        public List<FolderInfo> FoldersInfo { get { return folderinfo; } }

        public FolderInfo(int id, List<string> fldrinside, string fname, List<FileInfo> filinside, string relpath)
        {
            this.id = id; folders = fldrinside; folderName = fname; this.relpath = relpath; files = filinside; folderinfo = new List<FolderInfo>();
        }

        public void SetRootFolderName(string folder) { this.folderName = folder; }
    }
}
