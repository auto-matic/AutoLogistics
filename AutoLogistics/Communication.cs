using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Microsoft.VisualBasic;

namespace AutoLogistics
{
    public enum RequestTypes
    {
        INVALID, GET, TERMINATE, DISCONNECT
    }

    public enum ResponseTypes
    {
        SUCCESS, ERROR
    }
    public class Communication
    {
        private Socket Client;
        private IPEndPoint IpEndPoint;

        public Communication()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHost.AddressList[1];
            IpEndPoint = new IPEndPoint(ipAddress, 5005);
            Client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
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
                Client.Connect(IpEndPoint);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string Request(RequestTypes rt)
        {
            var msg = "";
            if (rt == RequestTypes.GET) msg = "GET";
            else if (rt == RequestTypes.TERMINATE) msg = "TERMINATE";
            else if (rt == RequestTypes.DISCONNECT) msg = "DISCONNECT";
            else if (rt == RequestTypes.INVALID) msg = "INVALID";

            Client.Send(Encoding.Unicode.GetBytes(msg));
            byte[] bytes = new byte[1024];
            int bytesRec = Client.Receive(bytes);
            return Encoding.Unicode.GetString(bytes, 0, bytesRec).Substring(1);
        }
    }
}