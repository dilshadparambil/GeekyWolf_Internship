using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q03
    {
        /// <summary>
        /// Large amount 3 numbers
        /// </summary>
        int number1, number2, number3;
        public void Answer()
        {
            Console.Write("Enter First number: ");
            int.TryParse(Console.ReadLine(), out number1);
            Console.Write("Enter Second number: ");
            int.TryParse(Console.ReadLine(), out number2);
            Console.Write("Enter Third number: ");
            int.TryParse(Console.ReadLine(), out number3);
            Largest(number1, number2, number3);


            Console.WriteLine();
        }

        public void Largest(int num1, int num2, int num3)
        {
            int largest_num;
            if (num1 > num2 & num1 > num3)
            {
                largest_num = num1;
            }
            else if (num2 > num1 && num2 > num3)
            {
                largest_num = num2;
            }
            else
            {
                largest_num = num3;
            }

            Console.WriteLine($"largest number Among the three numbers is : {largest_num}");
        }


    }

}
