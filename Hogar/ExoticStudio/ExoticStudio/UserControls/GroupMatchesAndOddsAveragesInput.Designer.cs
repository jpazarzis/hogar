namespace ExoticStudio.UserControls
{
    partial class GroupMatchesAndOddsAveragesInput
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._maxGroupMatchesComboBox = new System.Windows.Forms.ComboBox();
            this._minGroupMatchesComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._maxGroupMatchesComboBox);
            this.groupBox2.Controls.Add(this._minGroupMatchesComboBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 126);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Group Matches";
            // 
            // _maxGroupMatchesComboBox
            // 
            this._maxGroupMatchesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._maxGroupMatchesComboBox.FormattingEnabled = true;
            this._maxGroupMatchesComboBox.Location = new System.Drawing.Point(77, 76);
            this._maxGroupMatchesComboBox.Name = "_maxGroupMatchesComboBox";
            this._maxGroupMatchesComboBox.Size = new System.Drawing.Size(44, 21);
            this._maxGroupMatchesComboBox.TabIndex = 3;
            this._maxGroupMatchesComboBox.SelectedValueChanged += new System.EventHandler(this.OnMaxChanged);
            // 
            // _minGroupMatchesComboBox
            // 
            this._minGroupMatchesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._minGroupMatchesComboBox.FormattingEnabled = true;
            this._minGroupMatchesComboBox.Location = new System.Drawing.Point(77, 33);
            this._minGroupMatchesComboBox.Name = "_minGroupMatchesComboBox";
            this._minGroupMatchesComboBox.Size = new System.Drawing.Size(44, 21);
            this._minGroupMatchesComboBox.TabIndex = 2;
            this._minGroupMatchesComboBox.SelectedValueChanged += new System.EventHandler(this.OnMinChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "From";
            // 
            // GroupMatchesAndOddsAveragesInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "GroupMatchesAndOddsAveragesInput";
            this.Size = new System.Drawing.Size(183, 340);
            this.Load += new System.EventHandler(this.OnLoad);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox _maxGroupMatchesComboBox;
        private System.Windows.Forms.ComboBox _minGroupMatchesComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
