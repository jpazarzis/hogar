namespace OddsEditor.Dialogs
{
    partial class RealTimeOddsHistoryForm
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
            this._labelHorseName = new System.Windows.Forms.Label();
            this._gridExacta = new System.Windows.Forms.DataGridView();
            this._buttonRefreshExactaOdds = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridExacta)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 36);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(229, 575);
            this._grid.TabIndex = 0;
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.BackColor = System.Drawing.Color.RoyalBlue;
            this._labelHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseName.ForeColor = System.Drawing.Color.Aquamarine;
            this._labelHorseName.Location = new System.Drawing.Point(12, 13);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(57, 20);
            this._labelHorseName.TabIndex = 1;
            this._labelHorseName.Text = "label1";
            // 
            // _gridExacta
            // 
            this._gridExacta.AllowUserToAddRows = false;
            this._gridExacta.AllowUserToDeleteRows = false;
            this._gridExacta.AllowUserToOrderColumns = true;
            this._gridExacta.AllowUserToResizeColumns = false;
            this._gridExacta.AllowUserToResizeRows = false;
            this._gridExacta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridExacta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridExacta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridExacta.Location = new System.Drawing.Point(258, 96);
            this._gridExacta.Name = "_gridExacta";
            this._gridExacta.ReadOnly = true;
            this._gridExacta.Size = new System.Drawing.Size(452, 363);
            this._gridExacta.TabIndex = 2;
            // 
            // _buttonRefreshExactaOdds
            // 
            this._buttonRefreshExactaOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonRefreshExactaOdds.Location = new System.Drawing.Point(258, 51);
            this._buttonRefreshExactaOdds.Name = "_buttonRefreshExactaOdds";
            this._buttonRefreshExactaOdds.Size = new System.Drawing.Size(84, 39);
            this._buttonRefreshExactaOdds.TabIndex = 3;
            this._buttonRefreshExactaOdds.Text = "Refresh ";
            this._buttonRefreshExactaOdds.UseVisualStyleBackColor = true;
            this._buttonRefreshExactaOdds.Click += new System.EventHandler(this.OnRefreshExactaPayouts);
            // 
            // RealTimeOddsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 623);
            this.Controls.Add(this._buttonRefreshExactaOdds);
            this.Controls.Add(this._gridExacta);
            this.Controls.Add(this._labelHorseName);
            this.Controls.Add(this._grid);
            this.Name = "RealTimeOddsForm";
            this.Text = "RealTimeOddsForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridExacta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label _labelHorseName;
        private System.Windows.Forms.DataGridView _gridExacta;
        private System.Windows.Forms.Button _buttonRefreshExactaOdds;
    }
}