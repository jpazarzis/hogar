using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SippViewer
{
    static class SippExtentions
    {
        public static readonly double YARDS_IN_A_FURLONG = 220;

        public static readonly double FEET_IN_A_YEARD = 3;

        public static readonly double MILE_IN_YEARDS = 220 * 8;

        public static readonly double HORSE_LENGTH_IN_YEARDS = 3;

        // The constant used for the calculations of percentages using BestRating
        public static readonly double BEST_RATING_CONSTANT = 68;

        // The constant used for the calculations of percentages using BrisPrimePower
        public static readonly double PRIME_POWER_CONSTANT = 18;

        public static readonly double MIN_DISTANCE_FOR_ROUTE = 1760.0;

        public static readonly double LAYOFF_DAYS = 45;

        public static readonly double LONG_LAYOFF_DAYS = 180;

        static public int ToInteger(this string s)
        {
            int i = 0;

            return int.TryParse(s,out i) ? i : 0;
        }

        public static string ConvertYardsToMilesOrFurlongs(int yards)
        {
            string distance = "";

            if (yards < MILE_IN_YEARDS)
            {
                distance = (yards / YARDS_IN_A_FURLONG).ToString();
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
                distance = ConvertDecimalToFraction(((double)yards) / MILE_IN_YEARDS);
                distance += " Mile";
            }

            return distance;
        }
        private static string ConvertDecimalToFraction(double wholeNumber)
        {
            if (wholeNumber * MILE_IN_YEARDS - MILE_IN_YEARDS > 69 && wholeNumber * MILE_IN_YEARDS - MILE_IN_YEARDS < 71)
            {
                // special case mile and 70 y
                return "1 70";
            }

            double d = wholeNumber - (int)wholeNumber;

            if (d == 0)
            {
                return wholeNumber.ToString();
            }

            for (int denominator = 2; denominator < 100; ++denominator)
            {
                double nominator = d * denominator;

                if ((nominator - (int)nominator) == 0)
                {
                    return ((int)(wholeNumber - (int)wholeNumber + 1)).ToString() + " " + nominator.ToString() + "/" + denominator.ToString();
                }
            }

            return wholeNumber.ToString();
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
            if (false == double.TryParse(timeInDecimalSecond, out t))
            {
                return "";
            }

            string signPrefix = t < 0 ? "-" : "";

            t = Math.Abs(t);

            double minutes = ((int)t) / 60;
            double seconds = ((int)(t - minutes * 60.0));
            double decimalPart = t - minutes * 60 - seconds;
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
    }
}
