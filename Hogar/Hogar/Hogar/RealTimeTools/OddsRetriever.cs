using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml;
using System.Diagnostics;
using System.Data;

namespace Hogar.RealTimeTools
{
    public class OddsRetriever
    {
        readonly string _trackCode;
        readonly string _trackFullName;
        readonly int _raceNumber;
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        static Random _random = new Random();
        Dictionary<int, string> _odds = new Dictionary<int, string>();

        public delegate void UpdateObserverDelegate();
        public event UpdateObserverDelegate UpdateObserverDelegateEvent;


        private int _errorStatus = 0;
        private string _errorMsg = "";
        private bool _poolWasClosed = false;

        private object _locker = new object();
        private DataTable _exactaPayouts = null;
        private DataTable _doublePayouts = null;


        private bool _stopThread = false;
        private object _stopThreadLocker = new object();

        const int _initialInterval = 1000;
        private const int _regularInterval = 3000;
        

        private bool StopThread
        {
            get
            {
                lock (_stopThreadLocker)
                {
                    return _stopThread;
                }
            }
            set
            {
                lock (_stopThreadLocker)
                {
                    _stopThread = value;
                }
            }
        }


        public class RTOdds
        {
            readonly Odds _odds;
            Odds _oddsFromExactas;
            Odds _oddsFromDouble;

            public RTOdds(Odds odds)
            {
                _odds = odds;
                _oddsFromExactas = null;
            }

            public Odds OddsToWin
            {
                get
                {
                    return _odds;
                }
            }

            public Odds OddsFromDouble
            {
                get
                {
                    return _oddsFromDouble;
                }
                internal set
                {
                    _oddsFromDouble = value;
                }
            }

            public Odds OddsFromExactas
            {
                get
                {
                    return _oddsFromExactas;
                }
                internal set
                {
                    _oddsFromExactas = value;
                }
            }
        }


        Thread _updateThread = null;

        public OddsRetriever(string trackCode, int raceNumber)
        {

            _trackFullName = RaceTracks.GetNameFromTrackCode(trackCode);

            if (trackCode.ToUpper() == "AQU")
            {
                trackCode = "AQD";
            }
            else if (trackCode.ToUpper() == "BEL")
            {
                trackCode = "BED";
            }
            else if (trackCode.ToUpper() == "HOL")
            {
                trackCode = "HOD";
            }
            else if (trackCode.ToUpper() == "PHA")
            {
                trackCode = "PHD";
            }
            else if (trackCode.ToUpper() == "CRC")
            {
                trackCode = "CRM";
            }
            else if (trackCode.ToUpper() == "FG")
            {
                 trackCode = "JGD";
            }
            else if (trackCode.ToUpper() == "TAM")
            {
                trackCode = "TAM";
            }
            else if (trackCode.ToUpper() == "BEU")
            {
                trackCode = "BXM";
            }
            else if (trackCode.ToUpper() == "SA")
            {
                trackCode = "SAD";
            }
            else if (trackCode.ToUpper() == "GP")
            {
                trackCode = "GPM";
            }
            else if (trackCode.ToUpper() == "OP")
            {
                trackCode = "OPM";
            }
            else if (trackCode.ToUpper() == "KEE")
            {
                trackCode = "KED";
            }
            else if (trackCode.ToUpper() == "LSE")
            {
                trackCode = "KED";
            }
            else if (trackCode.ToUpper() == "LS")
            {
                trackCode = "LSE";
            }
            else if (trackCode.ToUpper() == "ATL")
            {
                trackCode = "AYD";
            }
            else if (trackCode.ToUpper() == "CD")
            {
                trackCode = "CHD";
                //trackCode = "B0S";
                
            }
            else if (trackCode.ToUpper() == "PIM")
            {
                trackCode = "PIM";
            } 
            else if (trackCode.ToUpper() == "MTH")
            {
                trackCode = "MTD";
            }
            else if (trackCode.ToUpper() == "ELP")
            {
                trackCode = "ELD";
            }
            else if (trackCode.ToUpper() == "LAD")
            {
                trackCode = "LDM";
            }
            else if (trackCode.ToUpper() == "SAR")
            {
                trackCode = "STD";
            }
            else if (trackCode.ToUpper() == "DMR")
            {
                trackCode = "DMD";
            }
            else if (trackCode.ToUpper() == "DEL")
            {
                trackCode = "DLD";
            }
            else if (trackCode.ToUpper() == "HOO")
            {
                trackCode = "HTN";
            }
            else if (trackCode.ToUpper() == "TP")
            {
                trackCode = "TPD";
            }
            else if (trackCode.ToUpper() == "LRL")
            {
                trackCode = "LRM";
            }
            else if (trackCode.ToUpper() == "PEN")
            {
                trackCode = "PEN";
            }

            else if (trackCode.ToUpper() == "OP")
            {
                trackCode = "OPM";
            }
            else if (trackCode.ToUpper() == "FL")
            {
                trackCode = "FIM";
            }
            else if (trackCode.ToUpper() == "IND")
            {
                trackCode = "IJN";
            }

            

            _trackCode = trackCode;
            _raceNumber = raceNumber;
            _timer.Interval = _initialInterval;
            _timer.Start();
            _timer.Tick += new EventHandler(OnTimerTick);

            _updateThread = new Thread(RetrieveThread);
            _updateThread.Start();
            
        }


