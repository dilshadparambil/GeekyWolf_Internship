using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace day3
{
    public class Q06
    {
        /// <summary>
        /// Simulate a simple calculator using a switch statement and arithmetic operators.
        /// </summary>
        public static void Answer()
        {
            int number1, number2;
            char op;
            double calcResult=0;
            Console.Write("Enter first number : ");
            int.TryParse(Console.ReadLine(), out number1);
            Console.Write("Enter second number : ");
            int.TryParse(Console.ReadLine(), out number2);
            Console.Write("Enter the calculation symbol +,-,*,/ : ");
            char.TryParse(Console.ReadLine(), out op);

            switch (op)
            {
                case '+':
                    calcResult = number1 + number2;
                    break;
                case '-':
                    calcResult = number1 - number2;
                    break;
                case '*':
                    calcResult = number1 * number2;
                    break;
                case '/':
                    calcResult = number1 / number2;
                    break;
                default:
                    Console.WriteLine("invalid symbol");
                    break;
            }
            Console.WriteLine($"{number1} {op} {number2} = {calcResult}");
            Console.WriteLine();
        }
         
    }
    
}
