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
    public partial class FactorsSummaryForm : Form
    {
        private readonly SippRace _sippRace;
        readonly RaceViewerControl _raceViewerControl;
        public FactorsSummaryForm(SippRace race,RaceViewerControl raceViewerControl)
        {
            _sippRace = race;
            _raceViewerControl = raceViewerControl;
            InitializeComponent();
        }

        private void FactorsSummaryForm_Load(object sender, EventArgs e)
        {
            LoadTree(f=>(-1)*f.Stats.IV);
        }

        void LoadTree(Func<SippRace.FactorKey,double > sorter)
        {
            _tree.Nodes.Clear();

            if (null == _sippRace)
                return;

            var sum = _sippRace.HandicappingFactorsSummary;

            int i = 0;
            foreach (var factorKey in sum.Keys.OrderBy(sorter))
            {
                string name = string.Format("{0,-30} {1}",factorKey.Name,factorKey.Stats);

                var tn = _tree.Nodes.Add(name);
                tn.BackColor = ((i++)%2 == 0) ? Color.Beige : Color.LightCyan;
                foreach (var horseStats in sum[factorKey])
                {
                    var horseNode = tn.Nodes.Add(horseStats.Description);
                    horseNode.Tag = horseStats.Horse;
                }
            }
        }

        private void OnSortByIV(object sender, EventArgs e)
        {
            LoadTree(f => (-1) * f.Stats.IV);
        }

        private void OnSortByROI(object sender, EventArgs e)
        {
            LoadTree(f => (-1) * f.Stats.Roi);
        }

        private void OnSortByWinningPercentage(object sender, EventArgs e)
        {
            LoadTree(f => (-1) * f.Stats.WinningPercent);
        }

       

        private void _tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void OnHorseToggleContenterStatus(object sender, EventArgs e)
        {
            try
            {
                _raceViewerControl.ToggleHorseStatus(((ToolStripItem)sender).Tag as SippHorse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (null == e.Node)
                return;

            var horse = e.Node.Tag as SippHorse;

            if (null == horse || null == _raceViewerControl)
                return;


            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);


                _popupMenu.Items.Clear();
                _popupMenu.Items.Add(string.Format("{0} ", horse.Name));
                _popupMenu.Items.Add("-");
                string s = horse.IsContender ? "Is No Contenter" : "Is Contenter";
                ToolStripItem item = _popupMenu.Items.Add(s, null, OnHorseToggleContenterStatus);
                item.Tag = horse;
                _popupMenu.Show((Control)sender, e.X, e.Y);
                
            }
            else
            {
                _raceViewerControl.DisplayHorseInfo(horse);    
            }
            
            

        }
    }
}
