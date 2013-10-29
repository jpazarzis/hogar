namespace OddsEditor.Dialogs
{
    partial class CreateSippFileForm
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
            this._buttonCreate = new System.Windows.Forms.Button();
            this._txtboxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonCreate
            // 
            this._buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonCreate.Location = new System.Drawing.Point(12, 12);
            this._buttonCreate.Name = "_buttonCreate";
            this._buttonCreate.Size = new System.Drawing.Size(248, 68);
            this._buttonCreate.TabIndex = 0;
            this._buttonCreate.Text = "Create Sipp File";
            this._buttonCreate.UseVisualStyleBackColor = true;
            this._buttonCreate.Click += new System.EventHandler(this._buttonCreate_Click);
            // 
            // _txtboxMessage
            // 
            this._txtboxMessage.Location = new System.Drawing.Point(12, 111);
            this._txtboxMessage.Multiline = true;
            this._txtboxMessage.Name = "_txtboxMessage";
            this._txtboxMessage.ReadOnly = true;
            this._txtboxMessage.Size = new System.Drawing.Size(389, 183);
            this._txtboxMessage.TabIndex = 6;
            // 
            // CreateSippFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 322);
            this.Controls.Add(this._txtboxMessage);
            this.Controls.Add(this._buttonCreate);
            this.Name = "CreateSippFileForm";
            this.Text = "CreateSippFileForm";
            this.Load += new System.EventHandler(this.CreateSippFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonCreate;
        private System.Windows.Forms.TextBox _txtboxMessage;
    }
}