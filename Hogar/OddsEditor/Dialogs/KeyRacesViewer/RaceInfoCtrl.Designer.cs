namespace OddsEditor.Dialogs.KeyRacesViewer
{
    partial class RaceInfoCtrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._labelGoldenPaceFigure = new System.Windows.Forms.Label();
            this._labelGoldenFigure = new System.Windows.Forms.Label();
            this._labelDaysSinceThisRace = new System.Windows.Forms.Label();
            this._tbTrackCode = new System.Windows.Forms.TextBox();
            this._tbDate = new System.Windows.Forms.TextBox();
            this._tbDistance = new System.Windows.Forms.TextBox();
            this._tbSurface = new System.Windows.Forms.TextBox();
            this._tbTrackCondition = new System.Windows.Forms.TextBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._tbRaceClassification = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _labelGoldenPaceFigure
            // 
            this._labelGoldenPaceFigure.AutoSize = true;
            this._labelGoldenPaceFigure.BackColor = System.Drawing.Color.Cyan;
            this._labelGoldenPaceFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelGoldenPaceFigure.ForeColor = System.Drawing.Color.Black;
            this._labelGoldenPaceFigure.Location = new System.Drawing.Point(628, 4);
            this._labelGoldenPaceFigure.Name = "_labelGoldenPaceFigure";
            this._labelGoldenPaceFigure.Size = new System.Drawing.Size(46, 31);
            this._labelGoldenPaceFigure.TabIndex = 1;
            this._labelGoldenPaceFigure.Text = "25";
            // 
            // _labelGoldenFigure
            // 
            this._labelGoldenFigure.AutoSize = true;
            this._labelGoldenFigure.BackColor = System.Drawing.Color.Black;
            this._labelGoldenFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelGoldenFigure.ForeColor = System.Drawing.Color.White;
            this._labelGoldenFigure.Location = new System.Drawing.Point(565, 4);
            this._labelGoldenFigure.Name = "_labelGoldenFigure";
            this._labelGoldenFigure.Size = new System.Drawing.Size(62, 31);
            this._labelGoldenFigure.TabIndex = 2;
            this._labelGoldenFigure.Text = "155";
            // 
            // _labelDaysSinceThisRace
            // 
            this._labelDaysSinceThisRace.AutoSize = true;
            this._labelDaysSinceThisRace.BackColor = System.Drawing.Color.Red;
            this._labelDaysSinceThisRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelDaysSinceThisRace.ForeColor = System.Drawing.Color.Black;
            this._labelDaysSinceThisRace.Location = new System.Drawing.Point(680, 4);
            this._labelDaysSinceThisRace.Name = "_labelDaysSinceThisRace";
            this._labelDaysSinceThisRace.Size = new System.Drawing.Size(46, 31);
            this._labelDaysSinceThisRace.TabIndex = 5;
            this._labelDaysSinceThisRace.Text = "25";
            // 
            // _tbTrackCode
            // 
            this._tbTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackCode.Location = new System.Drawing.Point(9, 4);
            this._tbTrackCode.Name = "_tbTrackCode";
            this._tbTrackCode.ReadOnly = true;
            this._tbTrackCode.Size = new System.Drawing.Size(40, 22);
            this._tbTrackCode.TabIndex = 9;
            this._tbTrackCode.Text = "AQU";
            // 
            // _tbDate
            // 
            this._tbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDate.Location = new System.Drawing.Point(61, 4);
            this._tbDate.Name = "_tbDate";
            this._tbDate.ReadOnly = true;
            this._tbDate.Size = new System.Drawing.Size(91, 22);
            this._tbDate.TabIndex = 10;
            this._tbDate.Text = "02/12/2010";
            // 
            // _tbDistance
            // 
            this._tbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDistance.Location = new System.Drawing.Point(158, 4);
            this._tbDistance.Name = "_tbDistance";
            this._tbDistance.ReadOnly = true;
            this._tbDistance.Size = new System.Drawing.Size(50, 22);
            this._tbDistance.TabIndex = 11;
            this._tbDistance.Text = "AQU";
            // 
            // _tbSurface
            // 
            this._tbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSurface.Location = new System.Drawing.Point(218, 4);
            this._tbSurface.Name = "_tbSurface";
            this._tbSurface.ReadOnly = true;
            this._tbSurface.Size = new System.Drawing.Size(29, 22);
            this._tbSurface.TabIndex = 12;
            this._tbSurface.Text = "D";
            // 
            // _tbTrackCondition
            // 
            this._tbTrackCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackCondition.Location = new System.Drawing.Point(256, 4);
            this._tbTrackCondition.Name = "_tbTrackCondition";
            this._tbTrackCondition.ReadOnly = true;
            this._tbTrackCondition.Size = new System.Drawing.Size(40, 22);
            this._tbTrackCondition.TabIndex = 13;
            this._tbTrackCondition.Text = "SY";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this._grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.ColumnHeadersVisible = false;
            this._grid.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle3;
            this._grid.GridColor = System.Drawing.SystemColors.Window;
            this._grid.Location = new System.Drawing.Point(1, 47);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(775, 109);
            this._grid.TabIndex = 14;
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._grid_CellFormatting);
            // 
            // _tbRaceClassification
            // 
            this._tbRaceClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbRaceClassification.Location = new System.Drawing.Point(318, 4);
            this._tbRaceClassification.Name = "_tbRaceClassification";
            this._tbRaceClassification.ReadOnly = true;
            this._tbRaceClassification.Size = new System.Drawing.Size(168, 22);
            this._tbRaceClassification.TabIndex = 15;
            this._tbRaceClassification.Text = "SY";
            // 
            // RaceInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._tbRaceClassification);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._tbTrackCondition);
            this.Controls.Add(this._tbSurface);
            this.Controls.Add(this._tbDistance);
            this.Controls.Add(this._tbDate);
            this.Controls.Add(this._tbTrackCode);
            this.Controls.Add(this._labelDaysSinceThisRace);
            this.Controls.Add(this._labelGoldenFigure);
            this.Controls.Add(this._labelGoldenPaceFigure);
            this.Name = "RaceInfoCtrl";
            this.Size = new System.Drawing.Size(777, 168);
            this.Load += new System.EventHandler(this.RaceInfoCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelGoldenPaceFigure;
        private System.Windows.Forms.Label _labelGoldenFigure;
        private System.Windows.Forms.Label _labelDaysSinceThisRace;
        private System.Windows.Forms.TextBox _tbTrackCode;
        private System.Windows.Forms.TextBox _tbDate;
        private System.Windows.Forms.TextBox _tbDistance;
        private System.Windows.Forms.TextBox _tbSurface;
        private System.Windows.Forms.TextBox _tbTrackCondition;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _tbRaceClassification;
    }
}
