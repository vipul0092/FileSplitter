using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSplitter.EventArgs_Classes
{
    public class CloseProgressFormEventArgs
    {
        public bool isCancelClose;

        public CloseProgressFormEventArgs(bool isCancelClose)
        {
            this.isCancelClose = isCancelClose;
        }
    }
}
