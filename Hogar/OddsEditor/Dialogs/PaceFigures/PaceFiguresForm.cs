using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.Dialogs.PaceFigures
{
    public partial class PaceFiguresForm : Form
    {
        readonly string _trackCode;
        readonly int _distance;
        readonly string _surface;
        readonly string _aboutDistanceFlag;

        private readonly string _thisRaceDate;
        private readonly int _thisRaceNumber;

        private PaceFigureCollection _paceFigureColletion;
        private PaceFigureFilter _filter;


        public PaceFiguresForm(string trackCode, int distance, string surface, string thisRaceDate, string aboutDistanceFlag, int thisRaceNumber)
        {
            _trackCode = trackCode;
            _distance = distance;
            _surface = surface;
            _aboutDistanceFlag = aboutDistanceFlag;
            _thisRaceDate = thisRaceDate;
            _thisRaceNumber = thisRaceNumber;

            InitializeComponent();
        }

        private void PaceFiguresForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _paceFigureColletion = new PaceFigureCollection(_trackCode, _distance, _surface, _aboutDistanceFlag);

            if (_paceFigureColletion.Count <= 0)
            {
                MessageBox.Show(string.Format("No races found for Track Code = {0} Distance = {1}  Surface = {2} , About Flag = {3} ", _trackCode, _distance, _surface, _aboutDistanceFlag));
                this.Close();
                return;
            }

            _filter = new PaceFigureFilter(_paceFigureColletion);
            _tbTrackCode.Text = _trackCode;
            _tbSurface.Text = _surface;
            _tbDistance.Text = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(_distance);
            _tbNumberOfRaces.Text = _paceFigureColletion.Count.ToString();
            _grid.Columns.Clear();
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;      
            _grid.Columns.Add("Date", "Date");
            _grid.Columns.Add("Class", "Class");
            _grid.Columns.Add("Number", "Number");
            _grid.Columns.Add("Cond", "Cond");
            _grid.Columns.Add("F1", "F1");
            _grid.Columns.Add("F2", "F2");
            _grid.Columns.Add("Final", "Final");

            _grid.Rows.Add(_paceFigureColletion.Count);

            int rowIndex = 0;
            foreach (var figure in _paceFigureColletion)
            {
                DataGridViewRow row = _grid.Rows[rowIndex++];
                var cells = row.Cells;

                cells[0].Value = figure.DateOfTheRace;
                cells[1].Value = figure.RaceClassification;
                cells[2].Value = figure.RaceNumber;
                cells[3].Value = figure.TrackCondition;
                cells[4].Value = figure.Call1;
                cells[5].Value = figure.Call2;
                cells[6].Value = figure.FinalCall;

                row.Tag = figure;

                if(figure.DateOfTheRace == _thisRaceDate && _thisRaceNumber == figure.RaceNumber)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }

            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Cursor = Cursors.Default;
        }

        private void _buttonFilter_Click(object sender, EventArgs e)
        {
            var form = new PaceFiguresFilterForm(_filter);

            if (form.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
