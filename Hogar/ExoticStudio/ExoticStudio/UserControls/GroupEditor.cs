using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExoticStudio.UserControls
{
    public partial class GroupEditor : UserControl
    {
        FullSystem _parent = null;


        ArrayList _raceInput = new ArrayList();

        bool _updatingGroupComboBox = false;


        int _groupIndex = -1;

        public GroupEditor()
        {
            InitializeComponent();

            UpdateButtons();
        }

        public void Clear()
        {
            _parent = null;

            _groupIndex = -1;
            UpdateButtons();

        }

        public int SelectedGroupIndex
        {
            get
            {
                return _groupIndex;
            }
        }

        public void BindFullSystem(FullSystem fs, int groupIndex)
        {
            _parent = fs;
            _groupIndex = groupIndex;

            UpdateScreen(groupIndex);

            UpdateGroupComboBox();
            UpdateButtons();
            
        }

        private void UpdateButtons()
        {
            _newLimitationButton.Enabled = (_groupIndex >= 0 && _parent != null);

            _selectGroupComboBox.Enabled = (_groupIndex >= 0 && _parent != null);

            _deleteGroupButton.Enabled = (_groupIndex >= 0 && _parent != null && _parent.NumberOfGroups >= 2);

            _nextGroupButton.Enabled = _groupIndex >= 0 && (_parent != null) &&(_groupIndex + 1 < _parent.NumberOfGroups);

            _previousGroupButton.Enabled = _groupIndex >= 1 ;

            _countCombinationsButton.Enabled = _parent != null && _parent.NeedsToBeCounted;

            _createNewGroupButton.Enabled = _parent != null;
        }
        

        private void GroupEditor_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        void UpdateGroupComboBox()
        {

            _updatingGroupComboBox = true;
            _selectGroupComboBox.Items.Clear();

            if (null == _parent)
            {
                _updatingGroupComboBox = false;
                return;

            }

            int selectedIndex = 0;
            for (int i = 0 ; i < _parent.NumberOfGroups; ++i)
            {
               int index = _selectGroupComboBox.Items.Add((i + 1).ToString());

               if (i == _groupIndex)
               {
                   selectedIndex = index;
               }
            }

            _selectGroupComboBox.SelectedIndex = selectedIndex;

            _updatingGroupComboBox = false;
        }

        private void OnGroupIndexChanged(object sender, EventArgs e)
        {
            if (true == _updatingGroupComboBox)
            {
                return;
            }

            int index = _selectGroupComboBox.SelectedIndex;
            string strg = _selectGroupComboBox.Items[index].ToString();
            int groupIndex = Convert.ToInt32(_selectGroupComboBox.Items[index].ToString()) - 1;
            BindFullSystem(_parent, groupIndex);

        }

        void removeExisting()
        {
            for (int i = 0; i < _raceInput.Count; ++i)
            {
                RaceInput ds = (RaceInput)_raceInput[i];
                this.Controls.Remove(ds);
            }

            _raceInput.Clear();

        }


        public void UpdateScreen(int limitationIndex)
        {
            removeExisting();

            if (null == _parent)
            {
                _numberOfGroupsTextBox.Text = "";
                _limitationsCountTextBox.Text = "";

                return;
            }


            _numberOfGroupsTextBox.Text = _parent.NumberOfGroups.ToString();

            _limitationsCountTextBox.Text = _parent.GetGroup(_groupIndex).Count.ToString();

            if (limitationIndex < 0)
            {
                return;
            }

            LimitationGroup lg = _parent.GetGroup(_groupIndex);

            int y = 24, dy = 320;

            this.SuspendLayout();

            for (int i = 0; i < lg.Count; ++i)
            {
                RaceInput ri = new RaceInput();

                ri.LimitationIndex = i;
                ri.GroupIndex = _groupIndex;
                ri.Location = new System.Drawing.Point(y, 65);
                ri.Size = new System.Drawing.Size(300, 451);
                _raceInput.Add(ri);
                ri.BindLimitation(lg.Get(i));
                this.Controls.Add(ri);
                y += dy;
            }

            this.ResumeLayout(false);
            this.Refresh();
            this.AdjustFormScrollbars(true);



        }

        private void OnNewLimitation(object sender, EventArgs e)
        {
            int index = _parent.GetGroup(this.SelectedGroupIndex).AddLimitation();

           this.UpdateScreen(index);
        }

        private void OnDeleteGroup(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("You are sure that you want to delete this Group?", "Delete Current Group", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Program.GetMainForm().DeleteGroup(_groupIndex);
            }

        }

        private void OnMoveToPreviousGroup(object sender, EventArgs e)
        {
            Debug.Assert( (null != _parent) && (_groupIndex -1 >= 0) && (_groupIndex -1 < _parent.NumberOfGroups));
            BindFullSystem(_parent, _groupIndex -1);
        }

        private void OnMoveToNextGroup(object sender, EventArgs e)
        {
            Debug.Assert( (null != _parent) && (_groupIndex +1 >= 0) && (_groupIndex +1 < _parent.NumberOfGroups));
            BindFullSystem(_parent, _groupIndex + 1);
        }

        private void OnCreateNewGroup(object sender, EventArgs e)
        {
            Program.GetMainForm().OnAddGroup(null, null);
        }

        private void OnCountCombinations(object sender, EventArgs e)
        {
            Program.GetMainForm().OnCount(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _countCombinationsButton.Enabled = _parent != null && _parent.NeedsToBeCounted;
        }


        
    }
}
