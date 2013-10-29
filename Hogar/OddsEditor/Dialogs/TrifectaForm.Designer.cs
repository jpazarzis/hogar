namespace OddsEditor.Dialogs
{
    partial class TrifectaForm
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
            this._panelSelections = new System.Windows.Forms.FlowLayoutPanel();
            this._panelHorseNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this._txtboxTotalNumberOfCombinations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._comboboxAmountToWin = new System.Windows.Forms.ComboBox();
            this._txtboxAmountNeeded = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtBoxROI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._panelRaceSummary = new System.Windows.Forms.FlowLayoutPanel();
            this._trifectaSubsystemsControl = new OddsEditor.MyComponents.TrifectaSubsystemsControl();
            this._trifectaPayoutsControl = new OddsEditor.MyComponents.TrifectaPayoutsControl();
            this._oddsControl = new OddsEditor.MyComponents.OddsControl();
            this.SuspendLayout();
            // 
            // _panelSelections
            // 
            this._panelSelections.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._panelSelections.Location = new System.Drawing.Point(781, 51);
            this._panelSelections.Name = "_panelSelections";
            this._panelSelections.Size = new System.Drawing.Size(573, 154);
            this._panelSelections.TabIndex = 0;
            // 
            // _panelHorseNumbers
            // 
            this._panelHorseNumbers.BackColor = System.Drawing.Color.DarkBlue;
            this._panelHorseNumbers.Location = new System.Drawing.Point(781, 221);
            this._panelHorseNumbers.Name = "_panelHorseNumbers";
            this._panelHorseNumbers.Size = new System.Drawing.Size(573, 118);
            this._panelHorseNumbers.TabIndex = 1;
            // 
            // _txtboxTotalNumberOfCombinations
            // 
            this._txtboxTotalNumberOfCombinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTotalNumberOfCombinations.Location = new System.Drawing.Point(781, 345);
            this._txtboxTotalNumberOfCombinations.Multiline = true;
            this._txtboxTotalNumberOfCombinations.Name = "_txtboxTotalNumberOfCombinations";
            this._txtboxTotalNumberOfCombinations.ReadOnly = true;
            this._txtboxTotalNumberOfCombinations.Size = new System.Drawing.Size(573, 29);
            this._txtboxTotalNumberOfCombinations.TabIndex = 2;
            this._txtboxTotalNumberOfCombinations.Text = "Total";
            this._txtboxTotalNumberOfCombinations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1136, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expected Payoff";
            // 
            // _comboboxAmountToWin
            // 
            this._comboboxAmountToWin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboboxAmountToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comboboxAmountToWin.FormattingEnabled = true;
            this._comboboxAmountToWin.Items.AddRange(new object[] {
            "200",
            "500",
            "1000",
            "2000",
            "3000",
            "5000"});
            this._comboboxAmountToWin.Location = new System.Drawing.Point(1281, 12);
            this._comboboxAmountToWin.Name = "_comboboxAmountToWin";
            this._comboboxAmountToWin.Size = new System.Drawing.Size(70, 28);
            this._comboboxAmountToWin.TabIndex = 5;
            this._comboboxAmountToWin.SelectedIndexChanged += new System.EventHandler(this.OnAmountToWinChanged);
            // 
            // _txtboxAmountNeeded
            // 
            this._txtboxAmountNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxAmountNeeded.Location = new System.Drawing.Point(1066, 9);
            this._txtboxAmountNeeded.Name = "_txtboxAmountNeeded";
            this._txtboxAmountNeeded.ReadOnly = true;
            this._txtboxAmountNeeded.Size = new System.Drawing.Size(64, 26);
            this._txtboxAmountNeeded.TabIndex = 7;
            this._txtboxAmountNeeded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(978, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Bet";
            // 
            // _txtBoxROI
            // 
            this._txtBoxROI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtBoxROI.Location = new System.Drawing.Point(900, 9);
            this._txtBoxROI.Name = "_txtBoxROI";
            this._txtBoxROI.ReadOnly = true;
            this._txtBoxROI.Size = new System.Drawing.Size(64, 26);
            this._txtBoxROI.TabIndex = 11;
            this._txtBoxROI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(854, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "ROI";
            // 
            // _panelRaceSummary
            // 
            this._panelRaceSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panelRaceSummary.AutoScroll = true;
            this._panelRaceSummary.Location = new System.Drawing.Point(195, 380);
            this._panelRaceSummary.Name = "_panelRaceSummary";
            this._panelRaceSummary.Size = new System.Drawing.Size(1156, 415);
            this._panelRaceSummary.TabIndex = 12;
            // 
            // _trifectaSubsystemsControl
            // 
            this._trifectaSubsystemsControl.Location = new System.Drawing.Point(483, 12);
            this._trifectaSubsystemsControl.Name = "_trifectaSubsystemsControl";
            this._trifectaSubsystemsControl.Size = new System.Drawing.Size(292, 368);
            this._trifectaSubsystemsControl.TabIndex = 9;
            // 
            // _trifectaPayoutsControl
            // 
            this._trifectaPayoutsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._trifectaPayoutsControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._trifectaPayoutsControl.Location = new System.Drawing.Point(195, -1);
            this._trifectaPayoutsControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this._trifectaPayoutsControl.Name = "_trifectaPayoutsControl";
            this._trifectaPayoutsControl.Size = new System.Drawing.Size(282, 381);
            this._trifectaPayoutsControl.TabIndex = 3;
            // 
            // _oddsControl
            // 
            this._oddsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._oddsControl.Location = new System.Drawing.Point(7, 49);
            this._oddsControl.Name = "_oddsControl";
            this._oddsControl.Size = new System.Drawing.Size(180, 746);
            this._oddsControl.TabIndex = 0;
            // 
            // TrifectaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1363, 810);
            this.Controls.Add(this._panelRaceSummary);
            this.Controls.Add(this._txtBoxROI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._trifectaSubsystemsControl);
            this.Controls.Add(this._trifectaPayoutsControl);
            this.Controls.Add(this._txtboxAmountNeeded);
            this.Controls.Add(this._oddsControl);
            this.Controls.Add(this._txtboxTotalNumberOfCombinations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._panelHorseNumbers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._panelSelections);
            this.Controls.Add(this._comboboxAmountToWin);
            this.Name = "TrifectaForm";
            this.Text = "TrifectaForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panelSelections;
        private System.Windows.Forms.FlowLayoutPanel _panelHorseNumbers;
        private System.Windows.Forms.TextBox _txtboxTotalNumberOfCombinations;
        private OddsEditor.MyComponents.OddsControl _oddsControl;
        private OddsEditor.MyComponents.TrifectaPayoutsControl _trifectaPayoutsControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _comboboxAmountToWin;
        private System.Windows.Forms.TextBox _txtboxAmountNeeded;
        private System.Windows.Forms.Label label2;
        private OddsEditor.MyComponents.TrifectaSubsystemsControl _trifectaSubsystemsControl;
        private System.Windows.Forms.TextBox _txtBoxROI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel _panelRaceSummary;
    }
}