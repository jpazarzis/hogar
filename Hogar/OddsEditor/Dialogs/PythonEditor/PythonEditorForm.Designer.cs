using HogarControlLibrary;

namespace OddsEditor.Dialogs.PythonEditor
{
    partial class PythonEditorForm
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
            this._tbCode = new System.Windows.Forms.RichTextBox();
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.textBoxWithLineNumbersControl1 = new HogarControlLibrary.TextBoxWithLineNumbersControl();
            this.SuspendLayout();
            // 
            // _tbCode
            // 
            this._tbCode.AcceptsTab = true;
            this._tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tbCode.Location = new System.Drawing.Point(30, 12);
            this._tbCode.Name = "_tbCode";
            this._tbCode.Size = new System.Drawing.Size(630, 507);
            this._tbCode.TabIndex = 1;
            this._tbCode.Text = "";
            this._tbCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // _buttonOK
            // 
            this._buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonOK.Location = new System.Drawing.Point(678, 21);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(116, 52);
            this._buttonOK.TabIndex = 2;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonCancel.Location = new System.Drawing.Point(678, 90);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(116, 52);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxWithLineNumbersControl1
            // 
            this.textBoxWithLineNumbersControl1._SeeThroughMode_ = false;
            this.textBoxWithLineNumbersControl1.AutoSizing = true;
            this.textBoxWithLineNumbersControl1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxWithLineNumbersControl1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxWithLineNumbersControl1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.textBoxWithLineNumbersControl1.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.textBoxWithLineNumbersControl1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.textBoxWithLineNumbersControl1.BorderLines_Thickness = 1F;
            this.textBoxWithLineNumbersControl1.DockSide = HogarControlLibrary.TextBoxWithLineNumbersControl.LineNumberDockSide.Left;
            this.textBoxWithLineNumbersControl1.GridLines_Color = System.Drawing.Color.SlateGray;
            this.textBoxWithLineNumbersControl1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.textBoxWithLineNumbersControl1.GridLines_Thickness = 1F;
            this.textBoxWithLineNumbersControl1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.textBoxWithLineNumbersControl1.LineNrs_AntiAlias = true;
            this.textBoxWithLineNumbersControl1.LineNrs_AsHexadecimal = false;
            this.textBoxWithLineNumbersControl1.LineNrs_ClippedByItemRectangle = true;
            this.textBoxWithLineNumbersControl1.LineNrs_LeadingZeroes = true;
            this.textBoxWithLineNumbersControl1.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.textBoxWithLineNumbersControl1.Location = new System.Drawing.Point(12, 12);
            this.textBoxWithLineNumbersControl1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxWithLineNumbersControl1.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.textBoxWithLineNumbersControl1.MarginLines_Side = HogarControlLibrary.TextBoxWithLineNumbersControl.LineNumberDockSide.Right;
            this.textBoxWithLineNumbersControl1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.textBoxWithLineNumbersControl1.MarginLines_Thickness = 1F;
            this.textBoxWithLineNumbersControl1.Name = "textBoxWithLineNumbersControl1";
            this.textBoxWithLineNumbersControl1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.textBoxWithLineNumbersControl1.ParentRichTextBox = this._tbCode;
            this.textBoxWithLineNumbersControl1.Show_BackgroundGradient = true;
            this.textBoxWithLineNumbersControl1.Show_BorderLines = true;
            this.textBoxWithLineNumbersControl1.Show_GridLines = true;
            this.textBoxWithLineNumbersControl1.Show_LineNrs = true;
            this.textBoxWithLineNumbersControl1.Show_MarginLines = true;
            this.textBoxWithLineNumbersControl1.Size = new System.Drawing.Size(17, 507);
            this.textBoxWithLineNumbersControl1.TabIndex = 0;
            // 
            // PythonEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 531);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this._tbCode);
            this.Controls.Add(this.textBoxWithLineNumbersControl1);
            this.Name = "PythonEditorForm";
            this.Text = "PythonEditorForm";
            this.Load += new System.EventHandler(this.PythonEditorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxWithLineNumbersControl textBoxWithLineNumbersControl1;
        private System.Windows.Forms.RichTextBox _tbCode;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;

    }
}