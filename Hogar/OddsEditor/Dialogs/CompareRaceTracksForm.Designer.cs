namespace OddsEditor.Dialogs
{
    partial class CompareRaceTracksForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._comboBoxTrack1 = new System.Windows.Forms.ComboBox();
            this._comboBoxTrack2 = new System.Windows.Forms.ComboBox();
            this._buttonCompare = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this._gridAggregate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridAggregate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Track1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Track2";
            // 
            // _comboBoxTrack1
            // 
            this._comboBoxTrack1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxTrack1.FormattingEnabled = true;
            this._comboBoxTrack1.Location = new System.Drawing.Point(25, 25);
            this._comboBoxTrack1.Name = "_comboBoxTrack1";
            this._comboBoxTrack1.Size = new System.Drawing.Size(121, 21);
            this._comboBoxTrack1.TabIndex = 4;
            // 
            // _comboBoxTrack2
            // 
            this._comboBoxTrack2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxTrack2.FormattingEnabled = true;
            this._comboBoxTrack2.Location = new System.Drawing.Point(166, 25);
            this._comboBoxTrack2.Name = "_comboBoxTrack2";
            this._comboBoxTrack2.Size = new System.Drawing.Size(121, 21);
            this._comboBoxTrack2.TabIndex = 5;
            // 
            // _buttonCompare
            // 
            this._buttonCompare.Location = new System.Drawing.Point(320, 13);
            this._buttonCompare.Name = "_buttonCompare";
            this._buttonCompare.Size = new System.Drawing.Size(75, 33);
            this._buttonCompare.TabIndex = 6;
            this._buttonCompare.Text = "Compare";
            this._buttonCompare.UseVisualStyleBackColor = true;
            this._buttonCompare.Click += new System.EventHandler(this.OnCompare);
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
            this._grid.Location = new System.Drawing.Point(25, 261);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(964, 288);
            this._grid.TabIndex = 7;
            // 
            // _gridAggregate
            // 
            this._gridAggregate.AllowUserToAddRows = false;
            this._gridAggregate.AllowUserToDeleteRows = false;
            this._gridAggregate.AllowUserToOrderColumns = true;
            this._gridAggregate.AllowUserToResizeColumns = false;
            this._gridAggregate.AllowUserToResizeRows = false;
            this._gridAggregate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridAggregate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridAggregate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridAggregate.Location = new System.Drawing.Point(24, 83);
            this._gridAggregate.Name = "_gridAggregate";
            this._gridAggregate.ReadOnly = true;
            this._gridAggregate.RowHeadersVisible = false;
            this._gridAggregate.Size = new System.Drawing.Size(964, 143);
            this._gridAggregate.TabIndex = 8;
            // 
            // CompareRaceTracksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 561);
            this.Controls.Add(this._gridAggregate);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._buttonCompare);
            this.Controls.Add(this._comboBoxTrack2);
            this.Controls.Add(this._comboBoxTrack1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CompareRaceTracksForm";
            this.Text = "CompareRaceTracksForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridAggregate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _comboBoxTrack1;
        private System.Windows.Forms.ComboBox _comboBoxTrack2;
        private System.Windows.Forms.Button _buttonCompare;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridView _gridAggregate;
    }
}