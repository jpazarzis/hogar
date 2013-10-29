namespace WillardsStudio
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._comboBoxTrackCode = new System.Windows.Forms.ComboBox();
            this._treeViewAvailableRaces = new System.Windows.Forms.TreeView();
            this._cynthiaParsCtrl = new WillardsStudio.CynthiaParsCtrl();
            this._raceInfoCtrl = new WillardsStudio.RaceInfoCtrl();
            this._buttonSaveAllAvailableDays = new System.Windows.Forms.Button();
            this._txtboxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Track ";
            // 
            // _comboBoxTrackCode
            // 
            this._comboBoxTrackCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comboBoxTrackCode.FormattingEnabled = true;
            this._comboBoxTrackCode.Location = new System.Drawing.Point(54, 57);
            this._comboBoxTrackCode.Name = "_comboBoxTrackCode";
            this._comboBoxTrackCode.Size = new System.Drawing.Size(155, 28);
            this._comboBoxTrackCode.TabIndex = 1;
            this._comboBoxTrackCode.SelectionChangeCommitted += new System.EventHandler(this.OnSelectionChangeCommitted);
            // 
            // _treeViewAvailableRaces
            // 
            this._treeViewAvailableRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._treeViewAvailableRaces.Location = new System.Drawing.Point(12, 91);
            this._treeViewAvailableRaces.Name = "_treeViewAvailableRaces";
            this._treeViewAvailableRaces.Size = new System.Drawing.Size(236, 315);
            this._treeViewAvailableRaces.TabIndex = 2;
            this._treeViewAvailableRaces.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnNodeMouseDoubleClick);
            // 
            // _cynthiaParsCtrl
            // 
            this._cynthiaParsCtrl.Location = new System.Drawing.Point(329, 127);
            this._cynthiaParsCtrl.Name = "_cynthiaParsCtrl";
            this._cynthiaParsCtrl.Size = new System.Drawing.Size(939, 711);
            this._cynthiaParsCtrl.TabIndex = 4;
            this._cynthiaParsCtrl.Load += new System.EventHandler(this._cynthiaParsCtrl_Load);
            // 
            // _raceInfoCtrl
            // 
            this._raceInfoCtrl.Location = new System.Drawing.Point(372, 18);
            this._raceInfoCtrl.Name = "_raceInfoCtrl";
            this._raceInfoCtrl.Size = new System.Drawing.Size(644, 103);
            this._raceInfoCtrl.TabIndex = 3;
            // 
            // _buttonSaveAllAvailableDays
            // 
            this._buttonSaveAllAvailableDays.Location = new System.Drawing.Point(40, 12);
            this._buttonSaveAllAvailableDays.Name = "_buttonSaveAllAvailableDays";
            this._buttonSaveAllAvailableDays.Size = new System.Drawing.Size(118, 29);
            this._buttonSaveAllAvailableDays.TabIndex = 5;
            this._buttonSaveAllAvailableDays.Text = "Save All";
            this._buttonSaveAllAvailableDays.UseVisualStyleBackColor = true;
            this._buttonSaveAllAvailableDays.Click += new System.EventHandler(this.OnSaveAll);
            // 
            // _txtboxOutput
            // 
            this._txtboxOutput.Location = new System.Drawing.Point(30, 453);
            this._txtboxOutput.Multiline = true;
            this._txtboxOutput.Name = "_txtboxOutput";
            this._txtboxOutput.ReadOnly = true;
            this._txtboxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtboxOutput.Size = new System.Drawing.Size(266, 308);
            this._txtboxOutput.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 850);
            this.Controls.Add(this._txtboxOutput);
            this.Controls.Add(this._buttonSaveAllAvailableDays);
            this.Controls.Add(this._cynthiaParsCtrl);
            this.Controls.Add(this._raceInfoCtrl);
            this.Controls.Add(this._treeViewAvailableRaces);
            this.Controls.Add(this._comboBoxTrackCode);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnIntialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _comboBoxTrackCode;
        private System.Windows.Forms.TreeView _treeViewAvailableRaces;
        private RaceInfoCtrl _raceInfoCtrl;
        private CynthiaParsCtrl _cynthiaParsCtrl;
        private System.Windows.Forms.Button _buttonSaveAllAvailableDays;
        private System.Windows.Forms.TextBox _txtboxOutput;
    }
}

