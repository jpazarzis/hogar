namespace OddsEditor.MyComponents
{
    partial class CynthiaProjectionsFullCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._gridTodaysRacePars = new System.Windows.Forms.DataGridView();
            this._gridPastPerformances = new System.Windows.Forms.DataGridView();
            this._gridCynthiaParsForSelectedRace = new System.Windows.Forms.DataGridView();
            this._txtboxFirstCallAdj = new System.Windows.Forms.TextBox();
            this._txtboxSecondCallAdj = new System.Windows.Forms.TextBox();
            this._txtboxFinalCallAdj = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._txtboxFinalCallProjection = new System.Windows.Forms.TextBox();
            this._txtboxFirstCallProjection = new System.Windows.Forms.TextBox();
            this._txtboxSecondCallProjection = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._txtboxFinalCallProjectionAdjustedByVariant = new System.Windows.Forms.TextBox();
            this._txtboxFirstCallProjectionAdjustedByVariant = new System.Windows.Forms.TextBox();
            this._txtboxSecondCallProjectionAdjustedByVariant = new System.Windows.Forms.TextBox();
            this._labelHorseName = new System.Windows.Forms.Label();
            this._cynthiaProjectionsCtrl = new OddsEditor.MyComponents.CynthiaProjectionsCtrl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridTodaysRacePars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridPastPerformances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridCynthiaParsForSelectedRace)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._gridTodaysRacePars);
            this.groupBox1.Location = new System.Drawing.Point(15, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Today\'s Race Pars";
            // 
            // _gridTodaysRacePars
            // 
            this._gridTodaysRacePars.AllowUserToAddRows = false;
            this._gridTodaysRacePars.AllowUserToDeleteRows = false;
            this._gridTodaysRacePars.AllowUserToResizeColumns = false;
            this._gridTodaysRacePars.AllowUserToResizeRows = false;
            this._gridTodaysRacePars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridTodaysRacePars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridTodaysRacePars.Location = new System.Drawing.Point(7, 32);
            this._gridTodaysRacePars.Name = "_gridTodaysRacePars";
            this._gridTodaysRacePars.ReadOnly = true;
            this._gridTodaysRacePars.RowHeadersVisible = false;
            this._gridTodaysRacePars.Size = new System.Drawing.Size(783, 85);
            this._gridTodaysRacePars.TabIndex = 0;
            // 
            // _gridPastPerformances
            // 
            this._gridPastPerformances.AllowUserToAddRows = false;
            this._gridPastPerformances.AllowUserToDeleteRows = false;
            this._gridPastPerformances.AllowUserToResizeColumns = false;
            this._gridPastPerformances.AllowUserToResizeRows = false;
            this._gridPastPerformances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridPastPerformances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridPastPerformances.Location = new System.Drawing.Point(20, 451);
            this._gridPastPerformances.Name = "_gridPastPerformances";
            this._gridPastPerformances.ReadOnly = true;
            this._gridPastPerformances.RowHeadersVisible = false;
            this._gridPastPerformances.Size = new System.Drawing.Size(985, 312);
            this._gridPastPerformances.TabIndex = 1;
            this._gridPastPerformances.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridPastPerformancesCellDoubleClick);
            // 
            // _gridCynthiaParsForSelectedRace
            // 
            this._gridCynthiaParsForSelectedRace.AllowUserToAddRows = false;
            this._gridCynthiaParsForSelectedRace.AllowUserToDeleteRows = false;
            this._gridCynthiaParsForSelectedRace.AllowUserToResizeColumns = false;
            this._gridCynthiaParsForSelectedRace.AllowUserToResizeRows = false;
            this._gridCynthiaParsForSelectedRace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridCynthiaParsForSelectedRace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridCynthiaParsForSelectedRace.Location = new System.Drawing.Point(22, 251);
            this._gridCynthiaParsForSelectedRace.Name = "_gridCynthiaParsForSelectedRace";
            this._gridCynthiaParsForSelectedRace.ReadOnly = true;
            this._gridCynthiaParsForSelectedRace.RowHeadersVisible = false;
            this._gridCynthiaParsForSelectedRace.Size = new System.Drawing.Size(783, 85);
            this._gridCynthiaParsForSelectedRace.TabIndex = 2;
            // 
            // _txtboxFirstCallAdj
            // 
            this._txtboxFirstCallAdj.Location = new System.Drawing.Point(25, 19);
            this._txtboxFirstCallAdj.Name = "_txtboxFirstCallAdj";
            this._txtboxFirstCallAdj.ReadOnly = true;
            this._txtboxFirstCallAdj.Size = new System.Drawing.Size(56, 20);
            this._txtboxFirstCallAdj.TabIndex = 3;
            // 
            // _txtboxSecondCallAdj
            // 
            this._txtboxSecondCallAdj.Location = new System.Drawing.Point(95, 19);
            this._txtboxSecondCallAdj.Name = "_txtboxSecondCallAdj";
            this._txtboxSecondCallAdj.ReadOnly = true;
            this._txtboxSecondCallAdj.Size = new System.Drawing.Size(56, 20);
            this._txtboxSecondCallAdj.TabIndex = 4;
            // 
            // _txtboxFinalCallAdj
            // 
            this._txtboxFinalCallAdj.Location = new System.Drawing.Point(164, 19);
            this._txtboxFinalCallAdj.Name = "_txtboxFinalCallAdj";
            this._txtboxFinalCallAdj.ReadOnly = true;
            this._txtboxFinalCallAdj.Size = new System.Drawing.Size(56, 20);
            this._txtboxFinalCallAdj.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtboxFinalCallAdj);
            this.groupBox2.Controls.Add(this._txtboxFirstCallAdj);
            this.groupBox2.Controls.Add(this._txtboxSecondCallAdj);
            this.groupBox2.Location = new System.Drawing.Point(24, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 57);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Differentials";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._txtboxFinalCallProjection);
            this.groupBox3.Controls.Add(this._txtboxFirstCallProjection);
            this.groupBox3.Controls.Add(this._txtboxSecondCallProjection);
            this.groupBox3.Location = new System.Drawing.Point(279, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 57);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Projections";
            // 
            // _txtboxFinalCallProjection
            // 
            this._txtboxFinalCallProjection.Location = new System.Drawing.Point(164, 19);
            this._txtboxFinalCallProjection.Name = "_txtboxFinalCallProjection";
            this._txtboxFinalCallProjection.ReadOnly = true;
            this._txtboxFinalCallProjection.Size = new System.Drawing.Size(56, 20);
            this._txtboxFinalCallProjection.TabIndex = 5;
            // 
            // _txtboxFirstCallProjection
            // 
            this._txtboxFirstCallProjection.Location = new System.Drawing.Point(25, 19);
            this._txtboxFirstCallProjection.Name = "_txtboxFirstCallProjection";
            this._txtboxFirstCallProjection.ReadOnly = true;
            this._txtboxFirstCallProjection.Size = new System.Drawing.Size(56, 20);
            this._txtboxFirstCallProjection.TabIndex = 3;
            // 
            // _txtboxSecondCallProjection
            // 
            this._txtboxSecondCallProjection.Location = new System.Drawing.Point(95, 19);
            this._txtboxSecondCallProjection.Name = "_txtboxSecondCallProjection";
            this._txtboxSecondCallProjection.ReadOnly = true;
            this._txtboxSecondCallProjection.Size = new System.Drawing.Size(56, 20);
            this._txtboxSecondCallProjection.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._txtboxFinalCallProjectionAdjustedByVariant);
            this.groupBox4.Controls.Add(this._txtboxFirstCallProjectionAdjustedByVariant);
            this.groupBox4.Controls.Add(this._txtboxSecondCallProjectionAdjustedByVariant);
            this.groupBox4.Location = new System.Drawing.Point(535, 375);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 57);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Projections Adj By Variant";
            // 
            // _txtboxFinalCallProjectionAdjustedByVariant
            // 
            this._txtboxFinalCallProjectionAdjustedByVariant.Location = new System.Drawing.Point(164, 19);
            this._txtboxFinalCallProjectionAdjustedByVariant.Name = "_txtboxFinalCallProjectionAdjustedByVariant";
            this._txtboxFinalCallProjectionAdjustedByVariant.ReadOnly = true;
            this._txtboxFinalCallProjectionAdjustedByVariant.Size = new System.Drawing.Size(56, 20);
            this._txtboxFinalCallProjectionAdjustedByVariant.TabIndex = 5;
            // 
            // _txtboxFirstCallProjectionAdjustedByVariant
            // 
            this._txtboxFirstCallProjectionAdjustedByVariant.Location = new System.Drawing.Point(25, 19);
            this._txtboxFirstCallProjectionAdjustedByVariant.Name = "_txtboxFirstCallProjectionAdjustedByVariant";
            this._txtboxFirstCallProjectionAdjustedByVariant.ReadOnly = true;
            this._txtboxFirstCallProjectionAdjustedByVariant.Size = new System.Drawing.Size(56, 20);
            this._txtboxFirstCallProjectionAdjustedByVariant.TabIndex = 3;
            // 
            // _txtboxSecondCallProjectionAdjustedByVariant
            // 
            this._txtboxSecondCallProjectionAdjustedByVariant.Location = new System.Drawing.Point(95, 19);
            this._txtboxSecondCallProjectionAdjustedByVariant.Name = "_txtboxSecondCallProjectionAdjustedByVariant";
            this._txtboxSecondCallProjectionAdjustedByVariant.ReadOnly = true;
            this._txtboxSecondCallProjectionAdjustedByVariant.Size = new System.Drawing.Size(56, 20);
            this._txtboxSecondCallProjectionAdjustedByVariant.TabIndex = 4;
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.BackColor = System.Drawing.Color.Cyan;
            this._labelHorseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._labelHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseName.ForeColor = System.Drawing.Color.RoyalBlue;
            this._labelHorseName.Location = new System.Drawing.Point(24, 25);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(219, 31);
            this._labelHorseName.TabIndex = 9;
            this._labelHorseName.Text = "Rachel Alexandra";
            // 
            // _cynthiaProjectionsCtrl
            // 
            this._cynthiaProjectionsCtrl.Location = new System.Drawing.Point(848, 82);
            this._cynthiaProjectionsCtrl.Name = "_cynthiaProjectionsCtrl";
            this._cynthiaProjectionsCtrl.Size = new System.Drawing.Size(325, 289);
            this._cynthiaProjectionsCtrl.TabIndex = 10;
            // 
            // CynthiaProjectionsFullCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cynthiaProjectionsCtrl);
            this.Controls.Add(this._labelHorseName);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._gridCynthiaParsForSelectedRace);
            this.Controls.Add(this._gridPastPerformances);
            this.Controls.Add(this.groupBox1);
            this.Name = "CynthiaProjectionsFullCtrl";
            this.Size = new System.Drawing.Size(1357, 908);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridTodaysRacePars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridPastPerformances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridCynthiaParsForSelectedRace)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView _gridTodaysRacePars;
        private System.Windows.Forms.DataGridView _gridPastPerformances;
        private System.Windows.Forms.DataGridView _gridCynthiaParsForSelectedRace;
        private System.Windows.Forms.TextBox _txtboxFirstCallAdj;
        private System.Windows.Forms.TextBox _txtboxSecondCallAdj;
        private System.Windows.Forms.TextBox _txtboxFinalCallAdj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _txtboxFinalCallProjection;
        private System.Windows.Forms.TextBox _txtboxFirstCallProjection;
        private System.Windows.Forms.TextBox _txtboxSecondCallProjection;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox _txtboxFinalCallProjectionAdjustedByVariant;
        private System.Windows.Forms.TextBox _txtboxFirstCallProjectionAdjustedByVariant;
        private System.Windows.Forms.TextBox _txtboxSecondCallProjectionAdjustedByVariant;
        private System.Windows.Forms.Label _labelHorseName;
        private CynthiaProjectionsCtrl _cynthiaProjectionsCtrl;
    }
}
