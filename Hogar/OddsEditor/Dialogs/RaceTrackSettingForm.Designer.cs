namespace OddsEditor.Dialogs
{
    partial class RaceTrackSettingForm
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
            this._panelRaceTrackName = new System.Windows.Forms.Panel();
            this._labelRaceTrackName = new System.Windows.Forms.Label();
            this._panelSiblingRaceTracks = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonSelectAll = new System.Windows.Forms.Button();
            this._buttonUnselectAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._buttonClose = new System.Windows.Forms.Button();
            this._panelRaceTrackName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelRaceTrackName
            // 
            this._panelRaceTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panelRaceTrackName.BackColor = System.Drawing.Color.DodgerBlue;
            this._panelRaceTrackName.Controls.Add(this._labelRaceTrackName);
            this._panelRaceTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._panelRaceTrackName.ForeColor = System.Drawing.Color.White;
            this._panelRaceTrackName.Location = new System.Drawing.Point(2, 0);
            this._panelRaceTrackName.Name = "_panelRaceTrackName";
            this._panelRaceTrackName.Size = new System.Drawing.Size(558, 32);
            this._panelRaceTrackName.TabIndex = 0;
            // 
            // _labelRaceTrackName
            // 
            this._labelRaceTrackName.AutoSize = true;
            this._labelRaceTrackName.Location = new System.Drawing.Point(8, 3);
            this._labelRaceTrackName.Name = "_labelRaceTrackName";
            this._labelRaceTrackName.Size = new System.Drawing.Size(66, 24);
            this._labelRaceTrackName.TabIndex = 0;
            this._labelRaceTrackName.Text = "label1";
            this._labelRaceTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _panelSiblingRaceTracks
            // 
            this._panelSiblingRaceTracks.AutoScroll = true;
            this._panelSiblingRaceTracks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelSiblingRaceTracks.Location = new System.Drawing.Point(6, 48);
            this._panelSiblingRaceTracks.Name = "_panelSiblingRaceTracks";
            this._panelSiblingRaceTracks.Size = new System.Drawing.Size(534, 311);
            this._panelSiblingRaceTracks.TabIndex = 1;
            // 
            // _buttonSelectAll
            // 
            this._buttonSelectAll.Location = new System.Drawing.Point(8, 19);
            this._buttonSelectAll.Name = "_buttonSelectAll";
            this._buttonSelectAll.Size = new System.Drawing.Size(75, 23);
            this._buttonSelectAll.TabIndex = 2;
            this._buttonSelectAll.Text = "Select All";
            this._buttonSelectAll.UseVisualStyleBackColor = true;
            this._buttonSelectAll.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // _buttonUnselectAll
            // 
            this._buttonUnselectAll.Location = new System.Drawing.Point(109, 19);
            this._buttonUnselectAll.Name = "_buttonUnselectAll";
            this._buttonUnselectAll.Size = new System.Drawing.Size(75, 23);
            this._buttonUnselectAll.TabIndex = 3;
            this._buttonUnselectAll.Text = "Unselect All";
            this._buttonUnselectAll.UseVisualStyleBackColor = true;
            this._buttonUnselectAll.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._panelSiblingRaceTracks);
            this.groupBox1.Controls.Add(this._buttonUnselectAll);
            this.groupBox1.Controls.Add(this._buttonSelectAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 343);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sibling Tracks";
            // 
            // _buttonClose
            // 
            this._buttonClose.Location = new System.Drawing.Point(477, 416);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(75, 23);
            this._buttonClose.TabIndex = 5;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.OnButtonCloseClicked);
            // 
            // RaceTrackSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(562, 451);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._panelRaceTrackName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RaceTrackSettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RaceTrackSettingForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._panelRaceTrackName.ResumeLayout(false);
            this._panelRaceTrackName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelRaceTrackName;
        private System.Windows.Forms.Label _labelRaceTrackName;
        private System.Windows.Forms.FlowLayoutPanel _panelSiblingRaceTracks;
        private System.Windows.Forms.Button _buttonSelectAll;
        private System.Windows.Forms.Button _buttonUnselectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _buttonClose;
    }
}