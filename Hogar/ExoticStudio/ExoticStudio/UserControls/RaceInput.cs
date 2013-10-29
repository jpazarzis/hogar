using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExoticStudio
{
    public partial class RaceInput : UserControl
    {
        Limitation _limitation = null;

        const int _columnWidth = 20;

        int _limitationIndex = -1;

        int _groupIndex = -1;


        static Limitation _clipedLimitation = null;

        public RaceInput()
        {
            InitializeComponent();
            UpdateButtons();
            
        }

        private void UpdateButtons()
        {
            if (null == _limitation)
            {
                _deleteLimitationButton.Enabled = false;
                _copyLimitationButton.Enabled = false;
                _pasteButton.Enabled = false;
                _chBoxIsLimitationEnabled.Enabled = false;
            }
            else
            {
                _deleteLimitationButton.Enabled = _groupIndex >= 0 && _limitationIndex >= 0;
                _copyLimitationButton.Enabled = _groupIndex >= 0 && _limitationIndex >= 0;
                _pasteButton.Enabled = _groupIndex >= 0 && _limitationIndex >= 0 && RaceInput._clipedLimitation != null;
                _chBoxIsLimitationEnabled.Enabled = _groupIndex >= 0 && _limitationIndex >= 0;
                _chBoxIsLimitationEnabled.Checked = _limitation.Enabled;

                if (!_limitation.Enabled)
                {
                    this.BackColor = Color.SlateGray;
                }
                else
                {
                    this.BackColor = SystemColors.Control;
                }


            }

        }

        public int GroupIndex
        {
            get
            {
                return _groupIndex;
            }
            set
            {
                _groupIndex = value;
            }
        }

        public int LimitationIndex
        {
            get
            {
                return _limitationIndex;
            }
            set
            {
                _limitationIndex = value;
            }
        }

        public void BindLimitation(Limitation s)
        {
            _limitation = s;
            LoadData(0,0);
            UpdateButtons();
            UpdateRaceNumbers();
            UpdateMatchingListView();

            if (!(_limitation is FullSystem))
            {
                _limitation.Parent = this;
            }
        }

        public void UpdateMatchingListView()
        {

            if (_limitation is FullSystem)
            {
                return;
            }

            _matchesListView.Items.Clear();

            if (null != _limitation)
            {
                Dictionary<int, int> matches = _limitation.MatchesWithDevelopedSystem;

                if (null == matches)
                {
                    return;
                }

                foreach (int m in matches.Keys)
                {
                    int count = matches[m];

                    string s = m.ToString() + ": " + count.ToString();

                    _matchesListView.Items.Add(s);

                    

                }

            }

        }

        private void UpdateRaceNumbers()
        {
            if (null == _limitation)
            {
                return;
            }

            for (int row = 0; row < _limitation.NumberOfRaces; ++row)
            {
                _grid.Rows[row].HeaderCell.Value = (row + _limitation.FirstRace).ToString();                
            }
        }

        private int GetMaxCols()
        {
            Debug.Assert(null != _limitation);

            int cols = 0;

            for (int race = 0; race < _limitation.Count(); ++race)
            {
                if (_limitation.GetRaceSelection(race).Count > cols)
                {
                    cols = _limitation.GetRaceSelection(race).Count;
               }
            }

            return cols;
        }

        private void LoadComboBox(ComboBox cb, int selection)
        {
            Debug.Assert(null != _limitation);

            cb.Items.Clear();

            for (int i = -1; i < _limitation.Count(); ++i)
            {
                int index = cb.Items.Add((i + 1).ToString());

                if ((i + 1) == selection)
                {
                    cb.SelectedIndex = index;
                }
            }
        }

        private void UpdateComboBoxes()
        {
            Debug.Assert(null != _limitation);

            LoadComboBox(_fromComboBox, _limitation.MinMatches);
            LoadComboBox(_toComboBox, _limitation.MaxMatches);

            if (_limitation is FullSystem)
            {
                _fromComboBox.Enabled = false;
                _toComboBox.Enabled = false;

                
            }
        }


        private void LoadData(int selectedRow, int selectedHorse)
        {
            if (_limitation == null)
            {
                _grid.Rows.Clear();
                return;
            }


            if (_limitation is FullSystem)
            {
                _indexTextBox.Visible = false;
                _deleteLimitationButton.Visible = false;

                _copyLimitationButton.Visible = false;
                _pasteButton.Visible = false;
                _chBoxIsLimitationEnabled.Visible = false;
            }
            else
            {
                _indexTextBox.Text = _limitationIndex.ToString();

                _chBoxIsLimitationEnabled.Checked = _limitation.Enabled;
            }
            

            _grid.Rows.Clear();

            this._grid.ColumnCount = GetMaxCols();
            this._grid.RowCount = _limitation.Count();

            for (int race = 0; race < _limitation.Count(); ++race)
            {
                RaceSelection r = _limitation.GetRaceSelection(race);

                for (int i = 0; i < r.Count; ++i)
                {
                    this._grid.Columns[i].Width = _columnWidth;
                    this._grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this._grid[i, race].Value = r.Get(i).ToString();

                    if (_limitation is FullSystem)
                    {
                        continue;
                    }


                    Color backColor, forecolor;

                    if (r.IsHorseMarked(r.Get(i)))
                    {
                        this._grid[i, race].Style.BackColor = Tools.SELECTED_BACKGROUND_COLOR;
                        this._grid[i, race].Style.ForeColor = Tools.SELECTED_FORE_COLOR;
                        
                        backColor = Tools.SELECTED_BACKGROUND_COLOR;
                        forecolor = Tools.SELECTED_FORE_COLOR;

                        if (selectedHorse == 0)
                        {
                            selectedHorse = r.Get(i);
                        }
                    }
                    else
                    {
                        this._grid[i, race].Style.BackColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                        this._grid[i, race].Style.ForeColor = Tools.UNSELECTED_FORE_COLOR;

                        backColor = Tools.UNSELECTED_BACKGROUND_COLOR;
                        forecolor = Tools.UNSELECTED_FORE_COLOR;

                        if (selectedHorse == 0)
                        {
                            selectedHorse = r.Get(i);
                        }
                    }

                    if (race == selectedRow && r.Get(i) == selectedHorse)
                    {
                        this._grid[i, race].Selected = true;

                        this._grid[i, race].Style.SelectionBackColor = backColor;
                        this._grid[i, race].Style.SelectionForeColor = forecolor;
                    }

                }

                UpdateRaceNumbers();
            }

            UpdateComboBoxes();


            _updateButtonsTimer.Start();

            
        }

        private void SystemScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void ChangeSelectionStatus()
        {
            if (_limitation is FullSystem)
            {
                return;
            }

            int index = _grid.SelectedCells[0].RowIndex;
            int horse = Convert.ToInt32((string)_grid.SelectedCells[0].Value);


            if (horse == 0)
            {
                _grid.SelectedCells[0].Style.SelectionForeColor = Color.White;
                _grid.SelectedCells[0].Style.SelectionBackColor = Color.White;
                return;
            }

            _limitation.GetRaceSelection(index).ToggleSelectionForHorse(horse);

            LoadData(index, horse);

        }

        
        private void OnGridClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            ChangeSelectionStatus();    
        }

        private void OnFromChanged(object sender, EventArgs e)
        {
            _limitation.MinMatches = Convert.ToInt32(_fromComboBox.SelectedItem.ToString());

        }

        private void OnToChanged(object sender, EventArgs e)
        {
            _limitation.MaxMatches = Convert.ToInt32(_toComboBox.SelectedItem.ToString());
        }

        private void OnDeleteLimitation(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("You are sure that you want to delete the limitation?", "Delete Limitation", MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
            {
                Program.GetMainForm().DeleteLimitation(_groupIndex, _limitationIndex);
            }
            
        }

        private void OnPaste(object sender, EventArgs e)
        {
            Debug.Assert(null != RaceInput._clipedLimitation);
            Program.GetMainForm().CopyLimitation(_groupIndex, _limitationIndex, RaceInput._clipedLimitation);
        }

        private void OnCopy(object sender, EventArgs e)
        {
            RaceInput._clipedLimitation = _limitation.CreateDeepCopy();
        }

        private void OnUpdateButtonsTimer(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void OnShowRaceSummary(object sender, EventArgs e)
        {
            MessageBox.Show(_grid.SelectedRows[0].HeaderCell.Value.ToString());
        }

        

        private void OnGridMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hti;

            if (e.Button == MouseButtons.Right)
            {

                Hti = _grid.HitTest(e.X, e.Y);

                if (Hti.Type == DataGridViewHitTestType.Cell)
                {
                    int raceNumber = Hti.RowIndex + _limitation.FirstRace-1;

                    FullSystem fs = Program.GetMainForm().GetFullSystem();

                    if (null == fs)
                    {
                        return;
                    }

                    MessageBox.Show("Right Click Handler not implemented");
                }

            }
        }

        private void _chBoxIsLimitationEnabled_Click(object sender, EventArgs e)
        {
            if (null != _limitation)
            {
                _limitation.Enabled = !_limitation.Enabled;
                _limitation.LimitationNeedsToBeCounted = true;
                _limitation.LimitationNeedsToBeSaved = true;
            }
        }


        
    }
}
