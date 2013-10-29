using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hogar;
using Hogar.DbTools;
using OddsEditor.Dialogs.WinnersForDay;

namespace OddsEditor.Dialogs
{
    public partial class ShowRacesByHorseForm : OddsEditor.GenericForm
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        private string _horseName = "";

        public ShowRacesByHorseForm()
        {
            InitializeComponent();
        }

        public ShowRacesByHorseForm(string horseName)
        {
            _horseName = horseName;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            if (_horseName.Length > 3)
            {
                _txtboxHorseName.Text = _horseName;
                OnGo(null, null);
            }
        }

        private void OnGo(object sender, EventArgs e)
        {
            if (_txtboxHorseName.Text.Trim().Length <= 3)
            {
                return;
            }

            try
            {
                var collection = new StarterInfoCollection(_txtboxHorseName.Text.Trim());
                _grid.DataSource = collection;
                _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowAllRacesForTheDay(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripItem;

            if (null == menuItem)
                return;

            var rd = menuItem.Tag as RaceDesc;
            if (null == rd)
                return;

            try
            {
                ShowFractionsForTheDayForm.DisplayModal(rd.Date, rd.TrackCode, rd.HorseName, rd.RaceNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        var dc = _grid.DataSource as StarterInfoCollection;

                        if (null != dc)
                        {
                            Rectangle r = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                            _popUpMenu.Items.Clear();

                            ToolStripItem item = _popUpMenu.Items.Add("Show All Races For The Day", null, OnShowAllRacesForTheDay);

                            string temp = dc[e.RowIndex].Date;
                            int year = int.Parse(temp.Substring(0, 4));
                            int month = int.Parse(temp.Substring(4, 2));
                            int day = int.Parse(temp.Substring(6, 2));
                            DateTime date = new DateTime(year, month, day);

                            item.Tag = new RaceDesc
                                           {
                                               RaceNumber = dc[e.RowIndex].RaceNumber,
                                               HorseName = dc[e.RowIndex].HorseName,
                                               TrackCode = dc[e.RowIndex].TrackCode,
                                               Date = date
                                           };

                            _popUpMenu.Show((Control) sender, r.Left + e.X, r.Top + e.Y);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (e.RowIndex >= 0)
                            {
                                var dc = _grid.DataSource as StarterInfoCollection;

                                if (null != dc)
                                {
                                    var f = new RaceChartForm(dc[e.RowIndex].RaceId);
                                    f.ShowDialog();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnGridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 1)
            {
                int finishPosition = (int) _grid["Position", e.RowIndex].Value;

                if (1 == finishPosition)
                {
                    _grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    _grid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = _grid.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                }
                else if (2 == finishPosition)
                {
                    _grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    _grid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = _grid.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                }
            }
        }

        private class RaceDesc
        {
            public int RaceNumber { get; set; }
            public string HorseName { get; set; }
            public string TrackCode { get; set; }
            public DateTime Date { get; set; }
        } ;

        private class StarterInfo : IDbPopulatable
        {
            [Browsable(false)]
            public int RaceId { get; set; }
            
            [DisplayName("Track")]
            public string TrackCode { get; set; }

            public string Date { get; set; }

            [DisplayName("#")]
            public int RaceNumber { get; set; }

            public string Distance { get; set; }

            [DisplayName("S")]
            public string Surface { get; set; }

            [DisplayName("Class")]
            public string Classification { get; set; }

            [DisplayName("Name")]
            public string HorseName { get; set; }

            [DisplayName("Jockey")]
            public string Jockey { get; set; }

            [DisplayName("Trainer")]
            public string Trainer { get; set; }

            public double Odds { get; set; }
            
            public int Weight { get; set; }
            
            public int Position { get; set; }

            public void Populate(DbReader dbr)
            {
                RaceId = dbr.GetValue<int>("RACE_ID");
                TrackCode = dbr.GetValue<string>("TRACK_CODE");
                Date = dbr.GetValue<string>("RACING_DATE");
                RaceNumber = dbr.GetValue<int>("RACE_NUMBER");
                Distance = Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int) dbr.GetValue<double>("DISTANCE"));
                Surface = dbr.GetValue<string>("SURFACE");
                Classification = dbr.GetValue<string>("ABBR_RACE_CLASS");
                HorseName = dbr.GetValue<string>("HORSE_NAME");
                Jockey = Utilities.CapitalizeOnlyFirstLetter(dbr.GetValue<string>("ABBR_JOCKEY_NAME"));
                Trainer = Utilities.CapitalizeOnlyFirstLetter(dbr.GetValue<string>("ABBR_TRAINER_NAME"));
                Odds = dbr.GetValue<double>("ODDS");
                Weight = dbr.GetValue<int>("WEIGHT");
                Position = dbr.GetValue<int>("OFFICIAL_POSITION");
            }
        }

        private class StarterInfoCollection : DataBaseCollection<StarterInfo>
        {
            private const string SQL_LOADER = @"SELECT   a.RACE_ID, 
                                                a.TRACK_CODE  ,
                                                a.RACING_DATE ,
                                                a.RACE_NUMBER ,
                                                b.DISTANCE ,
                                                b.SURFACE ,
                                                b.ABBR_RACE_CLASS ,
                                                a.HORSE_NAME ,
                                                a.ABBR_JOCKEY_NAME ,
                                                a.ABBR_TRAINER_NAME ,
                                                a.ODDS ,
                                                a.WEIGHT ,
                                                a.OFFICIAL_POSITION  
                                        FROM RACE_STARTERS a, RACE_DESCRIPTION b
                                        WHERE HORSE_NAME LIKE ('{0}') 
                                                AND a.RACE_ID = b.RACE_ID
                                                AND a.program_number !='SCR' ORDER BY a.RACING_DATE DESC";

            public StarterInfoCollection(string horseName)
            {
                Initialize(horseName);
            }

            private void Initialize(string horseName)
            {
                Load(string.Format(SQL_LOADER, horseName));
            }
        }
    }
}