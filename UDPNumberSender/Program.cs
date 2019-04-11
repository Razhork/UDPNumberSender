using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPNumberSender
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;

            IPAddress ip = IPAddress.Parse("127.0.0.1"); //
            UdpClient udpClient = new UdpClient("127.0.0.1", 9999);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9999); //
            //udpClient.Connect(RemoteIpEndPoint); //

            ; Console.Write("State name: ");
            String name = Console.ReadLine();
            while (true)
            {

                for (int i = 0; i < 5000; i++)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(name + " " + number + " hello");
                    udpClient.Send(sendBytes, sendBytes.Length); //, RemoteEndPoint);
                    number++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}