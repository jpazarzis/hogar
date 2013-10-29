namespace OddsEditor.Dialogs
{
    partial class HorseFiguresForm
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
            this._webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // _webBrowser1
            // 
            this._webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._webBrowser1.Location = new System.Drawing.Point(0, 0);
            this._webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowser1.Name = "_webBrowser1";
            this._webBrowser1.Size = new System.Drawing.Size(185, 269);
            this._webBrowser1.TabIndex = 0;
            // 
            // HorseFiguresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 269);
            this.Controls.Add(this._webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HorseFiguresForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "HorseFiguresForm";
            this.Load += new System.EventHandler(this.HorseFiguresForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser _webBrowser1;
    }
}