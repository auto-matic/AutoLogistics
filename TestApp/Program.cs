using System;
using AutoLogistics;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var coms = new Communication();
            coms.Connect();
            coms.Connect();
            Console.Read();
        }
    }
}
