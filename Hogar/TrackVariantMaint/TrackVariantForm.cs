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
    public partial class TrackVariantForm : Form
    {
        private StarterInfoCollection _starterInfoCollection = new StarterInfoCollection();

        private TrackVariantGraph _tvg ;

        
        readonly private string _trackCode;
        readonly private string _surface;


        public TrackVariantForm(string trackCode, string surface)
        {
            _trackCode = trackCode;
            _surface = surface;

          InitializeComponent();
        }

        private void LoadLoadingMethodsComboBox()
        {
            _cbLoadingMethod.Items.Clear();

            foreach (var v in Enum.GetValues(typeof(StarterInfoCollection.LoadingMethod)))
            {
                _cbLoadingMethod.Items.Add(v);
            }

            _cbLoadingMethod.SelectedItem = StarterInfoCollection.LoadingMethod.VeryTight;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} {1} ", _trackCode, _surface);
            LoadLoadingMethodsComboBox();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _tvg = new TrackVariantGraph();
                _starterInfoCollection.SelectedLoadingMethod = (StarterInfoCollection.LoadingMethod)_cbLoadingMethod.SelectedItem ;
                _starterInfoCollection.Load(_trackCode, _surface);
                _tbNumberOfHorses.Text = _starterInfoCollection.Count.ToString();
             
                LoadGraph();
                _tvg.InitializeVariant();
                UpdateDisplay();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void LoadGraph()
        {
            var list = new List<StarterInfo>();
            string currentHorse = "";

            foreach (var starterInfo in _starterInfoCollection)
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

            _tbTotalNumberOfVertices.Text = _tvg.Verteces.ToList().Count.ToString();
            _tbTotalNumberOfEdges.Text = _tvg.GetAllAvailableEdges().Count.ToString();
        }


       

        private void AddDataPointsToGraph(List<StarterInfo> list)
        {
            if (list.Count <= 0)
                return;

            CombinationCalculator<StarterInfo>.GenerateCombinations(list, 2).ForEach(l => AddPairToGraph(l[0], l[1]));
        }

        private void AddPairToGraph(StarterInfo si1, StarterInfo si2)
        {
            _tvg.InsertBidectionalEdge(si1.Date, si1.ThisHorseProjectedTime, si2.Date, si2.ThisHorseProjectedTime);           
        }

        private void _buttonLoadVariant_Click(object sender, EventArgs e)
        {
            for (; ;)
            {
                double stdev = _tvg.AdjustVariant();
                _tbStdDev.Text = string.Format("{0:0.000}", stdev);
                Application.DoEvents();
                if(stdev < 0.01)
                    break;
            }

            UpdateDisplay();

            
        }

        void UpdateDisplay()
        {
           
            _gridVariant.DataSource = _tvg.Verteces.ToList().OrderBy(v => v.Key).ToList();
            _tbNumberOfVerticesWithValidVariant.Text = _tvg.Verteces.Count().ToString(); 
        }

 
        private void _buttonNormalize_Click(object sender, EventArgs e)
        {
            _tvg.NormalizeVariant();
            UpdateDisplay();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _cbLoadingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initialize();
        }

        private string GetTrackDescription(string trackCode, string surface)
        {
            surface = surface.Trim();
            string s = surface;

            if(surface=="d")
            {
                s = "id";
            }

            else if(surface=="t")
            {
                s = "it";
            }

            return string.Format("{0}_{1}", trackCode.Trim(), s);
        }

        private void OnSaveVariantToDb(object sender, EventArgs e)
        {
            try
            {
                _buttonNormalize_Click(null, null);

                string trackDesc = GetTrackDescription(_trackCode, _surface);
                DbReader.ExecuteNonQuery(string.Format(SQL_DELETE_VARIANT, trackDesc));
                _tvg.Verteces.ToList().ForEach(v => DbReader.ExecuteNonQuery(string.Format(SQL_INSERT_VARIANT, trackDesc, _trackCode, _surface, v.Key, v.Variant)));

                MessageBox.Show("done saving the variant");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        const string SQL_DELETE_VARIANT = @"delete TRACK_VARIANT WHERE track_desc='{0}' ";
        const string SQL_INSERT_VARIANT = @"INSERT INTO TRACK_VARIANT (track_desc, TRACK_CODE,SURFACE,RACING_DATE,VARIANT) VALUES ('{0}',  '{1}', '{2}', '{3}', {4})";

        
     
    }
}