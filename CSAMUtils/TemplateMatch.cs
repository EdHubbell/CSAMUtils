using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Cyotek.Windows.Forms;
using System.Windows.Forms;

namespace CSAMUtils
{
    static class TemplateMatch
    {

        public static void MatchTranspTemplate(string sFilePath, string sTemplateFilePath, bool showMessageBoxes, ImageBox rawImageBox, ImageBox processedImageBox)
        {

            Mat src = new Mat(sFilePath, ImreadModes.Grayscale);

            rawImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);

            // I'm not sure why we do the gauss - It seems like everyone does it, it's cheap, so we do it. ~Ed
            LogEvent("gauss", showMessageBoxes);
            Mat gauss = new Mat();
            Cv2.GaussianBlur(src, gauss, new OpenCvSharp.Size(3, 3), 2, 2);
            processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(gauss);

            // An attempt to get the contrast across the image to be somewhat uniform. 
            LogEvent("clahe", showMessageBoxes);
            CLAHE claheFilter = Cv2.CreateCLAHE(4, new OpenCvSharp.Size(10, 10));
            Mat clahe = new Mat();
            claheFilter.Apply(gauss, clahe);
            processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(clahe);

            // Grab a template from some middle part of the image. Eventually, the size and location of this 
            // template will be specified. It is very possible we'll have to grab multiple templates, as the 
            // location of the template may impact the accuracy of the rotation.
            // e.g. - if the template is an image of a damaged device (which may happen at any location), the calculated 
            // rotation may be wrong. Testing is required. 
            // The locations where the template matches will create an image with lines that are offset from 0/90 degrees.
            // This is because we can assume that the devices are orthogonal to one another, even if the image itself is 
            // offset rotationally. 
            //Rect r1 = new Rect(new OpenCvSharp.Point(1000, 1000), new OpenCvSharp.Size(500, 300));
            //var roi = new Mat(clahe, r1);
            //Mat template = new Mat(new OpenCvSharp.Size(500, 300), MatType.CV_8UC1);
            //roi.CopyTo(template);


            Mat template = new Mat(sTemplateFilePath, ImreadModes.Grayscale);
            processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(template);

            //LogEvent("preotsu", showMessageBoxes);
            //Mat preotsu = new Mat();
            //Cv2.Threshold(clahe, preotsu, 240, 255, ThresholdTypes.Binary);
            //processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(preotsu);



            Mat templateMatch = new Mat();

            // # According to http://www.devsplanet.com/question/35658323, we can only use cv2.TM_SQDIFF or cv2.TM_CCORR_NORMED for a transparent template
            Cv2.MatchTemplate(clahe, template, templateMatch, TemplateMatchModes.CCorrNormed );


            //LogEvent("template match", showMessageBoxes);
            // can't do this - image is 32, needs to be 8uc1 or similar to convert to bitmap. 
            //processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(templateMatch);


            Mat converted = new Mat();

            converted = templateMatch.Normalize(0, 255, NormTypes.MinMax);

            converted.ConvertTo(converted, MatType.CV_8UC1);

            LogEvent("template match converted", showMessageBoxes);
            processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(converted);

            // This winnows down the number of matches.
            LogEvent("thresh", showMessageBoxes);
            Mat thresh = new Mat();
            Cv2.Threshold(converted, thresh, 240, 255, ThresholdTypes.Binary );
            processedImageBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(thresh);


            string matchFilename = string.Format("Matches_{0}.jpg", DateTime.Now.ToString("yyyyMMdd_hhmmss"));
            thresh.SaveImage(@"..\..\..\ExampleFiles\Templates\" + matchFilename);

        }

        public static void LogEvent(string sMessage, bool showMessageBoxes)
        {

            if (showMessageBoxes)
            {
                MessageBox.Show(sMessage);
            }

        }


    }
}
