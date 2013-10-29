namespace SippViewer
{
    partial class SippCardViewerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SippCardViewerForm));
            this._flowLayoutPanelRaceSelector = new System.Windows.Forms.FlowLayoutPanel();
            this._saveUserSettingsTimer = new System.Windows.Forms.Timer(this.components);
            this._linkLabelHandicappingNotes = new System.Windows.Forms.LinkLabel();
            this._linkLabelReadReleaseNotes = new System.Windows.Forms.LinkLabel();
            this._cbAvailableCards = new System.Windows.Forms.ComboBox();
            this._raceViewerControl = new SippViewer.RaceViewerControl();
            this.SuspendLayout();
            // 
            // _flowLayoutPanelRaceSelector
            // 
            this._flowLayoutPanelRaceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._flowLayoutPanelRaceSelector.BackColor = System.Drawing.Color.Turquoise;
            this._flowLayoutPanelRaceSelector.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanelRaceSelector.Location = new System.Drawing.Point(282, 12);
            this._flowLayoutPanelRaceSelector.Name = "_flowLayoutPanelRaceSelector";
            this._flowLayoutPanelRaceSelector.Size = new System.Drawing.Size(678, 51);
            this._flowLayoutPanelRaceSelector.TabIndex = 3;
            // 
            // _saveUserSettingsTimer
            // 
            this._saveUserSettingsTimer.Interval = 3000;
            this._saveUserSettingsTimer.Tick += new System.EventHandler(this._saveUserSettingsTimer_Tick);
            // 
            // _linkLabelHandicappingNotes
            // 
            this._linkLabelHandicappingNotes.AutoSize = true;
            this._linkLabelHandicappingNotes.Location = new System.Drawing.Point(1253, 9);
            this._linkLabelHandicappingNotes.Name = "_linkLabelHandicappingNotes";
            this._linkLabelHandicappingNotes.Size = new System.Drawing.Size(104, 13);
            this._linkLabelHandicappingNotes.TabIndex = 10;
            this._linkLabelHandicappingNotes.TabStop = true;
            this._linkLabelHandicappingNotes.Text = "Handicapping Notes";
            this._linkLabelHandicappingNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelHandicappingNotes_LinkClicked);
            // 
            // _linkLabelReadReleaseNotes
            // 
            this._linkLabelReadReleaseNotes.AutoSize = true;
            this._linkLabelReadReleaseNotes.Location = new System.Drawing.Point(1170, 9);
            this._linkLabelReadReleaseNotes.Name = "_linkLabelReadReleaseNotes";
            this._linkLabelReadReleaseNotes.Size = new System.Drawing.Size(77, 13);
            this._linkLabelReadReleaseNotes.TabIndex = 9;
            this._linkLabelReadReleaseNotes.TabStop = true;
            this._linkLabelReadReleaseNotes.Text = "Release Notes";
            this._linkLabelReadReleaseNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelReadReleaseNotes_LinkClicked);
            // 
            // _cbAvailableCards
            // 
            this._cbAvailableCards.BackColor = System.Drawing.Color.White;
            this._cbAvailableCards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbAvailableCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbAvailableCards.ForeColor = System.Drawing.Color.Black;
            this._cbAvailableCards.FormattingEnabled = true;
            this._cbAvailableCards.Location = new System.Drawing.Point(12, 12);
            this._cbAvailableCards.Name = "_cbAvailableCards";
            this._cbAvailableCards.Size = new System.Drawing.Size(249, 28);
            this._cbAvailableCards.TabIndex = 11;
            this._cbAvailableCards.SelectedIndexChanged += new System.EventHandler(this._cbAvailableCards_SelectedIndexChanged);
            // 
            // _raceViewerControl
            // 
            this._raceViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._raceViewerControl.AutoScroll = true;
            this._raceViewerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._raceViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._raceViewerControl.Location = new System.Drawing.Point(12, 69);
            this._raceViewerControl.Name = "_raceViewerControl";
            this._raceViewerControl.Size = new System.Drawing.Size(1345, 854);
            this._raceViewerControl.TabIndex = 4;
            // 
            // SippCardViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1381, 935);
            this.Controls.Add(this._cbAvailableCards);
            this.Controls.Add(this._flowLayoutPanelRaceSelector);
            this.Controls.Add(this._linkLabelHandicappingNotes);
            this.Controls.Add(this._raceViewerControl);
            this.Controls.Add(this._linkLabelReadReleaseNotes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SippCardViewerForm";
            this.Text = "SippCardViewerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SippCardViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.SippCardViewerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanelRaceSelector;
        private RaceViewerControl _raceViewerControl;
        private System.Windows.Forms.Timer _saveUserSettingsTimer;
        private System.Windows.Forms.LinkLabel _linkLabelReadReleaseNotes;
        private System.Windows.Forms.LinkLabel _linkLabelHandicappingNotes;
        private System.Windows.Forms.ComboBox _cbAvailableCards;
    }
}