using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using ExoticStudio.Dialogs;

namespace ExoticStudio
{
    public partial class MainForm : Form
    {
        private const int DEFAULT_GROUP_INDEX = 0;
        private const int X_OFFSET = 50;
        private const int Y_OFFSET = 100;

        private const string FILE_LOCKED_MENU_TEXT = "File is Locked";
        private const string FILE_CAN_BE_LOCKED_MENU_TEXT = "Lock File On Disk";

        private FullSystem _fullSystem = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public FullSystem GetFullSystem()
        {
            return _fullSystem;
        }

        public void DeleteLimitation(int groupIndex, int limitationIndex)
        {
            _fullSystem.DeleteLimitation(groupIndex, limitationIndex);
            RefreshObservers(groupIndex);
        }

        public void CopyLimitation(int groupIndex, int limitationIndex, Limitation toBeCopied)
        {
            _fullSystem.CopyLimitation(groupIndex, limitationIndex, toBeCopied);
            RefreshObservers(groupIndex);
        }

        public void DeleteGroup(int groupIndex)
        {
            int previousGroupIndex = _fullSystem.DeleteGroup(groupIndex);
            RefreshObservers(previousGroupIndex);
        }

        private void RefreshObservers(int groupIndex)
        {
            _groupEditor.BindFullSystem(_fullSystem, groupIndex);
            _groupMatchesInputUserCtrl.BindFullSystem(_fullSystem);
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                Open(Environment.GetCommandLineArgs()[1]);
            }

            _groupMatchesInputUserCtrl.BindFullSystem(_fullSystem);

            _updateToolButtonsTimer.Start();
        }

        private void BindFullSystem()
        {
            if (null != _fullSystem)
            {
                _unitBetTextBox.Text = _fullSystem.UnitBet.ToString();
                _fullSystemInputBox.BindLimitation(_fullSystem);
                _raceTrackTextBox.Text = _fullSystem.RaceTrack;
                _dateTextBox.Text = _fullSystem.Date;
                _fullSystemCountTextBox.Text = _fullSystem.GetTotalNumberOfCombinations().ToString();
                _raceTextBox.Text = _fullSystem.FirstRace.ToString();
                _labelHorsesPerRace.Text = string.Format("{0:0.00}",_fullSystem.AverageNumberOfHorsesPerRace);
                RefreshObservers(DEFAULT_GROUP_INDEX);
            }
            else
            {
                // This chuck is executed either when we first load the form 
                // or when we the document is closed, 
                // which means that the _fullSystem is set to null

                _unitBetTextBox.Text = "";
                _fullSystemInputBox.BindLimitation(_fullSystem);
                _raceTrackTextBox.Text = "";
                _dateTextBox.Text = "";
                _fullSystemCountTextBox.Text = "";
                _raceTextBox.Text = "";
                _developedSystemTextBox.Text = "";
                RefreshObservers(DEFAULT_GROUP_INDEX);
            }
        }

