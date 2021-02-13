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

namespace CSAMEval
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
        }


        private void LogEvent(string sMessage, bool showMessageBoxes)
        {

            if (showMessageBoxes)
            {
                MessageBox.Show(sMessage);
            }

        }


        private void RotateImage(string fileFolderPath, string fileName, bool showMessageBoxes)
        {


            Mat src = new Mat(fileFolderPath + fileName, ImreadModes.Grayscale);

            pbxCSAMImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);

            Mat src8UC1 = new Mat();

            src.ConvertTo(src8UC1, MatType.CV_8UC1);

            LogEvent("gauss", showMessageBoxes);
            Mat gauss = new Mat();
            Cv2.GaussianBlur(src8UC1, gauss, new OpenCvSharp.Size(3, 3), 2, 2);

            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(gauss);


            LogEvent("clahe", showMessageBoxes);
            CLAHE claheFilter = Cv2.CreateCLAHE(4, new OpenCvSharp.Size(10, 10));

            Mat clahe = new Mat();

            claheFilter.Apply(gauss, clahe);
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(clahe);


            Rect r1 = new Rect(new OpenCvSharp.Point(1000, 1000), new OpenCvSharp.Size(500, 300));
            var roi = new Mat(clahe, r1);
            Mat template = new Mat(new OpenCvSharp.Size(500, 300), MatType.CV_8UC1);
            roi.CopyTo(template);

            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(template);


            Mat templateMatch = new Mat();

            Cv2.MatchTemplate(clahe, template, templateMatch, TemplateMatchModes.CCoeffNormed);

            Mat converted = new Mat();

            // This doesn't really seem to normalize, as I don't see any values >250 in the output. 
            converted = templateMatch.Normalize(0, 255, NormTypes.MinMax);

            converted.ConvertTo(converted, MatType.CV_8UC1);



            LogEvent("template match", showMessageBoxes);
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(converted);



            LogEvent("otsu", showMessageBoxes);
            Mat otsu = new Mat();
            Cv2.Threshold(converted, otsu, 100, 255, ThresholdTypes.Binary);
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(otsu);


            LogEvent("erode", showMessageBoxes);
            Mat erode = new Mat();
            Cv2.Erode(otsu, erode, new Mat());
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(erode);


            LogEvent("hough", showMessageBoxes);

            LineSegmentPoint[] segHoughP = Cv2.HoughLinesP(erode, 1, Math.PI / 1800, 10, 500, 100);

            Mat imageOutP = src8UC1.EmptyClone();

            List<double> angles180 = new List<double>();

            foreach (LineSegmentPoint s in segHoughP)
            {

                var radian = Math.Atan2((s.P1.Y - s.P2.Y), (s.P1.X - s.P2.X));
                var angle = (radian * (180 / Math.PI) + 360) % 360;

                // The 270 and 90s all pile up on one another.
                if (angle > 240)
                {
                    angle = angle - 180;
                }

                if (angle > 175 && angle < 185)
                {
                    imageOutP.Line(s.P1, s.P2, Scalar.White, 1, LineTypes.AntiAlias, 0);
                    angles180.Add(angle);
                }

            }

            double meanAngle180 = angles180.Mean();

            double rotationAngle = meanAngle180 - 180;


            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageOutP);


            Mat rotated = new Mat();

            rotateImage(rotationAngle, 1, src8UC1, rotated);

            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rotated);

            string rotatedFilename = string.Format("Rotated_{0}deg_{1}.jpg", rotationAngle.ToString("0.00"), DateTime.Now.ToString("yyyyMMdd_hhmmss"));
            rotated.SaveImage(fileFolderPath + rotatedFilename);
        }


        private void btnAutoRotateImage_Click(object sender, EventArgs e)
        {
            RotateImage(@"..\..\..\ExampleFiles\", @"TH-01_AG4.jpg", cbxShowMessageboxes.Checked);

            // Just checking to see if a rotated image looks as if it has been properly rotated. The calculated re-rotation was .01, which is below the threshold of about .2 degrees.
            //RotateImage(@"..\..\..\ExampleFiles\", @"Rotated_0.30deg_20210213_030604.jpg", cbxShowMessageboxes.Checked);

        }


        private static void rotateImage(double angle, double scale, Mat src, Mat dst)
        {
            var imageCenter = new Point2f(src.Cols / 2f, src.Rows / 2f);
            var rotationMat = Cv2.GetRotationMatrix2D(imageCenter, angle, scale);
            Cv2.WarpAffine(src, dst, rotationMat, src.Size());
        }

    }
}
