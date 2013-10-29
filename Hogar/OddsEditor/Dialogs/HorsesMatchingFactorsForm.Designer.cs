namespace OddsEditor.Dialogs
{
    partial class HorsesMatchingFactorsForm
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
            this._txtboxTitle = new System.Windows.Forms.TextBox();
            this._buttonTurfOnly = new System.Windows.Forms.Button();
            this._buttonMaidenOnly = new System.Windows.Forms.Button();
            this._buttonShowAll = new System.Windows.Forms.Button();
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
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(2, 63);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.Size = new System.Drawing.Size(1002, 756);
            this._grid.TabIndex = 0;
            // 
            // _txtboxTitle
            // 
            this._txtboxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtboxTitle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._txtboxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTitle.ForeColor = System.Drawing.Color.Yellow;
            this._txtboxTitle.Location = new System.Drawing.Point(2, 1);
            this._txtboxTitle.Name = "_txtboxTitle";
            this._txtboxTitle.ReadOnly = true;
            this._txtboxTitle.Size = new System.Drawing.Size(1002, 26);
            this._txtboxTitle.TabIndex = 2;
            this._txtboxTitle.Text = "ComingFromBigWin";
            // 
            // _buttonTurfOnly
            // 
            this._buttonTurfOnly.Location = new System.Drawing.Point(175, 34);
            this._buttonTurfOnly.Name = "_buttonTurfOnly";
            this._buttonTurfOnly.Size = new System.Drawing.Size(75, 23);
            this._buttonTurfOnly.TabIndex = 3;
            this._buttonTurfOnly.Text = "Turf Only";
            this._buttonTurfOnly.UseVisualStyleBackColor = true;
            this._buttonTurfOnly.Click += new System.EventHandler(this.OnShowTurfOnly);
            // 
            // _buttonMaidenOnly
            // 
            this._buttonMaidenOnly.Location = new System.Drawing.Point(94, 34);
            this._buttonMaidenOnly.Name = "_buttonMaidenOnly";
            this._buttonMaidenOnly.Size = new System.Drawing.Size(75, 23);
            this._buttonMaidenOnly.TabIndex = 4;
            this._buttonMaidenOnly.Text = "Maiden Only";
            this._buttonMaidenOnly.UseVisualStyleBackColor = true;
            this._buttonMaidenOnly.Click += new System.EventHandler(this.OnShowMaidenOnly);
            // 
            // _buttonShowAll
            // 
            this._buttonShowAll.Location = new System.Drawing.Point(13, 34);
            this._buttonShowAll.Name = "_buttonShowAll";
            this._buttonShowAll.Size = new System.Drawing.Size(75, 23);
            this._buttonShowAll.TabIndex = 5;
            this._buttonShowAll.Text = "Show All";
            this._buttonShowAll.UseVisualStyleBackColor = true;
            this._buttonShowAll.Click += new System.EventHandler(this.OnShowAll);
            // 
            // HorsesMatchingFactorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 831);
            this.Controls.Add(this._buttonShowAll);
            this.Controls.Add(this._buttonMaidenOnly);
            this.Controls.Add(this._buttonTurfOnly);
            this.Controls.Add(this._txtboxTitle);
            this.Controls.Add(this._grid);
            this.Name = "HorsesMatchingFactorsForm";
            this.Text = "HorsesMatchingFactorsForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtboxTitle;
        private System.Windows.Forms.Button _buttonTurfOnly;
        private System.Windows.Forms.Button _buttonMaidenOnly;
        private System.Windows.Forms.Button _buttonShowAll;
    }
}