using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Hogar
{

    // OddsWrapper 
    //      This class is used as a wrapper around an existing odds object
    //      to define the Display mode.
    //      Used when we need to have more than one observers of an odds object
    //      Specifically used when we expose the

    [Serializable]
    public class Odds : ISerializable
    {
        public enum StringFormating
        {
            FractionalOdds,
            OneBasedOdds
        }

        double _oddsToOne = 0;


        StringFormating _format = StringFormating.OneBasedOdds;

        bool _dirty = false;

        Horse _parent = null;


        // Copy Constructor
        public Odds(Odds other)
        {
            _oddsToOne = other._oddsToOne;
            _format = other._format;
        }

        public Odds(SerializationInfo info, StreamingContext ctxt)
        {
            _oddsToOne = (double)info.GetValue("_oddsToOne", typeof(double));
            _format = (StringFormating)info.GetValue("_format", typeof(StringFormating));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_oddsToOne", _oddsToOne);
            info.AddValue("_format", _format);
        }

        public static Odds Make(string txt)
        {
            return new Odds(txt);
        }

        public Horse Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }



        public StringFormating Format
        {
            get { return _format; }
            set { _format = value; }
        }



        public void ReadOddsFromString(string strg)
        {
            double newOdds = _oddsToOne;

            _dirty = true;

            if (null == strg || strg.Length <= 0)
            {
                newOdds = 1.0;
            }
            else
            {
                string txt = strg.Trim().Replace(" ", "").Replace("-", "/");


                int position = 0;

                try
                {
                    double nominator = Convert.ToDouble(GetNextToken(txt, ref position));
                    double denominator = Convert.ToDouble(GetNextToken(txt, ref position));

                    newOdds = nominator / denominator;
                }
                catch 
                {
                    newOdds = 1;
                }
            }

            if (newOdds != _oddsToOne)
            {
                _oddsToOne = newOdds;
            }

            RoundOddsToOne();

            if (null != _parent)
            {
                _parent.Save();
            }
        }

        private Odds(string strg)
        {
            ReadOddsFromString(strg);
            RoundOddsToOne();
        }

        private Odds()
        {
            RoundOddsToOne();
        }

        private void RoundOddsToOne()
        {
            _oddsToOne = (double)((int)(_oddsToOne * 100)) / 100.00;
        }

        private int FindNominatorFactor()
        {

            RoundOddsToOne();


            for (int i = 1; i < 1000; ++i)
            {
                double temp = _oddsToOne * (double)i;

                temp = Math.Abs(temp - (double)((int)temp));


                if (temp < 0.01)
                {
                    return i;
                }
            }

            throw new Exception("Failed to convert odds to string format");
        }

        public override string ToString()
        {
            RoundOddsToOne();

            switch (_format)
            {
                case StringFormating.FractionalOdds:
                    {
                        int f = FindNominatorFactor();
                        return (_oddsToOne * f).ToString() + "-" + f.ToString();
                    }
                case StringFormating.OneBasedOdds:
                    {
                        return _oddsToOne.ToString();
                    }
                default:
                    {
                        throw new Exception("Invalid Display Mode");
                    }
            }
        }

        public static explicit operator double(Odds op)
        {
            return op.GetOddsToOne();
        }

        public void SetOddsToOne(double oddsToOne)
        {
            _dirty = true;

            _oddsToOne = oddsToOne;
            RoundOddsToOne();
            _parent.Save();
        }


        public bool Dirty
        {
            get
            {
                return _dirty;
            }
            set
            {
                _dirty = value;
            }
        }

        public double GetOddsToOne()
        {
            RoundOddsToOne();
            return _oddsToOne;
        }

        private bool IsDivisionSymbol(char c)
        {
            return (c == '-') || (c == '/');
        }

        private string GetNextToken(string txt, ref int position)
        {
            string token = "";

            --position;

            while (position + 1 < txt.Length)
            {
                ++position;

                char currentChar = txt[position];

                if (IsDivisionSymbol(currentChar))
                {
                    break;
                }
                else
                {
                    token += currentChar;
                }
            }

            ++position;

            if (token.Length <= 0)
            {
                token = "1";
            }

            return token;
        }
    }
}
