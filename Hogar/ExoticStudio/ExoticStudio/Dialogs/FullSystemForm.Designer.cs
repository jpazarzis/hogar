namespace ExoticStudio
{
    partial class FullSystemForm
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

        #region System Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._raceTrackComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._OKButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._firstRaceCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._numberOfCombinationsTextBox = new System.Windows.Forms.TextBox();
            this._ressetButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this._unitBetComboBox = new System.Windows.Forms.ComboBox();
            this._buttonAutoSelectFromWeightsFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dateTimePicker.Location = new System.Drawing.Point(82, 55);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.Size = new System.Drawing.Size(100, 20);
            this._dateTimePicker.TabIndex = 15;
            // 
            // _raceTrackComboBox
            // 
            this._raceTrackComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._raceTrackComboBox.FormattingEnabled = true;
            this._raceTrackComboBox.Location = new System.Drawing.Point(82, 23);
            this._raceTrackComboBox.Name = "_raceTrackComboBox";
            this._raceTrackComboBox.Size = new System.Drawing.Size(100, 21);
            this._raceTrackComboBox.TabIndex = 14;
            this._raceTrackComboBox.SelectedIndexChanged += new System.EventHandler(this.OnTrackComboBoxIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Race Track";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Full System";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 139);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grid.Size = new System.Drawing.Size(732, 420);
            this._grid.TabIndex = 10;
            this._grid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnMouseClick);
            this._grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnGridMouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(765, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _OKButton
            // 
            this._OKButton.Location = new System.Drawing.Point(669, 21);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 16;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this.OnOK);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(669, 59);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 17;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "First Race";
            // 
            // _firstRaceCombo
            // 
            this._firstRaceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._firstRaceCombo.FormattingEnabled = true;
            this._firstRaceCombo.Location = new System.Drawing.Point(428, 21);
            this._firstRaceCombo.Name = "_firstRaceCombo";
            this._firstRaceCombo.Size = new System.Drawing.Size(48, 21);
            this._firstRaceCombo.TabIndex = 19;
            this._firstRaceCombo.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Total number of Combinations";
            // 
            // _numberOfCombinationsTextBox
            // 
            this._numberOfCombinationsTextBox.Location = new System.Drawing.Point(412, 56);
            this._numberOfCombinationsTextBox.Name = "_numberOfCombinationsTextBox";
            this._numberOfCombinationsTextBox.ReadOnly = true;
            this._numberOfCombinationsTextBox.Size = new System.Drawing.Size(64, 20);
            this._numberOfCombinationsTextBox.TabIndex = 21;
            // 
            // _ressetButton
            // 
            this._ressetButton.Location = new System.Drawing.Point(28, 90);
            this._ressetButton.Name = "_ressetButton";
            this._ressetButton.Size = new System.Drawing.Size(75, 23);
            this._ressetButton.TabIndex = 22;
            this._ressetButton.Text = "Reset";
            this._ressetButton.UseVisualStyleBackColor = true;
            this._ressetButton.Click += new System.EventHandler(this.OnReset);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(521, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Unit Bet";
            // 
            // _unitBetComboBox
            // 
            this._unitBetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._unitBetComboBox.FormattingEnabled = true;
            this._unitBetComboBox.Location = new System.Drawing.Point(573, 23);
            this._unitBetComboBox.Name = "_unitBetComboBox";
            this._unitBetComboBox.Size = new System.Drawing.Size(51, 21);
            this._unitBetComboBox.TabIndex = 24;
            this._unitBetComboBox.SelectedIndexChanged += new System.EventHandler(this.OnUnitBetChanged);
            // 
            // _buttonAutoSelectFromWeightsFile
            // 
            this._buttonAutoSelectFromWeightsFile.Location = new System.Drawing.Point(125, 90);
            this._buttonAutoSelectFromWeightsFile.Name = "_buttonAutoSelectFromWeightsFile";
            this._buttonAutoSelectFromWeightsFile.Size = new System.Drawing.Size(75, 23);
            this._buttonAutoSelectFromWeightsFile.TabIndex = 25;
            this._buttonAutoSelectFromWeightsFile.Text = "Auto Select";
            this._buttonAutoSelectFromWeightsFile.UseVisualStyleBackColor = true;
            this._buttonAutoSelectFromWeightsFile.Click += new System.EventHandler(this._buttonAutoSelectFromWeightsFile_Click);
            // 
            // FullSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 571);
            this.Controls.Add(this._buttonAutoSelectFromWeightsFile);
            this.Controls.Add(this._unitBetComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._ressetButton);
            this.Controls.Add(this._numberOfCombinationsTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._firstRaceCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._dateTimePicker);
            this.Controls.Add(this._raceTrackComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._grid);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullSystemForm";
            this.Text = "SelectFullSystemForm1";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _dateTimePicker;
        private System.Windows.Forms.ComboBox _raceTrackComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _firstRaceCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _numberOfCombinationsTextBox;
        private System.Windows.Forms.Button _ressetButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _unitBetComboBox;
        private System.Windows.Forms.Button _buttonAutoSelectFromWeightsFile;
    }
}