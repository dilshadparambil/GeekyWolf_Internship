using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q04
    {
        /// <summary>
        /// Swap two numbers without using a third variable(use arithmetic).
        /// </summary>
        public static void Answer()
        {
            int number1, number2;
            Console.Write("Enter first number : ");
            int.TryParse(Console.ReadLine(), out number1);
            Console.Write("Enter second number : ");
            int.TryParse(Console.ReadLine(), out number2);

            number1=number1 + number2;  
            number2 = number1 - number2;
            number1=number1 - number2;

            Console.WriteLine($"\nswapped numbers : \nnumber1 = {number1}\nnumber2 = {number2}");

            Console.WriteLine();
        }
         
    }
    
}
