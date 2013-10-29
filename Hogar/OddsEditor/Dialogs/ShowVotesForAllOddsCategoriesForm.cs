using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.RaceGrouping;

namespace OddsEditor.Dialogs
{
    public partial class ShowVotesForAllOddsCategoriesForm : Form
    {
        private readonly Horse _horse;

        public ShowVotesForAllOddsCategoriesForm(Horse horse)
        {
            _horse = horse;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _labelHorseName.Text = "";
            if (null == _horse)
            {
                return;
            }

            _labelHorseName.Text = string.Format("({0:0}-1) {1}", _horse.RealTimeOdds, _horse.Name);

            _grid.Columns.Add("Category", "Category");
            _grid.Columns.Add("Votes", "Votes");

            var brisRace = _horse.CorrespondingBrisHorse.Parent;
            var rgt = brisRace.RaceGroupType;

            _grid.DefaultCellStyle.BackColor = Color.White;
            _grid.DefaultCellStyle.SelectionBackColor = Color.White;
            _grid.DefaultCellStyle.ForeColor = Color.Black;
            _grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (var targetGroup in rgt.Groups)
            {
                int row = _grid.Rows.Add();
                var cells = _grid.Rows[row].Cells;
                cells[0].Value = targetGroup.Description;

                if (targetGroup is GoodBetBasedInOdds)
                {
                    var g = targetGroup as GoodBetBasedInOdds;
                    cells[1].Value = _horse.CorrespondingBrisHorse.GetVotesBasedInOdds(g.AverageOdds);
                    if (_horse.RealTimeOdds >= g.MinOdds && _horse.RealTimeOdds < g.MaxOdds)
                    {
                        _grid.Rows[row].DefaultCellStyle.BackColor = Color.LightPink;
                        _grid.Rows[row].DefaultCellStyle.SelectionBackColor = Color.LightPink;
                    }
                }
                else if (targetGroup is GoodFavorite)
                {
                    var g = targetGroup as GoodFavorite;
                    cells[1].Value = _horse.CorrespondingBrisHorse.VotesForGoodFavorite;
                }
                else if (targetGroup is BadFavorite)
                {
                    var g = targetGroup as GoodFavorite;
                    cells[1].Value = _horse.CorrespondingBrisHorse.VotesForBadFavorite;
                }
            }

            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}