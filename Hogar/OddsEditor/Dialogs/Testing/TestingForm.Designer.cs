﻿namespace OddsEditor.Dialogs.Testing
{
    partial class TestingForm
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
            this._buttonTestIndividualHorsePastPerfrormances = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonTestIndividualHorsePastPerfrormances
            // 
            this._buttonTestIndividualHorsePastPerfrormances.Location = new System.Drawing.Point(32, 51);
            this._buttonTestIndividualHorsePastPerfrormances.Name = "_buttonTestIndividualHorsePastPerfrormances";
            this._buttonTestIndividualHorsePastPerfrormances.Size = new System.Drawing.Size(125, 49);
            this._buttonTestIndividualHorsePastPerfrormances.TabIndex = 0;
            this._buttonTestIndividualHorsePastPerfrormances.Text = "Test Past Performances";
            this._buttonTestIndividualHorsePastPerfrormances.UseVisualStyleBackColor = true;
            this._buttonTestIndividualHorsePastPerfrormances.Click += new System.EventHandler(this.OnTestIndividualHorsePastPerfrormances);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this._buttonTestIndividualHorsePastPerfrormances);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonTestIndividualHorsePastPerfrormances;
    }
}