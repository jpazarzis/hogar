namespace SippViewer
{
    partial class FiguresSummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiguresSummaryForm));
            this._grid = new System.Windows.Forms.DataGridView();
            this._gridNormalFigures = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridNormalFigures)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 31);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(564, 464);
            this._grid.TabIndex = 6;
            // 
            // _gridNormalFigures
            // 
            this._gridNormalFigures.AllowUserToAddRows = false;
            this._gridNormalFigures.AllowUserToDeleteRows = false;
            this._gridNormalFigures.AllowUserToResizeColumns = false;
            this._gridNormalFigures.AllowUserToResizeRows = false;
            this._gridNormalFigures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridNormalFigures.Location = new System.Drawing.Point(582, 31);
            this._gridNormalFigures.Name = "_gridNormalFigures";
            this._gridNormalFigures.ReadOnly = true;
            this._gridNormalFigures.RowHeadersVisible = false;
            this._gridNormalFigures.Size = new System.Drawing.Size(564, 464);
            this._gridNormalFigures.TabIndex = 7;
            // 
            // FiguresSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 513);
            this.Controls.Add(this._gridNormalFigures);
            this.Controls.Add(this._grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiguresSummaryForm";
            this.Text = "FiguresSummaryForm";
            this.Load += new System.EventHandler(this.FiguresSummaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridNormalFigures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridView _gridNormalFigures;
    }
}