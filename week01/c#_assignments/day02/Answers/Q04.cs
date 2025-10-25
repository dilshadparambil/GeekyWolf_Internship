using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q04
    {
        /// <summary>
        /// Reverse of a number
        /// </summary>
        public void Answer()
        {
            int number, reverse=0,remainder=0;

            Console.Write("Enter number to reverse: ");
            int.TryParse(Console.ReadLine(), out number);

            while (number > 0)
            {
                remainder = number % 10;
                number = number / 10;
                reverse = (reverse * 10) + remainder;

            }
            Console.WriteLine($"the reverse of the number is :{reverse}" );
            Console.WriteLine();
        }
         
    }
    
}
