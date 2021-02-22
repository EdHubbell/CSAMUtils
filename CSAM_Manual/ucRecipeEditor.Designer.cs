
namespace CSAM_Manual
{
    partial class ucRecipeEditor
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pgRecipe = new System.Windows.Forms.PropertyGrid();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnMakeNewRecipe = new System.Windows.Forms.Button();
            this.btnSaveRecipeAs = new System.Windows.Forms.Button();
            this.btnSaveRecipe = new System.Windows.Forms.Button();
            this.btnLoadRecipe = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.Controls.Add(this.pnlLeft, 0, 1);
            this.tlpMain.Controls.Add(this.pnlRight, 1, 1);
            this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(683, 432);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pgRecipe);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 43);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(477, 386);
            this.pnlLeft.TabIndex = 0;
            // 
            // pgRecipe
            // 
            this.pgRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgRecipe.Location = new System.Drawing.Point(0, 0);
            this.pgRecipe.Name = "pgRecipe";
            this.pgRecipe.Size = new System.Drawing.Size(477, 386);
            this.pgRecipe.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnMakeNewRecipe);
            this.pnlRight.Controls.Add(this.btnSaveRecipeAs);
            this.pnlRight.Controls.Add(this.btnSaveRecipe);
            this.pnlRight.Controls.Add(this.btnLoadRecipe);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(486, 43);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(194, 386);
            this.pnlRight.TabIndex = 1;
            // 
            // btnMakeNewRecipe
            // 
            this.btnMakeNewRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMakeNewRecipe.Location = new System.Drawing.Point(3, 229);
            this.btnMakeNewRecipe.Name = "btnMakeNewRecipe";
            this.btnMakeNewRecipe.Size = new System.Drawing.Size(188, 34);
            this.btnMakeNewRecipe.TabIndex = 3;
            this.btnMakeNewRecipe.Text = "Make New Recipe";
            this.btnMakeNewRecipe.UseVisualStyleBackColor = true;
            this.btnMakeNewRecipe.Click += new System.EventHandler(this.btnMakeNewRecipe_Click);
            // 
            // btnSaveRecipeAs
            // 
            this.btnSaveRecipeAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveRecipeAs.Location = new System.Drawing.Point(3, 309);
            this.btnSaveRecipeAs.Name = "btnSaveRecipeAs";
            this.btnSaveRecipeAs.Size = new System.Drawing.Size(188, 34);
            this.btnSaveRecipeAs.TabIndex = 2;
            this.btnSaveRecipeAs.Text = "Save Recipe As";
            this.btnSaveRecipeAs.UseVisualStyleBackColor = true;
            this.btnSaveRecipeAs.Click += new System.EventHandler(this.btnSaveRecipeAs_Click);
            // 
            // btnSaveRecipe
            // 
            this.btnSaveRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveRecipe.Location = new System.Drawing.Point(3, 349);
            this.btnSaveRecipe.Name = "btnSaveRecipe";
            this.btnSaveRecipe.Size = new System.Drawing.Size(188, 34);
            this.btnSaveRecipe.TabIndex = 1;
            this.btnSaveRecipe.Text = "Save Recipe";
            this.btnSaveRecipe.UseVisualStyleBackColor = true;
            this.btnSaveRecipe.Click += new System.EventHandler(this.btnSaveRecipe_Click);
            // 
            // btnLoadRecipe
            // 
            this.btnLoadRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadRecipe.Location = new System.Drawing.Point(3, 269);
            this.btnLoadRecipe.Name = "btnLoadRecipe";
            this.btnLoadRecipe.Size = new System.Drawing.Size(188, 34);
            this.btnLoadRecipe.TabIndex = 0;
            this.btnLoadRecipe.Text = "Load Recipe";
            this.btnLoadRecipe.UseVisualStyleBackColor = true;
            this.btnLoadRecipe.Click += new System.EventHandler(this.btnLoadRecipe_Click);
            // 
            // pnlHeader
            // 
            this.tlpMain.SetColumnSpan(this.pnlHeader, 2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(677, 34);
            this.pnlHeader.TabIndex = 2;
            // 
            // ucRecipeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucRecipeEditor";
            this.Size = new System.Drawing.Size(683, 432);
            this.tlpMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PropertyGrid pgRecipe;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnSaveRecipe;
        private System.Windows.Forms.Button btnLoadRecipe;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnSaveRecipeAs;
        private System.Windows.Forms.Button btnMakeNewRecipe;
    }
}
