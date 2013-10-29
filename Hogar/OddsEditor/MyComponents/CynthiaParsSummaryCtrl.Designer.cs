namespace OddsEditor.MyComponents
{
    partial class CynthiaParsSummaryCtrl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._cynthiaProjectionsCtrl = new OddsEditor.MyComponents.CynthiaProjectionsCtrl();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 267);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._cynthiaProjectionsCtrl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(424, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Times";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _cynthiaProjectionsCtrl
            // 
            this._cynthiaProjectionsCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cynthiaProjectionsCtrl.Location = new System.Drawing.Point(3, 3);
            this._cynthiaProjectionsCtrl.Name = "_cynthiaProjectionsCtrl";
            this._cynthiaProjectionsCtrl.Size = new System.Drawing.Size(418, 235);
            this._cynthiaProjectionsCtrl.TabIndex = 5;
            // 
            // CynthiaParsSummaryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabControl1);
            this.Name = "CynthiaParsSummaryCtrl";
            this.Size = new System.Drawing.Size(450, 278);
            this.Load += new System.EventHandler(this.CynthiaParsSummaryCtrl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private CynthiaProjectionsCtrl _cynthiaProjectionsCtrl;

    }
}
