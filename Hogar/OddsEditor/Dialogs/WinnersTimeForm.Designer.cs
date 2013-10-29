namespace OddsEditor.Dialogs
{
    partial class WinnersTimeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grid = new System.Windows.Forms.DataGridView();
            this._gridPostPositionStats = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._comboBoxAboutFlag = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._gridWinnersMove = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this._gridStatsByTrackCondition = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._comboboxSurface = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._comboboxRaceTrack = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._comboBoxDistance = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txtboxFavoriteWinPercent = new System.Windows.Forms.TextBox();
            this._txtboxWinningFavorites = new System.Windows.Forms.TextBox();
            this._txtboxTotal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._txtboxWire2WirePercent = new System.Windows.Forms.TextBox();
            this._txtboxTotalWire2WireWinners = new System.Windows.Forms.TextBox();
            this._txtboxTotalRaces = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridPostPositionStats)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridWinnersMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridStatsByTrackCondition)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle2;
            this._grid.Location = new System.Drawing.Point(13, 45);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grid.Size = new System.Drawing.Size(1343, 319);
            this._grid.TabIndex = 0;
            this._grid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridCellMouseLeave);
            this._grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellMouseEnter);
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
            // 
            // _gridPostPositionStats
            // 
            this._gridPostPositionStats.AllowUserToAddRows = false;
            this._gridPostPositionStats.AllowUserToDeleteRows = false;
            this._gridPostPositionStats.AllowUserToOrderColumns = true;
            this._gridPostPositionStats.AllowUserToResizeColumns = false;
            this._gridPostPositionStats.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this._gridPostPositionStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._gridPostPositionStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridPostPositionStats.BackgroundColor = System.Drawing.Color.SkyBlue;
            this._gridPostPositionStats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridPostPositionStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridPostPositionStats.Location = new System.Drawing.Point(13, 87);
            this._gridPostPositionStats.Name = "_gridPostPositionStats";
            this._gridPostPositionStats.RowHeadersVisible = false;
            this._gridPostPositionStats.Size = new System.Drawing.Size(442, 268);
            this._gridPostPositionStats.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Post Position Statistics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Winners For This Distance";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this._gridWinnersMove);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this._gridStatsByTrackCondition);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this._gridPostPositionStats);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.splitContainer1.Panel2.Controls.Add(this._grid);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1361, 744);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._comboBoxAboutFlag);
            this.groupBox6.Location = new System.Drawing.Point(654, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(83, 45);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "About Flag";
            // 
            // _comboBoxAboutFlag
            // 
            this._comboBoxAboutFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxAboutFlag.FormattingEnabled = true;
            this._comboBoxAboutFlag.Location = new System.Drawing.Point(6, 19);
            this._comboBoxAboutFlag.Name = "_comboBoxAboutFlag";
            this._comboBoxAboutFlag.Size = new System.Drawing.Size(68, 21);
            this._comboBoxAboutFlag.TabIndex = 11;
            this._comboBoxAboutFlag.SelectedIndexChanged += new System.EventHandler(this.OnAboutFlagChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(880, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Winners Move Factors";
            // 
            // _gridWinnersMove
            // 
            this._gridWinnersMove.AllowUserToAddRows = false;
            this._gridWinnersMove.AllowUserToDeleteRows = false;
            this._gridWinnersMove.AllowUserToOrderColumns = true;
            this._gridWinnersMove.AllowUserToResizeColumns = false;
            this._gridWinnersMove.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            this._gridWinnersMove.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this._gridWinnersMove.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridWinnersMove.BackgroundColor = System.Drawing.Color.SkyBlue;
            this._gridWinnersMove.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridWinnersMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridWinnersMove.Location = new System.Drawing.Point(884, 87);
            this._gridWinnersMove.Name = "_gridWinnersMove";
            this._gridWinnersMove.RowHeadersVisible = false;
            this._gridWinnersMove.Size = new System.Drawing.Size(398, 268);
            this._gridWinnersMove.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(481, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Statistics By Track Condition";
            // 
            // _gridStatsByTrackCondition
            // 
            this._gridStatsByTrackCondition.AllowUserToAddRows = false;
            this._gridStatsByTrackCondition.AllowUserToDeleteRows = false;
            this._gridStatsByTrackCondition.AllowUserToOrderColumns = true;
            this._gridStatsByTrackCondition.AllowUserToResizeColumns = false;
            this._gridStatsByTrackCondition.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            this._gridStatsByTrackCondition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._gridStatsByTrackCondition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridStatsByTrackCondition.BackgroundColor = System.Drawing.Color.SkyBlue;
            this._gridStatsByTrackCondition.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridStatsByTrackCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridStatsByTrackCondition.Location = new System.Drawing.Point(485, 87);
            this._gridStatsByTrackCondition.Name = "_gridStatsByTrackCondition";
            this._gridStatsByTrackCondition.RowHeadersVisible = false;
            this._gridStatsByTrackCondition.Size = new System.Drawing.Size(398, 268);
            this._gridStatsByTrackCondition.TabIndex = 18;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._comboboxSurface);
            this.groupBox5.Location = new System.Drawing.Point(555, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(83, 45);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Surface";
            // 
            // _comboboxSurface
            // 
            this._comboboxSurface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboboxSurface.FormattingEnabled = true;
            this._comboboxSurface.Location = new System.Drawing.Point(6, 19);
            this._comboboxSurface.Name = "_comboboxSurface";
            this._comboboxSurface.Size = new System.Drawing.Size(68, 21);
            this._comboboxSurface.TabIndex = 11;
            this._comboboxSurface.SelectedIndexChanged += new System.EventHandler(this.OnSelectedSurfaceChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._comboboxRaceTrack);
            this.groupBox4.Location = new System.Drawing.Point(392, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 45);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Race Track";
            // 
            // _comboboxRaceTrack
            // 
            this._comboboxRaceTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboboxRaceTrack.FormattingEnabled = true;
            this._comboboxRaceTrack.Location = new System.Drawing.Point(6, 19);
            this._comboboxRaceTrack.Name = "_comboboxRaceTrack";
            this._comboboxRaceTrack.Size = new System.Drawing.Size(147, 21);
            this._comboboxRaceTrack.TabIndex = 15;
            this._comboboxRaceTrack.SelectedIndexChanged += new System.EventHandler(this.OnSelectedRaceTrackChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._comboBoxDistance);
            this.groupBox3.Location = new System.Drawing.Point(305, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(83, 45);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Distance";
            // 
            // _comboBoxDistance
            // 
            this._comboBoxDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxDistance.FormattingEnabled = true;
            this._comboBoxDistance.Location = new System.Drawing.Point(6, 19);
            this._comboBoxDistance.Name = "_comboBoxDistance";
            this._comboBoxDistance.Size = new System.Drawing.Size(68, 21);
            this._comboBoxDistance.TabIndex = 11;
            this._comboBoxDistance.SelectedIndexChanged += new System.EventHandler(this.OnSelectedDistanceChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtboxFavoriteWinPercent);
            this.groupBox2.Controls.Add(this._txtboxWinningFavorites);
            this.groupBox2.Controls.Add(this._txtboxTotal);
            this.groupBox2.Location = new System.Drawing.Point(159, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 44);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Favorite Winnings";
            // 
            // _txtboxFavoriteWinPercent
            // 
            this._txtboxFavoriteWinPercent.Location = new System.Drawing.Point(95, 18);
            this._txtboxFavoriteWinPercent.Name = "_txtboxFavoriteWinPercent";
            this._txtboxFavoriteWinPercent.ReadOnly = true;
            this._txtboxFavoriteWinPercent.Size = new System.Drawing.Size(40, 20);
            this._txtboxFavoriteWinPercent.TabIndex = 11;
            // 
            // _txtboxWinningFavorites
            // 
            this._txtboxWinningFavorites.Location = new System.Drawing.Point(6, 18);
            this._txtboxWinningFavorites.Name = "_txtboxWinningFavorites";
            this._txtboxWinningFavorites.ReadOnly = true;
            this._txtboxWinningFavorites.Size = new System.Drawing.Size(40, 20);
            this._txtboxWinningFavorites.TabIndex = 9;
            // 
            // _txtboxTotal
            // 
            this._txtboxTotal.Location = new System.Drawing.Point(51, 18);
            this._txtboxTotal.Name = "_txtboxTotal";
            this._txtboxTotal.ReadOnly = true;
            this._txtboxTotal.Size = new System.Drawing.Size(40, 20);
            this._txtboxTotal.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txtboxWire2WirePercent);
            this.groupBox1.Controls.Add(this._txtboxTotalWire2WireWinners);
            this.groupBox1.Controls.Add(this._txtboxTotalRaces);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 44);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wire To Wire Winners";
            // 
            // _txtboxWire2WirePercent
            // 
            this._txtboxWire2WirePercent.Location = new System.Drawing.Point(95, 19);
            this._txtboxWire2WirePercent.Name = "_txtboxWire2WirePercent";
            this._txtboxWire2WirePercent.ReadOnly = true;
            this._txtboxWire2WirePercent.Size = new System.Drawing.Size(40, 20);
            this._txtboxWire2WirePercent.TabIndex = 8;
            // 
            // _txtboxTotalWire2WireWinners
            // 
            this._txtboxTotalWire2WireWinners.Location = new System.Drawing.Point(6, 19);
            this._txtboxTotalWire2WireWinners.Name = "_txtboxTotalWire2WireWinners";
            this._txtboxTotalWire2WireWinners.ReadOnly = true;
            this._txtboxTotalWire2WireWinners.Size = new System.Drawing.Size(40, 20);
            this._txtboxTotalWire2WireWinners.TabIndex = 4;
            // 
            // _txtboxTotalRaces
            // 
            this._txtboxTotalRaces.Location = new System.Drawing.Point(51, 19);
            this._txtboxTotalRaces.Name = "_txtboxTotalRaces";
            this._txtboxTotalRaces.ReadOnly = true;
            this._txtboxTotalRaces.Size = new System.Drawing.Size(40, 20);
            this._txtboxTotalRaces.TabIndex = 6;
            // 
            // WinnersTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1361, 744);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WinnersTimeForm";
            this.Text = "WinnersTimeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridPostPositionStats)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridWinnersMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridStatsByTrackCondition)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridView _gridPostPositionStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox _txtboxTotalRaces;
        private System.Windows.Forms.TextBox _txtboxTotalWire2WireWinners;
        private System.Windows.Forms.TextBox _txtboxWire2WirePercent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _txtboxFavoriteWinPercent;
        private System.Windows.Forms.TextBox _txtboxWinningFavorites;
        private System.Windows.Forms.TextBox _txtboxTotal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox _comboBoxDistance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox _comboboxRaceTrack;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox _comboboxSurface;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView _gridStatsByTrackCondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView _gridWinnersMove;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox _comboBoxAboutFlag;
    }
}