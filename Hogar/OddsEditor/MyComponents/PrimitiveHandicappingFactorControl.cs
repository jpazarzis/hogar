using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Handicapping;

namespace OddsEditor.MyComponents
{
    public partial class PrimitiveHandicappingFactorControl : UserControl
    {
        public PrimitiveHandicappingFactorControl()
        {
            InitializeComponent();
        }

        public void Bind(Horse horse)
        {
            List<Factor> list = horse.CorrespondingBrisHorse.GetMatchingHandicappingFactors(horse);
            this.SuspendLayout();
            string txt = "";
            foreach (Factor f in list)
            {
                txt += f.Name + Environment.NewLine;
            }
            _txtbox.Text = txt;
            this.ResumeLayout(false);
            this.Refresh();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            
        }
    }
}
