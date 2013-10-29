namespace OddsEditor.Dialogs.SuperStudio
{
    partial class SuperStudioForm
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
            this._grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this._txtboxFullSystemCount = new System.Windows.Forms.TextBox();
            this._txtboxDevelopedSystemCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._gridDevelopedCombinations = new System.Windows.Forms.DataGridView();
            this._buttonShowDevelopedCombos = new System.Windows.Forms.Button();
            this._txtboxEconomy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._txtboxTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevelopedCombinations)).BeginInit();
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
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Location = new System.Drawing.Point(22, 82);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 45;
            this._grid.Size = new System.Drawing.Size(697, 734);
            this._grid.TabIndex = 0;
            this._grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Full System";
            // 
            // _txtboxFullSystemCount
            // 
            this._txtboxFullSystemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxFullSystemCount.Location = new System.Drawing.Point(137, 19);
            this._txtboxFullSystemCount.Name = "_txtboxFullSystemCount";
            this._txtboxFullSystemCount.ReadOnly = true;
            this._txtboxFullSystemCount.Size = new System.Drawing.Size(60, 29);
            this._txtboxFullSystemCount.TabIndex = 3;
            // 
            // _txtboxDevelopedSystemCount
            // 
            this._txtboxDevelopedSystemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxDevelopedSystemCount.Location = new System.Drawing.Point(319, 19);
            this._txtboxDevelopedSystemCount.Name = "_txtboxDevelopedSystemCount";
            this._txtboxDevelopedSystemCount.ReadOnly = true;
            this._txtboxDevelopedSystemCount.Size = new System.Drawing.Size(60, 29);
            this._txtboxDevelopedSystemCount.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Developed";
            // 
            // _gridDevelopedCombinations
            // 
            this._gridDevelopedCombinations.AllowUserToAddRows = false;
            this._gridDevelopedCombinations.AllowUserToDeleteRows = false;
            this._gridDevelopedCombinations.AllowUserToOrderColumns = true;
            this._gridDevelopedCombinations.AllowUserToResizeColumns = false;
            this._gridDevelopedCombinations.AllowUserToResizeRows = false;
            this._gridDevelopedCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridDevelopedCombinations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridDevelopedCombinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridDevelopedCombinations.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridDevelopedCombinations.Location = new System.Drawing.Point(737, 136);
            this._gridDevelopedCombinations.Name = "_gridDevelopedCombinations";
            this._gridDevelopedCombinations.ReadOnly = true;
            this._gridDevelopedCombinations.RowHeadersVisible = false;
            this._gridDevelopedCombinations.RowTemplate.Height = 40;
            this._gridDevelopedCombinations.Size = new System.Drawing.Size(605, 680);
            this._gridDevelopedCombinations.TabIndex = 6;
            // 
            // _buttonShowDevelopedCombos
            // 
            this._buttonShowDevelopedCombos.Location = new System.Drawing.Point(737, 9);
            this._buttonShowDevelopedCombos.Name = "_buttonShowDevelopedCombos";
            this._buttonShowDevelopedCombos.Size = new System.Drawing.Size(605, 54);
            this._buttonShowDevelopedCombos.TabIndex = 8;
            this._buttonShowDevelopedCombos.Text = "Show Developed Combinations";
            this._buttonShowDevelopedCombos.UseVisualStyleBackColor = true;
            this._buttonShowDevelopedCombos.Click += new System.EventHandler(this.OnShowDevelopedCombinations);
            // 
            // _txtboxEconomy
            // 
            this._txtboxEconomy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxEconomy.Location = new System.Drawing.Point(507, 23);
            this._txtboxEconomy.Name = "_txtboxEconomy";
            this._txtboxEconomy.ReadOnly = true;
            this._txtboxEconomy.Size = new System.Drawing.Size(90, 29);
            this._txtboxEconomy.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Economy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(768, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total";
            // 
            // _txtboxTotal
            // 
            this._txtboxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxTotal.Location = new System.Drawing.Point(819, 85);
            this._txtboxTotal.Name = "_txtboxTotal";
            this._txtboxTotal.ReadOnly = true;
            this._txtboxTotal.Size = new System.Drawing.Size(90, 29);
            this._txtboxTotal.TabIndex = 12;
            // 
            // SuperStudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 828);
            this.Controls.Add(this._txtboxTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._txtboxEconomy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._buttonShowDevelopedCombos);
            this.Controls.Add(this._gridDevelopedCombinations);
            this.Controls.Add(this._txtboxDevelopedSystemCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtboxFullSystemCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._grid);
            this.Name = "SuperStudioForm";
            this.Text = "SuperStudioForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevelopedCombinations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtboxFullSystemCount;
        private System.Windows.Forms.TextBox _txtboxDevelopedSystemCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _gridDevelopedCombinations;
        private System.Windows.Forms.Button _buttonShowDevelopedCombos;
        private System.Windows.Forms.TextBox _txtboxEconomy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtboxTotal;
        
    }
}