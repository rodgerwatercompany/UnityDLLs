
using UnityEngine;

using System.Collections.Generic;

namespace Rodger
{

    public delegate void VOIDCB();
    public delegate void VOIDintCB(int value);

    public class Global
    {
        static DebugObject DebugObj;

        static public void SetupDebug(DebugObject obj, string serverip)
        {
            DebugObj = obj;
            string logname = SystemInfo.graphicsDeviceName + " " + SystemInfo.deviceUniqueIdentifier;
            DebugObj.Setup(serverip, logname);
        }

        static public void ReleaseDebugObj()
        {
            DebugObj = null;
        }

        static public void print(string str)
        {
            if (DebugObj != null)
            {
                Debug.Log("use logserver " + str);
                DebugObj.print(str);
            }
        }

    }
}