namespace OddsEditor.MyComponents
{
    partial class FactorPerfomanceCtrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this._buttonFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(3, 34);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(236, 334);
            this._grid.TabIndex = 0;
            this._grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellMouseDoubleClick);
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Handicapping Factors";
            // 
            // _buttonFilter
            // 
            this._buttonFilter.Location = new System.Drawing.Point(145, 9);
            this._buttonFilter.Name = "_buttonFilter";
            this._buttonFilter.Size = new System.Drawing.Size(41, 23);
            this._buttonFilter.TabIndex = 2;
            this._buttonFilter.Text = "Filter";
            this._buttonFilter.UseVisualStyleBackColor = true;
            this._buttonFilter.Click += new System.EventHandler(this.OnFilter);
            // 
            // FactorPerfomanceCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._grid);
            this.Name = "FactorPerfomanceCtrl";
            this.Size = new System.Drawing.Size(242, 373);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _buttonFilter;
    }
}
