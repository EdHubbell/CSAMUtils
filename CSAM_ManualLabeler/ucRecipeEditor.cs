using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace CSAM_Manual
{
    public partial class ucRecipeEditor : UserControl
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        private CSAM_ManualRecipe loadedRecipe = null;


        public ucRecipeEditor()
        {
            InitializeComponent();
        }


        public CSAM_ManualRecipe LoadedRecipe
        {
            get {
                return (CSAM_ManualRecipe)pgRecipe.SelectedObject;          
            }   
            set
            {
                loadedRecipe = value;
                pgRecipe.SelectedObject = loadedRecipe;
            }  
        }

        private void btnMakeNewRecipe_Click(object sender, EventArgs e)
        {
            LoadedRecipe = new CSAM_ManualRecipe();
        }

        private void btnLoadRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                LoadedRecipe = CSAM_ManualRecipe.OpenWithDialog(Program.RECIPE_PATH);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }

        private void btnSaveRecipeAs_Click(object sender, EventArgs e)
        {
            if (LoadedRecipe != null)
            {
                LoadedRecipe.SaveAsWithDialog(Program.RECIPE_PATH);
            }
            else
            {
                MessageBox.Show("No recipe loaded!");
            }
        }


        private void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            if (LoadedRecipe != null)
            {
                if (LoadedRecipe.FileFullPath.Length > 0)
                {
                    LoadedRecipe.Save(loadedRecipe.FileFullPath);
                }
                else
                {
                    LoadedRecipe.SaveAsWithDialog(Program.RECIPE_PATH);
                }
            }
            else
            {
                MessageBox.Show("No recipe loaded!");
            }
        }
    }
}
