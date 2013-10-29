namespace OddsEditor.Dialogs
{
    partial class EditRaceTrackInfoForm
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
            this._buttonClose = new System.Windows.Forms.Button();
            this._tbTrackCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._tbBrisAbrv = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._tbTrackName = new System.Windows.Forms.TextBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonClose
            // 
            this._buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this._buttonClose.Location = new System.Drawing.Point(140, 146);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(95, 34);
            this._buttonClose.TabIndex = 15;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.OnClose);
            // 
            // _tbTrackCode
            // 
            this._tbTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackCode.Location = new System.Drawing.Point(16, 27);
            this._tbTrackCode.MaxLength = 3;
            this._tbTrackCode.Name = "_tbTrackCode";
            this._tbTrackCode.Size = new System.Drawing.Size(66, 26);
            this._tbTrackCode.TabIndex = 17;
            this._tbTrackCode.Text = "AQU";
            this._tbTrackCode.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._tbTrackCode);
            this.groupBox1.Location = new System.Drawing.Point(28, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 62);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._tbBrisAbrv);
            this.groupBox2.Location = new System.Drawing.Point(164, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 62);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bris Abrv";
            // 
            // _tbBrisAbrv
            // 
            this._tbBrisAbrv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbBrisAbrv.Location = new System.Drawing.Point(16, 27);
            this._tbBrisAbrv.MaxLength = 3;
            this._tbBrisAbrv.Name = "_tbBrisAbrv";
            this._tbBrisAbrv.Size = new System.Drawing.Size(66, 26);
            this._tbBrisAbrv.TabIndex = 17;
            this._tbBrisAbrv.Text = "AQU";
            this._tbBrisAbrv.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._tbTrackName);
            this.groupBox3.Location = new System.Drawing.Point(295, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 62);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Full Name";
            // 
            // _tbTrackName
            // 
            this._tbTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackName.Location = new System.Drawing.Point(16, 27);
            this._tbTrackName.MaxLength = 35;
            this._tbTrackName.Name = "_tbTrackName";
            this._tbTrackName.Size = new System.Drawing.Size(338, 26);
            this._tbTrackName.TabIndex = 17;
            this._tbTrackName.Text = "AQU";
            this._tbTrackName.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // _buttonSave
            // 
            this._buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSave.Location = new System.Drawing.Point(28, 146);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(95, 34);
            this._buttonSave.TabIndex = 21;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.OnSave);
            // 
            // EditRaceTrackInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 192);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRaceTrackInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EditRaceInfoForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.TextBox _tbTrackCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _tbBrisAbrv;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _tbTrackName;
        private System.Windows.Forms.Button _buttonSave;
    }
}