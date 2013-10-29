namespace Hogar.Handicapping
{
    class LostMoreThanFiveInTheRow : Factor
    {
        public LostMoreThanFiveInTheRow(int bitpower)
            : base("LostMoreThanFiveInTheRow", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse horse)
        {
            if (horse.CorrespondingBrisHorse.IsFirstTimeOut || horse.CorrespondingBrisHorse.PastPerformances.Count < 5)
            {
                return false;
            }

            for (int i = 0; (i < 5) && (i < horse.CorrespondingBrisHorse.PastPerformances.Count); ++i)
            {
                var pp = horse.CorrespondingBrisHorse.PastPerformances[i];

                if (pp.WasTheWinner)
                {
                    return false;
                }
            }
            return true;
        }
    }
}