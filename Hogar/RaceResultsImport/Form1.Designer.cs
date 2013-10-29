namespace RaceResultsImport
{
    partial class Form1
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
            this._listboxAvailableRaces = new System.Windows.Forms.ListBox();
            this._buttonImportAll = new System.Windows.Forms.Button();
            this._txtboxMessages = new System.Windows.Forms.TextBox();
            this._buttonImportSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _listboxAvailableRaces
            // 
            this._listboxAvailableRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._listboxAvailableRaces.FormattingEnabled = true;
            this._listboxAvailableRaces.Location = new System.Drawing.Point(13, 49);
            this._listboxAvailableRaces.Name = "_listboxAvailableRaces";
            this._listboxAvailableRaces.Size = new System.Drawing.Size(141, 316);
            this._listboxAvailableRaces.TabIndex = 0;
            // 
            // _buttonImportAll
            // 
            this._buttonImportAll.Location = new System.Drawing.Point(13, 6);
            this._buttonImportAll.Name = "_buttonImportAll";
            this._buttonImportAll.Size = new System.Drawing.Size(75, 37);
            this._buttonImportAll.TabIndex = 1;
            this._buttonImportAll.Text = "Import All";
            this._buttonImportAll.UseVisualStyleBackColor = true;
            this._buttonImportAll.Click += new System.EventHandler(this.OnImportAll);
            // 
            // _txtboxMessages
            // 
            this._txtboxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtboxMessages.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxMessages.Location = new System.Drawing.Point(160, 49);
            this._txtboxMessages.Multiline = true;
            this._txtboxMessages.Name = "_txtboxMessages";
            this._txtboxMessages.ReadOnly = true;
            this._txtboxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtboxMessages.Size = new System.Drawing.Size(686, 316);
            this._txtboxMessages.TabIndex = 2;
            // 
            // _buttonImportSelected
            // 
            this._buttonImportSelected.Location = new System.Drawing.Point(116, 6);
            this._buttonImportSelected.Name = "_buttonImportSelected";
            this._buttonImportSelected.Size = new System.Drawing.Size(75, 37);
            this._buttonImportSelected.TabIndex = 3;
            this._buttonImportSelected.Text = "Import Selected";
            this._buttonImportSelected.UseVisualStyleBackColor = true;
            this._buttonImportSelected.Click += new System.EventHandler(this.OnImportSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 386);
            this.Controls.Add(this._buttonImportSelected);
            this.Controls.Add(this._txtboxMessages);
            this.Controls.Add(this._buttonImportAll);
            this.Controls.Add(this._listboxAvailableRaces);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Race Results Import";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _listboxAvailableRaces;
        private System.Windows.Forms.Button _buttonImportAll;
        private System.Windows.Forms.TextBox _txtboxMessages;
        private System.Windows.Forms.Button _buttonImportSelected;
    }
}

