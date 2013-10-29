namespace SippViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this._labelSurface = new System.Windows.Forms.Label();
            this._labelDistance = new System.Windows.Forms.Label();
            this._labelRaceTrack = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this._labelTrackVariant = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._labelAvgDailyVariant = new System.Windows.Forms.Label();
            this._labelFasterOrSlower = new System.Windows.Forms.Label();
            this._labelFasterOrSlowerBy = new System.Windows.Forms.Label();
            this._tbFirstCall = new System.Windows.Forms.TextBox();
            this._tbSecondCall = new System.Windows.Forms.TextBox();
            this._tbThirdCall = new System.Windows.Forms.TextBox();
            this._tbFinalTime = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this._labelSurface);
            this.panel1.Controls.Add(this._labelDistance);
            this.panel1.Controls.Add(this._labelRaceTrack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 28);
            this.panel1.TabIndex = 0;
            // 
            // _labelSurface
            // 
            this._labelSurface.AutoSize = true;
            this._labelSurface.Location = new System.Drawing.Point(306, 0);
            this._labelSurface.Name = "_labelSurface";
            this._labelSurface.Size = new System.Drawing.Size(47, 24);
            this._labelSurface.TabIndex = 2;
            this._labelSurface.Text = "Turf";
            // 
            // _labelDistance
            // 
            this._labelDistance.AutoSize = true;
            this._labelDistance.Location = new System.Drawing.Point(167, 0);
            this._labelDistance.Name = "_labelDistance";
            this._labelDistance.Size = new System.Drawing.Size(83, 24);
            this._labelDistance.TabIndex = 1;
            this._labelDistance.Text = "1 1/16m";
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Azure;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this._grid.BackgroundColor = System.Drawing.Color.PowderBlue;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle6;
            this._grid.EnableHeadersVisualStyles = false;
            this._grid.Location = new System.Drawing.Point(3, 104);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(422, 576);
            this._grid.TabIndex = 1;
            this._grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label3.Location = new System.Drawing.Point(17, 70);
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
            this._labelTrackVariant.Location = new System.Drawing.Point(49, 70);
            this._labelTrackVariant.Name = "_labelTrackVariant";
            this._labelTrackVariant.Size = new System.Drawing.Size(29, 20);
            this._labelTrackVariant.TabIndex = 5;
            this._labelTrackVariant.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label4.Location = new System.Drawing.Point(91, 70);
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
            this._labelAvgDailyVariant.Location = new System.Drawing.Point(149, 70);
            this._labelAvgDailyVariant.Name = "_labelAvgDailyVariant";
            this._labelAvgDailyVariant.Size = new System.Drawing.Size(29, 20);
            this._labelAvgDailyVariant.TabIndex = 7;
            this._labelAvgDailyVariant.Text = "18";
            // 
            // _labelFasterOrSlower
            // 
            this._labelFasterOrSlower.AutoSize = true;
            this._labelFasterOrSlower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelFasterOrSlower.ForeColor = System.Drawing.Color.LightSkyBlue;
            this._labelFasterOrSlower.Location = new System.Drawing.Point(190, 70);
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
            this._labelFasterOrSlowerBy.Location = new System.Drawing.Point(256, 70);
            this._labelFasterOrSlowerBy.Name = "_labelFasterOrSlowerBy";
            this._labelFasterOrSlowerBy.Size = new System.Drawing.Size(57, 20);
            this._labelFasterOrSlowerBy.TabIndex = 9;
            this._labelFasterOrSlowerBy.Text = "label1";
            // 
            // _tbFirstCall
            // 
            this._tbFirstCall.BackColor = System.Drawing.Color.DodgerBlue;
            this._tbFirstCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbFirstCall.ForeColor = System.Drawing.Color.Cyan;
            this._tbFirstCall.Location = new System.Drawing.Point(36, 34);
            this._tbFirstCall.Name = "_tbFirstCall";
            this._tbFirstCall.ReadOnly = true;
            this._tbFirstCall.Size = new System.Drawing.Size(75, 26);
            this._tbFirstCall.TabIndex = 21;
            this._tbFirstCall.Text = ":24";
            this._tbFirstCall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbSecondCall
            // 
            this._tbSecondCall.BackColor = System.Drawing.Color.DodgerBlue;
            this._tbSecondCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSecondCall.ForeColor = System.Drawing.Color.Cyan;
            this._tbSecondCall.Location = new System.Drawing.Point(117, 34);
            this._tbSecondCall.Name = "_tbSecondCall";
            this._tbSecondCall.ReadOnly = true;
            this._tbSecondCall.Size = new System.Drawing.Size(75, 26);
            this._tbSecondCall.TabIndex = 22;
            this._tbSecondCall.Text = ":24";
            this._tbSecondCall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbThirdCall
            // 
            this._tbThirdCall.BackColor = System.Drawing.Color.DodgerBlue;
            this._tbThirdCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbThirdCall.ForeColor = System.Drawing.Color.Cyan;
            this._tbThirdCall.Location = new System.Drawing.Point(198, 34);
            this._tbThirdCall.Name = "_tbThirdCall";
            this._tbThirdCall.ReadOnly = true;
            this._tbThirdCall.Size = new System.Drawing.Size(75, 26);
            this._tbThirdCall.TabIndex = 23;
            this._tbThirdCall.Text = ":24";
            this._tbThirdCall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbFinalTime
            // 
            this._tbFinalTime.BackColor = System.Drawing.Color.DodgerBlue;
            this._tbFinalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbFinalTime.ForeColor = System.Drawing.Color.Cyan;
            this._tbFinalTime.Location = new System.Drawing.Point(279, 34);
            this._tbFinalTime.Name = "_tbFinalTime";
            this._tbFinalTime.ReadOnly = true;
            this._tbFinalTime.Size = new System.Drawing.Size(75, 26);
            this._tbFinalTime.TabIndex = 24;
            this._tbFinalTime.Text = ":24";
            this._tbFinalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CynthiaParsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(429, 684);
            this.Controls.Add(this._labelFasterOrSlowerBy);
            this.Controls.Add(this._labelAvgDailyVariant);
            this.Controls.Add(this._labelFasterOrSlower);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbFinalTime);
            this.Controls.Add(this._labelTrackVariant);
            this.Controls.Add(this._tbThirdCall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbSecondCall);
            this.Controls.Add(this._tbFirstCall);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _labelRaceTrack;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label _labelSurface;
        private System.Windows.Forms.Label _labelDistance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _labelTrackVariant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _labelAvgDailyVariant;
        private System.Windows.Forms.Label _labelFasterOrSlower;
        private System.Windows.Forms.Label _labelFasterOrSlowerBy;
        private System.Windows.Forms.TextBox _tbFirstCall;
        private System.Windows.Forms.TextBox _tbSecondCall;
        private System.Windows.Forms.TextBox _tbThirdCall;
        private System.Windows.Forms.TextBox _tbFinalTime;
    }

}