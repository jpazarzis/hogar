namespace OddsEditor.MyComponents
{
    partial class BrisFiguresStatsCtrl
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
            this._tbStdev = new System.Windows.Forms.TextBox();
            this._tbMax = new System.Windows.Forms.TextBox();
            this._tbMin = new System.Windows.Forms.TextBox();
            this._tbAverage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _tbStdev
            // 
            this._tbStdev.BackColor = System.Drawing.Color.Wheat;
            this._tbStdev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbStdev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbStdev.ForeColor = System.Drawing.Color.Olive;
            this._tbStdev.Location = new System.Drawing.Point(156, 7);
            this._tbStdev.Name = "_tbStdev";
            this._tbStdev.ReadOnly = true;
            this._tbStdev.Size = new System.Drawing.Size(43, 19);
            this._tbStdev.TabIndex = 15;
            this._tbStdev.Text = "11";
            this._tbStdev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbMax
            // 
            this._tbMax.BackColor = System.Drawing.Color.Wheat;
            this._tbMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMax.ForeColor = System.Drawing.Color.Olive;
            this._tbMax.Location = new System.Drawing.Point(106, 7);
            this._tbMax.Name = "_tbMax";
            this._tbMax.ReadOnly = true;
            this._tbMax.Size = new System.Drawing.Size(43, 19);
            this._tbMax.TabIndex = 13;
            this._tbMax.Text = "89";
            this._tbMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbMin
            // 
            this._tbMin.BackColor = System.Drawing.Color.Wheat;
            this._tbMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbMin.ForeColor = System.Drawing.Color.Olive;
            this._tbMin.Location = new System.Drawing.Point(56, 7);
            this._tbMin.Name = "_tbMin";
            this._tbMin.ReadOnly = true;
            this._tbMin.Size = new System.Drawing.Size(43, 19);
            this._tbMin.TabIndex = 11;
            this._tbMin.Text = "51";
            this._tbMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbAverage
            // 
            this._tbAverage.BackColor = System.Drawing.Color.Wheat;
            this._tbAverage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAverage.ForeColor = System.Drawing.Color.Olive;
            this._tbAverage.Location = new System.Drawing.Point(6, 7);
            this._tbAverage.Name = "_tbAverage";
            this._tbAverage.ReadOnly = true;
            this._tbAverage.Size = new System.Drawing.Size(43, 19);
            this._tbAverage.TabIndex = 9;
            this._tbAverage.Text = "67";
            this._tbAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BrisFiguresStatsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.Controls.Add(this._tbStdev);
            this.Controls.Add(this._tbMax);
            this.Controls.Add(this._tbMin);
            this.Controls.Add(this._tbAverage);
            this.Name = "BrisFiguresStatsCtrl";
            this.Size = new System.Drawing.Size(209, 32);
            this.Load += new System.EventHandler(this.BrisFiguresStatsCtrl_Load);
            this.Click += new System.EventHandler(this.BrisFiguresStatsCtrl_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbStdev;
        private System.Windows.Forms.TextBox _tbMax;
        private System.Windows.Forms.TextBox _tbMin;
        private System.Windows.Forms.TextBox _tbAverage;
    }
}
