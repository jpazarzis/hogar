using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExoticStudio
{
    static class Program
    {

        static MainForm _mainForm = null;

        public static MainForm GetMainForm()
        {
            return _mainForm;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            _mainForm = new MainForm();
            Application.Run(_mainForm);
        }
    }
}
