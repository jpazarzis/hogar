namespace OddsEditor.Dialogs.SelectCard
{
    partial class SelectCardForm
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
            this._tree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this._tbTotalNumberOfCards = new System.Windows.Forms.TextBox();
            this._tbSelectedTrack = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbSelectedDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _tree
            // 
            this._tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._tree.Location = new System.Drawing.Point(25, 40);
            this._tree.Name = "_tree";
            this._tree.Size = new System.Drawing.Size(729, 721);
            this._tree.TabIndex = 0;
            this._tree.DoubleClick += new System.EventHandler(this._tree_DoubleClick);
            this._tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tree_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Number Of Cards";
            // 
            // _tbTotalNumberOfCards
            // 
            this._tbTotalNumberOfCards.Location = new System.Drawing.Point(147, 13);
            this._tbTotalNumberOfCards.Name = "_tbTotalNumberOfCards";
            this._tbTotalNumberOfCards.ReadOnly = true;
            this._tbTotalNumberOfCards.Size = new System.Drawing.Size(64, 20);
            this._tbTotalNumberOfCards.TabIndex = 4;
            // 
            // _tbSelectedTrack
            // 
            this._tbSelectedTrack.Location = new System.Drawing.Point(318, 13);
            this._tbSelectedTrack.Name = "_tbSelectedTrack";
            this._tbSelectedTrack.ReadOnly = true;
            this._tbSelectedTrack.Size = new System.Drawing.Size(152, 20);
            this._tbSelectedTrack.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Track";
            // 
            // _tbSelectedDate
            // 
            this._tbSelectedDate.Location = new System.Drawing.Point(539, 13);
            this._tbSelectedDate.Name = "_tbSelectedDate";
            this._tbSelectedDate.ReadOnly = true;
            this._tbSelectedDate.Size = new System.Drawing.Size(152, 20);
            this._tbSelectedDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date";
            // 
            // SelectCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 773);
            this.Controls.Add(this._tbSelectedDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbSelectedTrack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbTotalNumberOfCards);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tree);
            this.Name = "SelectCardForm";
            this.Text = "SelectCardForm";
            this.Load += new System.EventHandler(this.SelectCardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView _tree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbTotalNumberOfCards;
        private System.Windows.Forms.TextBox _tbSelectedTrack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbSelectedDate;
        private System.Windows.Forms.Label label3;
    }
}