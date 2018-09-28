using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    public class Server
    {
        /// <summary>
        /// 等待客戶端連線
        /// </summary>
        public void ListenToConnection()
        {
            //取得本機名稱
            string hostName = Dns.GetHostName();
            Console.WriteLine("本機名稱=" + hostName);

            //取得本機IP
            IPAddress[] ipa = Dns.GetHostAddresses(hostName);
            Console.WriteLine("本機IP=" + ipa[0].ToString());

            //建立本機端的IPEndPoint物件
            IPEndPoint ipe = new IPEndPoint(ipa[0], 1234);

            //建立TcpListener物件
            TcpListener tcpListener = new TcpListener(ipe);

            //開始監聽port
            tcpListener.Start();
            Console.WriteLine("等待客戶端連線中... \n");

            TcpClient tmpTcpClient;
            int numberOfClients = 0;
            while (true)
            {
                try
                {
                    //建立與客戶端的連線
                    tmpTcpClient = tcpListener.AcceptTcpClient();

                    if (tmpTcpClient.Connected)
                    {
                        Console.WriteLine("連線成功!");
                        HandleClient handleClient = new HandleClient(tmpTcpClient);
                        Thread myThread = new Thread(new ThreadStart(handleClient.Communicate));
                        numberOfClients += 1;
                        myThread.IsBackground = true;
                        myThread.Start();
                        myThread.Name = tmpTcpClient.Client.RemoteEndPoint.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
            } // end while
        } // end ListenToConnect()
    } // end class
}
