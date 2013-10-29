using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Hogar.Research.GeneticAlgorithm;

namespace GeneticResearch
{
    public partial class MainForm : Form
    {
        private SolutionPopulation _sp;

        public MainForm()
        {
            InitializeComponent();
        }

      

        

        private void OnGo(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _sp = SolutionPopulation.Make(PopulationSize,(int)_cbNUmberOfRacesToLoad.SelectedItem);
                _sp.MutationRate = (int)_cbMutationRate.SelectedItem;
                                
                var max = (int)_cbMaxNumberOfGenerations.SelectedItem;
                var fitnessTarget = (double)_cbFitnessTarget.SelectedItem;

                for (int i = 0; i < max; i++)
                {
                    _sp.CreateNextGeneration();
                    _tbFitness.Text = string.Format("{0:0.00}", _sp.BestFitness);
                    _tbGenerationCount.Text = i.ToString();
                    if (_sp.BestFitness <= fitnessTarget)
                    {
                        break;
                    }
                    Application.DoEvents();
                }
                _buttonSaveToDb.Enabled = true;
                _buttonBackTest.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private int PopulationSize
        {
            get
            {
                return (int)_cbPopulationSize.SelectedItem;
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _buttonSaveToDb.Enabled = false;
            _buttonBackTest.Enabled = false;

            _cbPopulationSize.Items.Clear();
            _cbPopulationSize.Items.Add(10);
            _cbPopulationSize.Items.Add(20);
            _cbPopulationSize.Items.Add(50);
            _cbPopulationSize.Items.Add(100);
            _cbPopulationSize.Items.Add(200);
            _cbPopulationSize.Items.Add(400);

            _cbPopulationSize.SelectedIndex = 0;

            _cbMaxNumberOfGenerations.Items.Add(10);
            _cbMaxNumberOfGenerations.Items.Add(100);
            _cbMaxNumberOfGenerations.Items.Add(500);
            _cbMaxNumberOfGenerations.Items.Add(1000);
            
            _cbMaxNumberOfGenerations.SelectedIndex = 3;

            for (int i = 0; i < 20; i++)
            {
                _cbMutationRate.Items.Add(i);    
            }

            _cbMutationRate.SelectedItem = 7;
            
            _cbFitnessTarget.Items.Add(0.01);
            _cbFitnessTarget.Items.Add(0.02);
            _cbFitnessTarget.Items.Add(0.03);
            _cbFitnessTarget.Items.Add(0.04);

            _cbFitnessTarget.SelectedIndex = 2;


            _cbNUmberOfRacesToLoad.Items.Add(100);
            _cbNUmberOfRacesToLoad.Items.Add(200);
            _cbNUmberOfRacesToLoad.Items.Add(500);
            _cbNUmberOfRacesToLoad.Items.Add(1000);
            _cbNUmberOfRacesToLoad.Items.Add(2000);
            _cbNUmberOfRacesToLoad.Items.Add(5000);
            _cbNUmberOfRacesToLoad.Items.Add(10000);

            _cbNUmberOfRacesToLoad.SelectedItem = 100;


            _tbGenerationCount.Text = "";

            _tbFitness.Text = "";

        }

        private void OnSaveToDb(object sender, EventArgs e)
        {
            try
            {
                _sp.SaveToDb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _buttonSaveToDb.Enabled = false;
            }
        }

        private void OnBackTest(object sender, EventArgs e)
        {
            try
            {
                var f = new BackTestForm(_sp.BestSolution);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnBacktestDbSolution(object sender, EventArgs e)
        {
            try
            {
                var f = new BackTestForm(Solution.MakeFromDb());
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
