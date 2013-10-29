namespace OddsEditor.MyComponents
{
    partial class HandicappingFactorLabel
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
            this._txtbox = new System.Windows.Forms.TextBox();
            this._txtboxThisTrackIV = new System.Windows.Forms.TextBox();
            this._txtboxTrackRoi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _txtbox
            // 
            this._txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._txtbox.Location = new System.Drawing.Point(4, 3);
            this._txtbox.Name = "_txtbox";
            this._txtbox.ReadOnly = true;
            this._txtbox.Size = new System.Drawing.Size(145, 20);
            this._txtbox.TabIndex = 0;
            // 
            // _txtboxThisTrackIV
            // 
            this._txtboxThisTrackIV.Location = new System.Drawing.Point(192, 3);
            this._txtboxThisTrackIV.Name = "_txtboxThisTrackIV";
            this._txtboxThisTrackIV.ReadOnly = true;
            this._txtboxThisTrackIV.Size = new System.Drawing.Size(31, 20);
            this._txtboxThisTrackIV.TabIndex = 3;
            // 
            // _txtboxTrackRoi
            // 
            this._txtboxTrackRoi.Location = new System.Drawing.Point(151, 3);
            this._txtboxTrackRoi.Name = "_txtboxTrackRoi";
            this._txtboxTrackRoi.ReadOnly = true;
            this._txtboxTrackRoi.Size = new System.Drawing.Size(39, 20);
            this._txtboxTrackRoi.TabIndex = 1;
            // 
            // HandicappingFactorLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtboxThisTrackIV);
            this.Controls.Add(this._txtbox);
            this.Controls.Add(this._txtboxTrackRoi);
            this.Name = "HandicappingFactorLabel";
            this.Size = new System.Drawing.Size(227, 27);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtbox;
        private System.Windows.Forms.TextBox _txtboxThisTrackIV;
        private System.Windows.Forms.TextBox _txtboxTrackRoi;
    }
}
