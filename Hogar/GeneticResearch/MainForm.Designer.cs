namespace GeneticResearch
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
            this._buttonGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._tbFitness = new System.Windows.Forms.TextBox();
            this._tbGenerationCount = new System.Windows.Forms.TextBox();
            this._buttonSaveToDb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cbPopulationSize = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._cbMaxNumberOfGenerations = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._cbFitnessTarget = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._cbMutationRate = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._cbNUmberOfRacesToLoad = new System.Windows.Forms.ComboBox();
            this._buttonBackTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonGo
            // 
            this._buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonGo.Location = new System.Drawing.Point(35, 4);
            this._buttonGo.Name = "_buttonGo";
            this._buttonGo.Size = new System.Drawing.Size(203, 87);
            this._buttonGo.TabIndex = 0;
            this._buttonGo.Text = "Go";
            this._buttonGo.UseVisualStyleBackColor = true;
            this._buttonGo.Click += new System.EventHandler(this.OnGo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(711, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Best Fitness";
            // 
            // _tbFitness
            // 
            this._tbFitness.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbFitness.Location = new System.Drawing.Point(710, 145);
            this._tbFitness.Name = "_tbFitness";
            this._tbFitness.ReadOnly = true;
            this._tbFitness.Size = new System.Drawing.Size(100, 31);
            this._tbFitness.TabIndex = 2;
            this._tbFitness.Text = "7899.98";
            // 
            // _tbGenerationCount
            // 
            this._tbGenerationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbGenerationCount.Location = new System.Drawing.Point(837, 145);
            this._tbGenerationCount.Name = "_tbGenerationCount";
            this._tbGenerationCount.ReadOnly = true;
            this._tbGenerationCount.Size = new System.Drawing.Size(100, 31);
            this._tbGenerationCount.TabIndex = 4;
            this._tbGenerationCount.Text = "879";
            // 
            // _buttonSaveToDb
            // 
            this._buttonSaveToDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this._buttonSaveToDb.Location = new System.Drawing.Point(288, 4);
            this._buttonSaveToDb.Name = "_buttonSaveToDb";
            this._buttonSaveToDb.Size = new System.Drawing.Size(203, 87);
            this._buttonSaveToDb.TabIndex = 5;
            this._buttonSaveToDb.Text = "Save To Db";
            this._buttonSaveToDb.UseVisualStyleBackColor = true;
            this._buttonSaveToDb.Click += new System.EventHandler(this.OnSaveToDb);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "# of Generation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cbPopulationSize);
            this.groupBox1.Location = new System.Drawing.Point(35, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 60);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Population Size";
            // 
            // _cbPopulationSize
            // 
            this._cbPopulationSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbPopulationSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbPopulationSize.FormattingEnabled = true;
            this._cbPopulationSize.Location = new System.Drawing.Point(6, 19);
            this._cbPopulationSize.Name = "_cbPopulationSize";
            this._cbPopulationSize.Size = new System.Drawing.Size(93, 33);
            this._cbPopulationSize.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._cbMaxNumberOfGenerations);
            this.groupBox2.Location = new System.Drawing.Point(165, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 60);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Max. generations";
            // 
            // _cbMaxNumberOfGenerations
            // 
            this._cbMaxNumberOfGenerations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbMaxNumberOfGenerations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbMaxNumberOfGenerations.FormattingEnabled = true;
            this._cbMaxNumberOfGenerations.Location = new System.Drawing.Point(6, 19);
            this._cbMaxNumberOfGenerations.Name = "_cbMaxNumberOfGenerations";
            this._cbMaxNumberOfGenerations.Size = new System.Drawing.Size(93, 33);
            this._cbMaxNumberOfGenerations.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._cbFitnessTarget);
            this.groupBox3.Location = new System.Drawing.Point(301, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 60);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target";
            // 
            // _cbFitnessTarget
            // 
            this._cbFitnessTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbFitnessTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbFitnessTarget.FormattingEnabled = true;
            this._cbFitnessTarget.Location = new System.Drawing.Point(6, 19);
            this._cbFitnessTarget.Name = "_cbFitnessTarget";
            this._cbFitnessTarget.Size = new System.Drawing.Size(93, 33);
            this._cbFitnessTarget.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._cbMutationRate);
            this.groupBox4.Location = new System.Drawing.Point(431, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(111, 60);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mutation Rate";
            // 
            // _cbMutationRate
            // 
            this._cbMutationRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbMutationRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbMutationRate.FormattingEnabled = true;
            this._cbMutationRate.Location = new System.Drawing.Point(6, 19);
            this._cbMutationRate.Name = "_cbMutationRate";
            this._cbMutationRate.Size = new System.Drawing.Size(93, 33);
            this._cbMutationRate.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._cbNUmberOfRacesToLoad);
            this.groupBox5.Location = new System.Drawing.Point(563, 124);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 60);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Races To Load";
            // 
            // _cbNUmberOfRacesToLoad
            // 
            this._cbNUmberOfRacesToLoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbNUmberOfRacesToLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbNUmberOfRacesToLoad.FormattingEnabled = true;
            this._cbNUmberOfRacesToLoad.Location = new System.Drawing.Point(6, 19);
            this._cbNUmberOfRacesToLoad.Name = "_cbNUmberOfRacesToLoad";
            this._cbNUmberOfRacesToLoad.Size = new System.Drawing.Size(93, 33);
            this._cbNUmberOfRacesToLoad.TabIndex = 8;
            // 
            // _buttonBackTest
            // 
            this._buttonBackTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this._buttonBackTest.Location = new System.Drawing.Point(541, 4);
            this._buttonBackTest.Name = "_buttonBackTest";
            this._buttonBackTest.Size = new System.Drawing.Size(203, 87);
            this._buttonBackTest.TabIndex = 12;
            this._buttonBackTest.Text = "Back Test";
            this._buttonBackTest.UseVisualStyleBackColor = true;
            this._buttonBackTest.Click += new System.EventHandler(this.OnBackTest);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(794, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 87);
            this.button1.TabIndex = 13;
            this.button1.Text = "Back Test DB Solution";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnBacktestDbSolution);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 221);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._buttonBackTest);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._buttonSaveToDb);
            this.Controls.Add(this._tbGenerationCount);
            this.Controls.Add(this._tbFitness);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonGo);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbFitness;
        private System.Windows.Forms.TextBox _tbGenerationCount;
        private System.Windows.Forms.Button _buttonSaveToDb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _cbPopulationSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox _cbMaxNumberOfGenerations;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox _cbFitnessTarget;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox _cbMutationRate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox _cbNUmberOfRacesToLoad;
        private System.Windows.Forms.Button _buttonBackTest;
        private System.Windows.Forms.Button button1;
    }
}