        private void OnOpenExistingSystem(object sender, EventArgs e)
        {
            try
            {
                OnFormIsClosing(null, null);

                var dlg = new OpenFileDialog
                              {
                                  InitialDirectory = CommonDirectory, 
                                  Filter = Tools.FILE_FILTER, FilterIndex = 1, 
                                  RestoreDirectory = true
                              };

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Open(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open(string filename)
        {
            _fullSystem = FullSystem.Make(filename);

            if (null != _fullSystem)
            {
                BindFullSystem();
                OnCount(null, null);
            }

            Text = "[ Exotic Studio ]  (c) Kasosoft 2008 - 2011  " + filename;

            _outputTextBox.Text = "";
        }

        private void OnEditFullSystem(object sender, EventArgs e)
        {
            var f = new FullSystemForm(_fullSystem.NumberOfRaces, _fullSystem);

            if (f.ShowDialog() == DialogResult.OK)
            {
                _fullSystem = f.GetFullSystem();
                BindFullSystem();
            }
        }

        // This method is public just because the group editor calls it
        // to create a new group....  Meabe not the best way to be done
        // In a refactoring circle probably I can change the logic here
        public void OnAddGroup(object sender, EventArgs e)
        {
            int index = _fullSystem.AddGroup();
            RefreshObservers(index);
        }

        private void OnNew(object sender, EventArgs e)
        {
            OnFormIsClosing(null, null);

            var selectRaces = new SelectNumberOfRacesForm();

            if (selectRaces.ShowDialog() == DialogResult.OK)
            {
                var f = new FullSystemForm(selectRaces.GetNumberOfRaces(), null);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _fullSystem = f.GetFullSystem();
                    BindFullSystem();
                    this.Text = "[ Exotic Studio ]  (c) Kasosoft 2008 - 2011   New System";
                    _outputTextBox.Text = "";
                }
            }
        }

        public static string CommonDirectory
        {
            get
            {
                return ConfigurationSettings.AppSettings != null ?
                    ConfigurationSettings.AppSettings["COMMON_DIRECTORY_PATH"] :
                    @"C:\HorseRacingSoftware\Documents\PastPerformances";
            }
        }

        private void SaveFullSystem(string filename)
        {
            if (null != _fullSystem)
            {
                try
                {
                    if (filename.Length <= 0)
                    {
                        var dlg = new SaveFileDialog
                                      {
                                          FileName =  _fullSystem.SuggestedFileName, 
                                          Filter = Tools.FILE_FILTER, 
                                          FilterIndex = 1,
                                          InitialDirectory = CommonDirectory
                                      };


                        switch (dlg.ShowDialog())
                        {
                            case DialogResult.OK:
                                filename = dlg.FileName;
                                break;
                            default:
                                return;
                        }
                    }

                    _fullSystem.Save(filename);
                    this.Text = "[ Exotic Studio ]  (c) Kasosoft 2008 - 2011  " + filename;
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            SaveFullSystem(_fullSystem.Filename);
        }

        private void OnAbout(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void OnFormIsClosing(object sender, FormClosingEventArgs e)
        {
            if (null != _fullSystem && _fullSystem.NeedsToBeSaved)
            {
                if (DialogResult.Yes == MessageBox.Show("You want to save your changes?", "Save your changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    if (_fullSystem.Filename.Length <= 0)
                    {
                        _fullSystem.Save(CommonDirectory + @"\" + _fullSystem.SuggestedFileName);
                    }
                    else
                    {
                        _fullSystem.Save(_fullSystem.Filename);
                    }
                }
            }
        }

        private void OnCreateTickets(object sender, EventArgs e)
        {
            if (null != _fullSystem)
            {
                Cursor = Cursors.WaitCursor;
                _developedSystemTextBox.Text = _fullSystem.Develop().ToString();
                _outputTextBox.Text = _fullSystem.GetAsString();
                //_outputTextBox.Rtf = @"{\rtf1\ansi" + _fullSystem.GetCombinationsAsString() + "}";
                Cursor = Cursors.Default;
            }
        }

        private void OnShowRoundly(object sender, EventArgs e)
        {
            if (null != _fullSystem)
            {
                Cursor = Cursors.WaitCursor;

                _developedSystemTextBox.Text = _fullSystem.DevelopWithoutCompressing().ToString();
                _outputTextBox.Text = _fullSystem.GetRoundly();
                Cursor = Cursors.Default;
            }
        }

        public void OnCount(object sender, EventArgs e)
        {
            if (null != _fullSystem)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _developedSystemTextBox.Text = _fullSystem.CountCombinations().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to Count System");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void OnSize(object sender, EventArgs e)
        {
            // Resize Group Editor User Control
            Point upperLeft = _groupEditor.Location;
            _groupEditor.Width = Width - upperLeft.X - X_OFFSET;

            // Resize output text box
            upperLeft = _outputTextBox.Location;
            _outputTextBox.Width = Width - upperLeft.X - X_OFFSET;
            _outputTextBox.Height = Height - upperLeft.Y - Y_OFFSET;
        }

        private void OnShowFrequencies(object sender, EventArgs e)
        {
            if (null != _fullSystem)
            {
                OnCount(null, null);
                new FrequenciesForm(_fullSystem).ShowDialog();
            }
        }

        // It is public because it's set by FullSystem's NeedsToCreateTickets
        // when  setting the value. Probably not the best way to do it!
        // TODO: Encapsulate this logic within FullSystem or find a way to make
        // it a private detail of this class....
        public bool NeedsToCreateTickets
        {
            get
            {
                if (_fullSystem.NeedsToBeCounted)
                {
                    _developedSystemTextBox.Text = "";
                    _outputTextBox.Text = "";
                    return true;
                }
                else
                {
                    return _outputTextBox.Text.Trim().Length <= 0;
                }
            }
            set
            {
                if (value == true)
                {
                    _outputTextBox.Text = "";
                }
            }
        }

        private void OnUpdateToolbarButtons(object sender, EventArgs e)
        {
            // Called by the timer to update enable / disable Toolbar buttons and Menu Items

            // Update Toolstrip buttons
            _saveButton.Enabled = (_fullSystem != null && _fullSystem.NeedsToBeSaved);
            _editButton.Enabled = _fullSystem != null;
            _countButton.Enabled = _fullSystem != null && _fullSystem.NeedsToBeCounted;
            //_createTicketsButton.Enabled = _fullSystem != null && NeedsToCreateTickets;
            //_showRoundlyButton.Enabled = _fullSystem != null && NeedsToCreateTickets;

            _createTicketsButton.Enabled = _fullSystem != null;
            _showRoundlyButton.Enabled = _fullSystem != null;
            _showFrequenciesButton.Enabled = _fullSystem != null;

            _tsbShowWeights.Enabled = _fullSystem != null;

            // Update Menu options
            _saveMenuItem.Enabled = (_fullSystem != null && _fullSystem.NeedsToBeSaved);
            _addGroupMenuItem.Enabled = _fullSystem != null;
            _closeDocumentMenuItem.Enabled = _fullSystem != null;
            _saveAsMenuItem.Enabled = _fullSystem != null;
            _checkWinningCombinationMenuItem.Enabled = _fullSystem != null;

            if (null != _fullSystem)
            {
                if (_fullSystem.Filename.Length <= 0)
                {
                    _lockFileMenuOption.Text = FILE_CAN_BE_LOCKED_MENU_TEXT;
                    _lockFileMenuOption.Enabled = false;
                }
                else
                {
                    if (!_fullSystem.FileIsLocked)
                    {
                        _lockFileMenuOption.Text = FILE_CAN_BE_LOCKED_MENU_TEXT;
                        _lockFileMenuOption.Enabled = true;
                    }
                    else
                    {
                        _lockFileMenuOption.Text = FILE_LOCKED_MENU_TEXT;
                        _lockFileMenuOption.Enabled = false;
                    }
                }
            }
            else
            {
                _lockFileMenuOption.Text = FILE_CAN_BE_LOCKED_MENU_TEXT;
                _lockFileMenuOption.Enabled = false;
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnCloseDocument(object sender, EventArgs e)
        {
            OnFormIsClosing(null, null);

            _updateToolButtonsTimer.Stop();

            _fullSystem = null;

            BindFullSystem();

            _groupMatchesInputUserCtrl.BindFullSystem(_fullSystem);

            _updateToolButtonsTimer.Start();
        }

        private void OnSaveAs(object sender, EventArgs e)
        {
            SaveFullSystem("");
        }

        private void OnCheckWinningCombination(object sender, EventArgs e)
        {
            var f = new CheckWinningCombinationForm(_fullSystem);
            f.ShowDialog();
        }

        private void OnLockFileOnDisk(object sender, EventArgs e)
        {
            try
            {
                _fullSystem.LockFileOnDisk();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _raceTrackTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void _buttonCreateMetablito_Click(object sender, EventArgs e)
        {
            if (null != _fullSystem)
            {
                Cursor = Cursors.WaitCursor;
                _tbMetablitoCount.Text = _fullSystem.ConvertToMetablito().ToString();
                _outputTextBox.Text = _fullSystem.GetMetablitoAsString();
                Cursor = Cursors.Default;
            }
        }

        private void _tsbShowWeights_Click(object sender, EventArgs e)
        {
            OnCount(null, null);

            var f = new WeightStatisticsForm(_fullSystem);
            f.ShowDialog();
        }
    }
}