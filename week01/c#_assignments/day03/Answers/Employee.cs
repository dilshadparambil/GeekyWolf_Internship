using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class Employee
    {
        /// <summary>
        /// Create a class Employee with two constructors (Name only; Name, Salary) using constructor chaining. 
        /// </summary>
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name)
        {
            
            this.Name = name;

        }
        public Employee(string name,double salary):this(name)
        {

            this.Salary = salary;

        }
        public void Details()
        {
            Console.WriteLine($"The Employee name is: {Name}\nThe Employee Salary is {Salary}");
            Console.WriteLine();
        }


    }

}
