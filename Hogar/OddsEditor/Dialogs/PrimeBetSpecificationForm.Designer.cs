using OddsEditor.MyComponents;

namespace OddsEditor.Dialogs
{
    partial class PrimeBetSpecificationForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._tbMinWinners = new System.Windows.Forms.TextBox();
            this._tbMinMatches = new System.Windows.Forms.TextBox();
            this._tbMinIV = new System.Windows.Forms.TextBox();
            this._tbMinROI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._tbMinNumberOfQualifiedFactors = new System.Windows.Forms.TextBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min ROI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MIN IV";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._tbMinWinners);
            this.groupBox1.Controls.Add(this._tbMinMatches);
            this.groupBox1.Controls.Add(this._tbMinIV);
            this.groupBox1.Controls.Add(this._tbMinROI);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(31, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfomance Requirements";
            // 
            // _tbMinWinners
            // 
            this._tbMinWinners.Location = new System.Drawing.Point(314, 60);
            this._tbMinWinners.Name = "_tbMinWinners";
            this._tbMinWinners.Size = new System.Drawing.Size(100, 20);
            this._tbMinWinners.TabIndex = 10;
            this._tbMinWinners.Leave += new System.EventHandler(this.OnLeavingTextBox);
            this._tbMinWinners.Enter += new System.EventHandler(this.OnEnterTextBox);
            // 
            // _tbMinMatches
            // 
            this._tbMinMatches.Location = new System.Drawing.Point(314, 24);
            this._tbMinMatches.Name = "_tbMinMatches";
            this._tbMinMatches.Size = new System.Drawing.Size(100, 20);
            this._tbMinMatches.TabIndex = 9;
            this._tbMinMatches.Leave += new System.EventHandler(this.OnLeavingTextBox);
            this._tbMinMatches.Enter += new System.EventHandler(this.OnEnterTextBox);
            // 
            // _tbMinIV
            // 
            this._tbMinIV.Location = new System.Drawing.Point(63, 60);
            this._tbMinIV.Name = "_tbMinIV";
            this._tbMinIV.Size = new System.Drawing.Size(100, 20);
            this._tbMinIV.TabIndex = 8;
            this._tbMinIV.Leave += new System.EventHandler(this.OnLeavingTextBox);
            this._tbMinIV.Enter += new System.EventHandler(this.OnEnterTextBox);
            // 
            // _tbMinROI
            // 
            this._tbMinROI.Location = new System.Drawing.Point(63, 24);
            this._tbMinROI.Name = "_tbMinROI";
            this._tbMinROI.Size = new System.Drawing.Size(100, 20);
            this._tbMinROI.TabIndex = 7;
            this._tbMinROI.Leave += new System.EventHandler(this.OnLeavingTextBox);
            this._tbMinROI.Enter += new System.EventHandler(this.OnEnterTextBox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Min Matches";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min Winners";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._tbMinNumberOfQualifiedFactors);
            this.groupBox2.Location = new System.Drawing.Point(467, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Min Number of Qualified Factors";
            // 
            // _tbMinNumberOfQualifiedFactors
            // 
            this._tbMinNumberOfQualifiedFactors.Location = new System.Drawing.Point(37, 40);
            this._tbMinNumberOfQualifiedFactors.Name = "_tbMinNumberOfQualifiedFactors";
            this._tbMinNumberOfQualifiedFactors.Size = new System.Drawing.Size(100, 20);
            this._tbMinNumberOfQualifiedFactors.TabIndex = 11;
            this._tbMinNumberOfQualifiedFactors.Leave += new System.EventHandler(this.OnLeavingTextBox);
            this._tbMinNumberOfQualifiedFactors.Enter += new System.EventHandler(this.OnEnterTextBox);
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(467, 159);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 43);
            this._buttonSave.TabIndex = 12;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _buttonExit
            // 
            this._buttonExit.Location = new System.Drawing.Point(566, 159);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(75, 43);
            this._buttonExit.TabIndex = 13;
            this._buttonExit.Text = "Exit";
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this.OnExit);
            // 
            // PrimeBetSpecificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 214);
            this.Controls.Add(this._buttonExit);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrimeBetSpecificationForm";
            this.Text = "Prime Bet Specification Qualification";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Button _buttonExit;
        private System.Windows.Forms.TextBox _tbMinROI;
        private System.Windows.Forms.TextBox _tbMinWinners;
        private System.Windows.Forms.TextBox _tbMinMatches;
        private System.Windows.Forms.TextBox _tbMinIV;
        private System.Windows.Forms.TextBox _tbMinNumberOfQualifiedFactors;
    }
}