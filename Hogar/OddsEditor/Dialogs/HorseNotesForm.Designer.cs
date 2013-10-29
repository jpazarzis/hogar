namespace OddsEditor.Dialogs
{
    partial class HorseNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HorseNotesForm));
            this._labelHorseName = new System.Windows.Forms.Label();
            this._buttonFont = new System.Windows.Forms.Button();
            this._buttonSelectColor = new System.Windows.Forms.Button();
            this._buttonItalic = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._buttonUnderlined = new System.Windows.Forms.Button();
            this._buttonMakeSelectionBold = new System.Windows.Forms.Button();
            this._txtbox = new System.Windows.Forms.RichTextBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonClose = new System.Windows.Forms.Button();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._buttonSaveAndClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.BackColor = System.Drawing.Color.DodgerBlue;
            this._labelHorseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelHorseName.ForeColor = System.Drawing.Color.White;
            this._labelHorseName.Location = new System.Drawing.Point(12, 9);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(150, 20);
            this._labelHorseName.TabIndex = 0;
            this._labelHorseName.Text = "Rachel Alexandra";
            // 
            // _buttonFont
            // 
            this._buttonFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonFont.Location = new System.Drawing.Point(182, 52);
            this._buttonFont.Name = "_buttonFont";
            this._buttonFont.Size = new System.Drawing.Size(35, 23);
            this._buttonFont.TabIndex = 11;
            this._buttonFont.Text = "F";
            this._buttonFont.UseVisualStyleBackColor = true;
            this._buttonFont.Click += new System.EventHandler(this.OnSelectFontClicked);
            // 
            // _buttonSelectColor
            // 
            this._buttonSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSelectColor.Image = ((System.Drawing.Image)(resources.GetObject("_buttonSelectColor.Image")));
            this._buttonSelectColor.Location = new System.Drawing.Point(141, 52);
            this._buttonSelectColor.Name = "_buttonSelectColor";
            this._buttonSelectColor.Size = new System.Drawing.Size(35, 23);
            this._buttonSelectColor.TabIndex = 10;
            this._buttonSelectColor.UseVisualStyleBackColor = true;
            this._buttonSelectColor.Click += new System.EventHandler(this.OnSelectColorClicked);
            // 
            // _buttonItalic
            // 
            this._buttonItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonItalic.Location = new System.Drawing.Point(100, 52);
            this._buttonItalic.Name = "_buttonItalic";
            this._buttonItalic.Size = new System.Drawing.Size(35, 23);
            this._buttonItalic.TabIndex = 9;
            this._buttonItalic.Text = "I";
            this._buttonItalic.UseVisualStyleBackColor = true;
            this._buttonItalic.Click += new System.EventHandler(this.OnMakeItalicClicked);
            // 
            // _buttonUnderlined
            // 
            this._buttonUnderlined.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonUnderlined.Location = new System.Drawing.Point(59, 52);
            this._buttonUnderlined.Name = "_buttonUnderlined";
            this._buttonUnderlined.Size = new System.Drawing.Size(35, 23);
            this._buttonUnderlined.TabIndex = 8;
            this._buttonUnderlined.Text = "U";
            this._buttonUnderlined.UseVisualStyleBackColor = true;
            this._buttonUnderlined.Click += new System.EventHandler(this.OnMakeUnderlinedCliked);
            // 
            // _buttonMakeSelectionBold
            // 
            this._buttonMakeSelectionBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonMakeSelectionBold.Location = new System.Drawing.Point(18, 52);
            this._buttonMakeSelectionBold.Name = "_buttonMakeSelectionBold";
            this._buttonMakeSelectionBold.Size = new System.Drawing.Size(35, 23);
            this._buttonMakeSelectionBold.TabIndex = 7;
            this._buttonMakeSelectionBold.Text = "B";
            this._buttonMakeSelectionBold.UseVisualStyleBackColor = true;
            this._buttonMakeSelectionBold.Click += new System.EventHandler(this.OnMakeSelectionBoldClicked);
            // 
            // _txtbox
            // 
            this._txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox.Location = new System.Drawing.Point(16, 87);
            this._txtbox.Name = "_txtbox";
            this._txtbox.Size = new System.Drawing.Size(687, 525);
            this._txtbox.TabIndex = 6;
            this._txtbox.Text = "";
            this._txtbox.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            this._txtbox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // _buttonSave
            // 
            this._buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSave.Location = new System.Drawing.Point(383, 52);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 23);
            this._buttonSave.TabIndex = 12;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _buttonClose
            // 
            this._buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClose.Location = new System.Drawing.Point(615, 52);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(75, 23);
            this._buttonClose.TabIndex = 13;
            this._buttonClose.Text = "Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.OnClose);
            // 
            // _buttonDelete
            // 
            this._buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonDelete.Location = new System.Drawing.Point(538, 52);
            this._buttonDelete.Name = "_buttonDelete";
            this._buttonDelete.Size = new System.Drawing.Size(75, 23);
            this._buttonDelete.TabIndex = 14;
            this._buttonDelete.Text = "Delete";
            this._buttonDelete.UseVisualStyleBackColor = true;
            this._buttonDelete.Click += new System.EventHandler(this.OnDelete);
            // 
            // _buttonSaveAndClose
            // 
            this._buttonSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSaveAndClose.Location = new System.Drawing.Point(463, 52);
            this._buttonSaveAndClose.Name = "_buttonSaveAndClose";
            this._buttonSaveAndClose.Size = new System.Drawing.Size(75, 23);
            this._buttonSaveAndClose.TabIndex = 15;
            this._buttonSaveAndClose.Text = "Save/Close";
            this._buttonSaveAndClose.UseVisualStyleBackColor = true;
            this._buttonSaveAndClose.Click += new System.EventHandler(this.OnSaveAndClose);
            // 
            // HorseNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 624);
            this.Controls.Add(this._buttonSaveAndClose);
            this.Controls.Add(this._buttonDelete);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._buttonFont);
            this.Controls.Add(this._buttonSelectColor);
            this.Controls.Add(this._buttonItalic);
            this.Controls.Add(this._buttonUnderlined);
            this.Controls.Add(this._buttonMakeSelectionBold);
            this.Controls.Add(this._txtbox);
            this.Controls.Add(this._labelHorseName);
            this.Name = "HorseNotesForm";
            this.Text = "HorseNotesForm";
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelHorseName;
        private System.Windows.Forms.Button _buttonFont;
        private System.Windows.Forms.Button _buttonSelectColor;
        private System.Windows.Forms.Button _buttonItalic;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Button _buttonUnderlined;
        private System.Windows.Forms.Button _buttonMakeSelectionBold;
        private System.Windows.Forms.RichTextBox _txtbox;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Button _buttonDelete;
        private System.Windows.Forms.Button _buttonSaveAndClose;
    }
}