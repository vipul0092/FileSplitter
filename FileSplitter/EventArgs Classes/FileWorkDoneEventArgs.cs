using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSplitter.EventArgs_Classes
{
    public class FileWorkDoneEventArgs
    {
        public bool IsSplitDone;
        public bool IsJoinDone;

        public FileWorkDoneEventArgs(bool isSplit, bool isJoin)
        { this.IsJoinDone = isJoin; this.IsSplitDone = isSplit; }

    }
}
