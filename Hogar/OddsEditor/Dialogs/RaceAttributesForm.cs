using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Handicapping.Analysis;

namespace OddsEditor.Dialogs
{
    public partial class RaceAttributesForm : Form
    {
        readonly Race _race;

        bool _changed = false;

        public RaceAttributesForm(Race race)
        {
            _race = race;
            InitializeComponent();
        }

        public bool Changed
        {
            get
            {
                return _changed;
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _labelRaceTrackInfo.Text =  RaceTracks.GetNameFromTrackCode(_race.Parent.TrackCode)+ ", " + _race.Parent.Date + ",  Race# " +  _race.RaceNumber.ToString();
            foreach (RaceAttributes ra in _race.RaceAttributesToUseForHandicapping)
            {
                CheckBox cb = new CheckBox();
                cb.Text = ra.Description;
                cb.Width = 140;
                cb.Checked = ra.IsChecked;
                cb.Tag = ra;
                _panel.Controls.Add(cb);
            }

            LoadFactorsDepthComboBox();
        }

        void LoadFactorsDepthComboBox()
        {
            _comboBoxFactorsDepth.Items.Clear();

            for (int i = Race.MinFactorsDepth; i <= Race.MaxFactorsDepth; ++i)
            {
                _comboBoxFactorsDepth.Items.Add(i);
            }

            _comboBoxFactorsDepth.SelectedItem = _race.FactorsDepth;

        }

        private void OnForceUpdate(object sender, EventArgs e)
        {
            _changed = true;
            foreach (Control ctrl in _panel.Controls)
            {
                CheckBox cb = ctrl as CheckBox;
                if (null != cb)
                {
                    RaceAttributes ra = cb.Tag as RaceAttributes;
                    if (null != ra)
                    {
                        if (ra.IsChecked != cb.Checked)
                        {
                            ra.IsChecked = cb.Checked;
                        }

                    }
                }
            }

            int factorsDepth = (int)_comboBoxFactorsDepth.SelectedItem;
            if (factorsDepth != _race.FactorsDepth)
            {
                _race.FactorsDepth = factorsDepth;
            }

            if (_changed)
            {
                _race.ClearFactorPerformanceCache();
            }

            DialogResult = DialogResult.OK;
        }

        private void OnOK(object sender, EventArgs e)
        {
            _changed = false;
            foreach (Control ctrl in _panel.Controls)
            {
                CheckBox cb = ctrl as CheckBox;
                if (null != cb)
                {
                    RaceAttributes ra = cb.Tag as RaceAttributes;
                    if (null != ra)
                    {
                        if (ra.IsChecked != cb.Checked)
                        {
                            ra.IsChecked = cb.Checked;
                            _changed = true;
                        }
                        
                    }
                }
            }

            int factorsDepth = (int)_comboBoxFactorsDepth.SelectedItem;

            if (factorsDepth != _race.FactorsDepth)
            {
                _race.FactorsDepth = factorsDepth;
                _changed = true;
            }

            if (_changed)
            {
                _race.ClearFactorPerformanceCache();
            }

            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
    }
}
