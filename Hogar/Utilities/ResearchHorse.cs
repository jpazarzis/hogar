using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    class ResearchHorse 
    {
        public string ProgramNumber { get; private set; }

        public List<int> Figure { get; private set; }

        public int FinalPosition { get; private set; }

        public double FinalOdds { get; private set; }

        static public ResearchHorse Make(string [] s, ref int pos)
        {
            return new ResearchHorse(s, ref pos);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(ProgramNumber);
            sb.Append("\t");
            sb.Append(string.Format("{0}\t",Figure.Count));
            Figure.ForEach(f => sb.Append(string.Format("{0}\t", f)));
            sb.Append(string.Format("{0}\t", FinalPosition));
            sb.Append(string.Format("{0:0.00}\t", FinalOdds));


            return sb.ToString();
        }

        private ResearchHorse(string[] s, ref  int pos)
        {
            Figure = new List<int>();

            ProgramNumber = s[pos++];

            int numberOfFigures = Convert.ToInt32(s[pos++]);

            for(int i = 0; i < numberOfFigures; ++i)
            {
                Figure.Add(Convert.ToInt32(s[pos++]));
            }

            FinalPosition = Convert.ToInt32(s[pos++]);

            FinalOdds = Convert.ToDouble(s[pos++]);

        }
    }
}