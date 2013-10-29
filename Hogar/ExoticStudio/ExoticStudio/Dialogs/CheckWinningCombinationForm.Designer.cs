namespace ExoticStudio
{
    partial class CheckWinningCombinationForm
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
            this._winningComboGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._selectWinnersButton = new System.Windows.Forms.Button();
            this._matchesTextBox = new System.Windows.Forms.TextBox();
            this._btnShowAllMatches = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this._tbMatchesCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._winningComboGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _winningComboGrid
            // 
            this._winningComboGrid.AllowUserToAddRows = false;
            this._winningComboGrid.AllowUserToDeleteRows = false;
            this._winningComboGrid.AllowUserToOrderColumns = true;
            this._winningComboGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._winningComboGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._winningComboGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._winningComboGrid.Location = new System.Drawing.Point(7, 29);
            this._winningComboGrid.Name = "_winningComboGrid";
            this._winningComboGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this._winningComboGrid.Size = new System.Drawing.Size(150, 239);
            this._winningComboGrid.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._winningComboGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 276);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter the Winning Horses";
            // 
            // _selectWinnersButton
            // 
            this._selectWinnersButton.Location = new System.Drawing.Point(19, 365);
            this._selectWinnersButton.Name = "_selectWinnersButton";
            this._selectWinnersButton.Size = new System.Drawing.Size(79, 34);
            this._selectWinnersButton.TabIndex = 2;
            this._selectWinnersButton.Text = "Select Winners";
            this._selectWinnersButton.UseVisualStyleBackColor = true;
            this._selectWinnersButton.Click += new System.EventHandler(this.OnSelectWinners);
            // 
            // _matchesTextBox
            // 
            this._matchesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._matchesTextBox.Location = new System.Drawing.Point(19, 310);
            this._matchesTextBox.Name = "_matchesTextBox";
            this._matchesTextBox.ReadOnly = true;
            this._matchesTextBox.Size = new System.Drawing.Size(157, 20);
            this._matchesTextBox.TabIndex = 4;
            // 
            // _btnShowAllMatches
            // 
            this._btnShowAllMatches.Location = new System.Drawing.Point(104, 365);
            this._btnShowAllMatches.Name = "_btnShowAllMatches";
            this._btnShowAllMatches.Size = new System.Drawing.Size(86, 34);
            this._btnShowAllMatches.TabIndex = 5;
            this._btnShowAllMatches.Text = "Show All Matches";
            this._btnShowAllMatches.UseVisualStyleBackColor = true;
            this._btnShowAllMatches.Click += new System.EventHandler(this.OnShowAllMatches);
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(195, 41);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(288, 240);
            this._grid.TabIndex = 6;
            // 
            // _tbMatchesCount
            // 
            this._tbMatchesCount.Location = new System.Drawing.Point(424, 309);
            this._tbMatchesCount.Name = "_tbMatchesCount";
            this._tbMatchesCount.ReadOnly = true;
            this._tbMatchesCount.Size = new System.Drawing.Size(59, 20);
            this._tbMatchesCount.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Matching Combinations Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(310, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Note: Use the 0 as a wild selection";
            // 
            // CheckWinningCombinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 417);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbMatchesCount);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._btnShowAllMatches);
            this.Controls.Add(this._matchesTextBox);
            this.Controls.Add(this._selectWinnersButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckWinningCombinationForm";
            this.Text = "CheckWinningCombinationForm";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this._winningComboGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _winningComboGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _selectWinnersButton;
        private System.Windows.Forms.TextBox _matchesTextBox;
        private System.Windows.Forms.Button _btnShowAllMatches;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _tbMatchesCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}