namespace OddsEditor.Dialogs
{
    partial class FractionSpeedForm
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
            this.label3 = new System.Windows.Forms.Label();
            this._txtboxTrackName = new System.Windows.Forms.TextBox();
            this._txtboxRaceNumber = new System.Windows.Forms.TextBox();
            this._txtboxDate = new System.Windows.Forms.TextBox();
            this._txtboxDistance = new System.Windows.Forms.TextBox();
            this._radioShowLeadersTime = new System.Windows.Forms.RadioButton();
            this._radioThisHorseTime = new System.Windows.Forms.RadioButton();
            this._panelPastPerformances = new System.Windows.Forms.Panel();
            this._txtboxRaceConditions = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(655, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // _txtboxTrackName
            // 
            this._txtboxTrackName.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxTrackName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTrackName.Location = new System.Drawing.Point(123, 13);
            this._txtboxTrackName.Name = "_txtboxTrackName";
            this._txtboxTrackName.ReadOnly = true;
            this._txtboxTrackName.Size = new System.Drawing.Size(216, 28);
            this._txtboxTrackName.TabIndex = 3;
            this._txtboxTrackName.Text = "DELTA FALHROY";
            // 
            // _txtboxRaceNumber
            // 
            this._txtboxRaceNumber.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxRaceNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxRaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxRaceNumber.Location = new System.Drawing.Point(34, 13);
            this._txtboxRaceNumber.Name = "_txtboxRaceNumber";
            this._txtboxRaceNumber.ReadOnly = true;
            this._txtboxRaceNumber.Size = new System.Drawing.Size(83, 73);
            this._txtboxRaceNumber.TabIndex = 4;
            this._txtboxRaceNumber.Text = "10";
            // 
            // _txtboxDate
            // 
            this._txtboxDate.Location = new System.Drawing.Point(692, 12);
            this._txtboxDate.Name = "_txtboxDate";
            this._txtboxDate.ReadOnly = true;
            this._txtboxDate.Size = new System.Drawing.Size(59, 20);
            this._txtboxDate.TabIndex = 5;
            // 
            // _txtboxDistance
            // 
            this._txtboxDistance.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDistance.Location = new System.Drawing.Point(345, 20);
            this._txtboxDistance.Name = "_txtboxDistance";
            this._txtboxDistance.ReadOnly = true;
            this._txtboxDistance.Size = new System.Drawing.Size(169, 19);
            this._txtboxDistance.TabIndex = 6;
            this._txtboxDistance.Text = "6 Furlongs";
            // 
            // _radioShowLeadersTime
            // 
            this._radioShowLeadersTime.AutoSize = true;
            this._radioShowLeadersTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._radioShowLeadersTime.Location = new System.Drawing.Point(14, 8);
            this._radioShowLeadersTime.Name = "_radioShowLeadersTime";
            this._radioShowLeadersTime.Size = new System.Drawing.Size(126, 20);
            this._radioShowLeadersTime.TabIndex = 7;
            this._radioShowLeadersTime.TabStop = true;
            this._radioShowLeadersTime.Text = "Leader\'s Time";
            this._radioShowLeadersTime.UseVisualStyleBackColor = true;
            this._radioShowLeadersTime.Click += new System.EventHandler(this._radioShowLeadersTime_Click);
            // 
            // _radioThisHorseTime
            // 
            this._radioThisHorseTime.AutoSize = true;
            this._radioThisHorseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._radioThisHorseTime.Location = new System.Drawing.Point(143, 8);
            this._radioThisHorseTime.Name = "_radioThisHorseTime";
            this._radioThisHorseTime.Size = new System.Drawing.Size(119, 20);
            this._radioThisHorseTime.TabIndex = 8;
            this._radioThisHorseTime.TabStop = true;
            this._radioThisHorseTime.Text = "Horse\'s Time";
            this._radioThisHorseTime.UseVisualStyleBackColor = true;
            this._radioThisHorseTime.Click += new System.EventHandler(this._radioThisHorseTime_Click);
            // 
            // _panelPastPerformances
            // 
            this._panelPastPerformances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panelPastPerformances.AutoScroll = true;
            this._panelPastPerformances.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelPastPerformances.Location = new System.Drawing.Point(27, 93);
            this._panelPastPerformances.Name = "_panelPastPerformances";
            this._panelPastPerformances.Size = new System.Drawing.Size(1262, 689);
            this._panelPastPerformances.TabIndex = 9;
            // 
            // _txtboxRaceConditions
            // 
            this._txtboxRaceConditions.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxRaceConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxRaceConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxRaceConditions.Location = new System.Drawing.Point(124, 48);
            this._txtboxRaceConditions.Multiline = true;
            this._txtboxRaceConditions.Name = "_txtboxRaceConditions";
            this._txtboxRaceConditions.ReadOnly = true;
            this._txtboxRaceConditions.Size = new System.Drawing.Size(711, 39);
            this._txtboxRaceConditions.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._radioThisHorseTime);
            this.panel1.Controls.Add(this._radioShowLeadersTime);
            this.panel1.Location = new System.Drawing.Point(844, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 38);
            this.panel1.TabIndex = 11;
            // 
            // FractionSpeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1324, 811);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._txtboxRaceConditions);
            this.Controls.Add(this._panelPastPerformances);
            this.Controls.Add(this._txtboxDistance);
            this.Controls.Add(this._txtboxDate);
            this.Controls.Add(this._txtboxRaceNumber);
            this.Controls.Add(this._txtboxTrackName);
            this.Controls.Add(this.label3);
            this.Name = "FractionSpeedForm";
            this.Text = "FractionSpeedForm (c) Delta 2008 - 2009  (c) John Pazarzis 2008-09";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtboxTrackName;
        private System.Windows.Forms.TextBox _txtboxRaceNumber;
        private System.Windows.Forms.TextBox _txtboxDate;
        private System.Windows.Forms.TextBox _txtboxDistance;
        private System.Windows.Forms.RadioButton _radioShowLeadersTime;
        private System.Windows.Forms.RadioButton _radioThisHorseTime;
        private System.Windows.Forms.Panel _panelPastPerformances;
        private System.Windows.Forms.TextBox _txtboxRaceConditions;
        private System.Windows.Forms.Panel panel1;
    }
}