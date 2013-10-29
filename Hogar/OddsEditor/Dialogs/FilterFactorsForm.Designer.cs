namespace OddsEditor.Dialogs
{
    partial class FilterFactorsForm
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
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonSelectAll = new System.Windows.Forms.Button();
            this._buttonUnselectAll = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
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
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 12);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(303, 470);
            this._grid.TabIndex = 0;
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClick);
            // 
            // _buttonOK
            // 
            this._buttonOK.Location = new System.Drawing.Point(338, 12);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(128, 43);
            this._buttonOK.TabIndex = 1;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            this._buttonOK.Click += new System.EventHandler(this.OnOK);
            // 
            // _buttonSelectAll
            // 
            this._buttonSelectAll.Location = new System.Drawing.Point(338, 132);
            this._buttonSelectAll.Name = "_buttonSelectAll";
            this._buttonSelectAll.Size = new System.Drawing.Size(128, 43);
            this._buttonSelectAll.TabIndex = 2;
            this._buttonSelectAll.Text = "Select All";
            this._buttonSelectAll.UseVisualStyleBackColor = true;
            this._buttonSelectAll.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // _buttonUnselectAll
            // 
            this._buttonUnselectAll.Location = new System.Drawing.Point(338, 195);
            this._buttonUnselectAll.Name = "_buttonUnselectAll";
            this._buttonUnselectAll.Size = new System.Drawing.Size(128, 43);
            this._buttonUnselectAll.TabIndex = 3;
            this._buttonUnselectAll.Text = "Unselect All";
            this._buttonUnselectAll.UseVisualStyleBackColor = true;
            this._buttonUnselectAll.Click += new System.EventHandler(this.OnUnselectAll);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(338, 71);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(128, 43);
            this._buttonCancel.TabIndex = 4;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // FilterFactorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 489);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonUnselectAll);
            this.Controls.Add(this._buttonSelectAll);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this._grid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterFactorsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filter Factors";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonSelectAll;
        private System.Windows.Forms.Button _buttonUnselectAll;
        private System.Windows.Forms.Button _buttonCancel;
    }
}