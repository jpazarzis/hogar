using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.MyComponents
{
    public partial class NumericTextBox : TextBox
    {
        
        

        public delegate void UpdateScreenDelegate();
        public event UpdateScreenDelegate UpdateScreenEvent;

        public NumericTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public double NumericValue
        {
            get
            {
                string s = this.Text.Trim();
                if (s.Length == 1 && s[0] == '.')
                {
                    return 0.0;
                }
                return s.Length > 0 ? Convert.ToDouble(s) : 0.0;
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                const char Delete = (char)8;
                e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != '.';
            }
           
            
            
        }

        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            if (null != UpdateScreenEvent)
            {
                UpdateScreenEvent();
            }
        }

        

        
    }
}
