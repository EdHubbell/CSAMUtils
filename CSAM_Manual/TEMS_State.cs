using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using CSAMCommon;

namespace CSAM_Manual
{

    public enum PanelImageSides
    {
        TH,
        BH
    }


    public enum TEMS_InspectionStates
    {
        NA,
        Fail,
        Pass
    }


    public class PanelState : XMLBaseObject
    {

        public string LotID;


        public List<TEMS_State> TEMS_States = new List<TEMS_State>();


        //[XmlIgnore]
        //public Dictionary<Point, TEMS_State> dictPoint_TEMS_States = new Dictionary<Point, TEMS_State>();

        //[XmlIgnore]
        //public Dictionary<int, TEMS_State> dictDeviceID_TEMS_States = new Dictionary<int, TEMS_State>();


        public PanelState()
        {

        }

        public PanelState(string lotID, CSAM_ManualRecipe recipe)
        {

            LotID = lotID;

            int iDeviceCount = recipe.TEMS_Count_X * recipe.TEMS_Count_Y;


            for (int y = 1; y <= recipe.TEMS_Count_Y; y++)
            {

                for (int x = 1; x <= recipe.TEMS_Count_X; x++)
                {
                    int deviceIndex = 0;
                    if (y % 2 == 1)
                    {
                        deviceIndex = x + (y - 1) * recipe.TEMS_Count_X;
                    }
                    else
                    {
                        deviceIndex = (1 + recipe.TEMS_Count_X - x) + (y - 1) * recipe.TEMS_Count_X;
                    }

                    TEMS_State tems_state = new TEMS_State(y, x, deviceIndex);

                    TEMS_States.Add(tems_state);

                    //dictPoint_TEMS_States.Add(new Point(x, y), tems_state);

                    //dictDeviceID_TEMS_States.Add(deviceIndex, tems_state);

                }

            }
        }


        public TEMS_State GetTEMS_State(int deviceIndex)
        {
            // Usually, lists are in order. Usually. We can do a dict too, but I don't really want to this early on. 
            if (TEMS_States[deviceIndex - 1].DeviceIndex == deviceIndex) return TEMS_States[deviceIndex - 1];

            // In case the list isn't in order.
            for (int index = 0; index < TEMS_States.Count; index++)
            {
                if (TEMS_States[index].DeviceIndex == deviceIndex) return TEMS_States[index];
            }

            return null;

        }
    }


    public class TEMS_State
    {
        public int Row = -1;
        public int Col = -1;
        public int DeviceIndex = -1;
        public TEMS_InspectionStates TH_InspectionState = TEMS_InspectionStates.NA;
        public TEMS_InspectionStates BH_InspectionState = TEMS_InspectionStates.NA;

        public OpenCvSharp.Rect TH_Rect;
        public OpenCvSharp.Rect BH_Rect;


        public TEMS_State()
        { }

        public TEMS_State(int row, int col, int deviceIndex)
        {
            Row = row;
            Col = col;
            DeviceIndex = deviceIndex;

        }
    }

}
