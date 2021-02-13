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

        private void btnRun_Click(object sender, EventArgs e)
        {

            ProcessFile(@"..\..\..\ExampleFiles\TH-01_AG4.jpg");
        }


        private async void ProcessFile(string fileFullPath)
        {
            try
            {
                Mat src = new Mat(fileFullPath, ImreadModes.Grayscale);

                pbxCSAMImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);

                Mat dst = new Mat();

                src.ConvertTo(dst, MatType.CV_8UC1);


                MessageBox.Show("gauss");

                Mat gauss = new Mat();
                Cv2.GaussianBlur(dst, gauss, new OpenCvSharp.Size(3, 3), 2, 2);

                pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(gauss);


                MessageBox.Show("clahe");

                CLAHE claheFilter = Cv2.CreateCLAHE(4, new OpenCvSharp.Size(10, 10));

                Mat clahe = new Mat();

                claheFilter.Apply(gauss, clahe);
                pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(clahe);



                MessageBox.Show("otsu");

                Mat otsu = new Mat();
                Cv2.Threshold(clahe, otsu, 100, 255, ThresholdTypes.Otsu);
                pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(otsu);


                //MessageBox.Show("erode");
                //Mat erode = new Mat();
                //Cv2.Erode(otsu, erode, new Mat());
                //pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(erode);

                //MessageBox.Show("Next step");
                //Mat inv = new Mat();
                //Cv2.Threshold(otsu, inv, 100, 255, ThresholdTypes.BinaryInv );
                //pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inv);
                //MessageBox.Show("Next step");

                //Cv2.Canny(dst, dst, 50, 200);
                //pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);

                MessageBox.Show("sobelx");
                Mat sobelX = new Mat();

                Cv2.Sobel(otsu, sobelX, MatType.CV_8UC1, 1, 0, 5);

                pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(sobelX);

                //MessageBox.Show("Next step");


                //Mat sobelY = new Mat();

                //Cv2.Sobel(clahe, sobelY, MatType.CV_8UC1, 0, 1, 9);
                //pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(sobelY);


                //MessageBox.Show("Next step");

                //Mat sobelXY = new Mat();

                //Cv2.Sobel(clahe, sobelXY, MatType.CV_8UC1, 1, 1, 9);
                //pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(sobelXY);


                //MessageBox.Show("Next step");

                //               Mat laplacian = new Mat();

                //Cv2.Laplacian(dst, laplacian, MatType.CV_8UC1);
                //pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(laplacian);

                ////                img_sobelx = cv2.Sobel(img_gaussian, cv2.CV_8U, 1, 0, ksize = 5)
                ////img_sobely = cv2.Sobel(img_gaussian, cv2.CV_8U, 0, 1, ksize = 5)

                MessageBox.Show("canny");
                Mat canny = new Mat();

                Cv2.Canny(otsu, canny, 95, 100);
                pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(canny);

                MessageBox.Show("hough");

                LineSegmentPoint[] segHoughP = Cv2.HoughLinesP(sobelX, 1, Math.PI / 1800, 10, 50, 10);

                Mat imageOutP = dst.EmptyClone();

                List<double> angles = new List<double>();

                foreach (LineSegmentPoint s in segHoughP)
                {
                    //                    if (s.Length() < 200)
                    //                    {

                    var radian = Math.Atan2((s.P1.Y - s.P2.Y), (s.P1.X - s.P2.X));
                    var angle = (radian * (180 / Math.PI) + 360) % 360;

                    if (angle > 180)
                    {
                        angle = angle - 180;
                    }

                    if (angle > 80 && angle < 100)
                    {
                        imageOutP.Line(s.P1, s.P2, Scalar.White, 1, LineTypes.AntiAlias, 0);
                        angles.Add(angle);
                    }

                    //                  }
                }

                double medianAngle = angles.Mean();


                pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageOutP);

                //using (new Window("Edges", edges))
                //using (new Window("HoughLinesP", imageOutP))
                //{
                //    Window.WaitKey(0);
                //}


                //CvSeq SeqLines;
                //SeqLines = edgeImage.HoughLines2(storage, HoughLinesMethod.Probabilistic, 1, Math.PI / 180, 80, 30, 10);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void TemplateMatch(string fileFullPath)
        {


            Mat src = new Mat(fileFullPath, ImreadModes.Grayscale);

            pbxCSAMImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);

            Mat dst = new Mat();

            src.ConvertTo(dst, MatType.CV_8UC1);


            MessageBox.Show("gauss");

            Mat gauss = new Mat();
            Cv2.GaussianBlur(dst, gauss, new OpenCvSharp.Size(3, 3), 2, 2);

            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(gauss);


            MessageBox.Show("clahe");

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
            converted = templateMatch.Normalize(0, 255, NormTypes.MinMax  );

            converted.ConvertTo(converted, MatType.CV_8UC1);


          //  Mat grayscaleMat = Mat.FromImageData(templateMatch, ImreadModes.Grayscale );

            //            Cv2.ImShow("Matches", templateMatch);

            
            
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(converted);


            MessageBox.Show("otsu");

            Mat otsu = new Mat();
            Cv2.Threshold(converted, otsu, 100, 255, ThresholdTypes.Binary  );
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(otsu);


            MessageBox.Show("erode");
            Mat erode = new Mat();
            Cv2.Erode(otsu, erode, new Mat());
            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(erode);


            MessageBox.Show("hough");

            LineSegmentPoint[] segHoughP = Cv2.HoughLinesP(erode, 1, Math.PI / 1800, 10, 500, 100);

            Mat imageOutP = dst.EmptyClone();

            List<double> angles = new List<double>();

            foreach (LineSegmentPoint s in segHoughP)
            {
                //                    if (s.Length() < 200)
                //                    {

                var radian = Math.Atan2((s.P1.Y - s.P2.Y), (s.P1.X - s.P2.X));
                var angle = (radian * (180 / Math.PI) + 360) % 360;

                // The 270 and 90s all pile up on one another.
                if (angle > 240)
                {
                    angle = angle - 180;
                }

                //if (angle > 80 && angle < 100)
                //{
                    imageOutP.Line(s.P1, s.P2, Scalar.White, 1, LineTypes.AntiAlias, 0);
                    angles.Add(angle);
                //}

                //                  }
            }

            double medianAngle = angles.Mean();

            pbxProcessed.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageOutP);


        }


        private void btnTemplateMatch_Click(object sender, EventArgs e)
        {
            TemplateMatch(@"..\..\..\ExampleFiles\TH-01_AG4.jpg");




        }
    }
}
