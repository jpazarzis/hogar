using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar
{
    // April 30 2009
    // Used to estimate and classify the 'class' of a race using its conditions
    // Maybe a throw away but let's see how it will work...
    public class ClassEstimator
    {
        public enum RaceType
        {
            Grade1, 
            Grade2, 
            Grade3,     
            CanadianG1,
            CanadianG2,
            CanadianG3,
            NonGradedHandicap,
            Allowance,
            OptionalClaiming,
            StarterAllowance,
            StarterHancicap,
            Trial,
            Claiming,
            MaidenSpecialWeight,
            MaidenClaiming,
            MaidenOptionalClaiming,
            OptionalClaimingStakes
        }

        public enum AgeRestriction
        {
            TwoYearsOld,
            ThreeYearsOld,
            FourYearsOld,
            FiveYearsOld,
            ThreeAndFourYearsOld,
            FourAndFiveYearsOld,
            ThreeFourAndFiveYearOlds,
            AllAges
        }

        public enum AgeOpeness
        {
            ThatAgeOnly,
            ThatAgeAndUp,
        }

        public enum SexRestrictions
        {
            NoSexRestriction,
            MaresAndFilliesOnly,
            ColtsAndGeldings,
            FilliesOnly
        }


        
        
       
        
      
        
        
        public ClassEstimator(string trackCode, string date, int raceNumber)
        {
            /*
            SqlDataReader myReader = null;

            try
            {
                string sql = string.Format("SELECT DISTINCT DATE_OF_THE_RACE  FROM RACE_DESCRIPTION WHERE TRACK_CODE = '{0}' ORDER BY DATE_OF_THE_RACE DESC", trackCode);
                SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    list.Add((string)myReader["DATE_OF_THE_RACE"]);
                }
                myReader.Close();

                return list;
        
            }
            catch
            {
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }
             */ 
        }


        
        


    }
}
