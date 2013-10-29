using Hogar.DbTools;

namespace OddsEditor.Dialogs.FactorStatsPerTrainer
{
    internal class TrainerSummary
    {
        public string Name { get; private set; }
        public int StartersCount { get; private set; }
        public double WinPercent { get; private set; }
        public double ROI { get; private set; }
        public double IV { get; private set; }

        static public TrainerSummary Make(string trainerName)
        {
            return new TrainerSummary(trainerName);
        }


        private TrainerSummary(string trainerName)
        {
            Name = trainerName;
            Load();
        }

        private void Load()
        {
            string sql = string.Format("exec GetSummarizedStatsForTrainer '{0}'", Name);
            using (var dbr = new DbReader())
            {
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        StartersCount = dbr.GetValue<int>("STARTERS");
                        WinPercent = dbr.GetValue<double>("WIN_PERCENT");
                        ROI = dbr.GetValue<double>("ROI");
                        IV = dbr.GetValue<double>("IV");     
                    }
                }
            }

        }
    }
}