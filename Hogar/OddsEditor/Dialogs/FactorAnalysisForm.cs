using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.Dialogs
{
    public partial class FactorAnalysisForm : Form
    {
        private readonly Horse _horse;
        public FactorAnalysisForm(Horse horse)
        {
            _horse = horse;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _factorAnalysisCtrl1.Bind(_horse);
        }
    }
}
