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
    public enum TEMS_InspectionStates
    {
        NA,
        Fail,
        Pass
    }


    public class Panel_State : XMLBaseObject
    {

        public string LotID;


        public List<TEMS_State> TEMS_States = new List<TEMS_State>();


        [XmlIgnore]
        public Dictionary<Point, TEMS_State> dictTEMS_States = new Dictionary<Point, TEMS_State>();

        public Panel_State()
        {

        }

        public Panel_State(string lotID, CSAM_ManualRecipe recipe)
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

                    dictTEMS_States.Add(new Point(x, y), tems_state);

                }

            }

        }

    }



    public class TEMS_State
    {
        public int Row = -1;
        public int Col = -1;
        public int DeviceIndex = -1;
        public TEMS_InspectionStates TH_State = TEMS_InspectionStates.NA;
        public TEMS_InspectionStates BH_State = TEMS_InspectionStates.NA;


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
