using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Hogar;
using Hogar.WebBrowser;
using OddsEditor.MyComponents;


namespace OddsEditor.Dialogs
{
    public partial class SummaryForm : GenericForm
    {
        readonly DailyCard _raceCard;
        List<RaceSummaryControl> _raceSummaryControls = new List<RaceSummaryControl>();

        bool _initialLoad = true;

        public SummaryForm(string filename)
        {
            _raceCard = DailyCard.Load(filename);
            InitializeComponent();
        }

        public SummaryForm(DailyCard raceCard)
        {
            _raceCard = raceCard;
            InitializeComponent();
        }

        private string MakeWindowCaption()
        {
            return RaceTracks.GetNameFromTrackCode(_raceCard.TrackCode) + " " + Utilities.GetDateInFullDescription(_raceCard.Date);
        }


        private void OnInitialLoad(object sender, EventArgs e)
        {
            this.Text = MakeWindowCaption();
            _initialLoad = true;
            _checkboxHideScratches.Checked = _raceCard.HideScratches;
            _initialLoad = false;
            _labelRaceTrack.Text = RaceTracks.GetNameFromTrackCode(_raceCard.TrackCode) + "    " + Utilities.GetDateInFullDescription(_raceCard.Date);
            InitialPaint();
            LoadSortingCombo();
            ToolStripControlHost host1 = new ToolStripControlHost(_checkboxHideScratches);
            _checkboxHideScratches.BackColor = SystemColors.Control;
            _toolStrip.Items.Add(host1);
            _toolStrip.Items.Add(new ToolStripSeparator());
            _toolStrip.Items.Add(new ToolStripLabel("Sort By"));
            ToolStripControlHost host2 = new ToolStripControlHost(_comboBoxSortBy);
            _toolStrip.Items.Add(host2);
           // this.FormBorderStyle = FormBorderStyle.None;
           // this.WindowState = FormWindowState.Maximized;

            UpcomingRacesForm.RegisterSummaryForm(this);
            
        }

        
        private void LoadSortingCombo()
        {
            _comboBoxSortBy.Items.Clear();
            _comboBoxSortBy.Items.Add("Number");
            _comboBoxSortBy.Items.Add("Odds");
            _comboBoxSortBy.Items.Add("PrimePower");
            _comboBoxSortBy.Items.Add("BestFigure");
            _comboBoxSortBy.Items.Add("QuirinSI");
            _comboBoxSortBy.Items.Add("RunningStyle");
            _comboBoxSortBy.Items.Add("BestRaceRating");
            _comboBoxSortBy.Items.Add("BestClassRating"); 
            _comboBoxSortBy.SelectedIndex = _comboBoxSortBy.Items.IndexOf("PrimePower");
        }

        private void InitialPaint()
        {
          

            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.SuspendLayout();
            
           _raceSummaryControls.Clear();
            Cursor = Cursors.WaitCursor;
            foreach (Race race in _raceCard.Races)
            {
                RaceSummaryControl c = new RaceSummaryControl();
                c.BindRace(race);
                _panel.Controls.Add(c);
                _raceSummaryControls.Add(c);

                if ( null != c.Race && c.Race.IsHidden)
                {
                    c.Visible = false;
                }
                
                c.UpdateParentEvent += OnRaceWasHidden;
            }
            Cursor = Cursors.Default;
            this.ResumeLayout(false);
            this.AdjustFormScrollbars(true);
        }


        public void OnRaceWasHidden(RaceSummaryControl c)
        {
            c.Visible = false;
            this.AdjustFormScrollbars(true);
        }

        private void RefreshScreen()
        {
            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                c.RefreshGrid();
                if (c.Race.IsHidden)
                {
                    c.Visible = false;
                }
                else
                {
                    c.Visible = true;
                }
            }
            this.AdjustFormScrollbars(true);
        }

