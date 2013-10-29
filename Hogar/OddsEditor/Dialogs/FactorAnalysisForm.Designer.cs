namespace OddsEditor.Dialogs
{
    partial class FactorAnalysisForm
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
            this._factorAnalysisCtrl1 = new OddsEditor.MyComponents.FactorAnalysisCtrl();
            this.SuspendLayout();
            // 
            // _factorAnalysisCtrl1
            // 
            this._factorAnalysisCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._factorAnalysisCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._factorAnalysisCtrl1.Location = new System.Drawing.Point(33, 23);
            this._factorAnalysisCtrl1.Name = "_factorAnalysisCtrl1";
            this._factorAnalysisCtrl1.Size = new System.Drawing.Size(894, 408);
            this._factorAnalysisCtrl1.TabIndex = 0;
            // 
            // FactorAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 463);
            this.Controls.Add(this._factorAnalysisCtrl1);
            this.Name = "FactorAnalysisForm";
            this.Text = "FactorAnalysisForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private OddsEditor.MyComponents.FactorAnalysisCtrl _factorAnalysisCtrl1;
    }
}