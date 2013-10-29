using System;
using System.Data.SqlClient;
using Hogar.DbTools;
using RaceResultsViewer;

namespace OddsEditor.Dialogs
{
    public partial class RaceResultsForm : GenericForm
    {
        readonly string _trackCode = "" ;
        readonly string _date = "";
        readonly int _raceNumber = -1;


        public RaceResultsForm(int raceid)
        {
            SqlDataReader myReader = null;

            try
            {

                string sql = string.Format(@"SELECT 
	                                            TRACK_CODE, 
	                                            DATE_OF_THE_RACE, 
	                                            RACE_NUMBER 
                                            FROM 
	                                            RACE_DESCRIPTION
                                            WHERE 
                                                RACE_ID ={0}"
                                            , raceid);

                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    _trackCode = myReader["TRACK_CODE"].ToString();
                    _date = myReader["DATE_OF_THE_RACE"].ToString();
                    _raceNumber = (int)myReader["RACE_NUMBER"];
                }
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }

            InitializeComponent();

        }

        public RaceResultsForm(string trackCode, string date, int raceNumber)
        {
            _trackCode = trackCode;
            _date = date;
            _raceNumber = raceNumber;

            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            AddRaceResults();
        }

        private void AddRaceResults()
        {
            this.Text = _trackCode + " " + _date + " Race# : " + _raceNumber.ToString();

            RaceResultsViewer.RaceResultsControl raceResultsControl = new RaceResultsControl(_trackCode, _date, _raceNumber);
            _panel.Controls.Add(raceResultsControl);
        }
    }
}
