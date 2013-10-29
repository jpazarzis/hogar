namespace OddsEditor.Dialogs.KeyRacesViewer
{
    partial class KeyRacesForm
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
            this._tbTrackCode = new System.Windows.Forms.TextBox();
            this._tbRaceNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._tbSurface = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbDistance = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._rbGoldenPaceFigure = new System.Windows.Forms.RadioButton();
            this._rbGoldenFigure = new System.Windows.Forms.RadioButton();
            this._rbDaysSince = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Track ";
            // 
            // _tbTrackCode
            // 
            this._tbTrackCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackCode.Location = new System.Drawing.Point(16, 29);
            this._tbTrackCode.Name = "_tbTrackCode";
            this._tbTrackCode.ReadOnly = true;
            this._tbTrackCode.Size = new System.Drawing.Size(69, 35);
            this._tbTrackCode.TabIndex = 1;
            this._tbTrackCode.Text = "AQU";
            // 
            // _tbRaceNumber
            // 
            this._tbRaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbRaceNumber.Location = new System.Drawing.Point(100, 29);
            this._tbRaceNumber.Name = "_tbRaceNumber";
            this._tbRaceNumber.ReadOnly = true;
            this._tbRaceNumber.Size = new System.Drawing.Size(69, 35);
            this._tbRaceNumber.TabIndex = 2;
            this._tbRaceNumber.Text = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Race #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Surface";
            // 
            // _tbSurface
            // 
            this._tbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSurface.Location = new System.Drawing.Point(186, 29);
            this._tbSurface.Name = "_tbSurface";
            this._tbSurface.ReadOnly = true;
            this._tbSurface.Size = new System.Drawing.Size(69, 35);
            this._tbSurface.TabIndex = 4;
            this._tbSurface.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Distance";
            // 
            // _tbDistance
            // 
            this._tbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDistance.Location = new System.Drawing.Point(272, 29);
            this._tbDistance.Name = "_tbDistance";
            this._tbDistance.ReadOnly = true;
            this._tbDistance.Size = new System.Drawing.Size(150, 35);
            this._tbDistance.TabIndex = 6;
            this._tbDistance.Text = "6 Furlongs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rbGoldenPaceFigure);
            this.groupBox1.Controls.Add(this._rbGoldenFigure);
            this.groupBox1.Controls.Add(this._rbDaysSince);
            this.groupBox1.Location = new System.Drawing.Point(648, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 72);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order By";
            // 
            // _rbGoldenPaceFigure
            // 
            this._rbGoldenPaceFigure.AutoSize = true;
            this._rbGoldenPaceFigure.Location = new System.Drawing.Point(239, 30);
            this._rbGoldenPaceFigure.Name = "_rbGoldenPaceFigure";
            this._rbGoldenPaceFigure.Size = new System.Drawing.Size(119, 17);
            this._rbGoldenPaceFigure.TabIndex = 2;
            this._rbGoldenPaceFigure.Text = "Golden Pace Figure";
            this._rbGoldenPaceFigure.UseVisualStyleBackColor = true;
            this._rbGoldenPaceFigure.CheckedChanged += new System.EventHandler(this._rbGoldenPaceFigure_CheckedChanged);
            // 
            // _rbGoldenFigure
            // 
            this._rbGoldenFigure.AutoSize = true;
            this._rbGoldenFigure.Location = new System.Drawing.Point(127, 30);
            this._rbGoldenFigure.Name = "_rbGoldenFigure";
            this._rbGoldenFigure.Size = new System.Drawing.Size(91, 17);
            this._rbGoldenFigure.TabIndex = 1;
            this._rbGoldenFigure.Text = "Golden Figure";
            this._rbGoldenFigure.UseVisualStyleBackColor = true;
            this._rbGoldenFigure.CheckedChanged += new System.EventHandler(this._rbGoldenPaceFigure_CheckedChanged);
            // 
            // _rbDaysSince
            // 
            this._rbDaysSince.AutoSize = true;
            this._rbDaysSince.Checked = true;
            this._rbDaysSince.Location = new System.Drawing.Point(25, 30);
            this._rbDaysSince.Name = "_rbDaysSince";
            this._rbDaysSince.Size = new System.Drawing.Size(79, 17);
            this._rbDaysSince.TabIndex = 0;
            this._rbDaysSince.TabStop = true;
            this._rbDaysSince.Text = "Days Since";
            this._rbDaysSince.UseVisualStyleBackColor = true;
            this._rbDaysSince.CheckedChanged += new System.EventHandler(this._rbGoldenPaceFigure_CheckedChanged);
            // 
            // KeyRacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1049, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbSurface);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbRaceNumber);
            this.Controls.Add(this._tbTrackCode);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "KeyRacesForm";
            this.Text = "KeyRacesForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KeyRacesForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.KeyRacesForm_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbTrackCode;
        private System.Windows.Forms.TextBox _tbRaceNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbSurface;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbDistance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _rbGoldenPaceFigure;
        private System.Windows.Forms.RadioButton _rbGoldenFigure;
        private System.Windows.Forms.RadioButton _rbDaysSince;

    }
}