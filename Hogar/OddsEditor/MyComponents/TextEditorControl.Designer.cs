namespace OddsEditor.MyComponents
{
    partial class TextEditorControl
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
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Interval = 5000;
            this._timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // _txtbox
            // 
            this._txtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtbox.Location = new System.Drawing.Point(0, 0);
            this._txtbox.Multiline = true;
            this._txtbox.Name = "_txtbox";
            this._txtbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtbox.Size = new System.Drawing.Size(526, 384);
            this._txtbox.TabIndex = 0;
            this._txtbox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // TextEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtbox);
            this.Name = "TextEditorControl";
            this.Size = new System.Drawing.Size(526, 384);
            this.Load += new System.EventHandler(this.OnInitialLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.TextBox _txtbox;
    }
}
