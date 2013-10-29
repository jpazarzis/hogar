namespace OddsEditor.Dialogs
{
    partial class ShowRacesByHorseForm
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
            this._panel = new System.Windows.Forms.Panel();
            this._buttonGo = new System.Windows.Forms.Button();
            this._txtboxHorseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._popUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.BackColor = System.Drawing.Color.DodgerBlue;
            this._panel.Controls.Add(this._buttonGo);
            this._panel.Controls.Add(this._txtboxHorseName);
            this._panel.Controls.Add(this.label1);
            this._panel.Dock = System.Windows.Forms.DockStyle.Top;
            this._panel.Location = new System.Drawing.Point(0, 0);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(1344, 54);
            this._panel.TabIndex = 0;
            // 
            // _buttonGo
            // 
            this._buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonGo.Location = new System.Drawing.Point(474, 9);
            this._buttonGo.Name = "_buttonGo";
            this._buttonGo.Size = new System.Drawing.Size(65, 31);
            this._buttonGo.TabIndex = 2;
            this._buttonGo.Text = "Go";
            this._buttonGo.UseVisualStyleBackColor = true;
            this._buttonGo.Click += new System.EventHandler(this.OnGo);
            // 
            // _txtboxHorseName
            // 
            this._txtboxHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxHorseName.Location = new System.Drawing.Point(140, 12);
            this._txtboxHorseName.Name = "_txtboxHorseName";
            this._txtboxHorseName.Size = new System.Drawing.Size(327, 26);
            this._txtboxHorseName.TabIndex = 1;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horse Name";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToOrderColumns = true;
            this._grid.AllowUserToResizeColumns = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(0, 60);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(1332, 828);
            this._grid.TabIndex = 1;
            this._grid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnMouseClick);
            this._grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnGridCellFormatting);
            // 
            // _popUpMenu
            // 
            this._popUpMenu.Name = "_popUpMenu";
            this._popUpMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // ShowRacesByHorseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1344, 900);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._panel);
            this.DoubleBuffered = true;
            this.Name = "ShowRacesByHorseForm";
            this.Text = "Find Races By Horse Name (c) John Pazarzis 2008-09 (c) John Pazarzis 2008-2011 Ve" +
                "r. 2.01";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this._panel.ResumeLayout(false);
            this._panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.TextBox _txtboxHorseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _buttonGo;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ContextMenuStrip _popUpMenu;
    }
}
