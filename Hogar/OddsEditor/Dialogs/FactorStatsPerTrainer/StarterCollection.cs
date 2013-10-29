using System.Collections.Generic;
using System.ComponentModel;
using Hogar.DbTools;
using System.Linq;

namespace OddsEditor.Dialogs.FactorStatsPerTrainer
{
    internal class StarterCollection : List<Starter>
    {

        static public StarterCollection Make(StarterCollection other, long bitMask )
        {
            var sc = new StarterCollection();
            sc.AddRange(other.Where(starter => (starter.FactorsFlag & bitMask) == bitMask));
            return sc;
        }


        static public StarterCollection Make(string trainerName, long bitMask)
        {
            return new StarterCollection(trainerName,bitMask);
        }

        private StarterCollection()
        {
        }

        private StarterCollection(string trainerName, long bitMask)
        {
            Load(trainerName, bitMask);
            
        }

        public List<Starter> Filter(int filter)
        {
             var v=  from p in this
                     where ((p.BrisRaceTypeFlag) & filter) == p.BrisRaceTypeFlag
                    select p;

            return v.ToList();
        }

        private void Load(string trainerName, long bitMask)
        {
            string sql = string.Format("exec GetAllStartersPerTrainerAndFactor {0} , '{1}'", bitMask, trainerName);

            Clear();
            using (var dbr = new DbReader())
            {
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        Add(new Starter(dbr));
                    }
                }
            }


        }
    }
}