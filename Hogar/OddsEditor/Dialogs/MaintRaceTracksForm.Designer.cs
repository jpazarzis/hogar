namespace OddsEditor.Dialogs
{
    partial class MaintRaceTracksForm
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
            this._listboxRaceTracks = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txtboxFullName = new System.Windows.Forms.TextBox();
            this._txtboxTrackCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtboxBrisAbrv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._buttonEdit = new System.Windows.Forms.Button();
            this._buttonNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _listboxRaceTracks
            // 
            this._listboxRaceTracks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._listboxRaceTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listboxRaceTracks.FormattingEnabled = true;
            this._listboxRaceTracks.ItemHeight = 16;
            this._listboxRaceTracks.Location = new System.Drawing.Point(18, 9);
            this._listboxRaceTracks.Margin = new System.Windows.Forms.Padding(4);
            this._listboxRaceTracks.Name = "_listboxRaceTracks";
            this._listboxRaceTracks.Size = new System.Drawing.Size(234, 308);
            this._listboxRaceTracks.TabIndex = 0;
            this._listboxRaceTracks.SelectedIndexChanged += new System.EventHandler(this._listboxRaceTracks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Full Name";
            // 
            // _txtboxFullName
            // 
            this._txtboxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxFullName.Location = new System.Drawing.Point(408, 31);
            this._txtboxFullName.Margin = new System.Windows.Forms.Padding(4);
            this._txtboxFullName.Name = "_txtboxFullName";
            this._txtboxFullName.ReadOnly = true;
            this._txtboxFullName.Size = new System.Drawing.Size(216, 29);
            this._txtboxFullName.TabIndex = 2;
            // 
            // _txtboxTrackCode
            // 
            this._txtboxTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTrackCode.Location = new System.Drawing.Point(408, 82);
            this._txtboxTrackCode.Margin = new System.Windows.Forms.Padding(4);
            this._txtboxTrackCode.MaxLength = 3;
            this._txtboxTrackCode.Name = "_txtboxTrackCode";
            this._txtboxTrackCode.ReadOnly = true;
            this._txtboxTrackCode.Size = new System.Drawing.Size(62, 29);
            this._txtboxTrackCode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Track Code";
            // 
            // _txtboxBrisAbrv
            // 
            this._txtboxBrisAbrv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxBrisAbrv.Location = new System.Drawing.Point(408, 143);
            this._txtboxBrisAbrv.Margin = new System.Windows.Forms.Padding(4);
            this._txtboxBrisAbrv.MaxLength = 3;
            this._txtboxBrisAbrv.Name = "_txtboxBrisAbrv";
            this._txtboxBrisAbrv.ReadOnly = true;
            this._txtboxBrisAbrv.Size = new System.Drawing.Size(62, 29);
            this._txtboxBrisAbrv.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bris Abrv";
            // 
            // _buttonEdit
            // 
            this._buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonEdit.Location = new System.Drawing.Point(276, 260);
            this._buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Size = new System.Drawing.Size(113, 56);
            this._buttonEdit.TabIndex = 7;
            this._buttonEdit.Text = "Edit";
            this._buttonEdit.UseVisualStyleBackColor = true;
            this._buttonEdit.Click += new System.EventHandler(this.OnEdit);
            // 
            // _buttonNew
            // 
            this._buttonNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonNew.Location = new System.Drawing.Point(423, 260);
            this._buttonNew.Margin = new System.Windows.Forms.Padding(4);
            this._buttonNew.Name = "_buttonNew";
            this._buttonNew.Size = new System.Drawing.Size(113, 56);
            this._buttonNew.TabIndex = 8;
            this._buttonNew.Text = "New";
            this._buttonNew.UseVisualStyleBackColor = true;
            this._buttonNew.Click += new System.EventHandler(this.OnNew);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(573, 260);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 56);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClose);
            // 
            // MaintRaceTracksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 334);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._buttonNew);
            this.Controls.Add(this._buttonEdit);
            this.Controls.Add(this._txtboxBrisAbrv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtboxTrackCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtboxFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._listboxRaceTracks);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MaintRaceTracksForm";
            this.Text = "MaintRaceTracksForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _listboxRaceTracks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtboxFullName;
        private System.Windows.Forms.TextBox _txtboxTrackCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtboxBrisAbrv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _buttonEdit;
        private System.Windows.Forms.Button _buttonNew;
        private System.Windows.Forms.Button button1;
    }
}