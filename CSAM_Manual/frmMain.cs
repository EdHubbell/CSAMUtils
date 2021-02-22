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
using Ookii.Dialogs.WinForms;

namespace CSAM_Manual
{
    public partial class frmMain : Form
    {
        Logger logger = LogManager.GetCurrentClassLogger();

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


                using (VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog())
                {
                   // dialog.SelectedPath  = LoadedRecipe.DefaultFolderPath + @"\";
                    //dialog.InitialDirectory = LoadedRecipe.DefaultFolderPath;
                    //dialog.IsFolderPicker = true;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string sFolderName = dialog.SelectedPath ;

                        string lotID = sFolderName.Substring(sFolderName.LastIndexOf(@"\") + 1, sFolderName.Length - (sFolderName.LastIndexOf(@"\") +1) );

                        ucTEMSMarker1.SetLotIDAndFolder(lotID, sFolderName, LoadedRecipe);
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
