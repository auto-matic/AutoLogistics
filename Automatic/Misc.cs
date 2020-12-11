using System;

namespace Automatic
{
    public static partial class Math
    {
        public static double Map(double value, double oldMin, double oldMax, double newMin, double newMax)
        {
            double result = value / oldMax * (newMax - newMin) + newMin;
            return result;
        }

        public static int GreatestCommonDivisor(int n, int d)
        {
            if (n == 0)
            {
                return d;
            }

            return GreatestCommonDivisor(d % n, n);
        }
    }

    public static class Misc
    {
        public static void SplashScreen()
        {
            var offset = "";
            if (Console.WindowWidth > 100)
            {
                int width = (int)(Console.WindowWidth - 101) / 2;
                for (int i = 0; i < width; i++)
                {
                    offset += " ";
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{offset}     _________   ___   ___  __________  _________   ___   ___   _________  __________  ___   ________{offset}");
            Console.WriteLine($"{offset}    /  ___   /  /  /  /  / /___   ___/ /  ___   /  /  /__/  /  /  ___   / /___   ___/ /  /  /  _____/{offset}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{offset}   /  /__/  /  /  /  /  /     /  /    /  /  /  /  /  ___   /  /  /__/  /     /  /    /  /  /  /      {offset}");
            Console.WriteLine($"{offset}  /  ___   /  /  /  /  /     /  /    /  /  /  /  /  /  /  /  /  ___   /     /  /    /  /  /  /       {offset}");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{offset} /  /  /  /  /  /__/  /     /  /    /  /__/  /  /  /  /  /  /  /  /  /     /  /    /  /  /  /_____   {offset}");
            Console.WriteLine($"{offset}/__/  /__/  /________/     /__/    /________/  /__/  /__/  /__/  /__/     /__/    /__/  /________/   {offset}");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{offset}                             It kind of works... most of the time.\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string FitString(string str, int length)
        {
            string fit = String.Empty;
            
            if (str.Length > length)
            {
                for (int i = 0; i < length; i++)
                {
                    if (i + 3 >= length)
                    {
                        fit += '.';
                    }
                    else
                    {
                        fit += str[i];
                    }
                }
            }
            else if (str.Length == length)
            {
                fit = str;
            }
            else
            {
                fit = str;
                while (fit.Length < length)
                {
                    fit += " ";
                }
            }
            return fit;
        }
    }
}
