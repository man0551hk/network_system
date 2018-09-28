using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
   
            Client client = new Client();
            client.ConnectToServer("127.0.0.1", 2025);
            Console.ReadKey();
        }
    }
}
