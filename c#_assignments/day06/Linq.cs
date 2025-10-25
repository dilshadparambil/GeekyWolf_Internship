using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    public class Linq
    {
        public void Answer()
        {
            //Create a List<string> of 6 names

            List<string> names = new List<string>
        {
            "Dilshad",
            "Bimal",
            "Arjun",
            "Max",
            "Rahul",
            "Adarsh"
        };

            //Use LINQ to:
            //Find all names that start with 'A'.
            //Find names with length greater than 4.

            var namesStartA = names.Where(name => name.StartsWith("A"));
            var namesLen4 = names.Where(name => name.Length > 4);

            //Display the results.
            Console.WriteLine("Names starting with 'A':");
            foreach (var name in namesStartA)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nNames with length greater than 4:");
            foreach (var name in namesLen4)
            {
                Console.WriteLine(name);
            }


        }

    }
}
