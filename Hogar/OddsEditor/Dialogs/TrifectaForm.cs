using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hogar;
using Hogar.Betting;
using OddsEditor.MyComponents;


namespace OddsEditor.Dialogs
{
    public partial class TrifectaForm : GenericForm
    {
        
        readonly Race _race;
        TrifectaPicksControl _firstPositionCtrl = null;
        TrifectaPicksControl _secondPositionCtrl = null;
        TrifectaPicksControl _thirdPositionCtrl = null;

        TrifectaPicksControl _selectedCtrl = null;


        List<Button> _numberButtons = new List<Button>();

        bool _isLoading = true;        

        public TrifectaForm(Race race)
        {
            _race = race;
            
            InitializeComponent();

         
        }

       

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _isLoading = true;
            this.Text = _race.Parent.TrackCode + " " + _race.Parent.Date;
            _comboboxAmountToWin.Text = "1000";
            _trifectaPayoutsControl.UpdateParentEvent += PayoutsControlWasChanged;
            LoadHorseNumbers();
            LoadSelectionComponents();
            LoadOddsControl();
            ControlWasSelected(_firstPositionCtrl);
            _oddsControl.OddsWereChangedEvent += UpdateScreen;
            _isLoading = false;
            RaceSummaryControl r = new RaceSummaryControl();
            r.BindRace(_race);
            _panelRaceSummary.Controls.Add(r);
        }

        public void PayoutsControlWasChanged()
        {
            UpdateNecessarySubsystemsControl();
        }

        private void LoadOddsControl()
        {

            SortedDictionary<int, Odds> odds = new SortedDictionary<int, Odds>();
            
            foreach (Horse h in _race.Horses)
            {
                if (h.Scratched == false)
                {
                    int n = Utilities.GetHorseNumberFromProgramNumber(h.ProgramNumber);

                    if (false == odds.ContainsKey(n))
                    {
                        odds.Add(n, h.MyOdds);
                    }
                }
            }

            

            _oddsControl.SetOdds(odds);
            
        }

        private void PaintHorseNumberButtons()
        {
            if (null == _selectedCtrl)
            {
                return;
            }

            foreach (Button b in _numberButtons)
            {
                int n = Convert.ToInt32(b.Text);

                if (_selectedCtrl.IsHorseSelected(n))
                {
                    SetButtonToSelectedColor(b);
                }
                else
                {
                    SetButtonToUnselectedColor(b);
                }
            }

        }

        public void ControlWasSelected(TrifectaPicksControl selectedCtrl)
        {
            if (_firstPositionCtrl != selectedCtrl)
            {
                _firstPositionCtrl.UnselectIt();
            }

            if (_secondPositionCtrl != selectedCtrl)
            {
                _secondPositionCtrl.UnselectIt();
            }

            if (_thirdPositionCtrl != selectedCtrl)
            {
                _thirdPositionCtrl.UnselectIt();
            }

            selectedCtrl.SelectIt();

            _selectedCtrl = selectedCtrl;

            PaintHorseNumberButtons();
        }

        private void LoadSelectionComponents()
        {
            _firstPositionCtrl = new TrifectaPicksControl("Position 1");
            _secondPositionCtrl = new TrifectaPicksControl("Position 2");
            _thirdPositionCtrl = new TrifectaPicksControl("Position 3");

            _firstPositionCtrl.ControlSelectedEvent += ControlWasSelected;
            _secondPositionCtrl.ControlSelectedEvent += ControlWasSelected;
            _thirdPositionCtrl.ControlSelectedEvent += ControlWasSelected;

            _panelSelections.Controls.Add(_firstPositionCtrl);
            _panelSelections.Controls.Add(_secondPositionCtrl);
            _panelSelections.Controls.Add(_thirdPositionCtrl);
        }

        private void OnUserSelectedAHorse(object sender, EventArgs e)
        {
            Button b = (Button) sender;

            string s = b.Text;

            _selectedCtrl.AddOrRemove(Convert.ToInt32(s));

            PaintHorseNumberButtons();

            UpdateScreen();
        }

