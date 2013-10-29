namespace OddsEditor.Dialogs
{
    partial class KellyCalculatorForm
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
            this._groupOdds = new System.Windows.Forms.GroupBox();
            this._groupWinPercent = new System.Windows.Forms.GroupBox();
            this._groupBetPercent = new System.Windows.Forms.GroupBox();
            this._txtPercentToBet = new System.Windows.Forms.TextBox();
            this._txtboxWinningPercent = new OddsEditor.MyComponents.NumericTextBox();
            this._txtboxOddsToOne = new OddsEditor.MyComponents.NumericTextBox();
            this._groupOdds.SuspendLayout();
            this._groupWinPercent.SuspendLayout();
            this._groupBetPercent.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupOdds
            // 
            this._groupOdds.Controls.Add(this._txtboxOddsToOne);
            this._groupOdds.Location = new System.Drawing.Point(13, 13);
            this._groupOdds.Name = "_groupOdds";
            this._groupOdds.Size = new System.Drawing.Size(89, 62);
            this._groupOdds.TabIndex = 0;
            this._groupOdds.TabStop = false;
            this._groupOdds.Text = "Odds To One";
            // 
            // _groupWinPercent
            // 
            this._groupWinPercent.Controls.Add(this._txtboxWinningPercent);
            this._groupWinPercent.Location = new System.Drawing.Point(108, 13);
            this._groupWinPercent.Name = "_groupWinPercent";
            this._groupWinPercent.Size = new System.Drawing.Size(89, 62);
            this._groupWinPercent.TabIndex = 1;
            this._groupWinPercent.TabStop = false;
            this._groupWinPercent.Text = "Winning %";
            // 
            // _groupBetPercent
            // 
            this._groupBetPercent.Controls.Add(this._txtPercentToBet);
            this._groupBetPercent.Location = new System.Drawing.Point(203, 13);
            this._groupBetPercent.Name = "_groupBetPercent";
            this._groupBetPercent.Size = new System.Drawing.Size(105, 62);
            this._groupBetPercent.TabIndex = 2;
            this._groupBetPercent.TabStop = false;
            this._groupBetPercent.Text = "% To bet";
            // 
            // _txtPercentToBet
            // 
            this._txtPercentToBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPercentToBet.Location = new System.Drawing.Point(15, 19);
            this._txtPercentToBet.Name = "_txtPercentToBet";
            this._txtPercentToBet.ReadOnly = true;
            this._txtPercentToBet.Size = new System.Drawing.Size(75, 35);
            this._txtPercentToBet.TabIndex = 0;
            // 
            // _txtboxWinningPercent
            // 
            this._txtboxWinningPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxWinningPercent.Location = new System.Drawing.Point(6, 18);
            this._txtboxWinningPercent.Name = "_txtboxWinningPercent";
            this._txtboxWinningPercent.Size = new System.Drawing.Size(77, 35);
            this._txtboxWinningPercent.TabIndex = 0;
            // 
            // _txtboxOddsToOne
            // 
            this._txtboxOddsToOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxOddsToOne.Location = new System.Drawing.Point(7, 18);
            this._txtboxOddsToOne.Name = "_txtboxOddsToOne";
            this._txtboxOddsToOne.Size = new System.Drawing.Size(69, 35);
            this._txtboxOddsToOne.TabIndex = 0;
            // 
            // KellyCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 87);
            this.Controls.Add(this._groupBetPercent);
            this.Controls.Add(this._groupWinPercent);
            this.Controls.Add(this._groupOdds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KellyCalculatorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Kelly Calculator";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._groupOdds.ResumeLayout(false);
            this._groupOdds.PerformLayout();
            this._groupWinPercent.ResumeLayout(false);
            this._groupWinPercent.PerformLayout();
            this._groupBetPercent.ResumeLayout(false);
            this._groupBetPercent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupOdds;
        private System.Windows.Forms.GroupBox _groupWinPercent;
        private System.Windows.Forms.GroupBox _groupBetPercent;
        private System.Windows.Forms.TextBox _txtPercentToBet;
        private OddsEditor.MyComponents.NumericTextBox _txtboxOddsToOne;
        private OddsEditor.MyComponents.NumericTextBox _txtboxWinningPercent;
    }
}