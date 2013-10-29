namespace OddsEditor.Dialogs
{
    partial class HorseDetailsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._tbSire = new System.Windows.Forms.TextBox();
            this._tbDam = new System.Windows.Forms.TextBox();
            this._tbTrainer = new System.Windows.Forms.TextBox();
            this._tbProgramNumber = new System.Windows.Forms.TextBox();
            this._tbHorseName = new System.Windows.Forms.TextBox();
            this._tbJockey = new System.Windows.Forms.TextBox();
            this._tbWeight = new System.Windows.Forms.TextBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._rbShowFractionTime = new System.Windows.Forms.RadioButton();
            this._rbShowFractionSpeed = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sire:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tr:";
            // 
            // _tbSire
            // 
            this._tbSire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbSire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSire.Location = new System.Drawing.Point(413, 17);
            this._tbSire.Name = "_tbSire";
            this._tbSire.ReadOnly = true;
            this._tbSire.Size = new System.Drawing.Size(270, 13);
            this._tbSire.TabIndex = 3;
            // 
            // _tbDam
            // 
            this._tbDam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbDam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDam.Location = new System.Drawing.Point(413, 37);
            this._tbDam.Name = "_tbDam";
            this._tbDam.ReadOnly = true;
            this._tbDam.Size = new System.Drawing.Size(270, 13);
            this._tbDam.TabIndex = 4;
            // 
            // _tbTrainer
            // 
            this._tbTrainer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbTrainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrainer.Location = new System.Drawing.Point(413, 57);
            this._tbTrainer.Name = "_tbTrainer";
            this._tbTrainer.ReadOnly = true;
            this._tbTrainer.Size = new System.Drawing.Size(270, 13);
            this._tbTrainer.TabIndex = 5;
            // 
            // _tbProgramNumber
            // 
            this._tbProgramNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbProgramNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbProgramNumber.Location = new System.Drawing.Point(13, 13);
            this._tbProgramNumber.Name = "_tbProgramNumber";
            this._tbProgramNumber.ReadOnly = true;
            this._tbProgramNumber.Size = new System.Drawing.Size(45, 33);
            this._tbProgramNumber.TabIndex = 6;
            // 
            // _tbHorseName
            // 
            this._tbHorseName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbHorseName.Location = new System.Drawing.Point(65, 13);
            this._tbHorseName.Name = "_tbHorseName";
            this._tbHorseName.ReadOnly = true;
            this._tbHorseName.Size = new System.Drawing.Size(238, 22);
            this._tbHorseName.TabIndex = 7;
            // 
            // _tbJockey
            // 
            this._tbJockey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbJockey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbJockey.Location = new System.Drawing.Point(12, 81);
            this._tbJockey.Name = "_tbJockey";
            this._tbJockey.ReadOnly = true;
            this._tbJockey.Size = new System.Drawing.Size(289, 19);
            this._tbJockey.TabIndex = 8;
            // 
            // _tbWeight
            // 
            this._tbWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbWeight.Location = new System.Drawing.Point(746, 39);
            this._tbWeight.Name = "_tbWeight";
            this._tbWeight.Size = new System.Drawing.Size(100, 28);
            this._tbWeight.TabIndex = 9;
            // 
            // _grid
            // 
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Location = new System.Drawing.Point(13, 139);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.Size = new System.Drawing.Size(1094, 431);
            this._grid.TabIndex = 10;
            // 
            // _rbShowFractionTime
            // 
            this._rbShowFractionTime.AutoSize = true;
            this._rbShowFractionTime.Checked = true;
            this._rbShowFractionTime.Location = new System.Drawing.Point(944, 13);
            this._rbShowFractionTime.Name = "_rbShowFractionTime";
            this._rbShowFractionTime.Size = new System.Drawing.Size(119, 17);
            this._rbShowFractionTime.TabIndex = 11;
            this._rbShowFractionTime.TabStop = true;
            this._rbShowFractionTime.Text = "Show Fraction Time";
            this._rbShowFractionTime.UseVisualStyleBackColor = true;
            this._rbShowFractionTime.CheckedChanged += new System.EventHandler(this.OnShowFractionTime);
            // 
            // _rbShowFractionSpeed
            // 
            this._rbShowFractionSpeed.AutoSize = true;
            this._rbShowFractionSpeed.Location = new System.Drawing.Point(944, 37);
            this._rbShowFractionSpeed.Name = "_rbShowFractionSpeed";
            this._rbShowFractionSpeed.Size = new System.Drawing.Size(127, 17);
            this._rbShowFractionSpeed.TabIndex = 12;
            this._rbShowFractionSpeed.Text = "Show Fraction Speed";
            this._rbShowFractionSpeed.UseVisualStyleBackColor = true;
            this._rbShowFractionSpeed.CheckedChanged += new System.EventHandler(this.OnShowFractionSpeed);
            // 
            // HorseDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1119, 582);
            this.Controls.Add(this._rbShowFractionSpeed);
            this.Controls.Add(this._rbShowFractionTime);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._tbWeight);
            this.Controls.Add(this._tbJockey);
            this.Controls.Add(this._tbHorseName);
            this.Controls.Add(this._tbProgramNumber);
            this.Controls.Add(this._tbTrainer);
            this.Controls.Add(this._tbDam);
            this.Controls.Add(this._tbSire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HorseDetailsForm";
            this.Text = "HorseDetailsForm";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbSire;
        private System.Windows.Forms.TextBox _tbDam;
        private System.Windows.Forms.TextBox _tbTrainer;
        private System.Windows.Forms.TextBox _tbProgramNumber;
        private System.Windows.Forms.TextBox _tbHorseName;
        private System.Windows.Forms.TextBox _tbJockey;
        private System.Windows.Forms.TextBox _tbWeight;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.RadioButton _rbShowFractionTime;
        private System.Windows.Forms.RadioButton _rbShowFractionSpeed;
    }
}