        private void LoadHorseNumbers()
        {
            List<int> horseNumbers = new List<int>();

            foreach (Horse h in _race.Horses)
            {
                if (h.Scratched == false)
                {
                    int n = Utilities.GetHorseNumberFromProgramNumber(h.ProgramNumber);

                    if (false == horseNumbers.Contains(n))
                    {
                        horseNumbers.Add(n);
                    }
                }
            }

            horseNumbers.Sort();
            _numberButtons.Clear();

            foreach (int n in horseNumbers)
            {
                Button b = new Button();
                b.Text = n.ToString();
                b.BackColor = Color.Goldenrod;
                b.FlatAppearance.BorderColor = Color.Goldenrod;
                b.FlatAppearance.BorderSize = 0;
                b.FlatStyle = FlatStyle.Flat;
                b.Click += new System.EventHandler(OnUserSelectedAHorse);
                b.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
                _panelHorseNumbers.Controls.Add(b);
                b.Width = 50;
                b.Height = 50;

                _numberButtons.Add(b);
            }

            PaintHorseNumberButtons();
        }

        void SetButtonToSelectedColor(Button b)
        {
            b.BackColor = Color.Red;
            b.ForeColor = Color.White;

            b.FlatAppearance.BorderColor = Color.Red;

            b.FlatAppearance.BorderSize = 0;
            b.FlatStyle = FlatStyle.Flat;
        }

        void SetButtonToUnselectedColor(Button b)
        {
            b.BackColor = Color.Goldenrod;
            b.ForeColor = Color.Blue;
            b.FlatAppearance.BorderColor = Color.Goldenrod;
            b.FlatAppearance.BorderSize = 0;
            b.FlatStyle = FlatStyle.Flat;
        }

        double AmountToWin
        {
            get
            {
                string s = _comboboxAmountToWin.Text;

                if (s.Length <= 0)
                {
                    return 1000;
                }
                else
                {
                    return Convert.ToDouble(s);
                }
            }
        }

        void UpdateScreen()
        {
            TrifectaFullSystem tr = new TrifectaFullSystem();

            tr.AmountToWin = AmountToWin;

            tr.SpecifySelectionsForTrifectasPosition(TrifectaFullSystem.Position.First, _firstPositionCtrl.Selections);
            tr.SpecifySelectionsForTrifectasPosition(TrifectaFullSystem.Position.Second, _secondPositionCtrl.Selections);
            tr.SpecifySelectionsForTrifectasPosition(TrifectaFullSystem.Position.Third, _thirdPositionCtrl.Selections);

            string txt = "Total : " + tr.CountAndDevelop(_oddsControl.GetOdds()).ToString();

            txt += " (" + tr.DutchingRate.ToString() + ")";

            _txtboxAmountNeeded.Text = tr.TotalBet.ToString();

            _txtboxTotalNumberOfCombinations.Text = txt;
            _trifectaPayoutsControl.LoadCombinations(tr.RawSubsystems);
            _trifectaSubsystemsControl.LoadSubsystem(tr.CondensedSubsystems);

            _txtBoxROI.Text = tr.ROI.ToString();
            
        }

        private void OnAmountToWinChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
            {
                UpdateScreen();
            }
        }

        private void UpdateNecessarySubsystemsControl()
        {
            TrifectaFullSystem tr = new TrifectaFullSystem();
            tr.AmountToWin = AmountToWin;
            tr.SpecifySelectionsForTrifectasPosition(TrifectaFullSystem.Position.First, _firstPositionCtrl.Selections);
            tr.SpecifySelectionsForTrifectasPosition(TrifectaFullSystem.Position.Second, _secondPositionCtrl.Selections);
            tr.SpecifySelectionsForTrifectasPosition(TrifectaFullSystem.Position.Third, _thirdPositionCtrl.Selections);
            tr.CountAndDevelop(_oddsControl.GetOdds());
            List<TrifectaSubsystem> selectedCombos = _trifectaPayoutsControl.SelectedCombinations;
            TrifectaFullSystem tr2 = new TrifectaFullSystem(selectedCombos);
            _trifectaSubsystemsControl.LoadSubsystem(tr2.CondensedSubsystems);
        }

    
      
    }

    
}
