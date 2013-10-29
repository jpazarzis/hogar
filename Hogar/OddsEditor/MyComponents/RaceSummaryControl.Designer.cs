namespace OddsEditor.MyComponents
{
    partial class RaceSummaryControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceSummaryControl));
            this._grid = new System.Windows.Forms.DataGridView();
            this._popupmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._labelRaceClassification = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._buttonShowRaceFilters = new System.Windows.Forms.Button();
            this._buttonShowKeyRaces = new System.Windows.Forms.Button();
            this._buttonShowSuperfectaStudio = new System.Windows.Forms.Button();
            this._buttonClearSelections = new System.Windows.Forms.Button();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._buttonDoublePayouts = new System.Windows.Forms.Button();
            this._buttonExactaPayouts = new System.Windows.Forms.Button();
            this._buttonRealTimeOdds = new System.Windows.Forms.Button();
            this._buttonHandicapBasedInFigures = new System.Windows.Forms.Button();
            this._buttonBreadAndButter = new System.Windows.Forms.Button();
            this._labelRaceNumber = new System.Windows.Forms.Label();
            this._buttonShowResults = new System.Windows.Forms.Button();
            this._buttonHideRace = new System.Windows.Forms.Button();
            this._buttonShowTrifectas = new System.Windows.Forms.Button();
            this._buttonSpeedAnalysis = new System.Windows.Forms.Button();
            this._panelHorseDetails = new System.Windows.Forms.Panel();
            this._labelHorseDetails = new System.Windows.Forms.Label();
            this._tooltip = new System.Windows.Forms.ToolTip(this.components);
            this._tabKeyRaces = new System.Windows.Forms.TabPage();
            this._tabFactorsSummary = new System.Windows.Forms.TabPage();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabPageRaceComments = new System.Windows.Forms.TabPage();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._brisFiguresStatsCtrl1 = new OddsEditor.MyComponents.BrisFiguresStatsCtrl();
            this._factorAnalysisCtrl1 = new OddsEditor.MyComponents.FactorAnalysisCtrl();
            this._breedingInfoCtrl = new OddsEditor.MyComponents.BreedingInfoCtrl();
            this._cynthiaParsSummaryCtrl1 = new OddsEditor.MyComponents.CynthiaParsSummaryCtrl();
            this._showRunTogethersControl = new OddsEditor.MyComponents.ShowRunTogethersControl();
            this._raceCommentsCtrl = new OddsEditor.MyComponents.RaceCommentsCtrl();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.panel1.SuspendLayout();
            this._panelHorseDetails.SuspendLayout();
            this._tabKeyRaces.SuspendLayout();
            this._tabFactorsSummary.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._tabPageRaceComments.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this._grid.BackgroundColor = System.Drawing.Color.Honeydew;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(5, 28);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.RowTemplate.Height = 35;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(810, 557);
            this._grid.TabIndex = 0;
            this._grid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnCellMouseClick);
            this._grid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.OnSortCompare);
            // 
            // _popupmenu
            // 
            this._popupmenu.Name = "_popupmenu";
            this._popupmenu.Size = new System.Drawing.Size(61, 4);
            // 
            // _labelRaceClassification
            // 
            this._labelRaceClassification.AutoSize = true;
            this._labelRaceClassification.Cursor = System.Windows.Forms.Cursors.Hand;
            this._labelRaceClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceClassification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._labelRaceClassification.Location = new System.Drawing.Point(125, 8);
            this._labelRaceClassification.Name = "_labelRaceClassification";
            this._labelRaceClassification.Size = new System.Drawing.Size(51, 16);
            this._labelRaceClassification.TabIndex = 9;
            this._labelRaceClassification.Text = "label1";
            this._labelRaceClassification.Click += new System.EventHandler(this.OnRaceClassificationCliked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this._brisFiguresStatsCtrl1);
            this.panel1.Controls.Add(this._buttonShowRaceFilters);
            this.panel1.Controls.Add(this._buttonShowKeyRaces);
            this.panel1.Controls.Add(this._buttonShowSuperfectaStudio);
            this.panel1.Controls.Add(this._buttonClearSelections);
            this.panel1.Controls.Add(this._progressBar);
            this.panel1.Controls.Add(this._buttonDoublePayouts);
            this.panel1.Controls.Add(this._buttonExactaPayouts);
            this.panel1.Controls.Add(this._buttonRealTimeOdds);
            this.panel1.Controls.Add(this._buttonHandicapBasedInFigures);
            this.panel1.Controls.Add(this._buttonBreadAndButter);
            this.panel1.Controls.Add(this._labelRaceNumber);
            this.panel1.Controls.Add(this._labelRaceClassification);
            this.panel1.Controls.Add(this._buttonShowResults);
            this.panel1.Controls.Add(this._buttonHideRace);
            this.panel1.Controls.Add(this._buttonShowTrifectas);
            this.panel1.Controls.Add(this._buttonSpeedAnalysis);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 29);
            this.panel1.TabIndex = 12;
            // 
            // _buttonShowRaceFilters
            // 
            this._buttonShowRaceFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonShowRaceFilters.Location = new System.Drawing.Point(622, 3);
            this._buttonShowRaceFilters.Name = "_buttonShowRaceFilters";
            this._buttonShowRaceFilters.Size = new System.Drawing.Size(31, 23);
            this._buttonShowRaceFilters.TabIndex = 12;
            this._buttonShowRaceFilters.Text = "F";
            this._tooltip.SetToolTip(this._buttonShowRaceFilters, "Apply Filter");
            this._buttonShowRaceFilters.UseVisualStyleBackColor = true;
            this._buttonShowRaceFilters.Click += new System.EventHandler(this._buttonShowRaceFilters_Click);
            // 
            // _buttonShowKeyRaces
            // 
            this._buttonShowKeyRaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonShowKeyRaces.Location = new System.Drawing.Point(679, 3);
            this._buttonShowKeyRaces.Name = "_buttonShowKeyRaces";
            this._buttonShowKeyRaces.Size = new System.Drawing.Size(31, 23);
            this._buttonShowKeyRaces.TabIndex = 15;
            this._buttonShowKeyRaces.Text = "K";
            this._tooltip.SetToolTip(this._buttonShowKeyRaces, "Show Key Races");
            this._buttonShowKeyRaces.UseVisualStyleBackColor = true;
            this._buttonShowKeyRaces.Click += new System.EventHandler(this.ButtonShowKeyRacesClick);
            // 
            // _buttonShowSuperfectaStudio
            // 
            this._buttonShowSuperfectaStudio.Location = new System.Drawing.Point(361, 3);
            this._buttonShowSuperfectaStudio.Name = "_buttonShowSuperfectaStudio";
            this._buttonShowSuperfectaStudio.Size = new System.Drawing.Size(31, 23);
            this._buttonShowSuperfectaStudio.TabIndex = 19;
            this._buttonShowSuperfectaStudio.Text = "S";
            this._tooltip.SetToolTip(this._buttonShowSuperfectaStudio, "Superfecta Studio");
            this._buttonShowSuperfectaStudio.UseVisualStyleBackColor = true;
            this._buttonShowSuperfectaStudio.Click += new System.EventHandler(this.OnShowSuperfectaStudio);
            // 
            // _buttonClearSelections
            // 
            this._buttonClearSelections.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonClearSelections.Location = new System.Drawing.Point(651, 3);
            this._buttonClearSelections.Name = "_buttonClearSelections";
            this._buttonClearSelections.Size = new System.Drawing.Size(31, 23);
            this._buttonClearSelections.TabIndex = 13;
            this._buttonClearSelections.Text = "C";
            this._tooltip.SetToolTip(this._buttonClearSelections, "Clear Selections");
            this._buttonClearSelections.UseVisualStyleBackColor = true;
            this._buttonClearSelections.Click += new System.EventHandler(this._buttonClearSelections_Click);
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(255, 5);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(53, 19);
            this._progressBar.TabIndex = 14;
            // 
            // _buttonDoublePayouts
            // 
            this._buttonDoublePayouts.Location = new System.Drawing.Point(390, 3);
            this._buttonDoublePayouts.Name = "_buttonDoublePayouts";
            this._buttonDoublePayouts.Size = new System.Drawing.Size(31, 23);
            this._buttonDoublePayouts.TabIndex = 18;
            this._buttonDoublePayouts.Text = "D";
            this._tooltip.SetToolTip(this._buttonDoublePayouts, "Exacta Payouts");
            this._buttonDoublePayouts.UseVisualStyleBackColor = true;
            this._buttonDoublePayouts.Click += new System.EventHandler(this.OnDoublePayouts);
            // 
            // _buttonExactaPayouts
            // 
            this._buttonExactaPayouts.Location = new System.Drawing.Point(419, 3);
            this._buttonExactaPayouts.Name = "_buttonExactaPayouts";
            this._buttonExactaPayouts.Size = new System.Drawing.Size(31, 23);
            this._buttonExactaPayouts.TabIndex = 17;
            this._buttonExactaPayouts.Text = "X";
            this._tooltip.SetToolTip(this._buttonExactaPayouts, "Exacta Payouts");
            this._buttonExactaPayouts.UseVisualStyleBackColor = true;
            this._buttonExactaPayouts.Click += new System.EventHandler(this.OnExactaPayouts);
            // 
            // _buttonRealTimeOdds
            // 
            this._buttonRealTimeOdds.Image = ((System.Drawing.Image)(resources.GetObject("_buttonRealTimeOdds.Image")));
            this._buttonRealTimeOdds.Location = new System.Drawing.Point(448, 3);
            this._buttonRealTimeOdds.Name = "_buttonRealTimeOdds";
            this._buttonRealTimeOdds.Size = new System.Drawing.Size(31, 23);
            this._buttonRealTimeOdds.TabIndex = 15;
            this._tooltip.SetToolTip(this._buttonRealTimeOdds, "R/T Odds Feed");
            this._buttonRealTimeOdds.UseVisualStyleBackColor = true;
            this._buttonRealTimeOdds.Click += new System.EventHandler(this.OnStartRealTimeOddsFeed);
            // 
            // _buttonHandicapBasedInFigures
            // 
            this._buttonHandicapBasedInFigures.Image = ((System.Drawing.Image)(resources.GetObject("_buttonHandicapBasedInFigures.Image")));
            this._buttonHandicapBasedInFigures.Location = new System.Drawing.Point(564, 3);
            this._buttonHandicapBasedInFigures.Name = "_buttonHandicapBasedInFigures";
            this._buttonHandicapBasedInFigures.Size = new System.Drawing.Size(31, 23);
            this._buttonHandicapBasedInFigures.TabIndex = 12;
            this._tooltip.SetToolTip(this._buttonHandicapBasedInFigures, "Handicap Based In Speed Figures");
            this._buttonHandicapBasedInFigures.UseVisualStyleBackColor = true;
            this._buttonHandicapBasedInFigures.Click += new System.EventHandler(this.OnRaceAttributes);
            // 
            // _buttonBreadAndButter
            // 
            this._buttonBreadAndButter.Image = ((System.Drawing.Image)(resources.GetObject("_buttonBreadAndButter.Image")));
            this._buttonBreadAndButter.Location = new System.Drawing.Point(477, 3);
            this._buttonBreadAndButter.Name = "_buttonBreadAndButter";
            this._buttonBreadAndButter.Size = new System.Drawing.Size(31, 23);
            this._buttonBreadAndButter.TabIndex = 11;
            this._tooltip.SetToolTip(this._buttonBreadAndButter, "Bread And Butter");
            this._buttonBreadAndButter.UseVisualStyleBackColor = true;
            this._buttonBreadAndButter.Click += new System.EventHandler(this.OnShowFigures);
            // 
            // _labelRaceNumber
            // 
            this._labelRaceNumber.AutoSize = true;
            this._labelRaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._labelRaceNumber.Location = new System.Drawing.Point(3, 5);
            this._labelRaceNumber.Name = "_labelRaceNumber";
            this._labelRaceNumber.Size = new System.Drawing.Size(86, 20);
            this._labelRaceNumber.TabIndex = 10;
            this._labelRaceNumber.Text = "Race# 12";
            // 
            // _buttonShowResults
            // 
            this._buttonShowResults.Image = ((System.Drawing.Image)(resources.GetObject("_buttonShowResults.Image")));
            this._buttonShowResults.Location = new System.Drawing.Point(333, 3);
            this._buttonShowResults.Name = "_buttonShowResults";
            this._buttonShowResults.Size = new System.Drawing.Size(31, 23);
            this._buttonShowResults.TabIndex = 7;
            this._tooltip.SetToolTip(this._buttonShowResults, "Race Chart");
            this._buttonShowResults.UseVisualStyleBackColor = true;
            this._buttonShowResults.Click += new System.EventHandler(this.OnShowResults);
            // 
            // _buttonHideRace
            // 
            this._buttonHideRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonHideRace.Image = ((System.Drawing.Image)(resources.GetObject("_buttonHideRace.Image")));
            this._buttonHideRace.Location = new System.Drawing.Point(535, 3);
            this._buttonHideRace.Name = "_buttonHideRace";
            this._buttonHideRace.Size = new System.Drawing.Size(31, 23);
            this._buttonHideRace.TabIndex = 3;
            this._tooltip.SetToolTip(this._buttonHideRace, "Hide Race");
            this._buttonHideRace.UseVisualStyleBackColor = true;
            this._buttonHideRace.Click += new System.EventHandler(this.OnHide);
            // 
            // _buttonShowTrifectas
            // 
            this._buttonShowTrifectas.Image = ((System.Drawing.Image)(resources.GetObject("_buttonShowTrifectas.Image")));
            this._buttonShowTrifectas.Location = new System.Drawing.Point(593, 3);
            this._buttonShowTrifectas.Name = "_buttonShowTrifectas";
            this._buttonShowTrifectas.Size = new System.Drawing.Size(31, 23);
            this._buttonShowTrifectas.TabIndex = 5;
            this._tooltip.SetToolTip(this._buttonShowTrifectas, "Make Trifectas");
            this._buttonShowTrifectas.UseVisualStyleBackColor = true;
            this._buttonShowTrifectas.Click += new System.EventHandler(this.OnShowTrifectas);
            // 
            // _buttonSpeedAnalysis
            // 
            this._buttonSpeedAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSpeedAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("_buttonSpeedAnalysis.Image")));
            this._buttonSpeedAnalysis.Location = new System.Drawing.Point(506, 3);
            this._buttonSpeedAnalysis.Name = "_buttonSpeedAnalysis";
            this._buttonSpeedAnalysis.Size = new System.Drawing.Size(31, 23);
            this._buttonSpeedAnalysis.TabIndex = 2;
            this._tooltip.SetToolTip(this._buttonSpeedAnalysis, "Speed Analysis For The Race");
            this._buttonSpeedAnalysis.UseVisualStyleBackColor = true;
            this._buttonSpeedAnalysis.Click += new System.EventHandler(this.OnSpeedAnalysis);
            // 
            // _panelHorseDetails
            // 
            this._panelHorseDetails.BackColor = System.Drawing.Color.SteelBlue;
            this._panelHorseDetails.Controls.Add(this._labelHorseDetails);
            this._panelHorseDetails.Location = new System.Drawing.Point(909, -2);
            this._panelHorseDetails.Name = "_panelHorseDetails";
            this._panelHorseDetails.Size = new System.Drawing.Size(481, 32);
            this._panelHorseDetails.TabIndex = 13;
            this._panelHorseDetails.Paint += new System.Windows.Forms.PaintEventHandler(this._panelHorseDetails_Paint);
            // 
            // _labelHorseDetails
            // 
            this._labelHorseDetails.AutoSize = true;
            this._labelHorseDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._labelHorseDetails.Location = new System.Drawing.Point(19, 5);
            this._labelHorseDetails.Name = "_labelHorseDetails";
            this._labelHorseDetails.Size = new System.Drawing.Size(86, 20);
            this._labelHorseDetails.TabIndex = 11;
            this._labelHorseDetails.Text = "Race# 12";
            // 
            // _tabKeyRaces
            // 
            this._tabKeyRaces.Controls.Add(this._showRunTogethersControl);
            this._tabKeyRaces.Location = new System.Drawing.Point(4, 22);
            this._tabKeyRaces.Name = "_tabKeyRaces";
            this._tabKeyRaces.Padding = new System.Windows.Forms.Padding(3);
            this._tabKeyRaces.Size = new System.Drawing.Size(561, 526);
            this._tabKeyRaces.TabIndex = 1;
            this._tabKeyRaces.Text = "Key Races";
            this._tabKeyRaces.UseVisualStyleBackColor = true;
            // 
            // _tabFactorsSummary
            // 
            this._tabFactorsSummary.Controls.Add(this._factorAnalysisCtrl1);
            this._tabFactorsSummary.Controls.Add(this._breedingInfoCtrl);
            this._tabFactorsSummary.Controls.Add(this._cynthiaParsSummaryCtrl1);
            this._tabFactorsSummary.Location = new System.Drawing.Point(4, 22);
            this._tabFactorsSummary.Name = "_tabFactorsSummary";
            this._tabFactorsSummary.Padding = new System.Windows.Forms.Padding(3);
            this._tabFactorsSummary.Size = new System.Drawing.Size(561, 526);
            this._tabFactorsSummary.TabIndex = 2;
            this._tabFactorsSummary.Text = "Summary";
            this._tabFactorsSummary.UseVisualStyleBackColor = true;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabFactorsSummary);
            this._tabControl.Controls.Add(this._tabKeyRaces);
            this._tabControl.Controls.Add(this._tabPageRaceComments);
            this._tabControl.Location = new System.Drawing.Point(821, 33);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(569, 552);
            this._tabControl.TabIndex = 11;
            // 
            // _tabPageRaceComments
            // 
            this._tabPageRaceComments.Controls.Add(this._raceCommentsCtrl);
            this._tabPageRaceComments.Location = new System.Drawing.Point(4, 22);
            this._tabPageRaceComments.Name = "_tabPageRaceComments";
            this._tabPageRaceComments.Size = new System.Drawing.Size(561, 526);
            this._tabPageRaceComments.TabIndex = 4;
            this._tabPageRaceComments.Text = "Race Comments";
            this._tabPageRaceComments.UseVisualStyleBackColor = true;
            // 
            // _backgroundWorker
            // 
            this._backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorker_DoWork);
            this._backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorker_RunWorkerCompleted);
            this._backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._backgroundWorker_ProgressChanged);
            // 
            // _brisFiguresStatsCtrl1
            // 
            this._brisFiguresStatsCtrl1.BackColor = System.Drawing.Color.Tan;
            this._brisFiguresStatsCtrl1.Location = new System.Drawing.Point(708, -2);
            this._brisFiguresStatsCtrl1.Name = "_brisFiguresStatsCtrl1";
            this._brisFiguresStatsCtrl1.Size = new System.Drawing.Size(212, 32);
            this._brisFiguresStatsCtrl1.TabIndex = 16;
            // 
            // _factorAnalysisCtrl1
            // 
            this._factorAnalysisCtrl1.Location = new System.Drawing.Point(3, 366);
            this._factorAnalysisCtrl1.Name = "_factorAnalysisCtrl1";
            this._factorAnalysisCtrl1.Size = new System.Drawing.Size(552, 150);
            this._factorAnalysisCtrl1.TabIndex = 5;
            // 
            // _breedingInfoCtrl
            // 
            this._breedingInfoCtrl.Location = new System.Drawing.Point(8, 282);
            this._breedingInfoCtrl.Name = "_breedingInfoCtrl";
            this._breedingInfoCtrl.Size = new System.Drawing.Size(272, 78);
            this._breedingInfoCtrl.TabIndex = 2;
            // 
            // _cynthiaParsSummaryCtrl1
            // 
            this._cynthiaParsSummaryCtrl1.BackColor = System.Drawing.SystemColors.Control;
            this._cynthiaParsSummaryCtrl1.Location = new System.Drawing.Point(8, 3);
            this._cynthiaParsSummaryCtrl1.Name = "_cynthiaParsSummaryCtrl1";
            this._cynthiaParsSummaryCtrl1.Size = new System.Drawing.Size(547, 268);
            this._cynthiaParsSummaryCtrl1.TabIndex = 1;
            // 
            // _showRunTogethersControl
            // 
            this._showRunTogethersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._showRunTogethersControl.Location = new System.Drawing.Point(3, 3);
            this._showRunTogethersControl.Name = "_showRunTogethersControl";
            this._showRunTogethersControl.Size = new System.Drawing.Size(555, 520);
            this._showRunTogethersControl.TabIndex = 0;
            // 
            // _raceCommentsCtrl
            // 
            this._raceCommentsCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._raceCommentsCtrl.Location = new System.Drawing.Point(0, 0);
            this._raceCommentsCtrl.Name = "_raceCommentsCtrl";
            this._raceCommentsCtrl.Size = new System.Drawing.Size(561, 526);
            this._raceCommentsCtrl.TabIndex = 0;
            // 
            // RaceSummaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._panelHorseDetails);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._tabControl);
            this.Name = "RaceSummaryControl";
            this.Size = new System.Drawing.Size(1397, 607);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._panelHorseDetails.ResumeLayout(false);
            this._panelHorseDetails.PerformLayout();
            this._tabKeyRaces.ResumeLayout(false);
            this._tabFactorsSummary.ResumeLayout(false);
            this._tabControl.ResumeLayout(false);
            this._tabPageRaceComments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ContextMenuStrip _popupmenu;
        private System.Windows.Forms.Button _buttonSpeedAnalysis;
        private System.Windows.Forms.Button _buttonHideRace;
        private System.Windows.Forms.Button _buttonShowTrifectas;
        private System.Windows.Forms.Button _buttonShowResults;
        private System.Windows.Forms.Label _labelRaceClassification;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _labelRaceNumber;
        private System.Windows.Forms.Panel _panelHorseDetails;
        private System.Windows.Forms.Label _labelHorseDetails;
        private System.Windows.Forms.Button _buttonBreadAndButter;
        private System.Windows.Forms.ToolTip _tooltip;
        private System.Windows.Forms.Button _buttonHandicapBasedInFigures;
        private System.Windows.Forms.TabPage _tabKeyRaces;
        private ShowRunTogethersControl _showRunTogethersControl;
        private System.Windows.Forms.TabPage _tabFactorsSummary;
        private CynthiaParsSummaryCtrl _cynthiaParsSummaryCtrl1;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.Button _buttonRealTimeOdds;
        private System.Windows.Forms.Button _buttonExactaPayouts;
        private BreedingInfoCtrl _breedingInfoCtrl;
        private System.Windows.Forms.Button _buttonDoublePayouts;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Button _buttonShowSuperfectaStudio;
        private System.Windows.Forms.TabPage _tabPageRaceComments;
        private RaceCommentsCtrl _raceCommentsCtrl;
        private System.Windows.Forms.Button _buttonShowRaceFilters;
        private System.Windows.Forms.Button _buttonClearSelections;
        private System.Windows.Forms.Button _buttonShowKeyRaces;
        private BrisFiguresStatsCtrl _brisFiguresStatsCtrl1;
        private FactorAnalysisCtrl _factorAnalysisCtrl1;
    }
}
