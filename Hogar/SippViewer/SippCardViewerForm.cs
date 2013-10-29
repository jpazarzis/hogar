// *************************************************************
// 
//                           Written By John Pazarzis
// 
// *************************************************************
// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Sipp;

namespace SippViewer
{
    public partial class SippCardViewerForm : Form
    {
        private class SippXmlFileInfo
        {
            public string Filename { get; set; }

            public string TrackName
            {
                get
                {
                    var s = Filename.Replace(".xml", "").Split('_');
                    return s.Length < 3 || s[2].Length < 8 ? "" : TrackInfo.GetFullName(s[1]);
                }
            }

            public string Date
            {
                get
                {
                    var s = Filename.Replace(".xml", "").Split('_');
                    var d = new DateTime(s[2].Substring(0, 4).ToInteger(), s[2].Substring(4, 2).ToInteger(), s[2].Substring(6, 2).ToInteger());

                    var diff = d - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                    if (diff.Days == 0)
                    {
                        return "Today";
                    }
                    else if (diff.Days == 1)
                    {
                        return "Tomorow";
                    }
                    else if (diff.Days == -1)
                    {
                        return "Yesterday";
                    }
                    else
                    {
                        return (s[2]);
                    }
                }
            }

            public override string ToString()
            {
                var s = Filename.Replace(".xml", "").Split('_');

                if (s.Length < 3 || s[2].Length < 8)
                    return Filename;

                var d = new DateTime(s[2].Substring(0, 4).ToInteger(), s[2].Substring(4, 2).ToInteger(), s[2].Substring(6, 2).ToInteger());

                var diff = d - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                if (diff.Days == 0)
                {
                    return string.Format("{0}, Today", TrackInfo.GetFullName(s[1]));
                }
                else if (diff.Days == 1)
                {
                    return string.Format("{0}, Tomorow", TrackInfo.GetFullName(s[1]));
                }
                else if (diff.Days == -1)
                {
                    return string.Format("{0}, Yesterday", TrackInfo.GetFullName(s[1]));
                }
                else
                {
                    return string.Format("{0}, {1}", TrackInfo.GetFullName(s[1]), s[2]);
                }
            }
        }

        private SippDailyCard _sippCard;

        private SippXmlFileInfo _currentlySelectedXmlFileInfo = null;

        public SippCardViewerForm()
        {
            InitializeComponent();
        }

        private void SippCardViewerForm_Load(object sender, EventArgs e)
        {
            Text = "Sipp Viewer";

            SippDailyCard.UserDirectory = ApplicationDeployment.IsNetworkDeployed ?
                ApplicationDeployment.CurrentDeployment.DataDirectory : @"C:\test";

            LoadAvailableTracksComboBox();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
            _raceViewerControl.Clear();
            _saveUserSettingsTimer.Start();
        }

        private void LoadAvailableTracksComboBox()
        {
            try
            {
                _cbAvailableCards.Items.Clear();
                var doc = new XmlDocument();
                doc.Load(@"http://kasosoft.com/SippFiles/Handler1.ashx");
                foreach (XmlNode node in doc.SelectNodes("/available-cards/card"))
                {
                    string xmlFilename = node.Attributes["filename"].Value;

                    _cbAvailableCards.Items.Add(new SippXmlFileInfo {Filename = xmlFilename});
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateScreen()
        {
            _saveUserSettingsTimer.Stop();
            _saveUserSettingsTimer_Tick(null, null);
            LoadRaceSelectors();
            ShowRace(_sippCard[0]);
            _saveUserSettingsTimer.Start();
        }

        private void LoadRaceSelectors()
        {
            _flowLayoutPanelRaceSelector.Controls.Clear();

            if (null == _sippCard)
                return;

            foreach (var race in _sippCard)
            {
                var button = new Button
                                 {
                                     Text = string.Format("{0} ({1})", race.RaceNumber, race.NumberOfHorses),
                                     Width = 50,
                                     Height = 40,
                                     Tag = race
                                 };
                button.Click += new EventHandler(button_Click);
                _flowLayoutPanelRaceSelector.Controls.Add(button);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (null != b)
            {
                ShowRace((SippRace) b.Tag);
            }
        }

        private void ShowRace(SippRace race)
        {
            _raceViewerControl.Bind(race);
        }

        private void _saveUserSettingsTimer_Tick(object sender, EventArgs e)
        {
            if (null == _sippCard)
            {
                return;
            }

            foreach (var ctrl in _flowLayoutPanelRaceSelector.Controls)
            {
                var button = ctrl as Button;
                if (null != button)
                {
                    var race = button.Tag as SippRace;

                    if (null != race)
                    {
                        string s = string.Format("{0} ({1})", race.RaceNumber, race.NumberOfHorses);

                        if (button.Text != s)
                        {
                            button.Text = s;
                        }
                    }
                }
            }

            if (_sippCard.NeedsToSaveUserSettings)
            {
                _sippCard.SaveUserSettings();
            }
        }

        private void SippCardViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _saveUserSettingsTimer.Stop();
            _saveUserSettingsTimer_Tick(null, null);

            _raceViewerControl.UnsubscribeFromFeed();
        }

        private void OpenWebDocument(string target)
        {
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                {
                    MessageBox.Show(noBrowser.Message);
                }
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void _linkLabelReadReleaseNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenWebDocument("http://kasosoft.com/SippFiles/sipp-release-notes.pdf");
        }

        private void _linkLabelHandicappingNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenWebDocument("http://kasosoft.com/SippFiles/handicapping-approach.pdf");
        }

        private void _cbAvailableCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var fi = _cbAvailableCards.SelectedItem as SippXmlFileInfo;

                if (null == fi)
                    return;

                var selectedCard = fi.Filename;

                string msg = string.Format("You are sure that you want to load {0} for {1}", fi.TrackName, fi.Date);
                if (MessageBox.Show(msg, "Load Data", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    _cbAvailableCards.SelectedIndexChanged -= _cbAvailableCards_SelectedIndexChanged;
                    _cbAvailableCards.Text = _currentlySelectedXmlFileInfo != null ? _currentlySelectedXmlFileInfo.ToString() : null;
                    _cbAvailableCards.SelectedIndexChanged += _cbAvailableCards_SelectedIndexChanged;
                    return;
                }

                Cursor = Cursors.WaitCursor;
                _sippCard = SippDailyCard.MakeFromXml(string.Format(@"http://kasosoft.com/SippFiles/{0}", selectedCard));
                _currentlySelectedXmlFileInfo = fi;

                Text = string.Format("{0} {1} - Sipp Viewer", TrackInfo.GetFullName(_sippCard.TrackCode), _sippCard.Date.ToString("MM/dd/yyyy"));
                UpdateScreen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}