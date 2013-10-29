using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.RaceGrouping
{
    public class RaceGroupType
    {
        private readonly string _description;
        private readonly string _whereClause;
        private readonly List<TargetGroup> _groups;

        private static readonly List<RaceGroupType> _raceTypes = new List<RaceGroupType>();

        static RaceGroupType()
        {
            _raceTypes.Add(MakeMaidenClaimer);
            _raceTypes.Add(MakeMaidenSpecialWeights);
            _raceTypes.Add(MakeClaimer);
            _raceTypes.Add(MakeStakes);
            _raceTypes.Add(MakeOther);
        }

        public static RaceGroupType MakeMaidenClaimer
        {
            get
            {
                return new RaceGroupType("MCL", @"race_attributes & 64 = 64 ");
            }
        }

        public static RaceGroupType MakeMaidenSpecialWeights
        {
            get
            {
                return new RaceGroupType("MSW", @"race_attributes & 16384 = 16384 ");
            }
        }

        public static RaceGroupType MakeClaimer
        {
            get
            {
                return new RaceGroupType("CLM", @"race_attributes & 256 = 256 ");
            }
        }

        public static RaceGroupType MakeStakes
        {
            get
            {
                return new RaceGroupType("STK", @"race_attributes & 128 = 128 ");
            }
        }

        public static RaceGroupType MakeOther
        {
            get
            {
                return new RaceGroupType("OTHER", @"race_attributes & 16832 = 0 ");
            }
        }

        public static List<RaceGroupType> RaceTypes
        {
            get
            {
                return _raceTypes;
            }
        }

        protected RaceGroupType(string desc, string whereClause)
        {
            _description = desc;
            _whereClause = whereClause;
            _groups = TargetGroup.MakeGroups(this);
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public string WhereClause
        {
            get
            {
                return _whereClause;
            }
        }

        public List<TargetGroup> Groups
        {
            get
            {
                return _groups;
            }
        }

        public string BasedInOddsProductionFilename(double odds)
        {
            TargetGroup tg = null;
            foreach (var ot in OddsTreshold.List)
            {
                if (odds >= ot.From && odds < ot.To)
                {
                    tg = new GoodBetBasedInOdds(this, ot.From, ot.To, TargetGroup.ComparisonStyleType.MaximizeROI);
                }
            }
            return null != tg ? tg.CreateProductionFileName() : "";
        }

        public string GoodFavoriteProductionFilename
        {
            get
            {
                foreach (var tg in Groups)
                {
                    if (tg is GoodFavorite)
                    {
                        return tg.CreateProductionFileName();
                    }
                }
                return "";
            }
        }

        public string BadFavoriteProductionFilename
        {
            get
            {
                foreach (var tg in Groups)
                {
                    if (tg is BadFavorite)
                    {
                        return tg.CreateProductionFileName();
                    }
                }
                return "";
            }
        }

        public override string ToString()
        {
            return _description;
        }
    }
}