        private void PaintScreen()
        {
            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                c.InitialGridLoad();

                if (c.Race.IsHidden)
                {
                    c.Visible = false;
                }
                else
                {
                    c.Visible = true;
                }
            }
            this.AdjustFormScrollbars(true);
        }

        

        private void OnHideScratchesCheckedChanged(object sender, EventArgs e)
        {
            if (_initialLoad == false)
            {
                this.Cursor = Cursors.WaitCursor;
                _raceCard.HideScratches = !_raceCard.HideScratches;
                RefreshScreen();
                this.Cursor = Cursors.Default;
            }
        }

        private void OnSortByChanged(object sender, EventArgs e)
        {
            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                c.SortBy(_comboBoxSortBy.SelectedItem.ToString());
            }

            if (_raceSummaryControls.Count > 0)
            {
                _raceSummaryControls[0].Focus();
            }
        }

        

        void PrintDocumentOnPrintPage(object obj, PrintPageEventArgs ppea)
        {
            Graphics grfx = ppea.Graphics;
            PrintUtility pu = new PrintUtility(grfx);
            pu.WriteLine(" ");
            int i = 1;
            float lowestY = 0;
            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                PrintUtility.Orientation orientation = ((i % 2) != 0 ? PrintUtility.Orientation.Horizontal : PrintUtility.Orientation.Vertical);
                PointF p = pu.PrintDataTable(c.GetGridAsDataTable(), orientation);
                
                ++i;

                if (i % 2 == 0)
                {
                    pu.MoveRight(20.0F);
                    lowestY = p.Y;
                }
                else
                {
                    if (p.Y > lowestY)
                    {
                        lowestY = p.Y;
                    }
                    pu.SetY(lowestY + 10.0F);
                }
            }
        }

        

        private void OnGetScratchesFromClipboard2(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are sure that you want to read scratches from clipboard?", "Get Scratches", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Race race in _raceCard.Races)
                {
                    race.UnscratchAll();
                    List<string> scratches = ScratchReader.GetScratches(race.RaceNumber);
                    if (null != scratches)
                    {
                        foreach (string number in scratches)
                        {
                            if (null != race.GetHorseByProgramNumber(number))
                            {
                                race.GetHorseByProgramNumber(number).ScratchIt();
                            }
                        }
                    }
                }
            }
        }

        private void OnCopySelectionsToClipboard2(object sender, EventArgs e)
        {

            string track = RaceTracks.GetNameFromTrackCode(_raceCard.TrackCode);
            

            string txt = "[size=24] DELTA Selections for " +   _raceCard.ToString() + "[/size]" + Environment.NewLine;
            //txt += "[u][color=red]The Horse Has High percentage to win and has a positive ROI [/color][/u]" + Environment.NewLine;
            //txt += "[color=red]The Horse Has High percentage to WIN [/color]" + Environment.NewLine;
            //txt += "[color=green]The Horse has a positive ROI [/color]" + Environment.NewLine + Environment.NewLine;

            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                txt += c.GetAsBBCode();
            }
            Clipboard.SetText(txt);

            return;
            
            Cursor = Cursors.WaitCursor;
            try
            {
                /*
                var doc = _raceCard.GetPastPerformancesAsXml();
                Clipboard.SetText(doc.OuterXml);
                //string filename = string.Format(@"C:\Users\John\Desktop\TodaysRaces\{0}_{1}.xml", _raceCard.TrackCode, _raceCard.Date);
                string filename = string.Format(@"C:\CodesSamples\WebApplication1\WebApplication1\{0}_{1}.xml", _raceCard.TrackCode, _raceCard.Date);
                var tw = new StreamWriter(filename);
                tw.WriteLine(doc.OuterXml);
                tw.Close();
            */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;    
            }


            
            return;
            /*
            try
            {
                var f = new WebBrowserForm(_raceCard.Races[0].GetPastPerformancesAsXml());
                f.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            return;
            _raceCard.SaveAsXML();
            string track = RaceTracks.GetNameFromTrackCode(_raceCard.TrackCode);
            string txt = "[size=24] DELTA Selections for " + track + " 2009" + _raceCard.Date + "[/size]" + Environment.NewLine;
            txt += "[u][color=red]The Horse Has High percentage to win and has a positive ROI [/color][/u]" + Environment.NewLine;
            txt += "[color=red]The Horse Has High percentage to WIN [/color]" + Environment.NewLine;
            txt += "[color=green]The Horse has a positive ROI [/color]" + Environment.NewLine + Environment.NewLine;

            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                txt += c.GetAsBBCode();
            }
            Clipboard.SetText(txt);
            */
        }

        private void _toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintDocumentOnPrintPage);
            pd.DefaultPageSettings.Landscape = false;
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Width = 100;
            dlg.MinimumSize = new Size(375, 250);
            dlg.SetBounds(100, -550, 800, 800);
            dlg.Document = pd;
            DialogResult result = dlg.ShowDialog();

        }

        private void _toolStripButtonShowAll_Click(object sender, EventArgs e)
        {
            foreach (Race r in _raceCard.Races)
            {
                r.IsHidden = false;
            }
            foreach (RaceSummaryControl c in _raceSummaryControls)
            {
                c.Visible = true;
            }
            this.AdjustFormScrollbars(true);
            //PaintScreen();
        }

        private void OnKelly(object sender, EventArgs e)
        {
            KellyCalculatorForm f = KellyCalculatorForm.Singleton;
            f.Show();
            

        }

        private void OnFindHorse(object sender, EventArgs e)
        {
            try
            {
                ShowRacesByHorseForm form = new ShowRacesByHorseForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            UpcomingRacesForm.UnregisterSummaryForm(this);
        }

        private void ApplyNeuralNetworksClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                _raceCard.ApplyNeuralNetwork();
                RefreshScreen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            Cursor = Cursors.Default;
        }

        private void OnSaveWeightsAsXMLFile(object sender, EventArgs e)
        {
            try
            {
                _raceCard.SaveWeights();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnAutoAssignWeights(object sender, EventArgs e)
        {
            try
            {
                _raceCard.AutoAssignValueIndexBasedInMorningLine();
                RefreshScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _tsbCreateSippXmlFile_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new CreateSippFileForm(_raceCard);
                form.ShowDialog();


                //string filename = _raceCard.CreateSippDailyCard();
                //MessageBox.Show(string.Format("File {0} was created successfully", filename));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    // ScratchReader reads scratches from clippboard
    class ScratchReader
    {
        static Dictionary<int, List<string>> _scratches = new Dictionary<int, List<string>>();

        static public List<string> GetScratches(int raceNumber)
        {
            ReadFromClipboard();
            return _scratches.ContainsKey(raceNumber) ? _scratches[raceNumber] : null;

        }

        static void ReadFromClipboard()
        {
            _scratches.Clear();
            string[] txt = Clipboard.GetText().Split(new char[] { Environment.NewLine[0] });
            List<string> scratches = null;
            foreach (string line in txt)
            {
                string s = line;
                if (s.IndexOf('\n') >= 0)
                {
                    s = s.Remove(s.IndexOf('\n'), 1);
                }
                if (ContainsScratchInfo(s))
                {
                    string[] ss = s.Split(new char[] { '\t' });
                    if (ss.Length < 2)
                    {
                        continue;
                    }
                    if (ss[0].Trim().Length != 0)
                    {
                        int raceNum = Convert.ToInt32(ss[0]);
                        scratches = new List<string>();
                        _scratches.Add(raceNum, scratches);
                    }
                    string number = ss[1].ToUpper();
                    string poe = "(POE)";
                    if (number.Contains(poe))
                    {
                        number = number.Remove(number.IndexOf(poe), poe.Length).Trim();
                    }
                    if (null == scratches)
                    {
                        throw new Exception("Invalid Format");
                    }
                    scratches.Add(number);
                }
            }
        }

        static bool ContainsScratchInfo(string txt)
        {
            txt = txt.Trim().ToUpper();
            if (txt.Length <= 0)
            {
                return false;
            }
            string s = "SCRATCHES";
            if (txt.Length >= s.Length && txt.Substring(0, s.Length).CompareTo(s) == 0)
            {
                return false;
            }
            s = "RACE";
            if (txt.Length >= s.Length && txt.Substring(0, s.Length).CompareTo(s) == 0)
            {
                return false;
            }
            return true;
        }
    }

}
