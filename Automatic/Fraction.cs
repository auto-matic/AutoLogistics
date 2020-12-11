using System;

namespace Automatic
{
    public static partial class Math
    {
        public class Fraction
        {
            private class DenominatorZeroException : Exception
            {
                public DenominatorZeroException()
                {
                }

                public DenominatorZeroException(string message)
                    : base(message)
                {
                }

                public DenominatorZeroException(string message, Exception inner)
                    : base(message, inner)
                {
                }
            }
            public int numerator
            {
                set
                {
                    if (denominator != 0)
                    {
                        int gcd = GreatestCommonDivisor(value, denominator);
                        numerator = value / gcd;
                        denominator /= gcd;
                    }
                    else if (denominator == 0)
                    {
                        numerator = value;
                    }

                }
                get
                {
                    return numerator;
                }
            }
            public int denominator
            {
                set
                {
                    if (value != 0)
                    {
                        int gcd = GreatestCommonDivisor(value, numerator);
                        numerator = value / gcd;
                        denominator /= gcd;
                    }
                    else if (value == 0)
                    {
                        DenominatorZeroException exception = new DenominatorZeroException("Denominator of fraction can not be 0.");
                        throw exception;
                    }

                }
                get
                {
                    return denominator;
                }
            }

            double value { get => Convert.ToDouble(numerator) / Convert.ToDouble(denominator); }

            public Fraction(int numerator, int denominator)
            {
                this.denominator = denominator;
                this.numerator = numerator;
            }

            public override string ToString()
            {
                return $"{numerator}/{denominator}";
            }
        }
    }
}
