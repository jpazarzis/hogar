using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.DbTools;
using TrackVariantMaint.IntraTrackVariantMaint;
using TrackVariantMaint.AnalysisPerTrack;

namespace TrackVariantMaint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RaceTracks.RaceTrackInfoCollection.ForEach(i => _cbTrackCode.Items.Add(i));

            if (_cbTrackCode.Items.Count > 0)
            {
                _cbTrackCode.SelectedIndex = 0;
            }
        }

        private void _cbTrackCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbSurface.Items.Clear();
            LoadSurfaceComboBox();
        }

        private string CurrentTrackCode
        {
            get
            {
                var item = _cbTrackCode.SelectedItem;
                return null != item ? ((RaceTrackInfo) item).TrackCode : "";
            }
        }

        private string CurrentSurface
        {
            get
            {
                var item = _cbSurface.SelectedItem;
                return null != item ? item.ToString() : "";
            }
        }

        

        private void LoadSurfaceComboBox()
        {
            _cbSurface.Items.Clear();

            string trackCode = CurrentTrackCode.Trim();

            if (trackCode.Length <= 0)
                return;

            using (var dbr = new DbReader())
            {
                if (dbr.Open(string.Format(@"select distinct(surface COLLATE SQL_Latin1_General_CP1_CS_AS) 'surface' from race_description where track_code='{0}'", trackCode)))
                {
                    while (dbr.MoveToNextRow())
                    {
                        _cbSurface.Items.Add(dbr.GetValue<string>("surface"));
                    }
                }
            }

            if (_cbSurface.Items.Count > 0)
            {
                _cbSurface.SelectedIndex = 0;
            }

            
        }

 
        private void _buttonShowTrackVariantForm_Click(object sender, EventArgs e)
        {
            try
            {
                
                string trackCode = CurrentTrackCode.Trim();
                string surface = CurrentSurface.Trim();

                if(trackCode.Length > 0 && surface.Length > 0)
                {
                    var f = new TrackVariantForm(trackCode, surface);
                    f.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void _buttonIntraTrackVariant_Click(object sender, EventArgs e)
        {
            try
            {

                var f = new AdjustIntraTrackVariantForm();
                f.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void _buttonAnalysisPerTrack_Click(object sender, EventArgs e)
        {
            try
            {

                var f = new AnalysisPerTrackForm();
                f.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}