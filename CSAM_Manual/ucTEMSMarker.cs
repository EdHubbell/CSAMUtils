using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace CSAM_Manual
{
    public partial class ucTEMSMarker : UserControl
    {
        public ucTEMSMarker()
        {
            InitializeComponent();
        }

        public ImageBox imageBoxTH
        {
            get
            {
                return imageBoxTH;
            }
            set
            {
                imageBoxTH = value;
            }
        }

        public ImageBox imageBoxBH
        {
            get
            {
                return imageBoxBH;
            }
            set
            {
                imageBoxBH = value;
            }
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


    }
}
