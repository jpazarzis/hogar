namespace ExoticStudio.Dialogs
{
    partial class WeightStatisticsForm
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
            this._gridValue = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._gridWeight = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._gridDevelopedValue = new System.Windows.Forms.DataGridView();
            this._gridDevelopedWeight = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._gridValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridWeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevelopedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevelopedWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // _gridValue
            // 
            this._gridValue.AllowUserToAddRows = false;
            this._gridValue.AllowUserToDeleteRows = false;
            this._gridValue.AllowUserToResizeColumns = false;
            this._gridValue.AllowUserToResizeRows = false;
            this._gridValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridValue.Location = new System.Drawing.Point(6, 52);
            this._gridValue.Name = "_gridValue";
            this._gridValue.RowHeadersVisible = false;
            this._gridValue.Size = new System.Drawing.Size(172, 565);
            this._gridValue.TabIndex = 0;
            this._gridValue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridWasClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Weight";
            // 
            // _gridWeight
            // 
            this._gridWeight.AllowUserToAddRows = false;
            this._gridWeight.AllowUserToDeleteRows = false;
            this._gridWeight.AllowUserToResizeColumns = false;
            this._gridWeight.AllowUserToResizeRows = false;
            this._gridWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridWeight.Location = new System.Drawing.Point(190, 52);
            this._gridWeight.Name = "_gridWeight";
            this._gridWeight.RowHeadersVisible = false;
            this._gridWeight.Size = new System.Drawing.Size(172, 565);
            this._gridWeight.TabIndex = 2;
            this._gridWeight.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridWasClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._gridValue);
            this.groupBox1.Controls.Add(this._gridWeight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 637);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full System";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._gridDevelopedValue);
            this.groupBox2.Controls.Add(this._gridDevelopedWeight);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(416, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 637);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Developed System";
            // 
            // _gridDevelopedValue
            // 
            this._gridDevelopedValue.AllowUserToAddRows = false;
            this._gridDevelopedValue.AllowUserToDeleteRows = false;
            this._gridDevelopedValue.AllowUserToResizeColumns = false;
            this._gridDevelopedValue.AllowUserToResizeRows = false;
            this._gridDevelopedValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridDevelopedValue.Location = new System.Drawing.Point(6, 52);
            this._gridDevelopedValue.Name = "_gridDevelopedValue";
            this._gridDevelopedValue.RowHeadersVisible = false;
            this._gridDevelopedValue.Size = new System.Drawing.Size(172, 565);
            this._gridDevelopedValue.TabIndex = 0;
            this._gridDevelopedValue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // _gridDevelopedWeight
            // 
            this._gridDevelopedWeight.AllowUserToAddRows = false;
            this._gridDevelopedWeight.AllowUserToDeleteRows = false;
            this._gridDevelopedWeight.AllowUserToResizeColumns = false;
            this._gridDevelopedWeight.AllowUserToResizeRows = false;
            this._gridDevelopedWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridDevelopedWeight.Location = new System.Drawing.Point(190, 52);
            this._gridDevelopedWeight.Name = "_gridDevelopedWeight";
            this._gridDevelopedWeight.RowHeadersVisible = false;
            this._gridDevelopedWeight.Size = new System.Drawing.Size(172, 565);
            this._gridDevelopedWeight.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Weight";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Value";
            // 
            // WeightStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 655);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "WeightStatisticsForm";
            this.Text = "WeightStatisticsForm";
            this.Load += new System.EventHandler(this.WeightStatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._gridValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridWeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevelopedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDevelopedWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _gridValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _gridWeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView _gridDevelopedValue;
        private System.Windows.Forms.DataGridView _gridDevelopedWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}