namespace OddsEditor.MyComponents
{
    partial class W2WStatsCtrl
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
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._tbTotalStarters = new System.Windows.Forms.TextBox();
            this._tbW2W = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox
            // 
            this._groupBox.BackColor = System.Drawing.Color.SeaShell;
            this._groupBox.Controls.Add(this._tbTotalStarters);
            this._groupBox.Controls.Add(this._tbW2W);
            this._groupBox.Controls.Add(this.label1);
            this._groupBox.Controls.Add(this.label2);
            this._groupBox.Location = new System.Drawing.Point(3, 3);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(190, 69);
            this._groupBox.TabIndex = 8;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "All Track Conditions";
            // 
            // _tbTotalStarters
            // 
            this._tbTotalStarters.BackColor = System.Drawing.Color.SeaShell;
            this._tbTotalStarters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbTotalStarters.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTotalStarters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this._tbTotalStarters.Location = new System.Drawing.Point(7, 38);
            this._tbTotalStarters.Name = "_tbTotalStarters";
            this._tbTotalStarters.ReadOnly = true;
            this._tbTotalStarters.Size = new System.Drawing.Size(73, 24);
            this._tbTotalStarters.TabIndex = 7;
            this._tbTotalStarters.Text = "1234";
            // 
            // _tbW2W
            // 
            this._tbW2W.BackColor = System.Drawing.Color.SeaShell;
            this._tbW2W.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbW2W.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbW2W.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this._tbW2W.Location = new System.Drawing.Point(109, 39);
            this._tbW2W.Name = "_tbW2W";
            this._tbW2W.ReadOnly = true;
            this._tbW2W.Size = new System.Drawing.Size(73, 24);
            this._tbW2W.TabIndex = 6;
            this._tbW2W.Text = "1234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "W2W";
            // 
            // W2WStatsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupBox);
            this.Name = "W2WStatsCtrl";
            this.Size = new System.Drawing.Size(197, 72);
            this.Load += new System.EventHandler(this.W2WStatsCtrl_Load);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.TextBox _tbTotalStarters;
        private System.Windows.Forms.TextBox _tbW2W;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
