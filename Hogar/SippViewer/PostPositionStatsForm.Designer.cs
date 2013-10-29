namespace SippViewer
{
    partial class PostPositionStatsForm
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
            this._tbTrackCode = new System.Windows.Forms.TextBox();
            this._tbSurface = new System.Windows.Forms.TextBox();
            this._tbAboutFlag = new System.Windows.Forms.TextBox();
            this._tbDistance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.AutoScroll = true;
            this._panel.Location = new System.Drawing.Point(12, 90);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(1216, 648);
            this._panel.TabIndex = 0;
            // 
            // _tbTrackCode
            // 
            this._tbTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackCode.Location = new System.Drawing.Point(28, 12);
            this._tbTrackCode.Name = "_tbTrackCode";
            this._tbTrackCode.ReadOnly = true;
            this._tbTrackCode.Size = new System.Drawing.Size(60, 29);
            this._tbTrackCode.TabIndex = 1;
            this._tbTrackCode.Text = "AQU";
            // 
            // _tbSurface
            // 
            this._tbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSurface.Location = new System.Drawing.Point(94, 12);
            this._tbSurface.Name = "_tbSurface";
            this._tbSurface.ReadOnly = true;
            this._tbSurface.Size = new System.Drawing.Size(33, 29);
            this._tbSurface.TabIndex = 2;
            this._tbSurface.Text = "T";
            // 
            // _tbAboutFlag
            // 
            this._tbAboutFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAboutFlag.Location = new System.Drawing.Point(131, 12);
            this._tbAboutFlag.Name = "_tbAboutFlag";
            this._tbAboutFlag.ReadOnly = true;
            this._tbAboutFlag.Size = new System.Drawing.Size(23, 29);
            this._tbAboutFlag.TabIndex = 3;
            this._tbAboutFlag.Text = "A";
            // 
            // _tbDistance
            // 
            this._tbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDistance.Location = new System.Drawing.Point(160, 12);
            this._tbDistance.Name = "_tbDistance";
            this._tbDistance.ReadOnly = true;
            this._tbDistance.Size = new System.Drawing.Size(140, 29);
            this._tbDistance.TabIndex = 4;
            this._tbDistance.Text = "A";
            // 
            // PostPositionStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 750);
            this.Controls.Add(this._tbDistance);
            this.Controls.Add(this._tbAboutFlag);
            this.Controls.Add(this._tbSurface);
            this.Controls.Add(this._tbTrackCode);
            this.Controls.Add(this._panel);
            this.Name = "PostPositionStatsForm";
            this.Text = "PostPositionStatsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PostPositionStatsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panel;
        private System.Windows.Forms.TextBox _tbTrackCode;
        private System.Windows.Forms.TextBox _tbSurface;
        private System.Windows.Forms.TextBox _tbAboutFlag;
        private System.Windows.Forms.TextBox _tbDistance;

    }
}