// *************************************************************
// 
//                           Written By John Pazarzis
// 
// *************************************************************
// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp;

namespace SippViewer
{
    public partial class RaceViewerControl : UserControl
    {
        enum ViewType
        {
            ClassicView,
            SpeedFiguresView
        }

        private ViewType _viewType = ViewType.ClassicView;

        private SippRace _race;
        private Font _underlinedFont;
        private Font _boldFont = null;
        private SippHorse _selectedHorse = null;

        private SippOddsRetriever _oddsRetriever = null;
        private double _averageFigure = 0;
        private double _minFigure = 0;
        private double _maxFigure = 0;
        private double _stdevFigure = 0;


        private int _oddsColumnIndex;
        private int _oddsFromExactaColumnIndex;
        private int _oddsFromDoubleColumnIndex;


        public RaceViewerControl()
        {
            InitializeComponent();
        }

        public void Bind(SippRace race)
        {
            _selectedHorse = null;
            _oddsRetriever = null;
            
            _toolButonStartRealTimeOdds.Enabled = true;
            _toolButonShowDoublePool.Enabled = false;
            _toolButonExactas.Enabled = false;
            _toolButonBreadAndButer.Enabled = false;
            _toolButonShowHandicappingFactors.Enabled = true;
            _toolButonCompareJockeys.Enabled = true;
            _underlinedFont = new Font(_gridPP.DefaultCellStyle.Font, FontStyle.Underline);
            _boldFont = new Font(_gridPP.DefaultCellStyle.Font.FontFamily, _gridPP.DefaultCellStyle.Font.Size, FontStyle.Bold);
            _race = race;
            UpdateScreen();
        }

        private Color GetBackgroundColorForFigure(int speedFigure)
        {
            if (speedFigure >= _averageFigure + 1 * _stdevFigure)
            {
                return Color.Red;
            }
            else if (speedFigure >= _averageFigure)
            {
                return Color.LightPink;
            }
            else if (speedFigure >= _averageFigure - 1 * _stdevFigure)
            {
                return Color.LightGray;
            }
            else
            {
                return Color.Gray;
            }
        }


        private void UpdateScreen()
        {
            Clear();

            _toolButonStartRealTimeOdds.Enabled = true;
            _toolButonShowDoublePool.Enabled = false;
            _toolButonExactas.Enabled = false;
            _toolButonBreadAndButer.Enabled = false;
            _toolButonShowHandicappingFactors.Enabled = true;
            _toolButonShowHandicappingFactors.Enabled = true;
            _toolButonCompareJockeys.Enabled = true;
            _toolButonShowSpeedFigures.Enabled = true;
            if (null == _race)
                return;

            var _figures = new List<double>();
            var f = _race.GetBrisSpeedFiguresForRecentFormCycles();
            _figures.Clear();
            _figures.AddRange(f.Select(i => (double) i));

            _averageFigure = _figures.Count > 0 ? _figures.Average() : 0;
            _minFigure = _figures.Count > 0 ? _figures.Min() : 0;
            _maxFigure = _figures.Count > 0 ? _figures.Max() : 0;
            _stdevFigure = _figures.Count > 0 ? RaceViewerControl.CalculateStdDev(_figures) : 0;


            var programNumberFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);

            _labelCondition.Text = _race.RaceCondition;
            _labelRaceNumber.Text = _race.RaceNumber.ToString();

            if (_race.Surface.ToUpper().Contains("T"))
            {
                _labelRaceNumber.BackColor = Color.Green;
                _labelRaceNumber.ForeColor = Color.LightGreen;

            }
            else
            {
                _labelRaceNumber.BackColor = Color.Brown;
                _labelRaceNumber.ForeColor = Color.White;
            }

            _grid.Columns.Add("program-number", "PN");
            _grid.Columns.Add("name", "NAME");
            _grid.Columns.Add("moring-line-odds", "M/L");

            _oddsColumnIndex = _grid.Columns.Add("real-time-odds", "Odds");
            _oddsFromExactaColumnIndex = _grid.Columns.Add("exacta-odds", "EO");
            _oddsFromDoubleColumnIndex = _grid.Columns.Add("double-odds", "DO");

            

            _grid.Columns.Add("Jockey", "Jockey");
            _grid.Columns.Add("Trainer", "Trainer");
            _grid.Columns.Add("Quirin", "Quirin");
            _grid.Columns.Add("Style", "Style");
            _grid.Columns.Add("figure", "FIG");
            _grid.Columns.Add("days-off", "Off");


            for (int i = 0; i < 10; ++i)
            {
                string columnName = string.Format("PP_{0}", i);
                _grid.Columns.Add(columnName, columnName);
            }

            SippHorse firstHorse = null;

