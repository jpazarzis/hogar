using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp;

namespace SippViewer
{
    public partial class CompareJockeysForm : Form
    {
        private readonly SippRace _race;

        class JockeyStats
        {
            public string Jockey { get; set; }
            public SippImpactValueStat Stats { get; set; }

        }

        readonly Dictionary<string , List<JockeyStats>> _stats = new Dictionary<string, List<JockeyStats>>();

        public CompareJockeysForm(SippRace race)
        {
            _race = race;
            InitializeComponent();
        }

        private void CompareJockeysForm_Load(object sender, EventArgs e)
        {
            BuildStats();

            foreach (var statName in _stats.Keys)
            {
                AddStatisticsGrid(statName);
            }
        }

        private DataGridView BuildNewGrid()
        {
            var grid = new DataGridView();

            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.ColumnHeadersVisible = false;

            var dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            grid.DefaultCellStyle = dataGridViewCellStyle7;


            grid.RowHeadersVisible = false;
            grid.Size = new System.Drawing.Size(300, 300);
            //this._gridJockeyStats.TabIndex = 0;

            return grid;
        }

        private void AddStatisticsGrid(string statName)
        {
            var grid = BuildNewGrid();
            
            grid.Columns.Add("Jockey", "Jockey");
            grid.Columns.Add("Stats", "Stats");
            grid.Columns[0].Width = 110;
            grid.Columns[1].Width = 200;
            foreach (var stat in _stats[statName].OrderBy(js => (-1) * js.Stats.IV))
            {
                var cells = grid.Rows[grid.Rows.Add()].Cells;
                cells[0].Value = stat.Jockey;
                cells[1].Value = stat.Stats.ToString();
            }

            var p = new FlowLayoutPanel() {Width = 305, Height = 340};

            p.Controls.Add(new Label{Text = statName,Width = 300,BackColor = Color.Blue, ForeColor = Color.Yellow});
            p.Controls.Add(grid);
            _panel.Controls.Add(p);
        }

        void BuildStats()
        {
            _stats.Clear();

            foreach (var horse in _race)
            {
                if (horse.Scratched) continue;

                foreach (var stat in _race.Parent.GetJockeySummarizedStatistics(horse.Jockey))
                {
                    if(!_stats.ContainsKey(stat.Name))
                    {
                        _stats.Add(stat.Name, new List<JockeyStats>());
                    }

                    _stats[stat.Name].Add(new JockeyStats {Jockey = horse.Jockey,Stats = stat});
                }
            }
        }
    }
}
