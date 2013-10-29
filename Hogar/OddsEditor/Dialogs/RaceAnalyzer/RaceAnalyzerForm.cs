using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.RaceAnalyzer;

namespace OddsEditor.Dialogs.RaceAnalyzer
{
    public partial class RaceAnalyzerForm : Form
    {
        private readonly Race _race;

        public RaceAnalyzerForm(Race race)
        {
            _race = race;
            InitializeComponent();
        }

        private void RaceAnalyzerForm_Load(object sender, EventArgs e)
        {
            //_webBrowser.Navigate(Hogar.RaceAnalyzer.RaceAnalyzer.Make(_race).CreateAnalysisDocument());
           // _webBrowser.Navigate(_race.CreateReport());
        }
    }
}