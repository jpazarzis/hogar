using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Hogar.Parsing;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.RaceResults
{
    public class RaceResultsInsertToDb
    {

        static string _path = @"C:\HorseRacingSoftware\Documents\Results";

        static string _archivePath = @"C:\HorseRacingSoftware\Documents\Results\archive";

        public delegate void ProcessStatusMessageDelegate(string message);

        public event ProcessStatusMessageDelegate ProcessStatusMessageEvent;

        // Jan 3 2011 change made to support the change for PHA to PRX
        static private void RenameFiles()
        {
            string[] filenames = Directory.GetFiles(_path, "*.*");


            foreach (var filename in filenames)
            {
                if (Path.GetFileName(filename).ToUpper().StartsWith("PRX"))
                {
                    Utilities.RenameStringInFile(filename, "\"PRX\"", "\"PHA\"");

                    string newFileName = filename.Replace("PRX", "PHA");

                    File.Move(filename,newFileName);
                }

                
            }
        }

        static public List<string> AvailableFiles
        {
            get
            {
                
                RenameFiles();
                List<string> f = new List<string>(); 
                foreach (string strg in Directory.GetFiles(_path, "*." + "1"))
                {
                    string filename = Path.GetFileName(strg);
                    if (CheckIfAllNeededFilesExist(filename))
                    {
                        f.Add(filename);
                    }
                }

                return f;
            }
        }

        

        public RaceResultsInsertToDb()
        {
        }

        private void SendMessage(string strg)
        {
            if (null != ProcessStatusMessageEvent)
            {
                ProcessStatusMessageEvent(strg);
            }
        }


        public void Import(string filename)
        {
            if (CheckIfAllNeededFilesExist(filename))
            {
                SendMessage("Processing file: " + filename);
                RemoveExistingDataFromDb(filename);
                UpdateRaceDescriptionTable(_path + @"\" + filename);
                UpdateRaceStartersTable(_path + @"\" + filename.Replace(".1", ".2"));
                UpdateRacePayoffsTable(_path + @"\" + filename.Replace(".1", ".3"));
                UpdateRaceExoticsTable(_path + @"\" + filename.Replace(".1", ".4"));
                UpdateRaceFootNotes(_path + @"\" + filename.Replace(".1", ".6"));
            }
            SendMessage("Done....");
        }

        private void MoveFileToArchiveDir(string filename)
        {
            string source = _path + @"\" + filename;
            string dest = _archivePath + @"\" + filename;

            if (File.Exists(dest))
            {
                File.Delete(dest);
            }

            File.Move(source, dest);
        }

        public void ImportAll()
        {
            SendMessage("Processing all files under the " + _path + " directory...");

            

            foreach (string strg in Directory.GetFiles(_path, "*." + "1"))
            {
                string filename = Path.GetFileName(strg);

                if (CheckIfAllNeededFilesExist(filename))
                {
                    SendMessage("Processing file: " + filename);

                    RemoveExistingDataFromDb(filename);

                    UpdateRaceDescriptionTable(_path + @"\" + filename);
                    UpdateRaceStartersTable(_path + @"\" + filename.Replace(".1", ".2"));
                    UpdateRacePayoffsTable(_path + @"\" + filename.Replace(".1", ".3"));
                    UpdateRaceExoticsTable(_path + @"\" + filename.Replace(".1", ".4"));
                    UpdateRaceFootNotes(_path + @"\" + filename.Replace(".1", ".6"));

                    MoveFileToArchiveDir(filename);
                    MoveFileToArchiveDir(filename.Replace(".1", ".2"));
                    MoveFileToArchiveDir(filename.Replace(".1", ".3"));
                    MoveFileToArchiveDir(filename.Replace(".1", ".4"));
                    MoveFileToArchiveDir(filename.Replace(".1", ".5"));
                    MoveFileToArchiveDir(filename.Replace(".1", ".6"));
                }
            }

            SendMessage("exec UpdateTrainerIdInRaceStarter");
            DbReader.ExecuteNonQuery("exec UpdateTrainerIdInRaceStarter");

            SendMessage("Done...." );
        }

        private void RemoveExistingDataFromDb(string filename)
        {
            if (filename.Length < 11)
            {
                throw new Exception("Bris Results file name appears is ivalid");
            }

            string trackCode = filename.Substring(0, 3);
            string month = filename.Substring(3, 2);
            string day = filename.Substring(5, 2);
            string year = filename.Substring(7, 4);
            string dateToClear = year + month + day;

            string sql = string.Format("EXEC RemoveEntries '{0}', '{1}'", trackCode, dateToClear);

            SqlCommand myCommand = new SqlCommand(sql, DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }


        public void TestRaceDescriptionTable(string filename)
        {
            List<ParsableText> ptl = LoadFile(filename);
            foreach (ParsableText pt in ptl)
            {
                var rdd = new RaceDescriptiveData(pt, SendMessage);
                rdd.TestInsertInDb();
            }
        }

        private void UpdateRaceDescriptionTable(string filename)
        {
            List<ParsableText> ptl = LoadFile(filename);
            foreach (ParsableText pt in ptl)
            {
                RaceDescriptiveData rdd = new RaceDescriptiveData(pt,SendMessage);
                rdd.InsertInDb();
            }
        }

        private void UpdateRaceStartersTable(string filename)
        {
            List<ParsableText> ptl = LoadFile(filename);
            foreach (ParsableText pt in ptl)
            {
                RaceStartersData d = new RaceStartersData(pt,SendMessage);
                d.InsertInDb();
            }
        }

        private void UpdateRacePayoffsTable(string filename)
        {
            
            List<ParsableText> ptl = LoadFile(filename);
            foreach (ParsableText pt in ptl)
            {
                RaceStraightBetPayoff d = new RaceStraightBetPayoff(pt);
                d.InsertInDb();
            }
        }

        private void UpdateRaceExoticsTable(string filename)
        {
            
            List<ParsableText> ptl = LoadFile(filename);
            foreach (ParsableText pt in ptl)
            {
                RaceExoticBetPayoff d = new RaceExoticBetPayoff(pt);
                d.InsertInDb();
            }
        }

        private void UpdateRaceFootNotes(string filename)
        {
            
            List<ParsableText> ptl = LoadFile(filename);
            foreach (ParsableText pt in ptl)
            {
                RaceFootNotes d = new RaceFootNotes(pt);
                d.InsertInDb();
            }
        }

        private List<ParsableText> LoadFile(string filename)
        {
            Debug.Assert(File.Exists(filename));

            StreamReader sr = new StreamReader(filename);
            List<ParsableText> pt = new List<ParsableText>();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                pt.Add(new ParsableText(line));

            }
            sr.Close();
            return pt;
        }


        static private bool CheckIfAllNeededFilesExist(string filename)
        {
            for (int i = 2; i <= 6; ++i)
            {
                string temp = filename;
                temp = _path+ @"\"+temp.Replace(".1", "." + i.ToString());
                if (File.Exists(temp) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
