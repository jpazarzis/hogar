using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.RaceGrouping
{
    public abstract class TargetGroup
    {
        private readonly string _description;
        private readonly string _abreviation;
        private readonly RaceGroupType _parent;

        protected const string _sqlBeginingOfSelect = @"Select RACE_ID, WAS_THE_WINNER, ODDS, FACTORS_FLAG FROM HORSE_FACTORS WHERE ";


        public enum ComparisonStyleType
        {
            Maximize,
            Minimize,
            MaximizeROI
        }

        private readonly ComparisonStyleType _comparisonStyle;

        static internal List<TargetGroup>  MakeGroups(RaceGroupType parent)
        {
            var groups = new List<TargetGroup>();

            groups.Add(new GoodFavorite(parent, ComparisonStyleType.MaximizeROI));
            groups.Add(new BadFavorite(parent, ComparisonStyleType.Minimize));


            OddsTreshold.List.ForEach(ot => groups.Add(new GoodBetBasedInOdds(parent, ot.From, ot.To, ComparisonStyleType.MaximizeROI)));

            
            return groups;
        }

        protected TargetGroup(RaceGroupType parent, string desc, string abrv,ComparisonStyleType comparisonStyle)
        {
            _parent = parent;
            _description = desc;
            _abreviation = abrv;
            _comparisonStyle = comparisonStyle;
        }

        public ComparisonStyleType ComparisonStyle
        {
            get
            {
                return _comparisonStyle;
            }
        }

        public string Description
        {
            get 
            {
                return string.Format("{0} {1}", _parent.Description, _description);
            }
        }

        protected RaceGroupType Parent
        {
            get
            {
                return _parent;
            }
        }

        //public abstract bool Qualifies(bool wasThefavorite, double odds);

        public abstract string GetSQLToLoadFromDB();

        public abstract bool RefersToFavoriteOnly { get; }
        

        static string GetCurrentTime()
        {
            var dt = DateTime.Now;
            return string.Format("{0}_{1:00}_{2:00}_{3:00}_{4:00}_{5:00}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }

        static public string FileNameExtention
        {
            get
            {
                return ".gp";
            }
        }

        public string FileNameBase
        {
            get
            {
                return string.Format("{0}_{1}", _parent.Description, _abreviation);
            }
        }

        public string FileNameMask
        {
            get
            {
                return string.Format("{0}_*{1}", FileNameBase,FileNameExtention);
            }
        }

        static public string MakeFileNameForProduction(string filename)
        {
            string temp = filename.Replace(FileNameExtention, "").Trim();
            int index = temp.IndexOf('_');
            index = temp.IndexOf('_', index+1);
            temp = temp.Substring(0, index);
            return string.Format("{0}{1}", temp, FileNameExtention);
        }

        public string CreateNewFileNameWithTimeStamp()
        {
            return string.Format("{0}_{1}{2}", FileNameBase, GetCurrentTime(),FileNameExtention);
        }

        public string CreateProductionFileName()
        {
            return string.Format("{0}{1}", FileNameBase,  FileNameExtention);
        }


        public override string ToString()
        {
            return _description;
        }
    }
}