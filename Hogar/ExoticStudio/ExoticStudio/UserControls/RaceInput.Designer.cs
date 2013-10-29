namespace ExoticStudio
{
    partial class RaceInput
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
            this.components = new System.ComponentModel.Container();
            this._grid = new System.Windows.Forms.DataGridView();
            this._popUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._showRaceSummaryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._fromComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._toComboBox = new System.Windows.Forms.ComboBox();
            this._deleteLimitationButton = new System.Windows.Forms.Button();
            this._indexTextBox = new System.Windows.Forms.TextBox();
            this._copyLimitationButton = new System.Windows.Forms.Button();
            this._pasteButton = new System.Windows.Forms.Button();
            this._updateButtonsTimer = new System.Windows.Forms.Timer(this.components);
            this._chBoxIsLimitationEnabled = new System.Windows.Forms.CheckBox();
            this._matchesListView = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this._popUpMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.CausesValidation = false;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(15, 50);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grid.Size = new System.Drawing.Size(214, 258);
            this._grid.TabIndex = 0;
            this._grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnGridMouseDown);
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridClick);
            // 
            // _popUpMenu
            // 
            this._popUpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showRaceSummaryMenuItem});
            this._popUpMenu.Name = "_popUpMenu";
            this._popUpMenu.Size = new System.Drawing.Size(186, 26);
            // 
            // _showRaceSummaryMenuItem
            // 
            this._showRaceSummaryMenuItem.Name = "_showRaceSummaryMenuItem";
            this._showRaceSummaryMenuItem.Size = new System.Drawing.Size(185, 22);
            this._showRaceSummaryMenuItem.Text = "Show Race Summary";
            this._showRaceSummaryMenuItem.Click += new System.EventHandler(this.OnShowRaceSummary);
            // 
            // _fromComboBox
            // 
            this._fromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._fromComboBox.FormattingEnabled = true;
            this._fromComboBox.Location = new System.Drawing.Point(58, 314);
            this._fromComboBox.Name = "_fromComboBox";
            this._fromComboBox.Size = new System.Drawing.Size(36, 21);
            this._fromComboBox.TabIndex = 1;
            this._fromComboBox.SelectedIndexChanged += new System.EventHandler(this.OnFromChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // _toComboBox
            // 
            this._toComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._toComboBox.FormattingEnabled = true;
            this._toComboBox.Location = new System.Drawing.Point(58, 345);
            this._toComboBox.Name = "_toComboBox";
            this._toComboBox.Size = new System.Drawing.Size(36, 21);
            this._toComboBox.TabIndex = 3;
            this._toComboBox.SelectedIndexChanged += new System.EventHandler(this.OnToChanged);
            // 
            // _deleteLimitationButton
            // 
            this._deleteLimitationButton.Location = new System.Drawing.Point(99, 347);
            this._deleteLimitationButton.Name = "_deleteLimitationButton";
            this._deleteLimitationButton.Size = new System.Drawing.Size(46, 21);
            this._deleteLimitationButton.TabIndex = 5;
            this._deleteLimitationButton.Text = "Delete";
            this._deleteLimitationButton.UseVisualStyleBackColor = true;
            this._deleteLimitationButton.Click += new System.EventHandler(this.OnDeleteLimitation);
            // 
            // _indexTextBox
            // 
            this._indexTextBox.Location = new System.Drawing.Point(18, 24);
            this._indexTextBox.Name = "_indexTextBox";
            this._indexTextBox.ReadOnly = true;
            this._indexTextBox.Size = new System.Drawing.Size(31, 20);
            this._indexTextBox.TabIndex = 7;
            // 
            // _copyLimitationButton
            // 
            this._copyLimitationButton.Location = new System.Drawing.Point(146, 347);
            this._copyLimitationButton.Name = "_copyLimitationButton";
            this._copyLimitationButton.Size = new System.Drawing.Size(40, 21);
            this._copyLimitationButton.TabIndex = 8;
            this._copyLimitationButton.Text = "Copy";
            this._copyLimitationButton.UseVisualStyleBackColor = true;
            this._copyLimitationButton.Click += new System.EventHandler(this.OnCopy);
            // 
            // _pasteButton
            // 
            this._pasteButton.Location = new System.Drawing.Point(188, 347);
            this._pasteButton.Name = "_pasteButton";
            this._pasteButton.Size = new System.Drawing.Size(42, 21);
            this._pasteButton.TabIndex = 9;
            this._pasteButton.Text = "Paste";
            this._pasteButton.UseVisualStyleBackColor = true;
            this._pasteButton.Click += new System.EventHandler(this.OnPaste);
            // 
            // _updateButtonsTimer
            // 
            this._updateButtonsTimer.Interval = 1000;
            this._updateButtonsTimer.Tick += new System.EventHandler(this.OnUpdateButtonsTimer);
            // 
            // _chBoxIsLimitationEnabled
            // 
            this._chBoxIsLimitationEnabled.AutoSize = true;
            this._chBoxIsLimitationEnabled.Location = new System.Drawing.Point(161, 25);
            this._chBoxIsLimitationEnabled.Name = "_chBoxIsLimitationEnabled";
            this._chBoxIsLimitationEnabled.Size = new System.Drawing.Size(65, 17);
            this._chBoxIsLimitationEnabled.TabIndex = 10;
            this._chBoxIsLimitationEnabled.Text = "Enabled";
            this._chBoxIsLimitationEnabled.UseVisualStyleBackColor = true;
            this._chBoxIsLimitationEnabled.Click += new System.EventHandler(this._chBoxIsLimitationEnabled_Click);
            // 
            // _matchesListView
            // 
            this._matchesListView.FormattingEnabled = true;
            this._matchesListView.Location = new System.Drawing.Point(235, 50);
            this._matchesListView.Name = "_matchesListView";
            this._matchesListView.Size = new System.Drawing.Size(50, 95);
            this._matchesListView.Sorted = true;
            this._matchesListView.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._grid);
            this.groupBox1.Controls.Add(this._fromComboBox);
            this.groupBox1.Controls.Add(this._pasteButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._chBoxIsLimitationEnabled);
            this.groupBox1.Controls.Add(this._toComboBox);
            this.groupBox1.Controls.Add(this._copyLimitationButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._indexTextBox);
            this.groupBox1.Controls.Add(this._matchesListView);
            this.groupBox1.Controls.Add(this._deleteLimitationButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 381);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // RaceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "RaceInput";
            this.Size = new System.Drawing.Size(308, 405);
            this.Load += new System.EventHandler(this.SystemScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this._popUpMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _fromComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _toComboBox;
        private System.Windows.Forms.Button _deleteLimitationButton;
        private System.Windows.Forms.TextBox _indexTextBox;
        private System.Windows.Forms.Button _copyLimitationButton;
        private System.Windows.Forms.Button _pasteButton;
        protected System.Windows.Forms.Timer _updateButtonsTimer;
        private System.Windows.Forms.ContextMenuStrip _popUpMenu;
        private System.Windows.Forms.ToolStripMenuItem _showRaceSummaryMenuItem;
        private System.Windows.Forms.CheckBox _chBoxIsLimitationEnabled;
        private System.Windows.Forms.ListBox _matchesListView;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
