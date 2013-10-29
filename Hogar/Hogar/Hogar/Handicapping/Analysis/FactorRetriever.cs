using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Hogar.Handicapping;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.Handicapping.Analysis
{
    public static class FactorRetriever
    {
        public static DataSet GetMatchingHorses(List<Factor> factors, string trackCode, long raceAttributes)
        {
            string sql = SQLGetMatchingHorses(factors, trackCode, raceAttributes);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        private static string SQLGetMatchingHorses(List<Factor> factors, string trackCode, long raceAttributes)
        {
            long bitMask = 0;
            foreach (Factor f in factors)
            {
                if (null != f)
                {
                    bitMask = bitMask | f.BitMask;
                }
                else
                {
                    bitMask = bitMask;
                }
            }
            return string.Format("Exec SelectMatchingHorsesByFactorsFlag {0}, '{1}', {2} ", bitMask, trackCode, raceAttributes);
        }
    }
}
