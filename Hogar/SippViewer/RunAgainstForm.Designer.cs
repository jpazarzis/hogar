namespace SippViewer
{
    partial class RunAgainstForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._gridPP = new System.Windows.Forms.DataGridView();
            this._txtboxTrack = new System.Windows.Forms.TextBox();
            this._tbDate = new System.Windows.Forms.TextBox();
            this._tbRaceNumber = new System.Windows.Forms.TextBox();
            this._tbSurface = new System.Windows.Forms.TextBox();
            this._tbCondition = new System.Windows.Forms.TextBox();
            this._tbDistance = new System.Windows.Forms.TextBox();
            this._tbRaceClassification = new System.Windows.Forms.TextBox();
            this._tbFirstCall = new System.Windows.Forms.TextBox();
            this._tbSecondCall = new System.Windows.Forms.TextBox();
            this._tbThirdCall = new System.Windows.Forms.TextBox();
            this._tbFinalTime = new System.Windows.Forms.TextBox();
            this._tbTrackVariant = new System.Windows.Forms.TextBox();
            this._tbPastPerformancesHeader = new System.Windows.Forms.TextBox();
            this._buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._gridPP)).BeginInit();
            this.SuspendLayout();
            // 
            // _gridPP
            // 
            this._gridPP.AllowUserToAddRows = false;
            this._gridPP.AllowUserToDeleteRows = false;
            this._gridPP.AllowUserToOrderColumns = true;
            this._gridPP.AllowUserToResizeColumns = false;
            this._gridPP.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Andale Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridPP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._gridPP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this._gridPP.BackgroundColor = System.Drawing.Color.SeaShell;
            this._gridPP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridPP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._gridPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridPP.ColumnHeadersVisible = false;
            this._gridPP.Cursor = System.Windows.Forms.Cursors.Hand;
            this._gridPP.DefaultCellStyle = dataGridViewCellStyle4;
            this._gridPP.GridColor = System.Drawing.SystemColors.Window;
            this._gridPP.Location = new System.Drawing.Point(14, 106);
            this._gridPP.MultiSelect = false;
            this._gridPP.Name = "_gridPP";
            this._gridPP.ReadOnly = true;
            this._gridPP.RowHeadersVisible = false;
            this._gridPP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridPP.Size = new System.Drawing.Size(654, 203);
            this._gridPP.TabIndex = 3;
            this._gridPP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._gridPP_CellFormatting);
            // 
            // _txtboxTrack
            // 
            this._txtboxTrack.BackColor = System.Drawing.Color.SeaShell;
            this._txtboxTrack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtboxTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTrack.Location = new System.Drawing.Point(152, 12);
            this._txtboxTrack.Name = "_txtboxTrack";
            this._txtboxTrack.ReadOnly = true;
            this._txtboxTrack.Size = new System.Drawing.Size(42, 13);
            this._txtboxTrack.TabIndex = 85;
            this._txtboxTrack.Text = "BEL";
            this._txtboxTrack.TextChanged += new System.EventHandler(this._txtboxTrack_TextChanged);
            // 
            // _tbDate
            // 
            this._tbDate.BackColor = System.Drawing.Color.SeaShell;
            this._tbDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDate.Location = new System.Drawing.Point(24, 12);
            this._tbDate.Name = "_tbDate";
            this._tbDate.ReadOnly = true;
            this._tbDate.Size = new System.Drawing.Size(83, 13);
            this._tbDate.TabIndex = 87;
            this._tbDate.Text = "02/20/2011";
            // 
            // _tbRaceNumber
            // 
            this._tbRaceNumber.BackColor = System.Drawing.Color.SeaShell;
            this._tbRaceNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbRaceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbRaceNumber.Location = new System.Drawing.Point(113, 12);
            this._tbRaceNumber.Name = "_tbRaceNumber";
            this._tbRaceNumber.ReadOnly = true;
            this._tbRaceNumber.Size = new System.Drawing.Size(33, 13);
            this._tbRaceNumber.TabIndex = 89;
            this._tbRaceNumber.Text = "12";
            // 
            // _tbSurface
            // 
            this._tbSurface.BackColor = System.Drawing.Color.SeaShell;
            this._tbSurface.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSurface.Location = new System.Drawing.Point(308, 12);
            this._tbSurface.Name = "_tbSurface";
            this._tbSurface.ReadOnly = true;
            this._tbSurface.Size = new System.Drawing.Size(33, 13);
            this._tbSurface.TabIndex = 91;
            this._tbSurface.Text = "T";
            // 
            // _tbCondition
            // 
            this._tbCondition.BackColor = System.Drawing.Color.SeaShell;
            this._tbCondition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbCondition.Location = new System.Drawing.Point(200, 12);
            this._tbCondition.Name = "_tbCondition";
            this._tbCondition.ReadOnly = true;
            this._tbCondition.Size = new System.Drawing.Size(33, 13);
            this._tbCondition.TabIndex = 93;
            this._tbCondition.Text = "ft";
            // 
            // _tbDistance
            // 
            this._tbDistance.BackColor = System.Drawing.Color.SeaShell;
            this._tbDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbDistance.Location = new System.Drawing.Point(251, 12);
            this._tbDistance.Name = "_tbDistance";
            this._tbDistance.ReadOnly = true;
            this._tbDistance.Size = new System.Drawing.Size(48, 13);
            this._tbDistance.TabIndex = 95;
            this._tbDistance.Text = "6f";
            // 
            // _tbRaceClassification
            // 
            this._tbRaceClassification.BackColor = System.Drawing.Color.SeaShell;
            this._tbRaceClassification.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbRaceClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbRaceClassification.Location = new System.Drawing.Point(347, 12);
            this._tbRaceClassification.Name = "_tbRaceClassification";
            this._tbRaceClassification.ReadOnly = true;
            this._tbRaceClassification.Size = new System.Drawing.Size(135, 13);
            this._tbRaceClassification.TabIndex = 97;
            this._tbRaceClassification.Text = "MCL35000";
            // 
            // _tbFirstCall
            // 
            this._tbFirstCall.BackColor = System.Drawing.Color.SeaShell;
            this._tbFirstCall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbFirstCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbFirstCall.Location = new System.Drawing.Point(79, 45);
            this._tbFirstCall.Name = "_tbFirstCall";
            this._tbFirstCall.ReadOnly = true;
            this._tbFirstCall.Size = new System.Drawing.Size(36, 13);
            this._tbFirstCall.TabIndex = 98;
            this._tbFirstCall.Text = ":23";
            // 
            // _tbSecondCall
            // 
            this._tbSecondCall.BackColor = System.Drawing.Color.SeaShell;
            this._tbSecondCall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbSecondCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSecondCall.Location = new System.Drawing.Point(125, 45);
            this._tbSecondCall.Name = "_tbSecondCall";
            this._tbSecondCall.ReadOnly = true;
            this._tbSecondCall.Size = new System.Drawing.Size(36, 13);
            this._tbSecondCall.TabIndex = 99;
            this._tbSecondCall.Text = "1:12:3";
            // 
            // _tbThirdCall
            // 
            this._tbThirdCall.BackColor = System.Drawing.Color.SeaShell;
            this._tbThirdCall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbThirdCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbThirdCall.Location = new System.Drawing.Point(171, 45);
            this._tbThirdCall.Name = "_tbThirdCall";
            this._tbThirdCall.ReadOnly = true;
            this._tbThirdCall.Size = new System.Drawing.Size(36, 13);
            this._tbThirdCall.TabIndex = 100;
            this._tbThirdCall.Text = "1:12:3";
            // 
            // _tbFinalTime
            // 
            this._tbFinalTime.BackColor = System.Drawing.Color.SeaShell;
            this._tbFinalTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbFinalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbFinalTime.Location = new System.Drawing.Point(215, 45);
            this._tbFinalTime.Name = "_tbFinalTime";
            this._tbFinalTime.ReadOnly = true;
            this._tbFinalTime.Size = new System.Drawing.Size(36, 13);
            this._tbFinalTime.TabIndex = 101;
            this._tbFinalTime.Text = "1:12:3";
            // 
            // _tbTrackVariant
            // 
            this._tbTrackVariant.BackColor = System.Drawing.Color.SeaShell;
            this._tbTrackVariant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbTrackVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbTrackVariant.Location = new System.Drawing.Point(388, 45);
            this._tbTrackVariant.Name = "_tbTrackVariant";
            this._tbTrackVariant.ReadOnly = true;
            this._tbTrackVariant.Size = new System.Drawing.Size(33, 13);
            this._tbTrackVariant.TabIndex = 102;
            this._tbTrackVariant.Text = "12";
            // 
            // _tbPastPerformancesHeader
            // 
            this._tbPastPerformancesHeader.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._tbPastPerformancesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbPastPerformancesHeader.ForeColor = System.Drawing.SystemColors.Info;
            this._tbPastPerformancesHeader.Location = new System.Drawing.Point(9, 74);
            this._tbPastPerformancesHeader.Name = "_tbPastPerformancesHeader";
            this._tbPastPerformancesHeader.ReadOnly = true;
            this._tbPastPerformancesHeader.Size = new System.Drawing.Size(663, 26);
            this._tbPastPerformancesHeader.TabIndex = 103;
            this._tbPastPerformancesHeader.Text = "The following Horses from today\' race ran against each other in this race";
            this._tbPastPerformancesHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _buttonClose
            // 
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonClose.Location = new System.Drawing.Point(551, 315);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(113, 38);
            this._buttonClose.TabIndex = 104;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "Fractions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Track Variant";
            // 
            // RunAgainstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(680, 365);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._tbPastPerformancesHeader);
            this.Controls.Add(this._tbTrackVariant);
            this.Controls.Add(this._tbFinalTime);
            this.Controls.Add(this._tbThirdCall);
            this.Controls.Add(this._tbSecondCall);
            this.Controls.Add(this._tbFirstCall);
            this.Controls.Add(this._tbRaceClassification);
            this.Controls.Add(this._tbDistance);
            this.Controls.Add(this._tbCondition);
            this.Controls.Add(this._tbSurface);
            this.Controls.Add(this._tbRaceNumber);
            this.Controls.Add(this._tbDate);
            this.Controls.Add(this._txtboxTrack);
            this.Controls.Add(this._gridPP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunAgainstForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RunAgainstForm";
            this.Load += new System.EventHandler(this.RunAgainstForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._gridPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _gridPP;
        private System.Windows.Forms.TextBox _txtboxTrack;
        private System.Windows.Forms.TextBox _tbDate;
        private System.Windows.Forms.TextBox _tbRaceNumber;
        private System.Windows.Forms.TextBox _tbSurface;
        private System.Windows.Forms.TextBox _tbCondition;
        private System.Windows.Forms.TextBox _tbDistance;
        private System.Windows.Forms.TextBox _tbRaceClassification;
        private System.Windows.Forms.TextBox _tbFirstCall;
        private System.Windows.Forms.TextBox _tbSecondCall;
        private System.Windows.Forms.TextBox _tbThirdCall;
        private System.Windows.Forms.TextBox _tbFinalTime;
        private System.Windows.Forms.TextBox _tbTrackVariant;
        private System.Windows.Forms.TextBox _tbPastPerformancesHeader;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}