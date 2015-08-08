using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace FileSplitter
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application. [Guid("C79805B6-406D-49B6-8C3B-671DE56DCF4F")]
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartingForm());
        }
    }
}
