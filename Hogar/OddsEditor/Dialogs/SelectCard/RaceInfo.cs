using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.DbTools;
using Hogar;

namespace OddsEditor.Dialogs.SelectCard
{
    class RaceInfo
    {
        private readonly int _raceID;
        private readonly int _raceNumber;
        private readonly double _distance;
        private readonly string _surface;
        private readonly string _age_sex_restrictions;
        private readonly string _state_bred_flag;
        private readonly string _abbr_race_class;
        private readonly string _race_conditions;
        private readonly int _raceGrade;
        private readonly string _raceName;

        public RaceInfo(DbReader dbr)
        {
            _raceID = dbr.GetValue<int>("RACE_ID");
            _raceNumber = dbr.GetValue<int>("race_number");
            _distance = dbr.GetValue<double>("DISTANCE");
            _surface = dbr.GetValue<string>("surface");
            _surface = dbr.GetValue<string>("surface");
            _age_sex_restrictions = dbr.GetValue<string>("age_sex_restrictions");
            _state_bred_flag = dbr.GetValue<string>("state_bred_flag");
            _abbr_race_class = dbr.GetValue<string>("abbr_race_class");
            _race_conditions = dbr.GetValue<string>("race_conditions");
            _raceGrade  = dbr.GetValue<int>("race_grade");
            _raceName = dbr.GetValue<string>("race_name");
        }


        public void AddToTree(TreeNode tv)
        {
            string classification = Utilities.MakeRaceCondition(_state_bred_flag, _age_sex_restrictions, _abbr_race_class, _raceGrade, _raceName);
            string distance = Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int)_distance);
            var n = tv.Nodes.Add(string.Format("#{0}. {1} {2} {3}", _raceNumber, distance, _surface, classification));
            n.Tag = this;

            LoadStarters(n);
        }

        private void LoadStarters(TreeNode treeNode)
        {
            var starters = RaceStarterCollection.Make(_raceID);
            starters.Bind(treeNode);
        }
    }
}