using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hogar.RaceResults;

namespace FixResultsUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var test = new RaceResultsInsertToDb();

                test.TestRaceDescriptionTable(@"c:\temp\pha03132010.1");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
