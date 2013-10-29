using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Hogar;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;
using Hogar.Betting.Superfecta;
using Hogar.BrisPastPerformances;
using Hogar.RealTimeTools;
using Hogar.StatisticTools;
using OddsEditor.Dialogs;
using OddsEditor.Dialogs.Filter;
using OddsEditor.Dialogs.KeyRacesViewer;
using OddsEditor.Dialogs.RaceAnalyzer;
using OddsEditor.Dialogs.SuperStudio;
using System.Threading;
using OddsEditor.Dialogs.JockeyStatistics;
using System.Linq;

namespace OddsEditor.MyComponents
{
    public partial class RaceSummaryControl : UserControl
    {
        private static int _REAL_TIME_UPDATES_COUNTER = 0;

        private Race _race = null;
        private Horse _currentHorse = null;

        private int _numberColumnIndex = -1;
        private int _isBestBetColumnIndex = -1;
        private int _nameColumnIndex = -1;
        private int _oddsColumnIndex = -1;
        private int _oddsFromExactaColumnIndex = -1;
        private int _oddsFromDoubleColumnIndex = -1;
        private int _valueColumnIndex = -1;
        private int _weightColumnIndex = -1;

        //private int _votesForFavoriteColumnIndex = -1;
        //private int _votesForOddsColumnIndex = -1;
        //private int _votesTotalsColumnIndex = -1;
        private int _jockeyColumnIndex = -1;
        private int _trainerColumnIndex = -1;
        private int _primePowerColumnIndex = -1;
        private int _bestRaceRatingColumnIndex = -1;
        private int _bestClassRatingColumnIndex = -1;
        private int _quirinSpeedIndexColumnIndex = -1;
        private int _runningStyleColumnIndex = -1;
        private int _daysOffColumnIndex = -1;
        private int _racingFrequencyColumnIndex = -1;
        private int _horseNotesColumnIndex = -1;
        private int _distanceColumnIndex = -1;
        private int _goldenPaceFigureForThisHorse = -1;
        private int _goldenPaceFigureIndex = -1;
        private int _goldenFigureForTheWinnerIndex = -1;
        private int _goldenFigureForThisIndex = -1;
        private int _donkeyColumnIndex = - 1;

        private OddsRetriever _oddsRetriever = null;
        private readonly SuperfectaSystem _superfectaSystem = new SuperfectaSystem();

        private static readonly Color _FIRST_TIME_OUT_BACK_COLOR = Color.DarkBlue;
        private static readonly Color _FIRST_TIME_OUT_FRONT_COLOR = Color.Yellow;
        private static readonly Color _FIRST_AFTER_LAYOFF_COLOR;
        private static readonly Color _SECOND_AFTER_LAYOFF_COLOR;
        private static readonly Color _THIRD_AFTER_LAYOFF_COLOR;

        private Font _boldFont;

        public delegate void UpdateParentDelegate(RaceSummaryControl c);

        public event UpdateParentDelegate UpdateParentEvent;

        private static int ComparePrimeRatings(Horse horse1, Horse horse2)
        {
            int h1 = horse1.CorrespondingBrisHorse.PrimePowerRating;
            int h2 = horse2.CorrespondingBrisHorse.PrimePowerRating;
            if (h1 > h2)
            {
                return -1;
            }
            else if (h1 < h2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static RaceSummaryControl()
        {
            //_firstAfterLayoffColor = System.Drawing.ColorTranslator.FromHtml("#F57550");
            //_secondAfterLayoffColor = System.Drawing.ColorTranslator.FromHtml("#FCEC01");
            //_thirdAfterLayoffColor = System.Drawing.ColorTranslator.FromHtml("#67039A");

            _FIRST_AFTER_LAYOFF_COLOR = Color.Yellow;
            _SECOND_AFTER_LAYOFF_COLOR = Color.LightGreen;
            _THIRD_AFTER_LAYOFF_COLOR = Color.Red;
        }

        public Race Race { get { return _race; } }

        public RaceSummaryControl()
        {
            InitializeComponent();
        }

        public void BindRace(Race race)
        {
            Cursor = Cursors.WaitCursor;
            _race = race;
            _race.SpecifyHorsesWithNotes();
            int hour = _race.CorrespondingBrisRace.PostTime.Hour >= 13 ? _race.CorrespondingBrisRace.PostTime.Hour - 12 : _race.CorrespondingBrisRace.PostTime.Hour;
            _labelRaceNumber.Text = string.Format("Race# {0} ({1}:{2})", _race.RaceNumber, hour, _race.CorrespondingBrisRace.PostTime.Minute);
            
            AddColumns();

            InitialGridLoad();
            _buttonShowResults.Visible = _race.ExistsInDb;
            _labelRaceClassification.Text = _race.CorrespondingBrisRace.RaceClassification;

            if (_race.CorrespondingBrisRace.Horses[0].TodaysRaceIsInTurf)
            {
                _labelRaceClassification.BackColor = Color.LightGreen;
            }

            _labelHorseDetails.Text = "";
            _progressBar.Visible = false;
            _grid.BorderStyle = BorderStyle.None;
            _grid.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            _raceCommentsCtrl.BindRace(race);

            _brisFiguresStatsCtrl1.Bind(race);

            Cursor = Cursors.Default;
        }

        private void SaveCommentsToHorse(string txt)
        {
            if (null != _currentHorse)
            {
                _currentHorse.Comments = txt;
                _currentHorse.UpdateCommentObservers(this);
            }
        }

        private void UpdateHorseNotesGridCells()
        {
            if (null == _race)
            {
                return;
            }

            _race.SpecifyHorsesWithNotes();

            foreach (DataGridViewRow row in _grid.Rows)
            {
                var h = (Horse) row.Tag;
                row.Cells[_horseNotesColumnIndex].Value = h.HasNotes ? "Y" : "";
            }
        }

        public DataTable GetGridAsDataTable()
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in _grid.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }
            foreach (DataGridViewRow row in _grid.Rows)
            {
                var cd = new object[row.Cells.Count];

                for (int i = 0; i < row.Cells.Count; ++i)
                {
                    cd[i] = row.Cells[i].Value;
                }

                dt.Rows.Add(cd);
            }
            return dt;
        }

