namespace OddsEditor.MyComponents
{
    partial class FractionTimesCtrl
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._gridRawTimes = new System.Windows.Forms.DataGridView();
            this._gridAdjustedTimes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridRawTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridAdjustedTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Raw";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._gridAdjustedTimes);
            this.groupBox1.Controls.Add(this._gridRawTimes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fraction Times";
            // 
            // _gridRawTimes
            // 
            this._gridRawTimes.AllowUserToAddRows = false;
            this._gridRawTimes.AllowUserToDeleteRows = false;
            this._gridRawTimes.AllowUserToOrderColumns = true;
            this._gridRawTimes.AllowUserToResizeColumns = false;
            this._gridRawTimes.AllowUserToResizeRows = false;
            this._gridRawTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridRawTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridRawTimes.ColumnHeadersVisible = false;
            this._gridRawTimes.Location = new System.Drawing.Point(17, 34);
            this._gridRawTimes.Name = "_gridRawTimes";
            this._gridRawTimes.ReadOnly = true;
            this._gridRawTimes.RowHeadersVisible = false;
            this._gridRawTimes.Size = new System.Drawing.Size(202, 57);
            this._gridRawTimes.TabIndex = 2;
            // 
            // _gridAdjustedTimes
            // 
            this._gridAdjustedTimes.AllowUserToAddRows = false;
            this._gridAdjustedTimes.AllowUserToDeleteRows = false;
            this._gridAdjustedTimes.AllowUserToOrderColumns = true;
            this._gridAdjustedTimes.AllowUserToResizeColumns = false;
            this._gridAdjustedTimes.AllowUserToResizeRows = false;
            this._gridAdjustedTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridAdjustedTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridAdjustedTimes.ColumnHeadersVisible = false;
            this._gridAdjustedTimes.Location = new System.Drawing.Point(236, 34);
            this._gridAdjustedTimes.Name = "_gridAdjustedTimes";
            this._gridAdjustedTimes.ReadOnly = true;
            this._gridAdjustedTimes.RowHeadersVisible = false;
            this._gridAdjustedTimes.Size = new System.Drawing.Size(202, 57);
            this._gridAdjustedTimes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adjusted";
            // 
            // FractionTimesCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FractionTimesCtrl";
            this.Size = new System.Drawing.Size(457, 107);
            this.Load += new System.EventHandler(this.FractionTimesCtrl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridRawTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridAdjustedTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView _gridRawTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _gridAdjustedTimes;
    }
}
