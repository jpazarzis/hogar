using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ExoticStudio
{
    class Tools
    {
        // Returns a string consisting of count tabs, used to format output
        static public string GetTabedPrefix(int count)
        {
            string prefix = "";

            for (int i = 0; i < count; ++i)
            {
                prefix += "\t";
            }

            return prefix;

        }

        
        static public readonly string COMMON_DIR_KEY = "CommonDirectory";

        static public readonly string FILE_FILTER = "system files |*.stm";

        static public readonly int MAX_NUMBER_OF_HORSES_PER_RACE = 15;

        static public readonly Color SELECTED_BACKGROUND_COLOR = Color.Green;

        static public readonly Color SELECTED_FORE_COLOR = Color.Black;

        static public readonly Color UNSELECTED_BACKGROUND_COLOR = Color.White;

        static public readonly Color UNSELECTED_FORE_COLOR = Color.Black;

        static public readonly int MINIMUM_NUMBER_OF_RACES = 3;

        static public readonly int MAXIMUM_NUMBER_OF_RACES = 9;

    }
}
