using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OddsEditor.Dialogs;
using Hogar;
using Hogar.BrisPastPerformances;
using System.Diagnostics;
using Hogar.Handicapping.Analysis;

namespace OddsEditor.MyComponents
{
    public partial class SelectFileControl : UserControl
    {
        readonly string _trackFullName;
        readonly string _brisAbrvTrackCode;

        public delegate void FileSelectedDelegate(string filename);

        public event FileSelectedDelegate FileSelectedEvent;


        public SelectFileControl(string trackFullName, string brisAbrvTrackCode)
        {
            _trackFullName = trackFullName;
            _brisAbrvTrackCode = brisAbrvTrackCode;
            InitializeComponent();
        }

        public string Racetrack
        {
            get
            {
                return _trackFullName;
            }
        }

        public override string ToString()
        {
            return _trackFullName;
        }

        public void AddDate(OddsFilename fn)
        {
            int index = _listboxDate.Items.Add(fn); 
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            string trackCode = RaceTracks.GetTrackCodeFromBrisAbrv(_brisAbrvTrackCode);
            int numberOfRacesInDb = RaceTracks.GetTotalNumberOfRacesInDb(trackCode);
            string txt = string.Format("{0}({1})", _trackFullName, numberOfRacesInDb);
            _txtboxRacetrack.Text = txt;
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {

            if (null == _listboxDate.SelectedItem)
            {
                return;
            }
            var ofn = (OddsFilename)_listboxDate.SelectedItem;

            FileSelectedEvent(ofn.FullPath);
        }

        private void OnEditRaceTrackSetting(object sender, MouseEventArgs e)
        {
            try
            {
                var f = new RaceTrackSettingForm(RaceTracks.GetTrackCodeFromBrisAbrv(_brisAbrvTrackCode));
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
