using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.StatisticTools;
using Hogar.DbTools;

namespace TimeProjector
{
    public partial class MainForm : Form
    {
        private readonly AverageTimeCollection _atc = new AverageTimeCollection();
        private List<ProjectionVariables> _projectionVariables = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonCalculateSlopeAndOrdinateClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DbReader.ExecuteNonQuery("exec TV_UpdateContainsValidTimeFlag");
                _atc.Clear();
                _atc.LoadFromDb();

                string currentTrack = "";
                string currentSurface = "";
                string currentTrackDesc = "";

                _projectionVariables = new List<ProjectionVariables>();

                LeastSquareCalculator lsq = null;
                foreach (var at in _atc)
                {
                    if (at.TrackCode != currentTrack || at.Surface != currentSurface)
                    {
                        if (null != lsq)
                        {
                            _projectionVariables.Add(new ProjectionVariables() {TrackCode = currentTrack, Surface = currentSurface, Slope = lsq.Sloppe, Ordinate = lsq.Ordinate, TrackDesc = currentTrackDesc});
                        }

                        currentTrack = at.TrackCode;
                        currentSurface = at.Surface;
                        currentTrackDesc = at.TrackDesc;
                        lsq = new LeastSquareCalculator();
                    }

                    lsq.Add(at.Distance, at.FinalTime);
                }

                if (null != lsq)
                {
                    _projectionVariables.Add(new ProjectionVariables() {TrackCode = currentTrack, Surface = currentSurface, Slope = lsq.Sloppe, Ordinate = lsq.Ordinate, TrackDesc = currentTrackDesc});
                }

                _gridProjectionVariables.DataSource = _projectionVariables;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void ButtonUpdateDbClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DbReader.ExecuteNonQuery(SQL_DELETE_ALL);
                foreach (var pv in _projectionVariables)
                {
                    if (Double.IsNaN(pv.Slope) || double.IsInfinity(pv.Slope))
                        continue;

                    if (Double.IsNaN(pv.Ordinate) || double.IsInfinity(pv.Ordinate))
                        continue;

                 
                    DbReader.ExecuteNonQuery(string.Format(SQL_INSERT, pv.TrackDesc, pv.TrackCode, pv.Surface, pv.Slope, pv.Ordinate));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private const string SQL_INSERT = @"INSERT INTO TV_TIME_PROJECTOR_VARS_PER_TRACK
           (TRACK_DESC
           ,TRACK_CODE
           ,SURFACE
           ,SLOPE
           ,ORDINATE)
     VALUES
           ('{0}'
           ,'{1}'
           ,'{2}'
           ,{3}
           ,{4})";

        private const string SQL_DELETE_ALL = @"DELETE FROM TV_TIME_PROJECTOR_VARS_PER_TRACK";
    }
}