using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.StatisticTools;
using OddsEditor.Dialogs.JockeyStatistics;

namespace OddsEditor.Dialogs
{
    public partial class ImpactValueForm : Form
    {
        public string Description { get; set; }

        public IEnumerable<ImpactValueStat> ImpactValues { get; set; }

        public ImpactValueForm()
        {
            InitializeComponent();
        }

        private void ImpactValueForm_Load(object sender, EventArgs e)
        {
            if (null == ImpactValues)
                return;

            Text = Description;
            _labelDescription.Text = Description;

            _listView.Columns.Add("Name");
            _listView.Columns.Add("Stats");
            _listView.Columns.Add("Win%");
            _listView.Columns.Add("ROI");
            _listView.Columns.Add("IV");

            foreach (var s in ImpactValues)
            {
                var lvi = _listView.Items.Add(s.Name);

                lvi.SubItems.Add(s.Starters.ToString());
                lvi.SubItems.Add(string.Format("{0:0}%", s.WinPercent));
                lvi.SubItems.Add(string.Format("{0:0.00}", s.ROI));
                lvi.SubItems.Add(string.Format("{0:0.00}", s.IV));
            }
        }

        
    }
}