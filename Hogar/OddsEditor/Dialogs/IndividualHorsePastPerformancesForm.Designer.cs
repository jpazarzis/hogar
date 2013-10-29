namespace OddsEditor.Dialogs
{
    partial class IndividualHorsePastPerformancesForm
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
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.AutoScroll = true;
            this._panel.Location = new System.Drawing.Point(4, 5);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(1333, 682);
            this._panel.TabIndex = 0;
            // 
            // IndividualHorsePastPerformancesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 691);
            this.Controls.Add(this._panel);
            this.Name = "IndividualHorsePastPerformancesForm";
            this.Text = "IndividualHorsePastPerformancesForm (c)DeltaLover 2008-09 (c) John Pazarzis 2008-" +
                "09";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panel;
    }
}