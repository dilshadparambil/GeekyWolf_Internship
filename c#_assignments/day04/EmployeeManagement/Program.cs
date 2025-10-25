

using EmployeeManagement;

Employee e1 = new Employee("John Doe", 15000, "Permanent");
Employee e2 = new Employee("Liam Smith", 20000, "Contract");
Employee e3 = new Employee("Mary James", 15000, "Permanent");

e1.Details();
e2.Details();
e3.Details();

Console.WriteLine($"total number of employees = {Employee.GetEmpCount()}");
Console.WriteLine($"next available Employee Id = {Employee.NextEmpId()}");
