namespace OddsEditor.Dialogs
{
    partial class TrainerStatisticsSummaryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._grid = new System.Windows.Forms.DataGridView();
            this._panelTrainerName = new System.Windows.Forms.Panel();
            this._labelTrainerName = new System.Windows.Forms.Label();
            this._gridStarters = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this._panelTrainerName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridStarters)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._grid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._panelTrainerName);
            this.splitContainer1.Panel2.Controls.Add(this._gridStarters);
            this.splitContainer1.Size = new System.Drawing.Size(1113, 800);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 0;
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(1113, 474);
            this._grid.TabIndex = 0;
            this._grid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnShowTrainerStarters);
            // 
            // _panelTrainerName
            // 
            this._panelTrainerName.BackColor = System.Drawing.Color.DodgerBlue;
            this._panelTrainerName.Controls.Add(this._labelTrainerName);
            this._panelTrainerName.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelTrainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._panelTrainerName.ForeColor = System.Drawing.Color.White;
            this._panelTrainerName.Location = new System.Drawing.Point(0, 0);
            this._panelTrainerName.Name = "_panelTrainerName";
            this._panelTrainerName.Size = new System.Drawing.Size(1113, 46);
            this._panelTrainerName.TabIndex = 1;
            // 
            // _labelTrainerName
            // 
            this._labelTrainerName.AutoSize = true;
            this._labelTrainerName.Location = new System.Drawing.Point(13, 4);
            this._labelTrainerName.Name = "_labelTrainerName";
            this._labelTrainerName.Size = new System.Drawing.Size(0, 31);
            this._labelTrainerName.TabIndex = 0;
            // 
            // _gridStarters
            // 
            this._gridStarters.AllowUserToAddRows = false;
            this._gridStarters.AllowUserToDeleteRows = false;
            this._gridStarters.AllowUserToOrderColumns = true;
            this._gridStarters.AllowUserToResizeColumns = false;
            this._gridStarters.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this._gridStarters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this._gridStarters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridStarters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridStarters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridStarters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridStarters.DefaultCellStyle = dataGridViewCellStyle3;
            this._gridStarters.Location = new System.Drawing.Point(0, 49);
            this._gridStarters.MultiSelect = false;
            this._gridStarters.Name = "_gridStarters";
            this._gridStarters.ReadOnly = true;
            this._gridStarters.RowHeadersVisible = false;
            this._gridStarters.Size = new System.Drawing.Size(1113, 270);
            this._gridStarters.TabIndex = 0;
            this._gridStarters.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.OnGridStartersSortCompare);
            this._gridStarters.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnGridStartersCellFormatting);
            // 
            // TrainerStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1113, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TrainerStatisticsForm";
            this.Text = "Trainer Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this._panelTrainerName.ResumeLayout(false);
            this._panelTrainerName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridStarters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridView _gridStarters;
        private System.Windows.Forms.Panel _panelTrainerName;
        private System.Windows.Forms.Label _labelTrainerName;

    }
}
