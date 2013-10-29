namespace OddsEditor.Dialogs
{
    partial class UpdateFactorsForm
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
            this._listbox = new System.Windows.Forms.ListBox();
            this._buttonUpdateAll = new System.Windows.Forms.Button();
            this._txtboxMessages = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _listbox
            // 
            this._listbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._listbox.FormattingEnabled = true;
            this._listbox.Location = new System.Drawing.Point(3, 40);
            this._listbox.Name = "_listbox";
            this._listbox.Size = new System.Drawing.Size(120, 225);
            this._listbox.TabIndex = 0;
            // 
            // _buttonUpdateAll
            // 
            this._buttonUpdateAll.Location = new System.Drawing.Point(3, 11);
            this._buttonUpdateAll.Name = "_buttonUpdateAll";
            this._buttonUpdateAll.Size = new System.Drawing.Size(75, 23);
            this._buttonUpdateAll.TabIndex = 1;
            this._buttonUpdateAll.Text = "Update All";
            this._buttonUpdateAll.UseVisualStyleBackColor = true;
            this._buttonUpdateAll.Click += new System.EventHandler(this.OnUpdateAll);
            // 
            // _txtboxMessages
            // 
            this._txtboxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtboxMessages.Location = new System.Drawing.Point(129, 40);
            this._txtboxMessages.Multiline = true;
            this._txtboxMessages.Name = "_txtboxMessages";
            this._txtboxMessages.ReadOnly = true;
            this._txtboxMessages.Size = new System.Drawing.Size(274, 225);
            this._txtboxMessages.TabIndex = 2;
            // 
            // UpdateFactorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 269);
            this.Controls.Add(this._txtboxMessages);
            this.Controls.Add(this._buttonUpdateAll);
            this.Controls.Add(this._listbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateFactorsForm";
            this.ShowInTaskbar = false;
            this.Text = "Update Factors";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _listbox;
        private System.Windows.Forms.Button _buttonUpdateAll;
        private System.Windows.Forms.TextBox _txtboxMessages;
    }
}