using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q10
    {
        /// <summary>
        /// Swap two integers using the ref keyword.
        /// </summary>
        /// 

        public static void Answer() 
        {
            int number1, number2;
            Console.Write("Enter first number : ");
            int.TryParse(Console.ReadLine(), out number1);
            Console.Write("Enter second number : ");
            int.TryParse(Console.ReadLine(), out number2);
            Console.Write("before swap : ");
            Console.Write($" num1 = {number1} , num2= {number2} ");
            swap(ref number1, ref number2);
            Console.Write("after swap : ");
            Console.Write($" num1 = {number1} , num2= {number2} \n");
        }
        public static void swap(ref int num1, ref int num2)
        {
            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }
         
    }
    
}
