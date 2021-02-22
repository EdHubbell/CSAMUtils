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
using OpenCvSharp;
using CSAMCommon;

namespace CSAM_Manual
{
    public partial class ucPanelImageBox : UserControl
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public Mat matRaw;

        public OpenCvSharp.Point ptUpperRight= new OpenCvSharp.Point(-999,-999);
        public OpenCvSharp.Point ptUpperLeft = new OpenCvSharp.Point(-999,-999);
        public OpenCvSharp.Point ptLowerRight = new OpenCvSharp.Point(-999, -999);
        public OpenCvSharp.Point ptLowerLeft = new OpenCvSharp.Point(-999, -999);

        public OpenCvSharp.Point ptLatest = new OpenCvSharp.Point(-999, -999);


        public ucPanelImageBox()
        {
            InitializeComponent();
        }



        //public void SetImage(Image image)
        //{
        //    iboxPanel.Image = image;
        //}



        public void LoadImage(string sFilename)
        {
            if (File.Exists(sFilename))
            {
                matRaw = new Mat(sFilename, ImreadModes.Unchanged);

                this.iboxPanel.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matRaw);
            }
            else
            {
                MessageBox.Show("Filename doesn't exist: " + sFilename);
            }
        }

        private void tsmiMarkAsCorner_Click(object sender, EventArgs e)
        {
            try
            {

                if (iboxPanel.Image == null) return;

                if (ptLatest.X < iboxPanel.Image.Width / 2)
                {
                    if (ptLatest.Y < iboxPanel.Image.Height / 2)
                    {
                        ptUpperLeft = ptLatest;
                    }
                    else
                    {
                        ptLowerLeft = ptLatest;
                    }
                }
                else
                {
                    if (ptLatest.Y < iboxPanel.Image.Height / 2)
                    {
                        ptUpperRight = ptLatest;
                    }
                    else
                    {
                        ptLowerRight = ptLatest;
                    }
                }

                DrawCorners();

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }


        }


        private void DrawCorners()
        {
            try
            {
                Cv2.PutText(matRaw, "UL", ptUpperLeft, HersheyFonts.HersheyPlain, .7, Color.Yellow.ToScalar(), 1);
                Cv2.PutText(matRaw, "UR", ptUpperRight, HersheyFonts.HersheyPlain, 1, Color.Yellow.ToScalar(), 1);
                Cv2.PutText(matRaw, "LL", ptLowerLeft, HersheyFonts.HersheyPlain, 3, Color.Yellow.ToScalar(), 1);
                Cv2.PutText(matRaw, "LR", ptLowerRight, HersheyFonts.HersheyPlain, .5, Color.Yellow.ToScalar(), 1);

                this.iboxPanel.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matRaw);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }



        private void iboxPanel_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateCursorPosition(e.Location);
        }



        private void UpdateCursorPosition(System.Drawing.Point location)
        {
            if (iboxPanel.IsPointInImage(location))
            {
                System.Drawing.Point pt = iboxPanel.PointToImage(location);
                ptLatest = new OpenCvSharp.Point(pt.X, pt.Y);
                //cursorToolStripStatusLabel.Text = this.FormatPoint(point);
            }
            else
            {
                ptLatest = new OpenCvSharp.Point(-999,-999);
                //cursorToolStripStatusLabel.Text = string.Empty;
            }
        }

    }
}
