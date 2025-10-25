using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q05
    {
        /// <summary>
        /// Check if a number lies between 10 and 50 using logical operators.
        /// </summary>
        public static void Answer()
        {
            int number;
            Console.Write("Enter number : ");
            int.TryParse(Console.ReadLine(), out number);

            if (number>10 && number < 50)
            {
                Console.WriteLine($"Number {number} lies between 10 and 50");
            }
            else
            {
                Console.WriteLine($"Number {number} is either less than 10 or greater than 50");
            }
           
            Console.WriteLine();
        }
         
    }
    
}
