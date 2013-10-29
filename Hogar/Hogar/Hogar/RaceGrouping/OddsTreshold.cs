using System;
using System.Collections.Generic;

namespace Hogar.RaceGrouping
{
    internal sealed class OddsTreshold
    {
        private readonly int _from;
        private readonly int _to;


        static List<OddsTreshold> _list = new List<OddsTreshold>();

        static public List<OddsTreshold> List
        {
            get
            {
                if(_list.Count <=0)
                {
                    Load();
                }
                return _list;
            }
        }

        private static void Load()
        {
            _list.Add(new OddsTreshold(3,4));
            _list.Add(new OddsTreshold(4, 5));
            _list.Add(new OddsTreshold(5, 6));
            _list.Add(new OddsTreshold(6, 7));
            _list.Add(new OddsTreshold(7,9));
            _list.Add(new OddsTreshold(9, 11));
            _list.Add(new OddsTreshold(11, 14));
            _list.Add(new OddsTreshold(14, 17));
            _list.Add(new OddsTreshold(17, 20));
            _list.Add(new OddsTreshold(20, 25));
            _list.Add(new OddsTreshold(25, 30));
            _list.Add(new OddsTreshold(30, 1000));
        }

        private OddsTreshold(int from, int to)
        {
            _from = from;
            _to = to;
        }

        public int From
        {
            get
            {
                return _from;
            }
        }

        public int To
        {
            get
            {
                return _to;
            }
        }
        

    }
}