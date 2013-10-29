namespace OddsEditor.Dialogs
{
    partial class HistogramForm
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
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this._histogramCtrl1 = new HogarControlLibrary.HistogramCtrl();
            this.SuspendLayout();
            // 
            // _histogramCtrl1
            // 
            this._histogramCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._histogramCtrl1.Location = new System.Drawing.Point(24, 22);
            this._histogramCtrl1.Name = "_histogramCtrl1";
            this._histogramCtrl1.Size = new System.Drawing.Size(522, 214);
            this._histogramCtrl1.TabIndex = 0;
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 264);
            this.Controls.Add(this._histogramCtrl1);
            this.Name = "HistogramForm";
            this.Text = "HistogramForm";
            this.Load += new System.EventHandler(this.HistogramForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private HogarControlLibrary.HistogramCtrl _histogramCtrl1;
    }
}