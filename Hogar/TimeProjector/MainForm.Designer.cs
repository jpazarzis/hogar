namespace TimeProjector
{
    partial class MainForm
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
            this._buttonCalculateSlopeAndOrdinate = new System.Windows.Forms.Button();
            this._gridProjectionVariables = new System.Windows.Forms.DataGridView();
            this._buttonUpdateDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._gridProjectionVariables)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonCalculateSlopeAndOrdinate
            // 
            this._buttonCalculateSlopeAndOrdinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonCalculateSlopeAndOrdinate.Location = new System.Drawing.Point(12, 2);
            this._buttonCalculateSlopeAndOrdinate.Name = "_buttonCalculateSlopeAndOrdinate";
            this._buttonCalculateSlopeAndOrdinate.Size = new System.Drawing.Size(172, 92);
            this._buttonCalculateSlopeAndOrdinate.TabIndex = 2;
            this._buttonCalculateSlopeAndOrdinate.Text = "Calculate Slope and Ordinate";
            this._buttonCalculateSlopeAndOrdinate.UseVisualStyleBackColor = true;
            this._buttonCalculateSlopeAndOrdinate.Click += new System.EventHandler(this.ButtonCalculateSlopeAndOrdinateClick);
            // 
            // _gridProjectionVariables
            // 
            this._gridProjectionVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridProjectionVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridProjectionVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridProjectionVariables.Location = new System.Drawing.Point(12, 112);
            this._gridProjectionVariables.Name = "_gridProjectionVariables";
            this._gridProjectionVariables.Size = new System.Drawing.Size(679, 515);
            this._gridProjectionVariables.TabIndex = 3;
            // 
            // _buttonUpdateDb
            // 
            this._buttonUpdateDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonUpdateDb.Location = new System.Drawing.Point(207, 2);
            this._buttonUpdateDb.Name = "_buttonUpdateDb";
            this._buttonUpdateDb.Size = new System.Drawing.Size(172, 92);
            this._buttonUpdateDb.TabIndex = 4;
            this._buttonUpdateDb.Text = "Update Data base";
            this._buttonUpdateDb.UseVisualStyleBackColor = true;
            this._buttonUpdateDb.Click += new System.EventHandler(this.ButtonUpdateDbClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 639);
            this.Controls.Add(this._buttonUpdateDb);
            this.Controls.Add(this._gridProjectionVariables);
            this.Controls.Add(this._buttonCalculateSlopeAndOrdinate);
            this.Name = "MainForm";
            this.Text = "Calculate Time Projection Variables";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._gridProjectionVariables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonCalculateSlopeAndOrdinate;
        private System.Windows.Forms.DataGridView _gridProjectionVariables;
        private System.Windows.Forms.Button _buttonUpdateDb;
    }
}

