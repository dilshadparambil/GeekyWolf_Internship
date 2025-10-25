
using TemperatureConverter;


TemperatureConverterClass converter = new TemperatureConverterClass();
//TemperatureValidator validator = new TemperatureValidator(); inaccessible due to internal class

Console.Write("Enter temperature in Celsius: ");
double celsius = double.Parse(Console.ReadLine());

if (converter.CelsiusToFahrenheit(celsius, out double fahrenheitConversion))
{
    Console.WriteLine($"{celsius}°C = {fahrenheitConversion:F2}°F");
}
else
{
    Console.WriteLine("Temperature out of valid range.");
}



Console.Write("Enter temperature in Fahrenheit: ");
double fahrenheit = double.Parse(Console.ReadLine());

if (converter.FahrenheitToCelsius(fahrenheit, out double celciusConversion))
{
    Console.WriteLine($"{fahrenheit}°F = {celciusConversion:F2}°C");
}
else
{
    Console.WriteLine("Temperature out of valid range.");
}