        public void InitialGridLoad()
        {
            _grid.Rows.Clear();
            var underlinedFont = new Font(_grid.RowsDefaultCellStyle.Font, FontStyle.Underline | FontStyle.Bold);
            _boldFont = new Font(_grid.RowsDefaultCellStyle.Font, FontStyle.Bold);

            _grid.Rows.Add(_race.Horses.Count);

            int rowIndex = 0;
            foreach (Horse h in _race.Horses)
            {
                _grid[_numberColumnIndex, rowIndex].Value = h.ProgramNumber;
                _grid[_nameColumnIndex, rowIndex].Value = h.Name;
                _grid[_valueColumnIndex, rowIndex].Value = h.ValueIndex;
                _grid[_weightColumnIndex, rowIndex].Value = h.WeightIndex;

                PaintIsBetBetCell(rowIndex, h);
                PaintIsDonkeyBetCell(rowIndex, h);

                string jockey = h.CorrespondingBrisHorse.Jockey;
                if (jockey.Length > 12)
                {
                    jockey = jockey.Substring(0, 12);
                }

               
                _grid[_jockeyColumnIndex, rowIndex].Value = jockey;
                string trainer = h.CorrespondingBrisHorse.TrainersFullName;
                if (trainer.Length > 12)
                {
                    trainer = trainer.Substring(0, 12);
                }
                _grid[_trainerColumnIndex, rowIndex].Value = Utilities.CapitalizeOnlyFirstLetter(trainer);
                _grid[_oddsColumnIndex, rowIndex].Value = Odds.Make(h.MorningLineOdds.ToString()).GetOddsToOne();
                _grid[_primePowerColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.PrimePowerRating;
                _grid[_bestRaceRatingColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.BestRecentRaceRating;
                _grid[_bestClassRatingColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.BestRecentClassRating;
                _grid[_quirinSpeedIndexColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.QuirinSpeedPoints;
                _grid[_runningStyleColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.BrisRunStyle;
                _grid[_daysOffColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.DaysSinceLastRace;
                _grid[_racingFrequencyColumnIndex, rowIndex].Value = h.CorrespondingBrisHorse.RacingFrequencyInDays;
                _grid[_horseNotesColumnIndex, rowIndex].Value = h.HasNotes ? "Y" : "";
                _grid.Rows[rowIndex].Tag = h;

                ++rowIndex;
            }
            RefreshGrid();
            SortBy("PrimePower");

            foreach (Horse h in _race.Horses)
            {
                if (h.IsContenter)
                {
                    UpdateRunningLine(h);
                    h._updateRunningLineEvent += UpdateRunningLine;
                }
            }

            _grid.Columns[_primePowerColumnIndex].Visible = false;
            _grid.Columns[_bestRaceRatingColumnIndex].Visible = false;
            _grid.Columns[_bestClassRatingColumnIndex].Visible = false;
            _grid.Columns[_racingFrequencyColumnIndex].Visible = false;

            _grid.Columns[_oddsFromDoubleColumnIndex].Visible = true;
            _grid.Columns[_oddsFromExactaColumnIndex].Visible = true;

            _grid.Columns[_valueColumnIndex].Visible = true;
            _grid.Columns[_weightColumnIndex].Visible = true;
            
        }


        private void PaintIsDonkeyBetCell(int rowIndex, Horse horse)
        {
            if (horse.IsDonkey)
            {
                _grid[_donkeyColumnIndex, rowIndex].Value = Properties.Resources.Donkey;
            }
            else
            {
                _grid[_donkeyColumnIndex, rowIndex].Value = Properties.Resources.ContenderHorse;
            }


        }

        private void PaintIsBetBetCell(int rowIndex, Horse horse)
        {
            if (horse.IsBestBet)
            {
                _grid[_isBestBetColumnIndex, rowIndex].Value = Properties.Resources.Pointer;
            }
            else
            {
                _grid[_isBestBetColumnIndex, rowIndex].Value = Properties.Resources.NonPointer;
            }
        }

        private void UpdateRunningLine(Horse horse)
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.Tag == horse)
                {
                    //UpdateNeuralNetworkDecisions(row, horse);
                    BrisPastPerformance pp = horse.SelectedRunningLine;
                    if (null != pp)
                    {
                        row.Cells[_goldenPaceFigureForThisHorse].Value = pp.GoldenPaceFigureForThisHorse;
                        row.Cells[_goldenPaceFigureIndex].Value = pp.GoldenPaceFigureForTheRace;
                        row.Cells[_goldenFigureForTheWinnerIndex].Value = pp.GoldenFigureForTheWinner;
                        row.Cells[_goldenFigureForThisIndex].Value = pp.GoldenFigureForThisHorse;

                        Color backColor = Color.Black;
                        Color foreColor = Color.White;

                        if (pp.GoldenFigureForTheWinner == -999)
                        {
                            backColor = Color.Gray;
                            foreColor = Color.Gray;
                        }

                        row.Cells[_goldenFigureForTheWinnerIndex].Style.BackColor = backColor;
                        row.Cells[_goldenFigureForTheWinnerIndex].Style.ForeColor = foreColor;
                        row.Cells[_goldenFigureForTheWinnerIndex].Style.SelectionBackColor = backColor;
                        row.Cells[_goldenFigureForTheWinnerIndex].Style.SelectionForeColor = foreColor;

                        backColor = Color.Black;
                        foreColor = Color.White;

                        if (pp.GoldenFigureForThisHorse == -999)
                        {
                            backColor = Color.Gray;
                            foreColor = Color.Gray;
                        }

                        row.Cells[_goldenFigureForThisIndex].Style.BackColor = backColor;
                        row.Cells[_goldenFigureForThisIndex].Style.ForeColor = foreColor;
                        row.Cells[_goldenFigureForThisIndex].Style.SelectionBackColor = backColor;
                        row.Cells[_goldenFigureForThisIndex].Style.SelectionForeColor = foreColor;

                        backColor = Color.DarkTurquoise;
                        foreColor = Color.White;

                        if (pp.GoldenPaceFigureForTheRace == -999)
                        {
                            backColor = Color.Gray;
                            foreColor = Color.Gray;
                        }

                        row.Cells[_goldenPaceFigureForThisHorse].Style.BackColor = backColor;
                        row.Cells[_goldenPaceFigureForThisHorse].Style.ForeColor = foreColor;
                        row.Cells[_goldenPaceFigureForThisHorse].Style.SelectionBackColor = backColor;
                        row.Cells[_goldenPaceFigureForThisHorse].Style.SelectionForeColor = foreColor;

                        row.Cells[_goldenPaceFigureIndex].Style.BackColor = backColor;
                        row.Cells[_goldenPaceFigureIndex].Style.ForeColor = foreColor;
                        row.Cells[_goldenPaceFigureIndex].Style.SelectionBackColor = backColor;
                        row.Cells[_goldenPaceFigureIndex].Style.SelectionForeColor = foreColor;

                        row.Cells[_goldenPaceFigureForThisHorse].Style.Font = _boldFont;
                        row.Cells[_goldenPaceFigureIndex].Style.Font = _boldFont;

                        row.Cells[_goldenFigureForThisIndex].Style.Font = _boldFont;
                        row.Cells[_goldenFigureForTheWinnerIndex].Style.Font = _boldFont;

                        row.Cells[_goldenFigureForThisIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        row.Cells[_goldenFigureForTheWinnerIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        row.Cells[_distanceColumnIndex].Value = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(pp.DistanceInYards);

                       
                    }
                    else
                    {
                        row.Cells[_goldenPaceFigureForThisHorse].Value = "";
                        row.Cells[_goldenPaceFigureIndex].Value = "";
                        row.Cells[_goldenFigureForTheWinnerIndex].Value = "";
                        row.Cells[_goldenFigureForThisIndex].Value = "";
                        row.Cells[_distanceColumnIndex].Value = "";
                    }
                }
            }
        }

        public void RefreshGrid()
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                var horse = (Horse) row.Tag;
                if (null != horse && horse.Scratched)
                {
                    if (horse.Parent.Parent.HideScratches)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }

            PaintAllRows();
        }

        private void PaintAllRows()
        {
            for (int row = 0; row < _grid.Rows.Count; ++row)
            {
                PaintRow(row);
            }
        }

        public void SortBy(string sortingField)
        {
            ListSortDirection direction = ListSortDirection.Descending;
            if (sortingField.CompareTo("Number") == 0 || sortingField.CompareTo("RunningStyle") == 0 || sortingField.CompareTo("Odds") == 0)
            {
                direction = ListSortDirection.Ascending;
            }

            if (_grid.Columns.Count <= 0)
            {
                return;
            }

            _grid.Sort(_grid.Columns[sortingField], direction);
        }

        private void AddColumns()
        {
            _grid.Columns.Clear();
            _numberColumnIndex = _grid.Columns.Add("Number", "P/N");

            _isBestBetColumnIndex = _grid.Columns.Add(new DataGridViewImageColumn());
            _grid.Columns[_isBestBetColumnIndex].Name = "IsBestBet";
            _grid.Columns[_isBestBetColumnIndex].HeaderText = "B";

            _nameColumnIndex = _grid.Columns.Add("Name", "Name");
            _oddsColumnIndex = _grid.Columns.Add("Odds", "M/L");
            _oddsFromExactaColumnIndex = _grid.Columns.Add("OddsFromExacta", "OE");
            _oddsFromDoubleColumnIndex = _grid.Columns.Add("OddsFromDouble", "OD");
            _valueColumnIndex = _grid.Columns.Add("ValueIndex", "VI");
            _weightColumnIndex = _grid.Columns.Add("WeightIndex", "WI");


            //_votesForFavoriteColumnIndex = _grid.Columns.Add("Votes", "Votes");
            //_votesForOddsColumnIndex = _grid.Columns.Add("VO", "VO");
            //_votesTotalsColumnIndex = _grid.Columns.Add("VT", "VT");
            _jockeyColumnIndex = _grid.Columns.Add("Jockey", "Jockey");
            _trainerColumnIndex = _grid.Columns.Add("Trainer", "Trainer");
            _primePowerColumnIndex = _grid.Columns.Add("PrimePower", "P");
            _bestRaceRatingColumnIndex = _grid.Columns.Add("BestRaceRating", "RR");
            _bestClassRatingColumnIndex = _grid.Columns.Add("BestClassRating", "CR");

            _distanceColumnIndex = _grid.Columns.Add("distance", "distance");

            _goldenPaceFigureForThisHorse = _grid.Columns.Add("GoldenFigureIndexForThisHorse", "GoldenFigureIndexForThisHorse");
            _goldenPaceFigureIndex = _grid.Columns.Add("GoldenFigureIndex", "GoldenFigureIndex");
            _goldenFigureForThisIndex = _grid.Columns.Add("GoldenFigureForThis", "GoldenFigureForThis");
            _goldenFigureForTheWinnerIndex = _grid.Columns.Add("GoldenFigureForWinner", "GoldenFigureForWinner");

            _quirinSpeedIndexColumnIndex = _grid.Columns.Add("QuirinSI", "Q");
            _runningStyleColumnIndex = _grid.Columns.Add("RunningStyle", "S");
            _daysOffColumnIndex = _grid.Columns.Add("DaysOff", "Off");
            _racingFrequencyColumnIndex = _grid.Columns.Add("RacingFrequency", "Freq");
            _horseNotesColumnIndex = _grid.Columns.Add("HorseNotes", "N");
            

            _donkeyColumnIndex = _grid.Columns.Add(new DataGridViewImageColumn());
            _grid.Columns[_donkeyColumnIndex].Name = "DonkeyCol";
            _grid.Columns[_donkeyColumnIndex].HeaderText = "DonkeyCol";



//            AddNeuronNetworkDecisionsColumns();

            _grid.Columns[_numberColumnIndex].Width = 30;
            _grid.Columns[_nameColumnIndex].Width = 150;
            _grid.Columns[_oddsColumnIndex].Width = 40;
            _grid.Columns[_oddsFromExactaColumnIndex].Width = 40;

            _grid.Columns[_valueColumnIndex].Width = 40;
            _grid.Columns[_weightColumnIndex].Width = 40;

            

            _grid.Columns[_oddsFromDoubleColumnIndex].Width = 40;
            _grid.Columns[_primePowerColumnIndex].Width = 40;
            _grid.Columns[_bestRaceRatingColumnIndex].Width = 40;
            _grid.Columns[_bestClassRatingColumnIndex].Width = 40;
            _grid.Columns[_quirinSpeedIndexColumnIndex].Width = 40;
            _grid.Columns[_runningStyleColumnIndex].Width = 40;
            _grid.Columns[_daysOffColumnIndex].Width = 40;
            _grid.Columns[_racingFrequencyColumnIndex].Width = 40;
            _grid.Columns[_horseNotesColumnIndex].Width = 40;
            _grid.Columns[_oddsColumnIndex].CellTemplate.ValueType = typeof (double);
            _grid.Columns[_oddsFromExactaColumnIndex].CellTemplate.ValueType = typeof (double);
            _grid.Columns[_oddsFromDoubleColumnIndex].CellTemplate.ValueType = typeof (double);
         
        }

        
        
        private void OnInitialLoad(object sender, EventArgs e)
        {
            
        }

        private string GetHorseNumberFromRow(int row)
        {
            var s = (string) _grid[_numberColumnIndex, row].Value;
            return s.Trim();
        }

        // May 26: The following method is used for positing in forums in BBCode
        public string GetAsBBCode()
        {
            string txt = "[b]Race Number: " + _race.RaceNumber + "[/b]" + Environment.NewLine;
            ;

            const string valueAnPrime = "";
            string prime = "";
            const string value = "";
            int count = 0;
            foreach (var horse in _race.Horses.OrderBy(h => h.CorrespondingBrisHorse.PrimePowerRating * -1))
            {
                if (!horse.Scratched)
                {
                    prime += "[color=red]" + horse.ProgramNumber + ". " + horse.Name + "[/color]" + Environment.NewLine;
                    ++count;
                }

                if(count >=4)
                    break;
            }
            txt += valueAnPrime + prime + value;
            txt += "---------------------------------------------" + Environment.NewLine;
            return txt;
        }

        private void PaintRow(int row)
        {
            Color backcolor = Color.White;
            Color forecolor = Color.Black;
            Horse horse = GetHorseFromRowIndex(row);

            if (null == horse)
            {
                return;
            }

            foreach (DataGridViewCell cell in _grid.Rows[row].Cells)
            {
                cell.Style.BackColor = Color.Beige;
                cell.Style.SelectionBackColor = Color.Beige;
                cell.Style.ForeColor = forecolor;
                cell.Style.SelectionForeColor = forecolor;
            }

            _grid[_valueColumnIndex, row].Value = horse.ValueIndex;
            _grid[_weightColumnIndex, row].Value = horse.WeightIndex;

            _grid.Rows[row].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f);

            _grid[_nameColumnIndex, row].Style.Font = _grid.RowsDefaultCellStyle.Font;

            var boldFont = new Font(_grid.RowsDefaultCellStyle.Font, FontStyle.Bold);
            var boldUnderlinedFont = new Font(_grid.RowsDefaultCellStyle.Font, FontStyle.Bold | FontStyle.Underline);

            var programNumberFont = new Font(_grid.RowsDefaultCellStyle.Font.FontFamily, 20F, FontStyle.Bold);

            _grid[_numberColumnIndex, row].Style.Font = programNumberFont;
            _grid[_numberColumnIndex, row].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid[_numberColumnIndex, row].Style.BackColor = horse.CorrespondingBrisHorse.IsFirstTimeOut ? _FIRST_TIME_OUT_BACK_COLOR : Color.Black;
            _grid[_numberColumnIndex, row].Style.ForeColor = horse.CorrespondingBrisHorse.IsFirstTimeOut ? _FIRST_TIME_OUT_FRONT_COLOR : Color.White;
            _grid[_numberColumnIndex, row].Style.SelectionBackColor = _grid[_numberColumnIndex, row].Style.BackColor;
            _grid[_numberColumnIndex, row].Style.SelectionForeColor = _grid[_numberColumnIndex, row].Style.ForeColor;

            _grid[_oddsColumnIndex, row].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid[_oddsFromExactaColumnIndex, row].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid[_oddsFromDoubleColumnIndex, row].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            _grid[_valueColumnIndex, row].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid[_weightColumnIndex, row].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            
            
            var oddsFont = new Font(_grid.RowsDefaultCellStyle.Font.FontFamily, 8F, FontStyle.Regular);
            _grid[_oddsColumnIndex, row].Style.Font = oddsFont;
            _grid[_oddsFromExactaColumnIndex, row].Style.Font = oddsFont;
            _grid[_oddsFromDoubleColumnIndex, row].Style.Font = oddsFont;

            _grid[_valueColumnIndex, row].Style.Font = oddsFont;
            _grid[_weightColumnIndex, row].Style.Font = oddsFont;
            

            
            _grid[_jockeyColumnIndex, row].Style.Font = oddsFont;
            _grid[_trainerColumnIndex, row].Style.Font = oddsFont;

            bool isPrimeBet = horse.IsAPrimeBet;

            if (horse.Scratched)
            {
                backcolor = Color.Black;
                forecolor = Color.White;
                foreach (DataGridViewCell cell in _grid.Rows[row].Cells)
                {
                    cell.Style.BackColor = backcolor;
                    cell.Style.SelectionBackColor = backcolor;
                    cell.Style.ForeColor = forecolor;
                    cell.Style.SelectionForeColor = forecolor;
                }
            }
            else if (false == horse.IsContenter)
            {
                backcolor = Color.Gray;
                forecolor = Color.Black;
                foreach (DataGridViewCell cell in _grid.Rows[row].Cells)
                {
                    cell.Style.BackColor = backcolor;
                    cell.Style.SelectionBackColor = backcolor;
                    cell.Style.ForeColor = forecolor;
                    cell.Style.SelectionForeColor = forecolor;
                }
            }
            else if (isPrimeBet)
            {
                _grid[_nameColumnIndex, row].Style.Font = boldUnderlinedFont;
                _grid[_nameColumnIndex, row].Style.BackColor = Color.Red;
                _grid[_nameColumnIndex, row].Style.ForeColor = Color.Black;
                _grid[_nameColumnIndex, row].Style.SelectionBackColor = _grid[_nameColumnIndex, row].Style.BackColor;
                _grid[_nameColumnIndex, row].Style.SelectionForeColor = _grid[_nameColumnIndex, row].Style.ForeColor;
            }
            else
            {
                _grid[_nameColumnIndex, row].Style.ForeColor = Color.LightSlateGray;
                _grid[_nameColumnIndex, row].Style.SelectionBackColor = _grid[_nameColumnIndex, row].Style.BackColor;
                _grid[_nameColumnIndex, row].Style.SelectionForeColor = _grid[_nameColumnIndex, row].Style.ForeColor;
                _grid.Rows[row].DefaultCellStyle.BackColor = Color.Beige;
                _grid.Rows[row].DefaultCellStyle.SelectionBackColor = Color.Beige;
                _grid.Rows[row].DefaultCellStyle.ForeColor = Color.LightSlateGray;
                _grid.Rows[row].DefaultCellStyle.SelectionForeColor = Color.LightSlateGray;
            }

            Color layoffColor = Color.White;

            if (horse.FirstAfterLayoff)
            {
                layoffColor = _FIRST_AFTER_LAYOFF_COLOR;
            }
            else if (horse.SecondAfterLayoff)
            {
                layoffColor = _SECOND_AFTER_LAYOFF_COLOR;
            }
            else if (horse.ThirdAfterLayoff)
            {
                layoffColor = _THIRD_AFTER_LAYOFF_COLOR;
            }

            _grid[_daysOffColumnIndex, row].Style.BackColor = layoffColor;
            _grid[_daysOffColumnIndex, row].Style.SelectionBackColor = layoffColor;
            UpdateRunningLine(horse);

            PaintIsBetBetCell(row, horse);

            PaintIsDonkeyBetCell(row, horse);
        }

        private void OnCynhiaProjections(object sender, EventArgs e)
        {
            if (_popupmenu.Tag is Horse)
            {
                try
                {
                    var form = new CynthiaProjectionForm((Horse) _popupmenu.Tag);
                    form.ShowDialog();
                    UpdateHorseNotesGridCells();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnEditWeights(object sender, EventArgs e)
        {
            if (_popupmenu.Tag is Horse)
            {
                try
                {
                    var f = new EditHorseWeightsForm((Horse)_popupmenu.Tag);
                    f.ShowDialog();
                    UpdateHorseNotesGridCells();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnHorseNotes(object sender, EventArgs e)
        {
            if (_popupmenu.Tag is Horse)
            {
                try
                {
                    var f = new HorseNotesForm((Horse) _popupmenu.Tag);
                    f.ShowDialog();
                    UpdateHorseNotesGridCells();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnToggleIsBestBetStatus(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _grid.SelectedRows)
            {
                Horse horse = GetHorseFromRowIndex(row.Index);
                horse.ToggleIsBestBetStatus();
                PaintIsBetBetCell(row.Index, horse);
            }
        }

        private void OnToggleContenterStatus(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _grid.SelectedRows)
            {
                Horse horse = GetHorseFromRowIndex(row.Index);
                horse.ToggleIsContenterStatus();
            }
            RefreshGrid();
        }

        private void OnScratch(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _grid.SelectedRows)
            {
                Horse horse = GetHorseFromRowIndex(row.Index);
                horse.ToggleScratchStatus();
            }
            RefreshGrid();
        }

        private Horse GetHorseFromRowIndex(int index)
        {
            return (Horse) _grid.Rows[index].Tag;
        }

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

        private void ShowHorseDetails(int rowIndex)
        {
            Horse h = (Horse) _grid.Rows[rowIndex].Tag;
            _currentHorse = h;
            _labelHorseDetails.Text = h.ProgramNumber + ". " + h.Name + " ( Days off: " + h.CorrespondingBrisHorse.DaysSinceLastRace.ToString() + " Period: " + h.CorrespondingBrisHorse.PeriodCoveredByPastPerformancesInDays.ToString() + " Freq: " + h.CorrespondingBrisHorse.RacingFrequencyInDays.ToString() + " )";

            
            _showRunTogethersControl.BindHorse(h.CorrespondingBrisHorse);
            _cynthiaParsSummaryCtrl1.BindHorse(h);
            
            _breedingInfoCtrl.BindHorse(h);
            _factorAnalysisCtrl1.Bind(h);

            Form parent = GetParentForm(this);

            if (null != parent)
            {
                parent.Closing += new CancelEventHandler(ParentClosing);
            }
        }

        private void ParentClosing(object sender, CancelEventArgs e)
        {
        }

        private void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in _grid.Rows)
                    {
                        row.Selected = false;
                    }
                    _grid.Rows[e.RowIndex].Selected = true;
                    Rectangle r = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    Horse horse = GetHorseFromRowIndex(e.RowIndex);

                    if (!horse.Scratched)
                    {
                        _popupmenu.Items.Clear();
                        _popupmenu.Items.Add("" + horse.Name);
                        _popupmenu.Items.Add("-");
                        _popupmenu.Items.Add("Scratch", null, OnScratch);
                    }
                    else
                    {
                        _popupmenu.Items.Clear();
                        _popupmenu.Items.Add("" + horse.Name);
                        _popupmenu.Items.Add("-");
                        _popupmenu.Items.Add("Unscratch", null, OnScratch);
                    }

                    if (horse.IsContenter)
                    {
                        _popupmenu.Tag = e.RowIndex;
                        _popupmenu.Items.Add("Is No Contenter", null, OnToggleContenterStatus);
                    }
                    else
                    {
                        _popupmenu.Tag = e.RowIndex;
                        _popupmenu.Items.Add("Is Contenter", null, OnToggleContenterStatus);
                    }

                    if (horse.IsBestBet)
                    {
                        _popupmenu.Tag = e.RowIndex;
                        _popupmenu.Items.Add("Is Not Best Best", null, OnToggleIsBestBetStatus);
                    }
                    else
                    {
                        _popupmenu.Tag = e.RowIndex;
                        _popupmenu.Items.Add("Is Best Best", null, OnToggleIsBestBetStatus);
                    }

                    _popupmenu.Items.Add("-");
                    _popupmenu.Items.Add("Horse Notes", null, OnHorseNotes);
                    _popupmenu.Items.Add("Cynthia Projections", null, OnCynhiaProjections);
                    _popupmenu.Items.Add("-");
                    _popupmenu.Items.Add("Edit Weights", null, OnEditWeights);

                    _popupmenu.Tag = horse;

                    _popupmenu.Show((Control) sender, r.Left + e.X, r.Top + e.Y);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                int trainerIndex = _grid.Columns["Trainer"].Index;
                int jockeyIndex = _grid.Columns["Jockey"].Index;

                if (e.ColumnIndex == 1 && null != _grid.Rows[e.RowIndex].Tag)
                {
                    OnToggleIsBestBetStatus(null, null);
                }
                else if (e.ColumnIndex == 2 && null != _grid.Rows[e.RowIndex].Tag)
                {
                    ShowHorseDetails(e.RowIndex);
                }
                else if (e.ColumnIndex == trainerIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    try
                    {
                        var h = (Horse) _grid.Rows[e.RowIndex].Tag;
                        string trainer = h.CorrespondingBrisHorse.TrainersFullName;
                        var form = new IndividualTrainerStatsForm(h);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else if (e.ColumnIndex == _valueColumnIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    var horse = _grid.Rows[e.RowIndex].Tag as Horse;
                    horse.ValueIndex = horse.ValueIndex + 1;
                    _grid[_valueColumnIndex, e.RowIndex].Value = horse.ValueIndex;
                }

                else if (e.ColumnIndex == _weightColumnIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    var horse = _grid.Rows[e.RowIndex].Tag as Horse;
                    horse.WeightIndex = horse.WeightIndex + 1;
                    _grid[_weightColumnIndex, e.RowIndex].Value = horse.WeightIndex;
                }

                    /*
                else if (e.ColumnIndex == _votesForOddsColumnIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    try
                    {
                        var f = new ShowVotesForAllOddsCategoriesForm(_grid.Rows[e.RowIndex].Tag as Horse);
                        f.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                     */
                else if (e.ColumnIndex == jockeyIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    try
                    {
                        string jockey = ((Horse)_grid.Rows[e.RowIndex].Tag).CorrespondingBrisHorse.Jockey;

                        var f = new ImpactValueForm
                        {
                            ImpactValues = JockeyStatistics.Get(jockey).AllStats,
                            Description = jockey
                        };

                        //f.ShowDialog();
                        f.Show(this);

                        //var form = new JockeyStatisticsForm(jockey);
                        //form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (e.ColumnIndex == _oddsColumnIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    Horse horse = GetHorseFromRowIndex(e.RowIndex);

                    try
                    {
                        var f = new RealTimeOddsHistoryForm(horse, _oddsRetriever.ExactaPayouts);
                        f.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (e.ColumnIndex == 0 && null != _grid.Rows[e.RowIndex].Tag)
                {
                    Horse horse = GetHorseFromRowIndex(e.RowIndex);
                    if (null != horse)
                    {
                        if (_currentHorse != horse)
                        {
                            ShowHorseDetails(e.RowIndex);
                        }

                        var f = new IndividualHorsePastPerformancesForm(horse);
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, something is wrong with this horse!\nPlease check its program number");
                    }
                }
                else if (e.ColumnIndex == _donkeyColumnIndex && null != _grid.Rows[e.RowIndex].Tag)
                {
                    Horse horse = GetHorseFromRowIndex(e.RowIndex);
                    if (null != horse)
                    {

                        var location = Cursor.Position;
                        var l2 = this.PointToClient(location);

                        var f = new HorseFiguresForm(horse);
                        f.Location = location;

                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, something is wrong with this horse!\nPlease check its program number");
                    }
                }
            }
        }

        private void OnShowRacePastPerformances(object sender, EventArgs e)
        {
        }

        private void OnHide(object sender, EventArgs e)
        {
            _race.IsHidden = true;
            UpdateParentEvent(this);
        }

        private void OnShowTrifectas(object sender, EventArgs e)
        {
            var tf = new TrifectaForm(_race);
            tf.Show();
        }

        private void OnSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name.CompareTo("Number") == 0)
            {
                BrisHorse h1 = ((Horse) _grid.Rows[e.RowIndex1].Tag).CorrespondingBrisHorse;
                BrisHorse h2 = ((Horse) _grid.Rows[e.RowIndex2].Tag).CorrespondingBrisHorse;
                int n1 = h1.GetProgramNumberWithoutEntryChar();
                int n2 = h2.GetProgramNumberWithoutEntryChar();
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
            else if (e.Column.Name.CompareTo("PrimePower") == 0)
            {
                BrisHorse h1 = ((Horse) _grid.Rows[e.RowIndex1].Tag).CorrespondingBrisHorse;
                BrisHorse h2 = ((Horse) _grid.Rows[e.RowIndex2].Tag).CorrespondingBrisHorse;
                int n1 = h1.PrimePowerRating;
                int n2 = h2.PrimePowerRating;
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
            else if (e.Column.Name.CompareTo("Odds") == 0)
            {
                var n1 = (double) _grid.Rows[e.RowIndex1].Cells["Odds"].Value;
                var n2 = (double) _grid.Rows[e.RowIndex2].Cells["Odds"].Value;

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
            else if (
                e.Column.Name.CompareTo("figure1") == 0 ||
                e.Column.Name.CompareTo("figure2") == 0 ||
                e.Column.Name.CompareTo("finalfigure") == 0 ||
                e.Column.Name.CompareTo("figure1ForHorse") == 0 ||
                e.Column.Name.CompareTo("figure2ForHorse") == 0 ||
                e.Column.Name.CompareTo("finalfigureForHorse") == 0 ||
                e.Column.Name.CompareTo("Compositefigure1") == 0 ||
                e.Column.Name.CompareTo("Compositefigure2") == 0 ||
                e.Column.Name.CompareTo("CompositeFinalfigure") == 0
                )
            {
                e.Handled = true;
                e.SortResult = 0;
                var h1 = (Horse) _grid.Rows[e.RowIndex1].Tag;
                var h2 = (Horse) _grid.Rows[e.RowIndex2].Tag;
                const int h1IsBiggerThan_h2 = -1;
                const int h2IsBiggerThan_h1 = 1;

                if ((!h1.IsContenter) && (!h2.IsContenter))
                {
                    e.SortResult = 0;
                }
                else if (h1.IsContenter && (!h2.IsContenter))
                {
                    e.SortResult = h1IsBiggerThan_h2;
                }
                else if (h2.IsContenter && (!h1.IsContenter))
                {
                    e.SortResult = h2IsBiggerThan_h1;
                }
                else
                {
                    var f1 = e.CellValue1;
                    var f2 = e.CellValue2;

                    if (f1 is int && f2 is int)
                    {
                        if ((int) f1 > (int) f2)
                        {
                            e.SortResult = -1;
                        }
                        else if ((int) f1 < (int) f2)
                        {
                            e.SortResult = 1;
                        }
                        else
                        {
                            e.SortResult = 0;
                        }
                    }
                    else if (f1 is int)
                    {
                        e.SortResult = -1;
                    }
                    else if (f2 is int)
                    {
                        e.SortResult = 1;
                    }
                    else
                    {
                        e.SortResult = 0;
                    }
                }

                e.Handled = true;
            }
            else if (e.Column.Name.CompareTo("Name") == 0)
            {
                var h1 = (Horse) _grid.Rows[e.RowIndex1].Tag;
                var h2 = (Horse) _grid.Rows[e.RowIndex2].Tag;

                const int h1IsBiggerThan_h2 = -1;
                const int h2IsBiggerThan_h1 = 1;

                if (h1.IsContenter && !h2.IsContenter)
                {
                    e.SortResult = h1IsBiggerThan_h2;
                }
                else if (h2.IsContenter && (!h1.IsContenter))
                {
                    e.SortResult = h2IsBiggerThan_h1;
                }
                else if ((!h2.IsContenter) && (!h1.IsContenter))
                {
                    e.SortResult = 0;
                }
                else // They are both contenters
                {
                    if (h1.IsAPrimeBet && (!h2.IsAPrimeBet))
                    {
                        e.SortResult = h1IsBiggerThan_h2;
                    }
                    else if (h2.IsAPrimeBet && (!h1.IsAPrimeBet))
                    {
                        e.SortResult = h2IsBiggerThan_h1;
                    }
                    else if (h1.IsAPrimeBet && h2.IsAPrimeBet)
                    {
                        e.SortResult = 0;
                    }
                    else // They both are non Prime Bets
                    {
                        e.SortResult = 0;
                    }
                }

                e.Handled = true;
            }
        }

        private void OnShowResults(object sender, EventArgs e)
        {
            // TODO change the date to contain the year...
            string raceTrack = _race.Parent.TrackCode;
            string date = _race.Parent.Date;
            int raceNumber = _race.RaceNumber;
            var f = new RaceResultsForm(raceTrack, date, raceNumber);
            f.ShowDialog();
        }

        private void OnShowAnalysis(object sender, EventArgs e)
        {
        }

        private void OnRaceClassificationCliked(object sender, EventArgs e)
        {
            try
            {
                int distance = _race.CorrespondingBrisRace.DistanceInYards;
                string trackCode = _race.Parent.TrackCode;
                string surface = "D";

                if (_race.CorrespondingBrisRace.Horses[0].TodaysRaceIsInTurf)
                {
                    surface = "T";
                }
                else if (_race.CorrespondingBrisRace.Horses[0].TodaysRaceIsSynthetic)
                {
                    surface = "A";
                }

                bool innerTrack = _race.CorrespondingBrisRace.Horses[0].TodaysRaceIsInInnerTrack;
                string aboutDistanceFlag = _race.CorrespondingBrisRace.IsAboutDistance ? "A" : " ";
                var f = new WinnersTimeForm(trackCode, surface, innerTrack, distance, aboutDistanceFlag);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowFigures(object sender, EventArgs e)
        {
            try
            {
                var f = new BreadAndButterForm(_race, _oddsRetriever);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            _race.LoadFactorPerformances();
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindRace(_race);
        }

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progressBar.Value = e.ProgressPercentage;
        }

        private void OnRaceAttributes(object sender, EventArgs e)
        {
            try
            {

                _race.HandicapBasedInSpeedFigures();
                RefreshGrid();

                /*
                var form = new RaceAttributesForm(_race);

                if (form.ShowDialog() == DialogResult.OK && form.Changed)
                {
                    _progressBar.Visible = true;
                    _progressBar.BringToFront();
                    _race.BGWorker = _backgroundWorker;
                    _backgroundWorker.WorkerSupportsCancellation = true;
                    _backgroundWorker.WorkerReportsProgress = true;

                    _backgroundWorker.RunWorkerAsync();
                }
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != _oddsRetriever)
            {
                _oddsRetriever.StopIt();
                _oddsRetriever = null;
            }
        }

        private void SetGridCellColor(DataGridViewCell cell, Color back, Color fore)
        {
            cell.Style.ForeColor = fore;
            cell.Style.BackColor = back;
            cell.Style.SelectionBackColor = back;
            cell.Style.SelectionForeColor = fore;
        }

        // Based in the highest return in Win - Exacta - Double find 
        // what is the return of a ducthing bet...
        private void CalculateRaceValue()
        {
            Color bestBetForeColor = Color.Blue;
            Color bestBetBackColor = Color.LightBlue;
            Color foreColor = Color.Black;
            Color backColor = Color.White;

            const double amountToWin = 1000.00;
            double amountNeeded = 0.0;

            var horseNumber = new List<int>();

            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.Tag is Horse)
                {
                    var horse = (Horse) row.Tag;

                    if (horse.Scratched)
                    {
                        continue;
                    }

                    double oddsFromWin = (null != row.Cells[_oddsColumnIndex].Value ? (double) row.Cells[_oddsColumnIndex].Value : 0.0);
                    double oddsFromExacta = (null != row.Cells[_oddsFromExactaColumnIndex].Value ? (double) row.Cells[_oddsFromExactaColumnIndex].Value : 0.0);
                    double oddsFromDouble = (null != row.Cells[_oddsFromDoubleColumnIndex].Value ? (double) row.Cells[_oddsFromDoubleColumnIndex].Value : 0.0);

                    double oddsToConsider = 0.0;

                    if (oddsFromWin > oddsFromExacta && oddsFromWin > oddsFromDouble)
                    {
                        oddsToConsider = oddsFromWin;
                        SetGridCellColor(row.Cells[_oddsColumnIndex], bestBetBackColor, bestBetForeColor);
                        SetGridCellColor(row.Cells[_oddsFromExactaColumnIndex], backColor, foreColor);
                        SetGridCellColor(row.Cells[_oddsFromDoubleColumnIndex], backColor, foreColor);
                    }
                    else if (oddsFromExacta > oddsFromWin && oddsFromExacta >= oddsFromDouble)
                    {
                        oddsToConsider = oddsFromExacta;
                        SetGridCellColor(row.Cells[_oddsColumnIndex], backColor, foreColor);
                        SetGridCellColor(row.Cells[_oddsFromExactaColumnIndex], bestBetBackColor, bestBetForeColor);
                        SetGridCellColor(row.Cells[_oddsFromDoubleColumnIndex], backColor, foreColor);
                    }
                    else
                    {
                        oddsToConsider = oddsFromDouble;
                        SetGridCellColor(row.Cells[_oddsColumnIndex], backColor, foreColor);
                        SetGridCellColor(row.Cells[_oddsFromExactaColumnIndex], backColor, foreColor);
                        SetGridCellColor(row.Cells[_oddsFromDoubleColumnIndex], bestBetBackColor, bestBetForeColor);
                    }

                    if (false == horseNumber.Contains(horse.GetProgramNumberWithoutEntryChar()))
                    {
                        horseNumber.Add(horse.GetProgramNumberWithoutEntryChar());
                        amountNeeded += amountToWin/(1.0 + oddsToConsider);
                    }
                }
            }

            
            
        }

        public void UpdateRealTimeOdds()
        {
            if (null != _oddsRetriever)
            {
                ++_REAL_TIME_UPDATES_COUNTER;
                if (_oddsRetriever.ErrorStatus != 0)
                {
                    string msg = _oddsRetriever.ErrorMessage;
                    StopOddsRetriever();
                    MessageBox.Show(msg);

                    return;
                }

                if (_oddsRetriever.PoolWasClosed)
                {

                }

                Dictionary<int, OddsRetriever.RTOdds> odds = _oddsRetriever.RealTimeOdds;
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    var horse = (Horse) row.Tag;
                    int number = horse.GetProgramNumberWithoutEntryChar();
                    if (odds.ContainsKey(number))
                    {
                        Odds oddsToWin = odds[number].OddsToWin;
                        double oddsToOne = oddsToWin.GetOddsToOne();
                        horse.RealTimeOdds = oddsToOne;
                        horse.AddRealTimeOddsToHistory(oddsToWin);
                        row.Cells[_oddsColumnIndex].Value = oddsToOne;

                        /*
                         row.Cells[_votesForOddsColumnIndex].Value = horse.CorrespondingBrisHorse.VotesBasedInOdds;
                        row.Cells[_votesTotalsColumnIndex].Value = horse.CorrespondingBrisHorse.VotesTotal;
                        */
                        Odds oddsFromExacta = odds[number].OddsFromExactas;
                        Odds oddsFromDouble = odds[number].OddsFromDouble;
                        if (null != oddsFromExacta)
                        {
                            row.Cells[_oddsFromExactaColumnIndex].Value = oddsFromExacta.GetOddsToOne();
                        }
                        if (null != oddsFromDouble)
                        {
                            row.Cells[_oddsFromDoubleColumnIndex].Value = oddsFromDouble.GetOddsToOne();
                        }
                    }
                }

                CalculateRaceValue();
                if (_oddsRetriever.PoolWasClosed)
                {
                    
                    StopOddsRetriever();
                }
            }
        }

        private void StopOddsRetriever()
        {
            _oddsRetriever.StopIt();
            //_oddsRetriever = null;
            _buttonRealTimeOdds.Image = Properties.Resources.start_feed;
        }

        private void StartOddsRetriever()
        {
            _oddsRetriever = new OddsRetriever(_race.Parent.TrackCode, _race.RaceNumber);
            _oddsRetriever.UpdateObserverDelegateEvent += UpdateRealTimeOdds;
            _buttonRealTimeOdds.Image = Properties.Resources.stop_feed;
        }

        private void OnStartRealTimeOddsFeed(object sender, EventArgs e)
        {
            if (null == _oddsRetriever)
            {
                StartOddsRetriever();
            }
            else
            {
                StopOddsRetriever();
            }
        }

        private void OnExactaPayouts(object sender, EventArgs e)
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

        private void OnDoublePayouts(object sender, EventArgs e)
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

        private void OnShowSuperfectaStudio(object sender, EventArgs e)
        {
            try
            {
                var f = new SuperStudioForm(_race, _superfectaSystem);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _factorPerfomanceCtrl1_Load(object sender, EventArgs e)
        {
        }

        private void _buttonMakeRaceUnplayable_Click(object sender, EventArgs e)
        {
        }

        private void _buttonShowRaceFilters_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new FiltersForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    f.SelectedFilters.ForEach(fi => fi.Apply(_race));
                    _race.Parent.Save();
                    RefreshGrid();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _buttonClearSelections_Click(object sender, EventArgs e)
        {
            try
            {
                _race.Horses.ForEach(h =>
                                         {
                                             h.IsContenter = true;
                                             h.IsBestBet = false;
                                         });
                _race.Parent.Save();
                RefreshGrid();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void OnSpeedAnalysis(object sender, EventArgs e)
        {
            try
            {
                var f = new RaceAnalyzerForm(_race);
                f.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ButtonShowKeyRacesClick(object sender, EventArgs e)
        {
            var keyRacesForm = new KeyRacesForm(_race);
            keyRacesForm.ShowDialog();
           
        }

        private void _panelHorseDetails_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}