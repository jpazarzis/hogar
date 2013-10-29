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
    public partial class HorseFiguresForm : Form
    {
        private readonly Horse _horse;
        public HorseFiguresForm(Horse horse)
        {
            _horse = horse;

            InitializeComponent();
        }

        private void HorseFiguresForm_Load(object sender, EventArgs e)
        {
            if(null == _horse)
                return;

            _webBrowser1.Navigate(_horse.BrisFiguresAsHtmlFile);
        }
    }
}
