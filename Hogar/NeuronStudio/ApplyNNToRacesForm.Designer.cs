namespace NeuronStudio
{
    partial class ApplyNNToRacesForm
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
            this._tbNumberOfRaces = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._buttonTest = new System.Windows.Forms.Button();
            this._tbTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbWinners = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbPercentage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbTotalBet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._tbTotalWinnings = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._tbAverageOdds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._tbMinOdds = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._tbMaxOdds = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._tbOddsStdDev = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._tbCurrentBankroll = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._tbMinReachedBankroll = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._tbMaxReachedBankroll = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._graph = new NPlot.Windows.PlotSurface2D();
            this.SuspendLayout();
            // 
            // _tbNumberOfRaces
            // 
            this._tbNumberOfRaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbNumberOfRaces.Location = new System.Drawing.Point(25, 36);
            this._tbNumberOfRaces.Name = "_tbNumberOfRaces";
            this._tbNumberOfRaces.ReadOnly = true;
            this._tbNumberOfRaces.Size = new System.Drawing.Size(123, 26);
            this._tbNumberOfRaces.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Number Of Races";
            // 
            // _buttonTest
            // 
            this._buttonTest.Location = new System.Drawing.Point(576, 36);
            this._buttonTest.Name = "_buttonTest";
            this._buttonTest.Size = new System.Drawing.Size(75, 23);
            this._buttonTest.TabIndex = 59;
            this._buttonTest.Text = "Test";
            this._buttonTest.UseVisualStyleBackColor = true;
            this._buttonTest.Click += new System.EventHandler(this.TestClick);
            // 
            // _tbTotal
            // 
            this._tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotal.Location = new System.Drawing.Point(164, 33);
            this._tbTotal.Name = "_tbTotal";
            this._tbTotal.ReadOnly = true;
            this._tbTotal.Size = new System.Drawing.Size(123, 26);
            this._tbTotal.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Total";
            // 
            // _tbWinners
            // 
            this._tbWinners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbWinners.Location = new System.Drawing.Point(25, 100);
            this._tbWinners.Name = "_tbWinners";
            this._tbWinners.ReadOnly = true;
            this._tbWinners.Size = new System.Drawing.Size(123, 26);
            this._tbWinners.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Winners";
            // 
            // _tbPercentage
            // 
            this._tbPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbPercentage.Location = new System.Drawing.Point(164, 100);
            this._tbPercentage.Name = "_tbPercentage";
            this._tbPercentage.ReadOnly = true;
            this._tbPercentage.Size = new System.Drawing.Size(123, 26);
            this._tbPercentage.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Percent";
            // 
            // _tbTotalBet
            // 
            this._tbTotalBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalBet.Location = new System.Drawing.Point(309, 100);
            this._tbTotalBet.Name = "_tbTotalBet";
            this._tbTotalBet.ReadOnly = true;
            this._tbTotalBet.Size = new System.Drawing.Size(123, 26);
            this._tbTotalBet.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Total Bet";
            // 
            // _tbTotalWinnings
            // 
            this._tbTotalWinnings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalWinnings.Location = new System.Drawing.Point(449, 100);
            this._tbTotalWinnings.Name = "_tbTotalWinnings";
            this._tbTotalWinnings.ReadOnly = true;
            this._tbTotalWinnings.Size = new System.Drawing.Size(123, 26);
            this._tbTotalWinnings.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Total Wiinings";
            // 
            // _tbAverageOdds
            // 
            this._tbAverageOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAverageOdds.Location = new System.Drawing.Point(19, 154);
            this._tbAverageOdds.Name = "_tbAverageOdds";
            this._tbAverageOdds.ReadOnly = true;
            this._tbAverageOdds.Size = new System.Drawing.Size(123, 26);
            this._tbAverageOdds.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Avg Odds";
            // 
            // _tbMinOdds
            // 
            this._tbMinOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMinOdds.Location = new System.Drawing.Point(173, 154);
            this._tbMinOdds.Name = "_tbMinOdds";
            this._tbMinOdds.ReadOnly = true;
            this._tbMinOdds.Size = new System.Drawing.Size(123, 26);
            this._tbMinOdds.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Min Odds";
            // 
            // _tbMaxOdds
            // 
            this._tbMaxOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMaxOdds.Location = new System.Drawing.Point(316, 154);
            this._tbMaxOdds.Name = "_tbMaxOdds";
            this._tbMaxOdds.ReadOnly = true;
            this._tbMaxOdds.Size = new System.Drawing.Size(123, 26);
            this._tbMaxOdds.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Max Odds";
            // 
            // _tbOddsStdDev
            // 
            this._tbOddsStdDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbOddsStdDev.Location = new System.Drawing.Point(445, 154);
            this._tbOddsStdDev.Name = "_tbOddsStdDev";
            this._tbOddsStdDev.ReadOnly = true;
            this._tbOddsStdDev.Size = new System.Drawing.Size(123, 26);
            this._tbOddsStdDev.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(442, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 76;
            this.label10.Text = "Stdev";
            // 
            // _tbCurrentBankroll
            // 
            this._tbCurrentBankroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbCurrentBankroll.Location = new System.Drawing.Point(19, 221);
            this._tbCurrentBankroll.Name = "_tbCurrentBankroll";
            this._tbCurrentBankroll.ReadOnly = true;
            this._tbCurrentBankroll.Size = new System.Drawing.Size(123, 26);
            this._tbCurrentBankroll.TabIndex = 79;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Current Bankroll";
            // 
            // _tbMinReachedBankroll
            // 
            this._tbMinReachedBankroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMinReachedBankroll.Location = new System.Drawing.Point(173, 221);
            this._tbMinReachedBankroll.Name = "_tbMinReachedBankroll";
            this._tbMinReachedBankroll.ReadOnly = true;
            this._tbMinReachedBankroll.Size = new System.Drawing.Size(123, 26);
            this._tbMinReachedBankroll.TabIndex = 81;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 80;
            this.label12.Text = "Min Reached ";
            // 
            // _tbMaxReachedBankroll
            // 
            this._tbMaxReachedBankroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMaxReachedBankroll.Location = new System.Drawing.Point(343, 221);
            this._tbMaxReachedBankroll.Name = "_tbMaxReachedBankroll";
            this._tbMaxReachedBankroll.ReadOnly = true;
            this._tbMaxReachedBankroll.Size = new System.Drawing.Size(123, 26);
            this._tbMaxReachedBankroll.TabIndex = 83;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(340, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 82;
            this.label13.Text = "Max Reached";
            // 
            // _graph
            // 
            this._graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._graph.AutoScaleAutoGeneratedAxes = false;
            this._graph.AutoScaleTitle = false;
            this._graph.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._graph.DateTimeToolTip = false;
            this._graph.Legend = null;
            this._graph.LegendZOrder = -1;
            this._graph.Location = new System.Drawing.Point(25, 276);
            this._graph.Name = "_graph";
            this._graph.RightMenu = null;
            this._graph.ShowCoordinates = true;
            this._graph.Size = new System.Drawing.Size(770, 396);
            this._graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this._graph.TabIndex = 84;
            this._graph.Text = "plotSurface2D1";
            this._graph.Title = "";
            this._graph.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this._graph.XAxis1 = null;
            this._graph.XAxis2 = null;
            this._graph.YAxis1 = null;
            this._graph.YAxis2 = null;
            // 
            // ApplyNNToRacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 705);
            this.Controls.Add(this._graph);
            this.Controls.Add(this._tbMaxReachedBankroll);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._tbMinReachedBankroll);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._tbCurrentBankroll);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._tbOddsStdDev);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._tbMaxOdds);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._tbMinOdds);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._tbAverageOdds);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._tbTotalWinnings);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._tbTotalBet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._tbPercentage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbWinners);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._buttonTest);
            this.Controls.Add(this._tbNumberOfRaces);
            this.Controls.Add(this.label1);
            this.Name = "ApplyNNToRacesForm";
            this.Text = "ApplyNNToRacesForm";
            this.Load += new System.EventHandler(this.ApplyNNToRacesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbNumberOfRaces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _buttonTest;
        private System.Windows.Forms.TextBox _tbTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbWinners;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbPercentage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbTotalBet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _tbTotalWinnings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbAverageOdds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbMinOdds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _tbMaxOdds;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _tbOddsStdDev;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _tbCurrentBankroll;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _tbMinReachedBankroll;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _tbMaxReachedBankroll;
        private System.Windows.Forms.Label label13;
        private NPlot.Windows.PlotSurface2D _graph;
    }
}