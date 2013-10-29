using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using Hogar.DbTools;
using Hogar.Handicapping;
using Hogar.StatisticTools;
using OddsEditor.Dialogs;
using OddsEditor.Dialogs.JockeyStatistics;
using OddsEditor.Dialogs.WinnersForDay;
using OddsEditor.Dialogs.PaceFigures;
using OddsEditor.Dialogs.PostPositionBehavior;

namespace OddsEditor.MyComponents
{
    public partial class HorseFractionsComponent : UserControl
    {
        private BrisHorse.TimingType _timingType;
        private readonly Horse _myHorse;
        private bool _isLoading = true;

        private Font _boldFont = null;
        private Font _underlinedFont = null;
        private Font _hyperlinkFont = null;

        private List<string> _topSpotFinishersWhoHaveDbEntries = null;

        public static int CompareByPrimePower(HorseFractionsComponent c1, HorseFractionsComponent c2)
        {
            if (c1.PrimePowerRating > c2.PrimePowerRating)
            {
                return -1;
            }
            else if (c1.PrimePowerRating < c2.PrimePowerRating)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public HorseFractionsComponent(Horse myHorse, BrisHorse.TimingType timingType)
        {
            _myHorse = myHorse;
            _timingType = timingType;
            InitializeComponent();
        }

        public void SelectRow(string date)
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (((string) row.Cells["Date"].Value).CompareTo(date) == 0)
                {
                    row.Selected = true;
                    return;
                }
            }
        }

        private void LoadWorkoutsToPanel()
        {
            List<Workout> workout = _myHorse.CorrespondingBrisHorse.GetWorkouts();
            this.SuspendLayout();
            for (int i = 0; i < workout.Count; ++i)
            {
                Workout previousWorkout = null;
                if (i + 1 < workout.Count)
                {
                    previousWorkout = workout[i + 1];
                }

                var fsp = new WorkoutComponent(workout[i], previousWorkout);
                _panelWorkouts.Controls.Add(fsp);
            }
            this.ResumeLayout(false);
            this.Refresh();
            this.AdjustFormScrollbars(true);
        }

        public string BrisRunStyle { get { return _txtboxBrisRunStyle.Text; } }

        public int QuirinSpeedIndex
        {
            get
            {
                string s = _txtboxQuirinSpeedIndex.Text.Trim();
                return s.Length > 0 ? Convert.ToInt32(s) : 0;
            }
        }

        public int PrimePowerRating
        {
            get
            {
                string s = _txtboxPrimePowerRating.Text.Trim();
                return s.Length > 0 ? Convert.ToInt32(s) : 0;
            }
        }

        public string HorseName { get { return _txtboxHorseName.Text; } }

        public string ProgramNumber { get { return _txtboxHorseNumber.Text; } }

        private Form GetParentForm(Control control)
        {
            if (null == control.Parent)
            {
                return null;
            }
            else if (control.Parent is Form)
            {
                return control.Parent as Form;
            }
            else
            {
                return GetParentForm(control.Parent);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _topSpotFinishersWhoHaveDbEntries = null;

            string trackCode = RaceTracks.GetNameFromTrackCode(_myHorse.Parent.Parent.TrackCode);
            int raceNumber = _myHorse.Parent.RaceNumber;
            string date = Utilities.GetFullDateString(_myHorse.Parent.Parent.Date);
            string classification = _myHorse.Parent.CorrespondingBrisRace.RaceClassification;
            _labelRaceInfo.Text = string.Format("{0}  {1} Race#{2}  {3}", trackCode, date, raceNumber, classification);

            DateTime time = DateTime.Now;
            _boldFont = new Font(_grid.DefaultCellStyle.Font.FontFamily, _grid.DefaultCellStyle.Font.Size, FontStyle.Bold);
            _underlinedFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);
            _hyperlinkFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);
            _isLoading = true;
            _txtboxHorseNumber.Text = _myHorse.CorrespondingBrisHorse.ProgramNumber;
            _txtboxHorseNumber.BackColor = Utilities.SaddleClothBackColor(_myHorse.GetProgramNumberWithoutEntryChar());
            _txtboxHorseNumber.ForeColor = Utilities.SaddleClothFrontColor(_myHorse.GetProgramNumberWithoutEntryChar());
            _txtboxHorseName.Text = _myHorse.CorrespondingBrisHorse.Name;
            
