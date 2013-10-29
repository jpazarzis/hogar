namespace OddsEditor.MyComponents
{
    partial class HorseFractionsComponent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._txtboxHorseNumber = new System.Windows.Forms.TextBox();
            this._txtboxHorseName = new System.Windows.Forms.TextBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._txtboxJockeyName = new System.Windows.Forms.TextBox();
            this._txtboxOwner = new System.Windows.Forms.TextBox();
            this._txtboxOwnersSilks = new System.Windows.Forms.TextBox();
            this._txtboxOdds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txtboxSireInfo = new System.Windows.Forms.TextBox();
            this._txtboxDamInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtboxTrainerInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtboxWeight = new System.Windows.Forms.TextBox();
            this._txtboxLifeTimeEarnings = new System.Windows.Forms.TextBox();
            this._txtboxCurrentYearEarnings = new System.Windows.Forms.TextBox();
            this._txtboxPreviousYearEarnings = new System.Windows.Forms.TextBox();
            this._txtboxTodaysTrackEarnings = new System.Windows.Forms.TextBox();
            this._txtboxWetTrackEarnings = new System.Windows.Forms.TextBox();
            this._txtboxTurfTrackEarnings = new System.Windows.Forms.TextBox();
            this._txtboxTodaysDistanceEarnings = new System.Windows.Forms.TextBox();
            this._txtboxPrimePowerRating = new System.Windows.Forms.TextBox();
            this._txtboxDaysSinceLastRace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._txtboxClaimingPrice = new System.Windows.Forms.TextBox();
            this._txtboxColorSexAge = new System.Windows.Forms.TextBox();
            this._panelWorkouts = new System.Windows.Forms.FlowLayoutPanel();
            this._txtboxQuirinSpeedIndex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._txtboxBrisRunStyle = new System.Windows.Forms.TextBox();
            this._radioButtonWinner = new System.Windows.Forms.RadioButton();
            this._radioButtonThis = new System.Windows.Forms.RadioButton();
            this._popupmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._labelRaceInfo = new System.Windows.Forms.Label();
            this._labelPostPosition = new System.Windows.Forms.Label();
            this._buttonShowTimeGraphs = new System.Windows.Forms.Button();
            this._radioButtonFigures = new System.Windows.Forms.RadioButton();
            this._brisFiguresStatsCtrl1 = new OddsEditor.MyComponents.BrisFiguresStatsCtrl();
            this._xRayCtrl = new OddsEditor.Dialogs.WinnersForDay.XRayCtrl();
            this._factorAnalysisCtrl = new OddsEditor.MyComponents.FactorAnalysisCtrl();
            this._breedingInfoCtrl = new OddsEditor.MyComponents.BreedingInfoCtrl();
            this._shortRaceChartControl = new OddsEditor.MyComponents.ShortRaceChartControl();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtboxHorseNumber
            // 
            this._txtboxHorseNumber.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxHorseNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxHorseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxHorseNumber.Location = new System.Drawing.Point(13, 60);
            this._txtboxHorseNumber.Name = "_txtboxHorseNumber";
            this._txtboxHorseNumber.ReadOnly = true;
            this._txtboxHorseNumber.Size = new System.Drawing.Size(63, 55);
            this._txtboxHorseNumber.TabIndex = 0;
            this._txtboxHorseNumber.Text = "12";
            this._txtboxHorseNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxHorseName
            // 
            this._txtboxHorseName.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxHorseName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxHorseName.Location = new System.Drawing.Point(82, 91);
            this._txtboxHorseName.Name = "_txtboxHorseName";
            this._txtboxHorseName.ReadOnly = true;
            this._txtboxHorseName.Size = new System.Drawing.Size(217, 24);
            this._txtboxHorseName.TabIndex = 1;
            this._txtboxHorseName.Text = "Elegant Boy";
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
            this._grid.Location = new System.Drawing.Point(10, 187);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1358, 264);
            this._grid.TabIndex = 2;
            this._grid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnCellMouseClick);
            this._grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnGridCellFormatting);
            // 
            // _txtboxJockeyName
            // 
            this._txtboxJockeyName.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxJockeyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxJockeyName.Cursor = System.Windows.Forms.Cursors.Hand;
            this._txtboxJockeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxJockeyName.ForeColor = System.Drawing.Color.Blue;
            this._txtboxJockeyName.Location = new System.Drawing.Point(7, 153);
            this._txtboxJockeyName.Name = "_txtboxJockeyName";
            this._txtboxJockeyName.ReadOnly = true;
            this._txtboxJockeyName.Size = new System.Drawing.Size(392, 15);
            this._txtboxJockeyName.TabIndex = 3;
            this._txtboxJockeyName.Text = "GIATRAS";
            this._txtboxJockeyName.TextChanged += new System.EventHandler(this._txtboxJockeyName_TextChanged);
            this._txtboxJockeyName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnJockeyClick);
            // 
            // _txtboxOwner
            // 
            this._txtboxOwner.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxOwner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxOwner.Location = new System.Drawing.Point(82, 122);
            this._txtboxOwner.Name = "_txtboxOwner";
            this._txtboxOwner.ReadOnly = true;
            this._txtboxOwner.Size = new System.Drawing.Size(325, 13);
            this._txtboxOwner.TabIndex = 4;
            this._txtboxOwner.Text = "SPASOF";
            // 
            // _txtboxOwnersSilks
            // 
            this._txtboxOwnersSilks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxOwnersSilks.Location = new System.Drawing.Point(82, 138);
            this._txtboxOwnersSilks.Name = "_txtboxOwnersSilks";
            this._txtboxOwnersSilks.Size = new System.Drawing.Size(325, 13);
            this._txtboxOwnersSilks.TabIndex = 5;
            this._txtboxOwnersSilks.Text = "Black Orange";
            // 
            // _txtboxOdds
            // 
            this._txtboxOdds.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxOdds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxOdds.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._txtboxOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxOdds.Location = new System.Drawing.Point(20, 132);
            this._txtboxOdds.Name = "_txtboxOdds";
            this._txtboxOdds.ReadOnly = true;
            this._txtboxOdds.Size = new System.Drawing.Size(40, 19);
            this._txtboxOdds.TabIndex = 6;
            this._txtboxOdds.Text = "2-1";
            this._txtboxOdds.TextChanged += new System.EventHandler(this._txtboxOdds_TextChanged);
            this._txtboxOdds.Click += new System.EventHandler(this.OnOddsClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(413, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sire:";
            // 
            // _txtboxSireInfo
            // 
            this._txtboxSireInfo.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxSireInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxSireInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxSireInfo.Location = new System.Drawing.Point(447, 108);
            this._txtboxSireInfo.Name = "_txtboxSireInfo";
            this._txtboxSireInfo.ReadOnly = true;
            this._txtboxSireInfo.Size = new System.Drawing.Size(250, 13);
            this._txtboxSireInfo.TabIndex = 8;
            this._txtboxSireInfo.Text = "AIAS";
            // 
            // _txtboxDamInfo
            // 
            this._txtboxDamInfo.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxDamInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxDamInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDamInfo.Location = new System.Drawing.Point(447, 129);
            this._txtboxDamInfo.Name = "_txtboxDamInfo";
            this._txtboxDamInfo.ReadOnly = true;
            this._txtboxDamInfo.Size = new System.Drawing.Size(219, 13);
            this._txtboxDamInfo.TabIndex = 10;
            this._txtboxDamInfo.Text = "AIAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(413, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dam:";
            // 
            // _txtboxTrainerInfo
            // 
            this._txtboxTrainerInfo.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxTrainerInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTrainerInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this._txtboxTrainerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTrainerInfo.ForeColor = System.Drawing.Color.Blue;
            this._txtboxTrainerInfo.Location = new System.Drawing.Point(447, 148);
            this._txtboxTrainerInfo.Name = "_txtboxTrainerInfo";
            this._txtboxTrainerInfo.ReadOnly = true;
            this._txtboxTrainerInfo.Size = new System.Drawing.Size(219, 13);
            this._txtboxTrainerInfo.TabIndex = 12;
            this._txtboxTrainerInfo.Text = "AIAS";
            this._txtboxTrainerInfo.TextChanged += new System.EventHandler(this._txtboxTrainerInfo_TextChanged);
            this._txtboxTrainerInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnTrainerInfoClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(413, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tr:";
            // 
            // _txtboxWeight
            // 
            this._txtboxWeight.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWeight.Location = new System.Drawing.Point(735, 92);
            this._txtboxWeight.Name = "_txtboxWeight";
            this._txtboxWeight.ReadOnly = true;
            this._txtboxWeight.Size = new System.Drawing.Size(90, 31);
            this._txtboxWeight.TabIndex = 13;
            this._txtboxWeight.Text = "L 121";
            // 
            // _txtboxLifeTimeEarnings
            // 
            this._txtboxLifeTimeEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxLifeTimeEarnings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtboxLifeTimeEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxLifeTimeEarnings.Location = new System.Drawing.Point(966, 91);
            this._txtboxLifeTimeEarnings.Name = "_txtboxLifeTimeEarnings";
            this._txtboxLifeTimeEarnings.ReadOnly = true;
            this._txtboxLifeTimeEarnings.Size = new System.Drawing.Size(155, 22);
            this._txtboxLifeTimeEarnings.TabIndex = 14;
            this._txtboxLifeTimeEarnings.Text = "AIAS";
            // 
            // _txtboxCurrentYearEarnings
            // 
            this._txtboxCurrentYearEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxCurrentYearEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxCurrentYearEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxCurrentYearEarnings.Location = new System.Drawing.Point(966, 122);
            this._txtboxCurrentYearEarnings.Name = "_txtboxCurrentYearEarnings";
            this._txtboxCurrentYearEarnings.ReadOnly = true;
            this._txtboxCurrentYearEarnings.Size = new System.Drawing.Size(155, 15);
            this._txtboxCurrentYearEarnings.TabIndex = 15;
            this._txtboxCurrentYearEarnings.Text = "AIAS";
            // 
            // _txtboxPreviousYearEarnings
            // 
            this._txtboxPreviousYearEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxPreviousYearEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxPreviousYearEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxPreviousYearEarnings.Location = new System.Drawing.Point(966, 143);
            this._txtboxPreviousYearEarnings.Name = "_txtboxPreviousYearEarnings";
            this._txtboxPreviousYearEarnings.ReadOnly = true;
            this._txtboxPreviousYearEarnings.Size = new System.Drawing.Size(155, 15);
            this._txtboxPreviousYearEarnings.TabIndex = 16;
            this._txtboxPreviousYearEarnings.Text = "AIAS";
            // 
            // _txtboxTodaysTrackEarnings
            // 
            this._txtboxTodaysTrackEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxTodaysTrackEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTodaysTrackEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTodaysTrackEarnings.Location = new System.Drawing.Point(966, 162);
            this._txtboxTodaysTrackEarnings.Name = "_txtboxTodaysTrackEarnings";
            this._txtboxTodaysTrackEarnings.ReadOnly = true;
            this._txtboxTodaysTrackEarnings.Size = new System.Drawing.Size(155, 15);
            this._txtboxTodaysTrackEarnings.TabIndex = 17;
            this._txtboxTodaysTrackEarnings.Text = "AIAS";
            // 
            // _txtboxWetTrackEarnings
            // 
            this._txtboxWetTrackEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxWetTrackEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxWetTrackEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWetTrackEarnings.Location = new System.Drawing.Point(1147, 121);
            this._txtboxWetTrackEarnings.Name = "_txtboxWetTrackEarnings";
            this._txtboxWetTrackEarnings.ReadOnly = true;
            this._txtboxWetTrackEarnings.Size = new System.Drawing.Size(155, 15);
            this._txtboxWetTrackEarnings.TabIndex = 18;
            this._txtboxWetTrackEarnings.Text = "AIAS";
            // 
            // _txtboxTurfTrackEarnings
            // 
            this._txtboxTurfTrackEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxTurfTrackEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTurfTrackEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTurfTrackEarnings.Location = new System.Drawing.Point(1147, 143);
            this._txtboxTurfTrackEarnings.Name = "_txtboxTurfTrackEarnings";
            this._txtboxTurfTrackEarnings.ReadOnly = true;
            this._txtboxTurfTrackEarnings.Size = new System.Drawing.Size(155, 15);
            this._txtboxTurfTrackEarnings.TabIndex = 19;
            this._txtboxTurfTrackEarnings.Text = "AIAS";
            // 
            // _txtboxTodaysDistanceEarnings
            // 
            this._txtboxTodaysDistanceEarnings.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxTodaysDistanceEarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTodaysDistanceEarnings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTodaysDistanceEarnings.Location = new System.Drawing.Point(1147, 164);
            this._txtboxTodaysDistanceEarnings.Name = "_txtboxTodaysDistanceEarnings";
            this._txtboxTodaysDistanceEarnings.ReadOnly = true;
            this._txtboxTodaysDistanceEarnings.Size = new System.Drawing.Size(155, 15);
            this._txtboxTodaysDistanceEarnings.TabIndex = 20;
            this._txtboxTodaysDistanceEarnings.Text = "AIAS";
            // 
            // _txtboxPrimePowerRating
            // 
            this._txtboxPrimePowerRating.BackColor = System.Drawing.SystemColors.MenuText;
            this._txtboxPrimePowerRating.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxPrimePowerRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxPrimePowerRating.ForeColor = System.Drawing.SystemColors.Window;
            this._txtboxPrimePowerRating.Location = new System.Drawing.Point(815, 147);
            this._txtboxPrimePowerRating.Name = "_txtboxPrimePowerRating";
            this._txtboxPrimePowerRating.ReadOnly = true;
            this._txtboxPrimePowerRating.Size = new System.Drawing.Size(56, 31);
            this._txtboxPrimePowerRating.TabIndex = 21;
            this._txtboxPrimePowerRating.Text = "121";
            this._txtboxPrimePowerRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxDaysSinceLastRace
            // 
            this._txtboxDaysSinceLastRace.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxDaysSinceLastRace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxDaysSinceLastRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDaysSinceLastRace.Location = new System.Drawing.Point(379, 168);
            this._txtboxDaysSinceLastRace.Name = "_txtboxDaysSinceLastRace";
            this._txtboxDaysSinceLastRace.ReadOnly = true;
            this._txtboxDaysSinceLastRace.Size = new System.Drawing.Size(49, 17);
            this._txtboxDaysSinceLastRace.TabIndex = 23;
            this._txtboxDaysSinceLastRace.Text = "123";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Days Off";
            // 
            // _txtboxClaimingPrice
            // 
            this._txtboxClaimingPrice.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxClaimingPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxClaimingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxClaimingPrice.Location = new System.Drawing.Point(307, 93);
            this._txtboxClaimingPrice.Name = "_txtboxClaimingPrice";
            this._txtboxClaimingPrice.ReadOnly = true;
            this._txtboxClaimingPrice.Size = new System.Drawing.Size(90, 19);
            this._txtboxClaimingPrice.TabIndex = 25;
            this._txtboxClaimingPrice.Text = "$10,000";
            // 
            // _txtboxColorSexAge
            // 
            this._txtboxColorSexAge.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxColorSexAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxColorSexAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxColorSexAge.Location = new System.Drawing.Point(416, 91);
            this._txtboxColorSexAge.Name = "_txtboxColorSexAge";
            this._txtboxColorSexAge.ReadOnly = true;
            this._txtboxColorSexAge.Size = new System.Drawing.Size(250, 13);
            this._txtboxColorSexAge.TabIndex = 27;
            this._txtboxColorSexAge.Text = "AIAS";
            // 
            // _panelWorkouts
            // 
            this._panelWorkouts.Location = new System.Drawing.Point(12, 458);
            this._panelWorkouts.Name = "_panelWorkouts";
            this._panelWorkouts.Size = new System.Drawing.Size(1355, 60);
            this._panelWorkouts.TabIndex = 28;
            // 
            // _txtboxQuirinSpeedIndex
            // 
            this._txtboxQuirinSpeedIndex.BackColor = System.Drawing.SystemColors.MenuText;
            this._txtboxQuirinSpeedIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxQuirinSpeedIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxQuirinSpeedIndex.ForeColor = System.Drawing.SystemColors.Window;
            this._txtboxQuirinSpeedIndex.Location = new System.Drawing.Point(682, 147);
            this._txtboxQuirinSpeedIndex.Name = "_txtboxQuirinSpeedIndex";
            this._txtboxQuirinSpeedIndex.ReadOnly = true;
            this._txtboxQuirinSpeedIndex.Size = new System.Drawing.Size(56, 31);
            this._txtboxQuirinSpeedIndex.TabIndex = 29;
            this._txtboxQuirinSpeedIndex.Text = "121";
            this._txtboxQuirinSpeedIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(809, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Power Rating";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(677, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Quirin Index";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(751, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Run Style";
            // 
            // _txtboxBrisRunStyle
            // 
            this._txtboxBrisRunStyle.BackColor = System.Drawing.SystemColors.MenuText;
            this._txtboxBrisRunStyle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxBrisRunStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxBrisRunStyle.ForeColor = System.Drawing.SystemColors.Window;
            this._txtboxBrisRunStyle.Location = new System.Drawing.Point(753, 147);
            this._txtboxBrisRunStyle.Name = "_txtboxBrisRunStyle";
            this._txtboxBrisRunStyle.ReadOnly = true;
            this._txtboxBrisRunStyle.Size = new System.Drawing.Size(56, 31);
            this._txtboxBrisRunStyle.TabIndex = 31;
            this._txtboxBrisRunStyle.Text = "121";
            this._txtboxBrisRunStyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _radioButtonWinner
            // 
            this._radioButtonWinner.AutoSize = true;
            this._radioButtonWinner.Location = new System.Drawing.Point(497, 168);
            this._radioButtonWinner.Name = "_radioButtonWinner";
            this._radioButtonWinner.Size = new System.Drawing.Size(59, 17);
            this._radioButtonWinner.TabIndex = 37;
            this._radioButtonWinner.TabStop = true;
            this._radioButtonWinner.Text = "Winner";
            this._radioButtonWinner.UseVisualStyleBackColor = true;
            this._radioButtonWinner.CheckedChanged += new System.EventHandler(this.OnRadioButtonWinnerCheckedChanged);
            // 
            // _radioButtonThis
            // 
            this._radioButtonThis.AutoSize = true;
            this._radioButtonThis.Location = new System.Drawing.Point(562, 168);
            this._radioButtonThis.Name = "_radioButtonThis";
            this._radioButtonThis.Size = new System.Drawing.Size(45, 17);
            this._radioButtonThis.TabIndex = 38;
            this._radioButtonThis.TabStop = true;
            this._radioButtonThis.Text = "This";
            this._radioButtonThis.UseVisualStyleBackColor = true;
            this._radioButtonThis.CheckedChanged += new System.EventHandler(this.OnRadioButtonWinnerCheckedChanged);
            // 
            // _popupmenu
            // 
            this._popupmenu.Name = "_popupmenu";
            this._popupmenu.Size = new System.Drawing.Size(61, 4);
            // 
            // _labelRaceInfo
            // 
            this._labelRaceInfo.AutoSize = true;
            this._labelRaceInfo.BackColor = System.Drawing.Color.PaleTurquoise;
            this._labelRaceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceInfo.Location = new System.Drawing.Point(27, 12);
            this._labelRaceInfo.Name = "_labelRaceInfo";
            this._labelRaceInfo.Size = new System.Drawing.Size(70, 25);
            this._labelRaceInfo.TabIndex = 41;
            this._labelRaceInfo.Text = "label1";
            // 
            // _labelPostPosition
            // 
            this._labelPostPosition.AutoSize = true;
            this._labelPostPosition.Location = new System.Drawing.Point(17, 116);
            this._labelPostPosition.Name = "_labelPostPosition";
            this._labelPostPosition.Size = new System.Drawing.Size(36, 13);
            this._labelPostPosition.TabIndex = 43;
            this._labelPostPosition.Text = "PP 12";
            this._labelPostPosition.Click += new System.EventHandler(this.OnShowPostPositionBehavior);
            // 
            // _buttonShowTimeGraphs
            // 
            this._buttonShowTimeGraphs.Location = new System.Drawing.Point(712, 3);
            this._buttonShowTimeGraphs.Name = "_buttonShowTimeGraphs";
            this._buttonShowTimeGraphs.Size = new System.Drawing.Size(75, 23);
            this._buttonShowTimeGraphs.TabIndex = 46;
            this._buttonShowTimeGraphs.Text = "Time Graphs";
            this._buttonShowTimeGraphs.UseVisualStyleBackColor = true;
            this._buttonShowTimeGraphs.Click += new System.EventHandler(this.OnShowTimeGraps);
            // 
            // _radioButtonFigures
            // 
            this._radioButtonFigures.AutoSize = true;
            this._radioButtonFigures.Location = new System.Drawing.Point(609, 168);
            this._radioButtonFigures.Name = "_radioButtonFigures";
            this._radioButtonFigures.Size = new System.Drawing.Size(59, 17);
            this._radioButtonFigures.TabIndex = 47;
            this._radioButtonFigures.TabStop = true;
            this._radioButtonFigures.Text = "Figures";
            this._radioButtonFigures.UseVisualStyleBackColor = true;
            this._radioButtonFigures.CheckedChanged += new System.EventHandler(this.OnRadioButtonWinnerCheckedChanged);
            // 
            // _brisFiguresStatsCtrl1
            // 
            this._brisFiguresStatsCtrl1.BackColor = System.Drawing.Color.Tan;
            this._brisFiguresStatsCtrl1.Location = new System.Drawing.Point(815, 5);
            this._brisFiguresStatsCtrl1.Name = "_brisFiguresStatsCtrl1";
            this._brisFiguresStatsCtrl1.Size = new System.Drawing.Size(209, 32);
            this._brisFiguresStatsCtrl1.TabIndex = 48;
            // 
            // _xRayCtrl
            // 
            this._xRayCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._xRayCtrl.Location = new System.Drawing.Point(735, 535);
            this._xRayCtrl.Name = "_xRayCtrl";
            this._xRayCtrl.Size = new System.Drawing.Size(610, 345);
            this._xRayCtrl.TabIndex = 45;
            // 
            // _factorAnalysisCtrl
            // 
            this._factorAnalysisCtrl.Location = new System.Drawing.Point(10, 524);
            this._factorAnalysisCtrl.Name = "_factorAnalysisCtrl";
            this._factorAnalysisCtrl.Size = new System.Drawing.Size(479, 360);
            this._factorAnalysisCtrl.TabIndex = 44;
            // 
            // _breedingInfoCtrl
            // 
            this._breedingInfoCtrl.Location = new System.Drawing.Point(1041, 3);
            this._breedingInfoCtrl.Name = "_breedingInfoCtrl";
            this._breedingInfoCtrl.Size = new System.Drawing.Size(304, 78);
            this._breedingInfoCtrl.TabIndex = 0;
            // 
            // _shortRaceChartControl
            // 
            this._shortRaceChartControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._shortRaceChartControl.Location = new System.Drawing.Point(495, 529);
            this._shortRaceChartControl.Name = "_shortRaceChartControl";
            this._shortRaceChartControl.Size = new System.Drawing.Size(221, 352);
            this._shortRaceChartControl.TabIndex = 40;
            // 
            // HorseFractionsComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._brisFiguresStatsCtrl1);
            this.Controls.Add(this._radioButtonFigures);
            this.Controls.Add(this._xRayCtrl);
            this.Controls.Add(this._buttonShowTimeGraphs);
            this.Controls.Add(this._factorAnalysisCtrl);
            this.Controls.Add(this._labelPostPosition);
            this.Controls.Add(this._labelRaceInfo);
            this.Controls.Add(this._txtboxHorseName);
            this.Controls.Add(this._txtboxOwner);
            this.Controls.Add(this._breedingInfoCtrl);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._shortRaceChartControl);
            this.Controls.Add(this._radioButtonThis);
            this.Controls.Add(this._radioButtonWinner);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._txtboxBrisRunStyle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._txtboxQuirinSpeedIndex);
            this.Controls.Add(this._panelWorkouts);
            this.Controls.Add(this._txtboxColorSexAge);
            this.Controls.Add(this._txtboxClaimingPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._txtboxDaysSinceLastRace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._txtboxPrimePowerRating);
            this.Controls.Add(this._txtboxTodaysDistanceEarnings);
            this.Controls.Add(this._txtboxTurfTrackEarnings);
            this.Controls.Add(this._txtboxWetTrackEarnings);
            this.Controls.Add(this._txtboxTodaysTrackEarnings);
            this.Controls.Add(this._txtboxPreviousYearEarnings);
            this.Controls.Add(this._txtboxCurrentYearEarnings);
            this.Controls.Add(this._txtboxLifeTimeEarnings);
            this.Controls.Add(this._txtboxWeight);
            this.Controls.Add(this._txtboxTrainerInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtboxDamInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtboxSireInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtboxOdds);
            this.Controls.Add(this._txtboxOwnersSilks);
            this.Controls.Add(this._txtboxHorseNumber);
            this.Controls.Add(this._txtboxJockeyName);
            this.DoubleBuffered = true;
            this.Name = "HorseFractionsComponent";
            this.Size = new System.Drawing.Size(1372, 887);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtboxHorseNumber;
        private System.Windows.Forms.TextBox _txtboxHorseName;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtboxJockeyName;
        private System.Windows.Forms.TextBox _txtboxOwner;
        private System.Windows.Forms.TextBox _txtboxOwnersSilks;
        private System.Windows.Forms.TextBox _txtboxOdds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtboxSireInfo;
        private System.Windows.Forms.TextBox _txtboxDamInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtboxTrainerInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtboxWeight;
        private System.Windows.Forms.TextBox _txtboxLifeTimeEarnings;
        private System.Windows.Forms.TextBox _txtboxCurrentYearEarnings;
        private System.Windows.Forms.TextBox _txtboxPreviousYearEarnings;
        private System.Windows.Forms.TextBox _txtboxTodaysTrackEarnings;
        private System.Windows.Forms.TextBox _txtboxWetTrackEarnings;
        private System.Windows.Forms.TextBox _txtboxTurfTrackEarnings;
        private System.Windows.Forms.TextBox _txtboxTodaysDistanceEarnings;
        private System.Windows.Forms.TextBox _txtboxPrimePowerRating;
        private System.Windows.Forms.TextBox _txtboxDaysSinceLastRace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtboxClaimingPrice;
        private System.Windows.Forms.TextBox _txtboxColorSexAge;
        private System.Windows.Forms.FlowLayoutPanel _panelWorkouts;
        private System.Windows.Forms.TextBox _txtboxQuirinSpeedIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _txtboxBrisRunStyle;
        private BreedingInfoCtrl _breedingInfoCtrl;
        private System.Windows.Forms.RadioButton _radioButtonWinner;
        private System.Windows.Forms.RadioButton _radioButtonThis;
        private System.Windows.Forms.ContextMenuStrip _popupmenu;
        private ShortRaceChartControl _shortRaceChartControl;
        private System.Windows.Forms.Label _labelRaceInfo;
        private System.Windows.Forms.Label _labelPostPosition;
        private FactorAnalysisCtrl _factorAnalysisCtrl;
        private OddsEditor.Dialogs.WinnersForDay.XRayCtrl _xRayCtrl;
        private System.Windows.Forms.Button _buttonShowTimeGraphs;
        private System.Windows.Forms.RadioButton _radioButtonFigures;
        private BrisFiguresStatsCtrl _brisFiguresStatsCtrl1;
    }
}
