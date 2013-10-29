namespace OddsEditor.Dialogs
{
    partial class TrainerFilterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._txtboxMaxLayoff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtboxMinLayoff = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txtboxMaxOdds = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtboxMinOdds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._checkBoxTurf = new System.Windows.Forms.CheckBox();
            this._checkBoxDirt = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._checkBoxRoute = new System.Windows.Forms.CheckBox();
            this._checkBoxSprint = new System.Windows.Forms.CheckBox();
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txtboxMaxLayoff);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._txtboxMinLayoff);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layoff";
            // 
            // _txtboxMaxLayoff
            // 
            this._txtboxMaxLayoff.Location = new System.Drawing.Point(137, 26);
            this._txtboxMaxLayoff.MaxLength = 4;
            this._txtboxMaxLayoff.Name = "_txtboxMaxLayoff";
            this._txtboxMaxLayoff.Size = new System.Drawing.Size(40, 20);
            this._txtboxMaxLayoff.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // _txtboxMinLayoff
            // 
            this._txtboxMinLayoff.Location = new System.Drawing.Point(55, 26);
            this._txtboxMinLayoff.MaxLength = 4;
            this._txtboxMinLayoff.Name = "_txtboxMinLayoff";
            this._txtboxMinLayoff.Size = new System.Drawing.Size(40, 20);
            this._txtboxMinLayoff.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtboxMaxOdds);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._txtboxMinOdds);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 59);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Odds";
            // 
            // _txtboxMaxOdds
            // 
            this._txtboxMaxOdds.Location = new System.Drawing.Point(137, 26);
            this._txtboxMaxOdds.MaxLength = 4;
            this._txtboxMaxOdds.Name = "_txtboxMaxOdds";
            this._txtboxMaxOdds.Size = new System.Drawing.Size(40, 20);
            this._txtboxMaxOdds.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // _txtboxMinOdds
            // 
            this._txtboxMinOdds.Location = new System.Drawing.Point(55, 26);
            this._txtboxMinOdds.MaxLength = 4;
            this._txtboxMinOdds.Name = "_txtboxMinOdds";
            this._txtboxMinOdds.Size = new System.Drawing.Size(40, 20);
            this._txtboxMinOdds.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "From";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._checkBoxTurf);
            this.groupBox3.Controls.Add(this._checkBoxDirt);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 51);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Surface";
            // 
            // _checkBoxTurf
            // 
            this._checkBoxTurf.AutoSize = true;
            this._checkBoxTurf.Checked = true;
            this._checkBoxTurf.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxTurf.Location = new System.Drawing.Point(140, 21);
            this._checkBoxTurf.Name = "_checkBoxTurf";
            this._checkBoxTurf.Size = new System.Drawing.Size(45, 17);
            this._checkBoxTurf.TabIndex = 1;
            this._checkBoxTurf.Text = "Turf";
            this._checkBoxTurf.UseVisualStyleBackColor = true;
            // 
            // _checkBoxDirt
            // 
            this._checkBoxDirt.AutoSize = true;
            this._checkBoxDirt.Checked = true;
            this._checkBoxDirt.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxDirt.Location = new System.Drawing.Point(7, 20);
            this._checkBoxDirt.Name = "_checkBoxDirt";
            this._checkBoxDirt.Size = new System.Drawing.Size(42, 17);
            this._checkBoxDirt.TabIndex = 0;
            this._checkBoxDirt.Text = "Dirt";
            this._checkBoxDirt.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._checkBoxRoute);
            this.groupBox4.Controls.Add(this._checkBoxSprint);
            this.groupBox4.Location = new System.Drawing.Point(12, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 51);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Distance";
            // 
            // _checkBoxRoute
            // 
            this._checkBoxRoute.AutoSize = true;
            this._checkBoxRoute.Checked = true;
            this._checkBoxRoute.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxRoute.Location = new System.Drawing.Point(140, 21);
            this._checkBoxRoute.Name = "_checkBoxRoute";
            this._checkBoxRoute.Size = new System.Drawing.Size(55, 17);
            this._checkBoxRoute.TabIndex = 1;
            this._checkBoxRoute.Text = "Route";
            this._checkBoxRoute.UseVisualStyleBackColor = true;
            // 
            // _checkBoxSprint
            // 
            this._checkBoxSprint.AutoSize = true;
            this._checkBoxSprint.Checked = true;
            this._checkBoxSprint.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxSprint.Location = new System.Drawing.Point(7, 20);
            this._checkBoxSprint.Name = "_checkBoxSprint";
            this._checkBoxSprint.Size = new System.Drawing.Size(53, 17);
            this._checkBoxSprint.TabIndex = 0;
            this._checkBoxSprint.Text = "Sprint";
            this._checkBoxSprint.UseVisualStyleBackColor = true;
            // 
            // _buttonOK
            // 
            this._buttonOK.Location = new System.Drawing.Point(292, 27);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 23);
            this._buttonOK.TabIndex = 5;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            this._buttonOK.Click += new System.EventHandler(this.OnOK);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(292, 67);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 6;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // TrainerFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 311);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainerFilterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Trainer Filter";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _txtboxMaxLayoff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtboxMinLayoff;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _txtboxMaxOdds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtboxMinOdds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox _checkBoxTurf;
        private System.Windows.Forms.CheckBox _checkBoxDirt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox _checkBoxRoute;
        private System.Windows.Forms.CheckBox _checkBoxSprint;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
    }
}