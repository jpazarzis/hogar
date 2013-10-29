namespace OddsEditor.Dialogs.FactorWorkbench
{
    class GroupingInfo
    {
        public GroupingInfo()
        {
            ByTrack = ByDistance = ByClassification = false;    
        }

        public bool ByTrack
        {
            get;
            set;
        }

        public bool ByDistance
        {
            get;
            set;
        }

        public bool ByClassification
        {
            get;
            set;
        }

        public bool ByTrainer
        {
            get;
            set;
        }
        
    }
}