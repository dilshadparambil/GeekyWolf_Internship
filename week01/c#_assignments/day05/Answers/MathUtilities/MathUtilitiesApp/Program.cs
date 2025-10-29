
using MathUtilities;
using System.Numerics;
int number;
BigInteger fact;

Utility mathFunction = new Utility();

Console.Write("enter a number: ");
int.TryParse(Console.ReadLine(), out number);


if (mathFunction.IsEven(number))
{
    Console.WriteLine("The number is even");
}
else
{
    Console.WriteLine("The number is odd");
}

if (mathFunction.IsPrime(number))
{
    Console.WriteLine("The number is Prime");
}
else
{
    Console.WriteLine("The number is not prime");
}

fact = mathFunction.Factorial(number);
Console.WriteLine($"Factorial of the number is {fact}");
