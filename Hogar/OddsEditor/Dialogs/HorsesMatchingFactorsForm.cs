using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Handicapping.Analysis;
using Hogar.Handicapping;
using Hogar;

namespace OddsEditor.Dialogs
{
    public partial class HorsesMatchingFactorsForm : Form
    {
        readonly string _trackCode;
        readonly long _raceAttributes;
        readonly List<Factor> _factors;

        enum ShowType
        {
            TurfOnly,
            MaidenOnly,
            ShowAll
        }

        ShowType _showType = ShowType.ShowAll;


        public HorsesMatchingFactorsForm(List<Factor> factors, string trackCode, long raceAttributes)
        {
            _factors = factors;
            _trackCode = trackCode;
            _raceAttributes = raceAttributes;
            InitializeComponent();
        }

        string Title
        {
            get
            {
                StringBuilder s = new StringBuilder();
                s.Append(RaceTracks.GetNameFromTrackCode(_trackCode));
                foreach (Factor f in _factors)
                {
                    if (null != f)
                    {
                        s.Append(" ");
                        s.Append(f.Name);
                    }
                }
                int c = 0;
                int winners = 0;
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    if (row.Visible)
                    {
                        ++c;
                        int p = (int)row.Cells["POS"].Value;
                        if (p == 1)
                        {
                            ++winners;
                        }
                    }
                }

                double percent = (winners * 100.0) / (c * 1.0);

                s.Append("   ");
                s.Append(winners.ToString());
                s.Append(" : ");
                s.Append(c.ToString());
                s.Append("  [");
                
                s.Append(string.Format("{0:00}", percent));
                s.Append(" % ] ");
                return s.ToString();
            }
        }

        
        private void OnInitialLoad(object sender, EventArgs e)
        {
            DataSet ds = FactorRetriever.GetMatchingHorses(_factors, _trackCode,_raceAttributes);
            _grid.DataSource = ds.Tables[0];
            _txtboxTitle.Text = Title;
        }

        private void UpdateView(ShowType showType)
        {
            if (showType != _showType)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    _grid.SuspendLayout();
                    _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    foreach (DataGridViewRow row in _grid.Rows)
                    {

                        _grid.CurrentCell = null;
                        switch (showType)
                        {
                            case ShowType.ShowAll:
                                row.Visible = true;
                                break;
                            case ShowType.TurfOnly:
                                {
                                    string s = (string)row.Cells["SUR"].Value;
                                    if (false == s.Equals("T", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        row.Visible = false;
                                    }
                                    else
                                    {
                                        row.Visible = true;
                                    }
                                }
                                break;
                            case ShowType.MaidenOnly:
                                {
                                    string s = (string)row.Cells["CLASS"].Value;
                                    if (s.IndexOf("MSW") >= 0 || s.IndexOf("MCL") >= 0)
                                    {
                                        row.Visible = true;
                                    }
                                    else
                                    {
                                        row.Visible = false;
                                    }
                                }
                                break;
                        }
                    }
                    _grid.ResumeLayout(false);
                    _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _showType = showType;
                    _txtboxTitle.Text = Title;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

            }
        }

        private void OnShowTurfOnly(object sender, EventArgs e)
        {
            UpdateView(ShowType.TurfOnly);
        }

        private void OnShowMaidenOnly(object sender, EventArgs e)
        {
            UpdateView(ShowType.MaidenOnly);
        }

        private void OnShowAll(object sender, EventArgs e)
        {
            UpdateView(ShowType.ShowAll);
        }
    }
}
