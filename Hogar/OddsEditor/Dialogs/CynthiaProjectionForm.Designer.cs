namespace OddsEditor.Dialogs
{
    partial class CynthiaProjectionForm
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
            this._cynthiaProjectionsCtrl = new OddsEditor.MyComponents.CynthiaProjectionsFullCtrl();
            this.SuspendLayout();
            // 
            // _cynthiaProjectionsCtrl
            // 
            this._cynthiaProjectionsCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cynthiaProjectionsCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._cynthiaProjectionsCtrl.Location = new System.Drawing.Point(12, 12);
            this._cynthiaProjectionsCtrl.Name = "_cynthiaProjectionsCtrl";
            this._cynthiaProjectionsCtrl.Size = new System.Drawing.Size(1295, 853);
            this._cynthiaProjectionsCtrl.TabIndex = 0;
            // 
            // CynthiaProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 877);
            this.Controls.Add(this._cynthiaProjectionsCtrl);
            this.Name = "CynthiaProjectionForm";
            this.Text = "CynthiaProjectionForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private OddsEditor.MyComponents.CynthiaProjectionsFullCtrl _cynthiaProjectionsCtrl;
    }
}