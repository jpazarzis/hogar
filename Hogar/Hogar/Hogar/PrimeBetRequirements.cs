using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;
using Hogar.Handicapping.Analysis;

namespace Hogar
{
    public sealed class PrimeBetRequirements
    {
        static PrimeBetRequirements _singleton = null;

        static public PrimeBetRequirements Singleton
        {
            get
            {
                if(null == _singleton)
                {
                    _singleton = new PrimeBetRequirements();
                }

                return _singleton;
            }
        }

        private PrimeBetRequirements()
        {
            LoadFromDb();
        }

        private void LoadFromDb()
        {
            SqlDataReader myReader = null;
            try
            {
                string sql = @"SELECT MIN_ROI,MIN_IV,MIN_MATCHES,MIN_WINNERS,REQUIRED_PRIME_BETS FROM PRIME_BET_REQUIREMENTS ";
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    MinROI = myReader.GetDouble(0);
                    MinIV = myReader.GetDouble(1);
                    MinMatches = myReader.GetInt32(2);
                    MinWinners = myReader.GetInt32(3);
                    MinRequiredPrimeBets = myReader.GetInt32(4);
                }
            }
            finally 
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }
        }

        public bool IsPrimeFactor(FactorPerformance fp)
        {
            return fp.ROI >= MinROI && fp.IV >= MinIV && fp.Matches > MinMatches && fp.Winners >= MinWinners;
        }


        public void AssignValues(double minROI, double minIV, int minMatches, int minWinners, int minRequiredPrimeBets)
        {
            if (minIV <= 0.0 || minROI <= 0 || minMatches < 0 || minWinners < 0 || minRequiredPrimeBets < 1)
            {
                throw new ArgumentException();
            }

            MinROI = minROI;
            MinIV = minIV;
            MinMatches = minMatches;
            MinWinners = minWinners;
            MinRequiredPrimeBets = minRequiredPrimeBets;

            SaveToDb();
        }

        private void SaveToDb()
        {
            string sql = string.Format(@"EXEC InsertPrimeBetRequiremnet
		                                {0},{1},{2},{3},{4}",
                                   MinROI, MinIV, MinMatches, MinWinners, MinRequiredPrimeBets);

            SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();

        }


        public double MinROI {get;private set;}
        public double MinIV{get;private set;}
        public int MinWinners{get;private set;}
        public int MinMatches{get;private set;}
        public int MinRequiredPrimeBets{get;private set;}
        
    }
}
