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

namespace FileSplitter
{
    /// <summary>
    /// Contains all the logic to represent a file and its information
    /// </summary>
    public class FileUtilities
    {
        #region Private Members
        bool isFinished;
        int checksumtype;
        string filePath;
        string fileDirectory;
        string fileSize;
        int nFiles;
        int currentFile;
        float currentHashProg;
        int currentFilePerc;
        string maxSize;
        string MD5sumfile;
        float actualFileSize;
        float splitsize;
        string fileSavePath;
        long totalDataSplit;
        FileMetaData fileMetaInfo;

        #endregion

        #region Public Members

        public string OrigFileFullSavePath;

        /// <summary>
        /// Gets the Current File Hash Calculation Progress
        /// </summary>
        public float CurrentHashProg { get { return currentHashProg; } }

        public CheckSumMethod CheckSumType { get { return ((CheckSumMethod)checksumtype); } set { checksumtype = (int)value; } }

        /// <summary>
        /// Gets Whether the Splitting process has been finished or not
        /// </summary>
        public bool IsFinished { get { return isFinished; } set { isFinished = value; } }

        /// <summary>
        /// Gets The Current File Number that is being split
        /// </summary>
        public int CurrentFileNumber { get { return currentFile; } set { currentFile = value; } }

        /// <summary>
        /// Gets the percentage of Current File to be split that has been already split
        /// </summary>
        public int CurrentSplitFilePercentage { get { return currentFilePerc; } set { currentFilePerc = value; } }

        /// <summary>
        /// Gets the Total Amount of Data Split Till Now
        /// </summary>
        public long TotalDataSplit { get { return totalDataSplit; } set { totalDataSplit = value; } }

        /// <summary>
        /// Gets or Sets the no. of files the original file was split to
        /// </summary>
        public int NoOfSplitFiles
        { get { return nFiles; }
          set { nFiles = value; }
        }

        /// <summary>
        /// Gets the Original File Name of the file that was split
        /// </summary>
        public string OrigFileName
        { get { return filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.Length - filePath.LastIndexOf('\\') - 1); }  }

        /// <summary>
        /// Gets the Path of the File To Split
        /// </summary>
        public string FilePath {

            get { return filePath; }
            set { filePath = value; }
        }

        /// <summary>
        /// Gets The Size of The File in String format
        /// </summary>
        public string FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        /// <summary>
        /// Gets the corresponding MD5 Hash String for the file
        /// </summary>
        public string MD5Sum
        {
            get { return MD5sumfile; }
            set { MD5sumfile = value; }
        }

        /// <summary>
        /// Gets or Sets the actual file split size
        /// </summary>
        public float FileSplitSize
        {
            get { return splitsize; }
            set { splitsize = value; }
        }

        /// <summary>
        /// Gets or Sets the Save Path for the Split files
        /// </summary>
        public string FileSavePath
        {
            get { return fileSavePath; }
            set { fileSavePath = value; }
        }

        /// <summary>
        /// Gets the Whole File Size of the concerned file in string format
        /// </summary>
        public string MaxFileSize {
            get { return maxSize; }
            set { maxSize = value; }
        }

        /// <summary>
        /// Gets the actual file size for the concerned file
        /// </summary>
        public float ActualFileSize
        { get { return actualFileSize; } set { actualFileSize = value; } }

