
namespace CSAM_Manual
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpImages = new System.Windows.Forms.TabPage();
            this.tpRecipe = new System.Windows.Forms.TabPage();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucRecipeEditor1 = new CSAM_Manual.ucRecipeEditor();
            this.ucTEMSMarker1 = new CSAM_Manual.ucTEMSMarker();
            this.tlpMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpImages.SuspendLayout();
            this.tpRecipe.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.tcMain, 0, 0);
            this.tlpMain.Controls.Add(this.pnlFooter, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(906, 501);
            this.tlpMain.TabIndex = 0;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpImages);
            this.tcMain.Controls.Add(this.tpRecipe);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(3, 3);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(900, 455);
            this.tcMain.TabIndex = 0;
            // 
            // tpImages
            // 
            this.tpImages.Controls.Add(this.ucTEMSMarker1);
            this.tpImages.Location = new System.Drawing.Point(4, 22);
            this.tpImages.Name = "tpImages";
            this.tpImages.Padding = new System.Windows.Forms.Padding(3);
            this.tpImages.Size = new System.Drawing.Size(892, 429);
            this.tpImages.TabIndex = 0;
            this.tpImages.Text = "Images";
            this.tpImages.UseVisualStyleBackColor = true;
            // 
            // tpRecipe
            // 
            this.tpRecipe.Controls.Add(this.ucRecipeEditor1);
            this.tpRecipe.Location = new System.Drawing.Point(4, 22);
            this.tpRecipe.Name = "tpRecipe";
            this.tpRecipe.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecipe.Size = new System.Drawing.Size(892, 429);
            this.tpRecipe.TabIndex = 1;
            this.tpRecipe.Text = "Recipe";
            this.tpRecipe.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(3, 464);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(900, 34);
            this.pnlFooter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open Folder";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // ucRecipeEditor1
            // 
            this.ucRecipeEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRecipeEditor1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucRecipeEditor1.LoadedRecipe = null;
            this.ucRecipeEditor1.Location = new System.Drawing.Point(3, 3);
            this.ucRecipeEditor1.Name = "ucRecipeEditor1";
            this.ucRecipeEditor1.Size = new System.Drawing.Size(886, 423);
            this.ucRecipeEditor1.TabIndex = 0;
            // 
            // ucTEMSMarker1
            // 
            this.ucTEMSMarker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTEMSMarker1.Location = new System.Drawing.Point(3, 3);
            this.ucTEMSMarker1.Name = "ucTEMSMarker1";
            this.ucTEMSMarker1.Size = new System.Drawing.Size(886, 423);
            this.ucTEMSMarker1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 525);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "CSAM_Manual";
            this.tlpMain.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpImages.ResumeLayout(false);
            this.tpRecipe.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpImages;
        private System.Windows.Forms.TabPage tpRecipe;
        private ucRecipeEditor ucRecipeEditor1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private ucTEMSMarker ucTEMSMarker1;
    }
}

