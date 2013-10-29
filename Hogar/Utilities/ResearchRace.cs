using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilities
{
    class ResearchRace : List<ResearchHorse>
    {

        static public List<ResearchRace> CreateFromFile(string filename)
        {

            var list = new List<ResearchRace>();

            using (var sr = new StreamReader(filename))
            {
                string txt = sr.ReadLine();

                

                while (!sr.EndOfStream && txt.Length > 0)
                {
                    
                    list.Add(ResearchRace.Make(txt));
                    txt = sr.ReadLine();
                }
            }

            return list;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            this.ForEach(horse=>sb.Append(string.Format("{0}\t",horse)));
            

            return sb.ToString();
        }


        static public ResearchRace Make(string line)
        {
            return new ResearchRace(line);
        }

        public List<double > GetFigures()
        {
            var list = new List<double>();


            foreach (var horse in this)
            {
                foreach (var f in horse.Figure)
                {
                    list.Add(f);
                }
            }

            return list;
            
        }

        private ResearchRace(string line)
        {
            string[] s = line.Split('\t');

            int pos = 0;

            while (pos < s.Length-1)
            {
                Add(ResearchHorse.Make(s,ref pos));
            }
        }
    }
}