using System.Collections.Generic;
using Hogar.DbTools;

namespace Hogar
{
    static public class Trainers
    {
        static Dictionary<string, int> _trainerIds = null;

        static public int GetTrainerId(string name)
        {
            if(null == _trainerIds)
            {
                LoadTrainers();
            }

            string key = name.Trim().ToUpper();

            return _trainerIds.ContainsKey(key) ? _trainerIds[key] : -999;
        }

        static void LoadTrainers()
        {
            _trainerIds = new Dictionary<string, int>();
            
            using (var dbr = new DbReader())
            {
                if (dbr.Open("select TRAINER_ID, ABBR_TRAINER_NAME FROM TRAINERS"))
                {
                    while (dbr.MoveToNextRow())
                    {
                        int id = dbr.GetValue<int>("TRAINER_ID");
                        string name = dbr.GetValue<string>("ABBR_TRAINER_NAME");

                        _trainerIds.Add(name.ToUpper().Trim(),id);
                    }
                }
            }
        }

    }
}