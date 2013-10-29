namespace Hogar.Filter
{
    public abstract class Filter
    {
        private readonly string _name;

        protected Filter(string name)
        {
            _name = name;    
        }

        public void Apply(Race race)
        {
            race.Horses.ForEach(ApplyToHorse);
        }

        public string Name 
        { 
            get
            {
                return _name;
            }
        }

        protected abstract void ApplyToHorse(Horse h);

        public override string ToString()
        {
            return _name;
        }
    }
}