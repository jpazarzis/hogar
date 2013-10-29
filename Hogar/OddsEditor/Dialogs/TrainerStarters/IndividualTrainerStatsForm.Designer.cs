namespace OddsEditor.Dialogs
{
    partial class IndividualTrainerStatsForm
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
            this._grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this._labelTrainerName = new System.Windows.Forms.Label();
            this._txtboxTotalStarters = new System.Windows.Forms.TextBox();
            this._txtboxWinners = new System.Windows.Forms.TextBox();
            this._txtboxWinPercent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txtbox0to7DaysTotal = new System.Windows.Forms.TextBox();
            this._txtbox0to7DaysPercent = new System.Windows.Forms.TextBox();
            this._txtbox0to7DaysWinners = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._txtbox8To21DaysTotal = new System.Windows.Forms.TextBox();
            this._txtbox8To21DaysPercent = new System.Windows.Forms.TextBox();
            this._txtbox8To21DaysWinners = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._txtbox22To60Total = new System.Windows.Forms.TextBox();
            this._txtbox22To60Percent = new System.Windows.Forms.TextBox();
            this._txtbox22To60Winners = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._txtbox61To180Total = new System.Windows.Forms.TextBox();
            this._txtbox61To180Percent = new System.Windows.Forms.TextBox();
            this._txtbox61To180Winners = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._txtbox180PlusTotal = new System.Windows.Forms.TextBox();
            this._txtbox180PlusPercent = new System.Windows.Forms.TextBox();
            this._txtbox180PlusWinners = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this._txtboxDirtTotal = new System.Windows.Forms.TextBox();
            this._txtboxDirtPercent = new System.Windows.Forms.TextBox();
            this._txtboxDirtWinners = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this._txtboxTurfTotal = new System.Windows.Forms.TextBox();
            this._txtboxTurfPercent = new System.Windows.Forms.TextBox();
            this._txtboxTurfWinners = new System.Windows.Forms.TextBox();
            this._gridJockeyStats = new System.Windows.Forms.DataGridView();
            this._buttonFilter = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this._txtboxStartersForSelectedDataSet = new System.Windows.Forms.TextBox();
            this._txtboxWinnersPercentForSelectedDataSet = new System.Windows.Forms.TextBox();
            this._txtboxWinnersForSelectedDataSet = new System.Windows.Forms.TextBox();
            this._txtboxROISelectedDataSet = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridJockeyStats)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Location = new System.Drawing.Point(2, 249);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(940, 633);
            this._grid.TabIndex = 0;
            this._grid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.OnSortCompare);
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormatting);
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this._labelTrainerName);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 66);
            this.panel1.TabIndex = 1;
            // 
            // _labelTrainerName
            // 
            this._labelTrainerName.AutoSize = true;
            this._labelTrainerName.Location = new System.Drawing.Point(4, 13);
            this._labelTrainerName.Name = "_labelTrainerName";
            this._labelTrainerName.Size = new System.Drawing.Size(76, 25);
            this._labelTrainerName.TabIndex = 0;
            this._labelTrainerName.Text = "label1";
            // 
            // _txtboxTotalStarters
            // 
            this._txtboxTotalStarters.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxTotalStarters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTotalStarters.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTotalStarters.ForeColor = System.Drawing.Color.White;
            this._txtboxTotalStarters.Location = new System.Drawing.Point(58, 25);
            this._txtboxTotalStarters.Name = "_txtboxTotalStarters";
            this._txtboxTotalStarters.ReadOnly = true;
            this._txtboxTotalStarters.Size = new System.Drawing.Size(46, 24);
            this._txtboxTotalStarters.TabIndex = 4;
            this._txtboxTotalStarters.Text = "0";
            this._txtboxTotalStarters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxWinners
            // 
            this._txtboxWinners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxWinners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWinners.ForeColor = System.Drawing.Color.White;
            this._txtboxWinners.Location = new System.Drawing.Point(6, 25);
            this._txtboxWinners.Name = "_txtboxWinners";
            this._txtboxWinners.ReadOnly = true;
            this._txtboxWinners.Size = new System.Drawing.Size(46, 24);
            this._txtboxWinners.TabIndex = 5;
            this._txtboxWinners.Text = "0";
            this._txtboxWinners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxWinPercent
            // 
            this._txtboxWinPercent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxWinPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxWinPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWinPercent.ForeColor = System.Drawing.Color.White;
            this._txtboxWinPercent.Location = new System.Drawing.Point(110, 25);
            this._txtboxWinPercent.Name = "_txtboxWinPercent";
            this._txtboxWinPercent.ReadOnly = true;
            this._txtboxWinPercent.Size = new System.Drawing.Size(46, 24);
            this._txtboxWinPercent.TabIndex = 7;
            this._txtboxWinPercent.Text = "0";
            this._txtboxWinPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txtboxTotalStarters);
            this.groupBox1.Controls.Add(this._txtboxWinPercent);
            this.groupBox1.Controls.Add(this._txtboxWinners);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 66);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grand Total";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtbox0to7DaysTotal);
            this.groupBox2.Controls.Add(this._txtbox0to7DaysPercent);
            this.groupBox2.Controls.Add(this._txtbox0to7DaysWinners);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(191, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 66);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "0-7 days";
            // 
            // _txtbox0to7DaysTotal
            // 
            this._txtbox0to7DaysTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox0to7DaysTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox0to7DaysTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox0to7DaysTotal.ForeColor = System.Drawing.Color.White;
            this._txtbox0to7DaysTotal.Location = new System.Drawing.Point(58, 25);
            this._txtbox0to7DaysTotal.Name = "_txtbox0to7DaysTotal";
            this._txtbox0to7DaysTotal.ReadOnly = true;
            this._txtbox0to7DaysTotal.Size = new System.Drawing.Size(46, 24);
            this._txtbox0to7DaysTotal.TabIndex = 4;
            this._txtbox0to7DaysTotal.Text = "0";
            this._txtbox0to7DaysTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox0to7DaysPercent
            // 
            this._txtbox0to7DaysPercent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox0to7DaysPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox0to7DaysPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox0to7DaysPercent.ForeColor = System.Drawing.Color.White;
            this._txtbox0to7DaysPercent.Location = new System.Drawing.Point(110, 25);
            this._txtbox0to7DaysPercent.Name = "_txtbox0to7DaysPercent";
            this._txtbox0to7DaysPercent.ReadOnly = true;
            this._txtbox0to7DaysPercent.Size = new System.Drawing.Size(46, 24);
            this._txtbox0to7DaysPercent.TabIndex = 7;
            this._txtbox0to7DaysPercent.Text = "0";
            this._txtbox0to7DaysPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox0to7DaysWinners
            // 
            this._txtbox0to7DaysWinners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox0to7DaysWinners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox0to7DaysWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox0to7DaysWinners.ForeColor = System.Drawing.Color.White;
            this._txtbox0to7DaysWinners.Location = new System.Drawing.Point(6, 25);
            this._txtbox0to7DaysWinners.Name = "_txtbox0to7DaysWinners";
            this._txtbox0to7DaysWinners.ReadOnly = true;
            this._txtbox0to7DaysWinners.Size = new System.Drawing.Size(46, 24);
            this._txtbox0to7DaysWinners.TabIndex = 5;
            this._txtbox0to7DaysWinners.Text = "0";
            this._txtbox0to7DaysWinners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._txtbox8To21DaysTotal);
            this.groupBox3.Controls.Add(this._txtbox8To21DaysPercent);
            this.groupBox3.Controls.Add(this._txtbox8To21DaysWinners);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(369, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 66);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "8-21 days";
            // 
            // _txtbox8To21DaysTotal
            // 
            this._txtbox8To21DaysTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox8To21DaysTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox8To21DaysTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox8To21DaysTotal.ForeColor = System.Drawing.Color.White;
            this._txtbox8To21DaysTotal.Location = new System.Drawing.Point(58, 25);
            this._txtbox8To21DaysTotal.Name = "_txtbox8To21DaysTotal";
            this._txtbox8To21DaysTotal.ReadOnly = true;
            this._txtbox8To21DaysTotal.Size = new System.Drawing.Size(46, 24);
            this._txtbox8To21DaysTotal.TabIndex = 4;
            this._txtbox8To21DaysTotal.Text = "0";
            this._txtbox8To21DaysTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox8To21DaysPercent
            // 
            this._txtbox8To21DaysPercent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox8To21DaysPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox8To21DaysPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox8To21DaysPercent.ForeColor = System.Drawing.Color.White;
            this._txtbox8To21DaysPercent.Location = new System.Drawing.Point(110, 25);
            this._txtbox8To21DaysPercent.Name = "_txtbox8To21DaysPercent";
            this._txtbox8To21DaysPercent.ReadOnly = true;
            this._txtbox8To21DaysPercent.Size = new System.Drawing.Size(46, 24);
            this._txtbox8To21DaysPercent.TabIndex = 7;
            this._txtbox8To21DaysPercent.Text = "0";
            this._txtbox8To21DaysPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox8To21DaysWinners
            // 
            this._txtbox8To21DaysWinners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox8To21DaysWinners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox8To21DaysWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox8To21DaysWinners.ForeColor = System.Drawing.Color.White;
            this._txtbox8To21DaysWinners.Location = new System.Drawing.Point(6, 25);
            this._txtbox8To21DaysWinners.Name = "_txtbox8To21DaysWinners";
            this._txtbox8To21DaysWinners.ReadOnly = true;
            this._txtbox8To21DaysWinners.Size = new System.Drawing.Size(46, 24);
            this._txtbox8To21DaysWinners.TabIndex = 5;
            this._txtbox8To21DaysWinners.Text = "0";
            this._txtbox8To21DaysWinners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._txtbox22To60Total);
            this.groupBox4.Controls.Add(this._txtbox22To60Percent);
            this.groupBox4.Controls.Add(this._txtbox22To60Winners);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(537, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(162, 66);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "22-60 days";
            // 
            // _txtbox22To60Total
            // 
            this._txtbox22To60Total.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox22To60Total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox22To60Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox22To60Total.ForeColor = System.Drawing.Color.White;
            this._txtbox22To60Total.Location = new System.Drawing.Point(58, 25);
            this._txtbox22To60Total.Name = "_txtbox22To60Total";
            this._txtbox22To60Total.ReadOnly = true;
            this._txtbox22To60Total.Size = new System.Drawing.Size(46, 24);
            this._txtbox22To60Total.TabIndex = 4;
            this._txtbox22To60Total.Text = "0";
            this._txtbox22To60Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox22To60Percent
            // 
            this._txtbox22To60Percent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox22To60Percent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox22To60Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox22To60Percent.ForeColor = System.Drawing.Color.White;
            this._txtbox22To60Percent.Location = new System.Drawing.Point(110, 25);
            this._txtbox22To60Percent.Name = "_txtbox22To60Percent";
            this._txtbox22To60Percent.ReadOnly = true;
            this._txtbox22To60Percent.Size = new System.Drawing.Size(46, 24);
            this._txtbox22To60Percent.TabIndex = 7;
            this._txtbox22To60Percent.Text = "0";
            this._txtbox22To60Percent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox22To60Winners
            // 
            this._txtbox22To60Winners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox22To60Winners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox22To60Winners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox22To60Winners.ForeColor = System.Drawing.Color.White;
            this._txtbox22To60Winners.Location = new System.Drawing.Point(6, 25);
            this._txtbox22To60Winners.Name = "_txtbox22To60Winners";
            this._txtbox22To60Winners.ReadOnly = true;
            this._txtbox22To60Winners.Size = new System.Drawing.Size(46, 24);
            this._txtbox22To60Winners.TabIndex = 5;
            this._txtbox22To60Winners.Text = "0";
            this._txtbox22To60Winners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._txtbox61To180Total);
            this.groupBox5.Controls.Add(this._txtbox61To180Percent);
            this.groupBox5.Controls.Add(this._txtbox61To180Winners);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(705, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(162, 66);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "61-180 days";
            // 
            // _txtbox61To180Total
            // 
            this._txtbox61To180Total.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox61To180Total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox61To180Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox61To180Total.ForeColor = System.Drawing.Color.White;
            this._txtbox61To180Total.Location = new System.Drawing.Point(58, 25);
            this._txtbox61To180Total.Name = "_txtbox61To180Total";
            this._txtbox61To180Total.ReadOnly = true;
            this._txtbox61To180Total.Size = new System.Drawing.Size(46, 24);
            this._txtbox61To180Total.TabIndex = 4;
            this._txtbox61To180Total.Text = "0";
            this._txtbox61To180Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox61To180Percent
            // 
            this._txtbox61To180Percent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox61To180Percent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox61To180Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox61To180Percent.ForeColor = System.Drawing.Color.White;
            this._txtbox61To180Percent.Location = new System.Drawing.Point(110, 25);
            this._txtbox61To180Percent.Name = "_txtbox61To180Percent";
            this._txtbox61To180Percent.ReadOnly = true;
            this._txtbox61To180Percent.Size = new System.Drawing.Size(46, 24);
            this._txtbox61To180Percent.TabIndex = 7;
            this._txtbox61To180Percent.Text = "0";
            this._txtbox61To180Percent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox61To180Winners
            // 
            this._txtbox61To180Winners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox61To180Winners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox61To180Winners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox61To180Winners.ForeColor = System.Drawing.Color.White;
            this._txtbox61To180Winners.Location = new System.Drawing.Point(6, 25);
            this._txtbox61To180Winners.Name = "_txtbox61To180Winners";
            this._txtbox61To180Winners.ReadOnly = true;
            this._txtbox61To180Winners.Size = new System.Drawing.Size(46, 24);
            this._txtbox61To180Winners.TabIndex = 5;
            this._txtbox61To180Winners.Text = "0";
            this._txtbox61To180Winners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._txtbox180PlusTotal);
            this.groupBox6.Controls.Add(this._txtbox180PlusPercent);
            this.groupBox6.Controls.Add(this._txtbox180PlusWinners);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(873, 85);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(162, 66);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "181 + days";
            // 
            // _txtbox180PlusTotal
            // 
            this._txtbox180PlusTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox180PlusTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox180PlusTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox180PlusTotal.ForeColor = System.Drawing.Color.White;
            this._txtbox180PlusTotal.Location = new System.Drawing.Point(58, 25);
            this._txtbox180PlusTotal.Name = "_txtbox180PlusTotal";
            this._txtbox180PlusTotal.ReadOnly = true;
            this._txtbox180PlusTotal.Size = new System.Drawing.Size(46, 24);
            this._txtbox180PlusTotal.TabIndex = 4;
            this._txtbox180PlusTotal.Text = "0";
            this._txtbox180PlusTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtbox180PlusTotal.TextChanged += new System.EventHandler(this._txtbox180PlusTotal_TextChanged);
            // 
            // _txtbox180PlusPercent
            // 
            this._txtbox180PlusPercent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox180PlusPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox180PlusPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox180PlusPercent.ForeColor = System.Drawing.Color.White;
            this._txtbox180PlusPercent.Location = new System.Drawing.Point(110, 25);
            this._txtbox180PlusPercent.Name = "_txtbox180PlusPercent";
            this._txtbox180PlusPercent.ReadOnly = true;
            this._txtbox180PlusPercent.Size = new System.Drawing.Size(46, 24);
            this._txtbox180PlusPercent.TabIndex = 7;
            this._txtbox180PlusPercent.Text = "0";
            this._txtbox180PlusPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtbox180PlusWinners
            // 
            this._txtbox180PlusWinners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtbox180PlusWinners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtbox180PlusWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox180PlusWinners.ForeColor = System.Drawing.Color.White;
            this._txtbox180PlusWinners.Location = new System.Drawing.Point(6, 25);
            this._txtbox180PlusWinners.Name = "_txtbox180PlusWinners";
            this._txtbox180PlusWinners.ReadOnly = true;
            this._txtbox180PlusWinners.Size = new System.Drawing.Size(46, 24);
            this._txtbox180PlusWinners.TabIndex = 5;
            this._txtbox180PlusWinners.Text = "0";
            this._txtbox180PlusWinners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this._txtboxDirtTotal);
            this.groupBox7.Controls.Add(this._txtboxDirtPercent);
            this.groupBox7.Controls.Add(this._txtboxDirtWinners);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(1041, 85);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(162, 66);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Dirt Only";
            // 
            // _txtboxDirtTotal
            // 
            this._txtboxDirtTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxDirtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxDirtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDirtTotal.ForeColor = System.Drawing.Color.White;
            this._txtboxDirtTotal.Location = new System.Drawing.Point(58, 25);
            this._txtboxDirtTotal.Name = "_txtboxDirtTotal";
            this._txtboxDirtTotal.ReadOnly = true;
            this._txtboxDirtTotal.Size = new System.Drawing.Size(46, 24);
            this._txtboxDirtTotal.TabIndex = 4;
            this._txtboxDirtTotal.Text = "0";
            this._txtboxDirtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxDirtPercent
            // 
            this._txtboxDirtPercent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxDirtPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxDirtPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDirtPercent.ForeColor = System.Drawing.Color.White;
            this._txtboxDirtPercent.Location = new System.Drawing.Point(110, 25);
            this._txtboxDirtPercent.Name = "_txtboxDirtPercent";
            this._txtboxDirtPercent.ReadOnly = true;
            this._txtboxDirtPercent.Size = new System.Drawing.Size(46, 24);
            this._txtboxDirtPercent.TabIndex = 7;
            this._txtboxDirtPercent.Text = "0";
            this._txtboxDirtPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxDirtWinners
            // 
            this._txtboxDirtWinners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxDirtWinners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxDirtWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDirtWinners.ForeColor = System.Drawing.Color.White;
            this._txtboxDirtWinners.Location = new System.Drawing.Point(6, 25);
            this._txtboxDirtWinners.Name = "_txtboxDirtWinners";
            this._txtboxDirtWinners.ReadOnly = true;
            this._txtboxDirtWinners.Size = new System.Drawing.Size(46, 24);
            this._txtboxDirtWinners.TabIndex = 5;
            this._txtboxDirtWinners.Text = "0";
            this._txtboxDirtWinners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this._txtboxTurfTotal);
            this.groupBox8.Controls.Add(this._txtboxTurfPercent);
            this.groupBox8.Controls.Add(this._txtboxTurfWinners);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(1209, 85);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(162, 66);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Turf Only";
            // 
            // _txtboxTurfTotal
            // 
            this._txtboxTurfTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxTurfTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTurfTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTurfTotal.ForeColor = System.Drawing.Color.White;
            this._txtboxTurfTotal.Location = new System.Drawing.Point(58, 25);
            this._txtboxTurfTotal.Name = "_txtboxTurfTotal";
            this._txtboxTurfTotal.ReadOnly = true;
            this._txtboxTurfTotal.Size = new System.Drawing.Size(46, 24);
            this._txtboxTurfTotal.TabIndex = 4;
            this._txtboxTurfTotal.Text = "0";
            this._txtboxTurfTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxTurfPercent
            // 
            this._txtboxTurfPercent.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxTurfPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTurfPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTurfPercent.ForeColor = System.Drawing.Color.White;
            this._txtboxTurfPercent.Location = new System.Drawing.Point(110, 25);
            this._txtboxTurfPercent.Name = "_txtboxTurfPercent";
            this._txtboxTurfPercent.ReadOnly = true;
            this._txtboxTurfPercent.Size = new System.Drawing.Size(46, 24);
            this._txtboxTurfPercent.TabIndex = 7;
            this._txtboxTurfPercent.Text = "0";
            this._txtboxTurfPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxTurfWinners
            // 
            this._txtboxTurfWinners.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxTurfWinners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTurfWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTurfWinners.ForeColor = System.Drawing.Color.White;
            this._txtboxTurfWinners.Location = new System.Drawing.Point(6, 25);
            this._txtboxTurfWinners.Name = "_txtboxTurfWinners";
            this._txtboxTurfWinners.ReadOnly = true;
            this._txtboxTurfWinners.Size = new System.Drawing.Size(46, 24);
            this._txtboxTurfWinners.TabIndex = 5;
            this._txtboxTurfWinners.Text = "0";
            this._txtboxTurfWinners.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _gridJockeyStats
            // 
            this._gridJockeyStats.AllowUserToAddRows = false;
            this._gridJockeyStats.AllowUserToDeleteRows = false;
            this._gridJockeyStats.AllowUserToOrderColumns = true;
            this._gridJockeyStats.AllowUserToResizeColumns = false;
            this._gridJockeyStats.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            this._gridJockeyStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this._gridJockeyStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridJockeyStats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridJockeyStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridJockeyStats.Location = new System.Drawing.Point(946, 249);
            this._gridJockeyStats.Name = "_gridJockeyStats";
            this._gridJockeyStats.ReadOnly = true;
            this._gridJockeyStats.RowHeadersVisible = false;
            this._gridJockeyStats.Size = new System.Drawing.Size(429, 633);
            this._gridJockeyStats.TabIndex = 16;
            // 
            // _buttonFilter
            // 
            this._buttonFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonFilter.Location = new System.Drawing.Point(949, 13);
            this._buttonFilter.Name = "_buttonFilter";
            this._buttonFilter.Size = new System.Drawing.Size(75, 58);
            this._buttonFilter.TabIndex = 19;
            this._buttonFilter.Text = "Filter";
            this._buttonFilter.UseVisualStyleBackColor = true;
            this._buttonFilter.Click += new System.EventHandler(this.OnFilter);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this._txtboxROISelectedDataSet);
            this.groupBox9.Controls.Add(this._txtboxStartersForSelectedDataSet);
            this.groupBox9.Controls.Add(this._txtboxWinnersPercentForSelectedDataSet);
            this.groupBox9.Controls.Add(this._txtboxWinnersForSelectedDataSet);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(13, 157);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(213, 66);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Selected DataSet";
            // 
            // _txtboxStartersForSelectedDataSet
            // 
            this._txtboxStartersForSelectedDataSet.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxStartersForSelectedDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxStartersForSelectedDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxStartersForSelectedDataSet.ForeColor = System.Drawing.Color.White;
            this._txtboxStartersForSelectedDataSet.Location = new System.Drawing.Point(58, 25);
            this._txtboxStartersForSelectedDataSet.Name = "_txtboxStartersForSelectedDataSet";
            this._txtboxStartersForSelectedDataSet.ReadOnly = true;
            this._txtboxStartersForSelectedDataSet.Size = new System.Drawing.Size(46, 24);
            this._txtboxStartersForSelectedDataSet.TabIndex = 4;
            this._txtboxStartersForSelectedDataSet.Text = "0";
            this._txtboxStartersForSelectedDataSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxWinnersPercentForSelectedDataSet
            // 
            this._txtboxWinnersPercentForSelectedDataSet.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxWinnersPercentForSelectedDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxWinnersPercentForSelectedDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWinnersPercentForSelectedDataSet.ForeColor = System.Drawing.Color.White;
            this._txtboxWinnersPercentForSelectedDataSet.Location = new System.Drawing.Point(110, 25);
            this._txtboxWinnersPercentForSelectedDataSet.Name = "_txtboxWinnersPercentForSelectedDataSet";
            this._txtboxWinnersPercentForSelectedDataSet.ReadOnly = true;
            this._txtboxWinnersPercentForSelectedDataSet.Size = new System.Drawing.Size(46, 24);
            this._txtboxWinnersPercentForSelectedDataSet.TabIndex = 7;
            this._txtboxWinnersPercentForSelectedDataSet.Text = "0";
            this._txtboxWinnersPercentForSelectedDataSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxWinnersForSelectedDataSet
            // 
            this._txtboxWinnersForSelectedDataSet.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxWinnersForSelectedDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxWinnersForSelectedDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWinnersForSelectedDataSet.ForeColor = System.Drawing.Color.White;
            this._txtboxWinnersForSelectedDataSet.Location = new System.Drawing.Point(6, 25);
            this._txtboxWinnersForSelectedDataSet.Name = "_txtboxWinnersForSelectedDataSet";
            this._txtboxWinnersForSelectedDataSet.ReadOnly = true;
            this._txtboxWinnersForSelectedDataSet.Size = new System.Drawing.Size(46, 24);
            this._txtboxWinnersForSelectedDataSet.TabIndex = 5;
            this._txtboxWinnersForSelectedDataSet.Text = "0";
            this._txtboxWinnersForSelectedDataSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxROISelectedDataSet
            // 
            this._txtboxROISelectedDataSet.BackColor = System.Drawing.Color.RoyalBlue;
            this._txtboxROISelectedDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxROISelectedDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxROISelectedDataSet.ForeColor = System.Drawing.Color.White;
            this._txtboxROISelectedDataSet.Location = new System.Drawing.Point(162, 25);
            this._txtboxROISelectedDataSet.Name = "_txtboxROISelectedDataSet";
            this._txtboxROISelectedDataSet.ReadOnly = true;
            this._txtboxROISelectedDataSet.Size = new System.Drawing.Size(46, 24);
            this._txtboxROISelectedDataSet.TabIndex = 8;
            this._txtboxROISelectedDataSet.Text = "0";
            this._txtboxROISelectedDataSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IndividualTrainerStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1036, 894);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this._buttonFilter);
            this.Controls.Add(this._gridJockeyStats);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._grid);
            this.Name = "IndividualTrainerStatsForm";
            this.Text = "IndividualTrainerStatsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridJockeyStats)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _labelTrainerName;
        private System.Windows.Forms.TextBox _txtboxTotalStarters;
        private System.Windows.Forms.TextBox _txtboxWinners;
        private System.Windows.Forms.TextBox _txtboxWinPercent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _txtbox0to7DaysTotal;
        private System.Windows.Forms.TextBox _txtbox0to7DaysPercent;
        private System.Windows.Forms.TextBox _txtbox0to7DaysWinners;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _txtbox8To21DaysTotal;
        private System.Windows.Forms.TextBox _txtbox8To21DaysPercent;
        private System.Windows.Forms.TextBox _txtbox8To21DaysWinners;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox _txtbox22To60Total;
        private System.Windows.Forms.TextBox _txtbox22To60Percent;
        private System.Windows.Forms.TextBox _txtbox22To60Winners;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox _txtbox61To180Total;
        private System.Windows.Forms.TextBox _txtbox61To180Percent;
        private System.Windows.Forms.TextBox _txtbox61To180Winners;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox _txtbox180PlusTotal;
        private System.Windows.Forms.TextBox _txtbox180PlusPercent;
        private System.Windows.Forms.TextBox _txtbox180PlusWinners;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox _txtboxDirtTotal;
        private System.Windows.Forms.TextBox _txtboxDirtPercent;
        private System.Windows.Forms.TextBox _txtboxDirtWinners;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox _txtboxTurfTotal;
        private System.Windows.Forms.TextBox _txtboxTurfPercent;
        private System.Windows.Forms.TextBox _txtboxTurfWinners;
        private System.Windows.Forms.DataGridView _gridJockeyStats;
        private System.Windows.Forms.Button _buttonFilter;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox _txtboxROISelectedDataSet;
        private System.Windows.Forms.TextBox _txtboxStartersForSelectedDataSet;
        private System.Windows.Forms.TextBox _txtboxWinnersPercentForSelectedDataSet;
        private System.Windows.Forms.TextBox _txtboxWinnersForSelectedDataSet;
    }
}