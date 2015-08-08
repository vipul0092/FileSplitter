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
    public class MurmurHash3
    {
        #region Public Constants

        public const uint seed = 144;
        public const uint c1 = 0xcc9e2d51;
        public const uint c2 = 0x1b873593;

        #endregion

        public uint Hash = seed;
        public uint K1 = 0;
        public uint StreamLength = 0;

        public void CalcHashBuffer(byte[] chunk)
        {
            StreamLength += (uint)chunk.Length;
            switch (chunk.Length)
            {
                case 4:
                    /* Get four bytes from the input into an uint */
                    K1 = (uint)
                       (chunk[0]
                      | chunk[1] << 8
                      | chunk[2] << 16
                      | chunk[3] << 24);

                    /* bitmagic hash */
                    K1 *= c1;
                    K1 = rotl32(K1, 15);
                    K1 *= c2;

                    Hash ^= K1;
                    Hash = rotl32(Hash, 13);
                    Hash = Hash * 5 + 0xe6546b64;
                    break;
                case 3:
                    K1 = (uint)
                       (chunk[0]
                      | chunk[1] << 8
                      | chunk[2] << 16);
                    K1 *= c1;
                    K1 = rotl32(K1, 15);
                    K1 *= c2;
                    Hash ^= K1;
                    break;
                case 2:
                    K1 = (uint)
                       (chunk[0]
                      | chunk[1] << 8);
                    K1 *= c1;
                    K1 = rotl32(K1, 15);
                    K1 *= c2;
                    Hash ^= K1;
                    break;
                case 1:
                    K1 = (uint)(chunk[0]);
                    K1 *= c1;
                    K1 = rotl32(K1, 15);
                    K1 *= c2;
                    Hash ^= K1;
                    break;

            }
        }

        public string GetHashString()
        {
            return BitConverter.ToString(BitConverter.GetBytes((int)Hash), 0).Replace("-", "");
        }

        private static uint rotl32(uint x, byte r)
        {
            return (x << r) | (x >> (32 - r));
        }

        public static uint fmix(uint h)
        {
            h ^= h >> 16;
            h *= 0x85ebca6b;
            h ^= h >> 13;
            h *= 0xc2b2ae35;
            h ^= h >> 16;
            return h;
        }
    }
}
