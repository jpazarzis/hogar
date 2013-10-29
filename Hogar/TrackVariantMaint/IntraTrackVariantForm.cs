using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Algorithms;
using Hogar.Algorithms.TrackVariant;
using Hogar.DbTools;

namespace TrackVariantMaint
{
    public partial class IntraTrackVariantForm : Form
    {
        private IntraTrackStarterInfoCollection _dbCollection;

        private TrackVariantGraph _tvg;

        public IntraTrackVariantForm()
        {
            InitializeComponent();
        }

        private void _buttonLoadFromDb_Click(object sender, EventArgs e)
        {
            _dbCollection = new IntraTrackStarterInfoCollection();
            _dbCollection.LoadFromDb();
            _tbNumberOfHorses.Text = _dbCollection.Count.ToString();

            LoadGraph();
            _tvg.InitializeVariant();
        }

        private void LoadGraph()
        {

            _tvg = new TrackVariantGraph();
            var list = new List<IntraTrackStarterInfo>();
            string currentHorse = "";

            _trackCodeMap.Clear();
            _trackSurfaceMap.Clear();


            foreach (var starterInfo in _dbCollection)
            {
                if (starterInfo.HorseName != currentHorse)
                {
                    AddDataPointsToGraph(list);
                    list.Clear();
                    currentHorse = starterInfo.HorseName;
                }

                list.Add(starterInfo);
            }

            AddDataPointsToGraph(list);

            _tbTotalNumberOfVertices.Text = _tvg.Verteces.Count().ToString();
            _tbTotalNumberOfEdges.Text = _tvg.GetAllAvailableEdges().Count.ToString();

        }

        private void AddDataPointsToGraph(List<IntraTrackStarterInfo> list)
        {
            if (list.Count <= 0)
                return;


            var d = new Dictionary<string, TimeForSpecificTrack>();

            foreach (var si in list)
            {
                if(!_trackCodeMap.ContainsKey(si.TrackDesc))
                {
                    _trackCodeMap.Add(si.TrackDesc,si.TrackCode);
                }

                if (!_trackSurfaceMap.ContainsKey(si.TrackDesc))
                {
                    _trackSurfaceMap.Add(si.TrackDesc, si.Surface);
                }

                if(!d.ContainsKey(si.TrackDesc))
                {
                    d.Add(si.TrackDesc, new TimeForSpecificTrack() {TrackCode = si.TrackCode, Surface = si.Surface, TrackDesc = si.TrackDesc});
                }

                d[si.TrackDesc].AddTime(si.ProjectedTime);
            }

            CombinationCalculator<TimeForSpecificTrack>.GenerateCombinations(d.Values.ToList(), 2).ForEach(pair => AddPairToGraph(pair[0], pair[1]));
        }

        private void AddPairToGraph(TimeForSpecificTrack t1, TimeForSpecificTrack t2)
        {
            _tvg.InsertBidectionalEdge(t1.TrackDesc, t1.AverageTime, t2.TrackDesc, t2.AverageTime);           
        }

        class TimeForSpecificTrack
        {
            public string TrackDesc { get; set; }
            public string TrackCode { get; set; }
            public string Surface { get; set; }

            private readonly List<double> _time = new List<double>();


            public double AverageTime
            {
                get
                {
                    return _time.Average();
                }
            }

            public void AddTime(double time)
            {
                _time.Add(time);
            }
        }

        private void _buttonAdjustVariant_Click(object sender, EventArgs e)
        {
            double stdev = _tvg.AdjustVariant();
            _tbStdDev.Text = string.Format("{0:0.000}", stdev);
           UpdateDisplay();
        }

        void UpdateDisplay()
        {

            _grid.DataSource = _tvg.Verteces.ToList().OrderBy(v => v.Key).ToList();
            _tbNumberOfVerticesWithValidVariant.Text = _tvg.Verteces.Count().ToString();
        }

        private void _buttonSaveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                DbReader.ExecuteNonQuery(SQL_DELETE_VARIANT);

                
                _tvg.Verteces.ToList().ForEach(v => DbReader.ExecuteNonQuery(string.Format(SQL_INSERT_VARIANT, v.Key, _trackCodeMap[v.Key], _trackSurfaceMap[v.Key], v.Variant)));

                MessageBox.Show("done saving the variant");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        Dictionary<string,string> _trackCodeMap = new Dictionary<string, string>();
        Dictionary<string, string> _trackSurfaceMap = new Dictionary<string, string>();


        const string SQL_DELETE_VARIANT = @"DELETE TRACK_INTRA_VARIANT ";
        const string SQL_INSERT_VARIANT = @"INSERT INTO TRACK_INTRA_VARIANT (TRACK_DESC, TRACK_CODE,SURFACE,INTRA_VARIANT) VALUES ('{0}',  '{1}', '{2}',  {3})";

    }
}
