namespace OddsEditor.Dialogs.KeyRacesViewer
{
    partial class HorseCtrl
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
            this._lableProgramNuber = new System.Windows.Forms.Label();
            this._labelHorseName = new System.Windows.Forms.Label();
            this._labelOdds = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lableProgramNuber
            // 
            this._lableProgramNuber.AutoSize = true;
            this._lableProgramNuber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._lableProgramNuber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lableProgramNuber.ForeColor = System.Drawing.Color.Yellow;
            this._lableProgramNuber.Location = new System.Drawing.Point(4, 5);
            this._lableProgramNuber.Name = "_lableProgramNuber";
            this._lableProgramNuber.Size = new System.Drawing.Size(29, 20);
            this._lableProgramNuber.TabIndex = 0;
            this._lableProgramNuber.Text = "12";
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._labelHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseName.ForeColor = System.Drawing.Color.Yellow;
            this._labelHorseName.Location = new System.Drawing.Point(98, 5);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(84, 20);
            this._labelHorseName.TabIndex = 1;
            this._labelHorseName.Text = "Uncle Mo";
            // 
            // _labelOdds
            // 
            this._labelOdds.AutoSize = true;
            this._labelOdds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._labelOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelOdds.ForeColor = System.Drawing.Color.Yellow;
            this._labelOdds.Location = new System.Drawing.Point(43, 5);
            this._labelOdds.Name = "_labelOdds";
            this._labelOdds.Size = new System.Drawing.Size(29, 20);
            this._labelOdds.TabIndex = 2;
            this._labelOdds.Text = "12";
            // 
            // HorseCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._labelOdds);
            this.Controls.Add(this._labelHorseName);
            this.Controls.Add(this._lableProgramNuber);
            this.Name = "HorseCtrl";
            this.Size = new System.Drawing.Size(273, 31);
            this.Load += new System.EventHandler(this.HorseCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lableProgramNuber;
        private System.Windows.Forms.Label _labelHorseName;
        private System.Windows.Forms.Label _labelOdds;
    }
}
