using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPSenderBroadcast
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;

            IPAddress ip = IPAddress.Parse("127.0.0.1"); //
            //UdpClient udpClient = new UdpClient("127.0.0.1", 9999);
            UdpClient udpSender = new UdpClient( 0);
            udpSender.EnableBroadcast = true;
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 9999);
            Console.Write("State name: ");
            String name = Console.ReadLine();

            while (true)
            {
                for (int i = 0; i < 5000; i++)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(name + " " + number + " hello");

                    udpSender.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint); //, RemoteEndPoint);
                    //Client is now activated");
                    number++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
