using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;

namespace CSAM_Manual
{
    public partial class frmMain : Form
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        PanelState currentPanelState = null;

        Image imgRawTH = null;
        Image imgRawBH = null;

        Image imgOverlayTH = null;
        Image imgOverlayBH = null;

        string fileNameTH = "";
        string fileNameBH = "";



        public frmMain(string sProgramVersion)
        {
            InitializeComponent();

            this.Text = "CSAM_Manual V" + sProgramVersion;
        }

        public CSAM_ManualRecipe LoadedRecipe
        {
            get { return ucRecipeEditor1.LoadedRecipe; } 
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                if (ucRecipeEditor1.LoadedRecipe == null)
                {
                    MessageBox.Show("Please load a recipe first.");
                    return;
                }

                currentPanelState = new PanelState("test", ucRecipeEditor1.LoadedRecipe);

                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.SelectedPath = ucRecipeEditor1.LoadedRecipe.DefaultFolderPath;
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        fileNameTH = fbd.SelectedPath + @"\" + LoadedRecipe.TH_AG1_Filename_Format;
                        ucTEMSMarker1.panelImageBoxTH.LoadImage(fileNameTH, PanelImageSides.TH, currentPanelState, LoadedRecipe);


                        fileNameBH = fbd.SelectedPath + @"\" + LoadedRecipe.BH_AG1_Filename_Format;
                        ucTEMSMarker1.panelImageBoxBH.LoadImage(fileNameBH, PanelImageSides.BH, currentPanelState, LoadedRecipe);


                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    }
                }



            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }


        }

    }
}
