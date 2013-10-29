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
    public partial class EditHorseWeightsForm : Form
    {
        readonly Horse _horse;

        readonly List<RadioButton> _valueIndexRadioButtons = new List<RadioButton>();
        readonly List<RadioButton> _weightIndexRadioButtons = new List<RadioButton>();

        public EditHorseWeightsForm(Horse horse)
        {
            _horse = horse;
            InitializeComponent();

            _valueIndexRadioButtons.Add(_rbVI_0);
            _valueIndexRadioButtons.Add(_rbVI_1);
            _valueIndexRadioButtons.Add(_rbVI_2);
            _valueIndexRadioButtons.Add(_rbVI_3);
            _valueIndexRadioButtons.Add(_rbVI_4);
            _valueIndexRadioButtons.Add(_rbVI_5);

            _weightIndexRadioButtons.Add(_rbWI_0);
            _weightIndexRadioButtons.Add(_rbWI_1);
            _weightIndexRadioButtons.Add(_rbWI_2);
            _weightIndexRadioButtons.Add(_rbWI_3);
            _weightIndexRadioButtons.Add(_rbWI_4);
            _weightIndexRadioButtons.Add(_rbWI_5);


        }



        private void OnInitialLoad(object sender, EventArgs e)
        {
            if(_horse.ValueIndex >= 0 && _horse.ValueIndex <=5)
            {
                _valueIndexRadioButtons[_horse.ValueIndex].Checked = true;
            }

            if (_horse.WeightIndex >= 0 && _horse.WeightIndex <= 5)
            {
                _weightIndexRadioButtons[_horse.WeightIndex].Checked = true;
            }
        }

        private void OnOK(object sender, EventArgs e)
        {
            for (int i = 0; i < _weightIndexRadioButtons.Count;++i )
            {
                if(_weightIndexRadioButtons[i].Checked)
                {
                    _horse.WeightIndex = i;
                    break;
                }
            }

            for (int i = 0; i < _valueIndexRadioButtons.Count; ++i)
            {
                if (_valueIndexRadioButtons[i].Checked)
                {
                    _horse.ValueIndex = i;
                    break;
                }
            }


            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
