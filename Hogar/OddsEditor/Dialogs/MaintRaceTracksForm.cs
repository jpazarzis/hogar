using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.Dialogs
{
    public partial class MaintRaceTracksForm : Form
    {
        public MaintRaceTracksForm()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            BindCollection();
        }

        private void BindCollection()
        {
            _listboxRaceTracks.DataSource = null;
            _listboxRaceTracks.DataSource = RaceTracks.RaceTrackInfoCollection;
        }


        private RaceTrackInfo SelectedRaceTrack
        {
            get
            {
                if (null == _listboxRaceTracks.SelectedItem)
                {
                    return null;
                }
                else
                {
                    return (RaceTrackInfo)_listboxRaceTracks.SelectedItem;
                }
            }
        }

        private void _listboxRaceTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != SelectedRaceTrack)
            {
                _txtboxFullName.Text = SelectedRaceTrack.TrackName;
                _txtboxTrackCode.Text = SelectedRaceTrack.TrackCode;
                _txtboxBrisAbrv.Text = SelectedRaceTrack.BrisAbrv;
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnNew(object sender, EventArgs e)
        {
            try
            {
                var f = new EditRaceTrackInfoForm(null);
                if(f.ShowDialog() == DialogResult.OK)
                {
                    BindCollection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            try
            {
                var f = new EditRaceTrackInfoForm(SelectedRaceTrack);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    BindCollection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
