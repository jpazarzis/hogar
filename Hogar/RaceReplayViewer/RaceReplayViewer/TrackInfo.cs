namespace RaceReplayViewer
{
    class TrackInfo
    {
        public string Name { get; private set; }
        public string TrackCode { get; private set; }
        public TrackInfo(string line)
        {
            string[] token = line.Split('\t');
            Name = token[0];
            TrackCode = token[1];
        }
        public override string ToString()
        {
            return Name;
        }
    }
}