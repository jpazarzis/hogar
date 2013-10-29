using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Hogar.WebBrowser
{
    public partial class WebBrowserForm : Form
    {
        private XmlDocument _doc;
        public WebBrowserForm(XmlDocument doc)
        {
            _doc = doc;
            InitializeComponent();
        }

        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            if(null != _doc)
            {


                _browser.Navigate("about:blank");

                if (_browser.Document != null)
                {

                    _browser.Document.Write(string.Empty);

                }


                string s = _doc.OuterXml;
               // _browser.DocumentText = _doc.OuterXml;
                _browser.DocumentText = "test";
                
            }
                
            
        }
    }
}
