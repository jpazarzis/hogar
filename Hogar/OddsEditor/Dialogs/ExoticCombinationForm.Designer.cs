namespace OddsEditor.Dialogs
{
    partial class ExoticCombinationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._gridExoticCombination = new System.Windows.Forms.DataGridView();
            this._gridSelectedExoticCombinations = new System.Windows.Forms.DataGridView();
            this._labelRaceTrack = new System.Windows.Forms.Label();
            this._txtboxAmountNeeded = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtboxAmountToWin = new System.Windows.Forms.TextBox();
            this._txtboxReturn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this._txtboxRoundedAmountNeeded = new System.Windows.Forms.TextBox();
            this._buttonSelectAll = new System.Windows.Forms.Button();
            this._buttonUnselectAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._txtboxNumberOfCombinations = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._gridExoticCombination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSelectedExoticCombinations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gridExoticCombination
            // 
            this._gridExoticCombination.AllowUserToAddRows = false;
            this._gridExoticCombination.AllowUserToDeleteRows = false;
            this._gridExoticCombination.AllowUserToResizeColumns = false;
            this._gridExoticCombination.AllowUserToResizeRows = false;
            this._gridExoticCombination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridExoticCombination.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridExoticCombination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridExoticCombination.DefaultCellStyle = dataGridViewCellStyle1;
            this._gridExoticCombination.Location = new System.Drawing.Point(12, 54);
            this._gridExoticCombination.MultiSelect = false;
            this._gridExoticCombination.Name = "_gridExoticCombination";
            this._gridExoticCombination.ReadOnly = true;
            this._gridExoticCombination.RowHeadersWidth = 50;
            this._gridExoticCombination.RowTemplate.Height = 40;
            this._gridExoticCombination.Size = new System.Drawing.Size(690, 697);
            this._gridExoticCombination.TabIndex = 0;
            this._gridExoticCombination.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnExactaGridCellClick);
            // 
            // _gridSelectedExoticCombinations
            // 
            this._gridSelectedExoticCombinations.AllowUserToAddRows = false;
            this._gridSelectedExoticCombinations.AllowUserToDeleteRows = false;
            this._gridSelectedExoticCombinations.AllowUserToResizeColumns = false;
            this._gridSelectedExoticCombinations.AllowUserToResizeRows = false;
            this._gridSelectedExoticCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridSelectedExoticCombinations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridSelectedExoticCombinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridSelectedExoticCombinations.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridSelectedExoticCombinations.Location = new System.Drawing.Point(721, 148);
            this._gridSelectedExoticCombinations.Name = "_gridSelectedExoticCombinations";
            this._gridSelectedExoticCombinations.ReadOnly = true;
            this._gridSelectedExoticCombinations.RowHeadersVisible = false;
            this._gridSelectedExoticCombinations.RowTemplate.Height = 39;
            this._gridSelectedExoticCombinations.Size = new System.Drawing.Size(482, 603);
            this._gridSelectedExoticCombinations.TabIndex = 3;
            // 
            // _labelRaceTrack
            // 
            this._labelRaceTrack.AutoSize = true;
            this._labelRaceTrack.BackColor = System.Drawing.Color.RoyalBlue;
            this._labelRaceTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelRaceTrack.ForeColor = System.Drawing.Color.White;
            this._labelRaceTrack.Location = new System.Drawing.Point(24, 13);
            this._labelRaceTrack.Name = "_labelRaceTrack";
            this._labelRaceTrack.Size = new System.Drawing.Size(100, 24);
            this._labelRaceTrack.TabIndex = 10;
            this._labelRaceTrack.Text = "Aqueduct";
            // 
            // _txtboxAmountNeeded
            // 
            this._txtboxAmountNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxAmountNeeded.Location = new System.Drawing.Point(114, 62);
            this._txtboxAmountNeeded.Name = "_txtboxAmountNeeded";
            this._txtboxAmountNeeded.ReadOnly = true;
            this._txtboxAmountNeeded.Size = new System.Drawing.Size(100, 26);
            this._txtboxAmountNeeded.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Return";
            // 
            // _txtboxAmountToWin
            // 
            this._txtboxAmountToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxAmountToWin.Location = new System.Drawing.Point(114, 29);
            this._txtboxAmountToWin.Name = "_txtboxAmountToWin";
            this._txtboxAmountToWin.Size = new System.Drawing.Size(100, 26);
            this._txtboxAmountToWin.TabIndex = 5;
            // 
            // _txtboxReturn
            // 
            this._txtboxReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxReturn.Location = new System.Drawing.Point(114, 97);
            this._txtboxReturn.Name = "_txtboxReturn";
            this._txtboxReturn.ReadOnly = true;
            this._txtboxReturn.Size = new System.Drawing.Size(100, 26);
            this._txtboxReturn.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Amount To Win";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Amount Needed";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._txtboxNumberOfCombinations);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._txtboxRoundedAmountNeeded);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._txtboxReturn);
            this.groupBox1.Controls.Add(this._txtboxAmountToWin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._txtboxAmountNeeded);
            this.groupBox1.Location = new System.Drawing.Point(722, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 129);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rounded Amount";
            // 
            // _txtboxRoundedAmountNeeded
            // 
            this._txtboxRoundedAmountNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxRoundedAmountNeeded.Location = new System.Drawing.Point(320, 57);
            this._txtboxRoundedAmountNeeded.Name = "_txtboxRoundedAmountNeeded";
            this._txtboxRoundedAmountNeeded.ReadOnly = true;
            this._txtboxRoundedAmountNeeded.Size = new System.Drawing.Size(100, 26);
            this._txtboxRoundedAmountNeeded.TabIndex = 11;
            // 
            // _buttonSelectAll
            // 
            this._buttonSelectAll.Location = new System.Drawing.Point(397, 12);
            this._buttonSelectAll.Name = "_buttonSelectAll";
            this._buttonSelectAll.Size = new System.Drawing.Size(75, 23);
            this._buttonSelectAll.TabIndex = 12;
            this._buttonSelectAll.Text = "Select All";
            this._buttonSelectAll.UseVisualStyleBackColor = true;
            this._buttonSelectAll.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // _buttonUnselectAll
            // 
            this._buttonUnselectAll.Location = new System.Drawing.Point(478, 12);
            this._buttonUnselectAll.Name = "_buttonUnselectAll";
            this._buttonUnselectAll.Size = new System.Drawing.Size(75, 23);
            this._buttonUnselectAll.TabIndex = 13;
            this._buttonUnselectAll.Text = "Unselect All";
            this._buttonUnselectAll.UseVisualStyleBackColor = true;
            this._buttonUnselectAll.Click += new System.EventHandler(this.OnUnselectAll);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Combos";
            // 
            // _txtboxNumberOfCombinations
            // 
            this._txtboxNumberOfCombinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxNumberOfCombinations.Location = new System.Drawing.Point(321, 89);
            this._txtboxNumberOfCombinations.Name = "_txtboxNumberOfCombinations";
            this._txtboxNumberOfCombinations.ReadOnly = true;
            this._txtboxNumberOfCombinations.Size = new System.Drawing.Size(100, 26);
            this._txtboxNumberOfCombinations.TabIndex = 13;
            // 
            // ExoticCombinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 763);
            this.Controls.Add(this._buttonUnselectAll);
            this.Controls.Add(this._buttonSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._labelRaceTrack);
            this.Controls.Add(this._gridSelectedExoticCombinations);
            this.Controls.Add(this._gridExoticCombination);
            this.Name = "ExoticCombinationForm";
            this.Text = "ExactaForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExactaForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._gridExoticCombination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSelectedExoticCombinations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _gridExoticCombination;
        private System.Windows.Forms.DataGridView _gridSelectedExoticCombinations;
        private System.Windows.Forms.Label _labelRaceTrack;
        private System.Windows.Forms.TextBox _txtboxAmountNeeded;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtboxAmountToWin;
        private System.Windows.Forms.TextBox _txtboxReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtboxRoundedAmountNeeded;
        private System.Windows.Forms.Button _buttonSelectAll;
        private System.Windows.Forms.Button _buttonUnselectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtboxNumberOfCombinations;
    }
}