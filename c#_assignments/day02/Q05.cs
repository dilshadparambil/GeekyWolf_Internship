using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q05
    {
        /// <summary>
        /// Sum of the digits of a number
        /// </summary>
        public void Answer()
        {

            int number, sum = 0, remainder = 0;
            Console.Write("Enter number to find sum of digits: ");
            int.TryParse(Console.ReadLine(), out number);

            while (number > 0)
            {
                remainder = number % 10;
                number = number / 10;
                sum += remainder;

            }
            Console.WriteLine($"the Sum of the digits of the number is :{sum}");
            Console.WriteLine();
        }
         
    }
    
}
