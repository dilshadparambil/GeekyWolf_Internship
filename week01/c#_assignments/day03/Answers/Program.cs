
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using day3;


string empName,studName,accHolder;
int studAge;
long accNumber;
double empSalary, accBalance;

Console.WriteLine("program 1");
Q01.Answer();

Console.WriteLine("program 2");
Q02.Answer();

Console.WriteLine("program 3");
Q03.Answer();

Console.WriteLine("program 4");
Q04.Answer();

Console.WriteLine("program 5");
Q05.Answer();

Console.WriteLine("program 6");
Q06.Answer();

Console.WriteLine("program 7");
Console.Write("Enter Name : ");
studName = Console.ReadLine();
Console.Write("Enter age : ");
int.TryParse(Console.ReadLine(), out studAge);
Student s1 = new Student(studName, studAge);
s1.Details();

Console.WriteLine("program 8");
Console.Write("Enter Name : ");
empName = Console.ReadLine();
Console.Write("Enter Salary : ");
double.TryParse(Console.ReadLine(), out empSalary);
Employee e1 = new Employee(empName, empSalary);
e1.Details();

Console.WriteLine("program 9");
Console.WriteLine("Default user added ");
BankAccount b1 = new BankAccount(); //default

Console.WriteLine("User 1 details ");
Console.Write("Enter Account number : ");
long.TryParse(Console.ReadLine(), out accNumber);
Console.Write("Enter Name : ");
accHolder = Console.ReadLine();
BankAccount b2 = new BankAccount(accNumber, accHolder); //no balnce specified

Console.WriteLine("User 2 details ");
Console.Write("Enter Account number : ");
long.TryParse(Console.ReadLine(), out accNumber);
Console.Write("Enter Name : ");
accHolder = Console.ReadLine();
Console.Write("Enter balance : ");
double.TryParse(Console.ReadLine(), out accBalance);
BankAccount b3 = new BankAccount(accNumber, accHolder, accBalance);

Console.WriteLine("\nDefault user details ");
b1.DisplayBalance();
b1.Deposit();

Console.WriteLine("\nuser1 details ");
b2.DisplayBalance();
b2.Deposit();

Console.WriteLine("\nuser2 details ");
b3.DisplayBalance();
b3.Deposit();

Console.WriteLine("program 10");
Q10.Answer();

Console.WriteLine("program 11");
Q11.Answer();

Console.WriteLine("program 12");
Q12.Answer();