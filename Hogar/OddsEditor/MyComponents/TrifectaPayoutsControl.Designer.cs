namespace OddsEditor.MyComponents
{
    partial class TrifectaPayoutsControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grid = new System.Windows.Forms.DataGridView();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._buttonSelect = new System.Windows.Forms.Button();
            this._buttonUnselect = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Combo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payoff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelected,
            this.Combo,
            this.Payoff,
            this.Bet});
            this._grid.Location = new System.Drawing.Point(0, 32);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(320, 271);
            this._grid.TabIndex = 0;
            this._grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.OnCurrentCellDirtyStateChanged);
            this._grid.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            // 
            // IsSelected
            // 
            this.IsSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IsSelected.HeaderText = "";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.Width = 5;
            // 
            // _buttonSelect
            // 
            this._buttonSelect.Location = new System.Drawing.Point(3, 3);
            this._buttonSelect.Name = "_buttonSelect";
            this._buttonSelect.Size = new System.Drawing.Size(75, 23);
            this._buttonSelect.TabIndex = 1;
            this._buttonSelect.Text = "Select";
            this._buttonSelect.UseVisualStyleBackColor = true;
            this._buttonSelect.Click += new System.EventHandler(this.OnSelect);
            // 
            // _buttonUnselect
            // 
            this._buttonUnselect.Location = new System.Drawing.Point(84, 3);
            this._buttonUnselect.Name = "_buttonUnselect";
            this._buttonUnselect.Size = new System.Drawing.Size(75, 23);
            this._buttonUnselect.TabIndex = 2;
            this._buttonUnselect.Text = "Unselect";
            this._buttonUnselect.UseVisualStyleBackColor = true;
            this._buttonUnselect.Click += new System.EventHandler(this.OnUnselect);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Combo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 46;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "DutchingAmount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 62;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "DutchingAmount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 111;
            // 
            // Combo
            // 
            this.Combo.HeaderText = "Combo";
            this.Combo.Name = "Combo";
            this.Combo.ReadOnly = true;
            this.Combo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Combo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Combo.Width = 46;
            // 
            // Payoff
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Payoff.DefaultCellStyle = dataGridViewCellStyle1;
            this.Payoff.HeaderText = "Payoff";
            this.Payoff.Name = "Payoff";
            this.Payoff.ReadOnly = true;
            this.Payoff.Width = 62;
            // 
            // Bet
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Bet.DefaultCellStyle = dataGridViewCellStyle2;
            this.Bet.HeaderText = "Bet";
            this.Bet.Name = "Bet";
            this.Bet.ReadOnly = true;
            this.Bet.Width = 48;
            // 
            // TrifectaPayoutsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonUnselect);
            this.Controls.Add(this._buttonSelect);
            this.Controls.Add(this._grid);
            this.Name = "TrifectaPayoutsControl";
            this.Size = new System.Drawing.Size(320, 303);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Combo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payoff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bet;
        private System.Windows.Forms.Button _buttonSelect;
        private System.Windows.Forms.Button _buttonUnselect;
    }
}
