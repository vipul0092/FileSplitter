using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileSplitter
{
    /// <summary>
    /// Class storing information for the MetaFile to be created for the Splitting and Joining Process for files
    /// </summary>
    [Serializable]
    public class FileMetaData
    {
        #region Private Data Members
        string origFileName;
        int noOfSplitFiles;
        long origFileSize;
        string checksum;
        int checksumtype;
        #endregion

        #region Public Data Members

        /// <summary>
        /// Gets The Original FileName Of the File Split
        /// </summary>
        public string OriginalFileName { get { return origFileName; } }

        public CheckSumMethod CheckSumType { get { return ((CheckSumMethod)checksumtype); } }

        /// <summary>
        /// Gets the no. of Files segments that were made
        /// </summary>
        public int NoOfSplitFiles { get { return noOfSplitFiles; } }

        /// <summary>
        /// Gets the size of the Original File
        /// </summary>
        public long OrigFileSize { get { return origFileSize; } }

        /// <summary>
        /// Gets the checksum of the Original File
        /// </summary>
        public string FileCheckSum { get { return checksum; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a File Info Object correspoding to the Original File
        /// </summary>
        /// <param name="origName">Name of the original file</param>
        /// <param name="nFiles">No. of segments the file was split to</param>
        /// <param name="origFilesize">Size of the original file</param>
        /// <param name="checksum">Checksum of the original file</param>
        public FileMetaData(string origName, int nFiles, long origFilesize, string checksum="NC", int checksumtype=-1)
        { this.origFileName = origName; this.noOfSplitFiles = nFiles; this.origFileSize = origFilesize; this.checksum = checksum; this.checksumtype = checksumtype; }

        #endregion

    }

    /// <summary>
    /// Class storing information for the MetaFile to be created for the Splitting and Joining of Folders
    /// </summary>
    [Serializable]
    public class FolderMetaData
    {
        List<FolderInfo> foldersInfo;
        Dictionary<string, int> folderToId;
        List<FileInfo> filesInfo;
        Dictionary<string, int> fileToId;
        FolderInfo recFolderInfo;
        int nSplitFiles;
        long tSize;

        public List<FolderInfo> FolderList { get { return foldersInfo; } }
        public Dictionary<string, int> FolderHash { get { return folderToId; } }
        public List<FileInfo> FileList { get { return filesInfo; } }
        public Dictionary<string, int> FileHash { get { return fileToId; } }
        public FolderInfo RecFolderInfo { get { return recFolderInfo; } }
        public int NumSplitFiles { get { return nSplitFiles; } }
        public long TotalSize { get { return tSize; } }

        public FolderMetaData(int nfiles, long totalsize, List<FolderInfo> folders, Dictionary<string, int> ftoId, List<FileInfo> files, Dictionary<string, int> filetoid, FolderInfo recinfo)
        {
            nSplitFiles = nfiles; tSize = totalsize; foldersInfo = folders; folderToId = ftoId; filesInfo = files; fileToId = filetoid; recFolderInfo = recinfo;
        }
    }
}
