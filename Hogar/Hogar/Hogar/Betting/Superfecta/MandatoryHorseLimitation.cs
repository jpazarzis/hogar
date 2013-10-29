using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Betting.Superfecta
{
    public class MandatoryHorseLimitation : ISuperfectaLimitation
    {
        readonly int _horseNumber;

        public MandatoryHorseLimitation(int horseNumber)
        {
            _horseNumber = horseNumber;
        }


        public bool IsValid(int firstHorse, int secondHorse, int thirdHorse, int fourthHorse)
        {
            return  firstHorse == _horseNumber ||
                    secondHorse == _horseNumber ||
                    thirdHorse == _horseNumber ||
                    fourthHorse == _horseNumber;
        }

        public override int GetHashCode()
        {
            return _horseNumber;
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }
            else if (this == obj)
            {
                return true;
            }
            else if (obj is MandatoryHorseLimitation)
            {
                MandatoryHorseLimitation other = obj as MandatoryHorseLimitation;

                return other._horseNumber == _horseNumber;
            }
            else
            {
                return false;
            }
        }

        
    }
}
