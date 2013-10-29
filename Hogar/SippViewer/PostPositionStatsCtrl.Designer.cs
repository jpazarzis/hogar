namespace SippViewer
{
    partial class PostPositionStatsCtrl
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
            this._labelCondition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._tbAverageIV = new System.Windows.Forms.TextBox();
            this._tbIVStdDev = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(13, 48);
            this._grid.Name = "_grid";
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(241, 497);
            this._grid.TabIndex = 0;
            // 
            // _labelCondition
            // 
            this._labelCondition.AutoSize = true;
            this._labelCondition.Location = new System.Drawing.Point(24, 15);
            this._labelCondition.Name = "_labelCondition";
            this._labelCondition.Size = new System.Drawing.Size(35, 13);
            this._labelCondition.TabIndex = 1;
            this._labelCondition.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Avg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stdev";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._tbIVStdDev);
            this.groupBox1.Controls.Add(this._tbAverageIV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(133, 551);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IV";
            // 
            // _tbAverageIV
            // 
            this._tbAverageIV.BackColor = System.Drawing.Color.DarkSalmon;
            this._tbAverageIV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbAverageIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAverageIV.ForeColor = System.Drawing.Color.AntiqueWhite;
            this._tbAverageIV.Location = new System.Drawing.Point(50, 18);
            this._tbAverageIV.Name = "_tbAverageIV";
            this._tbAverageIV.ReadOnly = true;
            this._tbAverageIV.Size = new System.Drawing.Size(56, 15);
            this._tbAverageIV.TabIndex = 4;
            this._tbAverageIV.Text = "12.1";
            // 
            // _tbIVStdDev
            // 
            this._tbIVStdDev.BackColor = System.Drawing.Color.DarkSalmon;
            this._tbIVStdDev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbIVStdDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbIVStdDev.ForeColor = System.Drawing.Color.AntiqueWhite;
            this._tbIVStdDev.Location = new System.Drawing.Point(50, 47);
            this._tbIVStdDev.Name = "_tbIVStdDev";
            this._tbIVStdDev.ReadOnly = true;
            this._tbIVStdDev.Size = new System.Drawing.Size(56, 15);
            this._tbIVStdDev.TabIndex = 5;
            this._tbIVStdDev.Text = "12.1";
            // 
            // PostPositionStatsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._labelCondition);
            this.Controls.Add(this._grid);
            this.Name = "PostPositionStatsCtrl";
            this.Size = new System.Drawing.Size(268, 644);
            this.Load += new System.EventHandler(this.PostPositionStatsCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label _labelCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _tbIVStdDev;
        private System.Windows.Forms.TextBox _tbAverageIV;
    }
}
