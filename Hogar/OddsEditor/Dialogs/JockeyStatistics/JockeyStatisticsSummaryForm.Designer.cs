namespace OddsEditor.Dialogs.JockeyStatistics
{
    partial class JockeyStatisticsSummaryForm
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
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _listBox
            // 
            this._listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._listBox.FormattingEnabled = true;
            this._listBox.Location = new System.Drawing.Point(12, 12);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(290, 446);
            this._listBox.TabIndex = 0;
            this._listBox.DoubleClick += new System.EventHandler(this.OnDoubleClick);
            // 
            // JockeyStatisticsSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 472);
            this.Controls.Add(this._listBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JockeyStatisticsSummaryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Jockey Statistics";
            this.Load += new System.EventHandler(this.OnInitiaLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _listBox;
    }
}