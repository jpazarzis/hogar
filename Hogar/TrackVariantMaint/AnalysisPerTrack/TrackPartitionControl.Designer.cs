﻿namespace TrackVariantMaint.AnalysisPerTrack
{
    partial class TrackPartitionControl
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
            this._graph = new NPlot.Windows.PlotSurface2D();
            this._labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _graph
            // 
            this._graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._graph.AutoScaleAutoGeneratedAxes = false;
            this._graph.AutoScaleTitle = false;
            this._graph.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._graph.DateTimeToolTip = false;
            this._graph.Legend = null;
            this._graph.LegendZOrder = -1;
            this._graph.Location = new System.Drawing.Point(14, 46);
            this._graph.Name = "_graph";
            this._graph.RightMenu = null;
            this._graph.ShowCoordinates = true;
            this._graph.Size = new System.Drawing.Size(575, 356);
            this._graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this._graph.TabIndex = 0;
            this._graph.Text = "plotSurface2D1";
            this._graph.Title = "";
            this._graph.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this._graph.XAxis1 = null;
            this._graph.XAxis2 = null;
            this._graph.YAxis1 = null;
            this._graph.YAxis2 = null;
            this._graph.Click += new System.EventHandler(this._graph_Click);
            // 
            // _labelDescription
            // 
            this._labelDescription.AutoSize = true;
            this._labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelDescription.Location = new System.Drawing.Point(21, 11);
            this._labelDescription.Name = "_labelDescription";
            this._labelDescription.Size = new System.Drawing.Size(51, 16);
            this._labelDescription.TabIndex = 1;
            this._labelDescription.Text = "label1";
            // 
            // TrackPartitionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._labelDescription);
            this.Controls.Add(this._graph);
            this.Name = "TrackPartitionControl";
            this.Size = new System.Drawing.Size(604, 419);
            this.Load += new System.EventHandler(this.TrackPartitionControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NPlot.Windows.PlotSurface2D _graph;
        private System.Windows.Forms.Label _labelDescription;
    }
}