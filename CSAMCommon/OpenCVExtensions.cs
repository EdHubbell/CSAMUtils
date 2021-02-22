using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Drawing;

namespace CSAMCommon
{
    public static class Cv2E
    {
        /// <summary>
        /// Rotate mat from center point by specified degrees
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="angle">Rotation angle in degrees. Positive values mean counter-clockwise rotation. </param>
        public static void RotateDegrees(Mat src, Mat dst, double angle)
        {
            var imageCenter = new Point2f(src.Cols / 2f, src.Rows / 2f);
            var rotationMat = Cv2.GetRotationMatrix2D(imageCenter, angle, 1);
            Cv2.WarpAffine(src, dst, rotationMat, src.Size());
        }


        public static Scalar ToScalar(this System.Drawing.Color color)
        {
            // Tricky with this b/g/r instead of r/g/b
            return new Scalar(color.B, color.G, color.R);
        }


    }
}
