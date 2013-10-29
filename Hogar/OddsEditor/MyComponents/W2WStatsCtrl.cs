using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.MyComponents
{
    public partial class W2WStatsCtrl : UserControl
    {
        public string Description { get; set; }

        public int TotalStarters { get; set; }

        public int NumberOfRaces { get; set; }

        public int W2WWinners { get; set; }


        public W2WStatsCtrl()
        {
            InitializeComponent();
        }

        string W2WPercent
        {
            get
            {
                if (NumberOfRaces <= 0)
                    return "0%";
                else
                {
                    return string.Format("{0:0}%", (((double)W2WWinners) / NumberOfRaces)*100.0);
                }
            }
        }

        private void W2WStatsCtrl_Load(object sender, EventArgs e)
        {
            //_groupBox.Text = Description;
            _tbTotalStarters.Text = NumberOfRaces.ToString();
            _tbW2W.Text = W2WPercent;
        }
    }
}
