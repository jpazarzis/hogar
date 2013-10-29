namespace OddsEditor.MyComponents
{
    partial class RaceCommentsCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceCommentsCtrl));
            this._txtbox = new System.Windows.Forms.RichTextBox();
            this._buttonMakeSelectionBold = new System.Windows.Forms.Button();
            this._buttonUnderlined = new System.Windows.Forms.Button();
            this._buttonItalic = new System.Windows.Forms.Button();
            this._buttonSelectColor = new System.Windows.Forms.Button();
            this._buttonFont = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _txtbox
            // 
            this._txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox.Location = new System.Drawing.Point(4, 32);
            this._txtbox.Name = "_txtbox";
            this._txtbox.Size = new System.Drawing.Size(363, 272);
            this._txtbox.TabIndex = 0;
            this._txtbox.Text = "";
            this._txtbox.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            this._txtbox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // _buttonMakeSelectionBold
            // 
            this._buttonMakeSelectionBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonMakeSelectionBold.Location = new System.Drawing.Point(4, 3);
            this._buttonMakeSelectionBold.Name = "_buttonMakeSelectionBold";
            this._buttonMakeSelectionBold.Size = new System.Drawing.Size(35, 23);
            this._buttonMakeSelectionBold.TabIndex = 1;
            this._buttonMakeSelectionBold.Text = "B";
            this._buttonMakeSelectionBold.UseVisualStyleBackColor = true;
            this._buttonMakeSelectionBold.Click += new System.EventHandler(this.OnMakeSelectionBoldClicked);
            // 
            // _buttonUnderlined
            // 
            this._buttonUnderlined.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonUnderlined.Location = new System.Drawing.Point(45, 3);
            this._buttonUnderlined.Name = "_buttonUnderlined";
            this._buttonUnderlined.Size = new System.Drawing.Size(35, 23);
            this._buttonUnderlined.TabIndex = 2;
            this._buttonUnderlined.Text = "U";
            this._buttonUnderlined.UseVisualStyleBackColor = true;
            this._buttonUnderlined.Click += new System.EventHandler(this.OnMakeUnderlinedCliked);
            // 
            // _buttonItalic
            // 
            this._buttonItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonItalic.Location = new System.Drawing.Point(86, 3);
            this._buttonItalic.Name = "_buttonItalic";
            this._buttonItalic.Size = new System.Drawing.Size(35, 23);
            this._buttonItalic.TabIndex = 3;
            this._buttonItalic.Text = "I";
            this._buttonItalic.UseVisualStyleBackColor = true;
            this._buttonItalic.Click += new System.EventHandler(this.OnMakeItalicClicked);
            // 
            // _buttonSelectColor
            // 
            this._buttonSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonSelectColor.Image = ((System.Drawing.Image)(resources.GetObject("_buttonSelectColor.Image")));
            this._buttonSelectColor.Location = new System.Drawing.Point(127, 3);
            this._buttonSelectColor.Name = "_buttonSelectColor";
            this._buttonSelectColor.Size = new System.Drawing.Size(35, 23);
            this._buttonSelectColor.TabIndex = 4;
            this._buttonSelectColor.UseVisualStyleBackColor = true;
            this._buttonSelectColor.Click += new System.EventHandler(this.OnSelectColorClicked);
            // 
            // _buttonFont
            // 
            this._buttonFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonFont.Location = new System.Drawing.Point(168, 3);
            this._buttonFont.Name = "_buttonFont";
            this._buttonFont.Size = new System.Drawing.Size(35, 23);
            this._buttonFont.TabIndex = 5;
            this._buttonFont.Text = "F";
            this._buttonFont.UseVisualStyleBackColor = true;
            this._buttonFont.Click += new System.EventHandler(this.OnSelectFontClicked);
            // 
            // _timer
            // 
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // RaceCommentsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonFont);
            this.Controls.Add(this._buttonSelectColor);
            this.Controls.Add(this._buttonItalic);
            this.Controls.Add(this._buttonUnderlined);
            this.Controls.Add(this._buttonMakeSelectionBold);
            this.Controls.Add(this._txtbox);
            this.Name = "RaceCommentsCtrl";
            this.Size = new System.Drawing.Size(370, 307);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _txtbox;
        private System.Windows.Forms.Button _buttonMakeSelectionBold;
        private System.Windows.Forms.Button _buttonUnderlined;
        private System.Windows.Forms.Button _buttonItalic;
        private System.Windows.Forms.Button _buttonSelectColor;
        private System.Windows.Forms.Button _buttonFont;
        private System.Windows.Forms.Timer _timer;
    }
}
