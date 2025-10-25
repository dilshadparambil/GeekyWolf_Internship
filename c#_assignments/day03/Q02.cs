using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q02
    {
        /// <summary>
        /// Check whether a number is even or odd using the ternary operator.
        /// </summary>
        public static void Answer()
        {
            int number;
            Console.Write("Enter number : ");
            int.TryParse(Console.ReadLine(), out number);

            bool isEven = number%2 == 0 ? true : false;

            if (isEven)
            {
                Console.WriteLine($"The number {number} is even");
            }
            else
            {
                Console.WriteLine($"The number {number} is odd");
            }
            Console.WriteLine();
        }
         
    }
    
}
