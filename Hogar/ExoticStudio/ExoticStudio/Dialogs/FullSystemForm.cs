using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;



namespace ExoticStudio
{
    public partial class FullSystemForm : Form
    {
        int _numberOfRaces = 0;

        FullSystem _fullSystem = null;

        bool _isLoading = false;

        public FullSystemForm(int numberOfRaces, FullSystem fullSystem)
        {
            _numberOfRaces = numberOfRaces;
            _fullSystem = fullSystem;

            InitializeComponent();
        }

        public FullSystem GetFullSystem()
        {
            return (null == _fullSystem) ? CreateNewFullSystem() : ModifyFullSystem();
        }

        public double AverageNumberOfHorsesPerRace { get; private set; }

        public int UnitBet
        {
            get
            {
                if (null == this._unitBetComboBox.SelectedItem)
                {
                    return -1;
                }
                return Convert.ToInt32(this._unitBetComboBox.SelectedItem.ToString());
            }
        }

        public int FirstRace
        {
            get
            {
                if (null == this._firstRaceCombo.SelectedItem)
                {
                    return -1;
                }
                return Convert.ToInt32(this._firstRaceCombo.SelectedItem.ToString());
            }
        }
        
        FullSystem CreateNewFullSystem()
        {
            FullSystem s = FullSystem.Make(_numberOfRaces, RaceTrack, Date, FirstRace, UnitBet,AverageNumberOfHorsesPerRace);

            for (int row = 0; row < this._numberOfRaces; ++row)
            {
                for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
                {
                    if (this._grid[col, row].Style.BackColor == Tools.SELECTED_BACKGROUND_COLOR)
                    {
                        int horseNumber = col + 1;

                        s.AddHorse(row, horseNumber);
                    }
                }
            }

         
            return s;
        }

        FullSystem ModifyFullSystem()
        {
            FullSystem temp = CreateNewFullSystem();

            _fullSystem.CopyMainSelections(temp);
            return _fullSystem;
        }

        void UpdateRaceNumbers()
        {
            for (int row = 0; row < _numberOfRaces; ++row)
            {
                this._grid.Rows[row].HeaderCell.Value = (row +  FirstRace).ToString();
            }
        }

        void OnLoad(object sender, EventArgs e)
        {
            _isLoading = true;
            bool selected = false;
            

            
            
            foreach (var trackCode in new string[] {"AQU", "BEL", "SAR","MTH"} )
            {
                int index = _raceTrackComboBox.Items.Add(trackCode);

                if (_fullSystem != null && trackCode.CompareTo(_fullSystem.RaceTrack) == 0)
                {
                    _raceTrackComboBox.SelectedIndex = index;
                    selected = true;
                }
            }

            if (false == selected)
            {
                _raceTrackComboBox.SelectedIndex = 0;
            }

            selected = false;

            for (int i = 0; i < 12; ++i)
            {
                _firstRaceCombo.Items.Add((i+1).ToString());

                if (_fullSystem != null && (i+1) == _fullSystem.FirstRace)
                {
                    _firstRaceCombo.SelectedIndex = i;
                    selected = true;
                }
            }

            if (false == selected)
            {
                _firstRaceCombo.SelectedIndex = 0;
            }


            UpdateUnitBetComboBox();

            this._grid.ColumnCount = Tools.MAX_NUMBER_OF_HORSES_PER_RACE;
            this._grid.RowCount = _numberOfRaces;

            for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
            {
                this._grid.Columns[col].Width = 40;
                this._grid.Columns[col].HeaderText = (col + 1).ToString();
            }

            for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
            {
                _grid.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;

                for (int row = 0; row < _numberOfRaces; ++row)
                {
                    this._grid.Rows[row].Height = 40;
                    this._grid[col, row].Value = col+1;
                }
            }

            if (null != _fullSystem)
            {
                UpdateDisplay();
            }

           EnableOKButton();

           _isLoading = false;
        }

