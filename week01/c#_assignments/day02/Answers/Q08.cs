using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    
    public class Q08
    {
        /// <summary>
        /// Fibonacci series
        /// </summary>

        int fibanocciLimit;
        public void Answer()
        {
            Console.Write("Enter fibanocci limit: ");
            int.TryParse(Console.ReadLine(), out fibanocciLimit);

            for (int i = 0; i < fibanocciLimit; i++)
            {
                Console.Write(Fibanocci(i) + " ");
            }
        }

        public int Fibanocci(int num)
        {
            if (num <= 1)
            {
                return 1;
            }
            else
            {
                return Fibanocci(num - 1) + Fibanocci(num - 2);
            }
        }
         
    }
    
}
