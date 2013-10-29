using System.Collections.Generic;
using System.Windows.Forms;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.SelectCard
{
    class RaceInfoCollection : List<RaceInfo>
    {
        const string _sqlLoadFromDb = @"select 
	race_id,
	race_number, 
	distance, 
	surface, 
	age_sex_restrictions, 
	state_bred_flag, 
	abbr_race_class,
	race_conditions,
    race_grade,
    race_name    
    from race_description where track_code = '{0}' and date_of_the_race = '{1}'";

        public static RaceInfoCollection Make(string trackCode, string date)
        {
            return new RaceInfoCollection(trackCode,date);
        }

        private readonly string _trackCode;
        private readonly string _date;

        protected RaceInfoCollection(string trackCode, string date)
        {
            _trackCode = trackCode;
            _date = date;
            LoadFromDb();
        }

        private void LoadFromDb()
        {
            this.Clear();
            using (var dbr = new DbReader())
            {
                if (dbr.Open(string.Format(_sqlLoadFromDb, _trackCode, _date)))
                {
                    while (dbr.MoveToNextRow())
                    {
                        this.Add(new RaceInfo(dbr));
                    }
                }
            }
        }

        

        public void Bind(TreeNode tv)
        {
            tv.Nodes.Clear();

            foreach (RaceInfo ri in this)
            {
                ri.AddToTree(tv);
            }
        }
    }
}