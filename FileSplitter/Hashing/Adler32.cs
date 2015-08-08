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

namespace FileSplitter.Hashing
{
    public class Adler32
    {
        #region Constants
        /// <summary>
        /// AdlerBase is Adler-32 checksum algorithm parameter.
        /// </summary>
        public const uint AdlerBase = 0xFFF1;
        /// <summary>
        /// AdlerStart is Adler-32 checksum algorithm parameter.
        /// </summary>
        public const uint AdlerStart = 0x0001;
        /// <summary>
        /// AdlerBuff is Adler-32 checksum algorithm parameter.
        /// </summary>
        public const uint AdlerBuff = 0x0400;
        /// Adler-32 checksum value
        public uint m_unChecksumValue = 0;
        #endregion

        /// <value>
        /// ChecksumValue is property which enables the user
        /// to get Adler-32 checksum value for the last calculation 
        /// </value>
        public uint ChecksumValue
        {
            get
            {
                return m_unChecksumValue;
            }
        }

        /// <summary>
        /// Calculate Adler-32 checksum for buffer
        /// </summary>
        /// <param name="bytesBuff">Bites array for checksum calculation</param>
        /// <param name="unAdlerCheckSum">Checksum start value (default=1)</param>
        /// <returns>Returns true if the checksum values is successflly calculated</returns>
        public bool MakeForBuff(byte[] bytesBuff, uint unAdlerCheckSum)
        {
            if (Object.Equals(bytesBuff, null))
            {
                m_unChecksumValue = 0;
                return false;
            }
            int nSize = bytesBuff.GetLength(0);
            if (nSize == 0)
            {
                m_unChecksumValue = 0;
                return false;
            }
            uint unSum1 = unAdlerCheckSum & 0xFFFF;
            uint unSum2 = (unAdlerCheckSum >> 16) & 0xFFFF;
            for (int i = 0; i < nSize; i++)
            {
                unSum1 = (unSum1 + bytesBuff[i]) % AdlerBase;
                unSum2 = (unSum1 + unSum2) % AdlerBase;
            }
            m_unChecksumValue = (unSum2 << 16) + unSum1;
            return true;
        }
        /// <summary>
        /// Calculate Adler-32 checksum for buffer
        /// </summary>
        /// <param name="bytesBuff">Bites array for checksum calculation</param>
        /// <returns>Returns true if the checksum values is successflly calculated</returns>
        public bool MakeForBuff(byte[] bytesBuff)
        {
            return MakeForBuff(bytesBuff, AdlerStart);
        }
        /// <summary>
        /// Calculate Adler-32 checksum for file
        /// </summary>
        /// <param name="sPath">Path to file for checksum calculation</param>
        /// <returns>Returns true if the checksum values is successflly calculated</returns>
        public bool MakeForFile(string sPath)
        {
            try
            {
                if (!File.Exists(sPath))
                {
                    m_unChecksumValue = 0;
                    return false;
                }
                using (FileStream fs = new FileStream(sPath, FileMode.Open, FileAccess.Read))
                {
                    m_unChecksumValue = AdlerStart;
                    byte[] bytesBuff = new byte[AdlerBuff];
                    for (uint i = 0; i < fs.Length; i++)
                    {
                        uint index = i % AdlerBuff;
                        bytesBuff[index] = (byte)fs.ReadByte();
                        if ((index == AdlerBuff - 1) || (i == fs.Length - 1))
                        {
                            if (!MakeForBuff(bytesBuff, m_unChecksumValue))
                            {
                                m_unChecksumValue = 0;
                                return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                m_unChecksumValue = 0;
                return false;
            }
        
            return true;
        }
        /// <summary>
        /// Equals determines whether two files (buffers) 
        /// have the same checksum value (identical).
        /// </summary>
        /// <param name="obj">A Adler32 object for comparison</param>
        /// <returns>Returns true if the value of checksum is the same
        /// as this instance; otherwise, false
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Adler32 other = (Adler32)obj;
            return (this.ChecksumValue == other.ChecksumValue);
        }
        /// <summary>
        /// operator== determines whether Adler32 objects are equal.
        /// </summary>
        /// <param name="objA">A Adler32 object for comparison</param>
        /// <param name="objB">A Adler32 object for comparison</param>
        /// <returns>Returns true if the values of its operands are equal</returns>
        public static bool operator ==(Adler32 objA, Adler32 objB)
        {
            if (Object.Equals(objA, null) && Object.Equals(objB, null)) return true;
            if (Object.Equals(objA, null) || Object.Equals(objB, null)) return false;
            return objA.Equals(objB);
        }
        /// <summary>
        /// operator!= determines whether Adler32 objects are not equal.
        /// </summary>
        /// <param name="objA">A Adler32 object for comparison</param>
        /// <param name="objB">A Adler32 object for comparison</param>
        /// <returns>Returns true if the values of its operands are not equal</returns>
        public static bool operator !=(Adler32 objA, Adler32 objB)
        {
            return !(objA == objB);
        }
        /// <summary>
        /// GetHashCode returns hash code for this instance.
        /// </summary>
        /// <returns>hash code of Adler32</returns>
        public override int GetHashCode()
        {
            return ChecksumValue.GetHashCode();
        }
        /// <summary>
        /// ToString is a method for current Adler32 object
        /// representation in textual form.
        /// </summary>
        /// <returns>Returns current checksum or
        /// or "Unknown" if checksum value is unavailable 
        /// </returns>
        public override string ToString()
        {
            if (ChecksumValue != 0)
                return ChecksumValue.ToString();
            return "Unknown";
        }
    }
}
