using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OddsEditor.UITools
{
    static public class UITools
    {
        public delegate bool FieldValidatorDelegate<T>(string s, out T v);
    }
}
