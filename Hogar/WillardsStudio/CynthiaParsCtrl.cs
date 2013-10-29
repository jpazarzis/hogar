using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.Cynthia;
using Hogar.Willard;    

namespace WillardsStudio
{
    public partial class CynthiaParsCtrl : UserControl
    {
        RaceInfo _ri = null;

        List<HorseInfo> _horseInfo = null;

        public CynthiaParsCtrl()
        {
            InitializeComponent();
        }

        public void BindRaceInfo(RaceInfo ri, List<HorseInfo> horseInfo)
        {
            _ri = ri;
            _horseInfo = horseInfo;

            CynthiaPar cp = CynthiaPar.Make(ri.TrackCode, ri.Year, ri.Month, ri.Day,ri.RaceNumber);
            _txtboxClass.Text = cp.CynthiaClassification;
            _txtboxFirstCall.Text = cp.FirstCall.ToString();
            _txtboxSecondCall.Text = cp.MidCall.ToString();
            _txtboxFinalTime.Text = cp.FinalCall.ToString();
       

            
            double firstCallWSP = WillardSpeedFigure.Make(ri, cp, WillardSpeedFigure.CallOfTheRace.First, 120.0,0.0);
            double secondCallWSP = WillardSpeedFigure.Make(ri, cp, WillardSpeedFigure.CallOfTheRace.Second, 120.0,0.0);
            double finalCallWSP = WillardSpeedFigure.Make(ri, cp, WillardSpeedFigure.CallOfTheRace.Final, 120.0,0.0);


            _txtboxSpeedForFisrtCall.Text = (ri.FirstCallInFeet / cp.FirstCall).ToString();
            _txtboxSpeedForSecondCall.Text = (ri.SecondCallInFeet / cp.MidCall).ToString();
            _txtboxSpeedForFinalCall.Text = (ri.DistanceOfTheRaceInFeet / cp.FinalCall).ToString();

            _txtboxFirstCallWSF.Text = firstCallWSP.ToString();
            _txtboxSecondCallWSF.Text = secondCallWSP.ToString();
            _txtboxFinalCallWSF.Text = finalCallWSP.ToString();


            foreach (HorseInfo hf in horseInfo)
            {
                hf.CalculateWSF(ri);
            }

            _grid.Columns.Clear();
            _grid.Columns.Add("Name", "Name");
            _grid.Columns.Add("1stCall", "1stCall");
            _grid.Columns.Add("2ndCall", "2ndCall");
            _grid.Columns.Add("FinalCall", "FinalCall");

            LoadGrid(horseInfo);

        }


        private void OnSave(object sender, EventArgs e)
        {
            if (null != _horseInfo)
            {
                try
                {
                    foreach (HorseInfo hf in _horseInfo)
                    {
                        hf.SaveToDb();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadGrid(List<HorseInfo> horseInfo)
        {
            foreach (HorseInfo hf in horseInfo)
            {
                int rowIndex = _grid.Rows.Add();

                DataGridViewCellCollection cells = _grid.Rows[rowIndex].Cells;

                cells[0].Value = hf.Name;
                cells[1].Value = string.Format("{0:0.00}",hf.FirstCallWSF);
                cells[2].Value = string.Format("{0:0.00}",hf.SecondCallWSF);
                cells[3].Value = string.Format("{0:0.00}",hf.FinalCallWSF);
            }
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {

        }

        

    }
}
