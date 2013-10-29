using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hogar;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace OddsEditor.Dialogs
{
    public partial class WinnersTimeForm : Form
    {
        string _trackCode;
        string _surface;
        double _distanceInYards;
        string _aboutDistanceFlag;
        
        readonly Dictionary<int, PostPositionStats> _postPositionStats = new Dictionary<int, PostPositionStats>();
        bool _ready = false;

        class Distance
        {
            readonly double _distanceInYards;

            public Distance(double distanceInYards)
            {
                _distanceInYards = distanceInYards;
            }

            public double DistanceInYards
            {
                get
                {
                    return _distanceInYards;
                }
            }

            public override string ToString()
            {
                return Utilities.ConvertYardsToMilesOrFurlongs((int)_distanceInYards);
            }

        }

        class PostPositionStats
        {
            readonly int _postPosition;
            readonly int _total;
            int _winners;
            int _wireToWireWiners;

            public PostPositionStats(int postPosition, int total)
            {
                _postPosition = postPosition;
                _total = total;
            }

            public double Percent
            {
                get
                {

                    if (_total <= 0)
                    {
                        return 0.0;
                    }
                    else
                    {
                        return 100.00 * ((double)_winners / (double)_total);
                    }
                }
            }

            public int PostPosition
            {
                get
                {
                    return _postPosition;
                }
            }

            public int Total
            {
                get
                {
                    return _total;
                }                
            }

            public double WireToWireWinnersPercent
            {
                get
                {
                    if (_winners <= 0)
                    {
                        return 0.0;
                    }
                    else
                    {
                        return 100.00 * ((double)_wireToWireWiners / (double)_winners);
                    }
                }
            }

            public int WireToWireWinners
            {
                set
                {
                    _wireToWireWiners = value;
                }
                get
                {
                    return _wireToWireWiners;
                }
            }

            public int Winners
            {
                set
                {
                    _winners = value;
                }
                get
                {
                    return _winners;
                }
            }

        }

        public WinnersTimeForm(string trackCode, string sufrace, bool innerTrack, int distanceInYards, string aboutDistanceFlag)
        {
            _trackCode = trackCode;
            _surface = sufrace;
            
            if (innerTrack && _surface.Contains("D"))
            {
                _surface = "d";
            }
            else if (innerTrack && _surface.Contains("T"))
            {
                _surface = "t";
            }


            _distanceInYards = distanceInYards == 1830 ? 1830.4 : distanceInYards;

            _aboutDistanceFlag = aboutDistanceFlag;

            

            InitializeComponent();
        }


        string SqlPostPositionStarters
        {
            get
            {
                string sql =    string.Format (@"SELECT
	                                    a.post_position 'POST_POSITION', 
	                                    count(*) 'STARTERS'
                                    FROM 
	                                    race_starters a, 
	                                    race_description b
                                    WHERE 
			                                    a.program_number !='SCR' 
	                                    and	    a.race_id = b.race_id 
	                                    and     b.track_code = '{0}'
	                                    and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}' ",
                                _trackCode,  _distanceInYards, _aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;

                sql += " GROUP BY a.post_position ";

                return sql;  

                /*
                return string.Format (@"SELECT
	                                    a.post_position 'POST_POSITION', 
	                                    count(*) 'STARTERS'
                                    FROM 
	                                    race_starters a, 
	                                    race_description b
                                    WHERE 
			                                    a.program_number !='SCR' 
	                                     and	a.race_id = b.race_id 
	                                    and     b.track_code = '{0}'
	                                    and     convert(varbinary, b.SURFACE) = convert(varbinary, '{1}') 
	                                    and		b.distance = {2}
                                        and     b.ABOUT_DISTANCE_FLAG = '{3}'
                                    GROUP BY
	                                    a.post_position", 
                            _trackCode, _surface,_distanceInYards, _aboutDistanceFlag);
                 */ 
            }
        }

        string SqlFavoriteStats
        {
            get
            {
                string sql= string.Format(@"SELECT
	                                    count(*) 'FAVORITE_WINNERS'
                                    FROM 
	                                    race_starters a, 
	                                    race_description b
                                    WHERE 
			                                    a.program_number !='SCR' 
	                                     and	a.race_id = b.race_id 
	                                    and     b.track_code = '{0}'
	                                    and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}'
                                        and		a.Favorite_Flag=1
                                        and     a.official_position=1 ",
                            _trackCode, _distanceInYards, _aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;
                return sql;
            }
        }

        string SqlPostPositionWinners
        {
            get
            {
                string sql = string.Format(@"SELECT
	                                    a.post_position 'POST_POSITION', 
	                                    count(*) 'WINNERS'
                                    FROM 
	                                    race_starters a, 
	                                    race_description b
                                    WHERE 
			                                    a.program_number !='SCR' 
	                                    and	    a.race_id = b.race_id 
	                                    and     b.track_code = '{0}'
	                                    and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}'
                                    	and     a.official_position = 1    ",
                            _trackCode, _distanceInYards, _aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;
                sql += " GROUP BY a.post_position ";
                return sql;
            }
        }

        string SqlWireToWireWinners
        {
            get
            {
                string sql = string.Format(@"SELECT
	                                    a.post_position 'POST_POSITION', 
	                                    count(*) 'WINNERS'
                                    FROM 
	                                    race_starters a, 
	                                    race_description b
                                    WHERE 
			                                    a.program_number !='SCR' 
	                                     and	a.race_id = b.race_id 
	                                    and     b.track_code = '{0}'
	                                    and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}'
                                    	and     a.official_position = 1     
                                        AND FINISH_POSITION =1 
                                        AND (CALL_1_POSITION = 1 OR CALL_1_POSITION = 0)
                                        AND (CALL_2_POSITION = 1 OR CALL_2_POSITION = 0)
                                        AND (CALL_3_POSITION = 1 OR CALL_3_POSITION = 0)
                                        AND (STRETCH_POSITION = 1 OR STRETCH_POSITION = 0)",
                            _trackCode,  _distanceInYards, _aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;
                sql += " GROUP BY a.post_position ";
                return sql;
            }
        }


        string SqlSurfaceWhereClause
        {
            get
            {
                if (_surface.ToUpper() == "T")
                {
                    return string.Format(" AND convert(varbinary, SURFACE) = convert(varbinary, '{0}') ", _surface);
                }
                else if (_surface == "d")
                {
                    return string.Format(" AND convert(varbinary, SURFACE) = convert(varbinary, '{0}') ", _surface);
                }
                else
                {
                    return string.Format(" AND SURFACE !='T' ");
                }
            }
        }

        string SqlLoadWinners
        {
            get
            {
                string sql = @"SELECT   
                                        a.DATE_OF_THE_RACE 'DATE' , 
                                        a.TRACK_CONDITION 'CON' ,  
                                        a.ABBR_RACE_CLASS 'Class' , 
                                        RTRIM(b.HORSE_NAME) 'Horse Name' , 
                                        b.ABBR_JOCKEY_NAME 'Jockey',
                                        b.ABBR_TRAINER_NAME 'Trainer',    
                                        CASE WHEN CAST((a.FINAL_TIME * 100) / 6000 as int ) > 0 THEN
                                            RTRIM(CAST(CAST((a.FINAL_TIME * 100) / 6000 as int ) as char(3))) + '.' 
                                        ELSE 
                                            '' 
                                        END + CASE WHEN (CAST (a.FINAL_TIME*100 as int) %6000 ) / 100 >= 10 THEN CAST( (CAST (a.FINAL_TIME*100 as int) %6000 ) / 100 as char(2)) +'.' ELSE '0' + CAST( (CAST (a.FINAL_TIME*100 as int) %6000 ) / 100 as char(2)) +'.' END + CASE WHEN ( (CAST (a.FINAL_TIME*100 as int) %6000 ) % 100) >= 10 THEN CAST( (CAST (a.FINAL_TIME*100 as int) %6000 ) % 100 as char(2)) ELSE '0' + CAST( (CAST (a.FINAL_TIME*100 as int) %6000 ) % 100as char(2)) END  'Time'  , 
                                        b.POST_POSITION 'PP',
                                        b.CALL_1_POSITION 'CALL 1',
                                        b.CALL_2_POSITION 'CALL 2',
                                        b.CALL_3_POSITION 'CALL 3',
                                        b.STRETCH_POSITION 'STRETCH',
                                        b.WIN_PAYOFF 'WIN' , 
                                        b.FAVORITE_FLAG 'FAVOR',  
                                        a.TRACK_CODE 'TC',
                                        a.RACE_ID 'RACE_ID',
                                        a.RACE_NUMBER 'RN' ,  
                                        b.PROGRAM_NUMBER 'PN'

                            FROM        RACE_DESCRIPTION a, 
                                        RACE_STARTERS b 
                            WHERE   
                                        a.RACE_ID = b.RACE_ID 
                                    AND a.FINAL_TIME > 0
                                    AND a.RACE_NUMBER = b.RACE_NUMBER 
                                    AND b.OFFICIAL_POSITION =1 ";
                sql += @"AND DISTANCE = '{0}' AND a.TRACK_CODE = '{1}' and     a.ABOUT_DISTANCE_FLAG = '{2}' ";
                
                sql = string.Format(sql, _distanceInYards, _trackCode, _aboutDistanceFlag);
                sql += SqlSurfaceWhereClause;
                sql += " ORDER BY FINAL_TIME ";

                return sql;
            }
        }

        void LoadWinnerMovesToGrid()
        {
            string trackCode = _trackCode;
            if (_trackCode == "OSA")
            {
                trackCode = "SA";

                if (_surface == "A")
                {
                    _surface = "d";
                }
            }

            string surface = _surface;

            if (_trackCode == "SA")
            {
                if (surface.ToUpper() == "A")
                {
                    surface = "d";
                }
            }

            string sql = string.Format(@"SELECT TRACK_CONDITION, WMF FROM CYNTHIA_WINNING_MOVE WHERE TRACK_CODE = '{0}' AND DISTANCE = {1} AND SURFACE = '{2}'", trackCode, _distanceInYards, surface);

            var dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            _gridWinnersMove.DataSource = dataSet.Tables[0];
        }

        void LoadPostPositionsToGrid()
        {

            LoadPostPositionStatsFromDb();

            _gridPostPositionStats.Columns.Clear();
            _gridPostPositionStats.Columns.Add("PP", "PP");
            _gridPostPositionStats.Columns.Add("WINNERS", "WINNERS");
            _gridPostPositionStats.Columns.Add("TOTAL", "TOTAL");
            _gridPostPositionStats.Columns.Add("PERC", "PERC");
            _gridPostPositionStats.Columns.Add("W2W", "W2W");
            _gridPostPositionStats.Columns.Add("W2WPer", "W2WPer");


            int totalWire2WireWinners = 0;
            int totalNumberOfWinners = 0;
            foreach (KeyValuePair<int, PostPositionStats> pair in _postPositionStats)
            {
                int index = _gridPostPositionStats.Rows.Add();

                _gridPostPositionStats["PP", index].Value = pair.Value.PostPosition;
                _gridPostPositionStats["WINNERS", index].Value = pair.Value.Winners;
                _gridPostPositionStats["TOTAL", index].Value = pair.Value.Total;
                _gridPostPositionStats["PERC", index].Value = string.Format("{0:0.00}%", pair.Value.Percent);
                _gridPostPositionStats["W2W", index].Value = pair.Value.WireToWireWinners;
                _gridPostPositionStats["W2WPer", index].Value = string.Format("{0:0.00}%", pair.Value.WireToWireWinnersPercent);

                totalWire2WireWinners += pair.Value.WireToWireWinners;
                totalNumberOfWinners += pair.Value.Winners;

            }

            _txtboxTotalWire2WireWinners.Text = totalWire2WireWinners.ToString();
            _txtboxTotalRaces.Text = totalNumberOfWinners.ToString();
            double percent = 100.00 * ((double)totalWire2WireWinners / (double)totalNumberOfWinners);
            _txtboxWire2WirePercent.Text = string.Format("{0:0.00}%", percent);

            int count = CountWinningFavorites;
            _txtboxWinningFavorites.Text = count.ToString();
            _txtboxTotal.Text = totalNumberOfWinners.ToString();
            percent = 100.00 * ((double)count / (double)totalNumberOfWinners);
            _txtboxFavoriteWinPercent.Text = string.Format("{0:0.00}%", percent);

        }


        void LoadPostPositionStatsFromDb()
        {
            _ready = false;
            _postPositionStats.Clear();

            SqlDataReader myReader = null;
            try
            {
                var myCommand = new SqlCommand(SqlPostPositionStarters, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int postPosition = (int)myReader["POST_POSITION"];
                        int starters = (int)myReader["STARTERS"];


                        _postPositionStats.Add(postPosition,new PostPositionStats(postPosition,starters));
                    }
                }
                myReader.Close();

                myCommand = new SqlCommand(SqlPostPositionWinners, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int postPosition = (int)myReader["POST_POSITION"];
                        int winners = (int)myReader["WINNERS"];

                        if (_postPositionStats.ContainsKey(postPosition))
                        {
                            _postPositionStats[postPosition].Winners = winners;
                        }
                    }
                }
                myReader.Close();

                myCommand = new SqlCommand(SqlWireToWireWinners, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int postPosition = (int)myReader["POST_POSITION"];
                        int winners = (int)myReader["WINNERS"];

                        if (_postPositionStats.ContainsKey(postPosition))
                        {
                            _postPositionStats[postPosition].WireToWireWinners = winners;
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

                _ready = true;
            } 


        }

        int CountWinningFavorites
        {
            get
            {
                SqlDataReader myReader = null;
                try
                {
                    var myCommand = new SqlCommand(SqlFavoriteStats, Hogar.DbTools.DbUtilities.SqlConnection);
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            return (int)myReader["FAVORITE_WINNERS"];
                        }
                    }
                }
                finally
                {
                    if (null != myReader && myReader.IsClosed == false)
                    {
                        myReader.Close();
                    }
                }
                return 0;
            }
        }

        void LoadSurfaceComboBox()
        {

            if (_comboboxSurface.Items.Count > 0)
            {
                return;
            }

            _comboboxSurface.Items.Clear();
            int dirtindex = -1, turfIndex = -1, innerDirtIndex = -1, innerTurfIndex = -1;

            dirtindex = _comboboxSurface.Items.Add("Dirt");
            turfIndex = _comboboxSurface.Items.Add("Turf");
            innerDirtIndex = _comboboxSurface.Items.Add("Inner Dirt");
            innerTurfIndex = _comboboxSurface.Items.Add("Inner Turf");

            if (_surface == "T")
            {
                _comboboxSurface.SelectedIndex = turfIndex;
            }
            else if (_surface == "t")
            {
                _comboboxSurface.SelectedIndex = innerTurfIndex;
            }
            else if (_surface == "d")
            {
                _comboboxSurface.SelectedIndex = innerDirtIndex;
            }
            else
            {
                _comboboxSurface.SelectedIndex = dirtindex;
            }
        }

        void LoadRaceTrackComboBox()
        {
            if (_comboboxRaceTrack.Items.Count > 0)
            {
                return;
            }

            _comboboxRaceTrack.Items.Clear();
            int index = -1;

            foreach (RaceTrackInfo rti in RaceTracks.RaceTrackInfoCollection)
            {
                int i = _comboboxRaceTrack.Items.Add(rti);

                if (rti.TrackCode == _trackCode)
                {
                    index = i;
                }
            }

            if (index >= 0)
            {
                _comboboxRaceTrack.SelectedIndex = index;
            }
        }

        void LoadDistanceComboBox()
        {
            
            if (_comboBoxDistance.Items.Count > 0)
            {
                return;
            }

            
            _comboBoxDistance.Items.Clear();
            SqlDataReader myReader = null;
            try
            {
                int indexToSelect = -1;
                string sql = string.Format(@"SELECT DISTINCT(DISTANCE) 'DISTANCE' FROM RACE_DESCRIPTION ORDER BY DISTANCE");
                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {

                        var d = (double)myReader["DISTANCE"];

                        if (d >= 4.0 * Utilities.YARDS_IN_A_FURLONG)
                        {
                            var dist = new Distance(d);
                            int index = _comboBoxDistance.Items.Add(dist);
                            if (dist.DistanceInYards == _distanceInYards)
                            {
                                indexToSelect = index;
                            }
                        }
                    }
                }
                myReader.Close();

                if (indexToSelect >= 0)
                {
                    _comboBoxDistance.SelectedIndex = indexToSelect;
                }

            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }

        }

        void OnInitialLoad(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadAboutDistanceComboBox()
        {
            if (_comboBoxAboutFlag.Items.Count > 0)
            {
                return;
            }

            _comboBoxAboutFlag.Items.Clear();
            int aboutIndex = _comboBoxAboutFlag.Items.Add("About");
            int exactIndex = _comboBoxAboutFlag.Items.Add("Exact");
            
            _comboBoxAboutFlag.SelectedIndex = _aboutDistanceFlag == "A" ? aboutIndex : exactIndex;
        }

        void LoadData()
        {

            Cursor = Cursors.WaitCursor;

            LoadDistanceComboBox();
            LoadRaceTrackComboBox();
            LoadSurfaceComboBox();
            LoadAboutDistanceComboBox();

            Text = string.Format("Winners for {0} {1} {2} {3} ", RaceTracks.GetNameFromTrackCode(_trackCode), _surface, _aboutDistanceFlag, Utilities.ConvertYardsToMilesOrFurlongs((int)_distanceInYards));
            try
            {
                var dataAdapter = new SqlDataAdapter(SqlLoadWinners, Hogar.DbTools.DbUtilities.SqlConnection);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                dataSet.Tables[0].Columns.Add("Date2");

                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    dr["Class"] = dr["Class"].ToString().Trim();
                    dr["Jockey"] = Utilities.CapitalizeOnlyFirstLetter(dr["Jockey"].ToString());
                    dr["Trainer"] = Utilities.CapitalizeOnlyFirstLetter(dr["Trainer"].ToString());
                    dr["Date2"] = dr["Date"].ToString();
                    dr["Date"] = Utilities.GetFullDateString(dr["Date2"].ToString());
                    
                }

                _grid.DataSource = dataSet.Tables[0];
                _grid.Columns["TC"].Visible = false;
                _grid.Columns["RACE_ID"].Visible = false;
                _grid.Columns["RN"].Visible = false;
                _grid.Columns["PN"].Visible = false;
                _grid.Columns["Date2"].Visible = false;

                var f = new Font(_grid.DefaultCellStyle.Font, FontStyle.Underline);
                Color c = Color.Blue;
                
                _grid.Columns["Horse Name"].DefaultCellStyle.Font = f;
                _grid.Columns["Horse Name"].DefaultCellStyle.ForeColor = c;
                _grid.Columns["Horse Name"].DefaultCellStyle.SelectionForeColor = c;
                _grid.Columns["Trainer"].DefaultCellStyle.Font = f;
                _grid.Columns["Trainer"].DefaultCellStyle.ForeColor = c;
                _grid.Columns["Trainer"].DefaultCellStyle.SelectionForeColor = c;
                _grid.Columns["Class"].DefaultCellStyle.Font = f;
                _grid.Columns["Class"].DefaultCellStyle.ForeColor = c;
                _grid.Columns["Class"].DefaultCellStyle.SelectionForeColor = c;
                
                LoadPostPositionsToGrid();
                LoadWinnerMovesToGrid();

                _gridStatsByTrackCondition.DataSource = LoadStatsByTrackCondition();

                _gridStatsByTrackCondition.Columns["W2W"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _gridStatsByTrackCondition.Columns["FAV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _gridStatsByTrackCondition.Columns["W2W%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _gridStatsByTrackCondition.Columns["FAV%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _gridStatsByTrackCondition.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor = Cursors.Default;
        }

       
        private void OnSelectedDistanceChanged(object sender, EventArgs e)
        {
            if (_ready)
            {
                var dist = (Distance)_comboBoxDistance.SelectedItem;
                _distanceInYards = (int)dist.DistanceInYards;
                LoadData();
            }
        }


        private void OnAboutFlagChanged(object sender, EventArgs e)
        {
            if (_ready)
            {
                var aboutFlag = _comboBoxAboutFlag.SelectedItem as string;

                if (null != aboutFlag)
                {
                    if (aboutFlag.ToUpper() == "ABOUT")
                    {
                        _aboutDistanceFlag = "A";
                    }
                    else
                    {
                        _aboutDistanceFlag = " ";
                    }

                    LoadData();
                }
            }
        }

        private void OnSelectedRaceTrackChanged(object sender, EventArgs e)
        {
            if (_ready)
            {
                var rti = _comboboxRaceTrack.SelectedItem as RaceTrackInfo;

                if (null != rti)
                {
                    _trackCode = rti.TrackCode;
                    LoadData();
                }
            }
        }

        private void OnSelectedSurfaceChanged(object sender, EventArgs e)
        {
            if (_ready)
            {
                string surface = _comboboxSurface.SelectedItem as string;

                if (null != surface)
                {
                    if (surface.ToUpper() == "TURF")
                    {
                        _surface = "T";
                    }
                    else if (surface.ToUpper() == "INNER TURF")
                    {
                        _surface = "t";
                    }
                    else if (surface.ToUpper() == "DIRT")
                    {
                        _surface = "D";
                    }
                    else if (surface.ToUpper() == "INNER DIRT")
                    {
                        _surface = "d";
                    }
                    else
                    {
                        _surface = "D";
                    }
                    
                    LoadData();
                }
            }
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    string trackCode = _grid["TC", e.RowIndex].Value.ToString();
                    string date = _grid["DATE2", e.RowIndex].Value.ToString();
                    int year = Convert.ToInt32(date.Substring(0, 4));
                    int month = Convert.ToInt32(date.Substring(4, 2));
                    int day = Convert.ToInt32(date.Substring(6, 2));
                    int raceNumber = (int)_grid["RN", e.RowIndex].Value;
                    int raceID = (int)_grid["RACE_ID", e.RowIndex].Value;
                    string programNumber = _grid["PN", e.RowIndex].Value.ToString();
                    string trainer = _grid["Trainer", e.RowIndex].Value.ToString();

                    Form form = null;

                    if (e.ColumnIndex == _grid.Columns["Horse Name"].Index)
                    {
                        form = new IndividualHorsePastPerformancesForm(trackCode, year, month, day, raceNumber, programNumber);
                    }
                    else if (e.ColumnIndex == _grid.Columns["Trainer"].Index)
                    {
                        form = new IndividualTrainerStatsForm(trainer);
                    }
                    else if (e.ColumnIndex == _grid.Columns["Class"].Index)
                    {
                        form = new RaceChartForm(raceID);
                    }

                    if (null != form)
                    {
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _grid.Columns["Horse Name"].Index)
            {
                _grid.Cursor = Cursors.Hand;
            }
            else if (e.ColumnIndex == _grid.Columns["Trainer"].Index)
            {
                _grid.Cursor = Cursors.Hand;
            }
            else if (e.ColumnIndex == _grid.Columns["Class"].Index)
            {
                _grid.Cursor = Cursors.Hand;
            }
        }

        private void OnGridCellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            _grid.Cursor = Cursors.Default;
        }

        private static void AddRowIfDoesNotExists(string columnName,string fieldValue, DataTable dt)
        {
            foreach (DataRow dr1 in dt.Rows)
            {
                if (dr1[columnName].ToString().Trim().ToUpper() == fieldValue.Trim().ToUpper())
                {
                    return;
                }
            }

            var fields = new object[dt.Columns.Count];

            DataRow dr = dt.Rows.Add(fields);
            dr[columnName] = fieldValue;

            foreach (DataColumn dc in dt.Columns)
            {
                if(dc.DataType == typeof(int))
                {
                    dr[dc] = 0;
                }
                
            }
        }

        private DataTable LoadStatsByTrackCondition()
        {
            var dt = new DataTable();
            dt.Columns.Add("Cond");
            dt.Columns.Add("W2W");
            dt.Columns.Add("W2W%");
            dt.Columns.Add("FAV");
            dt.Columns.Add("FAV%");
            dt.Columns.Add("TOTAL");

            dt.Columns["W2W"].DataType = typeof(int);
            dt.Columns["FAV"].DataType = typeof(int);
            dt.Columns["W2W%"].DataType = typeof(string);
            dt.Columns["FAV%"].DataType = typeof(string);
            dt.Columns["TOTAL"].DataType = typeof(int);

            var dataAdapter = new SqlDataAdapter(SQLLoadWireToWireByTrackCondition, Hogar.DbTools.DbUtilities.SqlConnection);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var condition = (string)dr["TRACK_CONDITION"];
                var count = (int)dr["COUNT"];
                AddRowIfDoesNotExists("Cond", condition, dt);
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (dr1[0].ToString().Trim().ToUpper() == condition.Trim().ToUpper())
                    {
                        dr1["W2W"] = count;
                        break;
                    }
                }
            }

            dataAdapter = new SqlDataAdapter(SqlLoadFavoriteWinnersByTrackCondition, Hogar.DbTools.DbUtilities.SqlConnection);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string condition = (string)dr["TRACK_CONDITION"];
                int count = (int)dr["COUNT"];
                AddRowIfDoesNotExists("Cond", condition, dt);
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (dr1[0].ToString().Trim().ToUpper() == condition.Trim().ToUpper())
                    {
                        dr1["FAV"] = count;
                        break;
                    }
                }
            }

            dataAdapter = new SqlDataAdapter(SqlLoadTotalRacesByTrackCondition, Hogar.DbTools.DbUtilities.SqlConnection);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string condition = (string)dr["TRACK_CONDITION"];
                int count = (int)dr["COUNT"];
                AddRowIfDoesNotExists("Cond", condition, dt);
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (dr1[0].ToString().Trim().ToUpper() == condition.Trim().ToUpper())
                    {
                        dr1["TOTAL"] = count;
                        break;
                    }
                }
            }

            foreach (DataRow row in dt.Rows)
            {   
                var total = (int)row["TOTAL"];
                var w2w = (int)row["W2W"];
                var fav = (int)row["FAV"];

                if (total != 0)
                {
                    var w2wPer = ((double)w2w / (double)total) * 100.0;
                    row["W2W%"] = string.Format("{0:0.00}%", w2wPer);

                    double favPer = ((double)fav / (double)total) * 100.0;
                    row["FAV%"] = string.Format("{0:0.00}%", favPer);
                }
                else
                {
                    row["W2W%"] = "0%";
                    row["FAV%"] = "0%";
                }
            }
            return dt;
        }

        private string SqlLoadTotalRacesByTrackCondition
        {
            get
            {
                string sql = string.Format(@"SELECT
                                        b.TRACK_CONDITION, 
                                        count(*) 'COUNT'
                                    FROM 
                                        race_starters a, 
                                        race_description b
                                    WHERE 
                                                a.program_number !='SCR' 
                                         and	a.race_id = b.race_id 
                                        and     b.track_code = '{0}'
                                        and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}'
            	                        and     a.official_position = 1    ",
                            _trackCode, _distanceInYards,_aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;
                sql += " GROUP BY TRACK_CONDITION ";
                return sql;

            }
        }


        private string SqlLoadFavoriteWinnersByTrackCondition
        {
            get
            {
                string sql = string.Format(@"SELECT
                                        b.TRACK_CONDITION, 
                                        count(*) 'COUNT'
                                    FROM 
                                        race_starters a, 
                                        race_description b
                                    WHERE 
                                                a.program_number !='SCR' 
                                         and	a.race_id = b.race_id 
                                        and     b.track_code = '{0}'
                                        and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}'
            	                        and     a.official_position = 1     
                                       AND FAVORITE_FLAG = 1 ",
                            _trackCode, _distanceInYards, _aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;
                sql += " GROUP BY TRACK_CONDITION ";
                return sql;

            }
        }


        private string SQLLoadWireToWireByTrackCondition
        {
            get
            {
                string sql = string.Format(@"SELECT
                                        b.TRACK_CONDITION 'TRACK_CONDITION', 
                                        count(*) 'COUNT'
                                    FROM 
                                        race_starters a, 
                                        race_description b
                                    WHERE 
                                                a.program_number !='SCR' 
                                         and	a.race_id = b.race_id 
                                        and     b.track_code = '{0}'
                                        and		b.distance = {1}
                                        and     b.ABOUT_DISTANCE_FLAG = '{2}'
            	                        and     a.official_position = 1     
                                        AND FINISH_POSITION =1 
                                        AND (CALL_1_POSITION = 1 OR CALL_1_POSITION = 0)
                                        AND (CALL_2_POSITION = 1 OR CALL_2_POSITION = 0)
                                        AND (CALL_3_POSITION = 1 OR CALL_3_POSITION = 0)
                                        AND (STRETCH_POSITION = 1 OR STRETCH_POSITION = 0) ",
                           _trackCode, _distanceInYards,_aboutDistanceFlag);

                sql += SqlSurfaceWhereClause;
                sql += " GROUP BY TRACK_CONDITION ";
                return sql;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
