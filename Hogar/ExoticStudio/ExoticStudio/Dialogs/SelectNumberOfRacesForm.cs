using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExoticStudio
{
    public partial class SelectNumberOfRacesForm : Form
    {
        int _selectedCount;

        public SelectNumberOfRacesForm()
        {
            InitializeComponent();
        }

        public int GetNumberOfRaces()
        {   
            return _selectedCount;
        }

        private void OnOK(object sender, EventArgs e)
        {
            _selectedCount = Convert.ToInt32(_numberOfRacesComboBox.Text);
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnLoad(object sender, EventArgs e)
        {

            

            for (int i = Tools.MINIMUM_NUMBER_OF_RACES; i <= Tools.MAXIMUM_NUMBER_OF_RACES; ++i)
            {
                if (i != 7 && i != 8)
                {
                    _numberOfRacesComboBox.Items.Add(i.ToString());
                }
            }

            _numberOfRacesComboBox.SelectedIndex = 1;
        }
    }
}
