namespace TrackVariantMaint
{
    partial class MainForm
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
            this._cbTrackCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cbSurface = new System.Windows.Forms.ComboBox();
            this._buttonShowTrackVariantForm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._buttonIntraTrackVariant = new System.Windows.Forms.Button();
            this._buttonAnalysisPerTrack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cbTrackCode
            // 
            this._cbTrackCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbTrackCode.FormattingEnabled = true;
            this._cbTrackCode.Location = new System.Drawing.Point(26, 60);
            this._cbTrackCode.Name = "_cbTrackCode";
            this._cbTrackCode.Size = new System.Drawing.Size(220, 32);
            this._cbTrackCode.TabIndex = 0;
            this._cbTrackCode.SelectedIndexChanged += new System.EventHandler(this._cbTrackCode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Track Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Surface";
            // 
            // _cbSurface
            // 
            this._cbSurface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbSurface.FormattingEnabled = true;
            this._cbSurface.Location = new System.Drawing.Point(29, 157);
            this._cbSurface.Name = "_cbSurface";
            this._cbSurface.Size = new System.Drawing.Size(220, 32);
            this._cbSurface.TabIndex = 2;
            // 
            // _buttonShowTrackVariantForm
            // 
            this._buttonShowTrackVariantForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonShowTrackVariantForm.Location = new System.Drawing.Point(304, 34);
            this._buttonShowTrackVariantForm.Name = "_buttonShowTrackVariantForm";
            this._buttonShowTrackVariantForm.Size = new System.Drawing.Size(158, 83);
            this._buttonShowTrackVariantForm.TabIndex = 6;
            this._buttonShowTrackVariantForm.Text = "Track Variant Form";
            this._buttonShowTrackVariantForm.UseVisualStyleBackColor = true;
            this._buttonShowTrackVariantForm.Click += new System.EventHandler(this._buttonShowTrackVariantForm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._buttonShowTrackVariantForm);
            this.groupBox1.Controls.Add(this._cbTrackCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._cbSurface);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 222);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Make Track Variant For Specific Track And Surface";
            // 
            // _buttonIntraTrackVariant
            // 
            this._buttonIntraTrackVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonIntraTrackVariant.Location = new System.Drawing.Point(22, 285);
            this._buttonIntraTrackVariant.Name = "_buttonIntraTrackVariant";
            this._buttonIntraTrackVariant.Size = new System.Drawing.Size(158, 83);
            this._buttonIntraTrackVariant.TabIndex = 8;
            this._buttonIntraTrackVariant.Text = "Calculate Intra-Track Variant";
            this._buttonIntraTrackVariant.UseVisualStyleBackColor = true;
            this._buttonIntraTrackVariant.Click += new System.EventHandler(this._buttonIntraTrackVariant_Click);
            // 
            // _buttonAnalysisPerTrack
            // 
            this._buttonAnalysisPerTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonAnalysisPerTrack.Location = new System.Drawing.Point(202, 285);
            this._buttonAnalysisPerTrack.Name = "_buttonAnalysisPerTrack";
            this._buttonAnalysisPerTrack.Size = new System.Drawing.Size(158, 83);
            this._buttonAnalysisPerTrack.TabIndex = 9;
            this._buttonAnalysisPerTrack.Text = "Analysis Per Track";
            this._buttonAnalysisPerTrack.UseVisualStyleBackColor = true;
            this._buttonAnalysisPerTrack.Click += new System.EventHandler(this._buttonAnalysisPerTrack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 384);
            this.Controls.Add(this._buttonAnalysisPerTrack);
            this.Controls.Add(this._buttonIntraTrackVariant);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbTrackCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cbSurface;
        private System.Windows.Forms.Button _buttonShowTrackVariantForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _buttonIntraTrackVariant;
        private System.Windows.Forms.Button _buttonAnalysisPerTrack;
    }
}