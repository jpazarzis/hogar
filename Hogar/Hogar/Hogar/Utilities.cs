using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.IO;
using System.Drawing;
using System.Configuration;




namespace Hogar
{
    
    public static class Utilities
    {
        public static readonly double YARDS_IN_A_FURLONG = 220;

        public static readonly double FEET_IN_A_YEARD = 3;

        public static readonly double MILE_IN_YEARDS = 220*8;

        public static readonly double HORSE_LENGTH_IN_YEARDS = 3;

        // The constant used for the calculations of percentages using BestRating
        public static readonly double BEST_RATING_CONSTANT = 68;

        // The constant used for the calculations of percentages using BrisPrimePower
        public static readonly double PRIME_POWER_CONSTANT = 18;

        public static readonly double MIN_DISTANCE_FOR_ROUTE = 1760.0;

        public static readonly double LAYOFF_DAYS = 45;

        public static readonly double LONG_LAYOFF_DAYS = 180;

        public enum Surface
        {
            Invalid,
            Turf,
            Dirt
        }

        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        public static double CalculateStdDev(IEnumerable<int> values)
        {
            return CalculateStdDev(values.Select(i => (double)i).ToList());
        }


        static public double Variance(this List<double> v)
        {
            if (v.Count <= 0)
                return 0.0;

            double average = v.Average();
            var squardDiff = new List<double>();
            v.ForEach(d=>squardDiff.Add( Math.Pow(d-average,2)));
            return squardDiff.Sum() / squardDiff.Count;
        }

