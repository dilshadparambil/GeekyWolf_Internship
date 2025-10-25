
try
{
    Console.Write("Enter first number: ");
    decimal num1 = decimal.Parse(Console.ReadLine());

    Console.Write("Enter operation (+, -, *, /): ");
    string operation = Console.ReadLine();

    Console.Write("Enter second number: ");
    decimal num2 = decimal.Parse(Console.ReadLine());

    decimal result = 0;

    switch (operation)
    {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            result = num1 / num2;
            break;
        default:
            Console.WriteLine("Invalid operation.");
            return;
    }

    Console.WriteLine($"Result: {result:F2}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("You can’t divide by zero.");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Please enter digits only.");
}
catch (OverflowException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("The number you entered is too large or too small.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("An unexpected error occurred.");
}
finally
{
    Console.WriteLine("Calculation completed.\n");
}