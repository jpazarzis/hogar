namespace TrackVariantMaint
{
    partial class TrackVariantForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._tbTotalNumberOfVertices = new System.Windows.Forms.TextBox();
            this._tbTotalNumberOfEdges = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonLoadVariant = new System.Windows.Forms.Button();
            this._gridVariant = new System.Windows.Forms.DataGridView();
            this._tbStdDev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._buttonNormalize = new System.Windows.Forms.Button();
            this._tbNumberOfHorses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._tbNumberOfVerticesWithValidVariant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._cbLoadingMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._buttonSaveToDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._gridVariant)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(665, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total # of Vertices";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // _tbTotalNumberOfVertices
            // 
            this._tbTotalNumberOfVertices.Location = new System.Drawing.Point(778, 30);
            this._tbTotalNumberOfVertices.Name = "_tbTotalNumberOfVertices";
            this._tbTotalNumberOfVertices.ReadOnly = true;
            this._tbTotalNumberOfVertices.Size = new System.Drawing.Size(61, 20);
            this._tbTotalNumberOfVertices.TabIndex = 3;
            // 
            // _tbTotalNumberOfEdges
            // 
            this._tbTotalNumberOfEdges.Location = new System.Drawing.Point(968, 34);
            this._tbTotalNumberOfEdges.Name = "_tbTotalNumberOfEdges";
            this._tbTotalNumberOfEdges.ReadOnly = true;
            this._tbTotalNumberOfEdges.Size = new System.Drawing.Size(61, 20);
            this._tbTotalNumberOfEdges.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(855, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total # of Edges";
            // 
            // _buttonLoadVariant
            // 
            this._buttonLoadVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonLoadVariant.Location = new System.Drawing.Point(13, 14);
            this._buttonLoadVariant.Name = "_buttonLoadVariant";
            this._buttonLoadVariant.Size = new System.Drawing.Size(110, 37);
            this._buttonLoadVariant.TabIndex = 7;
            this._buttonLoadVariant.Text = "Adjust";
            this._buttonLoadVariant.UseVisualStyleBackColor = true;
            this._buttonLoadVariant.Click += new System.EventHandler(this._buttonLoadVariant_Click);
            // 
            // _gridVariant
            // 
            this._gridVariant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridVariant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridVariant.Location = new System.Drawing.Point(21, 99);
            this._gridVariant.Name = "_gridVariant";
            this._gridVariant.Size = new System.Drawing.Size(1288, 627);
            this._gridVariant.TabIndex = 9;
            // 
            // _tbStdDev
            // 
            this._tbStdDev.Location = new System.Drawing.Point(592, 30);
            this._tbStdDev.Name = "_tbStdDev";
            this._tbStdDev.ReadOnly = true;
            this._tbStdDev.Size = new System.Drawing.Size(61, 20);
            this._tbStdDev.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stdev";
            // 
            // _buttonNormalize
            // 
            this._buttonNormalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonNormalize.Location = new System.Drawing.Point(129, 14);
            this._buttonNormalize.Name = "_buttonNormalize";
            this._buttonNormalize.Size = new System.Drawing.Size(110, 37);
            this._buttonNormalize.TabIndex = 13;
            this._buttonNormalize.Text = "Normalize";
            this._buttonNormalize.UseVisualStyleBackColor = true;
            this._buttonNormalize.Click += new System.EventHandler(this._buttonNormalize_Click);
            // 
            // _tbNumberOfHorses
            // 
            this._tbNumberOfHorses.Location = new System.Drawing.Point(460, 27);
            this._tbNumberOfHorses.Name = "_tbNumberOfHorses";
            this._tbNumberOfHorses.ReadOnly = true;
            this._tbNumberOfHorses.Size = new System.Drawing.Size(61, 20);
            this._tbNumberOfHorses.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "# of Horses";
            // 
            // _tbNumberOfVerticesWithValidVariant
            // 
            this._tbNumberOfVerticesWithValidVariant.Location = new System.Drawing.Point(778, 63);
            this._tbNumberOfVerticesWithValidVariant.Name = "_tbNumberOfVerticesWithValidVariant";
            this._tbNumberOfVerticesWithValidVariant.ReadOnly = true;
            this._tbNumberOfVerticesWithValidVariant.Size = new System.Drawing.Size(61, 20);
            this._tbNumberOfVerticesWithValidVariant.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Vertices with variant";
            // 
            // _cbLoadingMethod
            // 
            this._cbLoadingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbLoadingMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbLoadingMethod.FormattingEnabled = true;
            this._cbLoadingMethod.Location = new System.Drawing.Point(1060, 48);
            this._cbLoadingMethod.Name = "_cbLoadingMethod";
            this._cbLoadingMethod.Size = new System.Drawing.Size(183, 28);
            this._cbLoadingMethod.TabIndex = 18;
            this._cbLoadingMethod.SelectedIndexChanged += new System.EventHandler(this._cbLoadingMethod_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1057, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Loading Method";
            // 
            // _buttonSaveToDb
            // 
            this._buttonSaveToDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSaveToDb.Location = new System.Drawing.Point(245, 14);
            this._buttonSaveToDb.Name = "_buttonSaveToDb";
            this._buttonSaveToDb.Size = new System.Drawing.Size(110, 37);
            this._buttonSaveToDb.TabIndex = 20;
            this._buttonSaveToDb.Text = "Save To Db";
            this._buttonSaveToDb.UseVisualStyleBackColor = true;
            this._buttonSaveToDb.Click += new System.EventHandler(this.OnSaveVariantToDb);
            // 
            // TrackVariantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 757);
            this.Controls.Add(this._buttonSaveToDb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._cbLoadingMethod);
            this.Controls.Add(this._tbNumberOfVerticesWithValidVariant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._tbNumberOfHorses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._buttonNormalize);
            this.Controls.Add(this._tbStdDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._gridVariant);
            this.Controls.Add(this._buttonLoadVariant);
            this.Controls.Add(this._tbTotalNumberOfEdges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbTotalNumberOfVertices);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "TrackVariantForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._gridVariant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbTotalNumberOfVertices;
        private System.Windows.Forms.TextBox _tbTotalNumberOfEdges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _buttonLoadVariant;
        private System.Windows.Forms.DataGridView _gridVariant;
        private System.Windows.Forms.TextBox _tbStdDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _buttonNormalize;
        private System.Windows.Forms.TextBox _tbNumberOfHorses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbNumberOfVerticesWithValidVariant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cbLoadingMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _buttonSaveToDb;
    }
}

