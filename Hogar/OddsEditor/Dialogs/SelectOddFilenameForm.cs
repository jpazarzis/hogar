using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hogar;
using Hogar.Algorithms.ANN.Neurons;
using OddsEditor.MyComponents;

namespace OddsEditor.Dialogs
{
    public partial class SelectOddFilenameForm : GenericForm
    {

        readonly Dictionary<string, SelectFileControl> _ctrls = new Dictionary<string, SelectFileControl>();
        readonly List<string> _trackCodeList = new List<string>();

        private static readonly int _totalNumberOfRacesInTheDataBase = 0;

        static SelectOddFilenameForm()
        {
            SqlDataReader myReader = null;
            try
            {
                string sql = "SELECT COUNT(*) FROM RACE_DESCRIPTION ";
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _totalNumberOfRacesInTheDataBase = myReader.GetInt32(0);
                        
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }

        public enum DisplayType
        {
            All,
            Today,
            Future
        }

        public SelectOddFilenameForm()
        {
            InitializeComponent();
        }


        static bool FileHasDateInThePast(string filename)
        {
            var s = filename.Split('\\');

            if (s.Length < 1)
                return false;

            string f = s[s.Length - 1];

            if (f.Length < 3)
                return false;

            f = f.Substring(3);

            int i = f.IndexOf('.');

            if (i < 0)
                return false;

            f = f.Substring(0, i);

            int c = string.Compare(f, string.Format("{0}{1:00}{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

            return c == -1;




        }

        public void DisplayCards(DisplayType dt)
        {
            RemoveAllControls();

            try
            {
                _trackCodeList.Clear();
                List<string> filename = DailyCard.ExistingFilesOnlyForFuture;

                string txt = "";
                for (int i = filename.Count - 1; i >= 0; --i)
                {
                    string s = filename[i];

                    if(FileHasDateInThePast(s))
                        continue;

                    var ofn = new OddsFilename(s);

                    if (dt == DisplayType.All)
                    {
                        txt = "Displaying All Available Cards";
                        AddFilenameToCorrespondingControl(ofn);
                    }
                    else if (dt == DisplayType.Today && ofn.IsTodaysCard)
                    {
                        txt = "Displaying Only Today's Cards";
                        AddFilenameToCorrespondingControl(ofn);
                    }
                    else if (dt == DisplayType.Future && ofn.IsFutureCard)
                    {
                        txt = "Displaying Future's Cards";
                        AddFilenameToCorrespondingControl(ofn);
                    }
                }


                _labelDisplayType.Text = string.Format("{0}        (Total Number of Races: {1})       ", txt, _totalNumberOfRacesInTheDataBase);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void RemoveAllControls()
        {
            var ctrls = new List<Control>();

            foreach (Control ctrl in _panel.Controls)
            {
                ctrls.Add(ctrl);
            }

            foreach (Control ctrl in ctrls)
            {
                _panel.Controls.Remove(ctrl);
            }

            _ctrls.Clear();
        }

        private void OnLoad(object sender, EventArgs e)
        {
           
        }

        private void AddFilenameToCorrespondingControl(OddsFilename ofn)
        {
            if (_ctrls.ContainsKey(ofn.Track) == false)                
            {
                var sfc = new SelectFileControl(ofn.Track, ofn.TrackCode);
                _panel.Controls.Add(sfc);
                _ctrls.Add(ofn.Track, sfc);
                sfc.FileSelectedEvent += OnFileSelected;
                _trackCodeList.Add(ofn.TrackCode);
            }
            _ctrls[ofn.Track].AddDate(ofn);
        }

        public void OnFileSelected(string filename)
        {
            var sf = new SummaryForm(filename);
            sf.Show();
        }
    }
}
