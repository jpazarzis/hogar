namespace WillardsStudio
{
    partial class RaceInfoCtrl
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
            this._txtboxDistance = new System.Windows.Forms.TextBox();
            this._txtboxFinalTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtboxClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtboxFirstCall = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._txtboxSecondCall = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtboxMaxClaimingPrice = new System.Windows.Forms.TextBox();
            this._txtboxInnerOrOuter = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance";
            // 
            // _txtboxDistance
            // 
            this._txtboxDistance.Location = new System.Drawing.Point(72, 24);
            this._txtboxDistance.Name = "_txtboxDistance";
            this._txtboxDistance.ReadOnly = true;
            this._txtboxDistance.Size = new System.Drawing.Size(47, 20);
            this._txtboxDistance.TabIndex = 1;
            // 
            // _txtboxFinalTime
            // 
            this._txtboxFinalTime.Location = new System.Drawing.Point(253, 65);
            this._txtboxFinalTime.Name = "_txtboxFinalTime";
            this._txtboxFinalTime.ReadOnly = true;
            this._txtboxFinalTime.Size = new System.Drawing.Size(100, 20);
            this._txtboxFinalTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Final Time";
            // 
            // _txtboxClass
            // 
            this._txtboxClass.Location = new System.Drawing.Point(281, 22);
            this._txtboxClass.Name = "_txtboxClass";
            this._txtboxClass.ReadOnly = true;
            this._txtboxClass.Size = new System.Drawing.Size(100, 20);
            this._txtboxClass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Class";
            // 
            // _txtboxFirstCall
            // 
            this._txtboxFirstCall.Location = new System.Drawing.Point(19, 65);
            this._txtboxFirstCall.Name = "_txtboxFirstCall";
            this._txtboxFirstCall.ReadOnly = true;
            this._txtboxFirstCall.Size = new System.Drawing.Size(100, 20);
            this._txtboxFirstCall.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "1st Call";
            // 
            // _txtboxSecondCall
            // 
            this._txtboxSecondCall.Location = new System.Drawing.Point(136, 65);
            this._txtboxSecondCall.Name = "_txtboxSecondCall";
            this._txtboxSecondCall.ReadOnly = true;
            this._txtboxSecondCall.Size = new System.Drawing.Size(100, 20);
            this._txtboxSecondCall.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "2nd Call";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._txtboxMaxClaimingPrice);
            this.groupBox1.Controls.Add(this._txtboxInnerOrOuter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._txtboxSecondCall);
            this.groupBox1.Controls.Add(this._txtboxDistance);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._txtboxFirstCall);
            this.groupBox1.Controls.Add(this._txtboxFinalTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._txtboxClass);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 94);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Race Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "MaxClaimingPrice";
            // 
            // _txtboxMaxClaimingPrice
            // 
            this._txtboxMaxClaimingPrice.Location = new System.Drawing.Point(483, 23);
            this._txtboxMaxClaimingPrice.Name = "_txtboxMaxClaimingPrice";
            this._txtboxMaxClaimingPrice.ReadOnly = true;
            this._txtboxMaxClaimingPrice.Size = new System.Drawing.Size(90, 20);
            this._txtboxMaxClaimingPrice.TabIndex = 12;
            this._txtboxMaxClaimingPrice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _txtboxInnerOrOuter
            // 
            this._txtboxInnerOrOuter.Location = new System.Drawing.Point(134, 26);
            this._txtboxInnerOrOuter.Name = "_txtboxInnerOrOuter";
            this._txtboxInnerOrOuter.ReadOnly = true;
            this._txtboxInnerOrOuter.Size = new System.Drawing.Size(101, 20);
            this._txtboxInnerOrOuter.TabIndex = 10;
            // 
            // RaceInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "RaceInfoCtrl";
            this.Size = new System.Drawing.Size(595, 101);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtboxDistance;
        private System.Windows.Forms.TextBox _txtboxFinalTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtboxClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtboxFirstCall;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtboxSecondCall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _txtboxInnerOrOuter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txtboxMaxClaimingPrice;
    }
}
