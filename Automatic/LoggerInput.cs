using System;
using System.Diagnostics;

namespace Automatic
{
    public static partial class Log
    {
        public static string Read()
        {
            Console.Write($"[  Input  ][{DateTime.Now:hh:mm:ss}]> ");
            return Console.ReadLine();
        }

        public static string Read(string message)
        {
            Console.WriteLine($"[  Input  ][{DateTime.Now:hh:mm:ss}]> {message}");
            Console.Write($"[  Input  ][{DateTime.Now:hh:mm:ss}]> ");
            return Console.ReadLine();
        }
        public static class ProofRead
        {
            /// <summary>
            /// A class that is used to write a certain message, get Console input, check whether the given input has a certain datatype, output that input if it is the right datatype and write a log message if it is not.
            /// </summary>
            public static int Int(string message)
            {
                var variable = new int();
                try
                {
                    variable = Convert.ToInt32(Read());
                }
                catch (Exception e)
                {
                    Log.Write("The given value is not an integer", Log.MessageTypes.Error);
                    Debug.WriteLine(e);
                    variable = int.MinValue;
                }

                return variable;
            }

            public static double Double(string message)
            {
                var variable = new double();
                Console.Write(message);
                try
                {
                    variable = Convert.ToDouble(Read());
                }
                catch (Exception e)
                {
                    Log.Write("The given value is not a double", Log.MessageTypes.Error);
                    Debug.WriteLine(e);
                    variable = double.MinValue;
                }

                return variable;
            }
        }
    }
}