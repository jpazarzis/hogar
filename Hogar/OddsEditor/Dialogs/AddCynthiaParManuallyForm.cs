using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Cynthia;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace OddsEditor.Dialogs
{
    public partial class AddCynthiaParManuallyForm : Form
    {
        readonly CynthiaPar _cp;

        public AddCynthiaParManuallyForm(CynthiaPar cp)
        {
            _cp = cp;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            if (null == _cp)
            {
                return;
            }

            _txtboxTrackCode.Text = _cp.TrackCode;
            _txtboxDistance.Text = _cp.DistanceInYards.ToString();
            _txtboxClassification.Text = _cp.CynthiaClassification;
            _txtboxSurface.Text = _cp.Surface;
            _txtboxAboutFlag.Text = _cp.AboutFlag;

            try
            {
                string sql = string.Format("select * from cynthia_pars where track_code = '{0}' and distance = {1} and SURFACE = '{2}' AND ABOUT_FLAG = '{3}' ORDER BY FINAL_CALL", _cp.TrackCode, _cp.DistanceInYards, _cp.Surface, _cp.AboutFlag);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                _grid.DataSource = dataSet.Tables[0];
                //_grid.Columns["ROI"].DefaultCellStyle.Format = "c";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _buttonSaveAndClose.Enabled = false;
        }

        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                double firstCall = (double)_grid["FIRST_CALL", e.RowIndex].Value;
                double midCall = (double)_grid["MID_CALL", e.RowIndex].Value;
                double finalCall = (double)_grid["FINAL_CALL", e.RowIndex].Value;

                _txtboxFirstCall.Text = firstCall.ToString();
                _txtboxSecondCall.Text = midCall.ToString();
                _txtboxFinalCall.Text = finalCall.ToString();

                _buttonSaveAndClose.Enabled = true;
            }
        }

        private void OnSaveAndClose(object sender, EventArgs e)
        {
            try
            {
                double firstCall = Convert.ToDouble(_txtboxFirstCall.Text);
                double midCall = Convert.ToDouble(_txtboxSecondCall.Text);
                double finalCall = Convert.ToDouble(_txtboxFinalCall.Text);

                string deleteSql = string.Format(@"delete cynthia_pars where track_code = '{0}' and distance = {1} and surface = '{2}' and about_flag = '{3}' and class = '{4}'", _cp.TrackCode, _cp.DistanceInYards, _cp.Surface, _cp.AboutFlag, _cp.CynthiaClassification);
                
                string insertSql = string.Format(@"insert into cynthia_pars (track_code, surface, distance, about_flag, class, first_call, mid_call, final_call, manual_addition) values ('{0}', '{1}', {2}, '{3}', '{4}', {5}, {6}, {7}, {8})", _cp.TrackCode, _cp.Surface, _cp.DistanceInYards, _cp.AboutFlag, _cp.CynthiaClassification, firstCall, midCall, finalCall, 1);
                SqlCommand myCommand = new SqlCommand(deleteSql, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();

                myCommand = new SqlCommand(insertSql, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();

                _buttonSaveAndClose.Enabled = false;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