            string jockey = _myHorse.CorrespondingBrisHorse.Jockey;

            _txtboxJockeyName.Text = string.Format("{0} {1}", jockey, JockeyStatistics.Get(jockey).GeneralStats);
            

            _txtboxOwner.Text = @"Own: " + _myHorse.CorrespondingBrisHorse.Owner;
            _txtboxOwnersSilks.Text = _myHorse.CorrespondingBrisHorse.OwnersSilks;
            _txtboxOdds.Text = _myHorse.RealTimeOdds.ToString();
            _txtboxSireInfo.Text = _myHorse.CorrespondingBrisHorse.SireInfo;
            _txtboxDamInfo.Text = _myHorse.CorrespondingBrisHorse.DamInfo;
            _txtboxTrainerInfo.Text = _myHorse.CorrespondingBrisHorse.TrainerInfo;
            _txtboxWeight.Text = _myHorse.CorrespondingBrisHorse.MedicationAndWeight;
            _txtboxLifeTimeEarnings.Text = _myHorse.CorrespondingBrisHorse.LifeTimeEarnings;
            _txtboxCurrentYearEarnings.Text = _myHorse.CorrespondingBrisHorse.CurrentYearEarnings;
            _txtboxPreviousYearEarnings.Text = _myHorse.CorrespondingBrisHorse.PreviousYearEarnings;
            _txtboxTodaysTrackEarnings.Text = _myHorse.CorrespondingBrisHorse.TodaysTrackEarnings;
            _txtboxWetTrackEarnings.Text = _myHorse.CorrespondingBrisHorse.WetTrackEarnings;
            _txtboxTurfTrackEarnings.Text = _myHorse.CorrespondingBrisHorse.TurfTrackEarnings;
            _txtboxTodaysDistanceEarnings.Text = _myHorse.CorrespondingBrisHorse.TodaysDistanceEarnings;
            _txtboxPrimePowerRating.Text = _myHorse.CorrespondingBrisHorse.PrimePowerRating.ToString();
            _txtboxDaysSinceLastRace.Text = _myHorse.CorrespondingBrisHorse.DaysSinceLastRace.ToString();

            if (_myHorse.CorrespondingBrisHorse.ClaimingPriceOfTheHorse > 0)
            {
                _txtboxClaimingPrice.Text = string.Format("${0}", _myHorse.CorrespondingBrisHorse.ClaimingPriceOfTheHorse);
            }
            else
            {
                _txtboxClaimingPrice.Visible = false;
            }

            _txtboxColorSexAge.Text = _myHorse.CorrespondingBrisHorse.ColorAgeAndSex;
            _txtboxQuirinSpeedIndex.Text = _myHorse.CorrespondingBrisHorse.QuirinSpeedPoints.ToString();
            _txtboxBrisRunStyle.Text = _myHorse.CorrespondingBrisHorse.BrisRunStyle;
            _labelPostPosition.Text = string.Format("PP {0}", _myHorse.CorrespondingBrisHorse.PostPosition);

            LoadWorkoutsToPanel();

            _topSpotFinishersWhoHaveDbEntries = _myHorse.CorrespondingBrisHorse.TopSpotFinishersWhoHaveDataBaseEntries;

            UpdateGrid();

            _factorAnalysisCtrl.Bind(_myHorse);
            _breedingInfoCtrl.BindHorse(_myHorse);

            switch (_timingType)
            {
                case BrisHorse.TimingType.LeadersHorse:
                    _radioButtonWinner.Checked = true;
                    break;
                case BrisHorse.TimingType.ThisHorse:
                    _radioButtonThis.Checked = true;
                    break;
                case BrisHorse.TimingType.PaceFigures:
                    _radioButtonFigures.Checked = true;
                    break;
            }

            Form parent = GetParentForm(this);

            if (null != parent)
            {
                parent.Closing += ParentClosing;
            }


