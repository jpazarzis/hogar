namespace OddsEditor.Dialogs.FactorWorkbench
{
    partial class FactorWorkbenchForm
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
            this._lbFactor = new System.Windows.Forms.ListBox();
            this._bClose = new System.Windows.Forms.Button();
            this._panelSelectedFactor = new System.Windows.Forms.Panel();
            this._labelFactorName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._tbTotal = new System.Windows.Forms.TextBox();
            this._tbWinners = new System.Windows.Forms.TextBox();
            this._tbROI = new System.Windows.Forms.TextBox();
            this._tbWinningPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._cbGroupByDistance = new System.Windows.Forms.CheckBox();
            this._cbGroupByClassification = new System.Windows.Forms.CheckBox();
            this._cbGroupByTrack = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._gridGrouping = new System.Windows.Forms.DataGridView();
            this._cbTrainer = new System.Windows.Forms.CheckBox();
            this._panelSelectedFactor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridGrouping)).BeginInit();
            this.SuspendLayout();
            // 
            // _lbFactor
            // 
            this._lbFactor.Dock = System.Windows.Forms.DockStyle.Left;
            this._lbFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbFactor.FormattingEnabled = true;
            this._lbFactor.ItemHeight = 16;
            this._lbFactor.Location = new System.Drawing.Point(0, 0);
            this._lbFactor.Name = "_lbFactor";
            this._lbFactor.Size = new System.Drawing.Size(234, 532);
            this._lbFactor.TabIndex = 0;
            this._lbFactor.DoubleClick += new System.EventHandler(this.OnFactorListDoubleClicked);
            // 
            // _bClose
            // 
            this._bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bClose.Location = new System.Drawing.Point(985, 12);
            this._bClose.Name = "_bClose";
            this._bClose.Size = new System.Drawing.Size(101, 44);
            this._bClose.TabIndex = 4;
            this._bClose.Text = "Close";
            this._bClose.UseVisualStyleBackColor = true;
            // 
            // _panelSelectedFactor
            // 
            this._panelSelectedFactor.BackColor = System.Drawing.Color.LightSkyBlue;
            this._panelSelectedFactor.Controls.Add(this._labelFactorName);
            this._panelSelectedFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._panelSelectedFactor.ForeColor = System.Drawing.Color.RoyalBlue;
            this._panelSelectedFactor.Location = new System.Drawing.Point(240, 0);
            this._panelSelectedFactor.Name = "_panelSelectedFactor";
            this._panelSelectedFactor.Size = new System.Drawing.Size(453, 56);
            this._panelSelectedFactor.TabIndex = 5;
            // 
            // _labelFactorName
            // 
            this._labelFactorName.AutoSize = true;
            this._labelFactorName.Location = new System.Drawing.Point(18, 12);
            this._labelFactorName.Name = "_labelFactorName";
            this._labelFactorName.Size = new System.Drawing.Size(115, 20);
            this._labelFactorName.TabIndex = 0;
            this._labelFactorName.Text = "FirstTimeTurf";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Winners";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ROI";
            // 
            // _tbTotal
            // 
            this._tbTotal.Location = new System.Drawing.Point(287, 72);
            this._tbTotal.Name = "_tbTotal";
            this._tbTotal.ReadOnly = true;
            this._tbTotal.Size = new System.Drawing.Size(38, 20);
            this._tbTotal.TabIndex = 9;
            // 
            // _tbWinners
            // 
            this._tbWinners.Location = new System.Drawing.Point(383, 72);
            this._tbWinners.Name = "_tbWinners";
            this._tbWinners.ReadOnly = true;
            this._tbWinners.Size = new System.Drawing.Size(38, 20);
            this._tbWinners.TabIndex = 10;
            // 
            // _tbROI
            // 
            this._tbROI.Location = new System.Drawing.Point(534, 72);
            this._tbROI.Name = "_tbROI";
            this._tbROI.ReadOnly = true;
            this._tbROI.Size = new System.Drawing.Size(38, 20);
            this._tbROI.TabIndex = 11;
            // 
            // _tbWinningPercent
            // 
            this._tbWinningPercent.Location = new System.Drawing.Point(457, 72);
            this._tbWinningPercent.Name = "_tbWinningPercent";
            this._tbWinningPercent.ReadOnly = true;
            this._tbWinningPercent.Size = new System.Drawing.Size(38, 20);
            this._tbWinningPercent.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "%";
            // 
            // _cbGroupByDistance
            // 
            this._cbGroupByDistance.AutoSize = true;
            this._cbGroupByDistance.Location = new System.Drawing.Point(176, 19);
            this._cbGroupByDistance.Name = "_cbGroupByDistance";
            this._cbGroupByDistance.Size = new System.Drawing.Size(68, 17);
            this._cbGroupByDistance.TabIndex = 15;
            this._cbGroupByDistance.Text = "Distance";
            this._cbGroupByDistance.UseVisualStyleBackColor = true;
            this._cbGroupByDistance.CheckedChanged += new System.EventHandler(this.OnGroupingWasChanged);
            // 
            // _cbGroupByClassification
            // 
            this._cbGroupByClassification.AutoSize = true;
            this._cbGroupByClassification.Location = new System.Drawing.Point(74, 19);
            this._cbGroupByClassification.Name = "_cbGroupByClassification";
            this._cbGroupByClassification.Size = new System.Drawing.Size(87, 17);
            this._cbGroupByClassification.TabIndex = 16;
            this._cbGroupByClassification.Text = "Classification";
            this._cbGroupByClassification.UseVisualStyleBackColor = true;
            this._cbGroupByClassification.CheckedChanged += new System.EventHandler(this.OnGroupingWasChanged);
            // 
            // _cbGroupByTrack
            // 
            this._cbGroupByTrack.AutoSize = true;
            this._cbGroupByTrack.Location = new System.Drawing.Point(6, 19);
            this._cbGroupByTrack.Name = "_cbGroupByTrack";
            this._cbGroupByTrack.Size = new System.Drawing.Size(54, 17);
            this._cbGroupByTrack.TabIndex = 14;
            this._cbGroupByTrack.Text = "Track";
            this._cbGroupByTrack.UseVisualStyleBackColor = true;
            this._cbGroupByTrack.CheckedChanged += new System.EventHandler(this.OnGroupingWasChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._cbTrainer);
            this.groupBox1.Controls.Add(this._cbGroupByTrack);
            this.groupBox1.Controls.Add(this._cbGroupByDistance);
            this.groupBox1.Controls.Add(this._cbGroupByClassification);
            this.groupBox1.Location = new System.Drawing.Point(670, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 47);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grouping";
            // 
            // _gridGrouping
            // 
            this._gridGrouping.AllowUserToAddRows = false;
            this._gridGrouping.AllowUserToDeleteRows = false;
            this._gridGrouping.AllowUserToOrderColumns = true;
            this._gridGrouping.AllowUserToResizeColumns = false;
            this._gridGrouping.AllowUserToResizeRows = false;
            this._gridGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._gridGrouping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridGrouping.Location = new System.Drawing.Point(241, 119);
            this._gridGrouping.Name = "_gridGrouping";
            this._gridGrouping.ReadOnly = true;
            this._gridGrouping.Size = new System.Drawing.Size(845, 413);
            this._gridGrouping.TabIndex = 18;
            // 
            // _cbTrainer
            // 
            this._cbTrainer.AutoSize = true;
            this._cbTrainer.Location = new System.Drawing.Point(250, 19);
            this._cbTrainer.Name = "_cbTrainer";
            this._cbTrainer.Size = new System.Drawing.Size(59, 17);
            this._cbTrainer.TabIndex = 19;
            this._cbTrainer.Text = "Trainer";
            this._cbTrainer.UseVisualStyleBackColor = true;
            this._cbTrainer.CheckedChanged += new System.EventHandler(this.OnGroupingWasChanged);
            // 
            // FactorWorkbenchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 547);
            this.Controls.Add(this._gridGrouping);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._tbWinningPercent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbROI);
            this.Controls.Add(this._tbWinners);
            this.Controls.Add(this._tbTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._panelSelectedFactor);
            this.Controls.Add(this._bClose);
            this.Controls.Add(this._lbFactor);
            this.Name = "FactorWorkbenchForm";
            this.Text = "Factor Workbench ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._panelSelectedFactor.ResumeLayout(false);
            this._panelSelectedFactor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridGrouping)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _lbFactor;
        private System.Windows.Forms.Button _bClose;
        private System.Windows.Forms.Panel _panelSelectedFactor;
        private System.Windows.Forms.Label _labelFactorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbTotal;
        private System.Windows.Forms.TextBox _tbWinners;
        private System.Windows.Forms.TextBox _tbROI;
        private System.Windows.Forms.TextBox _tbWinningPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _cbGroupByDistance;
        private System.Windows.Forms.CheckBox _cbGroupByClassification;
        private System.Windows.Forms.CheckBox _cbGroupByTrack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView _gridGrouping;
        private System.Windows.Forms.CheckBox _cbTrainer;
    }
}