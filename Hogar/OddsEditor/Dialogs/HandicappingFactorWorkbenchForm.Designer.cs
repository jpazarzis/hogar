namespace OddsEditor.Dialogs
{
    partial class HandicappingFactorWorkbenchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._comboBoxSelectedRaceTrack = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._comboBoxFactor = new System.Windows.Forms.ComboBox();
            this._buttonExecute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 55);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(689, 491);
            this._grid.TabIndex = 16;
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._comboBoxSelectedRaceTrack);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 43);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By Track";
            // 
            // _comboBoxSelectedRaceTrack
            // 
            this._comboBoxSelectedRaceTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSelectedRaceTrack.FormattingEnabled = true;
            this._comboBoxSelectedRaceTrack.Location = new System.Drawing.Point(15, 16);
            this._comboBoxSelectedRaceTrack.Name = "_comboBoxSelectedRaceTrack";
            this._comboBoxSelectedRaceTrack.Size = new System.Drawing.Size(84, 21);
            this._comboBoxSelectedRaceTrack.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._comboBoxFactor);
            this.groupBox2.Location = new System.Drawing.Point(166, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 43);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter By Factor";
            // 
            // _comboBoxFactor
            // 
            this._comboBoxFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFactor.FormattingEnabled = true;
            this._comboBoxFactor.Location = new System.Drawing.Point(15, 16);
            this._comboBoxFactor.Name = "_comboBoxFactor";
            this._comboBoxFactor.Size = new System.Drawing.Size(197, 21);
            this._comboBoxFactor.Sorted = true;
            this._comboBoxFactor.TabIndex = 0;
            // 
            // _buttonExecute
            // 
            this._buttonExecute.Location = new System.Drawing.Point(447, 12);
            this._buttonExecute.Name = "_buttonExecute";
            this._buttonExecute.Size = new System.Drawing.Size(75, 39);
            this._buttonExecute.TabIndex = 23;
            this._buttonExecute.Text = "Execute";
            this._buttonExecute.UseVisualStyleBackColor = true;
            this._buttonExecute.Click += new System.EventHandler(this.OnExecute);
            // 
            // HandicappingFactorWorkbenchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 576);
            this.Controls.Add(this._buttonExecute);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._grid);
            this.DoubleBuffered = true;
            this.Name = "HandicappingFactorWorkbenchForm";
            this.Text = "Handicapping Factor Workbench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _comboBoxSelectedRaceTrack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox _comboBoxFactor;
        private System.Windows.Forms.Button _buttonExecute;
    }
}