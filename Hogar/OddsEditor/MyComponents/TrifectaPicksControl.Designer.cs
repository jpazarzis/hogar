namespace OddsEditor.MyComponents
{
    partial class TrifectaPicksControl
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
            this._txtboxPosition = new System.Windows.Forms.TextBox();
            this._buttonSelections = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtboxPosition
            // 
            this._txtboxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtboxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxPosition.ForeColor = System.Drawing.SystemColors.Window;
            this._txtboxPosition.Location = new System.Drawing.Point(4, 4);
            this._txtboxPosition.Name = "_txtboxPosition";
            this._txtboxPosition.ReadOnly = true;
            this._txtboxPosition.Size = new System.Drawing.Size(177, 24);
            this._txtboxPosition.TabIndex = 0;
            this._txtboxPosition.Text = "Position 1";
            this._txtboxPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _buttonSelections
            // 
            this._buttonSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSelections.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSelections.Location = new System.Drawing.Point(4, 30);
            this._buttonSelections.Name = "_buttonSelections";
            this._buttonSelections.Size = new System.Drawing.Size(177, 111);
            this._buttonSelections.TabIndex = 1;
            this._buttonSelections.Text = "1,2,3,4";
            this._buttonSelections.UseVisualStyleBackColor = true;
            this._buttonSelections.Click += new System.EventHandler(this.OnSelectionsClick);
            // 
            // TrifectaPicksControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonSelections);
            this.Controls.Add(this._txtboxPosition);
            this.Name = "TrifectaPicksControl";
            this.Size = new System.Drawing.Size(184, 144);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtboxPosition;
        private System.Windows.Forms.Button _buttonSelections;

    }
}