        public static void ParseDateString(string date, ref int year, ref int month, ref int day)
        {
            string[] s = date.Split('/');

            if (s.Length != 3)
            {
                throw new Exception("Invalid date format: " + date);
            }

            month = Convert.ToInt32(s[0]);
            day = Convert.ToInt32(s[1]);
            year = Convert.ToInt32(s[2]);
        }
        void UpdateUnitBetComboBox()
        {

            for (int i = 1; i < 20; ++i)
            {
                _unitBetComboBox.Items.Add(i);
            }
            if (_fullSystem == null)
            {
                _unitBetComboBox.SelectedIndex = 0;
            }
            else
            {

                int year = 0, month = 0, day = 0;

                ParseDateString(_fullSystem.Date, ref year, ref month, ref day);

                _dateTimePicker.Value = new DateTime(year, month, day);

                for (int i = 0; i < _unitBetComboBox.Items.Count; ++i)
                {
                    int v = Convert.ToInt32(_unitBetComboBox.Items[i].ToString());

                    if (v == _fullSystem.UnitBet)
                    {
                        _unitBetComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            
        }

        void UpdateDisplay()
        {
            if (null == _fullSystem)
            {
                return;
            }

            for (int row = 0; row < this._numberOfRaces; ++row)
            {
                for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
                {
                    

                    if (_fullSystem.GetRaceSelection(row).ContainsHorse(col + 1))
                    {
                        _grid[col, row].Style.BackColor = Tools.SELECTED_BACKGROUND_COLOR;
                        _grid[col, row].Style.ForeColor = Tools.SELECTED_FORE_COLOR;

                        _grid[col, row].Style.SelectionBackColor = Tools.SELECTED_BACKGROUND_COLOR;
                        _grid[col, row].Style.SelectionForeColor = Tools.SELECTED_FORE_COLOR;
                    }
                    else
                    {
                        _grid[col, row].Style.BackColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                        _grid[col, row].Style.ForeColor = Tools.UNSELECTED_FORE_COLOR;

                        _grid[col, row].Style.SelectionBackColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                        _grid[col, row].Style.SelectionForeColor = Tools.UNSELECTED_FORE_COLOR;
                    }
                }
            }

            this.UpdateNumberOfCombinations();
        }

        void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading == false)
            {
                EnableOKButton();
                UpdateRaceNumbers();
            }
        }

        void OnMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            DataGridViewSelectedCellCollection d = this._grid.SelectedCells;

            for (int i = 0; i < d.Count; ++i)
            {
                if (d[i].Style.BackColor == Tools.SELECTED_BACKGROUND_COLOR)
                {
                    d[i].Style.SelectionBackColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                    d[i].Style.SelectionForeColor = Tools.UNSELECTED_FORE_COLOR;

                    d[i].Style.BackColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                    d[i].Style.ForeColor = Tools.UNSELECTED_FORE_COLOR;

                }
                else
                {
                    d[i].Style.SelectionBackColor = Tools.SELECTED_BACKGROUND_COLOR;
                    d[i].Style.SelectionForeColor = Tools.SELECTED_FORE_COLOR;

                    d[i].Style.BackColor = Tools.SELECTED_BACKGROUND_COLOR;
                    d[i].Style.ForeColor = Tools.SELECTED_FORE_COLOR;
                }
            }

            EnableOKButton();
            UpdateNumberOfCombinations();
        }

        void UpdateNumberOfCombinations()
        {
            this._numberOfCombinationsTextBox.Text = this.NumberOfCombinations.ToString();
            UpdateRaceNumbers();
        }

