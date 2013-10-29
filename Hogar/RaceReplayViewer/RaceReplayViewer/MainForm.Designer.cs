namespace RaceReplayViewer
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._comboBoxTrack = new System.Windows.Forms.ToolStripComboBox();
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._buttonGo = new System.Windows.Forms.Button();
            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this._comboBoxRaceNumber = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gold;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._comboBoxTrack,
            this.toolStripSeparator,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(736, 29);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _comboBoxTrack
            // 
            this._comboBoxTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxTrack.DropDownWidth = 200;
            this._comboBoxTrack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comboBoxTrack.Name = "_comboBoxTrack";
            this._comboBoxTrack.Size = new System.Drawing.Size(200, 29);
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.Location = new System.Drawing.Point(375, 3);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this._dateTimePicker.TabIndex = 1;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // _buttonGo
            // 
            this._buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonGo.Location = new System.Drawing.Point(633, 4);
            this._buttonGo.Name = "_buttonGo";
            this._buttonGo.Size = new System.Drawing.Size(75, 23);
            this._buttonGo.TabIndex = 2;
            this._buttonGo.Text = "Go";
            this._buttonGo.UseVisualStyleBackColor = true;
            this._buttonGo.Click += new System.EventHandler(this._buttonGo_Click);
            // 
            // _webBrowser
            // 
            this._webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._webBrowser.Location = new System.Drawing.Point(0, 46);
            this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowser.Name = "_webBrowser";
            this._webBrowser.Size = new System.Drawing.Size(724, 299);
            this._webBrowser.TabIndex = 3;
            // 
            // _comboBoxRaceNumber
            // 
            this._comboBoxRaceNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxRaceNumber.FormattingEnabled = true;
            this._comboBoxRaceNumber.Location = new System.Drawing.Point(276, 2);
            this._comboBoxRaceNumber.Name = "_comboBoxRaceNumber";
            this._comboBoxRaceNumber.Size = new System.Drawing.Size(52, 21);
            this._comboBoxRaceNumber.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 357);
            this.Controls.Add(this._comboBoxRaceNumber);
            this.Controls.Add(this._webBrowser);
            this.Controls.Add(this._buttonGo);
            this.Controls.Add(this._dateTimePicker);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Race Replays  version 1.0 (by John Pazarzis) ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox _comboBoxTrack;
        private System.Windows.Forms.DateTimePicker _dateTimePicker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button _buttonGo;
        private System.Windows.Forms.WebBrowser _webBrowser;
        private System.Windows.Forms.ComboBox _comboBoxRaceNumber;
    }
}

