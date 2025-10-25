using MenuBasedList;

EmployeeList employeeList = new EmployeeList();
bool exit = false;

Console.WriteLine("Welcome to the Employee Management System...\n");

while (!exit)
{
    Console.WriteLine("Please choose one of the following:");
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. Remove Employee");
    Console.WriteLine("3. Display All Employees");
    Console.WriteLine("4. Search Employee by Name");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice (1-5): ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());
            Console.Write("Enter Employee Type (Permanent/Contract): ");
            string type = Console.ReadLine();
            employeeList.AddEmployee(name, salary, type);
            break;

        case "2":
            Console.Write("Enter Employee ID to remove: ");
            string id = Console.ReadLine();
            employeeList.RemoveEmployee(id);
            break;

        case "3":
            employeeList.DisplayAll();
            break;

        case "4":
            Console.Write("Enter Employee Name to search: ");
            string searchName = Console.ReadLine();
            employeeList.SearchEmployee(searchName);
            break;

        case "5":
            exit = true;
            Console.WriteLine("Exiting the system... Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
            break;
    }
}