using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar;
using Hogar.RaceResults;
using OddsEditor.Dialogs.WinnersForDay;

namespace OddsEditor.Dialogs
{
    public partial class RaceChartForm : Form
    {
        private int _raceid;
        private string _trackCode = "";
        private string _date = "";
        private int _raceNumber = -1;

        private List<int> _browserHistory = new List<int>();
        private int _historyIndex;

        public RaceChartForm(int raceid)
        {
            _raceid = raceid;

            InitializeComponent();
        }

        private static void EliminateColumnIfAllValuesAreZero(DataTable t, string name)
        {
            foreach (DataRow dr in t.Rows)
            {
                object v = dr[name];

                if (v is string && ((string) v).Length > 0 && ((string) v)[0] == '$')
                {
                    string s = ((string) v).Substring(1);
                    v = Convert.ToInt32(s);
                }

                if (null == v)
                {
                    continue;
                }
                else if (v is int)
                {
                    if (0 != (int) v)
                    {
                        return;
                    }
                }
                else if (v is double)
                {
                    if (0.0 != (double) v)
                    {
                        return;
                    }
                }
            }

            t.Columns.Remove(name);
        }

        private void LoadRace()
        {
            if (_browserHistory.Contains(_raceid))
            {
                _historyIndex = _browserHistory.IndexOf(_raceid);
            }
            else
            {
                _browserHistory.Add(_raceid);
                _historyIndex = _browserHistory.IndexOf(_raceid);
            }

            _buttonBack.Enabled = _historyIndex > 0 && _browserHistory.Count > 1;
            _buttonForward.Enabled = _historyIndex < _browserHistory.Count - 1 && _browserHistory.Count > 1;

            SqlDataReader myReader = null;

            try
            {
                string sql = string.Format(@"SELECT 
	                                            TRACK_CODE, 
	                                            DATE_OF_THE_RACE, 
	                                            RACE_NUMBER 
                                            FROM 
	                                            RACE_DESCRIPTION
                                            WHERE 
                                                RACE_ID ={0}"
                                           , _raceid);

                var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    _trackCode = myReader["TRACK_CODE"].ToString();
                    _date = myReader["DATE_OF_THE_RACE"].ToString();
                    _raceNumber = (int) myReader["RACE_NUMBER"];
                }
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }

