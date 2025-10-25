using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q06
    {
        /// <summary>
        /// Check prime number
        /// </summary>
        
        public void Answer() 
        {
            int number;
            bool checkPrimeResult;
            Console.Write("Enter number to check whether its prime: ");
            int.TryParse(Console.ReadLine(), out number);

            checkPrimeResult = CheckPrime(number);

            if (checkPrimeResult)
            {
                Console.WriteLine($"The number {number} is prime.");
            }
            else
            {
                Console.WriteLine($"The number {number} is not prime.");
            }
            Console.WriteLine();
        }

        public static bool CheckPrime(int num)
        {
            if (num == 2)
            {
                return true;
            }

            if (num < 2 || num%2==0)
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

            return true ;

        }

         
    }
    
}
