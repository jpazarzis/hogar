using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public partial class HistogramForm : Form
    {
        private List<double> _values;
        private string _xTitle;
        private string _yTitle;


        public HistogramForm(List<double> values, string xTitle, string yTitle)
        {
            _values = values;
            _xTitle = xTitle;
            _yTitle = yTitle;
            InitializeComponent();
        }

        private void HistogramForm_Load(object sender, EventArgs e)
        {
            try
            {
                _histogramCtrl1.ShowGraph(_values,_xTitle,_yTitle);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
