using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExoticStudio.UserControls
{
    public partial class GroupMatchesAndOddsAveragesInput : UserControl
    {
        private FullSystem _fullSystem = null;

        private bool _isLoading = false;

        public GroupMatchesAndOddsAveragesInput()
        {
            InitializeComponent();
        }

        public void BindFullSystem(FullSystem fs)
        {
            _fullSystem = fs;
            OnLoad(null, null);
        }

        private void LoadGroupMatchesComboBoxes()
        {
            _minGroupMatchesComboBox.Items.Clear();
            _maxGroupMatchesComboBox.Items.Clear();

            if (null != _fullSystem && _fullSystem.NumberOfGroups > 0)
            {
                for (int i = 0; i <= _fullSystem.NumberOfGroups; ++i)
                {
                    int index = _minGroupMatchesComboBox.Items.Add(i);

                    if (i == _fullSystem.MinNumberOfMatchingGroups)
                    {
                        _minGroupMatchesComboBox.SelectedIndex = index;
                    }

                    index = _maxGroupMatchesComboBox.Items.Add(i);

                    if (i == _fullSystem.MaxNumberOfMatchingGroups)
                    {
                        _maxGroupMatchesComboBox.SelectedIndex = index;
                    }
                }
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _isLoading = true;
            LoadGroupMatchesComboBoxes();

            _isLoading = false;
        }

        private void UpdateFullSystem()
        {
            if (false == _isLoading)
            {
                _fullSystem.MinNumberOfMatchingGroups = Convert.ToInt32(_minGroupMatchesComboBox.Text);
                _fullSystem.MaxNumberOfMatchingGroups = Convert.ToInt32(_maxGroupMatchesComboBox.Text);
            }
        }

        private void OnMinChanged(object sender, EventArgs e)
        {
            UpdateFullSystem();
        }

        private void OnMaxChanged(object sender, EventArgs e)
        {
            UpdateFullSystem();
        }
    }
}