
namespace CSAMEval
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pbxProcessed = new Cyotek.Windows.Forms.ImageBox();
            this.pbxCSAMImage = new Cyotek.Windows.Forms.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAutoRotateImage = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.pbxProcessed, 1, 1);
            this.tlpMain.Controls.Add(this.pbxCSAMImage, 0, 1);
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(6);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpMain.Size = new System.Drawing.Size(1600, 841);
            this.tlpMain.TabIndex = 2;
            // 
            // pbxProcessed
            // 
            this.pbxProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxProcessed.Location = new System.Drawing.Point(806, 83);
            this.pbxProcessed.Margin = new System.Windows.Forms.Padding(6);
            this.pbxProcessed.Name = "pbxProcessed";
            this.pbxProcessed.Size = new System.Drawing.Size(788, 714);
            this.pbxProcessed.TabIndex = 3;
            // 
            // pbxCSAMImage
            // 
            this.pbxCSAMImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCSAMImage.Location = new System.Drawing.Point(6, 83);
            this.pbxCSAMImage.Margin = new System.Windows.Forms.Padding(6);
            this.pbxCSAMImage.Name = "pbxCSAMImage";
            this.pbxCSAMImage.Size = new System.Drawing.Size(788, 714);
            this.pbxCSAMImage.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAutoRotateImage);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 71);
            this.panel1.TabIndex = 6;
            // 
            // btnAutoRotateImage
            // 
            this.btnAutoRotateImage.Location = new System.Drawing.Point(233, 11);
            this.btnAutoRotateImage.Margin = new System.Windows.Forms.Padding(6);
            this.btnAutoRotateImage.Name = "btnAutoRotateImage";
            this.btnAutoRotateImage.Size = new System.Drawing.Size(261, 35);
            this.btnAutoRotateImage.TabIndex = 5;
            this.btnAutoRotateImage.Text = "AutoRotateImage";
            this.btnAutoRotateImage.UseVisualStyleBackColor = true;
            this.btnAutoRotateImage.Click += new System.EventHandler(this.btnTemplateMatch_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(45, 6);
            this.btnRun.Margin = new System.Windows.Forms.Padding(6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(150, 44);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMain";
            this.Text = "CSAMEval";
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnRun;
        private Cyotek.Windows.Forms.ImageBox pbxProcessed;
        private Cyotek.Windows.Forms.ImageBox pbxCSAMImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAutoRotateImage;
    }
}

