using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.WinnersForDay
{
    public partial class ShowFractionsForTheDayForm : Form
    {
        private const string _sqlLoadRacesForDistanceAndTrack = @"exec GetRacesPerTrackAndDistance '{0}', {1}, '{2}','{3}', '{4}','{5}' ";

        private readonly BrisPastPerformance _pp;

        private int _winnersNameColumnIndex = -1;
        private int _distanceColumnIndex = -1;
        private int _aboutColumnIndex = -1;
        private int _surfaceColumnIndex = -1;

        private readonly DateTime _date;
        private readonly string _trackCode;
        private readonly string _horseName;
        private readonly int _raceNumber;

        private List<WinnerInfo> _winners = new List<WinnerInfo>();
        private DateTime _defaultFromDate, _defaultToDate, _maxAvailableDate, _minAvailableDate;

        private bool _skipLoading = false;

        private RaceInfo _currentRaceInfo;

        private DataBaseCollection<RaceResults> _results;

        public static void DisplayModal(DateTime date, string trackCode, string horseName, int raceNumber)
        {
            if (!DateOfRace.RaceExistsInDb(trackCode, date, raceNumber))
            {
                MessageBox.Show("Sorry, race does not exist in the data base!");
            }
            else
            {
                var form = new ShowFractionsForTheDayForm(date, trackCode, horseName, raceNumber, null);
                form.ShowDialog();
            }
        }

        public static void DisplayModal(BrisPastPerformance pp)
        {
            DateTime date = pp.Date;
            string trackCode = pp.TrackCode;
            string horseName = pp.Parent.Name;
            int raceNumber = Convert.ToInt32(pp.RaceNumber);
            if (!DateOfRace.RaceExistsInDb(trackCode, date, raceNumber))
            {
                string caption = string.Format("{0}, {1}", trackCode, Utilities.GetFullDateString(Utilities.GetDateInYYYYMMDD(date)));
                MessageBox.Show("Sorry, race does not exist in the data base!", caption);
            }
            else
            {
                var form = new ShowFractionsForTheDayForm(date, trackCode, horseName, raceNumber, pp);
                form.ShowDialog();
            }
        }

        private ShowFractionsForTheDayForm(DateTime date, string trackCode, string horseName, int raceNumber, BrisPastPerformance pp)
        {
            _pp = pp;
            _date = date;
            _trackCode = trackCode;
            _horseName = horseName;
            _raceNumber = raceNumber;

            InitializeComponent();
        }

        private void InitializePeriod()
        {
            var ts = new TimeSpan(10, 0, 0, 0);
            var dates = DateOfRace.GetDates(_trackCode);
            DateTime fromDate = _date - ts;
            DateTime toDate = _date + ts;

            _skipLoading = true;
            _periodSelector.Period = dates;
            _periodSelector.FromDate = fromDate;
            _periodSelector.ToDate = toDate;

            _defaultFromDate = fromDate;
            _defaultToDate = toDate;

            _maxAvailableDate = dates.Max();
            _minAvailableDate = dates.Min();
            _skipLoading = false;
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            InitializePeriod();
            string date = string.Format("{0}{1:00}{2:00}", _date.Year, _date.Month, _date.Day);

            _labelCardInfo.Text = string.Format("{0}    {1}, Horse Name: {2}", RaceTracks.GetNameFromTrackCode(_trackCode), string.Format("{0:MM/dd/yyyy}", _date), _horseName);

            string sql = string.Format(@"SELECT 
	                                            a.RACE_NUMBER, 
	                                            DISTANCE, 
	                                            SURFACE, 
                                                ABOUT_DISTANCE_FLAG,
	                                            TRACK_CONDITION , 
	                                            ABBR_RACE_CLASS, 
                                                HORSE_NAME,
	                                            TIME_FOR_FRACTION_1, 
	                                            TIME_FOR_FRACTION_2, 
                                                TIME_FOR_FRACTION_3, 
	                                            TIME_FOR_FRACTION_4, 
	                                            FINAL_TIME,
                                                a.RACE_ID,
                                                STATE_BRED_FLAG,
                                                AGE_SEX_RESTRICTIONS,
                                                RACE_GRADE  
                                            FROM 
	                                            RACE_DESCRIPTION a,
	                                            RACE_STARTERS b 
                                            
                                            WHERE 
	                                            a.RACE_ID = b.RACE_ID
	                                            AND DATE_OF_THE_RACE = '{0}' AND a.TRACK_CODE = '{1}'
                                                AND b.FINISH_POSITION = 1
                                            ORDER BY 
                                                DISTANCE, 
                                                SURFACE,
                                                ABOUT_DISTANCE_FLAG , 
                                                FINAL_TIME",
                                       date, _trackCode);

            _grid.Columns.Clear();
            _grid.Columns.Add("NUM", "NUM");
            _grid.Columns.Add("DIST", "DIST");
            _grid.Columns.Add("SURF", "SURF");
            _grid.Columns.Add("ABT", "ABT");
            _grid.Columns.Add("CNDT", "CNDT");
            _grid.Columns.Add("CLASS", "CLASS");
            _grid.Columns.Add("WINNER", "WINNER");
            _grid.Columns.Add("F1", "F1");
            _grid.Columns.Add("F2", "F2");
            _grid.Columns.Add("F3", "F3");
            _grid.Columns.Add("F4", "F4");
            _grid.Columns.Add("FINAL", "FINAL");

            var hyperlinkFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);
            Color hyperlinkColor = Color.Blue;
            RaceInfo currentRaceInfo = null;
            SqlDataReader myReader = null;
            try
            {
                var myCommand = new SqlCommand(sql, DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        DataGridViewRow row = _grid.Rows[_grid.Rows.Add()];

                        var raceNumber = (int) myReader["RACE_NUMBER"];
                        var distanceInYeards = (int) ((double) myReader["DISTANCE"]);
                        var surface = myReader["SURFACE"].ToString().Trim();
                        var aboutFlag = myReader["ABOUT_DISTANCE_FLAG"].ToString().Trim();
                        var trackCondition = myReader["TRACK_CONDITION"].ToString().Trim();
                        var abbrRaceClass = myReader["ABBR_RACE_CLASS"].ToString().Trim();
                        var horseName = myReader["HORSE_NAME"].ToString().Trim();
                        var fraction1 = (double) myReader["TIME_FOR_FRACTION_1"];
                        var fraction2 = (double) myReader["TIME_FOR_FRACTION_2"];
                        var fraction3 = (double) myReader["TIME_FOR_FRACTION_3"];
                        var fraction4 = (double) myReader["TIME_FOR_FRACTION_4"];
                        var finalTime = (double) myReader["FINAL_TIME"];
                        var raceid = (int) myReader["RACE_ID"];
                        var stateBredFlag = myReader["STATE_BRED_FLAG"].ToString().Trim();
                        var ageSexRestrictions = myReader["AGE_SEX_RESTRICTIONS"].ToString().Trim();
                        var raceGrade = (int) myReader["RACE_GRADE"];

                        row.Cells[0].Value = raceNumber;
                        row.Cells[1].Value = Utilities.ConvertYardsToMilesOrFurlongs(distanceInYeards);

                        _distanceColumnIndex = 1;
                        row.Cells[_distanceColumnIndex].Style.Font = hyperlinkFont;
                        row.Cells[_distanceColumnIndex].Style.ForeColor = hyperlinkColor;

                        _surfaceColumnIndex = 2;
                        row.Cells[2].Value = surface;
                        row.Cells[3].Value = aboutFlag;

                        _aboutColumnIndex = 3;

                        row.Cells[4].Value = trackCondition;

                        row.Cells[5].Value = Utilities.MakeRaceCondition(stateBredFlag, ageSexRestrictions, abbrRaceClass, raceGrade, "");
                        row.Cells[6].Value = horseName;
                        _winnersNameColumnIndex = 6;

                        row.Cells[_winnersNameColumnIndex].Style.Font = hyperlinkFont;
                        row.Cells[_winnersNameColumnIndex].Style.ForeColor = hyperlinkColor;

                        row.Cells[7].Value = Utilities.ConvertTimeToMMSSFifth(fraction1);
                        row.Cells[8].Value = Utilities.ConvertTimeToMMSSFifth(fraction2);
                        row.Cells[9].Value = Utilities.ConvertTimeToMMSSFifth(fraction3);
                        row.Cells[10].Value = Utilities.ConvertTimeToMMSSFifth(fraction4);
                        row.Cells[11].Value = Utilities.ConvertTimeToMMSSFifth(finalTime);

                        row.Tag = new RaceInfo
                                      {
                                          RaceId = raceid,
                                          Distance = myReader.GetDouble(_distanceColumnIndex),
                                          AboutFlag = myReader.GetString(_aboutColumnIndex),
                                          Surface = myReader.GetString(_surfaceColumnIndex),
                                          TrackCode = _trackCode
                                      };

                        if (surface.ToUpper().Contains("T"))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }

                        if (raceNumber == _raceNumber)
                        {
                            row.DefaultCellStyle.Font = new Font(_grid.DefaultCellStyle.Font, FontStyle.Bold);
                            currentRaceInfo = (RaceInfo) row.Tag;
                        }
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }

            try
            {
                SetCurrentRaceInfo(currentRaceInfo);
                LoadAllRacesForTheDistance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetCurrentRaceInfo(RaceInfo ri)
        {
            _winners = null;
            _currentRaceInfo = ri;
            LoadWinners();
        }

        private void LoadWinners()
        {
            _winners = null;

            if (null != _currentRaceInfo)
            {
                _winners = WinnerInfo.LoadFromDb(_currentRaceInfo.TrackCode,
                                                 _currentRaceInfo.Distance,
                                                 _currentRaceInfo.Surface,
                                                 _currentRaceInfo.AboutFlag);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (_winnersNameColumnIndex == e.ColumnIndex)
                    {
                        var ri = (RaceInfo) _grid.Rows[e.RowIndex].Tag;
                        int raceid = ri.RaceId;

                        var f = new RaceChartForm(raceid);
                        f.ShowDialog();
                    }
                    else if (_distanceColumnIndex == e.ColumnIndex)
                    {
                        SetCurrentRaceInfo((RaceInfo) _grid.Rows[e.RowIndex].Tag);
                        LoadAllRacesForTheDistance();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Dictionary<int, List<string>> LoadHorsesFromTodaysRaceWhoRanInThisPeriod()
        {
            if (null == _pp)
            {
                return null;
            }

            Race race = _pp.Parent.Parent.CorrespondingRace;
            var sb = new StringBuilder();
            bool needsComma = false;
            foreach (Horse horse in race.Horses)
            {
                if (false == horse.Scratched)
                {
                    if (needsComma)
                    {
                        sb.Append(",");
                    }
                    else
                    {
                        needsComma = true;
                    }

                    sb.Append(string.Format("'{0}'", horse.Name));
                }
            }

            string fromDate = string.Format("{0}{1:00}{2:00}", _periodSelector.FromDate.Year, _periodSelector.FromDate.Month, _periodSelector.FromDate.Day);
            string toDate = string.Format("{0}{1:00}{2:00}", _periodSelector.ToDate.Year, _periodSelector.ToDate.Month, _periodSelector.ToDate.Day);

            string sql = @"SELECT RACE_ID, HORSE_NAME FROM RACE_STARTERS
                            WHERE RACE_ID IN
                            (
                                SELECT RACE_ID FROM RACE_DESCRIPTION
                                WHERE 
	                                TRACK_CODE = '{0}' AND
	                                DISTANCE  = {1} AND 
	                                SURFACE  = '{2}' AND 
	                                ABOUT_DISTANCE_FLAG = '{3}' AND 
	                                DATE_OF_THE_RACE >= '{4}' AND 
	                                DATE_OF_THE_RACE <= '{5}'
                            )
                            AND HORSE_NAME IN ({6}) AND PROGRAM_NUMBER != 'SCR'";

            sql = string.Format(sql, _currentRaceInfo.TrackCode,
                                _currentRaceInfo.Distance,
                                _currentRaceInfo.Surface,
                                _currentRaceInfo.AboutFlag,
                                fromDate,
                                toDate,
                                sb);

            var temp = new Dictionary<int, List<string>>();

            SqlDataReader myReader = null;
            try
            {
                var myCommand = new SqlCommand(sql, DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string horseName = myReader["HORSE_NAME"].ToString().Trim();
                        var raceId = (int) myReader["RACE_ID"];

                        if (!temp.ContainsKey(raceId))
                        {
                            temp.Add(raceId, new List<string>());
                        }
                        temp[raceId].Add(horseName);
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }

            return temp;
        }

        private void LoadAllRacesForTheDistance()
        {
            if (_skipLoading)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                
                if (null == _currentRaceInfo)
                    return;

                _gridShowAllRacesForTheDistance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
               
                DateTime fd = _periodSelector.FromDate;
                DateTime td = _periodSelector.ToDate;
                
                string fromDate = string.Format("{0}{1:00}{2:00}", fd.Year, fd.Month, fd.Day);
                string toDate = string.Format("{0}{1:00}{2:00}", td.Year, td.Month, td.Day);
                string surf = _currentRaceInfo.Surface;
                string trackCode = _currentRaceInfo.TrackCode;
                string aboutFlag = _currentRaceInfo.AboutFlag.Trim();
                
                _tbDistance.Text = Utilities.ConvertYardsToMilesOrFurlongs((int) _currentRaceInfo.Distance);

                if (aboutFlag.Contains("A"))
                {
                    _tbDistance.Text = new string('*', 1) + _tbDistance.Text;
                }

                _tbSurface.Text = surf;
                var collection = new DataBaseCollection<RaceResults>();
                
                string sqlLoader = string.Format(_sqlLoadRacesForDistanceAndTrack, trackCode, _currentRaceInfo.Distance, surf, aboutFlag, fromDate, toDate);
                collection.Load(sqlLoader);
                
                
                RaceResults.InitializeGrid(_gridShowAllRacesForTheDistance, collection.Count);
                WinnerInfo thisRaceInfo = null;
                int rowIndex = 0;
                collection.ForEach(rr => rr.AddToGrid(_gridShowAllRacesForTheDistance, _currentRaceInfo.RaceId, rowIndex++));
                _gridShowAllRacesForTheDistance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _tbNumberOfRaces.Text = collection.Count.ToString();

            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadAllRacesForTheDistanceold()
        {
            /*
            Cursor = Cursors.WaitCursor;
            try
            {
                DataGridView g = _gridShowAllRacesForTheDistance;
                g.Columns.Clear();

                if (null == _winners || _winners.Count <= 0 || null == _currentRaceInfo)
                {
                    return;
                }

                Dictionary<int, List<string>> runTogether = LoadHorsesFromTodaysRaceWhoRanInThisPeriod();
                DateTime fd = _periodSelector.FromDate;
                DateTime td = _periodSelector.ToDate;
                string fromDate = string.Format("{0}{1:00}{2:00}", fd.Year, fd.Month, fd.Day);
                string toDate = string.Format("{0}{1:00}{2:00}", td.Year, td.Month, td.Day);

                _tbAboutFlag.Text = _currentRaceInfo.AboutFlag;
                _tbDistance.Text = Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int) _currentRaceInfo.Distance);
                _tbSurface.Text = _currentRaceInfo.Surface;



                string surf = _currentRaceInfo.Surface.ToUpper().Contains("T") ? "T" : "D";

                List<AverageTimeAndPurse> avgTimeAndPurse = LoadAverageTimeAndPurse(surf, _currentRaceInfo.TrackCode, fromDate, toDate);
              
                if(avgTimeAndPurse.Count<=0)
                {
                    return;
                }
                double minTime = avgTimeAndPurse.Min(a => a.AvgTime);

                int dateRowIndex = g.Columns.Add("DATE", "DATE");
                int cRowIndex = g.Columns.Add("C", "C");
                int classRowIndex = g.Columns.Add("CLASS", "CLASS");
                int winnerRowIndex = g.Columns.Add("WINNER", "WINNER");
                int f1RowIndex = g.Columns.Add("F1", "F1");
                int f2RowIndex = g.Columns.Add("F2", "F2");
                int f3RowIndex = g.Columns.Add("F3", "F3");
                int finalRowIndex = g.Columns.Add("FINAL", "FINAL");
                g.Columns.Add("VAR", "VAR");
                g.Columns.Add("PURSE", "AVGPURSE");
                g.DefaultCellStyle.SelectionBackColor = g.DefaultCellStyle.BackColor;
                g.DefaultCellStyle.SelectionForeColor = g.DefaultCellStyle.ForeColor;

                IEnumerable<WinnerInfo> wilist = _winners.FindAll(w => w.Date >= fd && w.Date <= td);

                if(wilist.Count()<=0)
                {
                    string msg = "Something is wrong!\n The list for the winners for the distance and track is empty!\nCheck to see if the CONTAINS_VALID_TIME_FLAG is set correctly";
                    throw new Exception(msg); 
                }

                WinnerInfo thisRaceInfo = null;
                g.Rows.Add(wilist.Count());
                int rowCounter = 0;

                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (var wi in wilist)
                {
                    DataGridViewRow row = g.Rows[rowCounter++];
                    row.Cells[dateRowIndex].Value = Utilities.GetDateInYYYYMMDD(wi.Date);
                    row.Cells[cRowIndex].Value = wi.TrackCondition;
                    var abbrRaceClass = wi.AbbrRaceClass;
                    var stateBredFlag = wi.StateBredFlag;
                    var ageSexRestrictions = wi.AgeSexRestrictions;
                    var raceGrade = wi.RaceGrade;
                    row.Cells[classRowIndex].Value = Utilities.MakeRaceCondition(stateBredFlag, ageSexRestrictions, abbrRaceClass, raceGrade, "");
                    row.Cells[winnerRowIndex].Value = wi.HorseName;
                    row.Cells[f1RowIndex].Value = Utilities.ConvertTimeToMMSSFifth(wi.FirstFraction());
                    row.Cells[f2RowIndex].Value = Utilities.ConvertTimeToMMSSFifth(wi.SecondFraction());
                    row.Cells[f3RowIndex].Value = Utilities.ConvertTimeToMMSSFifth(wi.ThirdFraction());
                    row.Cells[finalRowIndex].Value = Utilities.ConvertTimeToMMSSFifth(wi.FinalTime());

                    AverageTimeAndPurse atp = avgTimeAndPurse.Find(a => a.Date == Utilities.GetDateInYYYYMMDD(wi.Date));
                    if (null != atp)
                    {
                        row.Cells["VAR"].Value = string.Format("{0:0}", (atp.AvgTime - minTime)*5);
                        row.Cells["PURSE"].Value = string.Format("{0:c}", atp.AvgPurse);
                        row.Cells["PURSE"].Tag = atp.AvgPurse;
                    }
                    else
                    {
                        row.Cells["VAR"].Value = "N/A";
                        row.Cells["PURSE"].Value = "N/A";
                        row.Cells["PURSE"].Tag = 0;
                    }

                    var raceid = wi.RaceId;

                    if (raceid == _currentRaceInfo.RaceId)
                    {
                        thisRaceInfo = wi;
                        row.DefaultCellStyle.Font = new Font(_grid.DefaultCellStyle.Font, FontStyle.Bold);
                    }

                    row.Tag = raceid;

                    List<string> r = null;
                    if (null != runTogether && runTogether.ContainsKey(raceid))
                    {
                        r = runTogether[raceid];
                    }
                    row.Tag = new RaceInfo
                                  {
                                      RaceId = raceid,
                                      MatchingHorsesFromTodaysRace = r
                                  };

                    if (r != null)
                    {
                        row.Cells["CLASS"].Style.BackColor = Color.Red;
                        row.Cells["CLASS"].Style.SelectionBackColor = Color.Red;
                    }
                }
                _labelCount.Text = wilist.Count().ToString();
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;

                var ft = wilist.Cast<IFractionalTimes>().ToList();
                _timeComparisonCtrl.Bind(ft, thisRaceInfo, _currentRaceInfo.RaceId, _horseName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
             */
        }

        private void OnGridShowAllRacesForTheDistanceCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int raceid = ((RaceInfo) _gridShowAllRacesForTheDistance.Rows[e.RowIndex].Tag).RaceId;
                    var f = new RaceChartForm(raceid);
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnMouseEnteredInAHorseNameCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                var ri = (RaceInfo) _gridShowAllRacesForTheDistance.Rows[e.RowIndex].Tag;
                if (null != ri.MatchingHorsesFromTodaysRace)
                {
                    string txt = ri.MatchingHorsesFromTodaysRace.Aggregate("", (current, s) => current + (s + Environment.NewLine));

                    //_gridShowAllRacesForTheDistance[e.ColumnIndex, e.RowIndex].ToolTipText = txt;
                    _toolTip.Show(txt, _gridShowAllRacesForTheDistance, 1000);
                }
            }
        }

        private void OnSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name.CompareTo("PURSE") == 0)
            {
                var g = sender as DataGridView;
                if (null != g)
                {
                    var n1 = (double) g[e.Column.Index, e.RowIndex1].Tag;
                    var n2 = (double) g[e.Column.Index, e.RowIndex2].Tag;

                    if (n1 > n2)
                    {
                        e.SortResult = 1;
                    }
                    else if (n1 < n2)
                    {
                        e.SortResult = -1;
                    }
                    else
                    {
                        e.SortResult = 0;
                    }

                    e.Handled = true;
                }
            }
        }

        private void OnPeriodChanged(object sender, EventArgs e)
        {
            LoadAllRacesForTheDistance();
        }

        private void OnSelectDefaultPeriodOnly(object sender, EventArgs e)
        {
            _skipLoading = true;
            _periodSelector.FromDate = _defaultFromDate;
            _periodSelector.ToDate = _defaultToDate;
            _skipLoading = false;
            LoadAllRacesForTheDistance();
        }

        private void OnSelectAllAlAvailableRaces(object sender, EventArgs e)
        {
            _skipLoading = true;
            _periodSelector.FromDate = _minAvailableDate;
            _periodSelector.ToDate = _maxAvailableDate;
            _skipLoading = false;
            LoadAllRacesForTheDistance();
        }
    }

    internal class RaceResults : IDbPopulatable
    {
        public int RaceID { get; private set; }
        public string TrackCode { get; private set; }
        public string Date { get; private set; }
        public string TrackCondition { get; private set; }
        public string RaceCondition { get; private set; }
        public string HorseName { get; private set; }
        public string Fraction1 { get; private set; }
        public string Fraction2 { get; private set; }
        public string Fraction3 { get; private set; }
        public string FinalTime { get; private set; }

        public static void InitializeGrid(DataGridView grid, int numberOfRows)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();

            grid.Columns.Add("tr", "tr");
            grid.Columns.Add("date", "date");
            grid.Columns.Add("Cond", "Cond");
            grid.Columns.Add("Class", "Class");
            grid.Columns.Add("Horse", "Horse");
            grid.Columns.Add("F1", "F1");
            grid.Columns.Add("F2", "F2");
            grid.Columns.Add("F3", "F3");
            grid.Columns.Add("Final", "Final");

            if(numberOfRows > 0)
                grid.Rows.Add(numberOfRows);
        }

        public void AddToGrid(DataGridView grid, int selectedRaceId, int rowIndex)
        {
            var cells = grid.Rows[rowIndex].Cells;

            cells[0].Value = TrackCode;
            cells[1].Value = Date;
            cells[2].Value = TrackCondition;
            cells[3].Value = RaceCondition;
            cells[4].Value = HorseName;
            cells[5].Value = Fraction1;
            cells[6].Value = Fraction2;
            cells[7].Value = Fraction3;
            cells[8].Value = FinalTime;

            if (RaceID == selectedRaceId)
            {
                grid.Rows[rowIndex].DefaultCellStyle.Font = new Font(grid.DefaultCellStyle.Font, FontStyle.Bold);
            }
        }

        public void Populate(DbReader dbr)
        {
            RaceID = dbr.GetValue<int>("race_id");
            TrackCode = dbr.GetValue<string>("track_code");
            Date = dbr.GetValue<string>("RACING_DATE");
            TrackCondition = dbr.GetValue<string>("track_condition");
            HorseName = dbr.GetValue<string>("horse_name");
            var condition = dbr.GetValue<string>("abbr_race_class");
            condition = condition.Replace("clm", "CLM").Replace("alw", "ALW").Replace("hcp", "HCP").Replace("Mcl", "MCL").Replace("Msw", "MSW").Replace("oc", "OC");
            bool stateBredFlag = dbr.GetValue<string>("state_bred_flag").Contains("S");
            if (stateBredFlag)
            {
                condition = "S" + condition;
            }
            RaceCondition = Utilities.FormatCondition(condition, stateBredFlag, dbr.GetValue<string>("age_sex_restrictions"));
            RaceCondition = RaceCondition.Replace("Clm", "CLM").Replace("Alw", "ALW").Replace("Hcp", "HCP").Replace("Mcl", "MD").Replace("Msw", "MSW").Replace("Stk", "STK");
            Fraction1 = Utilities.ConvertTimeToMMSSFifth(dbr.GetValue<double>("time_for_fraction_1"));
            Fraction2 = Utilities.ConvertTimeToMMSSFifth(dbr.GetValue<double>("time_for_fraction_2"));
            Fraction3 = Utilities.ConvertTimeToMMSSFifth(dbr.GetValue<double>("time_for_fraction_3"));
            FinalTime = Utilities.ConvertTimeToMMSSFifth(dbr.GetValue<double>("final_time"));
        }
    }
}