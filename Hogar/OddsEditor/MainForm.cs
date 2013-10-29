using System;
using System.Windows.Forms;
using HogarControlLibrary;
using OddsEditor.Dialogs;
using Hogar;
using OddsEditor.Dialogs.JockeyStatistics;
using OddsEditor.Dialogs.FactorWorkbench;
using OddsEditor.Dialogs.PythonEditor;
using OddsEditor.Dialogs.SelectCard;
namespace OddsEditor
{
    public partial class MainForm : GenericForm
    {
        SelectOddFilenameForm _selectOddsFileNameForm = null;

        //UpcomingRacesForm _upcomingRacesForm = null;
     

        public MainForm()
        {
            InitializeComponent();
        }

        

        private void OnExit(object sender, EventArgs e)
        {
            this.Close();
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            try
            {
                _selectOddsFileNameForm = new SelectOddFilenameForm();
                _selectOddsFileNameForm.MdiParent = this;
                _selectOddsFileNameForm.WindowState = FormWindowState.Maximized;
                _selectOddsFileNameForm.Show();
                OnShowOnlyFutureCards(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCloseDocument(object sender, EventArgs e)
        {
            
        }

        private void OnAbout(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Hogar.DbTools.DbUtilities.CloseConnection();
        }

       

        private void OnBacktestProbabilityCalculator(object sender, EventArgs e)
        {
            BacktestProbabilityCalculatorForm f = new BacktestProbabilityCalculatorForm();
            f.ShowDialog();
        }

        private void OnHandicappingFactorsPerformance(object sender, EventArgs e)
        {
            
        }

        private void OnHandicappingFactorWorkbench(object sender, EventArgs e)
        {
            try
            {
                var f = new FactorWorkbenchForm();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void OnStrategiesPerformance(object sender, EventArgs e)
        {
            
        }

        private void OnKellyCalculator(object sender, EventArgs e)
        {
            
            try
            {
                KellyCalculatorForm f = KellyCalculatorForm.Singleton;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnUpdateFactors(object sender, EventArgs e)
        {
            try
            {
                UpdateFactorsForm form = new UpdateFactorsForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnTrainerStatistics(object sender, EventArgs e)
        {
            try
            {
                TrainerStatisticsSummaryForm form = new TrainerStatisticsSummaryForm();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnTrackStatistics(object sender, EventArgs e)
        {
            try
            {
                
                WinnersTimeForm form = new WinnersTimeForm("BEL", "D", false,(int)Utilities.YARDS_IN_A_FURLONG * 6, " ");
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnFindHorsePerformances(object sender, EventArgs e)
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

        private void OnJockeyStatistics(object sender, EventArgs e)
        {
            try
            {
                var form = new JockeyStatisticsSummaryForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnShowAllCards(object sender, EventArgs e)
        {
            _showAllCardsToolStripMenuItem.Checked = true;
            _showOnlyFutureCardsToolStripMenuItem.Checked = false;
            _showOnlyTodaysCardsToolStripMenuItem.Checked = false;
            _selectOddsFileNameForm.DisplayCards(SelectOddFilenameForm.DisplayType.All);
        }

        private void OnShowOnlyTodaysCards(object sender, EventArgs e)
        {
            _showAllCardsToolStripMenuItem.Checked = false;
            _showOnlyFutureCardsToolStripMenuItem.Checked = false;
            _showOnlyTodaysCardsToolStripMenuItem.Checked = true;
            _selectOddsFileNameForm.DisplayCards(SelectOddFilenameForm.DisplayType.Today);
        }

        private void OnShowOnlyFutureCards(object sender, EventArgs e)
        {
            _showAllCardsToolStripMenuItem.Checked = false;
            _showOnlyFutureCardsToolStripMenuItem.Checked = true;
            _showOnlyTodaysCardsToolStripMenuItem.Checked = false;
            _selectOddsFileNameForm.DisplayCards(SelectOddFilenameForm.DisplayType.Future);
        }

        private void OnMaintRaceTracks(object sender, EventArgs e)
        {
            try
            {
                MaintRaceTracksForm f = new MaintRaceTracksForm();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCompareTracks(object sender, EventArgs e)
        {
            
            try
            {
                CompareRaceTracksForm f = new CompareRaceTracksForm();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSpecifyParametersForPrimeBet(object sender, EventArgs e)
        {
            try
            {
                var f = new PrimeBetSpecificationForm();
                f.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void OnBestBetsOfTheday(object sender, EventArgs e)
        {
            try
            {
                var f = new BestBetsForm();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _selectCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new SelectCardForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    var sf = new SummaryForm(f.SelectedFilename);
                    sf.Show();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _pythonEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new PythonEditorForm();
                f.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
