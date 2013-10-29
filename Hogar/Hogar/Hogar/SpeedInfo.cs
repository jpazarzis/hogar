namespace Hogar
{
    public class SpeedInfo
    {
        private readonly Horse _horse;

        public SpeedInfo(Horse horse)
        {
            _horse = horse;
        }

        public string HorseName
        {
            get
            {
                return _horse.Name;
            }
        }

        public double FasterPaceFigure
        {
            get
            {
                if (_horse.CorrespondingBrisHorse.PastPerformances.Count <= 0)
                    return -999;

                double fasterFigure = -999;
                int distance = 0;
                int position = 0;
                
                foreach (var pp in _horse.CorrespondingBrisHorse.PastPerformances)
                {
                    if (pp.GoldenPaceFigureForThisHorse == -999 || pp.GoldenFigureForThisHorse == -999)
                    {
                        continue;
                    }
                        
                    if (fasterFigure <= 0)
                    {
                        fasterFigure = pp.GoldenPaceFigureForThisHorse;
                        distance = pp.DistanceInYards;
                        int.TryParse(pp.SecondCallPosition, out position);
                        continue;
                    }

                    if (fasterFigure < pp.GoldenPaceFigureForThisHorse && distance > pp.DistanceInYards)
                    {
                        fasterFigure = pp.GoldenPaceFigureForThisHorse;
                        distance = pp.DistanceInYards;
                        int.TryParse(pp.SecondCallPosition, out position);
                        continue;
                    }
                        
    
                }

                return fasterFigure;
            }
        }


    }
}