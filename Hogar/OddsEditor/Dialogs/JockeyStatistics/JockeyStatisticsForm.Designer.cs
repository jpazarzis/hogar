namespace OddsEditor.Dialogs.JockeyStatistics
{
    partial class JockeyStatisticsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._statsGrid = new System.Windows.Forms.DataGridView();
            this._trainerTrackGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this._labelEkar = new System.Windows.Forms.Label();
            this._labelMaxEkar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._labelAvgEkar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._ekarGraphCtrl = new NPlot.Windows.PlotSurface2D();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._gridStatsPerSelectedTrainer = new System.Windows.Forms.DataGridView();
            this._periodSelector = new HogarControlLibrary.PeriodSelector();
            ((System.ComponentModel.ISupportInitialize)(this._statsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trainerTrackGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridStatsPerSelectedTrainer)).BeginInit();
            this.SuspendLayout();
            // 
            // _statsGrid
            // 
            this._statsGrid.AllowUserToAddRows = false;
            this._statsGrid.AllowUserToDeleteRows = false;
            this._statsGrid.AllowUserToOrderColumns = true;
            this._statsGrid.AllowUserToResizeColumns = false;
            this._statsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this._statsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._statsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._statsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._statsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._statsGrid.Location = new System.Drawing.Point(12, 106);
            this._statsGrid.Name = "_statsGrid";
            this._statsGrid.ReadOnly = true;
            this._statsGrid.RowHeadersVisible = false;
            this._statsGrid.Size = new System.Drawing.Size(368, 261);
            this._statsGrid.TabIndex = 0;
            // 
            // _trainerTrackGrid
            // 
            this._trainerTrackGrid.AllowUserToAddRows = false;
            this._trainerTrackGrid.AllowUserToDeleteRows = false;
            this._trainerTrackGrid.AllowUserToResizeColumns = false;
            this._trainerTrackGrid.AllowUserToResizeRows = false;
            this._trainerTrackGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._trainerTrackGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._trainerTrackGrid.Location = new System.Drawing.Point(12, 389);
            this._trainerTrackGrid.Name = "_trainerTrackGrid";
            this._trainerTrackGrid.ReadOnly = true;
            this._trainerTrackGrid.RowHeadersWidth = 10;
            this._trainerTrackGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._trainerTrackGrid.Size = new System.Drawing.Size(1213, 429);
            this._trainerTrackGrid.TabIndex = 2;
            this._trainerTrackGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnTrainerTrackGridClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current";
            // 
            // _labelEkar
            // 
            this._labelEkar.AutoSize = true;
            this._labelEkar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelEkar.Location = new System.Drawing.Point(62, 37);
            this._labelEkar.Name = "_labelEkar";
            this._labelEkar.Size = new System.Drawing.Size(19, 20);
            this._labelEkar.TabIndex = 4;
            this._labelEkar.Text = "2";
            // 
            // _labelMaxEkar
            // 
            this._labelMaxEkar.AutoSize = true;
            this._labelMaxEkar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelMaxEkar.Location = new System.Drawing.Point(175, 37);
            this._labelMaxEkar.Name = "_labelMaxEkar";
            this._labelMaxEkar.Size = new System.Drawing.Size(19, 20);
            this._labelMaxEkar.TabIndex = 6;
            this._labelMaxEkar.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max";
            // 
            // _labelAvgEkar
            // 
            this._labelAvgEkar.AutoSize = true;
            this._labelAvgEkar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelAvgEkar.Location = new System.Drawing.Point(299, 37);
            this._labelAvgEkar.Name = "_labelAvgEkar";
            this._labelAvgEkar.Size = new System.Drawing.Size(19, 20);
            this._labelAvgEkar.TabIndex = 9;
            this._labelAvgEkar.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Average";
            // 
            // _ekarGraphCtrl
            // 
            this._ekarGraphCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._ekarGraphCtrl.AutoScaleAutoGeneratedAxes = false;
            this._ekarGraphCtrl.AutoScaleTitle = false;
            this._ekarGraphCtrl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._ekarGraphCtrl.DateTimeToolTip = false;
            this._ekarGraphCtrl.Legend = null;
            this._ekarGraphCtrl.LegendZOrder = -1;
            this._ekarGraphCtrl.Location = new System.Drawing.Point(6, 64);
            this._ekarGraphCtrl.Name = "_ekarGraphCtrl";
            this._ekarGraphCtrl.RightMenu = null;
            this._ekarGraphCtrl.ShowCoordinates = true;
            this._ekarGraphCtrl.Size = new System.Drawing.Size(793, 99);
            this._ekarGraphCtrl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this._ekarGraphCtrl.TabIndex = 10;
            this._ekarGraphCtrl.Text = "plotSurface2D1";
            this._ekarGraphCtrl.Title = "";
            this._ekarGraphCtrl.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this._ekarGraphCtrl.XAxis1 = null;
            this._ekarGraphCtrl.XAxis2 = null;
            this._ekarGraphCtrl.YAxis1 = null;
            this._ekarGraphCtrl.YAxis2 = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._ekarGraphCtrl);
            this.groupBox1.Controls.Add(this._labelAvgEkar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._labelEkar);
            this.groupBox1.Controls.Add(this._labelMaxEkar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(400, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 178);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EKAR";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // _gridStatsPerSelectedTrainer
            // 
            this._gridStatsPerSelectedTrainer.AllowUserToAddRows = false;
            this._gridStatsPerSelectedTrainer.AllowUserToDeleteRows = false;
            this._gridStatsPerSelectedTrainer.AllowUserToOrderColumns = true;
            this._gridStatsPerSelectedTrainer.AllowUserToResizeColumns = false;
            this._gridStatsPerSelectedTrainer.AllowUserToResizeRows = false;
            this._gridStatsPerSelectedTrainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridStatsPerSelectedTrainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridStatsPerSelectedTrainer.BackgroundColor = System.Drawing.SystemColors.Control;
            this._gridStatsPerSelectedTrainer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridStatsPerSelectedTrainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridStatsPerSelectedTrainer.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridStatsPerSelectedTrainer.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridStatsPerSelectedTrainer.Location = new System.Drawing.Point(12, 6);
            this._gridStatsPerSelectedTrainer.Name = "_gridStatsPerSelectedTrainer";
            this._gridStatsPerSelectedTrainer.ReadOnly = true;
            this._gridStatsPerSelectedTrainer.RowHeadersVisible = false;
            this._gridStatsPerSelectedTrainer.Size = new System.Drawing.Size(1197, 85);
            this._gridStatsPerSelectedTrainer.TabIndex = 16;
            // 
            // _periodSelector
            // 
            this._periodSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._periodSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._periodSelector.Location = new System.Drawing.Point(416, 106);
            this._periodSelector.Name = "_periodSelector";
            this._periodSelector.Size = new System.Drawing.Size(793, 77);
            this._periodSelector.TabIndex = 17;
            this._periodSelector.OnPeriodChanged += new System.EventHandler(this.OnPeriodChanged);
            // 
            // JockeyStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 830);
            this.Controls.Add(this._periodSelector);
            this.Controls.Add(this._gridStatsPerSelectedTrainer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._trainerTrackGrid);
            this.Controls.Add(this._statsGrid);
            this.Name = "JockeyStatisticsForm";
            this.ShowInTaskbar = false;
            this.Text = "JockeyStatisticsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._statsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trainerTrackGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridStatsPerSelectedTrainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _statsGrid;
        private System.Windows.Forms.DataGridView _trainerTrackGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _labelEkar;
        private System.Windows.Forms.Label _labelMaxEkar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _labelAvgEkar;
        private System.Windows.Forms.Label label4;
        private NPlot.Windows.PlotSurface2D _ekarGraphCtrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView _gridStatsPerSelectedTrainer;
        private HogarControlLibrary.PeriodSelector _periodSelector;
    }
}