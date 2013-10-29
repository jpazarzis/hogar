namespace TrackVariantMaint
{
    partial class IntraTrackVariantForm
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
            this._buttonLoadFromDb = new System.Windows.Forms.Button();
            this._tbNumberOfVerticesWithValidVariant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._tbNumberOfHorses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbStdDev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbTotalNumberOfEdges = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbTotalNumberOfVertices = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._buttonAdjustVariant = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this._buttonSaveToDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonLoadFromDb
            // 
            this._buttonLoadFromDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonLoadFromDb.Location = new System.Drawing.Point(39, 29);
            this._buttonLoadFromDb.Name = "_buttonLoadFromDb";
            this._buttonLoadFromDb.Size = new System.Drawing.Size(135, 56);
            this._buttonLoadFromDb.TabIndex = 0;
            this._buttonLoadFromDb.Text = "Load From Db";
            this._buttonLoadFromDb.UseVisualStyleBackColor = true;
            this._buttonLoadFromDb.Click += new System.EventHandler(this._buttonLoadFromDb_Click);
            // 
            // _tbNumberOfVerticesWithValidVariant
            // 
            this._tbNumberOfVerticesWithValidVariant.Location = new System.Drawing.Point(618, 82);
            this._tbNumberOfVerticesWithValidVariant.Name = "_tbNumberOfVerticesWithValidVariant";
            this._tbNumberOfVerticesWithValidVariant.ReadOnly = true;
            this._tbNumberOfVerticesWithValidVariant.Size = new System.Drawing.Size(61, 20);
            this._tbNumberOfVerticesWithValidVariant.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(505, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Vertices with variant";
            // 
            // _tbNumberOfHorses
            // 
            this._tbNumberOfHorses.Location = new System.Drawing.Point(300, 46);
            this._tbNumberOfHorses.Name = "_tbNumberOfHorses";
            this._tbNumberOfHorses.ReadOnly = true;
            this._tbNumberOfHorses.Size = new System.Drawing.Size(61, 20);
            this._tbNumberOfHorses.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "# of Horses";
            // 
            // _tbStdDev
            // 
            this._tbStdDev.Location = new System.Drawing.Point(432, 49);
            this._tbStdDev.Name = "_tbStdDev";
            this._tbStdDev.ReadOnly = true;
            this._tbStdDev.Size = new System.Drawing.Size(61, 20);
            this._tbStdDev.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Stdev";
            // 
            // _tbTotalNumberOfEdges
            // 
            this._tbTotalNumberOfEdges.Location = new System.Drawing.Point(808, 53);
            this._tbTotalNumberOfEdges.Name = "_tbTotalNumberOfEdges";
            this._tbTotalNumberOfEdges.ReadOnly = true;
            this._tbTotalNumberOfEdges.Size = new System.Drawing.Size(61, 20);
            this._tbTotalNumberOfEdges.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(695, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Total # of Edges";
            // 
            // _tbTotalNumberOfVertices
            // 
            this._tbTotalNumberOfVertices.Location = new System.Drawing.Point(618, 49);
            this._tbTotalNumberOfVertices.Name = "_tbTotalNumberOfVertices";
            this._tbTotalNumberOfVertices.ReadOnly = true;
            this._tbTotalNumberOfVertices.Size = new System.Drawing.Size(61, 20);
            this._tbTotalNumberOfVertices.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total # of Vertices";
            // 
            // _buttonAdjustVariant
            // 
            this._buttonAdjustVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonAdjustVariant.Location = new System.Drawing.Point(39, 91);
            this._buttonAdjustVariant.Name = "_buttonAdjustVariant";
            this._buttonAdjustVariant.Size = new System.Drawing.Size(135, 56);
            this._buttonAdjustVariant.TabIndex = 28;
            this._buttonAdjustVariant.Text = "Adjust Variant";
            this._buttonAdjustVariant.UseVisualStyleBackColor = true;
            this._buttonAdjustVariant.Click += new System.EventHandler(this._buttonAdjustVariant_Click);
            // 
            // _grid
            // 
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(39, 230);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(946, 328);
            this._grid.TabIndex = 29;
            // 
            // _buttonSaveToDb
            // 
            this._buttonSaveToDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSaveToDb.Location = new System.Drawing.Point(39, 153);
            this._buttonSaveToDb.Name = "_buttonSaveToDb";
            this._buttonSaveToDb.Size = new System.Drawing.Size(135, 56);
            this._buttonSaveToDb.TabIndex = 30;
            this._buttonSaveToDb.Text = "Save To Db";
            this._buttonSaveToDb.UseVisualStyleBackColor = true;
            this._buttonSaveToDb.Click += new System.EventHandler(this._buttonSaveToDb_Click);
            // 
            // IntraTrackVariantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 590);
            this.Controls.Add(this._buttonSaveToDb);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._buttonAdjustVariant);
            this.Controls.Add(this._tbNumberOfVerticesWithValidVariant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._tbNumberOfHorses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbStdDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbTotalNumberOfEdges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbTotalNumberOfVertices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonLoadFromDb);
            this.Name = "IntraTrackVariantForm";
            this.Text = "Calculate Intra-Track Variant";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonLoadFromDb;
        private System.Windows.Forms.TextBox _tbNumberOfVerticesWithValidVariant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _tbNumberOfHorses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbStdDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbTotalNumberOfEdges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbTotalNumberOfVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _buttonAdjustVariant;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button _buttonSaveToDb;
    }
}