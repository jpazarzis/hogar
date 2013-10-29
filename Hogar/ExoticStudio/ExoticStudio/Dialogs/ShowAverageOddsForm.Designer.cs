namespace ExoticStudio
{
    partial class ShowAverageOddsForm
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
            this._grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this._totalNumberOfCombinationsTextBox = new System.Windows.Forms.TextBox();
            this._frequencyGraphControl = new ExoticStudio.UserControls.FrequencyGraph();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 42);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.Size = new System.Drawing.Size(158, 319);
            this._grid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total";
            // 
            // _totalNumberOfCombinationsTextBox
            // 
            this._totalNumberOfCombinationsTextBox.Location = new System.Drawing.Point(61, 13);
            this._totalNumberOfCombinationsTextBox.Name = "_totalNumberOfCombinationsTextBox";
            this._totalNumberOfCombinationsTextBox.ReadOnly = true;
            this._totalNumberOfCombinationsTextBox.Size = new System.Drawing.Size(109, 20);
            this._totalNumberOfCombinationsTextBox.TabIndex = 2;
            // 
            // _frequencyGraphControl
            // 
            this._frequencyGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._frequencyGraphControl.Location = new System.Drawing.Point(194, 42);
            this._frequencyGraphControl.Name = "_frequencyGraphControl";
            this._frequencyGraphControl.Size = new System.Drawing.Size(305, 319);
            this._frequencyGraphControl.TabIndex = 3;
            // 
            // ShowAverageOddsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 373);
            this.Controls.Add(this._frequencyGraphControl);
            this.Controls.Add(this._totalNumberOfCombinationsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._grid);
            this.Name = "ShowAverageOddsForm";
            this.Text = "ShowAverageOddsForm";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totalNumberOfCombinationsTextBox;
        private ExoticStudio.UserControls.FrequencyGraph _frequencyGraphControl;

    }
}