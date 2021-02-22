
namespace CSAM_Manual
{
    partial class ucPanelImageBox
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
            this.iboxPanel = new Cyotek.Windows.Forms.ImageBox();
            this.cmsPanelImageBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMarkAsCorner = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFailTEMS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPassTEMS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetTEMS = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPanelImageBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // iboxPanel
            // 
            this.iboxPanel.ContextMenuStrip = this.cmsPanelImageBox;
            this.iboxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iboxPanel.Location = new System.Drawing.Point(0, 0);
            this.iboxPanel.Name = "iboxPanel";
            this.iboxPanel.Size = new System.Drawing.Size(270, 243);
            this.iboxPanel.TabIndex = 0;
            this.iboxPanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.iboxPanel_KeyDown);
            this.iboxPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iboxPanel_MouseMove);
            // 
            // cmsPanelImageBox
            // 
            this.cmsPanelImageBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMarkAsCorner,
            this.tsmiFailTEMS,
            this.tsmiPassTEMS,
            this.tsmiResetTEMS});
            this.cmsPanelImageBox.Name = "contextMenuStrip1";
            this.cmsPanelImageBox.Size = new System.Drawing.Size(157, 92);
            // 
            // tsmiMarkAsCorner
            // 
            this.tsmiMarkAsCorner.Name = "tsmiMarkAsCorner";
            this.tsmiMarkAsCorner.Size = new System.Drawing.Size(156, 22);
            this.tsmiMarkAsCorner.Text = "Mark As Corner";
            this.tsmiMarkAsCorner.Click += new System.EventHandler(this.tsmiMarkAsCorner_Click);
            // 
            // tsmiFailTEMS
            // 
            this.tsmiFailTEMS.Name = "tsmiFailTEMS";
            this.tsmiFailTEMS.Size = new System.Drawing.Size(156, 22);
            this.tsmiFailTEMS.Tag = "Fail";
            this.tsmiFailTEMS.Text = "Fail TEMS";
            this.tsmiFailTEMS.Click += new System.EventHandler(this.tsmiFailTEMS_Click);
            // 
            // tsmiPassTEMS
            // 
            this.tsmiPassTEMS.Name = "tsmiPassTEMS";
            this.tsmiPassTEMS.Size = new System.Drawing.Size(156, 22);
            this.tsmiPassTEMS.Tag = "Pass";
            this.tsmiPassTEMS.Text = "Pass TEMS";
            this.tsmiPassTEMS.Click += new System.EventHandler(this.tsmiPassTEMS_Click);
            // 
            // tsmiResetTEMS
            // 
            this.tsmiResetTEMS.Name = "tsmiResetTEMS";
            this.tsmiResetTEMS.Size = new System.Drawing.Size(156, 22);
            this.tsmiResetTEMS.Tag = "NA";
            this.tsmiResetTEMS.Text = "Reset TEMS";
            this.tsmiResetTEMS.Click += new System.EventHandler(this.tsmiResetTEMS_Click);
            // 
            // ucPanelImageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iboxPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanelImageBox";
            this.Size = new System.Drawing.Size(270, 243);
            this.cmsPanelImageBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.ImageBox iboxPanel;
        private System.Windows.Forms.ContextMenuStrip cmsPanelImageBox;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarkAsCorner;
        private System.Windows.Forms.ToolStripMenuItem tsmiFailTEMS;
        private System.Windows.Forms.ToolStripMenuItem tsmiPassTEMS;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetTEMS;
    }
}
