namespace ExoticStudio
{
    partial class SelectNumberOfRacesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._numberOfRacesComboBox = new System.Windows.Forms.ComboBox();
            this._OKButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Races";
            // 
            // _numberOfRacesComboBox
            // 
            this._numberOfRacesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._numberOfRacesComboBox.FormattingEnabled = true;
            this._numberOfRacesComboBox.Location = new System.Drawing.Point(142, 42);
            this._numberOfRacesComboBox.Name = "_numberOfRacesComboBox";
            this._numberOfRacesComboBox.Size = new System.Drawing.Size(75, 21);
            this._numberOfRacesComboBox.TabIndex = 1;
            // 
            // _OKButton
            // 
            this._OKButton.Location = new System.Drawing.Point(27, 125);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 2;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this.OnOK);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(177, 125);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 3;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // SelectNumberOfRacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 173);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._numberOfRacesComboBox);
            this.Controls.Add(this.label1);
            this.Name = "SelectNumberOfRacesForm";
            this.Text = "SelectNumberOfRacesForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _numberOfRacesComboBox;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}