using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PredictionsCompetition.DataModel
{
    public class Competition
    {
        readonly List<Handicapper> _participants = new List<Handicapper>();

        public IEnumerable<Handicapper> Participants
        {
            get { return _participants; }
        }

        public void AddParticipant(Handicapper handicapper)
        {
            _participants.Add(handicapper);   

        }
    }
}