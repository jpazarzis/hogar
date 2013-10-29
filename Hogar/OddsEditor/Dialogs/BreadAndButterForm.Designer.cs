namespace OddsEditor.Dialogs
{
    partial class BreadAndButterForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this._gridUsingOnlyWin = new System.Windows.Forms.DataGridView();
            this._cbAmountToWin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbAmountNeeded = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._gridExactasOnly = new System.Windows.Forms.DataGridView();
            this._rateForExactaOnly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._amountNeededForExactaOnly = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._buttonPlaceBetUsingWinAndExactas = new System.Windows.Forms.Button();
            this._buttonPlaceTheBetUsingExactasOnly = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._tbSurfAndTurfRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._tbAmountNeededForSurfAndTurf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._gridSurfAndTurf = new System.Windows.Forms.DataGridView();
            this._buttonClose = new System.Windows.Forms.Button();
            this._tbOddsToWin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._gridUsingOnlyWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridExactasOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSurfAndTurf)).BeginInit();
            this.SuspendLayout();
            // 
            // _gridUsingOnlyWin
            // 
            this._gridUsingOnlyWin.AllowUserToAddRows = false;
            this._gridUsingOnlyWin.AllowUserToDeleteRows = false;
            this._gridUsingOnlyWin.AllowUserToOrderColumns = true;
            this._gridUsingOnlyWin.AllowUserToResizeColumns = false;
            this._gridUsingOnlyWin.AllowUserToResizeRows = false;
            this._gridUsingOnlyWin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridUsingOnlyWin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridUsingOnlyWin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this._gridUsingOnlyWin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridUsingOnlyWin.DefaultCellStyle = dataGridViewCellStyle14;
            this._gridUsingOnlyWin.Location = new System.Drawing.Point(12, 88);
            this._gridUsingOnlyWin.Name = "_gridUsingOnlyWin";
            this._gridUsingOnlyWin.ReadOnly = true;
            this._gridUsingOnlyWin.RowHeadersVisible = false;
            this._gridUsingOnlyWin.RowTemplate.Height = 50;
            this._gridUsingOnlyWin.Size = new System.Drawing.Size(358, 619);
            this._gridUsingOnlyWin.TabIndex = 0;
            // 
            // _cbAmountToWin
            // 
            this._cbAmountToWin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbAmountToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbAmountToWin.FormattingEnabled = true;
            this._cbAmountToWin.Location = new System.Drawing.Point(1203, 40);
            this._cbAmountToWin.Name = "_cbAmountToWin";
            this._cbAmountToWin.Size = new System.Drawing.Size(121, 28);
            this._cbAmountToWin.TabIndex = 1;
            this._cbAmountToWin.SelectedValueChanged += new System.EventHandler(this.OnAmountToWinChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Amount Needed";
            // 
            // _tbAmountNeeded
            // 
            this._tbAmountNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAmountNeeded.Location = new System.Drawing.Point(23, 38);
            this._tbAmountNeeded.Name = "_tbAmountNeeded";
            this._tbAmountNeeded.ReadOnly = true;
            this._tbAmountNeeded.Size = new System.Drawing.Size(121, 26);
            this._tbAmountNeeded.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1240, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "AmounToWin";
            // 
            // _tbRate
            // 
            this._tbRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbRate.Location = new System.Drawing.Point(203, 40);
            this._tbRate.Name = "_tbRate";
            this._tbRate.ReadOnly = true;
            this._tbRate.Size = new System.Drawing.Size(54, 26);
            this._tbRate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rate";
            // 
            // _gridExactasOnly
            // 
            this._gridExactasOnly.AllowUserToAddRows = false;
            this._gridExactasOnly.AllowUserToDeleteRows = false;
            this._gridExactasOnly.AllowUserToOrderColumns = true;
            this._gridExactasOnly.AllowUserToResizeColumns = false;
            this._gridExactasOnly.AllowUserToResizeRows = false;
            this._gridExactasOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridExactasOnly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridExactasOnly.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this._gridExactasOnly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridExactasOnly.DefaultCellStyle = dataGridViewCellStyle16;
            this._gridExactasOnly.Location = new System.Drawing.Point(442, 88);
            this._gridExactasOnly.Name = "_gridExactasOnly";
            this._gridExactasOnly.ReadOnly = true;
            this._gridExactasOnly.RowHeadersVisible = false;
            this._gridExactasOnly.RowTemplate.Height = 50;
            this._gridExactasOnly.Size = new System.Drawing.Size(358, 619);
            this._gridExactasOnly.TabIndex = 7;
            // 
            // _rateForExactaOnly
            // 
            this._rateForExactaOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rateForExactaOnly.Location = new System.Drawing.Point(641, 40);
            this._rateForExactaOnly.Name = "_rateForExactaOnly";
            this._rateForExactaOnly.ReadOnly = true;
            this._rateForExactaOnly.Size = new System.Drawing.Size(54, 26);
            this._rateForExactaOnly.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rate";
            // 
            // _amountNeededForExactaOnly
            // 
            this._amountNeededForExactaOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._amountNeededForExactaOnly.Location = new System.Drawing.Point(461, 38);
            this._amountNeededForExactaOnly.Name = "_amountNeededForExactaOnly";
            this._amountNeededForExactaOnly.ReadOnly = true;
            this._amountNeededForExactaOnly.Size = new System.Drawing.Size(121, 26);
            this._amountNeededForExactaOnly.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Amount Needed";
            // 
            // _buttonPlaceBetUsingWinAndExactas
            // 
            this._buttonPlaceBetUsingWinAndExactas.Location = new System.Drawing.Point(295, 12);
            this._buttonPlaceBetUsingWinAndExactas.Name = "_buttonPlaceBetUsingWinAndExactas";
            this._buttonPlaceBetUsingWinAndExactas.Size = new System.Drawing.Size(75, 56);
            this._buttonPlaceBetUsingWinAndExactas.TabIndex = 12;
            this._buttonPlaceBetUsingWinAndExactas.Text = "Place The Bet";
            this._buttonPlaceBetUsingWinAndExactas.UseVisualStyleBackColor = true;
            this._buttonPlaceBetUsingWinAndExactas.Click += new System.EventHandler(this._buttonPlaceBetUsingWinAndExactas_Click);
            // 
            // _buttonPlaceTheBetUsingExactasOnly
            // 
            this._buttonPlaceTheBetUsingExactasOnly.Location = new System.Drawing.Point(725, 12);
            this._buttonPlaceTheBetUsingExactasOnly.Name = "_buttonPlaceTheBetUsingExactasOnly";
            this._buttonPlaceTheBetUsingExactasOnly.Size = new System.Drawing.Size(75, 56);
            this._buttonPlaceTheBetUsingExactasOnly.TabIndex = 13;
            this._buttonPlaceTheBetUsingExactasOnly.Text = "Place The Bet";
            this._buttonPlaceTheBetUsingExactasOnly.UseVisualStyleBackColor = true;
            this._buttonPlaceTheBetUsingExactasOnly.Click += new System.EventHandler(this._buttonPlaceTheBetUsingExactasOnly_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1107, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 19;
            this.button1.Text = "Place The Bet";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _tbSurfAndTurfRate
            // 
            this._tbSurfAndTurfRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbSurfAndTurfRate.Location = new System.Drawing.Point(1023, 40);
            this._tbSurfAndTurfRate.Name = "_tbSurfAndTurfRate";
            this._tbSurfAndTurfRate.ReadOnly = true;
            this._tbSurfAndTurfRate.Size = new System.Drawing.Size(54, 26);
            this._tbSurfAndTurfRate.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1020, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Rate";
            // 
            // _tbAmountNeededForSurfAndTurf
            // 
            this._tbAmountNeededForSurfAndTurf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbAmountNeededForSurfAndTurf.Location = new System.Drawing.Point(843, 38);
            this._tbAmountNeededForSurfAndTurf.Name = "_tbAmountNeededForSurfAndTurf";
            this._tbAmountNeededForSurfAndTurf.ReadOnly = true;
            this._tbAmountNeededForSurfAndTurf.Size = new System.Drawing.Size(121, 26);
            this._tbAmountNeededForSurfAndTurf.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(840, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total Amount Needed";
            // 
            // _gridSurfAndTurf
            // 
            this._gridSurfAndTurf.AllowUserToAddRows = false;
            this._gridSurfAndTurf.AllowUserToDeleteRows = false;
            this._gridSurfAndTurf.AllowUserToOrderColumns = true;
            this._gridSurfAndTurf.AllowUserToResizeColumns = false;
            this._gridSurfAndTurf.AllowUserToResizeRows = false;
            this._gridSurfAndTurf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._gridSurfAndTurf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridSurfAndTurf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this._gridSurfAndTurf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridSurfAndTurf.DefaultCellStyle = dataGridViewCellStyle18;
            this._gridSurfAndTurf.Location = new System.Drawing.Point(824, 88);
            this._gridSurfAndTurf.Name = "_gridSurfAndTurf";
            this._gridSurfAndTurf.ReadOnly = true;
            this._gridSurfAndTurf.RowHeadersVisible = false;
            this._gridSurfAndTurf.RowTemplate.Height = 50;
            this._gridSurfAndTurf.Size = new System.Drawing.Size(358, 619);
            this._gridSurfAndTurf.TabIndex = 14;
            // 
            // _buttonClose
            // 
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonClose.Location = new System.Drawing.Point(1203, 659);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(121, 48);
            this._buttonClose.TabIndex = 20;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            // 
            // _tbOddsToWin
            // 
            this._tbOddsToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbOddsToWin.Location = new System.Drawing.Point(1217, 115);
            this._tbOddsToWin.Name = "_tbOddsToWin";
            this._tbOddsToWin.ReadOnly = true;
            this._tbOddsToWin.Size = new System.Drawing.Size(80, 38);
            this._tbOddsToWin.TabIndex = 21;
            this._tbOddsToWin.Text = "24-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1203, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Odds To Win Only";
            // 
            // BreadAndButterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 719);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._tbOddsToWin);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._tbSurfAndTurfRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._tbAmountNeededForSurfAndTurf);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._gridSurfAndTurf);
            this.Controls.Add(this._buttonPlaceTheBetUsingExactasOnly);
            this.Controls.Add(this._buttonPlaceBetUsingWinAndExactas);
            this.Controls.Add(this._rateForExactaOnly);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._amountNeededForExactaOnly);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._gridExactasOnly);
            this.Controls.Add(this._tbRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbAmountNeeded);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cbAmountToWin);
            this.Controls.Add(this._gridUsingOnlyWin);
            this.Name = "BreadAndButterForm";
            this.Text = "BreadAndButterForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._gridUsingOnlyWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridExactasOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridSurfAndTurf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _gridUsingOnlyWin;
        private System.Windows.Forms.ComboBox _cbAmountToWin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbAmountNeeded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView _gridExactasOnly;
        private System.Windows.Forms.TextBox _rateForExactaOnly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _amountNeededForExactaOnly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _buttonPlaceBetUsingWinAndExactas;
        private System.Windows.Forms.Button _buttonPlaceTheBetUsingExactasOnly;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox _tbSurfAndTurfRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbAmountNeededForSurfAndTurf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView _gridSurfAndTurf;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.TextBox _tbOddsToWin;
        private System.Windows.Forms.Label label8;
    }
}