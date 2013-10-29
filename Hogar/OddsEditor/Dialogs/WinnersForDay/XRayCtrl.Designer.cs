namespace OddsEditor.Dialogs.WinnersForDay
{
    partial class XRayCtrl
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
            this._twoWayTracker1 = new HogarControlLibrary.TwoWayTracker();
            this._timeComparisonCtrl = new OddsEditor.Dialogs.WinnersForDay.TimeComparisonCtrl();
            this._labelHorseName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _twoWayTracker1
            // 
            this._twoWayTracker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._twoWayTracker1.FromDate = new System.DateTime(2010, 6, 8, 14, 12, 48, 848);
            this._twoWayTracker1.IndexBorderWidth = 10;
            this._twoWayTracker1.Location = new System.Drawing.Point(4, 4);
            this._twoWayTracker1.Name = "_twoWayTracker1";
            this._twoWayTracker1.Size = new System.Drawing.Size(242, 24);
            this._twoWayTracker1.TabIndex = 0;
            this._twoWayTracker1.Text = "twoWayTracker1";
            this._twoWayTracker1.ToDate = new System.DateTime(2010, 6, 8, 14, 12, 48, 848);
            this._twoWayTracker1.DateChanged += new System.EventHandler(this.OnDateChanged);
            // 
            // _timeComparisonCtrl
            // 
            this._timeComparisonCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._timeComparisonCtrl.Location = new System.Drawing.Point(3, 58);
            this._timeComparisonCtrl.Name = "_timeComparisonCtrl";
            this._timeComparisonCtrl.Size = new System.Drawing.Size(243, 91);
            this._timeComparisonCtrl.TabIndex = 1;
            // 
            // _labelHorseName
            // 
            this._labelHorseName.AutoSize = true;
            this._labelHorseName.Location = new System.Drawing.Point(17, 39);
            this._labelHorseName.Name = "_labelHorseName";
            this._labelHorseName.Size = new System.Drawing.Size(0, 13);
            this._labelHorseName.TabIndex = 2;
            // 
            // XRayCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._labelHorseName);
            this.Controls.Add(this._timeComparisonCtrl);
            this.Controls.Add(this._twoWayTracker1);
            this.Name = "XRayCtrl";
            this.Size = new System.Drawing.Size(249, 152);
            this.Load += new System.EventHandler(this.XRayCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HogarControlLibrary.TwoWayTracker _twoWayTracker1;
        private TimeComparisonCtrl _timeComparisonCtrl;
        private System.Windows.Forms.Label _labelHorseName;
    }
}
