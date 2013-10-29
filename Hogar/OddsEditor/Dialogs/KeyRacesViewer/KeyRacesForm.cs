using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.KeyRaces;

namespace OddsEditor.Dialogs.KeyRacesViewer
{
    public partial class KeyRacesForm : Form
    {
        private readonly Race _race;

        private KeyRaces _keyRaces;

        readonly private List<HorseCtrl> _horseCtrls = new List<HorseCtrl>();
        readonly private List<RaceInfoCtrl> _raceInfoCtrls = new List<RaceInfoCtrl>();
        private Pen _pen = new Pen(Color.Blue, 3);

        public KeyRacesForm(Race race)
        {
            _race = race;
            InitializeComponent();
        }

        private void KeyRacesForm_Load(object sender, EventArgs e)
        {
            _keyRaces = KeyRaces.Make(_race);

            LoadRaces();
            
            _tbTrackCode.Text = _race.Parent.TrackCode;
            _tbRaceNumber.Text = _race.RaceNumber.ToString();
            _tbSurface.Text = _race.Horses[0].CorrespondingBrisHorse.TodaysSurface;
            _tbDistance.Text = Utilities.ConvertYardsToMilesOrFurlongsAbreviation(_race.Horses[0].CorrespondingBrisHorse.DistanceInYards);
        }

        void LoadRaces()
        {
            CreateHorses();
            CreateRaceInfos();
            Invalidate();
        }

        static public int NumberOfKeyRaces(Horse horse, KeyRaces keyRaces)
        {
            int count = 0;

            foreach (var ri in keyRaces.Graph[horse])
            {
                if(ri.Matches >=2)
                {
                    ++count;
                }
            }

            return count;
        }

        void CreateLinks(Graphics graphics)
        {
            graphics.Clear(Color.LightSkyBlue);

            if (null == _keyRaces || null == _keyRaces.Graph)
            {
                return;
            }

            foreach(var horse in _keyRaces.Graph.Keys)
            {
                var hctrl = _horseCtrls.Find(hc => hc.Horse == horse);

                if(null == hctrl)
                    continue;

                foreach (var raceInfo in _keyRaces.Graph[horse])
                {
                    var rictrl = _raceInfoCtrls.Find(ri => ri.RaceInfo == raceInfo);

                    if(null == rictrl)
                        continue;

                    Connect(graphics, hctrl, rictrl);

                }
            }
        }

        private void Connect(Graphics graphics, HorseCtrl hctrl, RaceInfoCtrl rictrl)
        {
            var p1 = new Point(hctrl.Left + hctrl.Width, hctrl.Top + hctrl.Height / 2);
            var p2 = new Point(rictrl.Left, rictrl.Top + rictrl.Height / 2);
            graphics.DrawLine(_pen, p1, p2);

        }

        void CreateHorses()
        {
            _horseCtrls.ForEach(ctrl => Controls.Remove(ctrl));
            _horseCtrls.Clear();

            int x = 10, y = 80;

            foreach (var horse in _keyRaces.Horses.OrderBy(h=>h.RealTimeOdds))
            {
                
                var ctrl = new HorseCtrl(horse,NumberOfKeyRaces(horse, _keyRaces));
                this.Controls.Add(ctrl);
                ctrl.Location = new Point(x, y);
                y += ctrl.Height + 20;
                _horseCtrls.Add(ctrl);
            }
        }

        void CreateRaceInfos()
        {

            _raceInfoCtrls.ForEach(ctrl=>Controls.Remove(ctrl));
            _raceInfoCtrls.Clear();

            int x = 520, y = 110;


            List<RaceInfo> raceInfoList = null;

            if(_rbGoldenFigure.Checked)
            {
                raceInfoList = _keyRaces.Races.OrderBy(ri => (-1) * ri.GoldenFigure).ToList();
            }
            else if (_rbGoldenPaceFigure.Checked)
            {
                raceInfoList = _keyRaces.Races.OrderBy(ri => (-1) * ri.GoldenPaceFigure).ToList();
            }
            else
            {
                raceInfoList = _keyRaces.Races.OrderBy(ri => ri.DaysSince).ToList();
            }


            foreach (var raceinfo in raceInfoList)
            {
                if(raceinfo.Matches >=2)
                {
                    var ctrl = new RaceInfoCtrl(raceinfo);
                    this.Controls.Add(ctrl);
                    ctrl.Location = new Point(x, y);
                    y += ctrl.Height + 20;
                    _raceInfoCtrls.Add(ctrl);    
                }
                
            }
        }

        private void KeyRacesForm_Paint(object sender, PaintEventArgs e)
        {
            CreateLinks(e.Graphics);
        }


        private void _rbGoldenPaceFigure_CheckedChanged(object sender, EventArgs e)
        {
            CreateRaceInfos();
            Invalidate();
        }

        
        
    }
}
