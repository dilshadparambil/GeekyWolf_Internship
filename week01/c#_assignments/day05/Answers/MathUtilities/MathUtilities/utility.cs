using System;
using System.Numerics;

namespace MathUtilities
{
    public class Utility
    {
        public bool IsEven(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
        }
        public bool IsPrime(int num)
        {
            if (num == 2)
            {
                return true;
            }

            if (num < 2 || num % 2 == 0)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        public BigInteger Factorial(BigInteger num)
        {
            if (num == 0)
            {
                return 1;
            }
            return num * Factorial(num - 1);
        }
    }
}
