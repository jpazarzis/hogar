using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SippViewer
{
    public partial class SelectCardForm : Form
    {
        private  readonly List<string> _filenames = new List<string>();


        void LoadAvailableFiles()
        {
            _filenames.Clear();
            var doc = new XmlDocument();
            doc.Load(@"http://kasosoft.com/SippFiles/Handler1.ashx");
            foreach (XmlNode node in doc.SelectNodes("/available-cards/card"))
            {
                _filenames.Add(node.Attributes["filename"].Value);
            }
        }
        public SelectCardForm()
        {
            

            InitializeComponent();
        }

        

        private void SelectCardForm_Load(object sender, EventArgs e)
        {
            _listboxFilenames.Items.Clear();
            
            var doc = new XmlDocument();
            doc.Load(@"http://kasosoft.com/SippFiles/Handler1.ashx");
            foreach (XmlNode node in doc.SelectNodes("/available-cards/card"))
            {
                string xmlFilename = node.Attributes["filename"].Value;
                _listboxFilenames.Items.Add(xmlFilename);
            }
        }

        public string SelectedFilename
        {
            get
            {
                return _listboxFilenames.SelectedItem as string;
            }
        }

        private void _listboxFilenames_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
