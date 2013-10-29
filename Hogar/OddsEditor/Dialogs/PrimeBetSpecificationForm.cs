using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using OddsEditor.MyComponents;
using OddsEditor.UITools;

namespace OddsEditor.Dialogs
{
    // March 20 2010: This form is used to specify what are the 
    // minimum requirements for a handicapping factor performance
    // to be considered as prime

    public partial class PrimeBetSpecificationForm : Form
    {
        
        readonly PrimeBetRequirements _requirements;

        public PrimeBetSpecificationForm()
        {
            _requirements = PrimeBetRequirements.Singleton;

            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            BindFieldValidators();

            _tbMinROI.Text = string.Format("{0:0.00}", _requirements.MinROI);
            _tbMinIV.Text = string.Format( "{0:0.00}",_requirements.MinIV);
            _tbMinMatches.Text = string.Format("{0:0}", _requirements.MinMatches);
            _tbMinWinners.Text = string.Format("{0:0}", _requirements.MinWinners);
            _tbMinNumberOfQualifiedFactors.Text = string.Format("{0:0}", _requirements.MinRequiredPrimeBets);
            
        }

        private void BindFieldValidators()
        {
            _tbMinROI.Tag = FieldValidator<double>.Singelton;
            _tbMinIV.Tag = FieldValidator<double>.Singelton;
            _tbMinMatches.Tag = FieldValidator<int>.Singelton;
            _tbMinWinners.Tag = FieldValidator<int>.Singelton;
            _tbMinNumberOfQualifiedFactors.Tag = FieldValidator<int>.Singelton;
        }

        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                double roi = double.Parse(_tbMinROI.Text);
                double iv = double.Parse(_tbMinIV.Text);
                int matches = int.Parse(_tbMinMatches.Text);
                int winners = int.Parse(_tbMinWinners.Text);
                int qual = int.Parse(_tbMinNumberOfQualifiedFactors.Text);

                _requirements.AssignValues(roi, iv, matches, winners, qual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }

        private void OnLeavingTextBox(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = sender as TextBox;

                if (tb.Tag is IValidableField)
                {
                    IValidableField v = tb.Tag as IValidableField;

                    if (!v.Validate(tb.Text))
                    {
                        IUndoableField iu = tb.Tag as IUndoableField;
                        tb.Text = iu.TextToUseForUndo;
                    }
                }
            }
        }

        private void OnEnterTextBox(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = sender as TextBox;
                if (tb.Tag is IUndoableField)
                {
                    IUndoableField iu = tb.Tag as IUndoableField;
                    iu.TextToUseForUndo = tb.Text;
                }
            }
        }
    }
}
