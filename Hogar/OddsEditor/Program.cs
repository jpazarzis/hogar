using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OddsEditor.Dialogs;
using OddsEditor.Dialogs.Testing;
using OddsEditor.Dialogs.Filter;

namespace OddsEditor
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
            
            string[] arg = Environment.GetCommandLineArgs();
            Application.Run(new MainForm());

          // Application.Run(new FiltersForm());
            
            
        }
    }
}
