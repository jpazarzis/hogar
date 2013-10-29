namespace OddsEditor.Dialogs
{
    partial class CynthiaParsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._labelSurface = new System.Windows.Forms.Label();
            this._labelDistance = new System.Windows.Forms.Label();
            this._labelRaceClassification = new System.Windows.Forms.Label();
            this._labelRaceTrack = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._labelHorseName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._labelTrackVariant = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._labelAvgDailyVariant = new System.Windows.Forms.Label();
            this._labelFasterOrSlower = new System.Windows.Forms.Label();
            this._labelFasterOrSlowerBy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._labelDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._labelRaceNumber = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._fractionTimesCtrl = new OddsEditor.MyComponents.FractionTimesCtrl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this._labelSurface);
            this.panel1.Controls.Add(this._labelDistance);
            this.panel1.Controls.Add(this._labelRaceClassification);
            this.panel1.Controls.Add(this._labelRaceTrack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 28);
            this.panel1.TabIndex = 0;
            // 
            // _labelSurface
            // 
            this._labelSurface.AutoSize = true;
            this._labelSurface.Location = new System.Drawing.Point(299, 0);
            this._labelSurface.Name = "_labelSurface";
            this._labelSurface.Size = new System.Drawing.Size(47, 24);
            this._labelSurface.TabIndex = 2;
            this._labelSurface.Text = "Turf";
            // 
            // _labelDistance
            // 
            this._labelDistance.AutoSize = true;
            this._labelDistance.Location = new System.Drawing.Point(165, 0);
            this._labelDistance.Name = "_labelDistance";
            this._labelDistance.Size = new System.Drawing.Size(83, 24);
            this._labelDistance.TabIndex = 1;
            this._labelDistance.Text = "1 1/16m";
            // 
            // _labelRaceClassification
            // 
            this._labelRaceClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceClassification.ForeColor = System.Drawing.Color.White;
            this._labelRaceClassification.Location = new System.Drawing.Point(387, 3);
            this._labelRaceClassification.Name = "_labelRaceClassification";
            this._labelRaceClassification.Size = new System.Drawing.Size(165, 20);
            this._labelRaceClassification.TabIndex = 18;
            this._labelRaceClassification.Text = "label1";
            // 
            // _labelRaceTrack
            // 
            this._labelRaceTrack.AutoSize = true;
            this._labelRaceTrack.Location = new System.Drawing.Point(12, 0);
            this._labelRaceTrack.Name = "_labelRaceTrack";
            this._labelRaceTrack.Size = new System.Drawing.Size(86, 24);
            this._labelRaceTrack.TabIndex = 0;
            this._labelRaceTrack.Text = "Belmont";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(0, 177);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(612, 651);
            this._grid.TabIndex = 1;
            this._grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellContentClick);
            // 
            // _labelHorseName
            // 
            this._labelHorseName.BackColor = System.Drawing.Color.DarkTurquoise;
            this._labelHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseName.ForeColor = System.Drawing.Color.DodgerBlue;
            this._labelHorseName.Location = new System.Drawing.Point(105, 31);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(165, 20);
            this._labelHorseName.TabIndex = 0;
            this._labelHorseName.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label3.Location = new System.Drawing.Point(7, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Var";
            // 
            // _labelTrackVariant
            // 
            this._labelTrackVariant.AutoSize = true;
            this._labelTrackVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTrackVariant.ForeColor = System.Drawing.Color.DodgerBlue;
            this._labelTrackVariant.Location = new System.Drawing.Point(66, 14);
            this._labelTrackVariant.Name = "_labelTrackVariant";
            this._labelTrackVariant.Size = new System.Drawing.Size(57, 20);
            this._labelTrackVariant.TabIndex = 5;
            this._labelTrackVariant.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Avg Var";
            // 
            // _labelAvgDailyVariant
            // 
            this._labelAvgDailyVariant.AutoSize = true;
            this._labelAvgDailyVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelAvgDailyVariant.ForeColor = System.Drawing.Color.DodgerBlue;
            this._labelAvgDailyVariant.Location = new System.Drawing.Point(67, 40);
            this._labelAvgDailyVariant.Name = "_labelAvgDailyVariant";
            this._labelAvgDailyVariant.Size = new System.Drawing.Size(57, 20);
            this._labelAvgDailyVariant.TabIndex = 7;
            this._labelAvgDailyVariant.Text = "label1";
            // 
            // _labelFasterOrSlower
            // 
            this._labelFasterOrSlower.AutoSize = true;
            this._labelFasterOrSlower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelFasterOrSlower.ForeColor = System.Drawing.Color.LightSkyBlue;
            this._labelFasterOrSlower.Location = new System.Drawing.Point(7, 70);
            this._labelFasterOrSlower.Name = "_labelFasterOrSlower";
            this._labelFasterOrSlower.Size = new System.Drawing.Size(60, 13);
            this._labelFasterOrSlower.TabIndex = 10;
            this._labelFasterOrSlower.Text = "Faster By";
            // 
            // _labelFasterOrSlowerBy
            // 
            this._labelFasterOrSlowerBy.AutoSize = true;
            this._labelFasterOrSlowerBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelFasterOrSlowerBy.ForeColor = System.Drawing.Color.DodgerBlue;
            this._labelFasterOrSlowerBy.Location = new System.Drawing.Point(67, 67);
            this._labelFasterOrSlowerBy.Name = "_labelFasterOrSlowerBy";
            this._labelFasterOrSlowerBy.Size = new System.Drawing.Size(57, 20);
            this._labelFasterOrSlowerBy.TabIndex = 9;
            this._labelFasterOrSlowerBy.Text = "label1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label6.Location = new System.Drawing.Point(15, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Horse Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label7.Location = new System.Drawing.Point(276, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Date";
            // 
            // _labelDate
            // 
            this._labelDate.BackColor = System.Drawing.Color.DarkTurquoise;
            this._labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelDate.ForeColor = System.Drawing.Color.DodgerBlue;
            this._labelDate.Location = new System.Drawing.Point(325, 33);
            this._labelDate.Name = "_labelDate";
            this._labelDate.Size = new System.Drawing.Size(96, 20);
            this._labelDate.TabIndex = 14;
            this._labelDate.Text = "label1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label9.Location = new System.Drawing.Point(441, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Race#";
            // 
            // _labelRaceNumber
            // 
            this._labelRaceNumber.BackColor = System.Drawing.Color.DarkTurquoise;
            this._labelRaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceNumber.ForeColor = System.Drawing.Color.DodgerBlue;
            this._labelRaceNumber.Location = new System.Drawing.Point(494, 33);
            this._labelRaceNumber.Name = "_labelRaceNumber";
            this._labelRaceNumber.Size = new System.Drawing.Size(36, 20);
            this._labelRaceNumber.TabIndex = 16;
            this._labelRaceNumber.Text = "label1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this._labelTrackVariant);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this._labelAvgDailyVariant);
            this.groupBox3.Controls.Add(this._labelFasterOrSlowerBy);
            this.groupBox3.Controls.Add(this._labelFasterOrSlower);
            this.groupBox3.Location = new System.Drawing.Point(465, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(142, 107);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // _fractionTimesCtrl
            // 
            this._fractionTimesCtrl.Location = new System.Drawing.Point(5, 64);
            this._fractionTimesCtrl.Name = "_fractionTimesCtrl";
            this._fractionTimesCtrl.Size = new System.Drawing.Size(454, 107);
            this._fractionTimesCtrl.TabIndex = 21;
            // 
            // CynthiaParsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 840);
            this.Controls.Add(this._fractionTimesCtrl);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._labelRaceNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._labelDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._labelHorseName);
            this.Controls.Add(this._grid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CynthiaParsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CynthiaParsForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _labelRaceTrack;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label _labelSurface;
        private System.Windows.Forms.Label _labelDistance;
        private System.Windows.Forms.Label _labelHorseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _labelTrackVariant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _labelAvgDailyVariant;
        private System.Windows.Forms.Label _labelFasterOrSlower;
        private System.Windows.Forms.Label _labelFasterOrSlowerBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _labelDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label _labelRaceNumber;
        private System.Windows.Forms.Label _labelRaceClassification;
        private System.Windows.Forms.GroupBox groupBox3;
        private OddsEditor.MyComponents.FractionTimesCtrl _fractionTimesCtrl;
    }
}