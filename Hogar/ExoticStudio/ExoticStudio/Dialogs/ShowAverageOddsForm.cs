using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExoticStudio
{
    public partial class ShowAverageOddsForm : Form
    {

        readonly SortedDictionary<double, int> _averageOdds;

        public ShowAverageOddsForm(SortedDictionary<double, int> averageOdds)
        {
            _averageOdds = averageOdds;
            

            InitializeComponent();
        }

        private DataSet GetAverageOddsAsDataTable()
        {
          
            DataSet dataSet = new DataSet();

            DataTable dataTable = dataSet.Tables.Add();

            dataTable.Columns.Add("Avg", typeof(double));
            dataTable.Columns.Add("Freq", typeof(double));

            foreach (double key in _averageOdds.Keys)
            {
                dataTable.Rows.Add(key, _averageOdds[key]);
                
            }


            return dataSet;

        }

        private int GetTotalNumberOfCombinations()
        {
            int total = 0;

            foreach (double key in _averageOdds.Keys)
            {
                total += _averageOdds[key];
            }

            return total;

        }
        

        private void OnLoad(object sender, EventArgs e)
        {

            DataSet ds = GetAverageOddsAsDataTable();

            _grid.DataSource = ds.Tables[0];
            _totalNumberOfCombinationsTextBox.Text = GetTotalNumberOfCombinations().ToString();
            _frequencyGraphControl.DisplayGraph(ds);
        }
    }
}