        public string TrackName
        {
            get
            {
                return _trackFullName;
            }
        }

        public int RaceNumber
        {
            get
            {
                return _raceNumber;
            }
        }
        

        public int ErrorStatus
        {
            get
            {
                lock (_locker)
                {
                    return _errorStatus;
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                lock (_locker)
                {
                    return _errorMsg;
                }
            }
        }

        public DataTable ExactaPayouts
        {
            get
            {
                lock (_locker)
                {
                    return _exactaPayouts;
                }
            }
        }

        public DataTable DoublePayouts
        {
            get
            {
                lock (_locker)
                {
                    return _doublePayouts;
                }
            }
        }

        public bool PoolWasClosed
        {
            get
            {
                lock (_locker)
                {
                    return _poolWasClosed;
                }
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _timer.Interval = _regularInterval;
            if (null != UpdateObserverDelegateEvent)
            {
                UpdateObserverDelegateEvent();
            }
        }


        public Dictionary<int, RTOdds> RealTimeOdds
        {
            get
            {
                lock (_locker)
                {
                    
                    
                    Dictionary<int, RTOdds> temp = new Dictionary<int, RTOdds>();
                    foreach (KeyValuePair<int, string> pair in _odds)
                    {
                        Odds odds = Odds.Make(pair.Value);
                        temp.Add(pair.Key, new RTOdds(odds));
                    }

                    //Now Calculate the odds from the exactas

                    if (null != _exactaPayouts)
                    {
                        for (int row = 0; row < _exactaPayouts.Rows.Count; ++row)
                        {
                            int horseNumber = row + 1;

                            double amountToWin = 1000.00;
                            double totalBetRequired = 0.0;

                            for (int col = 0; col < _exactaPayouts.Columns.Count; ++col)
                            {
                                if (_exactaPayouts.Rows[row][col] is double)
                                {
                                    double payout = (double)_exactaPayouts.Rows[row][col];
                                    if (payout != 0.0)
                                    {
                                        double bet = (amountToWin * 2.0) / payout;
                                        totalBetRequired += bet;
                                    }
                                }
                            }

                            if (totalBetRequired > 0.0)
                            {
                                double oddsFromExacta = (amountToWin / totalBetRequired) - 1.0;
                                Odds odds1 = Odds.Make(string.Format("{0}",oddsFromExacta));

                                if (temp.ContainsKey(horseNumber))
                                {
                                    RTOdds rto = temp[horseNumber];
                                    rto.OddsFromExactas = odds1;
                                }
                            }
                        }
                    }

                    //Now Calculate the odds from the doubles

                    if (null != _doublePayouts)
                    {
                        for (int row = 0; row < _doublePayouts.Rows.Count; ++row)
                        {
                            int horseNumber = row + 1;

                            double amountToWin = 1000.00;
                            double totalBetRequired = 0.0;

                            for (int col = 0; col < _doublePayouts.Columns.Count; ++col)
                            {
                                if (_doublePayouts.Rows[row][col] is double)
                                {
                                    double payout = (double)_doublePayouts.Rows[row][col];
                                    if (payout != 0.0)
                                    {
                                        double bet = (amountToWin * 2.0) / payout;
                                        totalBetRequired += bet;
                                    }
                                }
                            }

                            if (totalBetRequired > 0.0)
                            {
                                double oddsFromDouble = (amountToWin / totalBetRequired) - 1.0;
                                Odds odds1 = Odds.Make(string.Format("{0}", oddsFromDouble));

                                if (temp.ContainsKey(horseNumber))
                                {
                                    RTOdds rto = temp[horseNumber];
                                    rto.OddsFromDouble = odds1;
                                }
                            }
                        }
                    }

                    return temp;
                }
            }
        }
        private string URL
        {
            get
            {
                // FOR TESTING ONLY
                //return @"C:\Users\john\Desktop\exacta_test.xml";
                //http://www.nyra.com/totedata/JCL AQD cycle race 1.xml?rand=0.1787
                
                return string.Format(@"http://www.nyra.com/totedata/JCL {0} cycle race {1}.xml?rand={2:0.0000}", _trackCode, _raceNumber, _random.NextDouble());
            }
        }

        private string OddsAsXMLDocument
        {
            get
            {
                WebRequest r = WebRequest.Create(URL);
                WebResponse resp = r.GetResponse();
                string s = @"<?xml version='1.0' encoding='UTF-8' ?>" + Environment.NewLine;
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    s += sr.ReadToEnd() + Environment.NewLine;
                }
                return s;
            }
        }



        private DataTable MakeNewTable(int maxRunners)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < maxRunners; ++i)
            {
                dt.Columns.Add((i + 1).ToString(), typeof(double));
            }

