namespace OddsEditor.MyComponents
{
    partial class CalculateConstantsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._txtboxOutput = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txtboxoptimalConstant = new System.Windows.Forms.TextBox();
            this._buttonGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._txtboxMaxConstant = new System.Windows.Forms.TextBox();
            this._txtboxConstantStep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtboxMinConstant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._comboBoxVariableToUse = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min Constant";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._txtboxOutput);
            this.groupBox3.Location = new System.Drawing.Point(15, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 102);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // _txtboxOutput
            // 
            this._txtboxOutput.BackColor = System.Drawing.SystemColors.Window;
            this._txtboxOutput.Location = new System.Drawing.Point(6, 19);
            this._txtboxOutput.Multiline = true;
            this._txtboxOutput.Name = "_txtboxOutput";
            this._txtboxOutput.ReadOnly = true;
            this._txtboxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this._txtboxOutput.Size = new System.Drawing.Size(346, 77);
            this._txtboxOutput.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtboxoptimalConstant);
            this.groupBox2.Location = new System.Drawing.Point(160, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(113, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optimal Constant";
            // 
            // _txtboxoptimalConstant
            // 
            this._txtboxoptimalConstant.Location = new System.Drawing.Point(32, 39);
            this._txtboxoptimalConstant.Name = "_txtboxoptimalConstant";
            this._txtboxoptimalConstant.ReadOnly = true;
            this._txtboxoptimalConstant.Size = new System.Drawing.Size(43, 20);
            this._txtboxoptimalConstant.TabIndex = 0;
            // 
            // _buttonGo
            // 
            this._buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonGo.Location = new System.Drawing.Point(549, 3);
            this._buttonGo.Name = "_buttonGo";
            this._buttonGo.Size = new System.Drawing.Size(75, 31);
            this._buttonGo.TabIndex = 12;
            this._buttonGo.Text = "Go";
            this._buttonGo.UseVisualStyleBackColor = true;
            this._buttonGo.Click += new System.EventHandler(this.OnGo);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txtboxMaxConstant);
            this.groupBox1.Controls.Add(this._txtboxConstantStep);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._txtboxMinConstant);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 108);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specify Constants";
            // 
            // _txtboxMaxConstant
            // 
            this._txtboxMaxConstant.Location = new System.Drawing.Point(103, 50);
            this._txtboxMaxConstant.Name = "_txtboxMaxConstant";
            this._txtboxMaxConstant.Size = new System.Drawing.Size(33, 20);
            this._txtboxMaxConstant.TabIndex = 4;
            this._txtboxMaxConstant.Text = "100";
            // 
            // _txtboxConstantStep
            // 
            this._txtboxConstantStep.Location = new System.Drawing.Point(103, 78);
            this._txtboxConstantStep.Name = "_txtboxConstantStep";
            this._txtboxConstantStep.Size = new System.Drawing.Size(33, 20);
            this._txtboxConstantStep.TabIndex = 5;
            this._txtboxConstantStep.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max Constant";
            // 
            // _txtboxMinConstant
            // 
            this._txtboxMinConstant.Location = new System.Drawing.Point(103, 22);
            this._txtboxMinConstant.Name = "_txtboxMinConstant";
            this._txtboxMinConstant.Size = new System.Drawing.Size(33, 20);
            this._txtboxMinConstant.TabIndex = 3;
            this._txtboxMinConstant.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Step";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._comboBoxVariableToUse);
            this.groupBox4.Location = new System.Drawing.Point(299, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(191, 83);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Variable To Use";
            // 
            // _comboBoxVariableToUse
            // 
            this._comboBoxVariableToUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxVariableToUse.FormattingEnabled = true;
            this._comboBoxVariableToUse.Location = new System.Drawing.Point(20, 34);
            this._comboBoxVariableToUse.Name = "_comboBoxVariableToUse";
            this._comboBoxVariableToUse.Size = new System.Drawing.Size(151, 21);
            this._comboBoxVariableToUse.TabIndex = 0;
            // 
            // CalculateConstantsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._buttonGo);
            this.Controls.Add(this.groupBox1);
            this.Name = "CalculateConstantsControl";
            this.Size = new System.Drawing.Size(627, 259);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _txtboxOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _txtboxoptimalConstant;
        private System.Windows.Forms.Button _buttonGo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _txtboxMaxConstant;
        private System.Windows.Forms.TextBox _txtboxConstantStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtboxMinConstant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox _comboBoxVariableToUse;
    }
}
