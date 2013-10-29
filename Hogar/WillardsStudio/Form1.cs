using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.DbTools;
using System.Data.SqlClient;
using Hogar.Willard;

namespace WillardsStudio
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void OnIntialLoad(object sender, EventArgs e)
        {
            try
            {
                string dbPath = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                this.Text = dbPath;
                Hogar.DbTools.DbUtilities.ConnectionString = dbPath;

                foreach (RaceTrackInfo rti in RaceTracks.RaceTrackInfoCollection)
                {
                    _comboBoxTrackCode.Items.Add(rti);
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        RaceTrackInfo SelectedTrack
        {
            get
            {
                return (RaceTrackInfo)_comboBoxTrackCode.SelectedItem;
            }
        }

        private void OnSelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadRacingDatesToTreeCtrl();    
        }


        private void LoadRacingDatesToTreeCtrl()
        {
            _treeViewAvailableRaces.Nodes.Clear();

            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format("SELECT DISTINCT(DATE_OF_THE_RACE) FROM RACE_DESCRIPTION WHERE TRACK_CODE = '{0}'", SelectedTrack.TrackCode);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string  dateStr = myReader["DATE_OF_THE_RACE"].ToString();

                        _treeViewAvailableRaces.Nodes.Add(dateStr);
                        
                    }
                }       
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }

        private void LoadRacesForDay(TreeNode parentNode)
        {
            SqlDataReader myReader = null;
            try
            {

                
                string dateStr = parentNode.Text;
                string sql = string.Format("EXEC SelectDataToCalculateWillysFigures '{0}' , '{1}'	", SelectedTrack.TrackCode, dateStr);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        RaceInfo ri = RaceInfo.Make(myReader);
                        TreeNode tn = parentNode.Nodes.Add(ri.ToString());
                        tn.Tag = ri;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ShowMessage(ex.Message);
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                   }
            }
        }

        private void LoadHorsesForTheRace(TreeNode parentNode)
        {
            RaceInfo ri = (RaceInfo)parentNode.Tag;


            SqlDataReader myReader = null;
            try
            {
                string dateStr = parentNode.Text;
                string sql = string.Format("SELECT ID, HORSE_NAME, PROGRAM_NUMBER, WEIGHT, CALL_1_LENGTHS_BEHIND, CALL_2_LENGTHS_BEHIND,  CALL_3_LENGTHS_BEHIND, STRETCH_LENGTHS_BEHIND,  FINISH_LENGTHS_BEHIND FROM RACE_STARTERS WHERE RACE_ID = {0} AND PROGRAM_NUMBER != 'SCR'", ri.RaceID);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {

                        int weight = (int)myReader["WEIGHT"];
                        double call1LengthsBehind = (double)myReader["CALL_1_LENGTHS_BEHIND"];
                        double call2LengthsBehind = (double)myReader["CALL_2_LENGTHS_BEHIND"];
                        double call3LengthsBehind = (double)myReader["CALL_3_LENGTHS_BEHIND"];
                        double stretchLengthsBehind = (double)myReader["STRETCH_LENGTHS_BEHIND"];
                        double finalCallLengthsBehind = (double)myReader["FINISH_LENGTHS_BEHIND"];

                        double firstCallLengthsBehind = 0;
                        double secondCallLengthsBehind = 0;

                        string horseName = myReader["HORSE_NAME"].ToString();
                        

                        if (ri.DistanceOfTheRaceInYards >= 2640)
                        {
                            firstCallLengthsBehind = call2LengthsBehind;
                            secondCallLengthsBehind = stretchLengthsBehind;               
                        }
                        else if (ri.DistanceOfTheRaceInYards >= 1760)
                        {
                            firstCallLengthsBehind = call2LengthsBehind;
                            secondCallLengthsBehind = call3LengthsBehind;
                        }
                        else
                        {
                            firstCallLengthsBehind = call1LengthsBehind;
                            secondCallLengthsBehind = call2LengthsBehind;
                        }
                      
                        HorseInfo hi = new HorseInfo((int)myReader["ID"], myReader["HORSE_NAME"].ToString(), myReader["PROGRAM_NUMBER"].ToString(), firstCallLengthsBehind, secondCallLengthsBehind, finalCallLengthsBehind,weight);
                        TreeNode tn = parentNode.Nodes.Add(hi.Name);
                        tn.Tag = hi;
                    }
                }
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
        }

        private void OnSaveAll(object sender, EventArgs e)
        {
            foreach (TreeNode tn in _treeViewAvailableRaces.Nodes)
            {
                LoadRacesForDay(tn);

                foreach (TreeNode tn2 in tn.Nodes)
                {
                    LoadHorsesForTheRace(tn2);
                }
            }
        }


        private void ShowMessage(string txt)
        {

            _txtboxOutput.Text += txt + Environment.NewLine;

            if (_txtboxOutput.Text.Length + txt.Length >= _txtboxOutput.MaxLength)
            {
                _txtboxOutput.Text = _txtboxOutput.Text.Substring(10000);
            }

            _txtboxOutput.Select(_txtboxOutput.Text.Length + 1, 2);
            _txtboxOutput.ScrollToCaret();

        }

        private void OnNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is RaceInfo)
            {
                LoadHorsesForTheRace(e.Node);

                List<HorseInfo> horseInfo = new List<HorseInfo>();


                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if (tn.Tag is HorseInfo)
                    {
                        horseInfo.Add(tn.Tag as HorseInfo);
                    }
                }


                _raceInfoCtrl.BindRaceInfo((RaceInfo)e.Node.Tag);
                _cynthiaParsCtrl.BindRaceInfo((RaceInfo)e.Node.Tag, horseInfo);
            }
            else
            {
                LoadRacesForDay(e.Node);
            }
        }

        private void _cynthiaParsCtrl_Load(object sender, EventArgs e)
        {

        }

        
    }
}
