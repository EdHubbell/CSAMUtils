
namespace CSAM_Manual
{
    partial class ucTEMSMarker
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTH = new System.Windows.Forms.TabPage();
            this.tpBH = new System.Windows.Forms.TabPage();
            this.pibTH = new CSAM_Manual.ucPanelImageBox();
            this.pibBH = new CSAM_Manual.ucPanelImageBox();
            this.tlpMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTH.SuspendLayout();
            this.tpBH.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.Controls.Add(this.tabControl1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(538, 334);
            this.tlpMain.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTH);
            this.tabControl1.Controls.Add(this.tpBH);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tlpMain.SetRowSpan(this.tabControl1, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(332, 328);
            this.tabControl1.TabIndex = 0;
            // 
            // tpTH
            // 
            this.tpTH.Controls.Add(this.pibTH);
            this.tpTH.Location = new System.Drawing.Point(4, 22);
            this.tpTH.Name = "tpTH";
            this.tpTH.Padding = new System.Windows.Forms.Padding(3);
            this.tpTH.Size = new System.Drawing.Size(324, 302);
            this.tpTH.TabIndex = 0;
            this.tpTH.Text = "TH";
            this.tpTH.UseVisualStyleBackColor = true;
            // 
            // tpBH
            // 
            this.tpBH.Controls.Add(this.pibBH);
            this.tpBH.Location = new System.Drawing.Point(4, 22);
            this.tpBH.Name = "tpBH";
            this.tpBH.Padding = new System.Windows.Forms.Padding(3);
            this.tpBH.Size = new System.Drawing.Size(324, 302);
            this.tpBH.TabIndex = 1;
            this.tpBH.Text = "BH";
            this.tpBH.UseVisualStyleBackColor = true;
            // 
            // pibTH
            // 
            this.pibTH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pibTH.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pibTH.Location = new System.Drawing.Point(3, 3);
            this.pibTH.Name = "pibTH";
            this.pibTH.Size = new System.Drawing.Size(318, 296);
            this.pibTH.TabIndex = 0;
            // 
            // pibBH
            // 
            this.pibBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pibBH.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pibBH.Location = new System.Drawing.Point(3, 3);
            this.pibBH.Name = "pibBH";
            this.pibBH.Size = new System.Drawing.Size(318, 296);
            this.pibBH.TabIndex = 1;
            // 
            // ucTEMSMarker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ucTEMSMarker";
            this.Size = new System.Drawing.Size(538, 334);
            this.tlpMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpTH.ResumeLayout(false);
            this.tpBH.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTH;
        private System.Windows.Forms.TabPage tpBH;
        private ucPanelImageBox pibTH;
        private ucPanelImageBox pibBH;
    }
}
