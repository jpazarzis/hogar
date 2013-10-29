using System.Collections.Generic;
using System.IO;

namespace RaceReplayViewer
{
    class TrackInfoCollection : List<TrackInfo>
    {
        static private TrackInfoCollection _singleton;

        private const string FILENAME = "Track_Info.txt";
        static public TrackInfoCollection Singleton 
        { 
            get
            {
                if(null == _singleton)
                {
                    _singleton = new TrackInfoCollection();
                }
                return _singleton;

            }
        }

        private TrackInfoCollection()
        {
            Load();
        }

        private void Load()
        {
            this.Clear();
            using (var s = new StreamReader(FILENAME))
            {
                string line;
                while ((line = s.ReadLine()) != null)
                {
                    this.Add(new TrackInfo(line));
                }
            }
        }
    }
}