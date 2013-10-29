using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Betting;

namespace OddsEditor.MyComponents
{
    public partial class TrifectaSubsystemsControl : UserControl
    {
        public TrifectaSubsystemsControl()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {

        }

        
        public void LoadSubsystem(List<TrifectaSubsystem> systems)
        {
            _grid.Rows.Clear();

            int total = 0;
            int numberOfTickets = 0;

            foreach (TrifectaSubsystem s in systems)
            {
                if (s.IsValid)
                {
                    int index = _grid.Rows.Add();
                    DataGridViewRow row = _grid.Rows[index];
                    row.Cells["FirstPosition"].Value = s.GetPositionAsString(TrifectaSubsystem.Position.First);
                    row.Cells["SecondPosition"].Value = s.GetPositionAsString(TrifectaSubsystem.Position.Second);
                    row.Cells["ThirdPosition"].Value = s.GetPositionAsString(TrifectaSubsystem.Position.Third);
                    int t = s.Count();
                    row.Cells["Count"].Value = t.ToString();
                    total += t;
                    ++numberOfTickets;
                }
                
            }

            _txtboxTotal.Text = total.ToString();
            _txtboxNumberOfTickets.Text = numberOfTickets.ToString();
        }
    }
}
