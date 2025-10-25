
using BusinessLogic;

UserDetails details = new UserDetails();

Console.Write("Enter user ID (1 or 2): ");
int userId = int.Parse(Console.ReadLine());

string greeting = details.GetUser(userId);
Console.WriteLine(greeting);
