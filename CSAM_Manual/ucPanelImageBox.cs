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
using static CSAM_Manual.PanelState;

namespace CSAM_Manual
{
    public partial class ucPanelImageBox : UserControl
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public Mat matRaw;

        public OpenCvSharp.Point ptDefault = new OpenCvSharp.Point(-999, -999);

        public OpenCvSharp.Point ptUpperRight = new OpenCvSharp.Point(-999, -999);
        public OpenCvSharp.Point ptUpperLeft = new OpenCvSharp.Point(-999, -999);
        public OpenCvSharp.Point ptLowerRight = new OpenCvSharp.Point(-999, -999);
        public OpenCvSharp.Point ptLowerLeft = new OpenCvSharp.Point(-999, -999);

        public OpenCvSharp.Point ptLatest = new OpenCvSharp.Point(-999, -999);

        public PanelState panelState;

        private PanelImageSides _PanelImageSide;

        private PanelState _PanelState;

        private CSAM_ManualRecipe recipe;

        public ucPanelImageBox()
        {
            InitializeComponent();
        }



        //public void SetImage(Image image)
        //{
        //    iboxPanel.Image = image;
        //}



        public void LoadImage(string sFilename, PanelImageSides panelImageSide, PanelState panelState, CSAM_ManualRecipe recipe)
        {
            if (File.Exists(sFilename))
            {
                matRaw = new Mat(sFilename, ImreadModes.Unchanged);

                this.iboxPanel.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matRaw);

                _PanelImageSide = panelImageSide;
                _PanelState = panelState;
                this.recipe = recipe;

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
                CalculateRectangles();
                DrawRectangles();

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
                Cv2.PutText(matRaw, "UR", ptUpperRight, HersheyFonts.HersheyPlain, .7, Color.Yellow.ToScalar(), 1);
                Cv2.PutText(matRaw, "LL", ptLowerLeft, HersheyFonts.HersheyPlain, .7, Color.Yellow.ToScalar(), 1);
                Cv2.PutText(matRaw, "LR", ptLowerRight, HersheyFonts.HersheyPlain, .7, Color.Yellow.ToScalar(), 1);

                this.iboxPanel.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matRaw);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }


        private void CalculateRectangles()
        {
            try
            {
                // If we don't have corners, don't draw rectangles.
                if (ptLowerLeft == ptDefault || ptUpperLeft == ptDefault || ptLowerRight == ptDefault || ptUpperRight == ptDefault) return;

                // We have corners. We know how many devices. Calculate rectangles.
                int rectWidth = (int)(((ptUpperRight.X - ptUpperLeft.X) + (ptLowerRight.X - ptLowerLeft.X)) / (2 * recipe.TEMS_Count_X));
                int rectHeight = (int)(((ptLowerRight.Y - ptUpperRight.Y) + (ptLowerLeft.Y - ptUpperLeft.Y)) / (2 * recipe.TEMS_Count_Y));


                for (int y = 1; y <= recipe.TEMS_Count_Y; y++)
                {

                    for (int x = 1; x <= recipe.TEMS_Count_X; x++)
                    {
                        int deviceIndex = 0;
                        if (y % 2 == 1)
                        {
                            deviceIndex = x + (y - 1) * recipe.TEMS_Count_X;

                            if (_PanelImageSide == PanelImageSides.BH) deviceIndex = (1 + recipe.TEMS_Count_X - x) + (y - 1) * recipe.TEMS_Count_X;
                        }
                        else
                        {
                            deviceIndex = (1 + recipe.TEMS_Count_X - x) + (y - 1) * recipe.TEMS_Count_X;

                            if (_PanelImageSide == PanelImageSides.BH) deviceIndex = x + (y - 1) * recipe.TEMS_Count_X; ;

                        }


                        // Upper left corner of the rectangle.
                        OpenCvSharp.Point pt = new OpenCvSharp.Point(ptUpperLeft.X + ((x - 1) * rectWidth), ptUpperLeft.Y + ((y - 1) * rectHeight));

                        if (_PanelImageSide == PanelImageSides.TH)
                        {
                            TEMS_State tems_state = _PanelState.GetTEMS_State(deviceIndex);
                            tems_state.TH_Rect = new Rect(pt, new OpenCvSharp.Size(rectWidth, rectHeight));
                        }


                        if (_PanelImageSide == PanelImageSides.BH)
                        {
                            TEMS_State tems_state = _PanelState.GetTEMS_State(deviceIndex);
                            tems_state.BH_Rect = new Rect(pt, new OpenCvSharp.Size(rectWidth, rectHeight));
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void DrawRectangles()
        {
            try
            {


                foreach (TEMS_State tems_state in _PanelState.TEMS_States)
                {

                    if (_PanelImageSide == PanelImageSides.TH)
                    {
                        Cv2.Rectangle(matRaw, tems_state.TH_Rect, System.Drawing.Color.Red.ToScalar(), 1);
                        LabelRectangle(matRaw, tems_state.DeviceIndex.ToString(), tems_state.TH_Rect, Color.Yellow);
                    }

                    if (_PanelImageSide == PanelImageSides.BH)
                    {
                        Cv2.Rectangle(matRaw, tems_state.BH_Rect, System.Drawing.Color.Red.ToScalar(), 1);
                        LabelRectangle(matRaw, tems_state.DeviceIndex.ToString(), tems_state.BH_Rect, Color.Yellow);
                    }

                }

                this.iboxPanel.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matRaw);


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void LabelRectangle(Mat mat, string label, Rect rect, Color color)
        {
            try
            {
                Cv2.PutText(mat, label, new OpenCvSharp.Point(rect.X + 5, rect.Y + 5), HersheyFonts.HersheyPlain, .7, color.ToScalar(), 1);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private System.Drawing.Color GetRectangleColor(TEMS_State tems_state)
        {
            try
            {
                // Never had state set. Bridal white.
                if (tems_state.BH_InspectionState == TEMS_InspectionStates.NA && tems_state.TH_InspectionState == TEMS_InspectionStates.NA) return System.Drawing.Color.White;

                // Both pass. That's great. Green means go.
                if (tems_state.BH_InspectionState == TEMS_InspectionStates.Pass && tems_state.TH_InspectionState == TEMS_InspectionStates.Pass) return System.Drawing.Color.Green;

                // Either one fails. This TEM is garbage.
                if (tems_state.BH_InspectionState == TEMS_InspectionStates.Fail || tems_state.TH_InspectionState == TEMS_InspectionStates.Fail) return System.Drawing.Color.Red;

                // Anything else is indeterminate. But it'd be nice to know that something was good on one side. So if we still don't have a result, we can get specific.

                if (_PanelImageSide == PanelImageSides.TH)
                {
                    if (tems_state.BH_InspectionState == TEMS_InspectionStates.Pass && tems_state.TH_InspectionState == TEMS_InspectionStates.NA) return System.Drawing.Color.White;
                    if (tems_state.BH_InspectionState == TEMS_InspectionStates.NA && tems_state.TH_InspectionState == TEMS_InspectionStates.Pass) return System.Drawing.Color.LightGreen;
                }

                if (_PanelImageSide == PanelImageSides.BH)
                {
                    if (tems_state.TH_InspectionState == TEMS_InspectionStates.Pass && tems_state.BH_InspectionState == TEMS_InspectionStates.NA) return System.Drawing.Color.White;
                    if (tems_state.TH_InspectionState == TEMS_InspectionStates.NA && tems_state.BH_InspectionState == TEMS_InspectionStates.Pass) return System.Drawing.Color.LightGreen;
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            // If we're down here, I'm not sure what's up. So we go yellow.
            return System.Drawing.Color.Yellow;

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
                ptLatest = ptDefault;
                //cursorToolStripStatusLabel.Text = string.Empty;
            }
        }

        private void tsmiFailTEMS_Click(object sender, EventArgs e)
        {
            SetTEMS_InspectionState(TEMS_InspectionStates.Fail);
        }

        private void tsmiPassTEMS_Click(object sender, EventArgs e)
        {
            SetTEMS_InspectionState(TEMS_InspectionStates.Pass);
        }

        private void tsmiResetTEMS_Click(object sender, EventArgs e)
        {
            SetTEMS_InspectionState(TEMS_InspectionStates.NA);
        }



        private void SetTEMS_InspectionState(TEMS_InspectionStates inspectionState)
        {
            try
            {
                TEMS_State currentTEMS_State = GetTEMS_StateAtPoint(ptLatest);

                if (currentTEMS_State != null)
                {
                    if (_PanelImageSide == PanelImageSides.TH)
                    {
                        currentTEMS_State.TH_InspectionState = inspectionState;
                    }
                    else
                    {
                        currentTEMS_State.BH_InspectionState = inspectionState;
                    }

                    DrawRectangles();

                }


            }

            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private TEMS_State GetTEMS_StateAtPoint(OpenCvSharp.Point pt)
        {
            foreach (TEMS_State tems_state in _PanelState.TEMS_States)
            {
                if (_PanelImageSide == PanelImageSides.TH)
                {
                    if (Cv2E.PointInRect(pt, tems_state.TH_Rect)) return tems_state;
                }
                else
                {
                    if (Cv2E.PointInRect(pt, tems_state.BH_Rect)) return tems_state;
                }
            }
            return null;
        }
    }
}