namespace Sipp
{
    public class SippHandicappingFactorStats
    {
        static public SippHandicappingFactorStats Make(int sampleSize, double winPercent, double roi, double iv)
        {
            return new SippHandicappingFactorStats
                       {
                           SampleSize = sampleSize,
                           WinningPercent = winPercent,
                           Roi = roi,
                           IV = iv
                       };
        }

        public int SampleSize { get;  set; }
        public double WinningPercent { get; set; }
        public double Roi { get; set; }
        public double IV { get; set; }

        public override string ToString()
        {
            return string.Format("{0,5} {1,2:#0}% {2,5:#0.00} {3,5:#0.00}",

                SampleSize, WinningPercent, Roi, IV);
        }


        private SippHandicappingFactorStats()
        {
            
        }
    }
}