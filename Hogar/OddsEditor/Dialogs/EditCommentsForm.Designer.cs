namespace OddsEditor.Dialogs
{
    partial class EditCommentsForm
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
            this._tbComments = new System.Windows.Forms.TextBox();
            this._bOK = new System.Windows.Forms.Button();
            this._bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tbComments
            // 
            this._tbComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbComments.Location = new System.Drawing.Point(12, 23);
            this._tbComments.Multiline = true;
            this._tbComments.Name = "_tbComments";
            this._tbComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._tbComments.Size = new System.Drawing.Size(649, 227);
            this._tbComments.TabIndex = 0;
            // 
            // _bOK
            // 
            this._bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._bOK.Location = new System.Drawing.Point(13, 267);
            this._bOK.Name = "_bOK";
            this._bOK.Size = new System.Drawing.Size(75, 23);
            this._bOK.TabIndex = 1;
            this._bOK.Text = "OK";
            this._bOK.UseVisualStyleBackColor = true;
            this._bOK.Click += new System.EventHandler(this.OnOK);
            // 
            // _bCancel
            // 
            this._bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._bCancel.Location = new System.Drawing.Point(104, 267);
            this._bCancel.Name = "_bCancel";
            this._bCancel.Size = new System.Drawing.Size(75, 23);
            this._bCancel.TabIndex = 2;
            this._bCancel.Text = "Cancel";
            this._bCancel.UseVisualStyleBackColor = true;
            this._bCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // EditCommentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 305);
            this.Controls.Add(this._bCancel);
            this.Controls.Add(this._bOK);
            this.Controls.Add(this._tbComments);
            this.Name = "EditCommentsForm";
            this.Text = "EditCommentsForm";
            this.Load += new System.EventHandler(this.OnLoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbComments;
        private System.Windows.Forms.Button _bOK;
        private System.Windows.Forms.Button _bCancel;
    }
}