using System.Collections.Generic;

namespace ExoticStudio
{
    public sealed class WeightStatistics
    {
        readonly Dictionary<int,int> _value = new Dictionary<int, int>();
        readonly Dictionary<int, int> _weight = new Dictionary<int, int>();

        public RaceCard SelectedRaceCard { get; set; }


       public Dictionary<int,int> Value
        {
            get { return _value; }
        }


       public Dictionary<int, int> Weight
        {
            get { return _weight; }
        }


        public void Clear()
        {
            _value.Clear();
            _weight.Clear();
        }


        public int GetTotalWeight(Limitation limitation)
        {
            if(null == SelectedRaceCard || null == limitation)
                return 0;
            int fromRace = limitation.FirstRace;
            int toRace = fromRace + limitation.Count()-1;
            int weightTotal = 0;
            for(int rn = fromRace, i=0; rn <= toRace; ++rn, ++i)
            {
                var race = SelectedRaceCard.GetRace(rn);
                if(null != race)
                {
                    var horse = race.GetHorse(limitation.Selections[i]);
                    if(null != horse)
                    {
                        weightTotal += horse.WeightIndex;
                    }
                }
            }
            return weightTotal;
        }

        public int GetTotalValue(Limitation limitation)
        {
            if (null == SelectedRaceCard || null == limitation)
                return 0;
            int fromRace = limitation.FirstRace;
            int toRace = fromRace + limitation.Count() - 1;
            int valueTotal = 0;
            for (int rn = fromRace, i = 0; rn <= toRace; ++rn, ++i)
            {
                var race = SelectedRaceCard.GetRace(rn);
                if (null != race)
                {
                    var horse = race.GetHorse(limitation.Selections[i]);
                    if (null != horse)
                    {
                        valueTotal += horse.ValueIndex;
                    }
                }
            }
            return valueTotal;
        }

        public void Add(Limitation limitation)
        {
            if(null == SelectedRaceCard || null == limitation)
                return;

            int valueWeightTotal = GetTotalValue(limitation);
            int weightTotal = GetTotalWeight(limitation);

            if(!_value.ContainsKey(valueWeightTotal))
            {
                _value.Add(valueWeightTotal,0);
            }

            if(!_weight.ContainsKey(weightTotal))
            {
                _weight.Add(weightTotal,0);
            }

            _value[valueWeightTotal]++;
            _weight[weightTotal]++;
        }
    }
}