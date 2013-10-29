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
    public partial class EditRaceTrackInfoForm : Form
    {
        private RaceTrackInfo _rti;

        private DialogResult _dialogResult = System.Windows.Forms.DialogResult.Cancel;

        public EditRaceTrackInfoForm(RaceTrackInfo rti)
        {
            _rti = rti;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            _tbTrackName.Text = _rti != null ? _rti.TrackName : "";
            _tbTrackCode.Text = _rti != null ? _rti.TrackCode: "";
            _tbBrisAbrv.Text = _rti != null ? _rti.BrisAbrv : "";

            _buttonSave.Enabled = false;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (_tbTrackName.Text.Trim().Length <= 0 ||
                _tbTrackCode.Text.Trim().Length <= 0 ||
                _tbBrisAbrv.Text.Trim().Length <= 0)
            {
                _buttonSave.Enabled = false;
            }
            else
            {
                _buttonSave.Enabled = true;
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                if(null == _rti)
                {
                    _rti = RaceTracks.CreateNew(_tbTrackName.Text, _tbBrisAbrv.Text, _tbTrackCode.Text);
                }
                else
                {
                    _rti.SetValues(_tbTrackName.Text,_tbBrisAbrv.Text,_tbTrackCode.Text,false);
                }

                UpdateScreen();

                _dialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            if(_buttonSave.Enabled)
            {
                if(MessageBox.Show("There are unsaved Changes. You are sure that you want to exit?","Exiting",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            DialogResult = _dialogResult;
        }


    

  
        
    }
}
