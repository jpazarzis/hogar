using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.WinnersForDay
{
    public partial class XRayCtrl : UserControl
    {
        private bool _isLoading = false;
        private List<WinnerInfo> _winners = new List<WinnerInfo>();
        private string _horseName;
        private string _trackCode;
        private DateTime _date;
        private RaceInfo _currentRaceInfo;

        public XRayCtrl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _timeComparisonCtrl.Clear();
            _currentRaceInfo = null;
            _labelHorseName.Text = "";
        }

        public void Bind(DateTime date, string trackCode, string horseName, int raceNumber)
        {
            _horseName = horseName;
            _trackCode = trackCode;
            _date = date;
            Clear();
            if (!DateOfRace.RaceExistsInDb(trackCode, date, raceNumber))
            {
                return;
            }
           
            var ts = new TimeSpan(4, 0, 0, 0);
            var dates = DateOfRace.GetDates(trackCode);
            DateTime fromDate = date - ts;
            DateTime toDate = date + ts;
            LoadCurrentRaceInfo(date, trackCode, raceNumber);
            
            _isLoading = true;
            _twoWayTracker1.Dates = dates;
            _twoWayTracker1.FromDate = fromDate;
            _twoWayTracker1.ToDate = toDate;
            _isLoading = false;
            LoadWinners();
            LoadData();
        }

        private void LoadCurrentRaceInfo(DateTime date, string trackCode, int raceNumber)
        {
            _currentRaceInfo = null;
            string sql = string.Format(
                @"SELECT RACE_ID, DISTANCE, ABOUT_DISTANCE_FLAG, SURFACE, TRACK_CODE, TRACK_CONDITION FROM RACE_DESCRIPTION
                WHERE DATE_OF_THE_RACE = '{0}' AND TRACK_CODE = '{1}' AND RACE_NUMBER = {2}", Utilities.GetDateInYYYYMMDD(date), trackCode, raceNumber);

            using (var dbr = new DbReader())
            {
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        _currentRaceInfo = new RaceInfo();
                        _currentRaceInfo.AboutFlag = dbr.GetValue<string>("ABOUT_DISTANCE_FLAG");
                        _currentRaceInfo.Distance = dbr.GetValue<double>("DISTANCE");
                        _currentRaceInfo.RaceId = dbr.GetValue<int>("RACE_ID");
                        _currentRaceInfo.Surface = dbr.GetValue<string>("SURFACE");
                        _currentRaceInfo.TrackCondition = dbr.GetValue<string>("TRACK_CONDITION");
                        _currentRaceInfo.TrackCode = trackCode;

                    }
                }
            }

        }

        private void OnDateChanged(object sender, EventArgs e)
        {
            if(_isLoading)
            {
                return;
            }

            LoadData();

        }

        private void LoadWinners()
        {
            _winners = null;

            if (null != _currentRaceInfo)
            {
                _winners = WinnerInfo.LoadFromDb(_currentRaceInfo.TrackCode,
                                                 _currentRaceInfo.Distance,
                                                 _currentRaceInfo.Surface,
                                                 _currentRaceInfo.AboutFlag);
            }
        }

        private void LoadData()
        {
            try
            {
                _timeComparisonCtrl.Clear();
                if(null == _currentRaceInfo) return;

                DateTime fd = _twoWayTracker1.FromDate;
                DateTime td = _twoWayTracker1.ToDate;
                IEnumerable<WinnerInfo> wilist = _winners.FindAll(w => w.Date >= fd && w.Date <= td);
                WinnerInfo raceToPlot = _winners.Find(w => w.RaceId == _currentRaceInfo.RaceId);
                if (null != raceToPlot)
                {
                    _timeComparisonCtrl.Bind(wilist.Cast<IFractionalTimes>().ToList(), raceToPlot, _currentRaceInfo.RaceId, _horseName);
                }

                if (null != _currentRaceInfo)
                {
                    string distance = _currentRaceInfo.Surface + " " + Utilities.ConvertYardsToMilesOrFurlongsAbreviation((int) _currentRaceInfo.Distance) + " " + _currentRaceInfo.TrackCondition;
                    _labelHorseName.Text = string.Format("{0},  {1} , {2} {3}", _trackCode.ToUpper(), Utilities.GetDateInFullDescription(Utilities.GetDateInYYYYMMDD(_date)), _horseName, distance);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void XRayCtrl_Load(object sender, EventArgs e)
        {

        }
    }
}
