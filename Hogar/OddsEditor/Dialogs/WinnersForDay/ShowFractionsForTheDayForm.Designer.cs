namespace OddsEditor.Dialogs.WinnersForDay
{
    partial class ShowFractionsForTheDayForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grid = new System.Windows.Forms.DataGridView();
            this._labelCardInfo = new System.Windows.Forms.Label();
            this._buttonClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._tbNumberOfRaces = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._buttonAlAvailableRaces = new System.Windows.Forms.Button();
            this._buttonDefaultPeriod = new System.Windows.Forms.Button();
            this._periodSelector = new HogarControlLibrary.PeriodSelector();
            this._tbSurface = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._tbDistance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._labelCount = new System.Windows.Forms.Label();
            this._gridShowAllRacesForTheDistance = new System.Windows.Forms.DataGridView();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._timeComparisonCtrl = new OddsEditor.Dialogs.WinnersForDay.TimeComparisonCtrl();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridShowAllRacesForTheDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grid.ShowCellToolTips = false;
            this._grid.Size = new System.Drawing.Size(1233, 308);
            this._grid.TabIndex = 0;
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridCellClick);
            // 
            // _labelCardInfo
            // 
            this._labelCardInfo.AutoSize = true;
            this._labelCardInfo.BackColor = System.Drawing.Color.PaleTurquoise;
            this._labelCardInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelCardInfo.ForeColor = System.Drawing.Color.Blue;
            this._labelCardInfo.Location = new System.Drawing.Point(13, 13);
            this._labelCardInfo.Name = "_labelCardInfo";
            this._labelCardInfo.Size = new System.Drawing.Size(86, 31);
            this._labelCardInfo.TabIndex = 1;
            this._labelCardInfo.Text = "label1";
            // 
            // _buttonClose
            // 
            this._buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonClose.Location = new System.Drawing.Point(1124, 8);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(110, 53);
            this._buttonClose.TabIndex = 2;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.OnClose);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(19, 71);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._grid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._tbNumberOfRaces);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this._buttonAlAvailableRaces);
            this.splitContainer1.Panel2.Controls.Add(this._buttonDefaultPeriod);
            this.splitContainer1.Panel2.Controls.Add(this._timeComparisonCtrl);
            this.splitContainer1.Panel2.Controls.Add(this._periodSelector);
            this.splitContainer1.Panel2.Controls.Add(this._tbSurface);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this._tbDistance);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this._labelCount);
            this.splitContainer1.Panel2.Controls.Add(this._gridShowAllRacesForTheDistance);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 790);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 3;
            // 
            // _tbNumberOfRaces
            // 
            this._tbNumberOfRaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfRaces.Location = new System.Drawing.Point(510, 10);
            this._tbNumberOfRaces.Name = "_tbNumberOfRaces";
            this._tbNumberOfRaces.ReadOnly = true;
            this._tbNumberOfRaces.Size = new System.Drawing.Size(58, 31);
            this._tbNumberOfRaces.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Count";
            // 
            // _buttonAlAvailableRaces
            // 
            this._buttonAlAvailableRaces.Location = new System.Drawing.Point(143, 56);
            this._buttonAlAvailableRaces.Name = "_buttonAlAvailableRaces";
            this._buttonAlAvailableRaces.Size = new System.Drawing.Size(114, 23);
            this._buttonAlAvailableRaces.TabIndex = 20;
            this._buttonAlAvailableRaces.Text = "All Available Races";
            this._buttonAlAvailableRaces.UseVisualStyleBackColor = true;
            this._buttonAlAvailableRaces.Click += new System.EventHandler(this.OnSelectAllAlAvailableRaces);
            // 
            // _buttonDefaultPeriod
            // 
            this._buttonDefaultPeriod.Location = new System.Drawing.Point(18, 56);
            this._buttonDefaultPeriod.Name = "_buttonDefaultPeriod";
            this._buttonDefaultPeriod.Size = new System.Drawing.Size(114, 23);
            this._buttonDefaultPeriod.TabIndex = 19;
            this._buttonDefaultPeriod.Text = "Default Period";
            this._buttonDefaultPeriod.UseVisualStyleBackColor = true;
            this._buttonDefaultPeriod.Click += new System.EventHandler(this.OnSelectDefaultPeriodOnly);
            // 
            // _periodSelector
            // 
            this._periodSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._periodSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._periodSelector.Location = new System.Drawing.Point(665, 7);
            this._periodSelector.Name = "_periodSelector";
            this._periodSelector.Size = new System.Drawing.Size(550, 94);
            this._periodSelector.TabIndex = 17;
            this._periodSelector.OnPeriodChanged += new System.EventHandler(this.OnPeriodChanged);
            // 
            // _tbSurface
            // 
            this._tbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSurface.Location = new System.Drawing.Point(342, 10);
            this._tbSurface.Name = "_tbSurface";
            this._tbSurface.ReadOnly = true;
            this._tbSurface.Size = new System.Drawing.Size(58, 31);
            this._tbSurface.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Surface";
            // 
            // _tbDistance
            // 
            this._tbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDistance.Location = new System.Drawing.Point(89, 10);
            this._tbDistance.Name = "_tbDistance";
            this._tbDistance.ReadOnly = true;
            this._tbDistance.Size = new System.Drawing.Size(168, 31);
            this._tbDistance.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Distance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(945, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number of Races";
            // 
            // _labelCount
            // 
            this._labelCount.AutoSize = true;
            this._labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelCount.Location = new System.Drawing.Point(1048, 432);
            this._labelCount.Name = "_labelCount";
            this._labelCount.Size = new System.Drawing.Size(27, 29);
            this._labelCount.TabIndex = 8;
            this._labelCount.Text = "0";
            // 
            // _gridShowAllRacesForTheDistance
            // 
            this._gridShowAllRacesForTheDistance.AllowUserToAddRows = false;
            this._gridShowAllRacesForTheDistance.AllowUserToDeleteRows = false;
            this._gridShowAllRacesForTheDistance.AllowUserToOrderColumns = true;
            this._gridShowAllRacesForTheDistance.AllowUserToResizeColumns = false;
            this._gridShowAllRacesForTheDistance.AllowUserToResizeRows = false;
            this._gridShowAllRacesForTheDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridShowAllRacesForTheDistance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this._gridShowAllRacesForTheDistance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridShowAllRacesForTheDistance.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridShowAllRacesForTheDistance.Location = new System.Drawing.Point(0, 107);
            this._gridShowAllRacesForTheDistance.Name = "_gridShowAllRacesForTheDistance";
            this._gridShowAllRacesForTheDistance.ReadOnly = true;
            this._gridShowAllRacesForTheDistance.RowHeadersVisible = false;
            this._gridShowAllRacesForTheDistance.ShowCellToolTips = false;
            this._gridShowAllRacesForTheDistance.Size = new System.Drawing.Size(911, 371);
            this._gridShowAllRacesForTheDistance.TabIndex = 1;
            this._gridShowAllRacesForTheDistance.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.OnSortCompare);
            this._gridShowAllRacesForTheDistance.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridShowAllRacesForTheDistanceCellDoubleClick);
            this._gridShowAllRacesForTheDistance.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnMouseEnteredInAHorseNameCell);
            // 
            // _timeComparisonCtrl
            // 
            this._timeComparisonCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._timeComparisonCtrl.Location = new System.Drawing.Point(931, 171);
            this._timeComparisonCtrl.Name = "_timeComparisonCtrl";
            this._timeComparisonCtrl.Size = new System.Drawing.Size(284, 258);
            this._timeComparisonCtrl.TabIndex = 18;
            // 
            // ShowFractionsForTheDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 894);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._labelCardInfo);
            this.DoubleBuffered = true;
            this.Name = "ShowFractionsForTheDayForm";
            this.ShowInTaskbar = false;
            this.Text = "Daily Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridShowAllRacesForTheDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label _labelCardInfo;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView _gridShowAllRacesForTheDistance;
        private System.Windows.Forms.Label _labelCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.TextBox _tbSurface;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _tbDistance;
        private System.Windows.Forms.Label label4;
        private HogarControlLibrary.PeriodSelector _periodSelector;
        private TimeComparisonCtrl _timeComparisonCtrl;
        private System.Windows.Forms.Button _buttonDefaultPeriod;
        private System.Windows.Forms.Button _buttonAlAvailableRaces;
        private System.Windows.Forms.TextBox _tbNumberOfRaces;
        private System.Windows.Forms.Label label1;
    }
}