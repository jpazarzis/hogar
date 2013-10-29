using System;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public partial class ChangeTotalAmountBetForm : GenericForm
    {

        double _amount = 0;

        public ChangeTotalAmountBetForm()
        {
            InitializeComponent();
        }

        public double Amount
        {
            get
            {
                return _amount * (1.0 -  Hogar.Race.TAKE_OUT_PERCENT);
            }
        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            for (double amount = 1000; amount < 20000; amount += 1000)
            {
                _cbAmount.Items.Add(amount);
            }
        }

        private void OnOK(object sender, EventArgs e)
        {
            _amount = Convert.ToDouble(_cbAmount.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
