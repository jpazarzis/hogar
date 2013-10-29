namespace OddsEditor.Dialogs
{
    partial class BacktestProbabilityCalculatorForm
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
            this._tab = new System.Windows.Forms.TabControl();
            this._tabPageCalculate = new System.Windows.Forms.TabPage();
            this._tabBackTest = new System.Windows.Forms.TabPage();
            this.calculateConstantsControl1 = new OddsEditor.MyComponents.CalculateConstantsControl();
            this.backTestControl1 = new OddsEditor.MyComponents.BackTestControl();
            this._tab.SuspendLayout();
            this._tabPageCalculate.SuspendLayout();
            this._tabBackTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tab
            // 
            this._tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tab.Controls.Add(this._tabPageCalculate);
            this._tab.Controls.Add(this._tabBackTest);
            this._tab.Location = new System.Drawing.Point(12, 12);
            this._tab.Name = "_tab";
            this._tab.SelectedIndex = 0;
            this._tab.Size = new System.Drawing.Size(646, 521);
            this._tab.TabIndex = 0;
            // 
            // _tabPageCalculate
            // 
            this._tabPageCalculate.Controls.Add(this.calculateConstantsControl1);
            this._tabPageCalculate.Location = new System.Drawing.Point(4, 22);
            this._tabPageCalculate.Name = "_tabPageCalculate";
            this._tabPageCalculate.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageCalculate.Size = new System.Drawing.Size(638, 495);
            this._tabPageCalculate.TabIndex = 0;
            this._tabPageCalculate.Text = "Calculate";
            this._tabPageCalculate.UseVisualStyleBackColor = true;
            // 
            // _tabBackTest
            // 
            this._tabBackTest.Controls.Add(this.backTestControl1);
            this._tabBackTest.Location = new System.Drawing.Point(4, 22);
            this._tabBackTest.Name = "_tabBackTest";
            this._tabBackTest.Padding = new System.Windows.Forms.Padding(3);
            this._tabBackTest.Size = new System.Drawing.Size(638, 495);
            this._tabBackTest.TabIndex = 1;
            this._tabBackTest.Text = "Backtest";
            this._tabBackTest.UseVisualStyleBackColor = true;
            // 
            // calculateConstantsControl1
            // 
            this.calculateConstantsControl1.Location = new System.Drawing.Point(7, 7);
            this.calculateConstantsControl1.Name = "calculateConstantsControl1";
            this.calculateConstantsControl1.Size = new System.Drawing.Size(612, 259);
            this.calculateConstantsControl1.TabIndex = 0;
            // 
            // backTestControl1
            // 
            this.backTestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backTestControl1.Location = new System.Drawing.Point(3, 3);
            this.backTestControl1.Name = "backTestControl1";
            this.backTestControl1.Size = new System.Drawing.Size(632, 489);
            this.backTestControl1.TabIndex = 0;
            // 
            // BacktestProbabilityCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 545);
            this.Controls.Add(this._tab);
            this.Name = "BacktestProbabilityCalculatorForm";
            this.Text = "BacktestProbabilityCalculatorForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._tab.ResumeLayout(false);
            this._tabPageCalculate.ResumeLayout(false);
            this._tabBackTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tab;
        private System.Windows.Forms.TabPage _tabPageCalculate;
        private OddsEditor.MyComponents.CalculateConstantsControl calculateConstantsControl1;
        private System.Windows.Forms.TabPage _tabBackTest;
        private OddsEditor.MyComponents.BackTestControl backTestControl1;

    }
}