            foreach (var horse in _race.OrderBy(h => (-1)*h.PrimePower))
            {
                if (null == firstHorse)
                {
                    firstHorse = horse;
                }

                int rowIndex = _grid.Rows.Add();
                var cell = _grid.Rows[rowIndex].Cells;

                _grid.Rows[rowIndex].Tag = horse;

                _grid.Rows[rowIndex].Height = 32;

                cell[0].Value = horse.ProgramNumber;
                cell[1].Value = horse.Name;
                cell[2].Value = horse.MorningLineOdds;
                cell[6].Value = horse.Jockey;
                cell[7].Value = horse.Trainer;
                cell[8].Value = horse.QuirinSpeedPoints;
                cell[9].Value = horse.RunningStyle;
                cell[10].Value = horse.PrimePower;
                cell[11].Value = horse.DaysOff;

                int ppIndex = 0;
                for (int col = 12; col < 22; ++col, ++ppIndex)
                {
                    var c = cell[col];

                    if (ppIndex >= horse.PastPerformances.Count)
                    {
                        c.Style.BackColor = Color.Black;
                        c.Style.SelectionBackColor = Color.Black;
                    }
                    else
                    {
                        c.Style.BackColor = Color.Cyan;
                        c.Style.SelectionBackColor = Color.Cyan;
                        c.Value = horse.PastPerformances[ppIndex].SpeedFigure;

                        SetCellColor(c, Color.Navy, GetBackgroundColorForFigure(horse.PastPerformances[ppIndex].SpeedFigure));
                    }
                }

                cell[0].Style.Font = programNumberFont;
                if (horse.FirstTimeOut)
                {
                    SetCellColor(cell[0], Color.Yellow, Color.Blue);
                }
                else
                {
                    SetCellColor(cell[0], Color.White, Color.Black);
                }

                cell[0].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                cell[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                cell[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                cell[6].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                Color daysOffBackColor = Color.White;

                if (horse.ComingFromLayOff)
                {
                    daysOffBackColor = Color.Yellow;
                }
                else if (horse.SecondOfLayoff)
                {
                    daysOffBackColor = Color.LightGreen;
                }
                else if (horse.ThirdOfLayoff)
                {
                    daysOffBackColor = Color.Pink;
                }

                SetCellColor(cell[3], Color.Yellow, Color.Black);
                SetCellColor(cell[4], Color.Yellow, Color.Black);
                SetCellColor(cell[5], Color.Yellow, Color.Black);

                cell[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cell[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cell[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                SetCellColor(cell[11], Color.Black, daysOffBackColor);
            }

            _grid.Columns[0].Width = 60;
            _grid.Columns[1].Width = 130;
            _grid.Columns[2].Width = 30;
            _grid.Columns[6].Width = 130;
            _grid.Columns[7].Width = 130;
            _grid.Columns[8].Width = 30;
            _grid.Columns[9].Width = 40;
            _grid.Columns[10].Width = 30;
            _grid.Columns[11].Width = 40;


        

            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            UpdateViewType();
            PaintHorseNameBasedInContenterAndScratchedStatus();

            DisplayHorseInfo(firstHorse);
            ShowAverageBrisFigures();
            
        }

        void UpdateViewType()
        {
            _linkSelectViewType.Text = _viewType == ViewType.ClassicView ? "Switch to Figures View" : "Switch to Classic View";

            if(_grid.Columns.Count < 21)
                return;

            if(_viewType == ViewType.ClassicView)
            {
                for(int col = 6; col < 12; ++col)
                {
                    _grid.Columns[col].Visible = true;
                }

                for(int col = 12 ; col < 22; ++col)
                {
                    _grid.Columns[col].Visible = false;
                }
            }
            else
            {
                for (int col = 6; col < 12; ++col)
                {
                    _grid.Columns[col].Visible = false;
                }

                for (int col = 12; col < 22; ++col)
                {
                    _grid.Columns[col].Visible = true;
                }
            }
            
        }


        private void SetCellColor(DataGridViewCell cell, Color fore, Color back)
        {
            cell.Style.BackColor = back;
            cell.Style.SelectionBackColor = back;

            cell.Style.ForeColor = fore;
            cell.Style.SelectionForeColor = fore;
        }

        public void Clear()
        {
            _grid.Rows.Clear();
            _grid.Columns.Clear();
            _labelCondition.Text = "";
            _labelRaceNumber.Text = "";
            _labelSelectedHorseName.Text = "";
            _labelSelectedHorseNumber.Text = "";
            _toolButonShowDoublePool.Enabled = false;
            _toolButonExactas.Enabled = false;
            _toolButonStartRealTimeOdds.Enabled = false;
            _toolButonBreadAndButer.Enabled = false;
            _toolButonShowHandicappingFactors.Enabled = false;
            _toolButonCompareJockeys.Enabled = false;
            _toolButonShowSpeedFigures.Enabled = false;
            _tbAverage.Text = "";
            _tbMin.Text = "";
            _tbMax.Text = "";
            _tbStdev.Text = "";
            _tbTrainerStats.Text = "";
            _tbJockeyStats.Text = "";
            _tbJockeyTrainerStats.Text = "";
            _tbJockeySummarizedStats.Text = "";
            _txtboxBrisRunStyle.Text = "";
            _txtboxClaimingPrice.Text = "";
            _txtboxColorSexAge.Text = "";
            _txtboxOwner.Text = "";
            _txtboxOwnersSilks.Text = "";
            _txtboxQuirinSpeedIndex.Text = "";
            _txtboxPostPosition.Text = "";
            _txtBoxMorningLine.Text = "";
            _txtboxDamInfo.Text = "";
            _txtboxSireInfo.Text = "";
            _tbPastPerformancesHeader.Text = "";
            _tbCurrentWinOdds.Text = "";
            _tbCurrentExactaOdds.Text = "";
            _tbCurrentDoubleOdds.Text = "";
            _gridHandicappingFactors.BorderStyle = BorderStyle.None;
            _gridJockeyStats.BorderStyle = BorderStyle.None;
            _gridSummarizeStats.BorderStyle = BorderStyle.None;
            _grid.BorderStyle = BorderStyle.None;
            _selectedHorse = null;
            UpdateViewType();
        }

        private void RaceViewerControl_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        
        public void DisplayHorseInfo(SippHorse horse)
        {
            _labelSelectedHorseNumber.Text = horse.ProgramNumber;

            _labelSelectedHorseNumber.BackColor = SippExtentions.SaddleClothBackColor(horse.ProgramNumberWithoutEntryChar);
            _labelSelectedHorseNumber.ForeColor = SippExtentions.SaddleClothFrontColor(horse.ProgramNumberWithoutEntryChar);


            _labelSelectedHorseName.Text = string.Format("{0}  {1} ({2} - {3})", horse.Name, horse.MedicationAndWeight, horse.Jockey,horse.Trainer);

            _txtboxBrisRunStyle.Text = horse.RunningStyle;

            if (horse.ClaimingPrice > 0)
                _txtboxClaimingPrice.Text = "$ " + horse.ClaimingPrice.ToString("#,##0");
            else
                _txtboxClaimingPrice.Text = "";

            _txtboxColorSexAge.Text = horse.ColorAgeAndSex;
            _txtboxOwner.Text = horse.Owner;
            _txtboxOwnersSilks.Text = horse.OwnerSilks;
            _txtboxQuirinSpeedIndex.Text = horse.QuirinSpeedPoints.ToString();
            _txtboxSireInfo.Text = horse.SireName;
            _txtboxDamInfo.Text = horse.Dam;
            _txtboxPostPosition.Text = "";
            _txtboxPostPosition.Text = horse.PostPosition.ToString();
            _tbCurrentWinOdds.Text = horse.CurrentOddsFromWin;
            _tbCurrentExactaOdds.Text = horse.CurrentOddsFromExacta;
            _tbCurrentDoubleOdds.Text = horse.CurrentOddsFromDouble;


            var odds = SippOdds.Make("1");
            odds.SetOddsToOne(horse.MorningLineOdds);

            _txtBoxMorningLine.Text = odds.ToString();

            _gridHandicappingFactors.Rows.Clear();
            _gridHandicappingFactors.Columns.Clear();

            _gridHandicappingFactors.Columns.Add("Name", "Name");
            _gridHandicappingFactors.Columns.Add("General", "General");
            _gridHandicappingFactors.Columns.Add("Trainer", "Trainer");

            foreach (var hp in horse.HandicappingFactors)
            {
                int rowindex = _gridHandicappingFactors.Rows.Add();
                var cells = _gridHandicappingFactors.Rows[rowindex].Cells;

                cells[0].Value = hp.Name;
                cells[1].Value = hp.GeneralStats.ToString();
                cells[2].Value = hp.TrainerStats.ToString();

                cells[0].Style.Font = new Font("Microsoft Sans Serif", 8.25F,FontStyle.Bold);
            }

            _gridHandicappingFactors.Columns[0].Width = 180;
            _gridHandicappingFactors.Columns[1].Width = 150;
            _gridHandicappingFactors.Columns[2].Width = 150;
            _gridHandicappingFactors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            _tbPastPerformancesHeader.Text = string.Format("Past Performances [ {0} ]", horse.Name);
            _gridPP.DataSource = horse.PastPerformances;



            _gridPP.Columns["SurfaceAndDistanceType"].Visible = false;
            _gridPP.Columns["DistanceInYards"].Visible = false;
            _gridPP.Columns["AboutDistanceFlag"].Visible = false;
            _gridPP.Columns["WinnersFinalTime"].Visible = false;
            _gridPP.Columns["ThisHorseFinalTime"].Visible = false;
            _gridPP.Columns["NormalFigureColor"].Visible = false;
            _gridPP.Columns["Parent"].Visible = false;
            
            HighlightPPGrid();
            LoadBreedingInfo(horse);
            LoadSummarizedStats(horse);

            _selectedHorse = horse;
        }

        

        private void LoadSummarizedStats(SippHorse horse)
        {
            _gridSummarizeStats.Rows.Clear();
            _gridSummarizeStats.Columns.Clear();
            _gridSummarizeStats.Columns.Add("Stat", "Stats");
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.LifeTimeRecord;
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.CurrentYearRecord;
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.PreviousYearRecord;
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.WetTrackRecord;
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.TurfTrackRecord;
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.TodaysTrackRecord;
            _gridSummarizeStats.Rows[_gridSummarizeStats.Rows.Add()].Cells[0].Value = horse.TodaysDistanceRecord;

            _gridSummarizeStats.BorderStyle = BorderStyle.None;

            
            _tbTrainerStats.Text = horse.TrainerStatistics;
            _tbJockeyStats.Text = horse.JockeyStatistics;
            _tbJockeyTrainerStats.Text = horse.JockeyTrainerStatistics;

            _tbJockeySummarizedStats.Text = horse.Jockey;
            _gridJockeyStats.Rows.Clear();
            _gridJockeyStats.Columns.Clear();
            _gridJockeyStats.Columns.Add("Name", "Name");
            _gridJockeyStats.Columns.Add("Stats", "Stats");

            _gridJockeyStats.Columns[0].Width = 80;
            _gridJockeyStats.Columns[1].Width = 170;


            foreach (var s in _race.Parent.GetJockeySummarizedStatistics(horse.Jockey))
            {
                var cells = _gridJockeyStats.Rows[_gridJockeyStats.Rows.Add()].Cells;
                cells[0].Value = s.Name;
                cells[1].Value = s.ToString();
            }

        }

        private void LoadBreedingInfo(SippHorse horse)
        {
            _gridBreedingInfo.Columns.Clear();

            _gridBreedingInfo.Columns.Add("S-DS", "S-DS");
            _gridBreedingInfo.Columns.Add("Name", "Name");
            _gridBreedingInfo.Columns.Add("FTS", "FTS");
            _gridBreedingInfo.Columns.Add("MUD", "MUD");
            _gridBreedingInfo.Columns.Add("TURF", "TURF");
            _gridBreedingInfo.Columns.Add("AWS", "AWS");
            _gridBreedingInfo.Columns.Add("DIST", "DIST");

            int index = _gridBreedingInfo.Rows.Add();

            var boldFont = new Font(_gridBreedingInfo.DefaultCellStyle.Font, FontStyle.Bold);
            _gridBreedingInfo.Rows[index].DefaultCellStyle.Font = boldFont;
            _gridBreedingInfo["FTS", index].Value = "FTS";
            _gridBreedingInfo["MUD", index].Value = "M";
            _gridBreedingInfo["TURF", index].Value = "T";
            _gridBreedingInfo["AWS", index].Value = "AWS";
            _gridBreedingInfo["DIST", index].Value = "D";

            foreach (var sire in new List<SippSire> {horse.Sire, horse.DamSire})
            {
                if(null == sire)
                    continue;
                
                index = _gridBreedingInfo.Rows.Add();
                DataGridViewCellCollection cells = _gridBreedingInfo.Rows[index].Cells;

                cells[0].Value = (sire == horse.Sire ? "S" : "DS");
                cells[0].Style.Font = boldFont;
                cells[1].Value = sire.Name;
                cells[2].Value = sire.FirstTimeOutRating;
                cells[3].Value = sire.MudRating;
                cells[4].Value = sire.TurfRating;
                cells[5].Value = sire.AllWeatherRating;
                cells[6].Value = sire.AverageDistance;
            }

            for (int i = 0; i < _gridBreedingInfo.Columns.Count; ++i)
            {
                _gridBreedingInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            _gridBreedingInfo.BorderStyle = BorderStyle.None;
            _gridBreedingInfo.CellBorderStyle = DataGridViewCellBorderStyle.None;
            _gridBreedingInfo.DefaultCellStyle.BackColor = Color.Beige;
            _gridBreedingInfo.DefaultCellStyle.SelectionBackColor = Color.Beige;
            _gridBreedingInfo.RowHeadersVisible = false;
            _gridBreedingInfo.ColumnHeadersVisible = false;

            _gridBreedingInfo.BackgroundColor = Color.Beige;
        }

        private void PaintBrisSpeedFigureCell(int rowIndex, string columnName)
        {
            Color backColor = Color.Olive;
            Color foreColor = Color.Wheat;

            _gridPP[columnName, rowIndex].Style.BackColor = backColor;
            _gridPP[columnName, rowIndex].Style.ForeColor = foreColor;

            _gridPP[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _gridPP[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _gridPP[columnName, rowIndex].Style.Font = _boldFont;
            _gridPP[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private Color GetColorForCallPosition(int rowIndex, string columnName)
        {
            try
            {
                int pos = Convert.ToInt32(_gridPP[columnName, rowIndex].Value.ToString().Trim());

                switch (pos)
                {
                    case 1:
                        return Color.Red;
                    case 2:
                        return Color.LightGreen;
                    case 3:
                    case 4:
                    case 5:
                        return Color.White;
                    default:
                        return Color.LightGray;
                }
            }
            catch
            {
                return Color.Black;
            }
        }

        private void HighlightPPGrid()
        {
            _gridPP.Columns["Odds"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _gridPP.Columns["DaysSincePreviousRace"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _gridPP.Columns["DaysSinceTodaysRace"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _gridPP.RowsDefaultCellStyle.BackColor = Color.White;
            _gridPP.RowsDefaultCellStyle.ForeColor = Color.Black;
            _gridPP.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _gridPP.RowsDefaultCellStyle.SelectionBackColor = _gridPP.RowsDefaultCellStyle.BackColor;

            _gridPP.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;
            _gridPP.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            _gridPP.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _gridPP.AlternatingRowsDefaultCellStyle.SelectionBackColor = _gridPP.AlternatingRowsDefaultCellStyle.BackColor;
        }

        private void _gridPP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int row = e.RowIndex;
                var daysSinceLast = (int) _gridPP.Rows[row].Cells["DaysSincePreviousRace"].Value;
                _gridPP.Rows[row].DefaultCellStyle.Font = daysSinceLast >= 45 ? _underlinedFont : _gridPP.DefaultCellStyle.Font;

                _gridPP["FirstCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FirstCallPosition");
                _gridPP["SecondCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "SecondCallPosition");
                _gridPP["ThirdCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "ThirdCallPosition");
                _gridPP["FinalPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FinalPosition");

                PaintBrisSpeedFigureCell(e.RowIndex, "SpeedFigure");

                Color distanceColor = Color.LightCyan;

                _gridPP["FirstCallLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                _gridPP["SecondCallLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                _gridPP["ThirdCallLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                _gridPP["FinalLengthsBehind", e.RowIndex].Style.BackColor = distanceColor;
                _gridPP["PostPosition", e.RowIndex].Style.BackColor = Color.LightSalmon;


                var pp = (SippPastPerformance)_gridPP.Rows[e.RowIndex].DataBoundItem;

                _gridPP["NormalFigure", e.RowIndex].Style.BackColor = pp.NormalFigureColor;
                _gridPP["NormalFigure", e.RowIndex].Style.SelectionBackColor = pp.NormalFigureColor;


                if (null != _gridPP["Surface", e.RowIndex].Value)
                {
                    var surface = (string) _gridPP["Surface", e.RowIndex].Value;
                    _gridPP["Surface", e.RowIndex].Style.BackColor = surface.IndexOf('T') != -1 ? Color.LightGreen : Color.White;
                }

                _gridPP["TrackVariant", e.RowIndex].Style.Font = _boldFont;
                _gridPP["TrackVariant", e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                _gridPP["TrackVariant", e.RowIndex].Style.BackColor = Color.White;
                _gridPP["TrackVariant", e.RowIndex].Style.ForeColor= Color.Blue;
                _gridPP["TrackCode", e.RowIndex].Style.BackColor = Color.White;
                _gridPP["TrackCode", e.RowIndex].Style.ForeColor = Color.Blue;


                foreach (DataGridViewCell cell in _gridPP.Rows[e.RowIndex].Cells)
                {
                    cell.Style.SelectionBackColor = cell.Style.BackColor;
                    cell.Style.SelectionForeColor = cell.Style.ForeColor;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < _grid.Rows.Count)
            {
                var horse = _grid.Rows[rowIndex].Tag as SippHorse;

                if (null == horse)
                    return;

                DisplayHorseInfo(horse);
            }
        }

        void PaintHorseNameBasedInContenterAndScratchedStatus()
        {
            foreach (DataGridViewRow gridRow in _grid.Rows)
            {
                var h = gridRow.Tag as SippHorse;
                if (null != h)
                {
                    var cell = gridRow.Cells["name"];
                    var bc = Color.White;
                    
                    if (!h.IsContender)
                    {
                        bc = Color.Gray;
                    }


                    if(h.IsBestBet)
                    {
                        bc = Color.LightPink;
                    }

                    cell.Style.BackColor = bc;
                    cell.Style.SelectionBackColor = bc;
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.SelectionForeColor = Color.Black;

                    if (h.Scratched)
                    {
                        gridRow.Visible = false;
                    }
                }
            }
        }

        public void ToggleHorseStatus(SippHorse horse)
        {
            if (null != horse)
            {
                horse.IsContender = !horse.IsContender;
            }

            PaintHorseNameBasedInContenterAndScratchedStatus();
        }

        private void ToggleHorseScratch(object sender, EventArgs e)
        {
            try
            {
                var h = ((ToolStripItem)sender).Tag as SippHorse;
                if (null != h)
                    h.Scratched = !h.Scratched;
                PaintHorseNameBasedInContenterAndScratchedStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToggleHorseIsBestBet(object sender, EventArgs e)
        {
            try
            {
                var h = ((ToolStripItem) sender).Tag as SippHorse;
                if (null != h)
                    h.IsBestBet = !h.IsBestBet;
                PaintHorseNameBasedInContenterAndScratchedStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnHorseToggleContenterStatus(object sender, EventArgs e)
        {
            try
            {
                ToggleHorseStatus(((ToolStripItem) sender).Tag as SippHorse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowRace(object sender, EventArgs e)
        {
            try
            {
                var race = ((ToolStripItem)sender).Tag as SippRace;
                if(null != race)
                {
                    Bind(race);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int columnIndex = e.ColumnIndex;

                if (_grid.Columns[columnIndex].Name == "Jockey")
                {
                    var horse = _grid.Rows[e.RowIndex].Tag as SippHorse;
                    if(null != horse)
                    {
                        Rectangle r = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _popupmenu.Items.Clear();
                        _popupmenu.Items.Add(string.Format("All horses for Jockey {0} for today's card",horse.Jockey));
                        _popupmenu.Items.Add("-");
                        foreach (var h in _race.Parent.GetHorsesForJockey(horse.Jockey))
                        {
                            string s = string.Format("Race# {0}: Number: {1} Horse: {2} M/L: {3} Trainer: {4} ", h.Parent.RaceNumber, h.ProgramNumber, h.Name, h.MorningLineOdds, h.Trainer);
                            ToolStripItem item = _popupmenu.Items.Add(s, null, OnShowRace);
                            item.Tag = h.Parent;
                        }   
                        _popupmenu.Show((Control)sender, r.Left + e.X, r.Top + e.Y);    
                    }
                }
                else if (_grid.Columns[columnIndex].Name == "Trainer")
                {
                    var horse = _grid.Rows[e.RowIndex].Tag as SippHorse;
                    if (null != horse)
                    {
                        Rectangle r = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _popupmenu.Items.Clear();
                        _popupmenu.Items.Add(string.Format("All horses for Trainer {0} for today's card", horse.Trainer));
                        _popupmenu.Items.Add("-");
                        foreach (var h in _race.Parent.GetHorsesForTrainer(horse.Trainer))
                        {
                            string s = string.Format("Race# {0}: Number: {1} Horse: {2} M/L: {3} Jockey: {4} ", h.Parent.RaceNumber, h.ProgramNumber, h.Name, h.MorningLineOdds, h.Jockey);
                            ToolStripItem item = _popupmenu.Items.Add(s, null, OnShowRace);
                            item.Tag = h.Parent;
                        }
                        _popupmenu.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
                    }
                }
                else if (_grid.Columns[columnIndex].Name == "name")
                {
                    var horse = _grid.Rows[e.RowIndex].Tag as SippHorse;
                    if (null != horse)
                    {
                        Rectangle r = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _popupmenu.Items.Clear();
                        _popupmenu.Items.Add(string.Format("{0} ", horse.Name));
                        _popupmenu.Items.Add("-");

                        string s = horse.IsContender ? "Is No Contenter" : "Is Contenter";

                        ToolStripItem item = _popupmenu.Items.Add(s, null, OnHorseToggleContenterStatus);
                        item.Tag = horse;


                        s = horse.IsBestBet ? "Is Not Best Bet" : "Is Best Bet";
                        item = _popupmenu.Items.Add(s, null, ToggleHorseIsBestBet);
                        item.Tag = horse;

                        s = horse.Scratched ? "Unscratch" : "Scratch";
                        item = _popupmenu.Items.Add(s, null, ToggleHorseScratch);
                        item.Tag = horse;

                        
                        _popupmenu.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
                    }
                }

            }
            else
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0 && rowIndex < _grid.Rows.Count)
                {
                    var horse = _grid.Rows[rowIndex].Tag as SippHorse;

                    if (null == horse)
                        return;

                    DisplayHorseInfo(horse);
                }    
            }
            
        }

        public void UpdateRealTimeOdds()
        {
            if (null != _oddsRetriever)
            {
                if (_oddsRetriever.ErrorStatus != 0)
                {
                    string msg = _oddsRetriever.ErrorMessage;
                    StopOddsRetriever();
                    MessageBox.Show(msg);
                    return;
                }

                var odds = _oddsRetriever.RealTimeOdds;
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    var horse = (SippHorse)row.Tag;
                    int number = horse.ProgramNumberWithoutEntryChar;

                    if (odds.ContainsKey(number))
                    {
                        SippOdds oddsToWin = odds[number].OddsToWin;

                        if (oddsToWin.Scratched && !horse.Scratched)
                        {
                            horse.Scratched = true;
                        }

                        if(!horse.Scratched)
                        {
                            double oddsToOne = oddsToWin.GetOddsToOne();
                            horse.RealTimeOdds = oddsToOne;
                            horse.AddRealTimeOddsToHistory(oddsToWin);
                            row.Cells[_oddsColumnIndex].Value = oddsToOne;
                            SippOdds oddsFromExacta = odds[number].OddsFromExactas;
                            SippOdds oddsFromDouble = odds[number].OddsFromDouble;

                            horse.CurrentOddsFromWin = null != oddsToOne ? ((int)oddsToOne).ToString() : "";
                            horse.CurrentOddsFromExacta = null != oddsFromExacta ? ((int)oddsFromExacta).ToString() : "";
                            horse.CurrentOddsFromDouble = null != oddsFromDouble ? ((int)oddsFromDouble).ToString() : "";



                            if (null != oddsFromExacta)
                            {
                                row.Cells[_oddsFromExactaColumnIndex].Value = (int)oddsFromExacta.GetOddsToOne();
                            }
                            if (null != oddsFromDouble)
                            {
                                row.Cells[_oddsFromDoubleColumnIndex].Value = (int)oddsFromDouble.GetOddsToOne();
                            }    
                        }   
                    }                    
                }

                foreach (DataGridViewRow gridRow in _grid.Rows)
                {
                    var h = gridRow.Tag as SippHorse;
                    if (null != h && h.Scratched && gridRow.Visible)
                    {
                        gridRow.Visible = false;    
                    }
                }

                if (_oddsRetriever.PoolWasClosed)
                {
                    StopOddsRetriever();
                }
            }
        }

        private void PaintRowForScratchedHorse(SippHorse horse)
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                var h = row.Tag as SippHorse;
                if(null != h && h == horse && h.Scratched)
                {
                    row.DefaultCellStyle.BackColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.Black;
                    return;
                }
            }
        }

        private void StopOddsRetriever()
        {
            if (null != _oddsRetriever)
            {
                _oddsRetriever.StopIt();
            }
            _toolButonStartRealTimeOdds.Enabled = true;
        }

      

        public void ShowAverageBrisFigures()
        {
             var _figures = new List<double>();
            var f = _race.GetBrisSpeedFiguresForRecentFormCycles();
            _figures.Clear();
            foreach (var i in f)
            {
                _figures.Add(i);
            }
            _tbAverage.Text = string.Format("{0:0}", _figures.Count > 0 ? _figures.Average() : 0);
            _tbMin.Text = string.Format("{0:0}", _figures.Count > 0 ? _figures.Min() : 0);
            _tbMax.Text = string.Format("{0:0}", _figures.Count > 0 ? _figures.Max() : 0);
            _tbStdev.Text = string.Format("{0:0}", _figures.Count > 0 ? CalculateStdDev(_figures) : 0);
        }

        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        public static double CalculateStdDev(IEnumerable<int> values)
        {
            return CalculateStdDev(values.Select(i => (double)i).ToList());
        }

        

        private void _toolButonStartRealTimeOdds_Click(object sender, EventArgs e)
        {
            if(null != _race)
            {
                _oddsRetriever = new SippOddsRetriever(_race.Parent.TrackCode, _race.RaceNumber, _race.Parent.Date);
                _oddsRetriever.UpdateObserverDelegateEvent += UpdateRealTimeOdds;
                _toolButonStartRealTimeOdds.Enabled = false;
                _toolButonShowDoublePool.Enabled = true;
                _toolButonExactas.Enabled = true;
                _toolButonExactas.Enabled = true;
                _toolButonBreadAndButer.Enabled = true;
            }
            
        }

        private void _toolButonBreadAndButer_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new BreadAndButterForm(_race, _oddsRetriever);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _toolButonExactas_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ExoticCombinationForm(_oddsRetriever, ExoticCombinationForm.ExoticCombinationType.Exacta);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _toolButonShowDoublePool_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ExoticCombinationForm(_oddsRetriever, ExoticCombinationForm.ExoticCombinationType.Double);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _toolButonShowSpeedFigures_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FiguresSummaryForm(_race);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _toolButonShowHandicappingFactors_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FactorsSummaryForm(_race, this);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _toolButonCompareJockeys_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new CompareJockeysForm(_race);
                f.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void _txtboxClaimingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void _txtboxQuirinSpeedIndex_TextChanged(object sender, EventArgs e)
        {

        }

    
        public void UnsubscribeFromFeed()
        {
            StopOddsRetriever();
            _oddsRetriever = null;
        }


        void ShowBreedingForHorse(string name)
        {
            try
            {
                if (null != _selectedHorse)
                {
                    name = name.Trim();

                    if (name.Length <= 0)
                        return;

                    int pos = name.IndexOf("(");
                    name = name.Substring(0, pos - 1);
                    var form = new BrowserForm(name);
                    form.ShowDialog();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void _txtboxSireInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null != _selectedHorse)
            {
                ShowBreedingForHorse(_selectedHorse.SireName);
            }
        }

        private void _txtboxDamInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null != _selectedHorse)
            {
                ShowBreedingForHorse(_selectedHorse.Dam);
            }
        }

      

        private void _gridPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == _gridPP.Columns["TrackVariant"].Index)
                    {
                        string trackCode = _gridPP["TrackCode", e.RowIndex].Value.ToString();
                        int distanceInYards = (int)_gridPP["DistanceInYards", e.RowIndex].Value;
                        string surface = _gridPP["SURFACE", e.RowIndex].Value.ToString();
                        var pp = (SippPastPerformance)_gridPP.Rows[e.RowIndex].DataBoundItem;
                        var form = new CynthiaParsForm(trackCode, distanceInYards, pp);
                        form.ShowDialog();
                    }
                    else if (e.ColumnIndex == _gridPP.Columns["TrackCode"].Index || e.ColumnIndex == _gridPP.Columns["RaceReplay"].Index)
                    {
                        int row = e.RowIndex;
                        var trackCode = _gridPP.Rows[row].Cells["TrackCode"].Value;
                        var date = _gridPP.Rows[row].Cells["RacingDate"].Value;
                        int raceNumber = (int)_gridPP.Rows[row].Cells["RaceNumber"].Value;
                        var form = new BrowserForm(trackCode.ToString(), (DateTime)date, raceNumber);
                        form.ShowDialog();
                    }

                    else if (e.ColumnIndex == _gridPP.Columns["RunAgainstIcon"].Index)
                    {
                        var pp = (SippPastPerformance)_gridPP.Rows[e.RowIndex].DataBoundItem;
                        if(pp.RunAgainst.Count > 0)
                        {
                            var form = new RunAgainstForm((SippPastPerformance)_gridPP.Rows[e.RowIndex].DataBoundItem);
                            form.ShowDialog();    
                        }
                    }
                    else if (e.ColumnIndex == _gridPP.Columns["PostPosition"].Index)
                    {
                        var pp = (SippPastPerformance)_gridPP.Rows[e.RowIndex].DataBoundItem;

                        string trackCode = pp.TrackCode;
                        string surface = pp.Surface.ToUpper();
                        string aboutDistanceFlag = pp.AboutDistanceFlag ? "A" : "";
                        double distance = pp.DistanceInYards;

                        if(surface == "IT")
                        {
                            surface = "t";
                        }

                        if (surface == "ID")
                        {
                            surface = "d";
                        }



                        var form = new PostPositionStatsForm(trackCode, surface, aboutDistanceFlag, distance);

                        form.ShowDialog();
 
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }

        private void _gridPP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void _linkUnscratchAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                var horse = row.Tag as SippHorse;
                if(null != horse)
                {
                    horse.Scratched = false;
                }
            }
            UpdateScreen();
        }

        private void _linkSelectViewType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_viewType == ViewType.ClassicView)
            {
                _viewType = ViewType.SpeedFiguresView;
            }
            else
            {
                _viewType = ViewType.ClassicView;
            }

            UpdateViewType();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void _txtboxPostPosition_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string trackCode = _selectedHorse.Parent.Parent.TrackCode;
                string surface = _selectedHorse.Parent.Surface;
                string aboutDistanceFlag = "";
                double distance = _selectedHorse.Parent.DistanceInYeards;


                var form = new PostPositionStatsForm(trackCode, surface, aboutDistanceFlag, distance);

                form.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}