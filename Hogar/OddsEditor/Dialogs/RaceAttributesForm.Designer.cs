namespace OddsEditor.Dialogs
{
    partial class RaceAttributesForm
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
            this._panel = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._labelRaceTrackInfo = new System.Windows.Forms.Label();
            this._comboBoxFactorsDepth = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txtboxMatches = new System.Windows.Forms.TextBox();
            this._buttonForceUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.AutoScroll = true;
            this._panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panel.Location = new System.Drawing.Point(5, 49);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(495, 162);
            this._panel.TabIndex = 0;
            // 
            // _buttonOK
            // 
            this._buttonOK.Location = new System.Drawing.Point(233, 251);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(86, 29);
            this._buttonOK.TabIndex = 1;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            this._buttonOK.Click += new System.EventHandler(this.OnOK);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(414, 251);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(86, 29);
            this._buttonCancel.TabIndex = 2;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this._labelRaceTrackInfo);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 40);
            this.panel1.TabIndex = 3;
            // 
            // _labelRaceTrackInfo
            // 
            this._labelRaceTrackInfo.AutoSize = true;
            this._labelRaceTrackInfo.Location = new System.Drawing.Point(8, 10);
            this._labelRaceTrackInfo.Name = "_labelRaceTrackInfo";
            this._labelRaceTrackInfo.Size = new System.Drawing.Size(57, 20);
            this._labelRaceTrackInfo.TabIndex = 0;
            this._labelRaceTrackInfo.Text = "label1";
            // 
            // _comboBoxFactorsDepth
            // 
            this._comboBoxFactorsDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFactorsDepth.FormattingEnabled = true;
            this._comboBoxFactorsDepth.Location = new System.Drawing.Point(15, 19);
            this._comboBoxFactorsDepth.Name = "_comboBoxFactorsDepth";
            this._comboBoxFactorsDepth.Size = new System.Drawing.Size(59, 21);
            this._comboBoxFactorsDepth.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._comboBoxFactorsDepth);
            this.groupBox1.Location = new System.Drawing.Point(17, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 47);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factor\'s Depth";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtboxMatches);
            this.groupBox2.Location = new System.Drawing.Point(134, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 47);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matches";
            // 
            // _txtboxMatches
            // 
            this._txtboxMatches.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._txtboxMatches.Location = new System.Drawing.Point(7, 19);
            this._txtboxMatches.Name = "_txtboxMatches";
            this._txtboxMatches.ReadOnly = true;
            this._txtboxMatches.Size = new System.Drawing.Size(78, 20);
            this._txtboxMatches.TabIndex = 0;
            // 
            // _buttonForceUpdate
            // 
            this._buttonForceUpdate.Location = new System.Drawing.Point(322, 251);
            this._buttonForceUpdate.Name = "_buttonForceUpdate";
            this._buttonForceUpdate.Size = new System.Drawing.Size(86, 29);
            this._buttonForceUpdate.TabIndex = 8;
            this._buttonForceUpdate.Text = "Force Update";
            this._buttonForceUpdate.UseVisualStyleBackColor = true;
            this._buttonForceUpdate.Click += new System.EventHandler(this.OnForceUpdate);
            // 
            // RaceAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(503, 294);
            this.Controls.Add(this._buttonForceUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this._panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RaceAttributesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RaceAttributesForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _panel;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _labelRaceTrackInfo;
        private System.Windows.Forms.ComboBox _comboBoxFactorsDepth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _txtboxMatches;
        private System.Windows.Forms.Button _buttonForceUpdate;
    }
}