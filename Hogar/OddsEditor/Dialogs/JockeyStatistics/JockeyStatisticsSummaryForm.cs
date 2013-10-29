using System;
using System.Linq;
using System.Windows.Forms;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.JockeyStatistics
{
    public partial class JockeyStatisticsSummaryForm : Form
    {
        public JockeyStatisticsSummaryForm()
        {
            InitializeComponent();
        }

        private void OnInitiaLoad(object sender, EventArgs e)
        {
            LoadListBox();
        }

        private void LoadListBox()
        {
            try
            {
                _listBox.Items.Clear();
                using (var dbr = new DbReader())
                {
                    if (dbr.Open(@"SELECT  DISTINCT(ABBR_JOCKEY_NAME) 'JOCKEY' FROM  RACE_STARTERS  WHERE ABBR_JOCKEY_NAME != '' ORDER BY 'JOCKEY'"))
                    {
                        while (dbr.MoveToNextRow())
                        {
                            _listBox.Items.Add(dbr.GetValue<string>("JOCKEY"));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {
            try
            {
                var form = new JockeyStatisticsForm(_listBox.SelectedItem.ToString());
                form.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}