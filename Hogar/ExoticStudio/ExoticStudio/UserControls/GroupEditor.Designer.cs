namespace ExoticStudio.UserControls
{
    partial class GroupEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupEditor));
            this.label2 = new System.Windows.Forms.Label();
            this._limitationsCountTextBox = new System.Windows.Forms.TextBox();
            this._numberOfGroupsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._selectGroupComboBox = new System.Windows.Forms.ComboBox();
            this._newLimitationButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._deleteGroupButton = new System.Windows.Forms.Button();
            this._previousGroupButton = new System.Windows.Forms.Button();
            this._nextGroupButton = new System.Windows.Forms.Button();
            this._createNewGroupButton = new System.Windows.Forms.Button();
            this._countCombinationsButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Limitations";
            // 
            // _limitationsCountTextBox
            // 
            this._limitationsCountTextBox.Location = new System.Drawing.Point(301, 12);
            this._limitationsCountTextBox.Name = "_limitationsCountTextBox";
            this._limitationsCountTextBox.ReadOnly = true;
            this._limitationsCountTextBox.Size = new System.Drawing.Size(32, 20);
            this._limitationsCountTextBox.TabIndex = 3;
            // 
            // _numberOfGroupsTextBox
            // 
            this._numberOfGroupsTextBox.Location = new System.Drawing.Point(204, 12);
            this._numberOfGroupsTextBox.Name = "_numberOfGroupsTextBox";
            this._numberOfGroupsTextBox.ReadOnly = true;
            this._numberOfGroupsTextBox.Size = new System.Drawing.Size(31, 20);
            this._numberOfGroupsTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "# Of Groups";
            // 
            // _selectGroupComboBox
            // 
            this._selectGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._selectGroupComboBox.FormattingEnabled = true;
            this._selectGroupComboBox.Location = new System.Drawing.Point(83, 10);
            this._selectGroupComboBox.Name = "_selectGroupComboBox";
            this._selectGroupComboBox.Size = new System.Drawing.Size(45, 21);
            this._selectGroupComboBox.TabIndex = 6;
            this._selectGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.OnGroupIndexChanged);
            // 
            // _newLimitationButton
            // 
            this._newLimitationButton.Location = new System.Drawing.Point(3, 47);
            this._newLimitationButton.Name = "_newLimitationButton";
            this._newLimitationButton.Size = new System.Drawing.Size(199, 23);
            this._newLimitationButton.TabIndex = 7;
            this._newLimitationButton.Text = "Add New Limitation For This Group";
            this._newLimitationButton.UseVisualStyleBackColor = true;
            this._newLimitationButton.Click += new System.EventHandler(this.OnNewLimitation);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Active Group";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._selectGroupComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._limitationsCountTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._numberOfGroupsTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 38);
            this.panel1.TabIndex = 9;
            // 
            // _deleteGroupButton
            // 
            this._deleteGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("_deleteGroupButton.Image")));
            this._deleteGroupButton.Location = new System.Drawing.Point(486, 2);
            this._deleteGroupButton.Name = "_deleteGroupButton";
            this._deleteGroupButton.Size = new System.Drawing.Size(63, 65);
            this._deleteGroupButton.TabIndex = 10;
            this._deleteGroupButton.Text = "Delete  Group";
            this._deleteGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._deleteGroupButton.UseVisualStyleBackColor = true;
            this._deleteGroupButton.Click += new System.EventHandler(this.OnDeleteGroup);
            // 
            // _previousGroupButton
            // 
            this._previousGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("_previousGroupButton.Image")));
            this._previousGroupButton.Location = new System.Drawing.Point(352, 3);
            this._previousGroupButton.Name = "_previousGroupButton";
            this._previousGroupButton.Size = new System.Drawing.Size(63, 65);
            this._previousGroupButton.TabIndex = 11;
            this._previousGroupButton.Text = "Previous Group";
            this._previousGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._previousGroupButton.UseVisualStyleBackColor = true;
            this._previousGroupButton.Click += new System.EventHandler(this.OnMoveToPreviousGroup);
            // 
            // _nextGroupButton
            // 
            this._nextGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("_nextGroupButton.Image")));
            this._nextGroupButton.Location = new System.Drawing.Point(419, 3);
            this._nextGroupButton.Name = "_nextGroupButton";
            this._nextGroupButton.Size = new System.Drawing.Size(63, 65);
            this._nextGroupButton.TabIndex = 12;
            this._nextGroupButton.Text = "Next Group";
            this._nextGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._nextGroupButton.UseVisualStyleBackColor = true;
            this._nextGroupButton.Click += new System.EventHandler(this.OnMoveToNextGroup);
            // 
            // _createNewGroupButton
            // 
            this._createNewGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("_createNewGroupButton.Image")));
            this._createNewGroupButton.Location = new System.Drawing.Point(555, 2);
            this._createNewGroupButton.Name = "_createNewGroupButton";
            this._createNewGroupButton.Size = new System.Drawing.Size(63, 65);
            this._createNewGroupButton.TabIndex = 13;
            this._createNewGroupButton.Text = "Create New Group";
            this._createNewGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._createNewGroupButton.UseVisualStyleBackColor = true;
            this._createNewGroupButton.Click += new System.EventHandler(this.OnCreateNewGroup);
            // 
            // _countCombinationsButton
            // 
            this._countCombinationsButton.Image = ((System.Drawing.Image)(resources.GetObject("_countCombinationsButton.Image")));
            this._countCombinationsButton.Location = new System.Drawing.Point(624, 3);
            this._countCombinationsButton.Name = "_countCombinationsButton";
            this._countCombinationsButton.Size = new System.Drawing.Size(63, 65);
            this._countCombinationsButton.TabIndex = 14;
            this._countCombinationsButton.Text = "Count";
            this._countCombinationsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._countCombinationsButton.UseVisualStyleBackColor = true;
            this._countCombinationsButton.Click += new System.EventHandler(this.OnCountCombinations);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GroupEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._countCombinationsButton);
            this.Controls.Add(this._createNewGroupButton);
            this.Controls.Add(this._nextGroupButton);
            this.Controls.Add(this._previousGroupButton);
            this.Controls.Add(this._deleteGroupButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._newLimitationButton);
            this.Name = "GroupEditor";
            this.Size = new System.Drawing.Size(804, 509);
            this.Load += new System.EventHandler(this.GroupEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _limitationsCountTextBox;
        private System.Windows.Forms.TextBox _numberOfGroupsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _selectGroupComboBox;
        private System.Windows.Forms.Button _newLimitationButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _deleteGroupButton;
        private System.Windows.Forms.Button _previousGroupButton;
        private System.Windows.Forms.Button _nextGroupButton;
        private System.Windows.Forms.Button _createNewGroupButton;
        private System.Windows.Forms.Button _countCombinationsButton;
        private System.Windows.Forms.Timer timer1;
    }
}
