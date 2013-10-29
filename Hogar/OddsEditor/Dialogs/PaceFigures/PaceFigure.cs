using Hogar.DbTools;

namespace OddsEditor.Dialogs.PaceFigures
{
   public class PaceFigure
    {

        public PaceFigure(DbReader dbr)
        {
            RaceId = dbr.GetValue<int>("raceid");
            RaceClassification = dbr.GetValue<string>("raceClassification");
            DateOfTheRace = dbr.GetValue<string>("dateOfTheRace");
            TrackCondition = dbr.GetValue<string>("trackCondition");
            RaceNumber = dbr.GetValue<int>("raceNumber");
            Call1 = dbr.GetValue<int>("figure1");
            Call2 = dbr.GetValue<int>("figure2");
            FinalCall = dbr.GetValue<int>("finalTime");

        }

        public int RaceId { get; set; }

        public string RaceClassification { get; set; }

        public string DateOfTheRace { get; set; }

        public string TrackCondition { get; set; }

        public int RaceNumber { get; set; }

        public int Call1 { get; set; }

        public int Call2 { get; set; }

        public int FinalCall { get; set; }

    }
}