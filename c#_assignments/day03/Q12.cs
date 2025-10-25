using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Q12
    {
        /// <summary>
        /// Write a method FindMaxMin(int[] arr, out int max, out int min) that finds maximum and minimum using out.
        /// </summary>
        public static void FindMaxMin(int[] arr, out int max, out int min)
        {
           max = arr.Max();
           min = arr.Min();
        }

        public static void Answer()
        {
            int minValue, maxValue;
            int[] numbers = { 110, 3, 40, 1, 50, 897, 60 };
            FindMaxMin(numbers, out maxValue,out minValue);
            Console.WriteLine($"Maximum value = {maxValue}\nMinimum value = {minValue}");

        }
         
    }
    
}