        /// <summary>
        /// Gets the Default File Directory for the split files
        /// </summary>
        public string FileDefDirectory
        { get { return fileDirectory; } set { fileDirectory = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of a File to be operated upon
        /// </summary>
        /// <param name="filePath">The Path of the file to be operated upon</param>
        public FileUtilities(string filePath, string initialDirectory)
        {
            if (filePath != "1")
            {
                this.filePath = filePath;
                this.fileDirectory = filePath.Substring(0, filePath.LastIndexOf('\\'));
                CalculateFileSize();
            }
        }

        #endregion

        #region Private Methods

        void CalculateFileSize()
        {
            float size = 0;
            if (File.Exists(filePath))
            {
                FileStream fOpen = File.Open(filePath, FileMode.Open, FileAccess.Read);
                size = fOpen.Length;
                fOpen.Close();
            }
            else size = this.ActualFileSize;

            if (size < 1024) { fileSize = size.ToString() + " B"; maxSize = "B"; }
            else if (size < 1048576) { fileSize = ((float)(size / 1024)).ToString("0.00") + " KB"; maxSize = "KB"; }
            else if (size < 1073741824) { fileSize = ((float)(size / 1048576)).ToString("0.00") + " MB"; maxSize = "MB"; }
            else if (size < 1099511627776) { fileSize = ((float)(size / 1073741824)).ToString("0.00") + " GB"; maxSize = "GB"; }
            actualFileSize = size;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Generates Metafile for the corresponding file that has been split
        /// </summary>
        public void GenerateMetaFile()
        {
            if(this.MD5Sum != "" && this.MD5Sum != null)
                fileMetaInfo = new FileMetaData(this.OrigFileName, this.NoOfSplitFiles, (long)this.ActualFileSize, this.MD5Sum, (int)this.CheckSumType);
            else
                fileMetaInfo = new FileMetaData(this.OrigFileName, this.NoOfSplitFiles, (long)this.ActualFileSize);
            
            using (Stream output = File.Create(fileSavePath + ".vipmeta"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, fileMetaInfo);
            }
        }

        /// <summary>
        /// [Deprecated] Do Not Use! ( CheckSum calculated in Background Worker Object in fileSplitter Form )
        /// </summary>
        public void CalculateMD5ofFile()
        {
            CRC32 crchash = new CRC32(); FileStream fOpen; byte[] buffer = new byte[8192];
            HashAlgorithm crc32 = (HashAlgorithm)(crchash); long bytesHashed=0;

            //Start Hashing
            crc32.Initialize();
            using (fOpen = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                while (bytesHashed != fOpen.Length)
                {
                    bytesHashed += fOpen.Read(buffer, 0, buffer.Length);
                    ((CRC32)crc32).CalcHashBuffer(buffer, 0, buffer.Length);

                    currentHashProg = ((float)bytesHashed / (float)fOpen.Length) * 100;
                }
            }

            this.MD5Sum=((CRC32)crc32).CalcHashFinal();

        }

        /// <summary>
        /// [Deprecated] Do Not Use! ( Splits the concerned file according to the set criteria )
        /// </summary>
        public void SplitFile()
        {
            byte[] tmpStorage; int splitFiles = this.NoOfSplitFiles; 
            int i = 0;long timesToRun = 0, bytesRead = 0;
            if (splitsize != 0)
            {

                FileStream fOpenOrig = File.OpenRead(filePath); FileStream fOpenNew;
                for (i = 0; i < splitFiles - 1; i++)
                {
                    fOpenNew = File.Open(fileSavePath + ".vip" + i.ToString(), FileMode.Create, FileAccess.ReadWrite);
                    bytesRead = 0; this.currentFile = i + 1;
                    if ((Int64)splitsize > 104857600)
                    {
                        timesToRun = ((Int64)splitsize / 104857600) + 1;
                        while(timesToRun > 1)
                        {
                            tmpStorage = new byte[(Int64)104857600];
                            bytesRead += fOpenOrig.Read(tmpStorage, 0, 104857600);
                            fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                            currentFilePerc = (int)((long)splitsize / (long)bytesRead) * 100;
                            totalDataSplit += bytesRead;
                            timesToRun--;

                        }
                        tmpStorage = new byte[(Int64)splitsize - bytesRead];
                        bytesRead += fOpenOrig.Read(tmpStorage, 0, tmpStorage.Length);
                        fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                        currentFilePerc = (int)((long)splitsize / (long)bytesRead) * 100;
                        totalDataSplit += bytesRead;
                        fOpenNew.Close();
                        
                    }
                    else
                    {
                        tmpStorage = new byte[(Int64)splitsize];
                        bytesRead += fOpenOrig.Read(tmpStorage, 0, (int)splitsize);
                        fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                        currentFilePerc = (int)((long)splitsize / (long)bytesRead) * 100;
                        totalDataSplit += bytesRead;
                        fOpenNew.Close();
                    }
                }

                fOpenNew = File.Open(fileSavePath + ".vip" + i.ToString(), FileMode.Create, FileAccess.ReadWrite);
                bytesRead = i * (Int64)splitsize; this.currentFile = i + 1; totalDataSplit = bytesRead;
                if (((Int64)fOpenOrig.Length - bytesRead) > 104857600)
                {
                    timesToRun = (((Int64)fOpenOrig.Length - bytesRead) / 104857600) + 1;
                    while (timesToRun > 1)
                    {
                        tmpStorage = new byte[(Int64)104857600];
                        bytesRead += fOpenOrig.Read(tmpStorage, 0, 104857600);
                        fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                        currentFilePerc = (int)((long)(fOpenOrig.Length) / (long)bytesRead) * 100;
                        totalDataSplit += bytesRead;

                        timesToRun--;
                    }
                    tmpStorage = new byte[(Int64)fOpenOrig.Length - bytesRead];
                    bytesRead += fOpenOrig.Read(tmpStorage, 0, tmpStorage.Length);
                    fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                    currentFilePerc = (int)((long)(fOpenOrig.Length) / (long)bytesRead) * 100;
                    totalDataSplit += bytesRead;
                    fOpenNew.Close();
                }
                else
                {
                    tmpStorage = new byte[(Int64)fOpenOrig.Length - bytesRead];
                    bytesRead += fOpenOrig.Read(tmpStorage, 0, tmpStorage.Length);
                    fOpenNew.Write(tmpStorage, 0, tmpStorage.Length);
                    currentFilePerc = (int)((long)(fOpenOrig.Length) / (long)bytesRead) * 100;
                    totalDataSplit += bytesRead;
                    fOpenNew.Close();
                }

                fOpenOrig.Close(); this.isFinished = true; GenerateMetaFile(); 
           }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Reads Back Metafile for Joining of Split Files
        /// </summary>
        /// <param name="saveDirectory">Folder name where the Metafile is saved</param>
        /// <param name="fileName">Filename of each of the split files with which they were saved</param>
        /// <returns></returns>
        public static FileMetaData ReadBackMetaFile(string saveDirectory, string fileName)
        {
            FileMetaData fileMetaInfo;
            using (Stream input = File.OpenRead(saveDirectory + fileName + ".vipmeta"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fileMetaInfo = (FileMetaData)formatter.Deserialize(input);
            }

            return fileMetaInfo;
        }

        public static bool CreateFolderMetaFile(FolderMetaData metadata, string fileSavePath, string name)
        {
            bool success = true;
            if (metadata == null) return false;
            try
            {
                using (Stream output = File.Create(fileSavePath + name + ".vipfmeta"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(output, metadata);
                }
            }
            catch (Exception e) { success = false; }

            return success;
        }

        public static FolderMetaData ReadFolderMetaFile(string saveDirectory, string fileName)
        {
            FolderMetaData MetaInfo;
            using (Stream input = File.OpenRead(saveDirectory + fileName + ".vipfmeta"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MetaInfo = (FolderMetaData)formatter.Deserialize(input);
            }

            return MetaInfo;
        }

        /// <summary>
        /// Returns the Proper String Equivalent of the Actual Size of a File
        /// </summary>
        /// <param name="size">The Actual Size of the file in Bytes</param>
        /// <returns>String Equivalent Of the file size</returns>
        public static string GetStringFromActualSize(float size)
        {
            string filesize = "";
            if (size < 1024) { filesize = size.ToString() + " B"; }
            else if (size < 1048576) { filesize = ((float)(size / 1024)).ToString("0.00") + " KB"; }
            else if (size < 1073741824) { filesize = ((float)(size / 1048576)).ToString("0.00") + " MB"; }
            else if (size < 1099511627776) { filesize = ((float)(size / 1073741824)).ToString("0.00") + " GB"; }

            return filesize;

        }

        public static string GetFolderNameFromFilepath(string filePath)
        { return filePath.Substring(0, filePath.LastIndexOf('\\') + 1); }

        public static string GetFileNameOnlyFromFilepath(string filePath)
        { return filePath.Substring(filePath.LastIndexOf('\\')+1, filePath.LastIndexOf('.') - filePath.LastIndexOf('\\')-1);  }

        /// <summary>
        /// [Deprecated] Do Not Use! ( Joins Files that have been split )
        /// </summary>
        /// <param name="startingFile"></param>
        /// <param name="saveDirectory"></param>
        public static void JoinFile(string startingFile, string saveDirectory)
        {
            string fileName = startingFile.Substring(startingFile.LastIndexOf('\\') + 1, startingFile.LastIndexOf('.') - startingFile.LastIndexOf('\\') - 1);
            FileMetaData fileData = ReadBackMetaFile(saveDirectory, fileName);
            FileStream fOpenOrig = File.Create(saveDirectory + fileData.OriginalFileName);

            int i = 0;
            for (i = 0; i < fileData.NoOfSplitFiles; i++)
            {
                FileStream fOpenSplit = File.Open(saveDirectory + fileName + ".vip" + i.ToString(), FileMode.Open, FileAccess.Read);
                fOpenSplit.CopyTo(fOpenOrig, 10485760);
                fOpenSplit.Close();
            }

            fOpenOrig.Close();
        }

        #endregion
    }
}
