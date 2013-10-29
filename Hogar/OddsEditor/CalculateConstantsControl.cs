using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.StatisticTools;
using Hogar.BrisPastPerformances;

namespace OddsEditor.MyComponents
{
    public partial class CalculateConstantsControl : UserControl
    {
        

        class ComboBoxItem
        {
            readonly string _caption;
            readonly CalculateOptimalConstant.GetValueDelegate _getValue;
            public ComboBoxItem(string caption, CalculateOptimalConstant.GetValueDelegate getValue)
            {
                _caption = caption;
                _getValue =getValue;
            }

            public override string  ToString()
            {
 	             return _caption;
            }

            public CalculateOptimalConstant.GetValueDelegate GetValueMethod
            {
                get
                {
                    return _getValue;
                }
            }

        }


        public CalculateConstantsControl()
        {
            InitializeComponent();
        }

        private int MinConstant
        {
            get
            {
                return Convert.ToInt32(_txtboxMinConstant.Text);
            }
        }
        private int MaxConstant
        {
            get
            {
                return Convert.ToInt32(_txtboxMaxConstant.Text);
            }
        }

        private int Step
        {
            get
            {
                return Convert.ToInt32(_txtboxConstantStep.Text);
            }
        }

        public double GetBestRating(BrisHorse brisHorse)
        {
            return brisHorse.BestRating;
            ////return brisHorse.DeltaLoverFigure;
        }

        public double GetBestPrimePower(BrisHorse brisHorse)
        {
            return (double)brisHorse.PrimePowerRating;
        }

        public void UpdateMessage(string message)
        {

            _txtboxOutput.Text += message + Environment.NewLine;

            if (_txtboxOutput.Text.Length + message.Length >= _txtboxOutput.MaxLength)
            {
                _txtboxOutput.Text = _txtboxOutput.Text.Substring(10000);
            }

            _txtboxOutput.Select(_txtboxOutput.Text.Length + 1, 2);
            _txtboxOutput.ScrollToCaret();
        }

        private void OnGo(object sender, EventArgs e)
        {
            try
            {
                CalculateOptimalConstant calculator = new CalculateOptimalConstant(MinConstant, MaxConstant, Step);
                calculator.UpdateObserverEvent += UpdateMessage;

                object obj = _comboBoxVariableToUse.SelectedItem;

                if (null != obj)
                {

                    ComboBoxItem it = (ComboBoxItem)obj;

                    calculator.GetValue = it.GetValueMethod;

                    int i = calculator.Calculate();
                    _txtboxoptimalConstant.Text = i.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to Calculate Constant");
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            
            _comboBoxVariableToUse.Items.Add(new ComboBoxItem("Bris Prime Power", GetBestPrimePower)); 
            _comboBoxVariableToUse.Items.Add(new ComboBoxItem("Bris Best Rating", GetBestRating));     
            _comboBoxVariableToUse.SelectedIndex = 0;

        }
    }
}
