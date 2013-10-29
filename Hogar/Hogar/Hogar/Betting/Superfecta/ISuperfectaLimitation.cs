using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Betting.Superfecta
{
    public interface ISuperfectaLimitation
    {
        bool IsValid(int firstHorse, int secondHorse, int thirdHorse, int fourthHorse);
    }
}
