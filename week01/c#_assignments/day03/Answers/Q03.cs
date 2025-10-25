using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q03
    {
        /// <summary>
        /// Compare two integers using relational and logical operators.
        /// </summary>
        public static void Answer()
        {
            int number1, number2;
            Console.Write("Enter first number : ");
            int.TryParse(Console.ReadLine(), out number1);
            Console.Write("Enter second number : ");
            int.TryParse(Console.ReadLine(), out number2);

            //relational operators
            if (number1 == number2)
            {
                Console.WriteLine("Both number are equal");
            }
            if (number1 != number2)
            {
                Console.WriteLine("Both number are not equal");
            }
            if (number1 < number2)
            {
                Console.WriteLine("number2 is greater");
            }
            if (number1 > number2)
            {
                Console.WriteLine("number1 is greater");
            }
            if (number1 <= number2)
            {
                Console.WriteLine("number2 is greater or equal");
            }
            if (number1 >= number2)
            {
                Console.WriteLine("number1 is greater or equal");
            }

            //logical operators
            if (number1 > 5 && number2 > 5)
            {
                Console.WriteLine("both numbers are greater than 5");
            }
            if (number1 > 5 || number2 > 5)
            {
                Console.WriteLine("one of the number is greater than 5");
            }
            if (!(number1 == number2))
            {
                Console.WriteLine("number1 is not equal to number2");
            }
            if (number1 < 4 & number2 < 4)
            {
                Console.WriteLine("both numbers are lesser than 4");
            }
            if (number1 < 4 | number2 < 4)
            {
                Console.WriteLine("one of the number is lesser than 4");
            }
            //xor
            if (number1 < 4 ^ number2 < 4)
            {
                Console.WriteLine("one number less than 4 and one number greater than 4");
            }
            Console.WriteLine();
        }

    }

}
