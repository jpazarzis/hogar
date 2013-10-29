using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;
using Hogar.Cynthia;
using OddsEditor.Dialogs;
using System.Diagnostics;

namespace OddsEditor.MyComponents
{
    public partial class CynthiaProjectionsFullCtrl : UserControl
    {

        Horse _horse = null;
        public CynthiaProjectionsFullCtrl()
        {
            InitializeComponent();
        }

        public void Bind(Horse horse)
        {
            _horse = horse;
            _labelHorseName.Text = _horse.Name;
            ShowCynthiaParsToGrid(_gridTodaysRacePars, horse.Parent.CynthiaParsForTheRace,null);
            LoadPastPerformances(horse);


            _cynthiaProjectionsCtrl.Bind(horse);
        }

        bool ShowCynthiaParsToGrid(DataGridView g, CynthiaPar cp, BrisPastPerformance pp)
        {
            bool cynthiaParWasChanged = false;

            g.Columns.Clear();
            g.Columns.Add("Track", "Track");
            g.Columns.Add("Class", "Class");
            g.Columns.Add("Dist", "Dist");
            g.Columns.Add("Surf", "Surf");
            g.Columns.Add("About", "About");
            g.Columns.Add("AvVar", "AvVar");
            g.Columns.Add("1stCall", "1stCall");
            g.Columns.Add("2ndCall", "2ndCall");
            g.Columns.Add("Final", "Final");

            if (cp.IsValid)
            {

                int i = g.Rows.Add();

                g[0, i].Value = cp.TrackCode;
                g[1, i].Value = cp.CynthiaClassification;
                g[2, i].Value = cp.Distance;
                g[3, i].Value = cp.Surface;
                g[4, i].Value = cp.AboutFlag;
                g[6, i].Value = Utilities.ConvertTimeToMMSSFifth(cp.FirstCall);
                g[7, i].Value = Utilities.ConvertTimeToMMSSFifth(cp.MidCall);
                g[8, i].Value = Utilities.ConvertTimeToMMSSFifth(cp.FinalCall);

            }
            else
            {
                string msg = string.Format("Sorry Cynthia par not found for \n {0} \n You want to add it manually? ", cp.ToString());

                if (MessageBox.Show(msg, "Not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        AddCynthiaParManuallyForm f = new AddCynthiaParManuallyForm(cp);
                       f.ShowDialog();
                       if (null != pp)
                       {
                           pp.Parent.ReloadCynthiaParForTheRace();

                       }
                       else
                       {
                           return ShowCynthiaParsToGrid(_gridTodaysRacePars, _horse.Parent.CynthiaParsForTheRace, null);

                       }

                       cynthiaParWasChanged = true;
                       
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return cynthiaParWasChanged;
        }

        double FirstCallAdjustment(CynthiaPar cp0, CynthiaPar cp1)
        {
            return ( (cp0.TrackCode != cp1.TrackCode) || (cp0.DistanceInYards != cp1.DistanceInYards)) ? cp0.FirstCall -cp1.FirstCall : 0.0;
        }

        double SecondCallAdjustment(CynthiaPar cp0, CynthiaPar cp1)
        {
            return ((cp0.TrackCode != cp1.TrackCode) || (cp0.DistanceInYards != cp1.DistanceInYards)) ? cp0.MidCall -cp1.MidCall : 0.0;
        }

        double FinalCallAdjustment(CynthiaPar cp0, CynthiaPar cp1)
        {
            return ((cp0.TrackCode != cp1.TrackCode) || (cp0.DistanceInYards != cp1.DistanceInYards)) ? cp0.FinalCall - cp1.FinalCall : 0.0;
        }

        private void CalculateAdjustments(CynthiaPar cp0, CynthiaPar cp1)
        {

            _txtboxFirstCallAdj.Text = FirstCallAdjustment(cp0, cp1).ToString();
            _txtboxSecondCallAdj.Text = SecondCallAdjustment(cp0, cp1).ToString();
            _txtboxFinalCallAdj.Text = FinalCallAdjustment(cp0, cp1).ToString();
        
        }

        private void CalculateProjections(CynthiaPar cp0, CynthiaPar cp1, BrisPastPerformance pp)
        {
            double firstCallProjectionDiff = FirstCallAdjustment(cp0, cp1);
            double secondCallProjectionDiff = SecondCallAdjustment(cp0, cp1);
            double finalCallProjectionDiff = FinalCallAdjustment(cp0, cp1);


             BrisPastPerformance.FractionCallsToUseForCynthia f = pp.FractionsToUseForCynthia;

            double firstCallProjection = firstCallProjectionDiff + f.FirstCall;
            double secondCallProjection = secondCallProjectionDiff + f.SecondCall;
            double finalCallProjection = finalCallProjectionDiff + f.FinalCall;

            _txtboxFirstCallProjection.Text = Utilities.ConvertTimeToMMSSFifth(firstCallProjection);

            _txtboxSecondCallProjection.Text = Utilities.ConvertTimeToMMSSFifth(secondCallProjection);

            _txtboxFinalCallProjection.Text = Utilities.ConvertTimeToMMSSFifth(finalCallProjection);

        }

        void CalculateAdjustedProjections(CynthiaPar cp0, CynthiaPar cp1, BrisPastPerformance pp)
        {
            double firstCallProjectionDiff = FirstCallAdjustment(cp0, cp1);
            double secondCallProjectionDiff = SecondCallAdjustment(cp0, cp1);
            double finalCallProjectionDiff = FinalCallAdjustment(cp0, cp1);


            BrisPastPerformance.FractionCallsToUseForCynthia f = pp.FractionsToUseForCynthia;

            double firstCallProjection = firstCallProjectionDiff + f.FirstCall;
            double secondCallProjection = secondCallProjectionDiff + f.SecondCall;
            double finalCallProjection = finalCallProjectionDiff + f.FinalCall;
            double variantDiff = (pp.AvgVariant-pp.TrackVariant) / 10.0;

            _txtboxFirstCallProjectionAdjustedByVariant.Text = Utilities.ConvertTimeToMMSSFifth(firstCallProjection + (variantDiff * 1.0 / 4.0));
            _txtboxSecondCallProjectionAdjustedByVariant.Text = Utilities.ConvertTimeToMMSSFifth(secondCallProjection + (variantDiff * 2.0 / 3.0));
            _txtboxFinalCallProjectionAdjustedByVariant.Text = Utilities.ConvertTimeToMMSSFifth(finalCallProjection + (variantDiff * 4.0 / 4.0));

        }

        void LoadPastPerformances(Horse horse)
        {

            DataGridView g = _gridPastPerformances;
            g.Columns.Clear();

            g.Columns.Add("DaysOff", "DaysOff");
            g.Columns.Add("Track", "Track");
            g.Columns.Add("Class", "Class");
            g.Columns.Add("Dist", "Dist");
            g.Columns.Add("Surf", "Surf");
            g.Columns.Add("About", "About");
            g.Columns.Add("1stCall", "1stCall");
            g.Columns.Add("2ndCall", "2ndCall");
            g.Columns.Add("Final", "Final");
            g.Columns.Add("Var", "Var");
            g.Columns.Add("AvgVar", "AvgVar");
            g.Columns.Add("Adj1stCall", "Adj1stCall");
            g.Columns.Add("Adj2ndCall", "Adj2ndCall");
            g.Columns.Add("AdjFinal", "AdjFinal");



            foreach (BrisPastPerformance pp in horse.CorrespondingBrisHorse.PastPerformances)
            {
                int i = g.Rows.Add();
                g["DaysOff", i].Value = pp.DaysSinceLastRace;
                g["Class", i].Value = pp.CynthiaParForTheRace.CynthiaClassification;
                g["Track", i].Value = pp.TrackCode;
                g["Dist", i].Value = pp.Distance;
                g["Surf", i].Value = pp.Surface;
                BrisPastPerformance.FractionCallsToUseForCynthia f = pp.FractionsToUseForCynthia;
                g["1stCall", i].Value = Utilities.ConvertTimeToMMSSFifth(f.FirstCall);
                g["2ndCall", i].Value = Utilities.ConvertTimeToMMSSFifth(f.SecondCall);
                g["Final", i].Value = Utilities.ConvertTimeToMMSSFifth(f.FinalCall);
                g["Var", i].Value = pp.TrackVariant.ToString();
                g["AvgVar", i].Value = pp.AvgVariant.ToString();
                g["Adj1stCall", i].Value = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFirstCall);
                g["Adj2ndCall", i].Value = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedSecondCall);
                g["AdjFinal", i].Value = Utilities.ConvertTimeToMMSSFifth(pp.AdjustedFinalCall);

                g.Rows[i].Tag = pp;

                foreach (DataGridViewCell cell in g.Rows[i].Cells)
                {
                    if (!pp.CynthiaParForTheRace.IsValid)
                    {
                        cell.Style.BackColor = Color.Red;
                    }
                    else
                    {
                        if (pp.IsATurfRace)
                        {
                            cell.Style.BackColor = Color.LightGreen;
                        }
                    }
                }

                
            }

        }

        private void OnInitialLoad(object sender, EventArgs e)
        {

        }

        private void OnGridPastPerformancesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BrisPastPerformance pp = (BrisPastPerformance)_gridPastPerformances.Rows[e.RowIndex].Tag;

                CynthiaPar cp = pp.CynthiaParForTheRace;

                if (ShowCynthiaParsToGrid(_gridCynthiaParsForSelectedRace, cp, pp))
                {
                    // Cynthia par was changed manually go ahead and refresh the grid
                    

                    foreach (BrisPastPerformance bpp in _horse.CorrespondingBrisHorse.PastPerformances)
                    {
                        bpp.NeedsToCalculateAdjustedCalls = true;
                    }

                    LoadPastPerformances(_horse);
                }

                Trace.WriteLine("Before ");
                _horse.UpdateObservers();
                Trace.WriteLine("after ");
                CalculateAdjustments(_horse.Parent.CynthiaParsForTheRace, cp);
                CalculateProjections(_horse.Parent.CynthiaParsForTheRace, cp, pp);
                CalculateAdjustedProjections(_horse.Parent.CynthiaParsForTheRace, cp, pp);
            }
        }

        
    }
}
