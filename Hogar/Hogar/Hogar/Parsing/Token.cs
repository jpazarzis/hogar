using System;

namespace Hogar.Parsing
{
    public class Token
    {
        const char _TEXT_DELIMETER = '"';

        readonly string _toString;

        private readonly int _textLength;


        public Token(string txt)
        {
            if(NeedsToBeTrimed(txt))
            {
                txt = txt.Trim();   
            }

            _textLength = txt.Length;
             bool isEmpty = _textLength <= 0;
             bool isNumeric = (isEmpty ? true : txt[0] != _TEXT_DELIMETER);

            if(isEmpty)
            {
                _toString = "";
            }
            else
            {
                if(isNumeric)
                {
                    _toString = txt;
                }
                else
                {
                    if (txt.Contains("'"))
                    {
                        txt = txt.Replace("'", "`");
                    }

                    if (txt.IndexOf(_TEXT_DELIMETER) >=0)
                    {
                        txt = txt.Replace(_TEXT_DELIMETER, ' ');
                    }

                    _toString = txt;

                    if(NeedsToBeTrimed(_toString))
                    {
                        _toString = _toString.Trim();
                    }

                    //_toString = txt.Replace("'", "`").Replace(_TEXT_DELIMETER, ' ').Trim();   
                }
                
            }                                
        }


        static private bool NeedsToBeTrimed(string str)
        {
            int length = str.Length;

            if(length<=0)
            {
                return false;
            }
            else
            {
                return (str[length - 1] == ' ') || (str[0] == ' ');    
            }
        }

        public override string ToString()
        {
            return _toString;            
        }

        public int Length
        {
            get
            {
                return _textLength;
            }
        }

        public int GetAsInteger()
        {
            int i = 0;
            return int.TryParse(_toString, out i) ? i : 0;
        }

        public double GetAsDouble()
        {
            double d = 0.0;
            return double.TryParse(_toString, out d) ? d : 0.0;
        }
    }
}
