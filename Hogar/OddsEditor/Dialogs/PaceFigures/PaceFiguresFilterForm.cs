using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.Dialogs.PaceFigures
{
    public partial class PaceFiguresFilterForm : Form
    {
        private readonly PaceFigureFilter _filter;

        public PaceFiguresFilterForm(PaceFigureFilter filter)
        {
            _filter = filter;
            InitializeComponent();
        }

        private void PaceFiguresFilterForm_Load(object sender, EventArgs e)
        {
            var classificationFilter = _filter.ClassificationFliter;

            foreach(var f in classificationFilter)
            {
               _listBoxRaceClassification.Items.Add(f, f.Checked);
            }

            var trackConditionFilter = _filter.TrackConditionFliter;

            foreach (var f in trackConditionFilter)
            {
                _listBoxTrackCondition.Items.Add(f, f.Checked);
            }
        }

        private void _listBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var listBox = sender as CheckedListBox;

            if (null != listBox)
            {
                var c = listBox.Items[e.Index] as Checkable;

                if (null != c)
                {
                    c.Checked = !c.Checked;
                }
            }
        }

        private void _buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void _buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
