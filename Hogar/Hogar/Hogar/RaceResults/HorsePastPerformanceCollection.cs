using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;
using System.Drawing;
using System.Windows.Forms;


namespace Hogar.RaceResults
{
    public class HorsePastPerformanceCollection
    {
        readonly List<HorsePastPerformance> _pp = new List<HorsePastPerformance>();

        public HorsePastPerformanceCollection(string name)
        {
            LoadFromDb(name);
        }

        public void BindGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            
            grid.Columns.Add("Track", "Track");
            grid.Columns.Add("Date", "Date");
            grid.Columns.Add("Race#", "Race#");
            grid.Columns.Add("Dist", "Dist");
            grid.Columns.Add("Surf", "Surf");
            grid.Columns.Add("Class", "Class");
            grid.Columns.Add("Jockey", "Jockey");
            grid.Columns.Add("Trainer", "Trainer");
            grid.Columns.Add("Odds", "Odds");
            grid.Columns.Add("Weight", "Weight");
            grid.Columns.Add("Pos", "Pos");
            grid.Columns.Add("WinTime", "WinTime");
            grid.Columns.Add("Len", "Len");
            grid.Columns.Add("ActTime", "ActTime");
            grid.Columns.Add("GoldenFigure", "GoldenFigure");
            grid.Columns.Add("WinnersGoldenFigure", "WinnersGoldenFigure");

            foreach (HorsePastPerformance hpp in _pp)
            {
                int index = grid.Rows.Add();

                grid["Track", index].Value = hpp.TrackCode;
                grid["Date", index].Value = Utilities.GetFullDateString(hpp.Date);
                grid["Race#", index].Value = hpp.RaceNumber;
                grid["Dist", index].Value = Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int)hpp.Distance);
                grid["Surf", index].Value = hpp.Surface;
                grid["Class", index].Value = hpp.RaceClass;
                grid["Jockey", index].Value = Utilities.CapitalizeOnlyFirstLetter(hpp.Jockey);
                grid["Trainer", index].Value = Utilities.CapitalizeOnlyFirstLetter(hpp.TrainerName);
                grid["Odds", index].Value = hpp.Odds;
                grid["Weight", index].Value = hpp.Weight;
                grid["Pos", index].Value = hpp.OfficialPosition;
                grid["WinTime", index].Value = Utilities.ConvertTimeToMMSSFifth(hpp.WinnersTime);
                grid["Len", index].Value = hpp.TotalMargin;
                grid["ActTime", index].Value = Utilities.ConvertTimeToMMSSFifth(hpp.ActualTime);
                grid["WinTime", index].ToolTipText = "Winners Time";
                grid["Len", index].ToolTipText = "Finished Length Margin";
                grid["ActTime", index].ToolTipText = "This horse's time";

                grid["GoldenFigure", index].Value = hpp.GoldenFigure;
                grid["WinnersGoldenFigure", index].Value = hpp.WinnersGoldenFigure;


                if (hpp.OfficialPosition == 1)
                {
                    grid.Rows[index].DefaultCellStyle.BackColor = Color.LightPink;
                }
                else if (hpp.OfficialPosition == 2)
                {
                    grid.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                }


                grid.Rows[index].Tag = hpp;
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToOrderColumns = false;

        }

        void LoadFromDb(string name)
        {
            _pp.Clear();
            SqlDataReader myReader = null;
            try
            {             
                SqlCommand myCommand = new SqlCommand(SQLLoad(name), Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        _pp.Add(new HorsePastPerformance(myReader));
                    }
                }
                myReader.Close();
            }
            finally
            {
                if (null != myReader && myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                double margin = 0;
                foreach (HorsePastPerformance h in _pp)
                {
                    if (h.FinishPosition == 1 || h.FinishPosition == 2)
                    {
                        margin = h.FinishLengthsBehind;
                    }
                    else
                    {
                        margin += h.FinishLengthsBehind;
                    }
                    
                    h.TotalMargin = margin;
                    
                }
            }


        }

        string SQLLoad(string name)
        {
            
                return string.Format(@"SELECT   a.RACE_ID, 
                                                a.TRACK_CODE  ,
                                                a.RACING_DATE ,
                                                a.RACE_NUMBER ,
                                                b.DISTANCE,
                                                b.SURFACE,
                                                b.ABBR_RACE_CLASS,
                                                a.HORSE_NAME,
                                                a.ABBR_JOCKEY_NAME,
                                                a.ABBR_TRAINER_NAME,
                                                a.ODDS,
                                                a.WEIGHT,
                                                a.OFFICIAL_POSITION,
                                                a.FINISH_POSITION,
                                                b.FINAL_TIME,
                                                a.FINISH_LENGTHS_BEHIND ,
                                                dbo.GoldenSpeedFigure (a.track_code, a.racing_date, b.final_time, finish_lengths_behind, distance) 'GoldenFigure',
                                                dbo.GoldenSpeedFigure (a.track_code, a.racing_date, b.final_time, 0, distance) 'WinnersGoldenFigure' 
                                        FROM RACE_STARTERS a, RACE_DESCRIPTION b
                                        WHERE HORSE_NAME LIKE ('{0}') 
                                                AND a.RACE_ID = b.RACE_ID
                                                AND a.program_number !='SCR' ORDER BY a.RACING_DATE DESC",
                                        name);

            
        }
    }
}
