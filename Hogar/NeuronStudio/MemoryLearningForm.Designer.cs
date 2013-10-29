namespace NeuronStudio
{
    partial class MemoryLearningForm
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
            this._buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._tbNumberOfRacesForTraining = new System.Windows.Forms.TextBox();
            this._tbNumberOfRacesForTesting = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbNumberOfCorrectPredictions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbNumberOfWrongPredictions = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonLoad
            // 
            this._buttonLoad.Location = new System.Drawing.Point(23, 23);
            this._buttonLoad.Name = "_buttonLoad";
            this._buttonLoad.Size = new System.Drawing.Size(75, 38);
            this._buttonLoad.TabIndex = 0;
            this._buttonLoad.Text = "Load";
            this._buttonLoad.UseVisualStyleBackColor = true;
            this._buttonLoad.Click += new System.EventHandler(this._buttonLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# races for training";
            // 
            // _tbNumberOfRacesForTraining
            // 
            this._tbNumberOfRacesForTraining.Location = new System.Drawing.Point(26, 103);
            this._tbNumberOfRacesForTraining.Name = "_tbNumberOfRacesForTraining";
            this._tbNumberOfRacesForTraining.ReadOnly = true;
            this._tbNumberOfRacesForTraining.Size = new System.Drawing.Size(100, 20);
            this._tbNumberOfRacesForTraining.TabIndex = 2;
            // 
            // _tbNumberOfRacesForTesting
            // 
            this._tbNumberOfRacesForTesting.Location = new System.Drawing.Point(26, 150);
            this._tbNumberOfRacesForTesting.Name = "_tbNumberOfRacesForTesting";
            this._tbNumberOfRacesForTesting.ReadOnly = true;
            this._tbNumberOfRacesForTesting.Size = new System.Drawing.Size(100, 20);
            this._tbNumberOfRacesForTesting.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "# races for testing";
            // 
            // _tbNumberOfCorrectPredictions
            // 
            this._tbNumberOfCorrectPredictions.Location = new System.Drawing.Point(154, 100);
            this._tbNumberOfCorrectPredictions.Name = "_tbNumberOfCorrectPredictions";
            this._tbNumberOfCorrectPredictions.ReadOnly = true;
            this._tbNumberOfCorrectPredictions.Size = new System.Drawing.Size(100, 20);
            this._tbNumberOfCorrectPredictions.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Correct";
            // 
            // _tbNumberOfWrongPredictions
            // 
            this._tbNumberOfWrongPredictions.Location = new System.Drawing.Point(154, 150);
            this._tbNumberOfWrongPredictions.Name = "_tbNumberOfWrongPredictions";
            this._tbNumberOfWrongPredictions.ReadOnly = true;
            this._tbNumberOfWrongPredictions.Size = new System.Drawing.Size(100, 20);
            this._tbNumberOfWrongPredictions.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wrong";
            // 
            // _tbOutput
            // 
            this._tbOutput.Location = new System.Drawing.Point(285, 42);
            this._tbOutput.Multiline = true;
            this._tbOutput.Name = "_tbOutput";
            this._tbOutput.ReadOnly = true;
            this._tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._tbOutput.Size = new System.Drawing.Size(302, 184);
            this._tbOutput.TabIndex = 85;
            // 
            // MemoryLearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 264);
            this.Controls.Add(this._tbOutput);
            this.Controls.Add(this._tbNumberOfWrongPredictions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbNumberOfCorrectPredictions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbNumberOfRacesForTesting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbNumberOfRacesForTraining);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonLoad);
            this.Name = "MemoryLearningForm";
            this.Text = "MemoryLearningForm";
            this.Load += new System.EventHandler(this.MemoryLearningForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbNumberOfRacesForTraining;
        private System.Windows.Forms.TextBox _tbNumberOfRacesForTesting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbNumberOfCorrectPredictions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbNumberOfWrongPredictions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbOutput;
    }
}