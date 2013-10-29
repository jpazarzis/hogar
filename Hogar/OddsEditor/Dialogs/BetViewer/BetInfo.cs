using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OddsEditor.Dialogs.BetViewer
{
    public enum BetType
    {
        Win, Exacta
    }

    public class BetInfo
    {
        private  BetType BetType { get; set; }
        private int Horse1 { get; set; }
        private int Horse2 { get; set; }
        private double Amount { get; set; }
        private double ExpectedPayout { get; set; }
    }
}
