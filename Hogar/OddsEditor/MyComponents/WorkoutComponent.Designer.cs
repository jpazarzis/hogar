namespace OddsEditor.MyComponents
{
    partial class WorkoutComponent
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
            this._labelDate = new System.Windows.Forms.Label();
            this._labelRaceTrack = new System.Windows.Forms.Label();
            this._labelDistance = new System.Windows.Forms.Label();
            this._labelTrackCondition = new System.Windows.Forms.Label();
            this._labelTime = new System.Windows.Forms.Label();
            this._labelRank = new System.Windows.Forms.Label();
            this._labelIsBullet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _labelDate
            // 
            this._labelDate.AutoSize = true;
            this._labelDate.Location = new System.Drawing.Point(3, 0);
            this._labelDate.Name = "_labelDate";
            this._labelDate.Size = new System.Drawing.Size(40, 13);
            this._labelDate.TabIndex = 0;
            this._labelDate.Text = "Mar 21";
            // 
            // _labelRaceTrack
            // 
            this._labelRaceTrack.AutoSize = true;
            this._labelRaceTrack.Location = new System.Drawing.Point(40, 0);
            this._labelRaceTrack.Name = "_labelRaceTrack";
            this._labelRaceTrack.Size = new System.Drawing.Size(30, 13);
            this._labelRaceTrack.TabIndex = 1;
            this._labelRaceTrack.Text = "AQU";
            // 
            // _labelDistance
            // 
            this._labelDistance.AutoSize = true;
            this._labelDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelDistance.Location = new System.Drawing.Point(71, 0);
            this._labelDistance.Name = "_labelDistance";
            this._labelDistance.Size = new System.Drawing.Size(18, 13);
            this._labelDistance.TabIndex = 2;
            this._labelDistance.Text = "5f";
            // 
            // _labelTrackCondition
            // 
            this._labelTrackCondition.AutoSize = true;
            this._labelTrackCondition.Location = new System.Drawing.Point(84, 0);
            this._labelTrackCondition.Name = "_labelTrackCondition";
            this._labelTrackCondition.Size = new System.Drawing.Size(18, 13);
            this._labelTrackCondition.TabIndex = 3;
            this._labelTrackCondition.Text = "fst";
            // 
            // _labelTime
            // 
            this._labelTime.AutoSize = true;
            this._labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTime.Location = new System.Drawing.Point(111, 1);
            this._labelTime.Name = "_labelTime";
            this._labelTime.Size = new System.Drawing.Size(43, 13);
            this._labelTime.TabIndex = 4;
            this._labelTime.Text = "1:06:1";
            // 
            // _labelRank
            // 
            this._labelRank.AutoSize = true;
            this._labelRank.Location = new System.Drawing.Point(169, 1);
            this._labelRank.Name = "_labelRank";
            this._labelRank.Size = new System.Drawing.Size(30, 13);
            this._labelRank.TabIndex = 5;
            this._labelRank.Text = "3/19";
            // 
            // _labelIsBullet
            // 
            this._labelIsBullet.AutoSize = true;
            this._labelIsBullet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelIsBullet.Location = new System.Drawing.Point(99, 1);
            this._labelIsBullet.Name = "_labelIsBullet";
            this._labelIsBullet.Size = new System.Drawing.Size(14, 16);
            this._labelIsBullet.TabIndex = 6;
            this._labelIsBullet.Text = "*";
            // 
            // WorkoutComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._labelIsBullet);
            this.Controls.Add(this._labelRank);
            this.Controls.Add(this._labelTime);
            this.Controls.Add(this._labelTrackCondition);
            this.Controls.Add(this._labelDistance);
            this.Controls.Add(this._labelRaceTrack);
            this.Controls.Add(this._labelDate);
            this.Name = "WorkoutComponent";
            this.Size = new System.Drawing.Size(208, 15);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelDate;
        private System.Windows.Forms.Label _labelRaceTrack;
        private System.Windows.Forms.Label _labelDistance;
        private System.Windows.Forms.Label _labelTrackCondition;
        private System.Windows.Forms.Label _labelTime;
        private System.Windows.Forms.Label _labelRank;
        private System.Windows.Forms.Label _labelIsBullet;



    }
}
