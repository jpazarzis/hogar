using System;
using System.Collections.Generic;
using System.IO;
using Hogar.RaceGrouping;

namespace Hogar.GeneticProgramming
{
    public sealed class DecisionTreeList : List<DecisionTree>
    {
        private const string GA_SCRIPTS_PRODUCTION_DIR = @"C:\HorseRacingSoftware\Documents\GeneticPrograms";
        private const string GA_SCRIPTS_RESEARCH_DIR = @"C:\HorseRacingSoftware\Documents\GeneticPrograms\Research";

        private readonly string _directory;
        private readonly Type _type;
        private string _filename;

        public enum Type
        {
            Research, Production
        }


        public DecisionTreeList(Type t)
        {
            _type = t;
            switch (_type)
            {
                case Type.Research:
                    _directory = GA_SCRIPTS_RESEARCH_DIR;
                    break;
                case Type.Production:
                    _directory = GA_SCRIPTS_PRODUCTION_DIR;
                    break;
                default:
                    _directory = "";
                    break;
            }
        }

        static public string ResearchDirectory
        {
            get
            {
                return GA_SCRIPTS_RESEARCH_DIR;
            }
        }
       
        public List<string> AvailableFiles
        {
            get
            {
                var list = new List<string>();
                var files = Directory.GetFiles(_directory);
                foreach (var file in files)
                {
                    list.Add(Path.GetFileName(file));
                }
                return list;
            }
        }

        public bool FileExists(string filename)
        {
            return File.Exists(GetFullPath(filename));
        }

        public void ReadFromDisk(string filename)
        {
            _filename = filename;
            this.Clear();
            using (var sr = new StreamReader(GetFullPath(filename)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    this.Add(DecisionTree.Make(line));
                }    
            }
        }

        public void Save()
        {
            using (var writer = new StreamWriter(GetFullPath(_filename)))
            {
                this.ForEach(dt => writer.WriteLine(dt.GetCodeAsScript()));
            }
        }

        public void SaveAs(string filename)
        {
            _filename = filename;
            using (var writer = new StreamWriter(GetFullPath(filename)))
            {
                this.ForEach(dt=>writer.WriteLine(dt.GetCodeAsScript()));
            }
        }

        private string GetFullPath(string filename)
        {
            return _directory + @"\" + filename;
        }

        public void MoveToProduction()
        {
            if(Type.Research ==_type )
            {
                string temp = TargetGroup.MakeFileNameForProduction(_filename);
                string destination = GA_SCRIPTS_PRODUCTION_DIR + @"\" + temp;
                string source = GetFullPath(_filename);

                if (File.Exists(destination))
                {
                    File.Delete(destination);
                }

                File.Copy(source,destination);
            }
        }
    }
}