using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Student
    {
        /// <summary>
        /// Create a class Student with fields Name and Age.
        /// Add a constructor to initialize them and display details in a separate method .
        /// </summary>
        public string Name { get; set; }
        public int Age { get; set; }
        public Student( string name, int age)
        {
            this.Name = name;
            this.Age = age; 
        }
        public void Details()
        {
            Console.WriteLine($"The Student name is: {Name}\nThe Student age is {Age}");
            Console.WriteLine();
        }
         
    }
    
}
