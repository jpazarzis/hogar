using System;
using System.IO;
using Hogar.DbTools;

namespace Hogar.Algorithms.ANN.InputData
{
    public partial class StarterInfo
    {
        private const string _sqlLoad = @"select 
            b.race_id,
	        a.track_code,
	        a.racing_date,
	        horse_name,
	        b.surface,
            a.finish_position,
            a.Odds,    
	        dbo.GoldenSpeedFigure (a.track_code, a.racing_date, b.final_time, finish_lengths_behind, distance) 'goldenFigure',
            dbo.GoldenSpeedFigure (a.track_code, a.racing_date, b.final_time, 0, distance) 'WinnersGoldenFigure',
            b.track_condition,
            b.distance,
            a.call_2_position,
            bris_race_type,
			age_sex_restrictions,
			state_bred_flag,
			post_position,
			claimed_indicator,
			equipment_codes,
            medication_codes,
            field_size,
            favorite_flag
        from 
	        race_starters a, race_description b 
        where 
	        a.program_number != 'SCR'
        and b.race_id = a.race_id
        and CONTAINS_VALID_TIME = 'Y'
        and surface != 't'
        order by horse_name, a.racing_date";

        static public void CreateGoldenFigureFile(string filename)
        {
            var collection = new DataBaseCollection<StarterInfo>();

            collection.Load(_sqlLoad);

            int counter = 0;
            using (var tw = new StreamWriter(filename))
            {
                string currentHorse = "";
                string line = "";

                foreach (var si in collection)
                {
                    ++counter;

                    if (0 == counter % 100)
                    {
                        Console.WriteLine(counter);
                    }

                    if(si.GoldenFigure == -999 || si.WinnersGoldenFigure == -999)
                        continue;

                    string horse = si.HorseName;

                    if (currentHorse.Length > 0 && currentHorse != horse)
                    {
                        if (line.Length > 0)
                        {
                            tw.Write(currentHorse);
                            tw.Write(",");
                            tw.WriteLine(line);
                        }

                        line = "";
                    }

                    currentHorse = horse;

                    if (si.FinishPosition > 0)
                    {
                        if (line.Length > 0)
                        {
                            line += ",";
                        }

                        line += si.GetAsParsableString();
                    }

                }

                if (line.Length > 0)
                {
                    tw.Write(currentHorse);
                    tw.Write(",");
                    tw.WriteLine(line);
                }

                tw.Close();
            }
        }
    }
}