using Hogar.DbTools;

namespace Hogar.FactorStatisticsNew.FactorStatisticsForTrainer
{
    internal class StarterCollection : DataBaseCollection<Starter>
    {
        private const string SQL_TRAINER_LOADER = @"select FACTORS_FLAG , a.WIN_PAYOFF, NUMBER_OF_HORSES_IN_RACE 'FIELD_SIZE' , a.ABBR_TRAINER_NAME, a.ABBR_JOCKEY_NAME
FROM RACE_STARTERS a, HORSE_FACTORS b

where 
a.trainer_id = {0}
and a.PROGRAM_NUMBER != 'SCR' and a.ID = b.HORSE_ID ";

        private const string SQL_JOCKEY_LOADER = @"select FACTORS_FLAG , a.WIN_PAYOFF, NUMBER_OF_HORSES_IN_RACE 'FIELD_SIZE' , a.ABBR_TRAINER_NAME, a.ABBR_JOCKEY_NAME
FROM RACE_STARTERS a, HORSE_FACTORS b

where 
a.ABBR_JOCKEY_NAME = '{0}'
and a.PROGRAM_NUMBER != 'SCR' and a.ID = b.HORSE_ID "; 



        public StarterCollection()
        {
            
        }

        public void LoadStartersForTrainer(string trainer)
        {
            Load(string.Format(SQL_TRAINER_LOADER, Trainers.GetTrainerId(trainer)));
        }

        public void LoadStartersForJockey(string jockey)
        {
            Load(string.Format(SQL_JOCKEY_LOADER, jockey));
        }

    }
}