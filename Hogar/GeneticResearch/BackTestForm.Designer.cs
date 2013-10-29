namespace GeneticResearch
{
    partial class BackTestForm
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._cbStartingBankroll = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cbNumberOfRacesToPlay = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._cbMinAdvantage = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._labelFinalBankroll = new System.Windows.Forms.Label();
            this._buttonGo = new System.Windows.Forms.Button();
            this._buttonClose = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._labelNumberOfBets = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._cbStartingBankroll);
            this.groupBox5.Location = new System.Drawing.Point(12, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 60);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Starting Bankroll";
            // 
            // _cbStartingBankroll
            // 
            this._cbStartingBankroll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbStartingBankroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbStartingBankroll.FormattingEnabled = true;
            this._cbStartingBankroll.Location = new System.Drawing.Point(6, 19);
            this._cbStartingBankroll.Name = "_cbStartingBankroll";
            this._cbStartingBankroll.Size = new System.Drawing.Size(93, 33);
            this._cbStartingBankroll.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cbNumberOfRacesToPlay);
            this.groupBox1.Location = new System.Drawing.Point(155, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 60);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Races To Play";
            // 
            // _cbNumberOfRacesToPlay
            // 
            this._cbNumberOfRacesToPlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbNumberOfRacesToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbNumberOfRacesToPlay.FormattingEnabled = true;
            this._cbNumberOfRacesToPlay.Location = new System.Drawing.Point(6, 19);
            this._cbNumberOfRacesToPlay.Name = "_cbNumberOfRacesToPlay";
            this._cbNumberOfRacesToPlay.Size = new System.Drawing.Size(93, 33);
            this._cbNumberOfRacesToPlay.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._cbMinAdvantage);
            this.groupBox2.Location = new System.Drawing.Point(286, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 60);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Min Advantage ";
            // 
            // _cbMinAdvantage
            // 
            this._cbMinAdvantage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbMinAdvantage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbMinAdvantage.FormattingEnabled = true;
            this._cbMinAdvantage.Location = new System.Drawing.Point(6, 19);
            this._cbMinAdvantage.Name = "_cbMinAdvantage";
            this._cbMinAdvantage.Size = new System.Drawing.Size(93, 33);
            this._cbMinAdvantage.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._labelFinalBankroll);
            this.groupBox3.Location = new System.Drawing.Point(409, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 60);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Final Bankroll";
            // 
            // _labelFinalBankroll
            // 
            this._labelFinalBankroll.AutoSize = true;
            this._labelFinalBankroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this._labelFinalBankroll.Location = new System.Drawing.Point(7, 20);
            this._labelFinalBankroll.Name = "_labelFinalBankroll";
            this._labelFinalBankroll.Size = new System.Drawing.Size(77, 25);
            this._labelFinalBankroll.TabIndex = 0;
            this._labelFinalBankroll.Text = "10000";
            // 
            // _buttonGo
            // 
            this._buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonGo.Location = new System.Drawing.Point(13, 209);
            this._buttonGo.Name = "_buttonGo";
            this._buttonGo.Size = new System.Drawing.Size(131, 55);
            this._buttonGo.TabIndex = 17;
            this._buttonGo.Text = "Go";
            this._buttonGo.UseVisualStyleBackColor = true;
            this._buttonGo.Click += new System.EventHandler(this.OnGo);
            // 
            // _buttonClose
            // 
            this._buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonClose.Location = new System.Drawing.Point(172, 209);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(131, 55);
            this._buttonClose.TabIndex = 18;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.OnClose);
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.ColumnHeadersVisible = false;
            this._grid.Location = new System.Drawing.Point(18, 116);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(739, 56);
            this._grid.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._labelNumberOfBets);
            this.groupBox4.Location = new System.Drawing.Point(547, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(111, 60);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Number Of Bets";
            // 
            // _labelNumberOfBets
            // 
            this._labelNumberOfBets.AutoSize = true;
            this._labelNumberOfBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this._labelNumberOfBets.Location = new System.Drawing.Point(7, 20);
            this._labelNumberOfBets.Name = "_labelNumberOfBets";
            this._labelNumberOfBets.Size = new System.Drawing.Size(77, 25);
            this._labelNumberOfBets.TabIndex = 0;
            this._labelNumberOfBets.Text = "10000";
            // 
            // BackTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 272);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._buttonGo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackTestForm";
            this.ShowIcon = false;
            this.Text = "BackTestForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox _cbStartingBankroll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _cbNumberOfRacesToPlay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox _cbMinAdvantage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label _labelFinalBankroll;
        private System.Windows.Forms.Button _buttonGo;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label _labelNumberOfBets;
    }
}