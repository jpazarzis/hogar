namespace SippViewer
{
    partial class FactorsSummaryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactorsSummaryForm));
            this._tree = new System.Windows.Forms.TreeView();
            this._buttonSortByWinningPercentage = new System.Windows.Forms.Button();
            this._sortByRoi = new System.Windows.Forms.Button();
            this.IV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._popupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tree
            // 
            this._tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tree.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tree.Location = new System.Drawing.Point(32, 73);
            this._tree.Name = "_tree";
            this._tree.Size = new System.Drawing.Size(612, 561);
            this._tree.TabIndex = 0;
            this._tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tree_NodeMouseClick);
            this._tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tree_NodeMouseDoubleClick);
            // 
            // _buttonSortByWinningPercentage
            // 
            this._buttonSortByWinningPercentage.Location = new System.Drawing.Point(12, 16);
            this._buttonSortByWinningPercentage.Name = "_buttonSortByWinningPercentage";
            this._buttonSortByWinningPercentage.Size = new System.Drawing.Size(75, 39);
            this._buttonSortByWinningPercentage.TabIndex = 1;
            this._buttonSortByWinningPercentage.Text = "Win %";
            this._buttonSortByWinningPercentage.UseVisualStyleBackColor = true;
            this._buttonSortByWinningPercentage.Click += new System.EventHandler(this.OnSortByWinningPercentage);
            // 
            // _sortByRoi
            // 
            this._sortByRoi.Location = new System.Drawing.Point(99, 16);
            this._sortByRoi.Name = "_sortByRoi";
            this._sortByRoi.Size = new System.Drawing.Size(75, 39);
            this._sortByRoi.TabIndex = 2;
            this._sortByRoi.Text = "ROI";
            this._sortByRoi.UseVisualStyleBackColor = true;
            this._sortByRoi.Click += new System.EventHandler(this.OnSortByROI);
            // 
            // IV
            // 
            this.IV.Location = new System.Drawing.Point(186, 16);
            this.IV.Name = "IV";
            this.IV.Size = new System.Drawing.Size(75, 39);
            this.IV.TabIndex = 3;
            this.IV.Text = "IV";
            this.IV.UseVisualStyleBackColor = true;
            this.IV.Click += new System.EventHandler(this.OnSortByIV);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IV);
            this.groupBox1.Controls.Add(this._buttonSortByWinningPercentage);
            this.groupBox1.Controls.Add(this._sortByRoi);
            this.groupBox1.Location = new System.Drawing.Point(360, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 64);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By";
            // 
            // _popupMenu
            // 
            this._popupMenu.Name = "_popupMenu";
            this._popupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // FactorsSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 655);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._tree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FactorsSummaryForm";
            this.Text = "FactorsSummaryForm";
            this.Load += new System.EventHandler(this.FactorsSummaryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _tree;
        private System.Windows.Forms.Button _buttonSortByWinningPercentage;
        private System.Windows.Forms.Button _sortByRoi;
        private System.Windows.Forms.Button IV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip _popupMenu;
    }
}