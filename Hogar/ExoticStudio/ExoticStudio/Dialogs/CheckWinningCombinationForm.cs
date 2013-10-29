using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExoticStudio
{
    public partial class CheckWinningCombinationForm : Form
    {
        private readonly FullSystem _fullSystem = null;

        private DataSet _winningCombination = null;

        public CheckWinningCombinationForm(FullSystem fs)
        {
            _fullSystem = fs;

            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Debug.Assert(null != _fullSystem);
            LoadWinningCombinationGrid();   
        }

        private DataSet GetWiningCombination()
        {
            _winningCombination = new DataSet();

            DataTable dataTable = _winningCombination.Tables.Add();
            DataTable rowHeaderDataTable = _winningCombination.Tables.Add();


            dataTable.Columns.Add("Winner", typeof(int));
            rowHeaderDataTable.Columns.Add("Header", typeof(string));

            for (int row = 0; row < _fullSystem.NumberOfRaces; ++row)
            {
                dataTable.Rows.Add(0);
                rowHeaderDataTable.Rows.Add((row +_fullSystem.FirstRace).ToString());                
            }

            return _winningCombination;
        }

        private void UpdateRowHeadersForWinningCombinationGrid(DataTable dt)
        {
            for (int i = 0; i < _fullSystem.NumberOfRaces; ++i)
            {
                _winningComboGrid.Rows[i].HeaderCell.Value = dt.Rows[i][0].ToString();
            }
        }

        private void LoadWinningCombinationGrid()
        {
            _winningComboGrid.DataSource = GetWiningCombination().Tables[0];
            UpdateRowHeadersForWinningCombinationGrid(GetWiningCombination().Tables[1]);
        }

        private void OnSelectWinners(object sender, EventArgs e)
        {
            _grid.DataSource = null;
            _tbMatchesCount.Text = "";

            Limitation winningCombination = new Limitation(_fullSystem.NumberOfRaces, _fullSystem.FirstRace);


            for (int i = 0; i < _fullSystem.NumberOfRaces; ++i)
            {
                int horseNumber = Convert.ToInt32(_winningComboGrid[0, i].Value.ToString());

                winningCombination.GetRaceSelection(i).AddHorse(horseNumber);        
                winningCombination.GetRaceSelection(i).ToggleSelectionForHorse(horseNumber);
            }

            int winningTicketIndex = _fullSystem.GetWinningTicket(winningCombination);

            if (winningTicketIndex <= 0)
            {
                _matchesTextBox.Text = "Not a winner";
            }
            else
            {
                _matchesTextBox.Text = "Winning ticket # " + winningTicketIndex.ToString();
            }
        }

        private DataSet GetMatchingCombinationsAsADataSet(List<Limitation> lim)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();
   
            for (int col = 0; col < lim.Count; ++col)
            {
                dataTable.Columns.Add( (col+1).ToString(), typeof(int));
            }

            for (int row = 0; row < _fullSystem.NumberOfRaces; ++row)
            {
                object[] objArray = new object[lim.Count];

                for (int col = 0; col < lim.Count; ++col)
                {
                    objArray[col] = lim[col].GetRaceSelection(row).Get(0);
                }

                dataTable.Rows.Add(objArray);
            }

            return dataSet;
        }


        private void OnShowAllMatches(object sender, EventArgs e)
        {
            try
            {
                _matchesTextBox.Text = "";

                Limitation winningCombination = new Limitation(_fullSystem.NumberOfRaces, _fullSystem.FirstRace);
                for (int i = 0; i < _fullSystem.NumberOfRaces; ++i)
                {
                    int horseNumber = Convert.ToInt32(_winningComboGrid[0, i].Value.ToString());

                    winningCombination.GetRaceSelection(i).AddHorse(horseNumber);
                    winningCombination.GetRaceSelection(i).ToggleSelectionForHorse(horseNumber);
                }

                Cursor = Cursors.WaitCursor;

                List<Limitation> lim = _fullSystem.ShowAllMatchesForSpecificCombination(winningCombination);
                
                // For performance reasons load the limitations to a dataset and then
                // assign it to the grid.  Painting the grid by hand is tooooo slow (dont now exacly why)
                _grid.DataSource = GetMatchingCombinationsAsADataSet(lim).Tables[0];
                
                _tbMatchesCount.Text = lim.Count.ToString();
                
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