            if (!LoadRaceDescription())
            {
                _txtboxRaceTrackName.Text = "Race Not Found";
                _txtboxRaceNumberAndDate.Text = string.Format("Race #{0} does not exist in the data base", _raceid);
                _txtboxRaceTrackName.BackColor = Color.White;
                _txtboxRaceTrackName.ForeColor = Color.Red;
                _txtboxRaceNumberAndDate.BackColor = Color.White;
                _txtboxRaceNumberAndDate.BackColor = Color.Red;
            }
            else
            {
                string sql = string.Format("SelectRaceResults '{0}', '{1}' , {2}", _trackCode, _date, _raceNumber);

                var dataAdapter = new SqlDataAdapter(string.Format("SelectRaceResults '{0}', '{1}' , {2}", _trackCode, _date, _raceNumber), Hogar.DbTools.DbUtilities.SqlConnection);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "CALL_1_POSITION");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "CALL_2_POSITION");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "CALL_3_POSITION");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "STRETCH_POSITION");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "FINISH_POSITION");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "CLAIMING_PRICE");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "Margin1");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "Margin2");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "Margin3");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "StretchMargin");
                EliminateColumnIfAllValuesAreZero(dataSet.Tables[0], "FinishMargin");

                _grid.DataSource = dataSet.Tables[0];

                var smallFont = new Font("Arial", 8.75F);
                var largeFont = new Font("Arial", 18.0F, FontStyle.Bold);

                foreach (DataGridViewColumn column in _grid.Columns)
                {
                    if (column.HeaderText.ToUpper().Contains("MARGIN"))
                    {
                        column.DefaultCellStyle.Font = smallFont;
                    }
                    if (column.HeaderText.ToUpper().Contains("POSITION"))
                    {
                        column.DefaultCellStyle.Font = largeFont;
                        column.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }

                _grid.Columns["PROGRAM_NUMBER"].DefaultCellStyle.BackColor = Color.Black;
                _grid.Columns["PROGRAM_NUMBER"].DefaultCellStyle.ForeColor = Color.White;

                _grid.Columns["PROGRAM_NUMBER"].DefaultCellStyle.SelectionBackColor = Color.Black;
                _grid.Columns["PROGRAM_NUMBER"].DefaultCellStyle.SelectionForeColor = Color.White;

                if (_grid.Columns.Contains("CLAIMING_PRICE"))
                {
                    _grid.Columns["CLAIMING_PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                LoadFootnotes();
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            LoadRace();
        }

        private string SqlLoadRaceDescription
        {
            get
            {
                return string.Format(@"SELECT 
	                                        TRACK_CODE,
	                                        DATE_OF_THE_RACE,
	                                        RACE_NUMBER,
	                                        DISTANCE,
	                                        SURFACE,
	                                        AGE_SEX_RESTRICTIONS,
	                                        STATE_BRED_FLAG,
	                                        ABBR_RACE_CLASS,
                                            RACE_NAME,
                                            RACE_GRADE,    
	                                        PURSE,
	                                        MAX_CLAIMING_PRICE,
	                                        RACE_CONDITIONS,
	                                        FIELD_SIZE,
	                                        TRACK_CONDITION,
	                                        TIME_FOR_FRACTION_1,
	                                        TIME_FOR_FRACTION_2,
	                                        TIME_FOR_FRACTION_3,
	                                        TIME_FOR_FRACTION_4,
	                                        TIME_FOR_FRACTION_5,
	                                        FINAL_TIME,
	                                        OFF_TURF_INDICATOR
                                        FROM 
	                                        RACE_DESCRIPTION
                                        WHERE RACE_ID = {0}", _raceid);
            }
        }

        private bool LoadRaceDescription()
        {
            SqlDataReader myReader = null;
            try
            {
                SqlCommand myCommand = new SqlCommand(SqlLoadRaceDescription, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string trackName = RaceTracks.GetNameFromTrackCode(myReader["TRACK_CODE"].ToString());
                        string date = Utilities.GetFullDateString(myReader["DATE_OF_THE_RACE"].ToString());
                        string raceNumber = GetRaceNumberAsString((int) myReader["RACE_NUMBER"]);
                        string distance = Utilities.ConvertYardsToMilesOrFurlongs((int) ((double) myReader["DISTANCE"]));
                        string surface = myReader["SURFACE"].ToString().Trim();
                        string offTurfIndicator = myReader["OFF_TURF_INDICATOR"].ToString().Trim();
                        string ageSexRestrictions = myReader["AGE_SEX_RESTRICTIONS"].ToString().Trim();
                        string stateBredFlag = myReader["STATE_BRED_FLAG"].ToString().Trim();
                        string abbrRaceClass = myReader["ABBR_RACE_CLASS"].ToString().Trim();
                        int raceGrade = (int) myReader["RACE_GRADE"];
                        string raceName = myReader["RACE_NAME"].ToString().Trim();

                        _txtboxRaceTrackName.Text = trackName;
                        _txtboxRaceNumberAndDate.Text = string.Format("{0}, {1}", raceNumber, date);
                        _txtboxDistanceAndSurface.Text = distance;
                        if (surface.ToUpper() == "T")
                        {
                            _txtboxDistanceAndSurface.Text += " TURF";
                        }
                        if (offTurfIndicator == "O")
                        {
                            _txtboxDistanceAndSurface.Text += " OFF TURF";
                        }

                        _labelRaceCondition.Text = Utilities.MakeRaceCondition(stateBredFlag, ageSexRestrictions, abbrRaceClass, raceGrade, raceName);
                        _labelTrackCondition.Text = MakeTrackCondition(myReader["TRACK_CONDITION"].ToString().ToUpper().Trim());

                        _labelFinalTime.Text = Utilities.ConvertTimeToMMSSFifth((double) myReader["FINAL_TIME"]);

                        Text = trackName + " " + _txtboxRaceNumberAndDate.Text + " " + _txtboxDistanceAndSurface.Text;
                    }
                    return true;
                }
                else
                {
                    return false;
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

        private string MakeTrackCondition(string p)
        {
            if (p == "FT")
            {
                return "Fast";
            }
            else if (p == "GD")
            {
                return "Good";
            }
            else if (p == "FM")
            {
                return "Firm";
            }
            else if (p == "SLY")
            {
                return "Sloppy";
            }
            else if (p == "yl")
            {
                return "Yielding";
            }
            else
            {
                return p;
            }
        }

        private string GetRaceNumberAsString(int raceNumber)
        {
            string txt = "";
            switch (raceNumber)
            {
                case 1:
                    txt += "FIRST";
                    break;
                case 2:
                    txt += "SECOND";
                    break;
                case 3:
                    txt += "THIRD";
                    break;
                case 4:
                    txt += "FOURTH";
                    break;
                case 5:
                    txt += "FIFTH";
                    break;
                case 6:
                    txt += "SIXTH";
                    break;
                case 7:
                    txt += "SEVENTH";
                    break;
                case 8:
                    txt += "EIGHTH";
                    break;
                case 9:
                    txt += "NINTH";
                    break;
                case 10:
                    txt += "TENTH";
                    break;
                case 11:
                    txt += "ELEVENTH";
                    break;
                case 12:
                    txt += "TWELTH";
                    break;
                case 13:
                    txt += "THIRTEENTH";
                    break;
                default:
                    txt += raceNumber.ToString();
                    break;
            }
            txt += " RACE";
            return txt;
        }

        private void _labelRaceCondition_Click(object sender, EventArgs e)
        {
        }

        private void LoadFootnotes()
        {
            SqlDataReader myReader = null;
            string footnote = "";
            try
            {
                string sql = string.Format("Exec SelectFootNotes '{0}', '{1}' , {2}", _trackCode, _date, _raceNumber);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    footnote += myReader["FOOT_NOTE"].ToString();
                }
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }

            string[] horseName = new string[_grid.Rows.Count];
            int i = 0;
            foreach (DataGridViewRow row in _grid.Rows)
            {
                horseName[i++] = row.Cells["HORSE_NAME"].Value.ToString();
            }

            string[] lines = footnote.Split('.');

            string txt = "";
            foreach (string s in lines)
            {
                txt += s.Trim();
                txt += Environment.NewLine + Environment.NewLine;
            }

            _txtboxFootNotes.Text = "";
            _txtboxFootNotes.Select();

            _txtboxFootNotes.Text = txt;
            _txtboxFootNotes.SelectionColor = Color.Black;

            for (i = 0; i < horseName.Length; ++i)
            {
                string name = horseName[i].ToUpper();
                int index = _txtboxFootNotes.Find(name);
                while (index >= 0)
                {
                    _txtboxFootNotes.Select(index, name.Length);
                    _txtboxFootNotes.SelectionColor = Color.Red;
                    _txtboxFootNotes.SelectionFont = new Font(_txtboxFootNotes.Font, FontStyle.Bold);
                    index += name.Length + 1;
                    if (index >= _txtboxFootNotes.Text.Length)
                    {
                        break;
                    }
                    index = _txtboxFootNotes.Find(name, index, RichTextBoxFinds.None);
                }
            }
        }

        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = _grid.Rows[e.RowIndex];

                foreach (DataGridViewColumn column in _grid.Columns)
                {
                    if (column.HeaderText.ToUpper().Contains("POSITION"))
                    {
                        if (row.Cells[column.HeaderText].Value is int)
                        {
                            if (1 == (int) row.Cells[column.HeaderText].Value)
                            {
                                _grid[column.HeaderText, row.Index].Style.BackColor = Color.Red;
                                _grid[column.HeaderText, row.Index].Style.SelectionBackColor = Color.Red;
                            }
                            else if (2 == (int) row.Cells[column.HeaderText].Value)
                            {
                                _grid[column.HeaderText, row.Index].Style.BackColor = Color.Green;
                                _grid[column.HeaderText, row.Index].Style.SelectionBackColor = Color.Green;
                            }
                            else
                            {
                                _grid[column.HeaderText, row.Index].Style.BackColor = Color.White;
                                _grid[column.HeaderText, row.Index].Style.SelectionBackColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        private void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string name = _grid["HORSE_NAME", e.RowIndex].Value.ToString();
                    _labelHorseName.Text = name;
                    var hpc = new HorsePastPerformanceCollection(name);
                    hpc.BindGrid(_gridSelectedHorseRaces);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnShowAllRacesForTheDay(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;

            if (null == menuItem)
                return;
            HorsePastPerformance pp = menuItem.Tag as HorsePastPerformance;
            if (null == pp)
                return;

            try
            {
                string trackCode = pp.TrackCode;

                int year = int.Parse(pp.Date.Substring(0, 4));
                int month = int.Parse(pp.Date.Substring(4, 2));
                int day = int.Parse(pp.Date.Substring(6, 2));
                var date = new DateTime(year, month, day);

                ShowFractionsForTheDayForm.DisplayModal(date, trackCode, pp.HorseName, pp.RaceNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSelectedHorseRacesCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView g = _gridSelectedHorseRaces;

                if (e.RowIndex >= 0)
                {
                    HorsePastPerformance pp = (HorsePastPerformance) g.Rows[e.RowIndex].Tag;

                    if (e.Button == MouseButtons.Left)
                    {
                        _raceid = pp.Raceid;
                        LoadRace();
                    }
                    else
                    {
                        Rectangle r = g.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _popUpMenu.Items.Clear();

                        ToolStripItem item = _popUpMenu.Items.Add("Show All Races For The Day", null, OnShowAllRacesForTheDay);

                        item.Tag = pp;
                        _popUpMenu.Show((Control) sender, r.Left + e.X, r.Top + e.Y);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ObBackButton(object sender, EventArgs e)
        {
            _raceid = _browserHistory[--_historyIndex];
            LoadRace();
        }

        private void OnForwardButton(object sender, EventArgs e)
        {
            _raceid = _browserHistory[++_historyIndex];
            LoadRace();
        }
    }
}