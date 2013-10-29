namespace OddsEditor.Dialogs
{
    partial class ShowAllTimeGraphsForm
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
            this._panelName = new System.Windows.Forms.Panel();
            this._labelHorseName = new System.Windows.Forms.Label();
            this._panelName.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panel.Location = new System.Drawing.Point(4, 44);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(520, 213);
            this._panel.TabIndex = 0;
            // 
            // _panelName
            // 
            this._panelName.BackColor = System.Drawing.Color.Black;
            this._panelName.Controls.Add(this._labelHorseName);
            this._panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._panelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._panelName.Location = new System.Drawing.Point(0, 0);
            this._panelName.Name = "_panelName";
            this._panelName.Size = new System.Drawing.Size(524, 37);
            this._panelName.TabIndex = 1;
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.Location = new System.Drawing.Point(12, 9);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(122, 24);
            this._labelHorseName.TabIndex = 0;
            this._labelHorseName.Text = "Elegant Boy";
            // 
            // ShowAllTimeGraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 264);
            this.Controls.Add(this._panelName);
            this.Controls.Add(this._panel);
            this.Name = "ShowAllTimeGraphsForm";
            this.Text = "ShowAllTimeGraphsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._panelName.ResumeLayout(false);
            this._panelName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panel;
        private System.Windows.Forms.Panel _panelName;
        private System.Windows.Forms.Label _labelHorseName;
    }
}