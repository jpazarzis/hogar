namespace TrackVariantMaint.IntraTrackVariantMaint
{
    partial class AdjustIntraTrackVariantForm
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
            this._gridAvgFigures = new System.Windows.Forms.DataGridView();
            this._buttonCalculateIntraTrackVariant = new System.Windows.Forms.Button();
            this._buttonSaveStdAdjustments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._gridAvgFigures)).BeginInit();
            this.SuspendLayout();
            // 
            // _gridAvgFigures
            // 
            this._gridAvgFigures.AllowUserToAddRows = false;
            this._gridAvgFigures.AllowUserToDeleteRows = false;
            this._gridAvgFigures.AllowUserToOrderColumns = true;
            this._gridAvgFigures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridAvgFigures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridAvgFigures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridAvgFigures.Location = new System.Drawing.Point(22, 78);
            this._gridAvgFigures.Name = "_gridAvgFigures";
            this._gridAvgFigures.ReadOnly = true;
            this._gridAvgFigures.Size = new System.Drawing.Size(786, 565);
            this._gridAvgFigures.TabIndex = 1;
            this._gridAvgFigures.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            // 
            // _buttonCalculateIntraTrackVariant
            // 
            this._buttonCalculateIntraTrackVariant.Location = new System.Drawing.Point(331, 12);
            this._buttonCalculateIntraTrackVariant.Name = "_buttonCalculateIntraTrackVariant";
            this._buttonCalculateIntraTrackVariant.Size = new System.Drawing.Size(108, 51);
            this._buttonCalculateIntraTrackVariant.TabIndex = 6;
            this._buttonCalculateIntraTrackVariant.Text = "Calculate Intra-Track Variant";
            this._buttonCalculateIntraTrackVariant.UseVisualStyleBackColor = true;
            this._buttonCalculateIntraTrackVariant.Click += new System.EventHandler(this.CaclulateIntraTrackVariantClick);
            // 
            // _buttonSaveStdAdjustments
            // 
            this._buttonSaveStdAdjustments.Location = new System.Drawing.Point(531, 12);
            this._buttonSaveStdAdjustments.Name = "_buttonSaveStdAdjustments";
            this._buttonSaveStdAdjustments.Size = new System.Drawing.Size(108, 51);
            this._buttonSaveStdAdjustments.TabIndex = 7;
            this._buttonSaveStdAdjustments.Text = "Save Std Adj";
            this._buttonSaveStdAdjustments.UseVisualStyleBackColor = true;
            this._buttonSaveStdAdjustments.Click += new System.EventHandler(this.SaveStdAdjustmentsClick);
            // 
            // AdjustIntraTrackVariantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 684);
            this.Controls.Add(this._buttonSaveStdAdjustments);
            this.Controls.Add(this._buttonCalculateIntraTrackVariant);
            this.Controls.Add(this._gridAvgFigures);
            this.Name = "AdjustIntraTrackVariantForm";
            this.Text = "AdjustIntraTrackVariantForm";
            this.Load += new System.EventHandler(this.AdjustIntraTrackVariantForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._gridAvgFigures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _gridAvgFigures;
        private System.Windows.Forms.Button _buttonCalculateIntraTrackVariant;
        private System.Windows.Forms.Button _buttonSaveStdAdjustments;
    }
}