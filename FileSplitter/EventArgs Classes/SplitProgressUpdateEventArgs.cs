using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSplitter.EventArgs_Classes
{
    public class SplitProgressUpdateEventArgs
    {
        int sfile;
        int nsfiles;
        int sfileperc;
        int tfileperc;

        public int CurrentSplitFileNum { get { return sfile; } }
        public int TotalSplitFiles { get { return nsfiles; } }
        public int CurrentSplitFilePercentage { get { return sfileperc; } }
        public int TotalSplitPercentage { get { return tfileperc; } }

        public SplitProgressUpdateEventArgs(int sfile, int nsfiles, int sfileperc, int tfileperc)
        { this.sfile = sfile; this.nsfiles = nsfiles; this.sfileperc = sfileperc; this.tfileperc = tfileperc; }
    }
}
