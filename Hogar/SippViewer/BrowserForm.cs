using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Sipp;
using System.Net;


namespace SippViewer
{
    public partial class BrowserForm : Form
    {
        private readonly string _trackCode;
        private readonly DateTime _date;
        private readonly int _raceNumber;
        private readonly string _url = "";
        static readonly Random _random = new Random();
        private readonly string _horseName= "";


        public BrowserForm(string horseName)
        {
            _horseName = horseName.Replace("`","'");
            InitializeComponent();
        }



        

        public BrowserForm(string trackCode, DateTime date, int raceNumber)
        {
            _trackCode = trackCode.ToUpper().Trim();

            if(_trackCode.Length == 2)
            {
                _trackCode += "9";
            }


            _date = date;
            _raceNumber = raceNumber;
            InitializeComponent();
        }

        string Url
        {
            get { return string.Format(@"http://www.racereplays.com/nyraframe/enyra/replay_embeded_rcn.php?raceid=T{0}{1:00}{2:00}{3:00}A{4:00}pf&t={5}", _trackCode, _date.Month, _date.Day, _date.Year - 2000, _raceNumber, (int)(_random.NextDouble() * 100000000)); }
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            if (_horseName.Length > 0)
            {
                var values = HttpUtility.ParseQueryString(string.Empty);
                values["g"] = "5";
                values["h"] = _horseName.ToLower();
                values["inbred"] = "Stanard";
                values["query_type"] = "check";
                values["search_bar"] = "horse";
                values["wsid"] = "1317484421";
                values["x2"] = "n";

                var dataToPost = Encoding.UTF8.GetBytes(values.ToString());
                var url = "http://www.pedigreequery.com/";
                
                var contentType = "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine;
                _browser.Navigate(url, null, dataToPost, contentType); 
            }
            else if (_url.Length > 0)
            {
                _browser.Navigate(_url);
            }
            else
            {
                this.Width = 540;
                this.Height = 430;
                Text = string.Format("{0} Race Number: {1} Date: {2}", _trackCode.ToUpper(), _raceNumber, _date.ToString(@"MM/dd/yyyy"));
                _browser.Navigate(Url);
            }
           
        }
    }
}
