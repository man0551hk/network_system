using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApplication1
{
    public class Client
    {
        /// <summary>
        /// 連線至主機
        /// </summary>
        public void ConnectToServer(string ip, int port)
        {
            //預設主機IP
            string hostIP = ip;

            //先建立IPAddress物件,IP為欲連線主機之IP
            IPAddress ipa = IPAddress.Parse(hostIP);

            //建立IPEndPoint
            IPEndPoint ipe = new IPEndPoint(ipa, port);

            //先建立一個TcpClient;
            TcpClient tcpClient = new TcpClient();

            //開始連線
            try
            {
                Console.WriteLine("connect to IP=" + ipa.ToString());
                Console.WriteLine("connecting...\n");
                tcpClient.Connect(ipe);
                if (tcpClient.Connected)
                {
                    Console.WriteLine("connection success");
                    CommunicationBase cb = new CommunicationBase();
                  
                      //*000090010000000000**\r
                    //*0000900100000000 *[CSM]*
                    //cb.SendMsg("*0000900100000000 *[CSM]*", tcpClient);
                    Console.WriteLine(cb.ReceiveMsg(tcpClient));
                    Console.WriteLine("finish send msg");
                }
                else
                {
                    Console.WriteLine("connect fail!");
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                tcpClient.Close();
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