        void OnOK(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        int NumberOfCombinations
        {
            get
            {

                if (CountSelectedRaces != _numberOfRaces)
                {
                    return 0;
                }

                int count = 1;

                for (int row = 0; row < this._numberOfRaces; ++row)
                {
                    int selections = 0;
                    for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
                    {
                        if (this._grid[col, row].Style.BackColor == Tools.SELECTED_BACKGROUND_COLOR)
                        {
                            ++selections;
                        }
                    }

                    Debug.Assert(selections > 0);

                    count *= selections;
                    
                }

                return count;
            }
        }


        int CountSelectedRaces
        {
            get
            {
                int count = 0;

                for (int row = 0; row < this._numberOfRaces; ++row)
                {
                    for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
                    {

                        if (_grid != null && _grid[col, row] != null && this._grid[col, row].Style.BackColor == Tools.SELECTED_BACKGROUND_COLOR)
                        {
                            ++count;
                            break;
                        }
                    }
                }

                return count;
            }
        }

        DateTime Date
        {
            get
            {
                return _dateTimePicker.Value;
                //return this._dateTimePicker.Value.ToString("d");
            }
        }

        string RaceTrack
        {
            get
            {
                return (null == this._raceTrackComboBox.SelectedItem) ? "" : _raceTrackComboBox.SelectedItem.ToString();
            }
        }

        void EnableOKButton()
        {
            
            this._OKButton.Enabled = RaceTrack.Length > 0 && FirstRace > 0 && CountSelectedRaces == this._numberOfRaces &&UnitBet >=1;
        }

        void OnTrackComboBoxIndexChanged(object sender, EventArgs e)
        {
            EnableOKButton();
        }

        void OnReset(object sender, EventArgs e)
        {
            for (int row = 0; row < this._numberOfRaces; ++row)
            {
                for (int col = 0; col < Tools.MAX_NUMBER_OF_HORSES_PER_RACE; ++col)
                {
                    this._grid[col, row].Style.BackColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                    this._grid[col, row].Style.ForeColor = Tools.UNSELECTED_FORE_COLOR;
                }
            }

            this.UpdateNumberOfCombinations();    
        }

        private void OnUnitBetChanged(object sender, EventArgs e)
        {
            if (this._isLoading)
            {
                return;
            }
            EnableOKButton();
        }

        private void OnGridMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hti;

            if (e.Button == MouseButtons.Right)
            {

                Hti = _grid.HitTest(e.X, e.Y);

                if (Hti.Type == DataGridViewHitTestType.Cell)
                {
                    int raceNumber = Hti.RowIndex + FirstRace - 1;

                    FullSystem fs = Program.GetMainForm().GetFullSystem();

                    if (null == fs)
                    {
                        return;
                    }

                    MessageBox.Show("Right Click Handler not implemented");
                }

            }
        }


        void SelectCell(DataGridViewCell cell)
        {
            cell.Style.SelectionBackColor = Tools.SELECTED_BACKGROUND_COLOR;
            cell.Style.SelectionForeColor = Tools.SELECTED_FORE_COLOR;
            cell.Style.BackColor = Tools.SELECTED_BACKGROUND_COLOR;
            cell.Style.ForeColor = Tools.SELECTED_FORE_COLOR;
        }

        

        private void _buttonAutoSelectFromWeightsFile_Click(object sender, EventArgs e)
        {
            
            var rc = RaceCard.CreateFromXml(RaceTrack, _dateTimePicker.Value);

            if(null == rc)
            {
                MessageBox.Show("Sorry, selection file not available");
                return;
            }

            OnReset(null, null);

            int row = 0;
            int totalNumberOfHorses = 0;

            for(int rn = FirstRace; rn < FirstRace + _numberOfRaces; ++rn, ++row)
            {
                var race = rc.GetRace(rn);

                if(null == race)
                    break;

                totalNumberOfHorses += race.TotalHorseCount; 

                foreach(var horse in race.Horses)
                {
                    SelectCell(_grid[horse.ProgramNumber - 1, row]);
                }
            }

            AverageNumberOfHorsesPerRace = (double) totalNumberOfHorses/(double) _numberOfRaces;
            
            EnableOKButton();
            UpdateNumberOfCombinations();   
        }

        
    }
}
