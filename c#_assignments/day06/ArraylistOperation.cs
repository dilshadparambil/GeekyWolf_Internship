using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    public class ArraylistOperation
    {
        public void Answer()
        {
            //Basic ArrayList Operations

            //Create an ArrayList to store student names.
            ArrayList students = new ArrayList();

            //Add 5 student names to the list.
            students.Add("dilshad");
            students.Add("nabeel");
            students.Add("bimal");
            students.Add("sufiyan");
            students.Add("adarsh");

            //Display all names.
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
            Console.WriteLine();

            //Remove one name from the list.
            //Insert a new name at index 2.
            students.Remove(students[0]);
            students.Insert(2, "max");

            //Print the final list using both a for loop and a foreach loop.
            Console.WriteLine("using for loop");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
            Console.WriteLine();

            Console.WriteLine("using for each");
            foreach (var name in students)
            {
                Console.WriteLine(name);
            }

        }
    }
}