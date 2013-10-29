using System.Collections.Generic;
using System.Windows.Forms;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.SelectCard
{
    class RaceStarterCollection: List<RaceStarter>
    {
        const string _sqlLoadFromDb = @"select horse_name, program_number, official_position from race_starters where race_id = {0}  and program_number != 'scr'  order by official_position";

        public static RaceStarterCollection Make(int raceid)
        {
            return new RaceStarterCollection(raceid);
        }

        private readonly int _raceid;
        

        protected RaceStarterCollection(int raceid)
        {
            _raceid = raceid;
            LoadFromDb();
        }

        private void LoadFromDb()
        {
            this.Clear();
            using (var dbr = new DbReader())
            {
                if (dbr.Open(string.Format(_sqlLoadFromDb, _raceid)))
                {
                    while (dbr.MoveToNextRow())
                    {
                        this.Add(new RaceStarter(dbr));
                    }
                }
            }
        }

        

        public void Bind(TreeNode node)
        {
            node.Nodes.Clear();

            foreach (RaceStarter rs in this)
            {
                rs.AddToNode(node);
            }
        }
    }
    
}