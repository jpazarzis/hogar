using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Betting.Superfecta
{
    class ValidCombinationLimitation: ISuperfectaLimitation
    {
        public bool IsValid(int firstHorse, int secondHorse, int thirdHorse, int fourthHorse)
        {
            if (firstHorse == secondHorse   || 
                firstHorse == thirdHorse    || 
                firstHorse == fourthHorse   || 
                secondHorse == thirdHorse   || 
                secondHorse == fourthHorse  || 
                thirdHorse == fourthHorse)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
