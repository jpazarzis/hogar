namespace OddsEditor.Dialogs.PaceFigures
{
    partial class PaceFiguresFilterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._listBoxRaceClassification = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._listBoxTrackCondition = new System.Windows.Forms.CheckedListBox();
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this._listBoxRaceClassification);
            this.groupBox1.Location = new System.Drawing.Point(31, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Race Classification";
            // 
            // _listBoxRaceClassification
            // 
            this._listBoxRaceClassification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._listBoxRaceClassification.CheckOnClick = true;
            this._listBoxRaceClassification.FormattingEnabled = true;
            this._listBoxRaceClassification.Location = new System.Drawing.Point(19, 30);
            this._listBoxRaceClassification.Name = "_listBoxRaceClassification";
            this._listBoxRaceClassification.Size = new System.Drawing.Size(167, 394);
            this._listBoxRaceClassification.Sorted = true;
            this._listBoxRaceClassification.TabIndex = 0;
            this._listBoxRaceClassification.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._listBox_ItemCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._listBoxTrackCondition);
            this.groupBox2.Location = new System.Drawing.Point(279, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Track Condition";
            // 
            // _listBoxTrackCondition
            // 
            this._listBoxTrackCondition.CheckOnClick = true;
            this._listBoxTrackCondition.FormattingEnabled = true;
            this._listBoxTrackCondition.Location = new System.Drawing.Point(19, 30);
            this._listBoxTrackCondition.Name = "_listBoxTrackCondition";
            this._listBoxTrackCondition.Size = new System.Drawing.Size(167, 169);
            this._listBoxTrackCondition.Sorted = true;
            this._listBoxTrackCondition.TabIndex = 0;
            this._listBoxTrackCondition.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._listBox_ItemCheck);
            // 
            // _buttonOK
            // 
            this._buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonOK.Location = new System.Drawing.Point(529, 56);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 47);
            this._buttonOK.TabIndex = 2;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            this._buttonOK.Click += new System.EventHandler(this._buttonOK_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonCancel.Location = new System.Drawing.Point(529, 112);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 47);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
            // 
            // PaceFiguresFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 482);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PaceFiguresFilterForm";
            this.Text = "PaceFiguresFilterForm";
            this.Load += new System.EventHandler(this.PaceFiguresFilterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox _listBoxRaceClassification;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox _listBoxTrackCondition;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
    }
}