using UnityEngine;

using System;
using System.Net.Sockets;

namespace Rodger
{
    public class DebugObject : MonoBehaviour
    {

        private TcpClient tcpClient;

        public string ServerIP;

        public int GameCode;

        void Awake()
        {
            if (!string.IsNullOrEmpty(ServerIP))
                Global.SetupDebug(this, ServerIP);
            else
            {
                Global.ReleaseDebugObj();

                Destroy(gameObject);
            }
        }

        public void Setup(string serverip, string logname)
        {
            try
            {
                //string IP = "192.168.152.205";
                int port = 13000;

                tcpClient = new TcpClient(serverip, port);

                if (tcpClient.Connected)
                {
                    //StartCoroutine(Read());

                    WriteToLServer("Login Username:" + logname);

                }
            }
            catch (Exception EX)
            {
                Debug.Log("Connect Exception : " + EX);

                Global.ReleaseDebugObj();

                Destroy(gameObject);
            }

        }


        public void print(string str)
        {
            WriteToLServer(str + "\n");
        }
        void WriteToLServer(string message)
        {
            try
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = tcpClient.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
            }
            catch
            {
                Debug.Log("遠端主機關閉");

                Global.ReleaseDebugObj();

                Destroy(gameObject);
            }
        }
    }
}