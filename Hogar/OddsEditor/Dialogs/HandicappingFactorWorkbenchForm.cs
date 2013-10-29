using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hogar.Handicapping;
using Hogar.Handicapping.Analysis;

namespace OddsEditor.Dialogs
{
    public partial class HandicappingFactorWorkbenchForm : GenericForm
    {
        

        public HandicappingFactorWorkbenchForm()
        {
            InitializeComponent();
        }

        void OnInitialLoad(object sender, EventArgs e)
        {
            LoadAvailableTracksComboBox();
            LoadAvailableFactorsComboBox();
        }

        string SelectedTrackCode
        {
            get
            {
                return _comboBoxSelectedRaceTrack.Text;
            }
        }

        void LoadAvailableFactorsComboBox()
        {
            
            _comboBoxFactor.Items.Clear();
            _comboBoxFactor.Items.Add("ALL");
            foreach(Factor f in Factor.AvailableFactorsAsList)
            {
                _comboBoxFactor.Items.Add(f.ToString());
            }
            
        }

        void LoadAvailableTracksComboBox()
        {
            
            _comboBoxSelectedRaceTrack.Items.Clear();
            _comboBoxSelectedRaceTrack.Items.Add("ALL");
            SqlDataReader myReader = null;
            try
            {
                string sql = "SELECT DISTINCT(TRACK_CODE) 'TRACK_CODE' FROM RACE_STARTERS";
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _comboBoxSelectedRaceTrack.Items.Add((string)myReader["TRACK_CODE"]);
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
                
            }
        }

        void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                
            }
        }

        private void OnExecute(object sender, EventArgs e)
        {
            
            BindingList<FactorPerformance> fp = new BindingList<FactorPerformance>();

            foreach (Factor f in Factor.AvailableFactorsAsList)
            {
                fp.Add(FactorPerformance.GetFactorPerformance(f.BitMask,0,SelectedTrackCode));
            }

            _grid.DataSource = fp;
            
            _grid.Columns["ROI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["ROI"].DefaultCellStyle.Format = "##.00";
            _grid.Columns["IV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["IV"].DefaultCellStyle.Format = "##.00";
            _grid.Columns["EIX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["EIX"].DefaultCellStyle.Format = "##.00";

        }

      
    }
}
