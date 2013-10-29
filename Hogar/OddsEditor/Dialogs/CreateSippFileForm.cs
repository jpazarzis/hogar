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
    public partial class CreateSippFileForm : Form
    {
        readonly private DailyCard _card;

        public CreateSippFileForm(DailyCard card)
        {
            _card = card;
            InitializeComponent();
        }

        private void CreateSippFileForm_Load(object sender, EventArgs e)
        {

        }

        public void ShowMessage(string txt)
        {
            _txtboxMessage.Text += txt + Environment.NewLine;
            if (_txtboxMessage.Text.Length + txt.Length >= _txtboxMessage.MaxLength)
            {
                _txtboxMessage.Text = _txtboxMessage.Text.Substring(10000);
            }
            _txtboxMessage.Select(_txtboxMessage.Text.Length + 1, 2);
            _txtboxMessage.ScrollToCaret();
            Application.DoEvents();
        }

        private void _buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                _buttonCreate.Enabled = false;
                _txtboxMessage.Text = "";
                _card.CreateSippDailyCard(ShowMessage);
                _buttonCreate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
