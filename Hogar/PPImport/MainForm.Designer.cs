namespace PPImport
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
            this._listboxPastPerfomances = new System.Windows.Forms.ListBox();
            this._buttonImportAll = new System.Windows.Forms.Button();
            this._buttonImportSelected = new System.Windows.Forms.Button();
            this._comboBoxSelectedYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txtboxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _listboxPastPerfomances
            // 
            this._listboxPastPerfomances.FormattingEnabled = true;
            this._listboxPastPerfomances.Location = new System.Drawing.Point(13, 96);
            this._listboxPastPerfomances.Name = "_listboxPastPerfomances";
            this._listboxPastPerfomances.Size = new System.Drawing.Size(120, 420);
            this._listboxPastPerfomances.TabIndex = 0;
            // 
            // _buttonImportAll
            // 
            this._buttonImportAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonImportAll.Location = new System.Drawing.Point(13, 13);
            this._buttonImportAll.Name = "_buttonImportAll";
            this._buttonImportAll.Size = new System.Drawing.Size(108, 58);
            this._buttonImportAll.TabIndex = 1;
            this._buttonImportAll.Text = "Import All";
            this._buttonImportAll.UseVisualStyleBackColor = true;
            this._buttonImportAll.Click += new System.EventHandler(this.OnImportAll);
            // 
            // _buttonImportSelected
            // 
            this._buttonImportSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonImportSelected.Location = new System.Drawing.Point(127, 13);
            this._buttonImportSelected.Name = "_buttonImportSelected";
            this._buttonImportSelected.Size = new System.Drawing.Size(108, 58);
            this._buttonImportSelected.TabIndex = 2;
            this._buttonImportSelected.Text = "Import Selected";
            this._buttonImportSelected.UseVisualStyleBackColor = true;
            // 
            // _comboBoxSelectedYear
            // 
            this._comboBoxSelectedYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSelectedYear.FormattingEnabled = true;
            this._comboBoxSelectedYear.Items.AddRange(new object[] {
            "2011",
            "2010",
            "2009",
            "2008",
            "2007"});
            this._comboBoxSelectedYear.Location = new System.Drawing.Point(296, 20);
            this._comboBoxSelectedYear.Name = "_comboBoxSelectedYear";
            this._comboBoxSelectedYear.Size = new System.Drawing.Size(73, 21);
            this._comboBoxSelectedYear.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year";
            // 
            // _txtboxMessage
            // 
            this._txtboxMessage.Location = new System.Drawing.Point(179, 109);
            this._txtboxMessage.Multiline = true;
            this._txtboxMessage.Name = "_txtboxMessage";
            this._txtboxMessage.ReadOnly = true;
            this._txtboxMessage.Size = new System.Drawing.Size(389, 292);
            this._txtboxMessage.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 537);
            this.Controls.Add(this._txtboxMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._comboBoxSelectedYear);
            this.Controls.Add(this._buttonImportSelected);
            this.Controls.Add(this._buttonImportAll);
            this.Controls.Add(this._listboxPastPerfomances);
            this.Name = "MainForm";
            this.Text = "Import Past Performances";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _listboxPastPerfomances;
        private System.Windows.Forms.Button _buttonImportAll;
        private System.Windows.Forms.Button _buttonImportSelected;
        private System.Windows.Forms.ComboBox _comboBoxSelectedYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtboxMessage;
    }
}