            _brisFiguresStatsCtrl1.Bind(_myHorse.Parent);
            _isLoading = false;
        }

        private void ParentClosing(object sender, CancelEventArgs e)
        {
        }

        public void SaveHorseComments(string txt)
        {
            _myHorse.Comments = txt;
            _myHorse.UpdateCommentObservers(this);
        }

        private void UpdateGrid()
        {
            var hiddenColumns = new List<string>();
            _grid.DataSource = _myHorse.CorrespondingBrisHorse.GetFractionsAsDataTable(_timingType, hiddenColumns).Tables[0];

            HighlightGrid();
            foreach (DataGridViewColumn column in _grid.Columns)
            {
                if (hiddenColumns.Contains(column.HeaderText))
                {
                    column.Visible = false;
                }
            }
        }

        private void PaintSelectedRunningLineCell(int row)
        {
            var pp = (BrisPastPerformance) _grid["ID_PP_OBJECT", row].Value;

            Color c = Color.White;
            string s = "";
            if (pp.Parent.CorrespondingHorse.SelectedRunningLine == pp)
            {
                c = Color.Red;
                s = char.ConvertFromUtf32(219);
            }
            _grid.Rows[row].Cells["SELECTED_AS_RUNNING_LINE"].Style.ForeColor = c;
            _grid.Rows[row].Cells["SELECTED_AS_RUNNING_LINE"].Style.SelectionForeColor = c;
            _grid.Rows[row].Cells["SELECTED_AS_RUNNING_LINE"].Value = s;
        }

        private void HighlightGrid()
        {
            var smallFont = new Font("Arial", 8.1F);

            _grid.Columns["BrisRaceShapeFirstCall"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["BrisRaceShapeSecondCall"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["BrisRaceShapeFirstCall"].DefaultCellStyle.BackColor = Color.LightGray;
            _grid.Columns["BrisRaceShapeSecondCall"].DefaultCellStyle.BackColor = Color.LightGray;
            _grid.Columns["BrisRaceShapeFirstCall"].DefaultCellStyle.Font = _boldFont;
            _grid.Columns["BrisRaceShapeSecondCall"].DefaultCellStyle.Font = _boldFont;
            _grid.Columns["BrisRaceRating"].DefaultCellStyle.Font = _boldFont;
            _grid.Columns["BrisClassRating"].DefaultCellStyle.Font = _boldFont;
            _grid.Columns["SELECTED_AS_RUNNING_LINE"].DefaultCellStyle.Font = _boldFont;
            _grid.Columns["Odds"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["NumberOfDaysSinceLastRace"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns["NumberOfDaysSinceThatRace"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _grid.RowsDefaultCellStyle.BackColor = Color.White;
            _grid.RowsDefaultCellStyle.ForeColor = Color.Black;
            _grid.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _grid.RowsDefaultCellStyle.SelectionBackColor = _grid.RowsDefaultCellStyle.BackColor;

            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            _grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            _grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = _grid.AlternatingRowsDefaultCellStyle.BackColor;
        }

        private void OnTrainerInfoClick(object sender, MouseEventArgs e)
        {
            try
            {
                var f = new IndividualTrainerStatsForm(_myHorse);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnJockeyClick(object sender, MouseEventArgs e)
        {
            try
            {
                //var f = new JockeyStatisticsForm(_myHorse.CorrespondingBrisHorse.Jockey);


                var f = new ImpactValueForm
                            {
                                ImpactValues = JockeyStatistics.Get(_myHorse.CorrespondingBrisHorse.Jockey).AllStats,
                                Description = _myHorse.CorrespondingBrisHorse.Jockey
                            };

                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static int GetRaceIdFromDb(string trackCode, int year, int month, int day, int raceNumber)
        {
            int raceid = -1;
            using (var dbr = new DbReader())
            {
                string date = string.Format("{0:0000}{1:00}{2:00}", year, month, day);
                string sql = string.Format(@"SELECT RACE_ID FROM RACE_DESCRIPTION  WHERE TRACK_CODE = '{0}' AND DATE_OF_THE_RACE = '{1}' AND RACE_NUMBER= {2}", trackCode, date, raceNumber);

                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        raceid = dbr.GetValue<int>("RACE_ID");
                    }
                }
            }
            return raceid;
        }

        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == _grid.Columns["TrackVariant"].Index)
                    {
                        string trackCode = _grid["ID_INFO_TRACK_CODE", e.RowIndex].Value.ToString();
                        int distanceInYards = (int) _grid["ID_INFO_DISTANCE_IN_YARDS", e.RowIndex].Value;
                        string surface = _grid["SURFACE", e.RowIndex].Value.ToString();
                        var pp = (BrisPastPerformance) _grid["ID_PP_OBJECT", e.RowIndex].Value;

                        var form = new CynthiaParsForm(trackCode, distanceInYards, pp);
                        form.ShowDialog();
                    }
                    else
                    {
                        var date = (string) _grid["ID_INFO_DATE", e.RowIndex].Value;
                        var trackCode = (string) _grid["ID_INFO_TRACK_CODE", e.RowIndex].Value;
                        var raceNumber = (string) _grid["ID_INFO_RACE_NUMBER", e.RowIndex].Value;
                        int year = Convert.ToInt32(date.Substring(0, 4));
                        int month = Convert.ToInt32(date.Substring(4, 2));
                        int day = Convert.ToInt32(date.Substring(6, 2));
                        int raceid = GetRaceIdFromDb(trackCode, year, month, day, Convert.ToInt32(raceNumber));
                        if (raceid > 0)
                        {
                            var f = new RaceChartForm(raceid);
                            f.ShowDialog();
                        }
                        else
                        {
                            BrisPastPerformance pp = _myHorse.CorrespondingBrisHorse.PastPerformances[e.RowIndex];
                            var f = new FirstSecondAndThridInfoForm(pp);
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
        private void PaintGoldenTrackVariantCell(int rowIndex, string columnName)
        {
            int goldenTrackVariant = 0;

            int.TryParse(_grid[columnName, rowIndex].Value.ToString(), out goldenTrackVariant);

            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if (goldenTrackVariant != -999)
            {
                backColor = Color.Gold;
                foreColor = Color.Navy;
            }

            _grid[columnName, rowIndex].Style.BackColor = backColor;
            _grid[columnName, rowIndex].Style.ForeColor = foreColor;

            _grid[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _grid[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _grid[columnName, rowIndex].Style.Font = _boldFont;
            _grid[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void PaintGoldenPaceFigureCell(int rowIndex, string columnName)
        {
            int goldenFigure = 0;

            int.TryParse(_grid[columnName, rowIndex].Value.ToString(), out goldenFigure);

            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if (goldenFigure != -999)
            {
                backColor = Color.DarkTurquoise;
                foreColor = Color.White;
            }

            _grid[columnName, rowIndex].Style.BackColor = backColor;
            _grid[columnName, rowIndex].Style.ForeColor = foreColor;

            _grid[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _grid[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _grid[columnName, rowIndex].Style.Font = _boldFont;
            _grid[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        */
        private void PaintBrisSpeedFigureCell(int rowIndex, string columnName)
        {

            Color backColor = Color.Olive;
            Color foreColor = Color.Wheat;

            
           

            _grid[columnName, rowIndex].Style.BackColor = backColor;
            _grid[columnName, rowIndex].Style.ForeColor = foreColor;

            _grid[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _grid[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _grid[columnName, rowIndex].Style.Font = _boldFont;
            _grid[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void PaintGoldenFigureCell(int rowIndex, string columnName)
        {
            int goldenFigure = 0;

            int.TryParse(_grid[columnName, rowIndex].Value.ToString(), out goldenFigure);

            Color backColor = Color.Gray;
            Color foreColor = Color.Gray;

            if (goldenFigure != -999)
            {
                backColor = Color.Black;
                foreColor = Color.White;
            }

            _grid[columnName, rowIndex].Style.BackColor = backColor;
            _grid[columnName, rowIndex].Style.ForeColor = foreColor;

            _grid[columnName, rowIndex].Style.SelectionBackColor = backColor;
            _grid[columnName, rowIndex].Style.SelectionForeColor = foreColor;

            _grid[columnName, rowIndex].Style.Font = _boldFont;
            _grid[columnName, rowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private Color GetColorForCallPosition(int rowIndex, string columnName)
        {
            try
            {
                int pos = Convert.ToInt32(_grid[columnName, rowIndex].Value.ToString().Trim());

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

        private void SetCellStyleToHyperlink(string columnName, int rowIndex)
        {
            _grid[columnName, rowIndex].Style.Font = _hyperlinkFont;
            _grid[columnName, rowIndex].Style.BackColor = Color.White;
            _grid[columnName, rowIndex].Style.ForeColor = Color.Blue;
            _grid[columnName, rowIndex].Style.SelectionForeColor = _grid[columnName, rowIndex].Style.ForeColor;
            _grid[columnName, rowIndex].Style.SelectionBackColor = _grid[columnName, rowIndex].Style.BackColor;
        }

        private void SetCellStyleToDisabled(string columnName, int rowIndex)
        {
            _grid[columnName, rowIndex].Style.Font = _grid.DefaultCellStyle.Font;
            _grid[columnName, rowIndex].Style.BackColor = Color.Gray;
            _grid[columnName, rowIndex].Style.ForeColor = Color.Black;
            _grid[columnName, rowIndex].Style.SelectionForeColor = _grid[columnName, rowIndex].Style.ForeColor;
            _grid[columnName, rowIndex].Style.SelectionBackColor = _grid[columnName, rowIndex].Style.BackColor;
        }

        private void OnGridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                PaintSelectedRunningLineCell(e.RowIndex);
                int row = e.RowIndex;
                var daysSinceLast = (int) _grid.Rows[row].Cells["NumberOfDaysSinceLastRace"].Value;
                _grid.Rows[row].DefaultCellStyle.Font = daysSinceLast >= Utilities.LAYOFF_DAYS ? _underlinedFont : _grid.DefaultCellStyle.Font;

                _grid["FirstCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FirstCallPosition");
                _grid["SecondCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "SecondCallPosition");
                _grid["StretchCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "StretchCallPosition");
                _grid["FinalCallPosition", e.RowIndex].Style.BackColor = GetColorForCallPosition(e.RowIndex, "FinalCallPosition");

                //PaintGoldenTrackVariantCell(e.RowIndex, "GoldenTrackVariant");
                //PaintGoldenPaceFigureCell(e.RowIndex, "GoldenPaceFigureForThisHorse");
                //PaintGoldenPaceFigureCell(e.RowIndex, "GoldenPaceFigure");
                //PaintGoldenFigureCell(e.RowIndex, "GoldenFigure");
                //PaintGoldenFigureCell(e.RowIndex, "GoldenFigureForWinnerOfRace");

                PaintBrisSpeedFigureCell(e.RowIndex, "BrisSpeedRating");


                Color distanceColor = Color.LightCyan;

                _grid["FirstCallDistanceFromLeader", e.RowIndex].Style.BackColor = distanceColor;
                _grid["SecondCallDistanceFromLeader", e.RowIndex].Style.BackColor = distanceColor;
                _grid["StretchCallDistanceFromLeader", e.RowIndex].Style.BackColor = distanceColor;
                _grid["FinalCallDistanceFromLeader", e.RowIndex].Style.BackColor = distanceColor;
                _grid["PostPosition", e.RowIndex].Style.BackColor = Color.LightSalmon;

                if (null != _grid["Surface", e.RowIndex].Value)
                {
                    var surface = (string) _grid["Surface", e.RowIndex].Value;
                    _grid["Surface", e.RowIndex].Style.BackColor = surface.IndexOf('T') != -1 ? Color.LightGreen : Color.White;
                }

                _grid["TrackVariant", e.RowIndex].Style.Font = _boldFont;
                _grid["TrackVariant", e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (null != _topSpotFinishersWhoHaveDbEntries)
                {
                    if (_topSpotFinishersWhoHaveDbEntries.Contains(_grid["WinnersName", e.RowIndex].Value.ToString().ToUpper()))
                    {
                        SetCellStyleToHyperlink("WinnersName", e.RowIndex);
                    }
                    else
                    {
                        SetCellStyleToDisabled("WinnersName", e.RowIndex);
                    }

                    if (_topSpotFinishersWhoHaveDbEntries.Contains(_grid["SecondHorseName", e.RowIndex].Value.ToString().ToUpper()))
                    {
                        SetCellStyleToHyperlink("SecondHorseName", e.RowIndex);
                    }
                    else
                    {
                        SetCellStyleToDisabled("SecondHorseName", e.RowIndex);
                    }

                    if (_topSpotFinishersWhoHaveDbEntries.Contains(_grid["ThirdHorseName", e.RowIndex].Value.ToString().ToUpper()))
                    {
                        SetCellStyleToHyperlink("ThirdHorseName", e.RowIndex);
                    }
                    else
                    {
                        SetCellStyleToDisabled("ThirdHorseName", e.RowIndex);
                    }
                }

                // SetCellStyleToHyperlink("Race Class", e.RowIndex);
                //SetCellStyleToHyperlink("TrackVariant", e.RowIndex);

                foreach (DataGridViewCell cell in _grid.Rows[e.RowIndex].Cells)
                {
                    cell.Style.SelectionBackColor = cell.Style.BackColor;
                    cell.Style.SelectionForeColor = cell.Style.ForeColor;
                }
            }
        }

        private void OnRadioButtonWinnerCheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                return;
            }

            var rb = sender as RadioButton;
            if (null != rb && false == rb.Checked)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;

            if (sender == _radioButtonThis)
            {
                _timingType = BrisHorse.TimingType.ThisHorse;
            }
            else if (sender == _radioButtonWinner)
            {
                _timingType = BrisHorse.TimingType.LeadersHorse;
            }
            else if (sender == _radioButtonWinner)
            {
                _timingType = BrisHorse.TimingType.LeadersHorse;
            }
            else if (sender == _radioButtonFigures)
            {
                _timingType = BrisHorse.TimingType.PaceFigures;
            }
            else
            {
                return;
            }

            UpdateGrid();

            Cursor = Cursors.Default;
        }

        private string GetRaceReplaysUrl(string trackCdode, DateTime date, int raceNumber)
        {
            trackCdode = trackCdode.Trim();
            if (trackCdode.Length == 2)
            {
                trackCdode += "9";
            }

            string key = string.Format("{0}{1:00}{2:00}{3:00}A{4:00}", trackCdode, date.Month, date.Day, date.Year - 2000, raceNumber);
            return string.Format("http://www.racereplays.com/racereplays/replay_embeded.cfm?raceid=T{0}pf", key);
        }

        private void OnCopyRaceReplaysLinkToClipboard(object sender, EventArgs e)
        {
            try
            {
                var pp = (BrisPastPerformance) ((ToolStripItem) sender).Tag;
                string url = GetRaceReplaysUrl(pp.TrackCode, pp.Date, int.Parse(pp.RaceNumber));

                Clipboard.SetText(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowPaceFigures(object sender, EventArgs e)
        {
            try
            {
                var pp = (BrisPastPerformance) ((ToolStripItem) sender).Tag;

                int raceNumber;
                int.TryParse(pp.RaceNumber, out raceNumber);

                string date = string.Format("{0:0000}{1:00}{2:00}", pp.Date.Year, pp.Date.Month, pp.Date.Day);

                var f = new PaceFiguresForm(pp.TrackCode, pp.DistanceInYards, pp.Surface, date, pp.AboutDistanceFlag ? "A" : "", raceNumber);

                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowAllRacesForTheDay(object sender, EventArgs e)
        {
            try
            {
                var pp = (BrisPastPerformance) ((ToolStripItem) sender).Tag;
                ShowFractionsForTheDayForm.DisplayModal(pp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                if (e.Button == MouseButtons.Right)
                {
                    Rectangle r = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    _popupmenu.Items.Clear();
                    ToolStripItem item = _popupmenu.Items.Add("Show All Races For The Day", null, OnShowAllRacesForTheDay);
                    ToolStripItem item2 = _popupmenu.Items.Add("Copy Race Replays Link To Clipboard", null, OnCopyRaceReplaysLinkToClipboard);
                    ToolStripItem item3 = _popupmenu.Items.Add("Show Pace Figures", null, OnShowPaceFigures);

                    item.Tag = _grid["ID_PP_OBJECT", e.RowIndex].Value;
                    item2.Tag = _grid["ID_PP_OBJECT", e.RowIndex].Value;
                    item3.Tag = _grid["ID_PP_OBJECT", e.RowIndex].Value;

                    _popupmenu.Show((Control) sender, r.Left + e.X, r.Top + e.Y);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    int winnersNameColIndex = _grid.Columns["WinnersName"].Index;
                    int secondNameColIndex = _grid.Columns["SecondHorseName"].Index;
                    int thirdNameColIndex = _grid.Columns["ThirdHorseName"].Index;
                    int conditionColIndex = _grid.Columns["Race Class"].Index;
                    int jockeyColIndex = _grid.Columns["Jockey"].Index;

                    if (0 == e.ColumnIndex)
                    {
                        var pp = (BrisPastPerformance) _grid.Rows[e.RowIndex].Cells["ID_PP_OBJECT"].Value;
                        pp.Parent.CorrespondingHorse.SelectedRunningLine = pp;
                        for (int i = 0; i < _grid.Rows.Count; ++i)
                        {
                            PaintSelectedRunningLineCell(i);
                        }
                    }
                    else if (e.ColumnIndex == winnersNameColIndex ||
                             e.ColumnIndex == secondNameColIndex ||
                             e.ColumnIndex == thirdNameColIndex)
                    {
                        string horseName = _grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        var f = new ShowRacesByHorseForm(horseName);
                        f.ShowDialog();
                    }
                    else if (e.ColumnIndex == conditionColIndex)
                    {
                        var pp = (BrisPastPerformance) _grid.Rows[e.RowIndex].Cells["ID_PP_OBJECT"].Value;
                        _shortRaceChartControl.Bind(pp);

                        int raceNumber;
                        if (int.TryParse(pp.RaceNumber, out raceNumber))
                        {
                            _xRayCtrl.Bind(pp.Date, pp.TrackCode, pp.Parent.Name, raceNumber);
                        }
                        else
                        {
                            _xRayCtrl.Clear();
                        }
                    }
                    else if (e.ColumnIndex == jockeyColIndex)
                    {
                        var pp = (BrisPastPerformance) _grid.Rows[e.RowIndex].Cells["ID_PP_OBJECT"].Value;
                        var jsf = new JockeyStatisticsForm(pp.Jockey);
                        jsf.ShowDialog();
                    }
                    else if (e.ColumnIndex == _grid.Columns["PostPosition"].Index)
                    {
                        var ctrl = sender as Control;

                        var pp = (BrisPastPerformance) _grid.Rows[e.RowIndex].Cells["ID_PP_OBJECT"].Value;
                        string trackCode = pp.TrackCode;
                        string surface = pp.Surface.ToUpper();

                        if (surface == "ID")
                        {
                            surface = "d";
                        }

                        if (surface == "IT")
                        {
                            surface = "t";
                        }

                        int distance = pp.DistanceInYards;
                        string distanceFlag = pp.AboutDistanceFlag ? "A" : "";
                        var postPositionPopUp = new PostPositionStatsForm(trackCode, surface, distanceFlag, distance);
                        postPositionPopUp.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowPostPositionBehavior(object sender, EventArgs e)
        {
            try
            {
                string trackCode = _myHorse.Parent.Parent.TrackCode;
                string surface = _myHorse.CorrespondingBrisHorse.TodaysSurface;
                int distance = _myHorse.CorrespondingBrisHorse.DistanceInYards;
                string distanceFlag = _myHorse.CorrespondingBrisHorse.TodaysDistanceFlag;
                var postPositionPopUp = new PostPositionStatsForm(trackCode, surface, distanceFlag, distance);
                postPositionPopUp.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _txtboxJockeyName_TextChanged(object sender, EventArgs e)
        {
        }

        private void _txtboxOdds_TextChanged(object sender, EventArgs e)
        {
        }

        private void OnOddsClicked(object sender, EventArgs e)
        {
            try
            {
                var f = new ShowVotesForAllOddsCategoriesForm(_myHorse);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowTimeGraps(object sender, EventArgs e)
        {
            try
            {
                var f = new ShowAllTimeGraphsForm(_myHorse);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _txtboxTrainerInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

