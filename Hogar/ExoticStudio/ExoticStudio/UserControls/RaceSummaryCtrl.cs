using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ExoticStudio
{
    public partial class RaceSummaryCtrl : UserControl
    {
        DailyProgram _program = new DailyProgram();

        int _currentRaceIndex = -1;

        string _filename = "";

        public RaceSummaryCtrl()
        {
            InitializeComponent();
        }

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        public void LoadRace(int raceIndex)
        {
            _program.Load(_filename);
            _currentRaceIndex = raceIndex;
            Race race = _program.GetRace(_currentRaceIndex);

            _grid.ColumnCount = 6;
            _grid.RowCount = race.NumberOfHorses;

            for (int col = 0; col < _grid.Columns.Count; ++col)
            {
                _grid.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < race.NumberOfHorses; ++i)
            {
                Horse horse = race[i];

                if (horse.WasScratched)
                {
                    continue;
                }

                _grid[0, i].Value = race[i].ProgramNumber;
                _grid[1, i].Value = race[i].Odds;
                _grid[2, i].Value = race[i].Name;
                _grid[3, i].Value = race[i].Jockey;
                _grid[4, i].Value = race[i].Weight;
                _grid[5, i].Value = race[i].Trainer;
            }

            _raceNumberTextBox.Text = race[0].RaceNumber.ToString();

            _raceTrackTextBox.Text = race[0].RaceTrack;

            _dateTextBox.Text = race[0].Date;
        }

        int GetHorseNumber(int rowIndex)
        {
            return Convert.ToInt32(_grid[0, rowIndex].Value.ToString());
        }

        void OnInitialLoad(object sender, EventArgs e)
        {

        }
    }


    public class Token
    {
        readonly string _txt;

        static readonly char _textDelimeter = '"';

        public Token(string txt)
        {
            _txt = txt.Trim();
        }

        public override string ToString()
        {
            return IsNumeric ? _txt : _txt.Replace(_textDelimeter, ' ').Trim();
        }

        public int Length
        {
            get
            {
                return _txt.Length;
            }
        }

        bool IsNumeric
        {
            get
            {
                return (Length <= 0) ? true : _txt[0] != _textDelimeter;
            }
        }
    }



    public class ParsableText
    {
        readonly string _strg;

        static readonly char _commaDelimeter = ',';

        int _index = 0;

        public ParsableText(string txt)
        {
            _strg = txt;
        }

        public List<Token> Tokens
        {
            get
            {
                List<Token> t = new List<Token>();

                PrepareForParsing();

                while (!ReachedEnd)
                {
                    t.Add(GetNextToken());
                }

                return t;
            }
        }

        bool ReachedEnd
        {
            get
            {
                return _index >= _strg.Length;
            }
        }

        void PrepareForParsing()
        {
            _index = 0;
        }

        Token GetNextToken()
        {

            int pos = _strg.IndexOf(_commaDelimeter, _index);

            Token token = null;

            if (pos < 0)
            {
                token = new Token(_strg.Substring(_index));
                _index += token.Length + 1;

            }
            else
            {
                token = new Token(_strg.Substring(_index, pos - _index));
                _index = pos + 1;
            }

            return token;
        }
    }

    public class Race
    {
        int _raceNumber;

        List<Horse> _horse = new List<Horse>();

        public Race(int raceNumber)
        {
            _raceNumber = raceNumber;
        }

        public int RaceNumber
        {
            get
            {
                return _raceNumber;
            }
        }

        public void Add(Horse horse)
        {
            if (!horse.WasScratched)
            {
                _horse.Add(horse);
            }
        }

        public Horse this[int index]
        {
            get
            {
                return _horse[index];
            }
        }

        public int NumberOfHorses
        {
            get
            {
                return _horse.Count;
            }
        }



    }

    public class Horse
    {
        ParsableText _pt = null;

        int RACE_TRACK_INDEX = 0;
        int RACE_NUMBER_INDEX = 2;
        int ENTRY_INDEX = 4;
        int DATE_INDEX = 1;

        int JOCKEY_NAME_INDEX = 32;
        int PROGRAM_NUMBER_INDEX = 42;
        int ODDS_INDEX = 43;
        int HORSE_NAME_INDEX = 44;
        int WEIGHT_INDEX = 50;

        // Trainer 

        int TRAINER_INDEX = 27;
        int TRAINER_STARTS_INDEX = 28;
        int TRAINER_WINS_INDEX = 29;
        int TRAINER_PLACES_INDEX = 30;
        int TRAINER_SHOWS_INDEX = 31;

        string CapitalizeOnlyFirstLetter(string txt)
        {
            string returnValue = "";

            txt = txt.Trim();

            bool insideAWord = false;

            for (int i = 0; i < txt.Length; ++i)
            {
                if (i == 0)
                {
                    returnValue += txt[i].ToString().ToUpper();
                    insideAWord = true;
                }
                else if (txt[i] == ' ')
                {
                    insideAWord = false;
                    returnValue += ' ';

                }
                else
                {
                    if (insideAWord)
                    {
                        returnValue += txt[i].ToString().ToLower();
                    }
                    else
                    {
                        returnValue += txt[i].ToString().ToUpper();
                        insideAWord = true;
                    }
                }
            }

            return returnValue;
        }


        public Horse(ParsableText pt)
        {
            _pt = pt;
        }

        public string Date
        {
            get
            {
                return _pt.Tokens[DATE_INDEX].ToString();
            }
        }

        public bool WasScratched
        {
            get
            {
                return Entry == "S";
            }
        }

        public int Weight
        {
            get
            {
                return Convert.ToInt32(_pt.Tokens[WEIGHT_INDEX].ToString());
            }
        }

        public string Jockey
        {
            get
            {
                return CapitalizeOnlyFirstLetter(_pt.Tokens[JOCKEY_NAME_INDEX].ToString());
            }
        }

        public string Entry
        {
            get
            {
                return _pt.Tokens[ENTRY_INDEX].ToString();
            }
        }

        public string RaceTrack
        {
            get
            {
                return _pt.Tokens[RACE_TRACK_INDEX].ToString();
            }
        }

        public int RaceNumber
        {
            get
            {
                return Convert.ToInt32(_pt.Tokens[RACE_NUMBER_INDEX].ToString());
            }
        }

        public string Name
        {
            get
            {

                return CapitalizeOnlyFirstLetter(_pt.Tokens[HORSE_NAME_INDEX].ToString());
            }
        }
        public string ProgramNumber
        {
            get
            {
                return _pt.Tokens[PROGRAM_NUMBER_INDEX].ToString();
            }
        }

        double TrainersWinningPercentage
        {
            get
            {
                if (Convert.ToDouble(_pt.Tokens[TRAINER_STARTS_INDEX].ToString()) <= 0.0)
                {
                    return 0;

                }
                return (Convert.ToDouble(_pt.Tokens[TRAINER_WINS_INDEX].ToString()) / Convert.ToDouble(_pt.Tokens[TRAINER_STARTS_INDEX].ToString()));

            }
        }


        public string Trainer
        {
            get
            {

                string txt = "";

                txt = _pt.Tokens[TRAINER_INDEX].ToString() + " ";
                txt += String.Format("{0:0.00}", TrainersWinningPercentage * 100) + "% ";
                txt += " (";
                txt += _pt.Tokens[TRAINER_STARTS_INDEX].ToString() + " ";
                txt += _pt.Tokens[TRAINER_WINS_INDEX].ToString() + " ";
                txt += _pt.Tokens[TRAINER_PLACES_INDEX].ToString() + " ";
                txt += _pt.Tokens[TRAINER_SHOWS_INDEX].ToString() + " ";
                txt += ")";

                return CapitalizeOnlyFirstLetter(txt);
            }
        }

        public double Odds
        {
            get
            {
                if (_pt.Tokens[ODDS_INDEX].ToString().Length <= 0)
                {
                    return 0;
                }
                return Convert.ToDouble(_pt.Tokens[ODDS_INDEX].ToString());
            }
        }
    }

    public class DailyProgram
    {
        List<Race> _race = new List<Race>();

        public int NumberOfRaces
        {
            get
            {
                return _race.Count;
            }
        }

        public Race GetRace(int index)
        {
            return _race[index];
        }

        public void Load(string filename)
        {
            StreamReader sr = new StreamReader(filename);

            List<ParsableText> txt = new List<ParsableText>();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                txt.Add(new ParsableText(line));

            }
            sr.Close();

            Race currentRace = null;

            foreach (ParsableText p in txt)
            {
                Horse horse = new Horse(p);

                if ((currentRace == null) || (horse.RaceNumber != currentRace.RaceNumber))
                {
                    Race race = new Race(horse.RaceNumber);
                    currentRace = race;
                    _race.Add(race);
                }

                currentRace.Add(horse);

            }
        }

    }


}