            for (int i = 0; i < maxRunners; ++i)
            {
                object[] emptyRow = new object[maxRunners];
                for (int j = 0; j < maxRunners; ++j)
                {
                    emptyRow[j] = 0.0;
                }

                dt.Rows.Add(emptyRow);
            }

            return dt;
        }

        public void StopIt()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            StopThread = true;
        }

        private void RetrieveThread()
        {
            int consequtiveFailures = 0;

            StopThread = false;

            for (; StopThread == false; )
            {

                try
                {
                    _errorStatus = 0;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(new StringReader(OddsAsXMLDocument));


                    lock (_locker)
                    {
                        // Retrieve Odds
                        _odds.Clear();
                        foreach (XmlNode node in doc.SelectNodes("/Cycle/Odds/Runner"))
                        {
                            string n = node.Attributes["Number"].Value;
                            string odds = node.Attributes["Odd"].Value;
                            _odds.Add(Convert.ToInt32(n), odds);
                        }

                        int numberOfHorsesInThisRace = 0;
                        // Retrieve Exacta payouts
                        DataTable dt = null;
                        try
                        {
                            foreach (XmlNode node in doc.SelectNodes("/Cycle/Probable[@Pool='EX']/Runner"))
                            {
                                int number1 = Convert.ToInt32(node.Attributes["Number"].Value);
                                
                                int maxRunners = Convert.ToInt32(node.Attributes["MaxRunner"].Value);
                                numberOfHorsesInThisRace = maxRunners;

                                if (null == dt)
                                {
                                    dt = MakeNewTable(maxRunners);
                                }
                                

                                foreach (XmlNode node2 in node.SelectNodes("With"))
                                {
                                    int number2 = Convert.ToInt32(node2.Attributes["Number"].Value);
                                    
                                    double price = 0.0;
                                    if (null != node2.Attributes["Price"])
                                    {
                                        try
                                        {

                                            string temp = node2.Attributes["Price"].Value;
                                            if (temp == "SCR")
                                            {
                                                price = 0.0;
                                            }
                                            else
                                            {
                                                price = Convert.ToDouble(node2.Attributes["Price"].Value);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }

                                    dt.Rows[number1 - 1][number2 - 1] = price;
                                }
                            }
                        }
                        catch
                        {
                        }

                        _exactaPayouts = dt;
   

                        // Now Retrieve Double Payouts
                        dt = null;
                        try
                        {
                            foreach (XmlNode node in doc.SelectNodes("/Cycle/Probable[@Pool='DBL']/Runner"))
                            {
                                int number1 = Convert.ToInt32(node.Attributes["Number"].Value);

                                int maxRunners = Convert.ToInt32(node.Attributes["MaxRunner"].Value);

                                if (null == dt)
                                {
                                    dt = MakeNewTable(Math.Max(numberOfHorsesInThisRace, maxRunners));
                                }


                                foreach (XmlNode node2 in node.SelectNodes("With"))
                                {
                                    int number2 = Convert.ToInt32(node2.Attributes["Number"].Value);

                                    double price = 0.0;
                                    if (null != node2.Attributes["Price"])
                                    {
                                        try
                                        {

                                            string temp = node2.Attributes["Price"].Value;
                                            if (temp == "SCR")
                                            {
                                                price = 0.0;
                                            }
                                            else
                                            {
                                                price = Convert.ToDouble(node2.Attributes["Price"].Value);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }

                                    dt.Rows[number1 - 1][number2 - 1] = price;
                                }
                            }
                        }
                        catch
                        {
                        }

                        _doublePayouts = dt;

                        // Now let's see if the WIN pool was closed
                        // TODO JAN 20 2009 NYRA code has changed removing the status attribute adding the Final
                        foreach (XmlNode node in doc.SelectNodes("/Cycle/Pools/Pool"))
                        {
                            string poolType = node.Attributes["Pool"].Value;

                            if (null != node.Attributes["Status"])
                            {
                                string status = node.Attributes["Status"].Value;

                                if (poolType == "WIN")
                                {
                                    if (status == "Closed")
                                    {
                                        _poolWasClosed = true;
                                    }
                                }
                            }
                        }
                    }
                    
                    consequtiveFailures = 0;
                }
                catch (Exception ex)
                {
                    if (++consequtiveFailures >=4)
                    {
                        lock (_locker)
                        {
                            _errorStatus = -1;
                            _errorMsg = ex.Message;
                        }

                        StopThread = true;
                       
                    }
                }

                Thread.Sleep(32000);
            }
            
        }
    }
}
