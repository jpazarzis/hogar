using System.Collections.Generic;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.PaceFigures
{
    public class PaceFigureCollection : List<PaceFigure>
    {
        private readonly string _trackCode;
        private readonly int _distance;
        private readonly string _surface;
        private readonly string _aboutDistanceFlag;

        private const string _sqlLoader = @"exec GetPaceFigures '{0}', {1} , '{2}', '{3}'";

        public PaceFigureCollection(string trackCode, int distance, string surface, string aboutDistanceFlag)
        {
            _trackCode = trackCode;
            _distance = distance;
            _aboutDistanceFlag = aboutDistanceFlag;

            if(surface == "id")
                _surface = "d";
            else if (surface == "it")
                _surface = "t";
            else if (surface == "d" || surface == "D")
                _surface = "D";
            else if (surface == "t" || surface == "T")
                _surface = "T";

            Load();
        }

        private void Load()
        {
            string sql = string.Format(_sqlLoader, _trackCode, _distance, _surface, _aboutDistanceFlag);

            this.Clear();
            using (var dbr = new DbReader())
            {
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        Add(new PaceFigure(dbr));
                    }
                }
            }
        }



    }
}