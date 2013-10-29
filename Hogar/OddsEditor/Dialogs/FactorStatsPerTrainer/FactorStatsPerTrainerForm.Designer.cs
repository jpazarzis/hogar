namespace OddsEditor.Dialogs.FactorStatsPerTrainer
{
    partial class FactorStatsPerTrainerForm
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
            this._grid = new System.Windows.Forms.DataGridView();
            this._tbTrainerName = new System.Windows.Forms.TextBox();
            this._tbFactorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonClose = new System.Windows.Forms.Button();
            this._gridSummary = new System.Windows.Forms.DataGridView();
            this._cbMCL = new System.Windows.Forms.CheckBox();
            this._cbMSW = new System.Windows.Forms.CheckBox();
            this._cbCLM = new System.Windows.Forms.CheckBox();
            this._cbAlw = new System.Windows.Forms.CheckBox();
            this._cbStakes = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._tbTurfWinPercent = new System.Windows.Forms.TextBox();
            this._tbDirtWinPercent = new System.Windows.Forms.TextBox();
            this._cbTurf = new System.Windows.Forms.CheckBox();
            this._tbStakesWinPercent = new System.Windows.Forms.TextBox();
            this._cbDirt = new System.Windows.Forms.CheckBox();
            this._tbALWWinPercent = new System.Windows.Forms.TextBox();
            this._tbCLMWinPercent = new System.Windows.Forms.TextBox();
            this._tbMSWWinPercent = new System.Windows.Forms.TextBox();
            this._tbMCLWinPercent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._tbWinStdDev = new System.Windows.Forms.TextBox();
            this._tbAvgWinOdds = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._tbWinPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._tbWinnerCount = new System.Windows.Forms.TextBox();
            this._tbNumberOfStarters = new System.Windows.Forms.TextBox();
            this._gridFactorsStatistics = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSummary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridFactorsStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 302);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(761, 336);
            this._grid.TabIndex = 0;
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellClick);
            // 
            // _tbTrainerName
            // 
            this._tbTrainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrainerName.Location = new System.Drawing.Point(12, 26);
            this._tbTrainerName.Name = "_tbTrainerName";
            this._tbTrainerName.ReadOnly = true;
            this._tbTrainerName.Size = new System.Drawing.Size(241, 24);
            this._tbTrainerName.TabIndex = 1;
            this._tbTrainerName.Text = "Todd Pletcher";
            // 
            // _tbFactorName
            // 
            this._tbFactorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbFactorName.Location = new System.Drawing.Point(15, 76);
            this._tbFactorName.Name = "_tbFactorName";
            this._tbFactorName.ReadOnly = true;
            this._tbFactorName.Size = new System.Drawing.Size(241, 24);
            this._tbFactorName.TabIndex = 2;
            this._tbFactorName.Text = "FirstTimeOut";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trainer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Factor";
            // 
            // _buttonClose
            // 
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonClose.Location = new System.Drawing.Point(1079, 32);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(141, 56);
            this._buttonClose.TabIndex = 19;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            // 
            // _gridSummary
            // 
            this._gridSummary.AllowUserToAddRows = false;
            this._gridSummary.AllowUserToDeleteRows = false;
            this._gridSummary.AllowUserToResizeColumns = false;
            this._gridSummary.AllowUserToResizeRows = false;
            this._gridSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this._gridSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridSummary.Location = new System.Drawing.Point(294, 26);
            this._gridSummary.Name = "_gridSummary";
            this._gridSummary.ReadOnly = true;
            this._gridSummary.RowHeadersVisible = false;
            this._gridSummary.Size = new System.Drawing.Size(638, 141);
            this._gridSummary.TabIndex = 20;
            // 
            // _cbMCL
            // 
            this._cbMCL.AutoSize = true;
            this._cbMCL.Checked = true;
            this._cbMCL.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbMCL.Location = new System.Drawing.Point(22, 19);
            this._cbMCL.Name = "_cbMCL";
            this._cbMCL.Size = new System.Drawing.Size(48, 17);
            this._cbMCL.TabIndex = 21;
            this._cbMCL.Text = "MCL";
            this._cbMCL.UseVisualStyleBackColor = true;
            this._cbMCL.CheckedChanged += new System.EventHandler(this._cbMCL_CheckedChanged);
            // 
            // _cbMSW
            // 
            this._cbMSW.AutoSize = true;
            this._cbMSW.Checked = true;
            this._cbMSW.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbMSW.Location = new System.Drawing.Point(133, 19);
            this._cbMSW.Name = "_cbMSW";
            this._cbMSW.Size = new System.Drawing.Size(53, 17);
            this._cbMSW.TabIndex = 22;
            this._cbMSW.Text = "MSW";
            this._cbMSW.UseVisualStyleBackColor = true;
            this._cbMSW.CheckedChanged += new System.EventHandler(this._cbMSW_CheckedChanged);
            // 
            // _cbCLM
            // 
            this._cbCLM.AutoSize = true;
            this._cbCLM.Checked = true;
            this._cbCLM.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbCLM.Location = new System.Drawing.Point(241, 19);
            this._cbCLM.Name = "_cbCLM";
            this._cbCLM.Size = new System.Drawing.Size(48, 17);
            this._cbCLM.TabIndex = 23;
            this._cbCLM.Text = "CLM";
            this._cbCLM.UseVisualStyleBackColor = true;
            this._cbCLM.CheckedChanged += new System.EventHandler(this._cbCLM_CheckedChanged);
            // 
            // _cbAlw
            // 
            this._cbAlw.AutoSize = true;
            this._cbAlw.Checked = true;
            this._cbAlw.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbAlw.Location = new System.Drawing.Point(349, 19);
            this._cbAlw.Name = "_cbAlw";
            this._cbAlw.Size = new System.Drawing.Size(76, 17);
            this._cbAlw.TabIndex = 24;
            this._cbAlw.Text = "ALW/OCL";
            this._cbAlw.UseVisualStyleBackColor = true;
            this._cbAlw.CheckedChanged += new System.EventHandler(this._cbAlw_CheckedChanged);
            // 
            // _cbStakes
            // 
            this._cbStakes.AutoSize = true;
            this._cbStakes.Checked = true;
            this._cbStakes.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbStakes.Location = new System.Drawing.Point(470, 19);
            this._cbStakes.Name = "_cbStakes";
            this._cbStakes.Size = new System.Drawing.Size(59, 17);
            this._cbStakes.TabIndex = 25;
            this._cbStakes.Text = "Stakes";
            this._cbStakes.UseVisualStyleBackColor = true;
            this._cbStakes.CheckedChanged += new System.EventHandler(this._cbStakes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._tbTurfWinPercent);
            this.groupBox1.Controls.Add(this._tbDirtWinPercent);
            this.groupBox1.Controls.Add(this._cbTurf);
            this.groupBox1.Controls.Add(this._tbStakesWinPercent);
            this.groupBox1.Controls.Add(this._cbDirt);
            this.groupBox1.Controls.Add(this._tbALWWinPercent);
            this.groupBox1.Controls.Add(this._tbCLMWinPercent);
            this.groupBox1.Controls.Add(this._tbMSWWinPercent);
            this.groupBox1.Controls.Add(this._tbMCLWinPercent);
            this.groupBox1.Controls.Add(this._cbMSW);
            this.groupBox1.Controls.Add(this._cbStakes);
            this.groupBox1.Controls.Add(this._cbMCL);
            this.groupBox1.Controls.Add(this._cbAlw);
            this.groupBox1.Controls.Add(this._cbCLM);
            this.groupBox1.Location = new System.Drawing.Point(15, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 50);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Of Races";
            // 
            // _tbTurfWinPercent
            // 
            this._tbTurfWinPercent.Location = new System.Drawing.Point(778, 17);
            this._tbTurfWinPercent.Name = "_tbTurfWinPercent";
            this._tbTurfWinPercent.ReadOnly = true;
            this._tbTurfWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbTurfWinPercent.TabIndex = 32;
            // 
            // _tbDirtWinPercent
            // 
            this._tbDirtWinPercent.Location = new System.Drawing.Point(652, 18);
            this._tbDirtWinPercent.Name = "_tbDirtWinPercent";
            this._tbDirtWinPercent.ReadOnly = true;
            this._tbDirtWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbDirtWinPercent.TabIndex = 30;
            // 
            // _cbTurf
            // 
            this._cbTurf.AutoSize = true;
            this._cbTurf.Checked = true;
            this._cbTurf.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbTurf.Location = new System.Drawing.Point(713, 19);
            this._cbTurf.Name = "_cbTurf";
            this._cbTurf.Size = new System.Drawing.Size(45, 17);
            this._cbTurf.TabIndex = 31;
            this._cbTurf.Text = "Turf";
            this._cbTurf.UseVisualStyleBackColor = true;
            this._cbTurf.CheckedChanged += new System.EventHandler(this._cbTurf_CheckedChanged);
            // 
            // _tbStakesWinPercent
            // 
            this._tbStakesWinPercent.Location = new System.Drawing.Point(535, 17);
            this._tbStakesWinPercent.Name = "_tbStakesWinPercent";
            this._tbStakesWinPercent.ReadOnly = true;
            this._tbStakesWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbStakesWinPercent.TabIndex = 28;
            // 
            // _cbDirt
            // 
            this._cbDirt.AutoSize = true;
            this._cbDirt.Checked = true;
            this._cbDirt.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbDirt.Location = new System.Drawing.Point(587, 20);
            this._cbDirt.Name = "_cbDirt";
            this._cbDirt.Size = new System.Drawing.Size(42, 17);
            this._cbDirt.TabIndex = 29;
            this._cbDirt.Text = "Dirt";
            this._cbDirt.UseVisualStyleBackColor = true;
            this._cbDirt.CheckedChanged += new System.EventHandler(this._cbDirt_CheckedChanged);
            // 
            // _tbALWWinPercent
            // 
            this._tbALWWinPercent.Location = new System.Drawing.Point(422, 18);
            this._tbALWWinPercent.Name = "_tbALWWinPercent";
            this._tbALWWinPercent.ReadOnly = true;
            this._tbALWWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbALWWinPercent.TabIndex = 28;
            // 
            // _tbCLMWinPercent
            // 
            this._tbCLMWinPercent.Location = new System.Drawing.Point(295, 16);
            this._tbCLMWinPercent.Name = "_tbCLMWinPercent";
            this._tbCLMWinPercent.ReadOnly = true;
            this._tbCLMWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbCLMWinPercent.TabIndex = 28;
            // 
            // _tbMSWWinPercent
            // 
            this._tbMSWWinPercent.Location = new System.Drawing.Point(181, 16);
            this._tbMSWWinPercent.Name = "_tbMSWWinPercent";
            this._tbMSWWinPercent.ReadOnly = true;
            this._tbMSWWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbMSWWinPercent.TabIndex = 27;
            // 
            // _tbMCLWinPercent
            // 
            this._tbMCLWinPercent.Location = new System.Drawing.Point(76, 18);
            this._tbMCLWinPercent.Name = "_tbMCLWinPercent";
            this._tbMCLWinPercent.ReadOnly = true;
            this._tbMCLWinPercent.Size = new System.Drawing.Size(42, 20);
            this._tbMCLWinPercent.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._tbWinStdDev);
            this.groupBox2.Controls.Add(this._tbAvgWinOdds);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this._tbWinPercent);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._tbWinnerCount);
            this.groupBox2.Controls.Add(this._tbNumberOfStarters);
            this.groupBox2.Location = new System.Drawing.Point(910, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 60);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Win StdDev";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Avg Win Odds";
            // 
            // _tbWinStdDev
            // 
            this._tbWinStdDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbWinStdDev.Location = new System.Drawing.Point(327, 26);
            this._tbWinStdDev.Name = "_tbWinStdDev";
            this._tbWinStdDev.ReadOnly = true;
            this._tbWinStdDev.Size = new System.Drawing.Size(74, 26);
            this._tbWinStdDev.TabIndex = 35;
            this._tbWinStdDev.Text = "12343";
            // 
            // _tbAvgWinOdds
            // 
            this._tbAvgWinOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAvgWinOdds.Location = new System.Drawing.Point(246, 26);
            this._tbAvgWinOdds.Name = "_tbAvgWinOdds";
            this._tbAvgWinOdds.ReadOnly = true;
            this._tbAvgWinOdds.Size = new System.Drawing.Size(74, 26);
            this._tbAvgWinOdds.TabIndex = 33;
            this._tbAvgWinOdds.Text = "12343";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Win %";
            // 
            // _tbWinPercent
            // 
            this._tbWinPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbWinPercent.Location = new System.Drawing.Point(166, 28);
            this._tbWinPercent.Name = "_tbWinPercent";
            this._tbWinPercent.ReadOnly = true;
            this._tbWinPercent.Size = new System.Drawing.Size(74, 26);
            this._tbWinPercent.TabIndex = 31;
            this._tbWinPercent.Text = "12343";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Winners";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Starters";
            // 
            // _tbWinnerCount
            // 
            this._tbWinnerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbWinnerCount.Location = new System.Drawing.Point(86, 29);
            this._tbWinnerCount.Name = "_tbWinnerCount";
            this._tbWinnerCount.ReadOnly = true;
            this._tbWinnerCount.Size = new System.Drawing.Size(74, 26);
            this._tbWinnerCount.TabIndex = 28;
            this._tbWinnerCount.Text = "12343";
            // 
            // _tbNumberOfStarters
            // 
            this._tbNumberOfStarters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfStarters.Location = new System.Drawing.Point(6, 28);
            this._tbNumberOfStarters.Name = "_tbNumberOfStarters";
            this._tbNumberOfStarters.ReadOnly = true;
            this._tbNumberOfStarters.Size = new System.Drawing.Size(74, 26);
            this._tbNumberOfStarters.TabIndex = 0;
            this._tbNumberOfStarters.Text = "12343";
            // 
            // _gridFactorsStatistics
            // 
            this._gridFactorsStatistics.AllowUserToAddRows = false;
            this._gridFactorsStatistics.AllowUserToDeleteRows = false;
            this._gridFactorsStatistics.AllowUserToResizeColumns = false;
            this._gridFactorsStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridFactorsStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridFactorsStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridFactorsStatistics.DefaultCellStyle = dataGridViewCellStyle1;
            this._gridFactorsStatistics.Location = new System.Drawing.Point(793, 302);
            this._gridFactorsStatistics.Name = "_gridFactorsStatistics";
            this._gridFactorsStatistics.ReadOnly = true;
            this._gridFactorsStatistics.RowHeadersVisible = false;
            this._gridFactorsStatistics.Size = new System.Drawing.Size(539, 336);
            this._gridFactorsStatistics.TabIndex = 28;
            this._gridFactorsStatistics.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridFactorsStatistics_CellClick);
            // 
            // FactorStatsPerTrainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 650);
            this.Controls.Add(this._gridFactorsStatistics);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._gridSummary);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbFactorName);
            this.Controls.Add(this._tbTrainerName);
            this.Controls.Add(this._grid);
            this.Name = "FactorStatsPerTrainerForm";
            this.Text = "FactorStatsPerTrainerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FactorStatsPerTrainerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSummary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridFactorsStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _tbTrainerName;
        private System.Windows.Forms.TextBox _tbFactorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.DataGridView _gridSummary;
        private System.Windows.Forms.CheckBox _cbMCL;
        private System.Windows.Forms.CheckBox _cbMSW;
        private System.Windows.Forms.CheckBox _cbCLM;
        private System.Windows.Forms.CheckBox _cbAlw;
        private System.Windows.Forms.CheckBox _cbStakes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _tbNumberOfStarters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _tbWinPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbWinnerCount;
        private System.Windows.Forms.TextBox _tbStakesWinPercent;
        private System.Windows.Forms.TextBox _tbALWWinPercent;
        private System.Windows.Forms.TextBox _tbCLMWinPercent;
        private System.Windows.Forms.TextBox _tbMSWWinPercent;
        private System.Windows.Forms.TextBox _tbMCLWinPercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbAvgWinOdds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbWinStdDev;
        private System.Windows.Forms.TextBox _tbTurfWinPercent;
        private System.Windows.Forms.TextBox _tbDirtWinPercent;
        private System.Windows.Forms.CheckBox _cbTurf;
        private System.Windows.Forms.CheckBox _cbDirt;
        private System.Windows.Forms.DataGridView _gridFactorsStatistics;
    }
}