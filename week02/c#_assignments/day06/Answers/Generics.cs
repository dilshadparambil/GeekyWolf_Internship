using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace day6
{
    public class Generics
    {
        public void Answer()
        {
            //Using Generics with List
            //Create a List<int> to store marks of 5 students.
            List<int> marks = new List<int>();
            double average;

            //Add marks(e.g., 78, 92, 67, 88, 95).
            marks.Add(78);
            marks.Add(92);
            marks.Add(67);
            marks.Add(88);
            marks.Add(95);

            //Calculate and print the average mark.
            average=marks.Average();
            Console.WriteLine($"Average mark = {average}\n");

            //Remove the lowest mark.
            marks.Remove(marks.Min());

            //Sort the list in ascending order and print the updated list.
            marks.Sort();
            foreach (var mark in marks)
            {
                Console.WriteLine(mark);
            }
        }
    }
}
