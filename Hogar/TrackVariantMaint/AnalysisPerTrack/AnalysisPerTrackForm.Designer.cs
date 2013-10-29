namespace TrackVariantMaint.AnalysisPerTrack
{
    partial class AnalysisPerTrackForm
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
            this._panel = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.AutoScroll = true;
            this._panel.Location = new System.Drawing.Point(24, 48);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(462, 184);
            this._panel.TabIndex = 0;
            // 
            // _buttonLoad
            // 
            this._buttonLoad.Location = new System.Drawing.Point(46, 13);
            this._buttonLoad.Name = "_buttonLoad";
            this._buttonLoad.Size = new System.Drawing.Size(75, 23);
            this._buttonLoad.TabIndex = 1;
            this._buttonLoad.Text = "Load";
            this._buttonLoad.UseVisualStyleBackColor = true;
            this._buttonLoad.Click += new System.EventHandler(this._buttonLoad_Click);
            // 
            // AnalysisPerTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 264);
            this.Controls.Add(this._buttonLoad);
            this.Controls.Add(this._panel);
            this.Name = "AnalysisPerTrackForm";
            this.Text = "AnalysisPerTrackForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panel;
        private System.Windows.Forms.Button _buttonLoad;

    }
}