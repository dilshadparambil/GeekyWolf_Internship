using day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    public class Q07
    {
        /// <summary>
        /// Print all prime numbers below 100
        /// </summary>
        public static void Answer()
        {
            Console.WriteLine("prime numbers less than 100 ");
            Console.WriteLine(2); // write 2 to the output
            for (int i = 3; i <= 100; i+=2)
            {
                bool isPrime;
                isPrime = Q06.CheckPrime(i); //question6 already have a function to check prime

                if (isPrime)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }
         
    }
    
}
