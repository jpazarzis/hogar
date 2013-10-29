namespace OddsEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._showAllCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._showOnlyTodaysCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._showOnlyFutureCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._selectCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._backtestProbabilityCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemMaintRaceTracks = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemBestBetsOfTheday = new System.Windows.Forms.ToolStripMenuItem();
            this._handicappingFactorWorkbenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._kellyCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemUpdateFactors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripMenuItemJockeyStats = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemtrainerStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.findHorsePerformancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.compareTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._specifyParametersForPrimeBetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._pythonEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showAllCardsToolStripMenuItem,
            this._showOnlyTodaysCardsToolStripMenuItem,
            this._showOnlyFutureCardsToolStripMenuItem,
            this.toolStripSeparator6,
            this._selectCardToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // _showAllCardsToolStripMenuItem
            // 
            this._showAllCardsToolStripMenuItem.Name = "_showAllCardsToolStripMenuItem";
            this._showAllCardsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._showAllCardsToolStripMenuItem.Text = "Show All Cards";
            this._showAllCardsToolStripMenuItem.Click += new System.EventHandler(this.OnShowAllCards);
            // 
            // _showOnlyTodaysCardsToolStripMenuItem
            // 
            this._showOnlyTodaysCardsToolStripMenuItem.Name = "_showOnlyTodaysCardsToolStripMenuItem";
            this._showOnlyTodaysCardsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._showOnlyTodaysCardsToolStripMenuItem.Text = "Show Only Today\'s Cards";
            this._showOnlyTodaysCardsToolStripMenuItem.Click += new System.EventHandler(this.OnShowOnlyTodaysCards);
            // 
            // _showOnlyFutureCardsToolStripMenuItem
            // 
            this._showOnlyFutureCardsToolStripMenuItem.Name = "_showOnlyFutureCardsToolStripMenuItem";
            this._showOnlyFutureCardsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._showOnlyFutureCardsToolStripMenuItem.Text = "Show Only Future Cards ";
            this._showOnlyFutureCardsToolStripMenuItem.Click += new System.EventHandler(this.OnShowOnlyFutureCards);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(205, 6);
            // 
            // _selectCardToolStripMenuItem
            // 
            this._selectCardToolStripMenuItem.Name = "_selectCardToolStripMenuItem";
            this._selectCardToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._selectCardToolStripMenuItem.Text = "Select Card";
            this._selectCardToolStripMenuItem.Click += new System.EventHandler(this._selectCardToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._backtestProbabilityCalculatorToolStripMenuItem,
            this._menuItemMaintRaceTracks,
            this._menuItemBestBetsOfTheday,
            this._handicappingFactorWorkbenchToolStripMenuItem,
            this.toolStripSeparator3,
            this._kellyCalculatorToolStripMenuItem,
            this._menuItemUpdateFactors,
            this.toolStripSeparator2,
            this._toolStripMenuItemJockeyStats,
            this._menuItemtrainerStatistics,
            this.toolStripMenuItem1,
            this.findHorsePerformancesToolStripMenuItem,
            this.toolStripSeparator5,
            this.compareTracksToolStripMenuItem,
            this._specifyParametersForPrimeBetToolStripMenuItem,
            this.toolStripSeparator7,
            this._pythonEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // _backtestProbabilityCalculatorToolStripMenuItem
            // 
            this._backtestProbabilityCalculatorToolStripMenuItem.Name = "_backtestProbabilityCalculatorToolStripMenuItem";
            this._backtestProbabilityCalculatorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this._backtestProbabilityCalculatorToolStripMenuItem.Text = "Backtest Probability Calculator";
            this._backtestProbabilityCalculatorToolStripMenuItem.Click += new System.EventHandler(this.OnBacktestProbabilityCalculator);
            // 
            // _menuItemMaintRaceTracks
            // 
            this._menuItemMaintRaceTracks.Name = "_menuItemMaintRaceTracks";
            this._menuItemMaintRaceTracks.Size = new System.Drawing.Size(249, 22);
            this._menuItemMaintRaceTracks.Text = "Maint Race Tracks";
            this._menuItemMaintRaceTracks.Click += new System.EventHandler(this.OnMaintRaceTracks);
            // 
            // _menuItemBestBetsOfTheday
            // 
            this._menuItemBestBetsOfTheday.Name = "_menuItemBestBetsOfTheday";
            this._menuItemBestBetsOfTheday.Size = new System.Drawing.Size(249, 22);
            this._menuItemBestBetsOfTheday.Text = "Best Bets Of The Day";
            this._menuItemBestBetsOfTheday.Click += new System.EventHandler(this.OnBestBetsOfTheday);
            // 
            // _handicappingFactorWorkbenchToolStripMenuItem
            // 
            this._handicappingFactorWorkbenchToolStripMenuItem.Name = "_handicappingFactorWorkbenchToolStripMenuItem";
            this._handicappingFactorWorkbenchToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this._handicappingFactorWorkbenchToolStripMenuItem.Text = "Handicapping Factor Workbench";
            this._handicappingFactorWorkbenchToolStripMenuItem.Click += new System.EventHandler(this.OnHandicappingFactorWorkbench);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(246, 6);
            // 
            // _kellyCalculatorToolStripMenuItem
            // 
            this._kellyCalculatorToolStripMenuItem.Name = "_kellyCalculatorToolStripMenuItem";
            this._kellyCalculatorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this._kellyCalculatorToolStripMenuItem.Text = "Kelly Calculator";
            this._kellyCalculatorToolStripMenuItem.Click += new System.EventHandler(this.OnKellyCalculator);
            // 
            // _menuItemUpdateFactors
            // 
            this._menuItemUpdateFactors.Name = "_menuItemUpdateFactors";
            this._menuItemUpdateFactors.Size = new System.Drawing.Size(249, 22);
            this._menuItemUpdateFactors.Text = "Update Handicapping Factors";
            this._menuItemUpdateFactors.Click += new System.EventHandler(this.OnUpdateFactors);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(246, 6);
            // 
            // _toolStripMenuItemJockeyStats
            // 
            this._toolStripMenuItemJockeyStats.Name = "_toolStripMenuItemJockeyStats";
            this._toolStripMenuItemJockeyStats.Size = new System.Drawing.Size(249, 22);
            this._toolStripMenuItemJockeyStats.Text = "Jockey Statistics";
            this._toolStripMenuItemJockeyStats.Click += new System.EventHandler(this.OnJockeyStatistics);
            // 
            // _menuItemtrainerStatistics
            // 
            this._menuItemtrainerStatistics.Name = "_menuItemtrainerStatistics";
            this._menuItemtrainerStatistics.Size = new System.Drawing.Size(249, 22);
            this._menuItemtrainerStatistics.Text = "Trainer Statistics";
            this._menuItemtrainerStatistics.Click += new System.EventHandler(this.OnTrainerStatistics);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItem1.Text = "Track Statistics";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.OnTrackStatistics);
            // 
            // findHorsePerformancesToolStripMenuItem
            // 
            this.findHorsePerformancesToolStripMenuItem.Name = "findHorsePerformancesToolStripMenuItem";
            this.findHorsePerformancesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.findHorsePerformancesToolStripMenuItem.Text = "Find Horse Performances";
            this.findHorsePerformancesToolStripMenuItem.Click += new System.EventHandler(this.OnFindHorsePerformances);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // compareTracksToolStripMenuItem
            // 
            this.compareTracksToolStripMenuItem.Name = "compareTracksToolStripMenuItem";
            this.compareTracksToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.compareTracksToolStripMenuItem.Text = "Compare Tracks";
            this.compareTracksToolStripMenuItem.Click += new System.EventHandler(this.OnCompareTracks);
            // 
            // _specifyParametersForPrimeBetToolStripMenuItem
            // 
            this._specifyParametersForPrimeBetToolStripMenuItem.Name = "_specifyParametersForPrimeBetToolStripMenuItem";
            this._specifyParametersForPrimeBetToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this._specifyParametersForPrimeBetToolStripMenuItem.Text = "Specify Parameters For Prime Bet";
            this._specifyParametersForPrimeBetToolStripMenuItem.Click += new System.EventHandler(this.OnSpecifyParametersForPrimeBet);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(246, 6);
            // 
            // _pythonEditorToolStripMenuItem
            // 
            this._pythonEditorToolStripMenuItem.Name = "_pythonEditorToolStripMenuItem";
            this._pythonEditorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this._pythonEditorToolStripMenuItem.Text = "Python Editor";
            this._pythonEditorToolStripMenuItem.Click += new System.EventHandler(this._pythonEditorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // _menuItemAbout
            // 
            this._menuItemAbout.Name = "_menuItemAbout";
            this._menuItemAbout.Size = new System.Drawing.Size(107, 22);
            this._menuItemAbout.Text = "About";
            this._menuItemAbout.Click += new System.EventHandler(this.OnAbout);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(758, 517);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = " (c) John Pazarzis 2008-09";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _backtestProbabilityCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _handicappingFactorWorkbenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _kellyCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuItemUpdateFactors;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _menuItemtrainerStatistics;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findHorsePerformancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemJockeyStats;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _showAllCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _showOnlyTodaysCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _showOnlyFutureCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuItemMaintRaceTracks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem compareTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _specifyParametersForPrimeBetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuItemBestBetsOfTheday;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem _selectCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem _pythonEditorToolStripMenuItem;
    }
}

