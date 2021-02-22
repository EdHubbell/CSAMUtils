using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using NLog;

namespace CSAM_Manual
{
    public partial class ucTEMSMarker : UserControl
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        string fileNameTH = "";
        string fileNameBH = "";

        string FolderPath = "";
        string LotID = "";
        CSAM_ManualRecipe LoadedRecipe = null;

        string PanelStateFilename = "PanelState.xml";

        PanelState currentPanelState = null;

        public ucTEMSMarker()
        {
            InitializeComponent();
        }


        public ucPanelImageBox panelImageBoxTH
        {
            get { return pibTH; }
            set { pibTH = value; }
        }
        public ucPanelImageBox panelImageBoxBH
        {
            get { return pibBH; }
            set { pibBH = value; }
        }

        public void SetLotIDAndFolder(string lotID, string folderPath, CSAM_ManualRecipe recipe)
        {
            try
            {
                FolderPath = folderPath;
                LotID = lotID;
                LoadedRecipe = recipe;

                currentPanelState = new PanelState(lotID, LoadedRecipe);

                if (File.Exists(FolderPath + @"\" + PanelStateFilename))
                {
                    currentPanelState = PanelState.Load<PanelState>(FolderPath + @"\" + PanelStateFilename);
                }

                if (Directory.Exists(FolderPath))
                {
                    fileNameTH = FolderPath + @"\" + recipe.TH_AG1_Filename_Format;
                    this.panelImageBoxTH.LoadImage(fileNameTH, PanelImageSides.TH, currentPanelState, LoadedRecipe);


                    fileNameBH = FolderPath + @"\" + recipe.BH_AG1_Filename_Format;
                    this.panelImageBoxBH.LoadImage(fileNameBH, PanelImageSides.BH, currentPanelState, LoadedRecipe);
                }



            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }



        }



        private void btnSavePanelState_Click(object sender, EventArgs e)
        {
            try
            {
                currentPanelState.Save(FolderPath + @"\" + PanelStateFilename);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
