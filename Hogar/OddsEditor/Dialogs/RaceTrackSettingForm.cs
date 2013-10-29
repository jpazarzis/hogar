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
    public partial class RaceTrackSettingForm : Form
    {
        readonly RaceTrackInfo _raceTrackInfo;

        public RaceTrackSettingForm(string trackCode)
        {
            _raceTrackInfo = RaceTracks.GetRaceTrackInfo(trackCode);
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            Text = string.Format("Sibling Tracks for {0}", _raceTrackInfo.TrackName);
            _labelRaceTrackName.Text = string.Format("Sibling Tracks for {0}", _raceTrackInfo.TrackName);

            foreach (RaceTrackInfo rti in RaceTracks.RaceTrackInfoCollection)
            {
                if (rti == _raceTrackInfo) continue;
                CheckBox cb = new CheckBox();
                cb.Tag = rti;
                cb.Text = rti.TrackName;
                cb.Checked = _raceTrackInfo.IsSibling(rti);
                cb.Click += OnRaceTrackCheckBoxCliked;
                _panelSiblingRaceTracks.Controls.Add(cb);
            }

            
        }

        private void OnRaceTrackCheckBoxCliked(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbox = (CheckBox)sender;
                RaceTrackInfo rti = (RaceTrackInfo)cbox.Tag;
                if (cbox.Checked)
                {
                    _raceTrackInfo.AddSiblingTrack(rti);
                }
                else
                {
                    _raceTrackInfo.RemoveSiblingTrack(rti);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectAll(bool selectAll)
        {
            foreach (Control ctrl in _panelSiblingRaceTracks.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox cb = ctrl as CheckBox;
                    if (cb.Tag is RaceTrackInfo)
                    {
                        RaceTrackInfo rti = cb.Tag as RaceTrackInfo;
                        if (selectAll)
                        {
                            _raceTrackInfo.AddSiblingTrack(rti);
                            cb.Checked = true;
                        }
                        else
                        {
                            _raceTrackInfo.RemoveSiblingTrack(rti);
                            cb.Checked = false;
                        }
                    }
                }
            }
        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            if (sender == _buttonSelectAll)
            {
                SelectAll(true);
            }
            else if (sender == _buttonUnselectAll)
            {
                SelectAll(false);
            } 
        }

        private void OnButtonCloseClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
