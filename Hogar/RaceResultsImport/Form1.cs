using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.DbTools;
using Hogar.RaceResults;
using Hogar.Handicapping;
using Hogar.Handicapping.Analysis;
using Hogar;

namespace RaceResultsImport
{
    public partial class Form1 : Form
    {
        RaceResultsInsertToDb _dataLoader = new RaceResultsInsertToDb();

        public Form1()
        {
            _dataLoader.ProcessStatusMessageEvent += OnUpdateMessageTextBox;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            try
            {
                string dbPath = ConfigurationSettings.AppSettings["ConnectionString"];
                this.Text = dbPath;
                DbUtilities.ConnectionString = dbPath;

                _listboxAvailableRaces.DataSource = RaceResultsInsertToDb.AvailableFiles;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void OnUpdateMessageTextBox(string txt)
        {
            _txtboxMessages.Text += txt + Environment.NewLine;

            if (_txtboxMessages.Text.Length + txt.Length >= _txtboxMessages.MaxLength)
            {
                _txtboxMessages.Text = _txtboxMessages.Text.Substring(10000);
            }

            _txtboxMessages.Select(_txtboxMessages.Text.Length + 1, 2);
            _txtboxMessages.ScrollToCaret();

            Application.DoEvents();
        }

        

        
        private void OnImportAll(object sender, EventArgs e)
        {
            Cursor original = this.Cursor;
            Cursor = Cursors.WaitCursor;
            _dataLoader.ImportAll();
            Cursor = original;
            Hogar.DbTools.DbUtilities.CloseConnection();
        }

        private void OnImportSelected(object sender, EventArgs e)
        {
            string filename = _listboxAvailableRaces.Items[_listboxAvailableRaces.SelectedIndex].ToString();
            Cursor original = this.Cursor;
            Cursor = Cursors.WaitCursor;
            _dataLoader.Import(filename);
            Cursor = original;
            Hogar.DbTools.DbUtilities.CloseConnection();
        }
    }
}
