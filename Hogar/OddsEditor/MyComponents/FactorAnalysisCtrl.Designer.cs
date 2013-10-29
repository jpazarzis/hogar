namespace OddsEditor.MyComponents
{
    partial class FactorAnalysisCtrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grid = new System.Windows.Forms.DataGridView();
            this._tbTrainerName = new System.Windows.Forms.TextBox();
            this._buttonShowAllTrainerStats = new System.Windows.Forms.Button();
            this._tbJockeyName = new System.Windows.Forms.TextBox();
            this._tbJockeyStats = new System.Windows.Forms.TextBox();
            this._tbTrainersStatistics = new System.Windows.Forms.TextBox();
            this._tbJockeyTrainer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Location = new System.Drawing.Point(7, 60);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(477, 123);
            this._grid.TabIndex = 0;
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellClick);
            // 
            // _tbTrainerName
            // 
            this._tbTrainerName.Location = new System.Drawing.Point(12, 6);
            this._tbTrainerName.Name = "_tbTrainerName";
            this._tbTrainerName.ReadOnly = true;
            this._tbTrainerName.Size = new System.Drawing.Size(114, 20);
            this._tbTrainerName.TabIndex = 1;
            // 
            // _buttonShowAllTrainerStats
            // 
            this._buttonShowAllTrainerStats.Location = new System.Drawing.Point(314, 34);
            this._buttonShowAllTrainerStats.Name = "_buttonShowAllTrainerStats";
            this._buttonShowAllTrainerStats.Size = new System.Drawing.Size(166, 23);
            this._buttonShowAllTrainerStats.TabIndex = 6;
            this._buttonShowAllTrainerStats.Text = "View All Trainers";
            this._buttonShowAllTrainerStats.UseVisualStyleBackColor = true;
            this._buttonShowAllTrainerStats.Click += new System.EventHandler(this._buttonShowAllTrainerStats_Click);
            // 
            // _tbJockeyName
            // 
            this._tbJockeyName.Location = new System.Drawing.Point(12, 34);
            this._tbJockeyName.Name = "_tbJockeyName";
            this._tbJockeyName.ReadOnly = true;
            this._tbJockeyName.Size = new System.Drawing.Size(114, 20);
            this._tbJockeyName.TabIndex = 7;
            // 
            // _tbJockeyStats
            // 
            this._tbJockeyStats.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbJockeyStats.Location = new System.Drawing.Point(133, 34);
            this._tbJockeyStats.Name = "_tbJockeyStats";
            this._tbJockeyStats.ReadOnly = true;
            this._tbJockeyStats.Size = new System.Drawing.Size(170, 23);
            this._tbJockeyStats.TabIndex = 8;
            // 
            // _tbTrainersStatistics
            // 
            this._tbTrainersStatistics.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrainersStatistics.Location = new System.Drawing.Point(133, 8);
            this._tbTrainersStatistics.Name = "_tbTrainersStatistics";
            this._tbTrainersStatistics.ReadOnly = true;
            this._tbTrainersStatistics.Size = new System.Drawing.Size(170, 23);
            this._tbTrainersStatistics.TabIndex = 9;
            // 
            // _tbJockeyTrainer
            // 
            this._tbJockeyTrainer.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbJockeyTrainer.Location = new System.Drawing.Point(314, 8);
            this._tbJockeyTrainer.Name = "_tbJockeyTrainer";
            this._tbJockeyTrainer.ReadOnly = true;
            this._tbJockeyTrainer.Size = new System.Drawing.Size(170, 23);
            this._tbJockeyTrainer.TabIndex = 10;
            // 
            // FactorAnalysisCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tbJockeyTrainer);
            this.Controls.Add(this._tbTrainersStatistics);
            this.Controls.Add(this._tbJockeyStats);
            this.Controls.Add(this._tbJockeyName);
            this.Controls.Add(this._buttonShowAllTrainerStats);
            this.Controls.Add(this._tbTrainerName);
            this.Controls.Add(this._grid);
            this.Name = "FactorAnalysisCtrl";
            this.Size = new System.Drawing.Size(495, 189);
            this.Load += new System.EventHandler(this.FactorAnalysisCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _tbTrainerName;
        private System.Windows.Forms.Button _buttonShowAllTrainerStats;
        private System.Windows.Forms.TextBox _tbJockeyName;
        private System.Windows.Forms.TextBox _tbJockeyStats;
        private System.Windows.Forms.TextBox _tbTrainersStatistics;
        private System.Windows.Forms.TextBox _tbJockeyTrainer;
    }
}
