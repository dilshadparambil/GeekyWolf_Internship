using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBasedList
{
    public class Employee
    {
        private static int counter = 1000;
        public string Id { get; private set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string EmployeeType { get; set; }

        public Employee(string name, double salary, string employeeType)
        {
            Id = $"Emp{counter}";
            counter++;
            Name = name;
            Salary = salary;
            EmployeeType = employeeType;
        }

    }
    public class EmployeeList
    {
        public List<Employee> employees = new List<Employee>();
        public void AddEmployee(string name, double salary, string type)
        {
            Employee emp = new Employee(name, salary, type);
            employees.Add(emp);
            Console.WriteLine($"Employee added successfully with ID: {emp.Id}\n");
        }

        public void RemoveEmployee(string id)
        {
            var employee = employees.FirstOrDefault(emp => emp.Id == id);

            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine($"Employee {id} removed successfully.\n");
            }
            else
            {
                Console.WriteLine($"No Employee found with Id {id}\n");
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine("Employee List:\n");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary:C}, Type: {emp.EmployeeType}");
            }
            Console.WriteLine();
        }

        public void SearchEmployee(string name)
        {
            var results = employees.Where(e => e.Name.ToLower() == name.ToLower()).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine($"No Employee found with name {name}\n");
            }
            else
            {
                Console.WriteLine("Search Results:");
                foreach (var emp in results)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary:C}, Type: {emp.EmployeeType}");
                }
                Console.WriteLine();
            }
        }

    }
}
