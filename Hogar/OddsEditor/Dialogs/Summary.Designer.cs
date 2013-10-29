namespace OddsEditor.Dialogs
{
    partial class SummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryForm));
            this._panel = new System.Windows.Forms.FlowLayoutPanel();
            this._labelRaceTrack = new System.Windows.Forms.Label();
            this._checkboxHideScratches = new System.Windows.Forms.CheckBox();
            this._comboBoxSortBy = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripButtonGetScratchesFromClipboard = new System.Windows.Forms.ToolStripButton();
            this._toolStripButtonCopySelectionsToClipboard = new System.Windows.Forms.ToolStripButton();
            this._toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this._toolStripButtonShowAll = new System.Windows.Forms.ToolStripButton();
            this._toolStripKellyButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripButtonFindHorse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._applyNeuralNetworks = new System.Windows.Forms.ToolStripButton();
            this._tsbSaveWeightsAsFile = new System.Windows.Forms.ToolStripButton();
            this._tsbButtonAutoAssignWeights = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tsbCreateSippXmlFile = new System.Windows.Forms.ToolStripButton();
            this.panel3.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.AutoScroll = true;
            this._panel.Location = new System.Drawing.Point(0, 70);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(1335, 581);
            this._panel.TabIndex = 0;
            // 
            // _labelRaceTrack
            // 
            this._labelRaceTrack.AutoSize = true;
            this._labelRaceTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceTrack.ForeColor = System.Drawing.SystemColors.Window;
            this._labelRaceTrack.Location = new System.Drawing.Point(10, 9);
            this._labelRaceTrack.Name = "_labelRaceTrack";
            this._labelRaceTrack.Size = new System.Drawing.Size(168, 31);
            this._labelRaceTrack.TabIndex = 1;
            this._labelRaceTrack.Text = "Unassigned";
            // 
            // _checkboxHideScratches
            // 
            this._checkboxHideScratches.AutoSize = true;
            this._checkboxHideScratches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._checkboxHideScratches.Location = new System.Drawing.Point(422, 16);
            this._checkboxHideScratches.Name = "_checkboxHideScratches";
            this._checkboxHideScratches.Size = new System.Drawing.Size(99, 17);
            this._checkboxHideScratches.TabIndex = 5;
            this._checkboxHideScratches.Text = "Hide Scratches";
            this._checkboxHideScratches.UseVisualStyleBackColor = true;
            this._checkboxHideScratches.CheckedChanged += new System.EventHandler(this.OnHideScratchesCheckedChanged);
            // 
            // _comboBoxSortBy
            // 
            this._comboBoxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSortBy.FormattingEnabled = true;
            this._comboBoxSortBy.Items.AddRange(new object[] {
            "P/N",
            "Prime Power",
            "Figure",
            "Quirin Style",
            "Running Style"});
            this._comboBoxSortBy.Location = new System.Drawing.Point(312, 12);
            this._comboBoxSortBy.Name = "_comboBoxSortBy";
            this._comboBoxSortBy.Size = new System.Drawing.Size(104, 21);
            this._comboBoxSortBy.TabIndex = 13;
            this._comboBoxSortBy.SelectedIndexChanged += new System.EventHandler(this.OnSortByChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this._labelRaceTrack);
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1335, 44);
            this.panel3.TabIndex = 21;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonGetScratchesFromClipboard,
            this._toolStripButtonCopySelectionsToClipboard,
            this._toolStripButtonPrint,
            this._toolStripButtonShowAll,
            this._toolStripKellyButton,
            this._toolStripButtonFindHorse,
            this.toolStripSeparator1,
            this._applyNeuralNetworks,
            this._tsbSaveWeightsAsFile,
            this._tsbButtonAutoAssignWeights,
            this._tsbCreateSippXmlFile});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(1336, 25);
            this._toolStrip.TabIndex = 26;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _toolStripButtonGetScratchesFromClipboard
            // 
            this._toolStripButtonGetScratchesFromClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonGetScratchesFromClipboard.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonGetScratchesFromClipboard.Image")));
            this._toolStripButtonGetScratchesFromClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonGetScratchesFromClipboard.Name = "_toolStripButtonGetScratchesFromClipboard";
            this._toolStripButtonGetScratchesFromClipboard.Size = new System.Drawing.Size(23, 22);
            this._toolStripButtonGetScratchesFromClipboard.Text = "Get Scratches From Clipboard";
            this._toolStripButtonGetScratchesFromClipboard.Click += new System.EventHandler(this.OnGetScratchesFromClipboard2);
            // 
            // _toolStripButtonCopySelectionsToClipboard
            // 
            this._toolStripButtonCopySelectionsToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonCopySelectionsToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonCopySelectionsToClipboard.Image")));
            this._toolStripButtonCopySelectionsToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonCopySelectionsToClipboard.Name = "_toolStripButtonCopySelectionsToClipboard";
            this._toolStripButtonCopySelectionsToClipboard.Size = new System.Drawing.Size(23, 22);
            this._toolStripButtonCopySelectionsToClipboard.Text = "Copy Selections To Clipboard";
            this._toolStripButtonCopySelectionsToClipboard.Click += new System.EventHandler(this.OnCopySelectionsToClipboard2);
            // 
            // _toolStripButtonPrint
            // 
            this._toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonPrint.Image")));
            this._toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonPrint.Name = "_toolStripButtonPrint";
            this._toolStripButtonPrint.Size = new System.Drawing.Size(23, 22);
            this._toolStripButtonPrint.Text = "Print";
            this._toolStripButtonPrint.Click += new System.EventHandler(this._toolStripButtonPrint_Click);
            // 
            // _toolStripButtonShowAll
            // 
            this._toolStripButtonShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonShowAll.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonShowAll.Image")));
            this._toolStripButtonShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonShowAll.Name = "_toolStripButtonShowAll";
            this._toolStripButtonShowAll.Size = new System.Drawing.Size(23, 22);
            this._toolStripButtonShowAll.Text = "Show All";
            this._toolStripButtonShowAll.Click += new System.EventHandler(this._toolStripButtonShowAll_Click);
            // 
            // _toolStripKellyButton
            // 
            this._toolStripKellyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripKellyButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripKellyButton.Image")));
            this._toolStripKellyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripKellyButton.Name = "_toolStripKellyButton";
            this._toolStripKellyButton.Size = new System.Drawing.Size(23, 22);
            this._toolStripKellyButton.Text = "toolStripButton1";
            this._toolStripKellyButton.Click += new System.EventHandler(this.OnKelly);
            // 
            // _toolStripButtonFindHorse
            // 
            this._toolStripButtonFindHorse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonFindHorse.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonFindHorse.Image")));
            this._toolStripButtonFindHorse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonFindHorse.Name = "_toolStripButtonFindHorse";
            this._toolStripButtonFindHorse.Size = new System.Drawing.Size(23, 22);
            this._toolStripButtonFindHorse.Text = "toolStripButton1";
            this._toolStripButtonFindHorse.ToolTipText = "Find Horse";
            this._toolStripButtonFindHorse.Click += new System.EventHandler(this.OnFindHorse);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _applyNeuralNetworks
            // 
            this._applyNeuralNetworks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._applyNeuralNetworks.Image = ((System.Drawing.Image)(resources.GetObject("_applyNeuralNetworks.Image")));
            this._applyNeuralNetworks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._applyNeuralNetworks.Name = "_applyNeuralNetworks";
            this._applyNeuralNetworks.Size = new System.Drawing.Size(23, 22);
            this._applyNeuralNetworks.Text = "Apply Neural Networks";
            this._applyNeuralNetworks.Click += new System.EventHandler(this.ApplyNeuralNetworksClick);
            // 
            // _tsbSaveWeightsAsFile
            // 
            this._tsbSaveWeightsAsFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbSaveWeightsAsFile.Image = ((System.Drawing.Image)(resources.GetObject("_tsbSaveWeightsAsFile.Image")));
            this._tsbSaveWeightsAsFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbSaveWeightsAsFile.Name = "_tsbSaveWeightsAsFile";
            this._tsbSaveWeightsAsFile.Size = new System.Drawing.Size(23, 22);
            this._tsbSaveWeightsAsFile.Text = "Save Weights As XML";
            this._tsbSaveWeightsAsFile.Click += new System.EventHandler(this.OnSaveWeightsAsXMLFile);
            // 
            // _tsbButtonAutoAssignWeights
            // 
            this._tsbButtonAutoAssignWeights.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbButtonAutoAssignWeights.Image = ((System.Drawing.Image)(resources.GetObject("_tsbButtonAutoAssignWeights.Image")));
            this._tsbButtonAutoAssignWeights.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbButtonAutoAssignWeights.Name = "_tsbButtonAutoAssignWeights";
            this._tsbButtonAutoAssignWeights.Size = new System.Drawing.Size(23, 22);
            this._tsbButtonAutoAssignWeights.Text = "AutoAssignWeightsBasedInOdds";
            this._tsbButtonAutoAssignWeights.Click += new System.EventHandler(this.OnAutoAssignWeights);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // _tsbCreateSippXmlFile
            // 
            this._tsbCreateSippXmlFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbCreateSippXmlFile.Image = ((System.Drawing.Image)(resources.GetObject("_tsbCreateSippXmlFile.Image")));
            this._tsbCreateSippXmlFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCreateSippXmlFile.Name = "_tsbCreateSippXmlFile";
            this._tsbCreateSippXmlFile.Size = new System.Drawing.Size(23, 22);
            this._tsbCreateSippXmlFile.Text = "Create Sipp Xml File";
            this._tsbCreateSippXmlFile.Click += new System.EventHandler(this._tsbCreateSippXmlFile_Click);
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1336, 663);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this._comboBoxSortBy);
            this.Controls.Add(this._checkboxHideScratches);
            this.Controls.Add(this._panel);
            this.Name = "SummaryForm";
            this.Text = "BrisSelectionsForm (c) John Pazarzis 2008-09 (c) John Pazarzis 2008-2011 Ver. 2.0" +
    "1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panel;
        private System.Windows.Forms.Label _labelRaceTrack;
        private System.Windows.Forms.CheckBox _checkboxHideScratches;
        private System.Windows.Forms.ComboBox _comboBoxSortBy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _toolStripButtonGetScratchesFromClipboard;
        private System.Windows.Forms.ToolStripButton _toolStripButtonCopySelectionsToClipboard;
        private System.Windows.Forms.ToolStripButton _toolStripButtonPrint;
        private System.Windows.Forms.ToolStripButton _toolStripButtonShowAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _toolStripKellyButton;
        private System.Windows.Forms.ToolStripButton _toolStripButtonFindHorse;
        private System.Windows.Forms.ToolStripButton _applyNeuralNetworks;
        private System.Windows.Forms.ToolStripButton _tsbSaveWeightsAsFile;
        private System.Windows.Forms.ToolStripButton _tsbButtonAutoAssignWeights;
        private System.Windows.Forms.ToolStripButton _tsbCreateSippXmlFile;
    }
}