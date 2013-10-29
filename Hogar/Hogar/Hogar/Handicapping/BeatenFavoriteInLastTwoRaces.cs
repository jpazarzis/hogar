namespace Hogar.Handicapping
{
    class BeatenFavoriteInLastTwoRaces : Factor
    {
        public BeatenFavoriteInLastTwoRaces(int bitpower)
            : base("BeatenFavoriteInLastTwoRaces", bitpower)
        {
        }

        public override bool AppliesToHorse(Horse horse)
        {
            if (horse.CorrespondingBrisHorse.IsFirstTimeOut)
            {
                return false;
            }

            for(int i = 0; (i <2) &&  (i < horse.CorrespondingBrisHorse.PastPerformances.Count); ++i)
            {
                var pp = horse.CorrespondingBrisHorse.PastPerformances[i];

                if(pp.WasTheFavorite && (!pp.WasTheWinner))
                {
                    return true;
                }
            }
            return false;
        }
    }
}