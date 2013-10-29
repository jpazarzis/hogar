namespace OddsEditor.MyComponents
{
    partial class SelectFileControl
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
            this._txtboxRacetrack = new System.Windows.Forms.TextBox();
            this._listboxDate = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _txtboxRacetrack
            // 
            this._txtboxRacetrack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtboxRacetrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxRacetrack.Location = new System.Drawing.Point(4, 4);
            this._txtboxRacetrack.Name = "_txtboxRacetrack";
            this._txtboxRacetrack.ReadOnly = true;
            this._txtboxRacetrack.Size = new System.Drawing.Size(217, 26);
            this._txtboxRacetrack.TabIndex = 0;
            this._txtboxRacetrack.Text = "Aqueduct";
            this._txtboxRacetrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtboxRacetrack.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnEditRaceTrackSetting);
            // 
            // _listboxDate
            // 
            this._listboxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._listboxDate.Font = new System.Drawing.Font("Andale Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listboxDate.FormattingEnabled = true;
            this._listboxDate.ItemHeight = 15;
            this._listboxDate.Location = new System.Drawing.Point(4, 37);
            this._listboxDate.Name = "_listboxDate";
            this._listboxDate.Size = new System.Drawing.Size(217, 199);
            this._listboxDate.TabIndex = 1;
            this._listboxDate.DoubleClick += new System.EventHandler(this.OnDoubleClick);
            // 
            // SelectFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listboxDate);
            this.Controls.Add(this._txtboxRacetrack);
            this.Name = "SelectFileControl";
            this.Size = new System.Drawing.Size(224, 240);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtboxRacetrack;
        private System.Windows.Forms.ListBox _listboxDate;
    }
}
