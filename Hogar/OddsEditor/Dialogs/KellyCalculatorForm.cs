using System;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public sealed partial class KellyCalculatorForm : Form
    {

        private static readonly KellyCalculatorForm _singleton = new KellyCalculatorForm();
        private static bool _isShown = false;


        private KellyCalculatorForm()
        {
            InitializeComponent();
        }

        static KellyCalculatorForm()
        {
            _singleton.FormClosing += new FormClosingEventHandler(OnSingletonFormClosing);
        }


        static public KellyCalculatorForm Singleton
        {
            get
            {
                return _singleton;
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
           _txtboxWinningPercent.UpdateScreenEvent += UpdateScreen;
           _txtboxOddsToOne.UpdateScreenEvent += UpdateScreen;
           TopMost = true;
        }

        public new void Show()
        {
            if (_isShown)
            {
                base.Show();
            }
            else
            {
                base.Show();
                _isShown = true;
            }
        }
        

        public void UpdateScreen()
        {
            _txtPercentToBet.Text = "";
            double v = _txtboxOddsToOne.NumericValue;
            if (v <= 0)
            {
                return;
            }

            double p = _txtboxWinningPercent.NumericValue;
            if (p <= 0)
            {
                return;
            }

            double f = (p * (v + 1) - 1) / v;

            _txtPercentToBet.Text = string.Format("{0:0.00}", f);

        }

        private static void OnSingletonFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _isShown = false;
            _singleton.Hide();
        }
    }
}
