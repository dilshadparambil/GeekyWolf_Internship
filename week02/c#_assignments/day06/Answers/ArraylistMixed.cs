using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    public class ArraylistMixed
    {
        public void Answer()
        {
            //ArrayList with Mixed Data Types

            //Create an ArrayList and add the following elements:
            ArrayList mixed = new ArrayList();

            //A string ("John")
            mixed.Add("John");

            //An integer (25)
            mixed.Add(25);

            //A double (75.5)
            mixed.Add(75.5);

            //A boolean (true)
            mixed.Add(true);

            //Iterate through the list and print each element along with its data type using GetType().
            foreach (var element in mixed)
            {
                Console.WriteLine($"{element}, Datatype: {element.GetType()}");
            }
        }
    }
}
