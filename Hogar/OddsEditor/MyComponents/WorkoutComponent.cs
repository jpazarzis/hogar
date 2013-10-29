using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;

namespace OddsEditor.MyComponents
{
    public partial class WorkoutComponent : UserControl
    {
        readonly Workout _workout;
        readonly Workout _previousWorkout;

        public WorkoutComponent(Workout workout, Workout previousWorkout)
        {
            _workout = workout;
            _previousWorkout = previousWorkout;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _labelDistance.Text = _workout.Distance;
            _labelDate.Text = _workout.DateAsString;
            _labelRaceTrack.Text = _workout.RaceTrack;
            _labelTrackCondition.Text = _workout.TrackCondition;
            _labelTime.Text = _workout.Time;
            _labelRank.Text = _workout.Rank;

            _labelIsBullet.Text = _workout.IsBullet ? "*" : " ";

            if (_workout.IsBullet)
            {
                this.BackColor = Color.LightGreen;
            }

            if(null != _previousWorkout)
            {
                TimeSpan ts = _workout.Date - _previousWorkout.Date;
                if (ts.Days >= 31)
                {
                    _labelDate.BackColor = Color.Red;
                }
                else if (ts.Days >= 13)
                {
                    _labelDate.BackColor = Color.LightSkyBlue;
                }
            }
        }
    }
}
