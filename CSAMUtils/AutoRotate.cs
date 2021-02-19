using Cyotek.Windows.Forms;
using MathNet.Numerics.Statistics;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSAMUtils
{
    static class AutoRotate
    {

        public static void RotateImage(string inputFileFolderPath, string inputFileName, bool showMessageBoxes, ImageBox iboxRaw, ImageBox iboxProcessed, string outputFileFolderPath, string outputFileName)
        {
            double houghRotationOffsetAngle = 25.0;

            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                iboxProcessed.Image = null;
                iboxProcessed.Refresh();

                Mat src = new Mat(inputFileFolderPath + inputFileName, ImreadModes.Grayscale);

                iboxRaw.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);

                // Not needed if we read as grayscale to start with. 
                //Mat src8UC1 = new Mat();
                //src.ConvertTo(src8UC1, MatType.CV_8UC1);

                // I'm not sure why we do the gauss - It seems like everyone does it, it's cheap, so we do it. ~Ed
                Mat gauss = new Mat();
                Cv2.GaussianBlur(src, gauss, new OpenCvSharp.Size(3, 3), 2, 2);
                LogEvent("gauss", showMessageBoxes, gauss, iboxProcessed);

                // An attempt to get the contrast across the image to be somewhat uniform. 
                CLAHE claheFilter = Cv2.CreateCLAHE(4, new OpenCvSharp.Size(10, 10));
                Mat clahe = new Mat();
                claheFilter.Apply(gauss, clahe);
                LogEvent("clahe", showMessageBoxes, clahe, iboxProcessed);

                // An attempt to get the contrast across the image to be somewhat uniform. 
                Mat hist = new Mat();
                Cv2.EqualizeHist(gauss, hist);
                LogEvent("hist", showMessageBoxes, hist, iboxProcessed);



                // Grab a template from some middle part of the image. Eventually, the size and location of this 
                // template will be specified. It is very possible we'll have to grab multiple templates, as the 
                // location of the template may impact the accuracy of the rotation.
                // e.g. - if the template is an image of a damaged device (which may happen at any location), the calculated 
                // rotation may be wrong. Testing is required. 
                // The locations where the template matches will create an image with lines that are offset from 0/90 degrees.
                // This is because we can assume that the devices are orthogonal to one another, even if the image itself is 
                // offset rotationally. 
                Rect r1 = new Rect(new OpenCvSharp.Point(1000, 1000), new OpenCvSharp.Size(500, 300));
                var roi = new Mat(clahe, r1);
                Mat template = new Mat(new OpenCvSharp.Size(500, 300), MatType.CV_8UC1);
                roi.CopyTo(template);

                LogEvent("template", showMessageBoxes, template, iboxProcessed);


                Mat templateMatch = new Mat();

                Cv2.MatchTemplate(clahe, template, templateMatch, TemplateMatchModes.CCoeffNormed);
                LogEvent("templatematch", showMessageBoxes, templateMatch, iboxProcessed);

                Mat normalized = new Mat();
                normalized = templateMatch.Normalize(0, 255, NormTypes.MinMax);
                normalized.ConvertTo(normalized, MatType.CV_8UC1);
                LogEvent("normalized template match", showMessageBoxes, normalized, iboxProcessed);


                // This winnows down the number of matches.
                Mat thresh = new Mat();
                Cv2.Threshold(normalized, thresh, 200, 255, ThresholdTypes.Binary);
                LogEvent("threshold template match", showMessageBoxes, thresh, iboxProcessed);

                // rotate the image because hough doesn't work very well to find horizontal lines. 
                Mat rotatedThresh = new Mat();
                Cv2E.RotateDegrees(thresh, rotatedThresh, houghRotationOffsetAngle);
                LogEvent("rotatedThresh", showMessageBoxes, rotatedThresh, iboxProcessed);

                Mat erode = new Mat();
                Cv2.Erode(rotatedThresh, erode, new Mat());
                LogEvent("erode", showMessageBoxes, erode, iboxProcessed);


                LineSegmentPoint[] segHoughP = Cv2.HoughLinesP(rotatedThresh, 1, Math.PI / 1800, 2, 10, 600);


                Mat imageOutP = new Mat(src.Size(), MatType.CV_8UC3);

                // We're limiting the rotation correction to +/- 10 degrees. So we only care about hough lines that fall within 80 to 100 or 170 to 190
                List<double> anglesNear90 = new List<double>();
                List<double> anglesNear0 = new List<double>();

                foreach (LineSegmentPoint s in segHoughP)
                {
                    try
                    {
                        // Add lines to the image, if we're going to look at it.
                        if (showMessageBoxes) imageOutP.Line(s.P1, s.P2, Scalar.White, 1, LineTypes.AntiAlias, 0);

                        var radian = Math.Atan2((s.P1.Y - s.P2.Y), (s.P1.X - s.P2.X));
                        var angle = ((radian * (180 / Math.PI) + 360) % 360);

                        // We rotated the image because the hough algo does a bad job with small horizontal lines. So we take that rotation back out here. 
                        angle += houghRotationOffsetAngle;
                        angle -= 180;

                        if (angle > 80 && angle < 100)
                        {
                            anglesNear90.Add(angle);
                            if (showMessageBoxes) imageOutP.Line(s.P1, s.P2, Scalar.Red, 1, LineTypes.AntiAlias, 0);
                        }

                        if (angle > -10 && angle < 10)
                        {
                            anglesNear0.Add(angle);
                            if (showMessageBoxes) imageOutP.Line(s.P1, s.P2, Scalar.Orange, 1, LineTypes.AntiAlias, 0);
                        }
                    }
                    catch (Exception ex)
                    {
                        // there's always some infinity risk with atan, yes? Maybe. I don't want to fail on horizontal or vertical line edge cases.
                    }

                }

                double meanAngleNear0 = anglesNear0.Mean();
                double meanAngleNear90 = anglesNear90.Mean();

                // Use both the vertical and horizontal to calculate the image angle with a weighted average. It might be more accurate to use median instead of mean here.
                double rotationAngle = ((meanAngleNear0) * anglesNear0.Count + (meanAngleNear90 - 90) * anglesNear90.Count) / (anglesNear0.Count + anglesNear90.Count);

                LogEvent("hough lines", showMessageBoxes, imageOutP, iboxProcessed);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value. Less than 400msec in debug mode via IDE.
                TimeSpan ts = stopWatch.Elapsed;

                Mat rotated = new Mat();
                Cv2E.RotateDegrees(src, rotated, rotationAngle);

                rotated.SaveImage(outputFileFolderPath + outputFileName);

            }
            catch (Exception ex)
            {
            }


        }


        public static void LogEvent(string sMessage, bool showMessageBoxes, Mat mat, ImageBox ibox)
        {
            try
            {
                if (showMessageBoxes)
                {
                    if (mat != null && ibox != null)
                    {
                        ibox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
                    }

                    MessageBox.Show(sMessage);
                }

            }
            catch (Exception ex)
            {
            }
        }

    }
}
