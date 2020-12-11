using System;
using System.Diagnostics;

namespace Automatic
{
    public static partial class Log
    {
        /// <summary>
        /// A class for logging console and debug messages with formatting and coloring.
        /// </summary>
        public enum MessageTypes
        {
            Info,
            Warning,
            Error,
            Fatal
        }

        public static void Write(string message, MessageTypes messageType)
        {
            string[] types = {"  Info   ", " Warning ", "  Error  ", "  Fatal  "};
            var type = "";
            switch (messageType)
            {
                
                case MessageTypes.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    type = types[0];
                    break;
                case MessageTypes.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    type = types[1];
                    break;
                case MessageTypes.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    type = types[2];
                    break;
                case MessageTypes.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    type = types[3];
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    type = types[0];
                    break;
            }
            Console.WriteLine($"[{type}][{DateTime.Now:hh:mm:ss}]: {message}");
            Debug.WriteLine($"[{type}][{DateTime.Now:hh:mm:ss}]: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}