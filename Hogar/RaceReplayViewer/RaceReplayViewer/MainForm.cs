using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaceReplayViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string GetRaceReplaysUrl()
        {
            string trackCdode = ((TrackInfo) _comboBoxTrack.SelectedItem).TrackCode;
            DateTime date = _dateTimePicker.Value;
            int raceNumber = (int) _comboBoxRaceNumber.SelectedItem;
            trackCdode = trackCdode.Trim();
            if (trackCdode.Length == 2)
            {
                trackCdode += "9";
            }


            string key = string.Format("{0}{1:00}{2:00}{3:00}A{4:00}", trackCdode, date.Month, date.Day, date.Year - 2000, raceNumber);
            return string.Format("http://www.racereplays.com/racereplays/replay_embeded.cfm?raceid=T{0}pf", key);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTracks();
            
            for (int i = 1; i < 15; ++i )
            {
                _comboBoxRaceNumber.Items.Add(i);
            }

            _comboBoxTrack.SelectedIndex = 0;
            _comboBoxRaceNumber.SelectedIndex = 0;


            _webBrowser.Navigate(@"http://www.racereplays.com/racereplays/index.cfm?start=RR");
        }

        private void LoadTracks()
        {
            try
            {
                _comboBoxTrack.Items.Clear();
                TrackInfoCollection.Singleton.ForEach(ti => _comboBoxTrack.Items.Add(ti));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void _buttonGo_Click(object sender, EventArgs e)
        {
            _webBrowser.Navigate(GetRaceReplaysUrl());
        }
    }
}
