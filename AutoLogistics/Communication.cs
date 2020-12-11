using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace AutoLogistics
{
    public class Communication
    {
        private Socket Client;
        private IPEndPoint ipEndPoint;

        public Communication()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            foreach (IPAddress ip in ipHost.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }
            ipEndPoint = new IPEndPoint(ipAddr, 5005);
            Client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            if (Client.Connected)
            {
                Console.WriteLine("Already Connected");
                return;
            }
            try
            {
                Client.Connect(ipEndPoint);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}