using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.Dialogs.Testing
{
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();
        }

        private void OnTestIndividualHorsePastPerfrormances(object sender, EventArgs e)
        {

            try
            {
                var f = new IndividualHorsePastPerformancesForm("BEL", 2010, 7, 17, 1, "1");
                f.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
