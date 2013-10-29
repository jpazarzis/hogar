using System;
using System.Collections.Generic;
using System.Linq;

namespace OddsEditor.Dialogs.PaceFigures
{

    public class Checkable
    {
        public bool Checked { set; get; }
    }

    public class FilterSelection<T> : Checkable
    {
        public T Value { set; get; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class PaceFigureFilter
    {
        private readonly PaceFigureCollection _pfc;

        readonly List<FilterSelection<string>> _classification = new List<FilterSelection<string>>();
        readonly List<FilterSelection<string>> _trackCondition = new List<FilterSelection<string>>();

        public PaceFigureFilter(PaceFigureCollection pfc)
        {
            _pfc = pfc;

            Initialize();
        }

        public List<FilterSelection<string>> ClassificationFliter
        {
            get
            {
                return _classification;
            }
        }

        public List<FilterSelection<string>> TrackConditionFliter
        {
            get
            {
                return _trackCondition;
            }
        }


        private void Initialize()
        {
            _classification.Clear();
            _trackCondition.Clear();

            foreach (var pf in _pfc)
            {
                if(null == _classification.Find(item=>item.Value == pf.RaceClassification))
                {
                    _classification.Add(new FilterSelection<string>(){Checked = true, Value = pf.RaceClassification});
                }

                if (null == _trackCondition.Find(item => item.Value == pf.TrackCondition))
                {
                    _trackCondition.Add(new FilterSelection<string>() { Checked = true, Value = pf.TrackCondition });
                }
    
            }
        }


    }
}