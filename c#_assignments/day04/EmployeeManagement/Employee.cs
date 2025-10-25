using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Employee
    {
        static int Counter;
        static int empCount;

        public string Id { get; private set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string EmployeeType { get; set; }

        static Employee()
        {
            Counter = 1000;
        }
        public Employee(string name,double salary,string type)
        {
            this.Id = $"Emp{Counter}";
            Counter++;
            empCount++;
            this.Name = name;
            this.Salary = salary;
            this.EmployeeType = type;
        }

        public void Details()
        {
            Console.WriteLine($"Employee ID: {Id}\nName: {Name}\nSalary: {Salary}\nEmployee Type: {EmployeeType}\n");
        }

        public static int GetEmpCount()
        {
            return empCount;
        }
        public static string NextEmpId()
        {
            return $"Emp{Counter}";
        }
    }
    
}
