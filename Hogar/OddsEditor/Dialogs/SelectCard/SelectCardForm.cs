using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.BrisPastPerformances;

namespace OddsEditor.Dialogs.SelectCard
{
    public partial class SelectCardForm : Form
    {
        private string _selectedFilename;
        public SelectCardForm()
        {
            InitializeComponent();
        }


        public string SelectedFilename
        {
            get
            {
                return _selectedFilename;
            }
        }
    
        private void SelectCardForm_Load(object sender, EventArgs e)
        {
            _tree.Nodes.Clear();

            List<string> filenames = DailyCard.ExistingFiles;

            string txt = "";
            int count = 0;
            foreach (var filename in filenames)
            {
                ++count;

                AddNode(new OddsFilename(filename));

               
            }

            _tbTotalNumberOfCards.Text = count.ToString();

            RemoveEmptyMonths();
        }

        Dictionary<string, TreeNode> _trackTreeNode = new Dictionary<string, TreeNode>();

        void RemoveEmptyMonths()
        {
            foreach (TreeNode trackNode in _tree.Nodes)
            {
                foreach (TreeNode yearNode in trackNode.Nodes)
                {
                    for (int i = 0; i < yearNode.Nodes.Count; ++i)
                    {
                        if (null != yearNode.Nodes[i].Nodes && yearNode.Nodes[i].Nodes.Count <= 0)
                        {
                            yearNode.Nodes.RemoveAt(i);
                            --i;
                        }
                    }    
                }


                
                
            }
        }

        void AddFilenameToTree(TreeNode parent, OddsFilename ofn)
        {

            var monthNode = GetNodeForTheMonth(parent, ofn);

            if(null == monthNode)
                return;

            TreeNode newNode = monthNode.Nodes.Add(Utilities.GetFullDateString(ofn.DateAsYYYYMMDD));
            newNode.Tag = ofn;

            
        }

        private TreeNode GetNodeForTheMonth(TreeNode treeNode, OddsFilename ofn)
        {
            string month = ofn.MonthFullName;
            foreach (TreeNode n in treeNode.Nodes)
            {
                if(month == n.Text)
                {
                    return n;
                }
            }
            return null;

        }

        private void AddNode(OddsFilename ofn)
        {
            TreeNode parentNode = null;

            if (_trackTreeNode.ContainsKey(ofn.TrackCode))
            {
                parentNode = _trackTreeNode[ofn.TrackCode];
            }
            else
            {
                parentNode = _tree.Nodes.Add(RaceTracks.GetNameFromBrisAbrv(ofn.TrackCode));
                _trackTreeNode.Add(ofn.TrackCode, parentNode);
                
            }

            foreach (TreeNode n in parentNode.Nodes)
            {
                if (null != n.Tag &&  ((int)n.Tag) == ofn.Year)
                {
                    AddFilenameToTree(n, ofn);
                    return;
                }
            }

            TreeNode yearNode = parentNode.Nodes.Add(ofn.Year.ToString());
            yearNode.Tag = ofn.Year;
            AddAllMonthsToNode(yearNode);
            AddFilenameToTree(yearNode, ofn);

            
        }

        private void AddAllMonthsToNode(TreeNode parentNode)
        {
            Utilities.MonthNames.ForEach(name=>parentNode.Nodes.Add(name));
        }

        OddsFilename GetSelectedOddsFilename()
        {
            TreeNode n = _tree.SelectedNode;

            if (n == null)
            {
                return null;
            }
            var ofn = n.Tag as OddsFilename;
            return ofn ?? null;
        }

        private void _tree_DoubleClick(object sender, EventArgs e)
        {
            var ofn = GetSelectedOddsFilename();
            if (null == ofn)
            {
                return;
           
            }

            _selectedFilename = ofn.FullPath;

            DialogResult = DialogResult.OK;
        }

        void UpdateRacesOfTheDate()
        {
            _tbSelectedTrack.Text = "";
            _tbSelectedDate.Text = "";
            var ofn = GetSelectedOddsFilename();
            if (null == ofn)
            {
                return;
            }
            _tbSelectedTrack.Text = RaceTracks.GetNameFromBrisAbrv(ofn.TrackCode);
            _tbSelectedDate.Text = Utilities.GetFullDateString(ofn.DateAsYYYYMMDD);

            var raceInfoCollection = RaceInfoCollection.Make(ofn.TrackCode, ofn.DateAsYYYYMMDD);
            raceInfoCollection.Bind(_tree.SelectedNode);

            _tree.SelectedNode.Expand();


        }

        
        private void _tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateRacesOfTheDate();
        }

    }
}
