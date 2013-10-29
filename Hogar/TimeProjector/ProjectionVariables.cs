namespace TimeProjector
{
    public class ProjectionVariables
    {
        public string TrackDesc { get; set; }
        public string TrackCode { get; set; }
        public string Surface { get; set; }
        public double Slope { get; set; }
        public double Ordinate { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", TrackDesc, Slope, Ordinate);
        }
    }
}