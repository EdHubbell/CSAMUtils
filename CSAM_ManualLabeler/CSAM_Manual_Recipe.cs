using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using NLog;

namespace CSAM_Manual
{


    [Serializable]
    [XmlRoot("config")]
    public class CSAM_ManualRecipe : XMLBaseObject
    {
        [XmlIgnore]
        public string FileFullPath = "";



        [Category("Panel")]
        [Browsable(true)]
        [Description("The number of TEMS in the X-direction of the panel")]
        public int TEMS_Count_X { get; set; } = 12;

        [Category("Panel")]
        [Browsable(true)]
        [Description("The number of TEMS in the Y-direction of the panel")]
        public int TEMS_Count_Y { get; set; } = 30;

        [Category("Panel")]
        [Browsable(true)]
        [Description("BH AG1 Filename string format")]
        public string BH_AG1_Filename_Format { get; set; } = @"BH-01_CSAM2_AG1.jpg";

        [Category("Panel")]
        [Browsable(true)]
        [Description("BH AG4 Filename string format")]
        public string BH_AG4_Filename_Format { get; set; } = @"BH-01_CSAM2_AG4.jpg";

        [Category("Panel")]
        [Browsable(true)]
        [Description("TH AG1 Filename string format")]
        public string TH_AG1_Filename_Format { get; set; } = @"TH-01_CSAM2_AG1.jpg";

        [Category("Panel")]
        [Browsable(true)]
        [Description("TH AG4 Filename string format")]
        public string TH_AG4_Filename_Format { get; set; } = @"TH-01_CSAM2_AG1.jpg";



        public void SaveAsWithDialog(string initialDirectory)
        {
            try
            {

                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.InitialDirectory = initialDirectory;
                    saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.FileFullPath = saveFileDialog1.FileName;
                        this.Save(this.FileFullPath);
                    }

                }

           }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }


        public static CSAM_ManualRecipe OpenWithDialog(string initialDirectory)
        {
            CSAM_ManualRecipe recipe = null;
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.InitialDirectory = initialDirectory;
                    openFileDialog.Filter = "xml files (*.xml)|*.xml";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        recipe = CSAM_ManualRecipe.Load(openFileDialog.FileName);
                        recipe.FileFullPath = openFileDialog.FileName;
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return recipe;
        }


        public static CSAM_ManualRecipe Load(string recipeFileFullPath)
        {
            return Load("", recipeFileFullPath);
        }


        public static CSAM_ManualRecipe Load(string recipePath, string recipeFileName)
        {
            CSAM_ManualRecipe oCSAM_ManualRecipe = null;
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Debug("entering {0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
                XmlSerializer serializer = new XmlSerializer(typeof(CSAM_ManualRecipe));

                // Could do some handling here, but I don't think it buys us much. There are .UnknownNode, .UnknownElement, and a few other .Unknown methods.
                // AddHandler serializer.UnknownNode

                StreamReader reader = new StreamReader(recipePath + recipeFileName);
                oCSAM_ManualRecipe = (CSAM_ManualRecipe)serializer.Deserialize(reader);
                oCSAM_ManualRecipe.FileFullPath = recipePath + recipeFileName;
                reader.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                logger.Debug("exiting  {0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
            }

            return oCSAM_ManualRecipe;
        }




    }

}
