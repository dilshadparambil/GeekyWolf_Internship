using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q09
    {
        /// <summary>
        /// Tax calculation program, input the amount and display the tax 
        ///  <code>
        ///    +-------------------------+-------+
        ///    |         Amount          | Tax % |
        ///    +-------------------------+-------+
        ///    | Less than 10000         |     5 |
        ///    | Between 10000 and 15000 |   7.5 |
        ///    | Between 15000 and 20000 |    10 |
        ///    | Between 20000 and 25000 |  12.5 |
        ///    | Above 25000             |    15 |
        ///    +-------------------------+-------+
        ///   </code>
        /// </summary>
        public void Answer()
        {
            int amount;
            Console.Write("Enter the amount ");
            int.TryParse(Console.ReadLine(), out amount);
            Findtax(amount);
        }
         
        public void Findtax(int amount)
        {
            double tax, taxAmount;
            if (amount < 10000)
            {
                tax = 5;
            }
            else if (amount < 15000)
            {
                tax = 7.5;
            }
            else if (amount < 20000)
            {
                tax = 10;
            }
            else if (amount < 25000)
            {
                tax = 12.5;
            }
            else
            {
                tax = 15;
            }
            taxAmount = tax/100 * amount;
            Console.WriteLine($"Tax for the amount: {amount} = {taxAmount}");
        }
    }
    
}
