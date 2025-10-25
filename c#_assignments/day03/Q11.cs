using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q11
    {
        /// <summary>
        /// Write a method GetSumAndAverage(int a, int b, out int sum, out double avg) 
        /// that returns sum and average using out parameters.
        /// </summary>
        /// 
        public static void GetSumAndAverage(int a, int b, out int sum, out double avg)
        {
            sum = a + b;
            avg = (double)sum/2;
        }
        public static void Answer()
        {
            int number1, number2,sum;
            double avg;
           
            Console.Write("Enter first number : ");
            int.TryParse(Console.ReadLine(), out number1);
            Console.Write("Enter second number : ");
            int.TryParse(Console.ReadLine(), out number2);

            GetSumAndAverage(number1, number2,out sum,out avg);
            Console.WriteLine($"Sum: {sum}\nAverage: {avg}");
        }
         
    }
    
}
