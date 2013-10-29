namespace OddsEditor.Dialogs
{
    partial class RaceChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceChartForm));
            this._txtboxRaceTrackName = new System.Windows.Forms.TextBox();
            this._txtboxRaceNumberAndDate = new System.Windows.Forms.TextBox();
            this._labelRaceCondition = new System.Windows.Forms.Label();
            this._panelRaceDescription = new System.Windows.Forms.FlowLayoutPanel();
            this._txtboxDistanceAndSurface = new System.Windows.Forms.Label();
            this._labelTrackCondition = new System.Windows.Forms.Label();
            this._labelFinalTime = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._txtboxFootNotes = new System.Windows.Forms.RichTextBox();
            this._gridSelectedHorseRaces = new System.Windows.Forms.DataGridView();
            this._buttonBack = new System.Windows.Forms.Button();
            this._buttonForward = new System.Windows.Forms.Button();
            this._labelHorseName = new System.Windows.Forms.Label();
            this._popUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._panelRaceDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSelectedHorseRaces)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtboxRaceTrackName
            // 
            this._txtboxRaceTrackName.BackColor = System.Drawing.Color.DodgerBlue;
            this._txtboxRaceTrackName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxRaceTrackName.Dock = System.Windows.Forms.DockStyle.Top;
            this._txtboxRaceTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxRaceTrackName.ForeColor = System.Drawing.Color.White;
            this._txtboxRaceTrackName.Location = new System.Drawing.Point(0, 0);
            this._txtboxRaceTrackName.Name = "_txtboxRaceTrackName";
            this._txtboxRaceTrackName.ReadOnly = true;
            this._txtboxRaceTrackName.Size = new System.Drawing.Size(1376, 31);
            this._txtboxRaceTrackName.TabIndex = 0;
            this._txtboxRaceTrackName.Text = "ΦΑΛΗΡΙΚΟ ΔΕΛΤΑ";
            this._txtboxRaceTrackName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtboxRaceNumberAndDate
            // 
            this._txtboxRaceNumberAndDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this._txtboxRaceNumberAndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxRaceNumberAndDate.Dock = System.Windows.Forms.DockStyle.Top;
            this._txtboxRaceNumberAndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxRaceNumberAndDate.ForeColor = System.Drawing.Color.Blue;
            this._txtboxRaceNumberAndDate.Location = new System.Drawing.Point(0, 31);
            this._txtboxRaceNumberAndDate.Name = "_txtboxRaceNumberAndDate";
            this._txtboxRaceNumberAndDate.ReadOnly = true;
            this._txtboxRaceNumberAndDate.Size = new System.Drawing.Size(1376, 31);
            this._txtboxRaceNumberAndDate.TabIndex = 1;
            this._txtboxRaceNumberAndDate.Text = "First Race";
            this._txtboxRaceNumberAndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _labelRaceCondition
            // 
            this._labelRaceCondition.AutoSize = true;
            this._labelRaceCondition.BackColor = System.Drawing.Color.Black;
            this._labelRaceCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceCondition.ForeColor = System.Drawing.Color.Yellow;
            this._labelRaceCondition.Location = new System.Drawing.Point(3, 0);
            this._labelRaceCondition.Name = "_labelRaceCondition";
            this._labelRaceCondition.Size = new System.Drawing.Size(67, 25);
            this._labelRaceCondition.TabIndex = 3;
            this._labelRaceCondition.Text = "MSW";
            this._labelRaceCondition.Click += new System.EventHandler(this._labelRaceCondition_Click);
            // 
            // _panelRaceDescription
            // 
            this._panelRaceDescription.BackColor = System.Drawing.Color.Aquamarine;
            this._panelRaceDescription.Controls.Add(this._labelRaceCondition);
            this._panelRaceDescription.Controls.Add(this._txtboxDistanceAndSurface);
            this._panelRaceDescription.Controls.Add(this._labelTrackCondition);
            this._panelRaceDescription.Controls.Add(this._labelFinalTime);
            this._panelRaceDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelRaceDescription.Location = new System.Drawing.Point(0, 62);
            this._panelRaceDescription.Name = "_panelRaceDescription";
            this._panelRaceDescription.Size = new System.Drawing.Size(1376, 43);
            this._panelRaceDescription.TabIndex = 4;
            // 
            // _txtboxDistanceAndSurface
            // 
            this._txtboxDistanceAndSurface.AutoSize = true;
            this._txtboxDistanceAndSurface.BackColor = System.Drawing.Color.Black;
            this._txtboxDistanceAndSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDistanceAndSurface.ForeColor = System.Drawing.Color.Yellow;
            this._txtboxDistanceAndSurface.Location = new System.Drawing.Point(76, 0);
            this._txtboxDistanceAndSurface.Name = "_txtboxDistanceAndSurface";
            this._txtboxDistanceAndSurface.Size = new System.Drawing.Size(117, 25);
            this._txtboxDistanceAndSurface.TabIndex = 5;
            this._txtboxDistanceAndSurface.Text = "5 furlongs";
            // 
            // _labelTrackCondition
            // 
            this._labelTrackCondition.AutoSize = true;
            this._labelTrackCondition.BackColor = System.Drawing.Color.Black;
            this._labelTrackCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTrackCondition.ForeColor = System.Drawing.Color.Yellow;
            this._labelTrackCondition.Location = new System.Drawing.Point(199, 0);
            this._labelTrackCondition.Name = "_labelTrackCondition";
            this._labelTrackCondition.Size = new System.Drawing.Size(58, 25);
            this._labelTrackCondition.TabIndex = 5;
            this._labelTrackCondition.Text = "Fast";
            // 
            // _labelFinalTime
            // 
            this._labelFinalTime.AutoSize = true;
            this._labelFinalTime.BackColor = System.Drawing.Color.Black;
            this._labelFinalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelFinalTime.ForeColor = System.Drawing.Color.Yellow;
            this._labelFinalTime.Location = new System.Drawing.Point(263, 0);
            this._labelFinalTime.Name = "_labelFinalTime";
            this._labelFinalTime.Size = new System.Drawing.Size(78, 25);
            this._labelFinalTime.TabIndex = 6;
            this._labelFinalTime.Text = "1.10.2";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.BackgroundColor = System.Drawing.Color.LightCyan;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Location = new System.Drawing.Point(7, 111);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.DividerHeight = 1;
            this._grid.RowTemplate.Height = 44;
            this._grid.Size = new System.Drawing.Size(800, 542);
            this._grid.TabIndex = 5;
            this._grid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnCellMouseClick);
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormatting);
            // 
            // _txtboxFootNotes
            // 
            this._txtboxFootNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxFootNotes.Location = new System.Drawing.Point(813, 111);
            this._txtboxFootNotes.Name = "_txtboxFootNotes";
            this._txtboxFootNotes.ReadOnly = true;
            this._txtboxFootNotes.Size = new System.Drawing.Size(550, 542);
            this._txtboxFootNotes.TabIndex = 6;
            this._txtboxFootNotes.Text = "";
            // 
            // _gridSelectedHorseRaces
            // 
            this._gridSelectedHorseRaces.AllowUserToAddRows = false;
            this._gridSelectedHorseRaces.AllowUserToDeleteRows = false;
            this._gridSelectedHorseRaces.AllowUserToOrderColumns = true;
            this._gridSelectedHorseRaces.AllowUserToResizeColumns = false;
            this._gridSelectedHorseRaces.AllowUserToResizeRows = false;
            this._gridSelectedHorseRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridSelectedHorseRaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridSelectedHorseRaces.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridSelectedHorseRaces.Location = new System.Drawing.Point(7, 688);
            this._gridSelectedHorseRaces.MultiSelect = false;
            this._gridSelectedHorseRaces.Name = "_gridSelectedHorseRaces";
            this._gridSelectedHorseRaces.ReadOnly = true;
            this._gridSelectedHorseRaces.RowHeadersVisible = false;
            this._gridSelectedHorseRaces.Size = new System.Drawing.Size(1356, 189);
            this._gridSelectedHorseRaces.TabIndex = 7;
            this._gridSelectedHorseRaces.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnSelectedHorseRacesCellMouseClick);
            // 
            // _buttonBack
            // 
            this._buttonBack.FlatAppearance.BorderSize = 0;
            this._buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("_buttonBack.Image")));
            this._buttonBack.Location = new System.Drawing.Point(7, 2);
            this._buttonBack.Name = "_buttonBack";
            this._buttonBack.Size = new System.Drawing.Size(43, 23);
            this._buttonBack.TabIndex = 8;
            this._buttonBack.UseVisualStyleBackColor = true;
            this._buttonBack.Click += new System.EventHandler(this.ObBackButton);
            // 
            // _buttonForward
            // 
            this._buttonForward.FlatAppearance.BorderSize = 0;
            this._buttonForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonForward.Image = ((System.Drawing.Image)(resources.GetObject("_buttonForward.Image")));
            this._buttonForward.Location = new System.Drawing.Point(57, 2);
            this._buttonForward.Name = "_buttonForward";
            this._buttonForward.Size = new System.Drawing.Size(44, 23);
            this._buttonForward.TabIndex = 9;
            this._buttonForward.UseVisualStyleBackColor = true;
            this._buttonForward.Click += new System.EventHandler(this.OnForwardButton);
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.BackColor = System.Drawing.Color.DodgerBlue;
            this._labelHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._labelHorseName.Location = new System.Drawing.Point(15, 656);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(0, 29);
            this._labelHorseName.TabIndex = 10;
            // 
            // _popUpMenu
            // 
            this._popUpMenu.Name = "_popUpMenu";
            this._popUpMenu.Size = new System.Drawing.Size(153, 26);
            // 
            // RaceChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1376, 896);
            this.Controls.Add(this._labelHorseName);
            this.Controls.Add(this._buttonForward);
            this.Controls.Add(this._buttonBack);
            this.Controls.Add(this._gridSelectedHorseRaces);
            this.Controls.Add(this._txtboxFootNotes);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._panelRaceDescription);
            this.Controls.Add(this._txtboxRaceNumberAndDate);
            this.Controls.Add(this._txtboxRaceTrackName);
            this.Name = "RaceChartForm";
            this.ShowInTaskbar = false;
            this.Text = "RaceChartForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._panelRaceDescription.ResumeLayout(false);
            this._panelRaceDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSelectedHorseRaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtboxRaceTrackName;
        private System.Windows.Forms.TextBox _txtboxRaceNumberAndDate;
        private System.Windows.Forms.Label _labelRaceCondition;
        private System.Windows.Forms.FlowLayoutPanel _panelRaceDescription;
        private System.Windows.Forms.Label _txtboxDistanceAndSurface;
        private System.Windows.Forms.Label _labelTrackCondition;
        private System.Windows.Forms.Label _labelFinalTime;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.RichTextBox _txtboxFootNotes;
        private System.Windows.Forms.DataGridView _gridSelectedHorseRaces;
        private System.Windows.Forms.Button _buttonBack;
        private System.Windows.Forms.Button _buttonForward;
        private System.Windows.Forms.Label _labelHorseName;
        private System.Windows.Forms.ContextMenuStrip _popUpMenu;
    }
}