        static public double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-1 * x));
        }

        public static Color SaddleClothBackColor(int horseNumber)
        {
            switch (horseNumber)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.White;
                case 3:
                    return Color.Blue;
                case 4:
                    return Color.Yellow;
                case 5:
                    return Color.Green;
                case 6:
                    return Color.Black;
                case 7:
                    return Color.Orange;
                case 8:
                    return Color.Pink;
                case 9:
                    return Color.Turquoise;
                case 10:
                    return Color.Purple;
                case 11:
                    return Color.Gray;
                case 12:
                    return Color.Lime;
                case 13:
                    return Color.Brown;
                case 14:
                    return Color.Maroon;
                case 15:
                    return Color.Khaki;
                case 16:
                    return Color.Navy;
                case 17:
                    return Color.Navy;
                case 18:
                    return Color.ForestGreen;
                case 19:
                    return Color.ForestGreen;
                case 20:
                    return Color.Fuchsia;
                default:
                    return Color.Black;
            }
        }

        public static double CalculateTimeBasedInBeatenLengths(double winnersTime, double distanceInYards, double lengthsBehind)
        {
            return winnersTime*(1 + 3*lengthsBehind/(distanceInYards - 3*lengthsBehind));
        }

        public static void RenameStringInFile(string filePath, string oldtext, string newtext)
        {
            string tempFile = filePath + ".temp";

            using(var originalFile = new StreamReader(filePath))
            {
                using (var temp = new StreamWriter(tempFile))
                {
                    string line;
                    while ((line = originalFile.ReadLine()) != null)
                    {
                        temp.WriteLine(line.Replace(oldtext, newtext));
                    }
                }
            }

            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }

        public static string FormatCondition(string condition, bool isStateBredRace, string ageSexRestrictions)
        {
            string originalCondition = condition;

            condition = condition.Trim().ToUpper();

            if (condition.Length <= 3)
            {
                return condition;
            }

            var formatedCondition = new StringBuilder();
            const char upArrow = '\u2191';
            if (ageSexRestrictions.Length >= 3)
            {
                bool thatAgeAndUp = ageSexRestrictions.ToUpper()[1] == 'U';

                switch (ageSexRestrictions.ToUpper()[0])
                {
                    case 'A':
                        {
                            if (thatAgeAndUp)
                            {
                                formatedCondition.Append(upArrow);
                                formatedCondition.Append("2");
                            }
                            break;
                        }
                    case 'B':
                        {
                            if (thatAgeAndUp)
                            {
                                formatedCondition.Append(upArrow);
                                formatedCondition.Append("3");
                            }
                            break;
                        }
                    case 'C':
                        {
                            if (thatAgeAndUp)
                            {
                                formatedCondition.Append(upArrow);
                                formatedCondition.Append("4");
                            }
                            break;
                        }
                    case 'D':
                        {
                            if (thatAgeAndUp)
                            {
                                formatedCondition.Append(upArrow);
                                formatedCondition.Append("4");
                            }
                            break;
                        }
                }
            }

            int index = 0;

            if (condition[index] == 'F' && (ageSexRestrictions.ToUpper()[2] == 'F' || ageSexRestrictions.ToUpper()[2] == 'M'))
            {
                formatedCondition.Append('\u24BB');
                ++index;
            }

            if (condition[index] == 'S' && isStateBredRace)
            {
                formatedCondition.Append('\u24C8');
                ++index;
            }

            if (formatedCondition.Length > 0)
            {
                formatedCondition.Append(" ");
            }

            formatedCondition.Append(CapitalizeOnlyFirstLetter(originalCondition.Substring(index)));
            return formatedCondition.ToString().Replace("Mdspwt", "MSW");
        }

        public static string MakeRaceCondition(string stateBredFlag,
                                               string ageSexRestrictions,
                                               string abbrRaceClass,
                                               int raceGrade,
                                               string raceName)
        {
            var condition = new StringBuilder();

            const char upArrow = '\u2191';

            if (ageSexRestrictions.Length >= 3)
            {
                bool thatAgeAndUp = ageSexRestrictions.ToUpper()[1] == 'U';

                switch (ageSexRestrictions.ToUpper()[0])
                {
                    case 'A':
                        {
                            if (thatAgeAndUp)
                            {
                                condition.Append(upArrow);
                                condition.Append("2");
                            }
                            break;
                        }
                    case 'B':
                        {
                            if (thatAgeAndUp)
                            {
                                condition.Append(upArrow);
                                condition.Append("3");
                            }
                            break;
                        }
                    case 'C':
                        {
                            if (thatAgeAndUp)
                            {
                                condition.Append(upArrow);
                                condition.Append("4");
                            }
                            break;
                        }
                    case 'D':
                        {
                            if (thatAgeAndUp)
                            {
                                condition.Append(upArrow);
                                condition.Append("4");
                            }
                            break;
                        }
                }

                if (ageSexRestrictions.ToUpper()[2] == 'F' || ageSexRestrictions.ToUpper()[2] == 'M')
                {
                    condition.Append('\u24BB');
                }
            }

            if (stateBredFlag.ToUpper().Contains("S"))
            {
                condition.Append('\u24C8');
            }

            condition.Append(abbrRaceClass.Trim());

            if (raceGrade == 1 || raceGrade == 5)
            {
                condition.Append("-G1");
            }
            else if (raceGrade == 2 || raceGrade == 6)
            {
                condition.Append("-G2");
            }
            else if (raceGrade == 3 || raceGrade == 7)
            {
                condition.Append("-G3");
            }

            if (raceName.Length > 0)
            {
                condition.Append(" ");
                condition.Append(raceName);
            }

            return condition.ToString();
        }

        public static Color SaddleClothFrontColor(int horseNumber)
        {
            switch (horseNumber)
            {
                case 1:
                    return Color.White;
                case 2:
                    return Color.Black;
                case 3:
                    return Color.White;
                case 4:
                    return Color.Black;
                case 5:
                    return Color.White;
                case 6:
                    return Color.Yellow;
                case 7:
                    return Color.Black;
                case 8:
                    return Color.Black;
                case 9:
                    return Color.Black;
                case 10:
                    return Color.White;
                case 11:
                    return Color.Black;
                case 12:
                    return Color.Black;
                case 13:
                    return Color.White;
                case 14:
                    return Color.White;
                case 15:
                    return Color.White;
                case 16:
                    return Color.White;
                case 17:
                    return Color.White;
                case 18:
                    return Color.White;
                case 19:
                    return Color.Black;
                case 20:
                    return Color.White;
                default:
                    return Color.White;
            }
        }

        // returns the program number without the entry letter
        public static int GetHorseNumberFromProgramNumber(string num)
        {
            num = num.Trim();
            if (num.Length <= 0)
            {
                return 0;
            }
            string s = "";
            foreach (char c in num)
            {
                if (c >= '0' && c <= '9')
                {
                    s += c;
                }
            }
            int i;
            return int.TryParse(s, out i) ? i : 0;
        }

        
        public static string GetBrisPastPerformancesFilename(int year, string filename)
        {
            string drfFilename = Utilities.PastPerformancesDirectory + @"\" + year.ToString() + @"\" + filename + ".DRF";
            string multiCapFilename = Utilities.PastPerformancesDirectory + @"\" + year.ToString() + @"\" + filename + ".MCP";

            if (File.Exists(multiCapFilename))
            {
                return multiCapFilename;
            }
            else if (File.Exists(drfFilename))
            {
                return drfFilename;
            }
            else
            {
                return "";
            }
        }

        // Parsing a date string in the M/D/Y format
        public static void ParseDateString(string date, ref int year, ref int month, ref int day)
        {
            string[] s = date.Split('/');

            if (s.Length != 3)
            {
                throw new Exception("Invalid date format: " + date);
            }

            month = Convert.ToInt32(s[0]);
            day = Convert.ToInt32(s[1]);
            year = Convert.ToInt32(s[2]);
        }

        // Created this method because I could not find a better way to detect 
        // if a SerializationInfo object contains a specific field
        // Used when deserializing an obect and we want to maintain
        // backwards compatibility with previous formats used to save an object

        public static bool SerializationObjectExists(SerializationInfo info, string fieldName, System.Type dataType)
        {
            Debug.Assert(null != info);
            Debug.Assert(!string.IsNullOrEmpty(fieldName));



            var e = info.GetEnumerator();
            e.Reset();
            e.MoveNext();
            while(e.MoveNext())
            {
                if (e.Current.ObjectType == dataType && e.Current.Name == fieldName)
                {
                    return true;
                }    
            }

            return false;
         

            try
            {
                return null != info.GetValue(fieldName, dataType);
            }
            catch
            {
                return false;
            }
        }

        // Created the following method to make the deserialization of
        // an object a little bit more elegant when we need to check
        // if a field indeed exists

        public static object GetSerializedObject(SerializationInfo info, string fieldName, System.Type dataType, object defautValue)
        {
            if (Utilities.SerializationObjectExists(info, fieldName, dataType))
            {
                return info.GetValue(fieldName, dataType);
            }
            else
            {
                return defautValue;
            }
        }

        public static string ReportsDirectory
        {
            get
            {
                return @"C:\HorseRacingSoftware\Documents\Reports";
            }
        }

        public static string WebDocumentDirectory
        {
            get
            {
                return @"C:\HorseRacingSoftware\Documents\WebDocuments";
            }
        }

        public static string NeuronNetworkDirectory
        {
            get
            {
                return @"C:\HorseRacingSoftware\Documents\NeuronNetworks";
            }
        }

        public static string RaceWeightsDirectory
        {
            get
            {
                return @"C:\HorseRacingSoftware\Documents\RaceWeights";
            }
        }

        public static string SippFilesDirectory
        {
            get
            {
                return @"C:\HorseRacingSoftware\Documents\Sipp";
            }
        }
        

        public static string DirectoryToImportPP
        {
            get
            {
                return @"C:\HorseRacingSoftware\Documents\PastPerformances\ToImport";
            }
        }

        public static string CommonDirectory
        {
            get 
            {

                return @"C:\HorseRacingSoftware\Documents\PastPerformances";
                    
            }
        }

        public static string PastPerformancesDirectory
        {
            get
            {
                return CommonDirectory + @"\BrisFiles";
            }
        }

        internal static string OddsDirectory
        {
            get
            {
                return CommonDirectory + @"\Odds\2009";
            }
        }

        public static double GetVelocity(double distance, double margin, double time)
        {
            return (distance - (margin*HORSE_LENGTH_IN_YEARDS))/time;
        }

        private static string ConvertDecimalToFraction(double wholeNumber)
        {
            if (wholeNumber*MILE_IN_YEARDS - MILE_IN_YEARDS > 69 && wholeNumber*MILE_IN_YEARDS - MILE_IN_YEARDS < 71)
            {
                // special case mile and 70 y
                return "1 70";
            }

            double d = wholeNumber - (int) wholeNumber;

            Debug.Assert(d >= 0 && d < 1);

            if (d == 0)
            {
                return wholeNumber.ToString();
            }

            for (int denominator = 2; denominator < 100; ++denominator)
            {
                double nominator = d*denominator;

                if ((nominator - (int) nominator) == 0)
                {
                    return ((int) (wholeNumber - (int) wholeNumber + 1)).ToString() + " " + nominator.ToString() + "/" + denominator.ToString();
                }
            }

            return wholeNumber.ToString();
        }

        public static string ConvertYardsToMilesOrFurlongsAbreviation(int yards)
        {
            string distance = "";

            if (yards < MILE_IN_YEARDS)
            {
                distance = (yards/YARDS_IN_A_FURLONG).ToString();
                distance += " f";
            }
            else if (yards == 1830)
            {
                return "1m 70y";
            }
            else if (yards >= 1799 && yards <= 1801)
            {
                return "1m 40y";
            }
            else
            {
                distance = ConvertDecimalToFraction(((double) yards)/MILE_IN_YEARDS);
                distance += " m";
            }

            return distance;
        }

        public static string ConvertYardsToMilesOrFurlongs(int yards)
        {
            string distance = "";

            if (yards < MILE_IN_YEARDS)
            {
                distance = (yards/YARDS_IN_A_FURLONG).ToString();
                distance += " Furlongs";
            }
            else if (yards == 1830)
            {
                return "1m 70y";
            }
            else if (yards >= 1799 && yards <= 1801)
            {
                return "1m 40y";
            }
            else
            {
                distance = ConvertDecimalToFraction(((double) yards)/MILE_IN_YEARDS);
                distance += " Mile";
            }

            return distance;
        }

        /// <summary>
        /// Takes a date in YYYYMMDD format and returns it short format ie 14Apr09
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetShortDate(string d)
        {
            int year = Convert.ToInt32(d.Substring(0, 4));
            int month = Convert.ToInt32(d.Substring(4, 2));
            int day = Convert.ToInt32(d.Substring(6, 2));

            if (day < 10)
            {
                return " " + day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
            }
            else
            {
                return day.ToString() + Utilities.GetMonthName(month) + year.ToString().Substring(2, 2);
            }
        }

        public static string GetDateInYYYYMMDD(DateTime dt)
        {
            return string.Format("{0:0000}{1:00}{2:00}", dt.Year, dt.Month, dt.Day);
        }

        public static DateTime MakeDateTime(string dateInYYYYMMDD)
        {
            int year = 2000, month = 1, day = 1;

            int.TryParse(dateInYYYYMMDD.Substring(0, 4), out year);
            int.TryParse(dateInYYYYMMDD.Substring(4, 2), out month);
            int.TryParse(dateInYYYYMMDD.Substring(6, 2), out day);

            return new DateTime(year, month, day);
        }

        public static string GetFullDateString(string dateInYYYYMMDD)
        {
            if (dateInYYYYMMDD.Length < 8)
            {
                return "Invalid Date";
            }

            int month = Convert.ToInt32(dateInYYYYMMDD.Substring(4, 2));
            return GetMonthName(month) + " " + dateInYYYYMMDD.Substring(6, 2) + ", " + dateInYYYYMMDD.Substring(0, 4);
        }

        public static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return "UNKNWON";
            }
        }

        public static List<string> MonthNames
        {
            get
            {
                var list = new List<string>();
                for (int i = 1; i <= 12; ++i )
                {
                    list.Add(GetMonthFullName(i));
                }
                return list;
            }
        }

        public static string GetMonthFullName(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "Febrary";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "UNKNWON";
            }
        }

        // Return the date in full desc ie:  0401 returns April 1

        public static string GetDateInFullDescription(string s)
        {
            s = s.Trim();

            if (s.Length != 8)
            {
                return "N/A";
            }

            string m = s.Substring(4, 2);
            m = GetMonthFullName(Convert.ToInt32(m));

            string d = s.Substring(6, 2);

            int j = Convert.ToInt32(d);

            d = j.ToString();

            return m + " " + d + ", " + s.Substring(0, 4);
        }

        public static string ConvertTimeToMMSSHundreds(double timeInSecondsAndHundreds)
        {
            if (timeInSecondsAndHundreds <= 0)
            {
                return "0";
            }

            double minutes = ((int) timeInSecondsAndHundreds)/60;
            double seconds = ((int) (timeInSecondsAndHundreds - minutes*60.0));
            int hundreds = (int) ((timeInSecondsAndHundreds - minutes*60 - seconds)*100);

            string dp = hundreds.ToString().Trim();

            if (dp.Length <= 0)
            {
                dp = ".00";
            }
            else if (dp.Length == 1)
            {
                dp = "." + "0" + dp;
            }
            else
            {
                dp = "." + dp;
            }

            string sp = seconds.ToString().Trim();

            if (sp.Length == 1)
            {
                sp = "0" + sp;
            }

            return minutes <= 0 ? sp + dp : minutes.ToString() + ":" + sp + dp;
        }

        // date should be in YYYYMMDD or in the m/d/y format
        public static bool ReadYearMonthDay(string date, ref int year, ref int month, ref int day)
        {
            try
            {
                if (date.Contains('/'))
                {
                    string[] s = date.Split('/');
                    month = Convert.ToInt32(s[0]);
                    day = Convert.ToInt32(s[1]);
                    year = Convert.ToInt32(s[2]);
                    return true;
                }
                else
                {
                    month = Convert.ToInt32(date.Substring(0, 4));
                    day = Convert.ToInt32(date.Substring(4, 2));
                    year = Convert.ToInt32(date.Substring(6, 2));
                    return true;
                }
            }
            catch
            {
                year = month = day = 0;
                return false;
            }
        }

        public static string ConvertTimeToMMSSFifth(double timeInDecimalSecond)
        {
            try
            {
                return ConvertTimeToMMSSFifth(string.Format("{0:0.00}", timeInDecimalSecond));
            }
            catch
            {
                return "N/A";
            }
        }

        public static string ConvertTimeToMMSSFifth(string timeInDecimalSecond)
        {
            if (timeInDecimalSecond.Length <= 0)
            {
                return "         ";
            }

            

            double t;
            if(false == double.TryParse(timeInDecimalSecond, out t))
            {
                return "";
            }

            string signPrefix = t < 0 ? "-" : "";

            t = Math.Abs(t);

            double minutes = ((int) t)/60;
            double seconds = ((int) (t - minutes*60.0));
            double decimalPart = t - minutes*60 - seconds;
            string dp = "";

            if (decimalPart < 0.20)
            {
                dp = "";
            }
            else if (decimalPart < 0.4)
            {
                dp = ".1";
            }
            else if (decimalPart < 0.6)
            {
                dp = ".2";
            }
            else if (decimalPart < 0.8)
            {
                dp = ".3";
            }
            else
            {
                dp = ".4";
            }

            string sp = seconds.ToString();

            if (sp.Length == 1)
            {
                sp = "0" + sp;
            }

            if (minutes <= 0)
            {
                return signPrefix + ((":" + sp + dp) + "         ").Substring(0, 7);
            }
            else
            {
                return signPrefix + (minutes.ToString() + ":" + sp + dp + "         ").Substring(0, 7);
            }
        }

        public static int GetProgramNumberWithoutEntryChar(string num)
        {
            if (num.Trim().Length <= 0)
            {
                return 0;
            }

            for (char ch = 'A'; ch <= 'Z'; ++ch)
            {
                string s = new string(ch, 1);
                num = num.Replace(s, "");
            }

            int i;

            return int.TryParse(num.Trim(), out i) ? i : 0;
        }

        public static string CapitalizeOnlyFirstLetter(string txt)
        {
            string returnValue = "";

            txt = txt.Trim();

            bool insideAWord = false;

            for (int i = 0; i < txt.Length; ++i)
            {
                if (i == 0)
                {
                    returnValue += txt[i].ToString().ToUpper();
                    insideAWord = true;
                }
                else if (txt[i] == ' ')
                {
                    insideAWord = false;
                    returnValue += ' ';
                }
                else
                {
                    if (insideAWord)
                    {
                        returnValue += txt[i].ToString().ToLower();
                    }
                    else
                    {
                        returnValue += txt[i].ToString().ToUpper();
                        insideAWord = true;
                    }
                }
            }
            return returnValue;
        }


        public static string GetFieldAsString(DataRow dr, int index)
        {
            return dr[index].ToString().Trim();
        }

        public static int GetFieldAsInteger(DataRow dr, int index)
        {
            int i;
            return int.TryParse(GetFieldAsString(dr, index), out i) ? i : 0;
        }

        public static double GetFieldAsDouble(DataRow dr, int index)
        {
            double i;
            return double.TryParse(GetFieldAsString(dr, index), out i) ? i : 0.0;
        }

        // June 10 2010 Note:
        // To start using parser with files with extention mcp and drf
        // you have to add this extension in the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Jet\4.0\Engines\Text
        // both for extensions and DisabledExtensions

        public static DataTable Parser(string filenameIncludingPath)
        {
            if (!File.Exists(filenameIncludingPath))
            {
                new FileNotFoundException("File does not exist", filenameIncludingPath);
            }

            string directory = Path.GetDirectoryName(filenameIncludingPath);
            string filename = Path.GetFileName(filenameIncludingPath);
            
            using (var cn =
                new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;" +
                                    "Data Source=" + directory + ";" +
                                    "Extended Properties=\"Text;HDR=No;FMT=Delimited\""))
            {
                cn.Open();
                using (var adapter =
                    new OleDbDataAdapter("SELECT * FROM " + filename, cn))
                {
                    var dt = new DataTable(filename);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}