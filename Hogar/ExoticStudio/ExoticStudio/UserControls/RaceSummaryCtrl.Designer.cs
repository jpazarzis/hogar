namespace ExoticStudio
{
    partial class RaceSummaryCtrl
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
            this._grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this._dateTextBox = new System.Windows.Forms.TextBox();
            this._raceNumberTextBox = new System.Windows.Forms.TextBox();
            this._raceTrackTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.Size = new System.Drawing.Size(640, 285);
            this._grid.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._dateTextBox);
            this.panel1.Controls.Add(this._raceNumberTextBox);
            this.panel1.Controls.Add(this._raceTrackTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 35);
            this.panel1.TabIndex = 1;
            // 
            // _dateTextBox
            // 
            this._dateTextBox.Location = new System.Drawing.Point(54, 9);
            this._dateTextBox.Name = "_dateTextBox";
            this._dateTextBox.ReadOnly = true;
            this._dateTextBox.Size = new System.Drawing.Size(65, 20);
            this._dateTextBox.TabIndex = 2;
            // 
            // _raceNumberTextBox
            // 
            this._raceNumberTextBox.Location = new System.Drawing.Point(19, 9);
            this._raceNumberTextBox.Name = "_raceNumberTextBox";
            this._raceNumberTextBox.ReadOnly = true;
            this._raceNumberTextBox.Size = new System.Drawing.Size(31, 20);
            this._raceNumberTextBox.TabIndex = 1;
            // 
            // _raceTrackTextBox
            // 
            this._raceTrackTextBox.Location = new System.Drawing.Point(125, 9);
            this._raceTrackTextBox.Name = "_raceTrackTextBox";
            this._raceTrackTextBox.ReadOnly = true;
            this._raceTrackTextBox.Size = new System.Drawing.Size(100, 20);
            this._raceTrackTextBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._grid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(640, 285);
            this.panel2.TabIndex = 2;
            // 
            // RaceSummaryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RaceSummaryCtrl";
            this.Size = new System.Drawing.Size(640, 320);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _dateTextBox;
        private System.Windows.Forms.TextBox _raceNumberTextBox;
        private System.Windows.Forms.TextBox _raceTrackTextBox;
    }
}
