namespace OddsEditor.Dialogs
{
    partial class SpeedAnalysisForm
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
            this._grid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbAverage = new System.Windows.Forms.TextBox();
            this._tbMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbStdev = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 25);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(188, 421);
            this._grid.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._tbStdev);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._tbMax);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._tbMin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._tbAverage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(224, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 421);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bris Speed Figures Analysis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Avg";
            // 
            // _tbAverage
            // 
            this._tbAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAverage.Location = new System.Drawing.Point(74, 36);
            this._tbAverage.Name = "_tbAverage";
            this._tbAverage.ReadOnly = true;
            this._tbAverage.Size = new System.Drawing.Size(77, 26);
            this._tbAverage.TabIndex = 1;
            // 
            // _tbMin
            // 
            this._tbMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMin.Location = new System.Drawing.Point(74, 82);
            this._tbMin.Name = "_tbMin";
            this._tbMin.ReadOnly = true;
            this._tbMin.Size = new System.Drawing.Size(77, 26);
            this._tbMin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min";
            // 
            // _tbMax
            // 
            this._tbMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMax.Location = new System.Drawing.Point(74, 138);
            this._tbMax.Name = "_tbMax";
            this._tbMax.ReadOnly = true;
            this._tbMax.Size = new System.Drawing.Size(77, 26);
            this._tbMax.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max";
            // 
            // _tbStdev
            // 
            this._tbStdev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbStdev.Location = new System.Drawing.Point(74, 193);
            this._tbStdev.Name = "_tbStdev";
            this._tbStdev.ReadOnly = true;
            this._tbStdev.Size = new System.Drawing.Size(77, 26);
            this._tbStdev.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stdev";
            // 
            // SpeedAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 466);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._grid);
            this.Name = "SpeedAnalysisForm";
            this.Text = "SpeedAnalysisForm";
            this.Load += new System.EventHandler(this.SpeedAnalysisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _tbStdev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbAverage;
        private System.Windows.Forms.Label label1;
    }
}