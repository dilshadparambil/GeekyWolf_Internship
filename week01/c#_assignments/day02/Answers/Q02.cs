using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q02
    {
        /// <summary>
        /// Print odd numbers less than 50 using while loop
        /// </summary>
        public void Answer()
        {
            int counter = 1;
            while (counter<50) 
            {
                Console.WriteLine($"odd number = {counter}");
                counter +=2;
            }
            Console.WriteLine();
        }
         
    }
    
}
