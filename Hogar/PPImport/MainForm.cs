using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using System.IO;

namespace PPImport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _comboBoxSelectedYear.SelectedIndex = 0;
            LoadListBox();
        }

        private void ShowMessage(string txt)
        {
            _txtboxMessage.Text += txt + Environment.NewLine;
            if (_txtboxMessage.Text.Length + txt.Length >= _txtboxMessage.MaxLength)
            {
                _txtboxMessage.Text = _txtboxMessage.Text.Substring(10000);
            }
            _txtboxMessage.Select(_txtboxMessage.Text.Length + 1, 2);
            _txtboxMessage.ScrollToCaret();
        }

        private string SelectedYear
        {
            get
            {
                return _comboBoxSelectedYear.Text;
            }
        }

        private void ImportFile(string filename)
        {
            filename = filename.ToUpper();

            

            Utilities.RenameStringInFile(string.Format(@"{0}/{1}", Utilities.DirectoryToImportPP, filename), "\"PRX\"", "\"PHA\"");

            string destinationFilename = filename;

            if (destinationFilename.StartsWith("PRX"))
            {
                destinationFilename = destinationFilename.Replace("PRX", "PHA");    
            }

            string fileToCopy = Utilities.DirectoryToImportPP + @"\" + filename;
            string dirWhereToCopy = Utilities.PastPerformancesDirectory + @"\" + SelectedYear;

            if (false == Directory.Exists(dirWhereToCopy))
            {
                Directory.CreateDirectory(dirWhereToCopy);
            }
            string whereToCopy = dirWhereToCopy + @"\" + destinationFilename;

            if (File.Exists(whereToCopy))
            {
                File.Delete(whereToCopy);
            }

            File.Move(fileToCopy, whereToCopy);
            DailyCard raceCard = DailyCard.MakeNewFromBrisFile(whereToCopy);

            if (null != raceCard)
            {
                ShowMessage(string.Format("{0} imported successfully ", filename));
                //_listboxPastPerfomances.Items.Remove(filename);
            }
            else
            {
                ShowMessage(string.Format("Failed to Move {0} ", filename));
            }
        }

        private void LoadListBox()
        {
            _listboxPastPerfomances.Items.Clear();
            foreach (string filename in Directory.GetFiles(Utilities.DirectoryToImportPP))
            {
                _listboxPastPerfomances.Items.Add(Path.GetFileName(filename));
            }
        }

        private void OnImportAll(object sender, EventArgs e)
        {
            for (int i = 0; i < _listboxPastPerfomances.Items.Count; ++i)
            {
                string filename = _listboxPastPerfomances.Items[i].ToString();
                ImportFile(filename);
            }
        }
    }
}
