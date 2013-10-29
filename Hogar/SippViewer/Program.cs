using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SippViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SippCardViewerForm());
           // Application.Run(new BrowserForm("KEE",new DateTime(2011,10,8),1));
            
        }
    }
}
