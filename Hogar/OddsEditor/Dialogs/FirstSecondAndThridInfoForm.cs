using System;
using System.Windows.Forms;
using Hogar.BrisPastPerformances;

namespace OddsEditor.Dialogs
{
    public partial class FirstSecondAndThridInfoForm : Form
    {
        readonly BrisPastPerformance _pp;

        public FirstSecondAndThridInfoForm(BrisPastPerformance pp)
        {
            _pp = pp;
            InitializeComponent();
        }

        void OnInitialLoad(object sender, EventArgs e)
        {
            _grid.Columns.Add("Name","Name");
            _grid.Columns.Add("Weight","Weight");

            AddHorseToGrid(_pp.WinnersName,_pp.WinnersWeight);
            AddHorseToGrid(_pp.SecondPlaceFinisherName, _pp.SecondPlaceFinisherWeight);
            AddHorseToGrid(_pp.ThirdPlaceFinisherName, _pp.ThirdPlaceFinisherWeight);

        }

        void AddHorseToGrid(string name, string weight)
        {
            int index = _grid.Rows.Add();

            _grid["Name", index].Value = name;
            _grid["Weight", index].Value = weight;
        }
    }
}
