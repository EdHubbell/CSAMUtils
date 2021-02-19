using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using MathNet.Numerics.Statistics;

namespace CSAMUtils
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
        }


        private void btnAutoRotateImage_Click(object sender, EventArgs e)
        {

            string outputFileName = string.Format("Rotated_{0}.jpg", DateTime.Now.ToString("yyyyMMdd_hhmmss"));
            AutoRotate.RotateImage (@"..\..\..\ExampleFiles\", @"ExampleImage.jpg", cbxShowMessageboxes.Checked, pbxCSAMImage , pbxProcessed , @"..\..\..\TempFiles\", outputFileName);

            // Just checking to see if a rotated image looks as if it has been properly rotated. The calculated re-rotation was .01, which is below the threshold of about .2 degrees.
            //RotateImage(@"..\..\..\ExampleFiles\", @"Rotated_0.30deg_20210213_030604.jpg", cbxShowMessageboxes.Checked);

        }


        private static void rotateImage(double angle, double scale, Mat src, Mat dst)
        {
            var imageCenter = new Point2f(src.Cols / 2f, src.Rows / 2f);
            var rotationMat = Cv2.GetRotationMatrix2D(imageCenter, angle, scale);
            Cv2.WarpAffine(src, dst, rotationMat, src.Size());
        }

        private void btnMatchTemplate_Click(object sender, EventArgs e)
        {
            TemplateMatch.MatchTranspTemplate(@"..\..\..\ExampleFiles\Templates\ExampleRotated.jpg", @"..\..\..\ExampleFiles\Templates\renderedTemplate.png", true, pbxCSAMImage , pbxProcessed );
        }
    }
}
