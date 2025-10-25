namespace TemperatureConverter
{
    public class TemperatureConverterClass
    {
        private TemperatureValidator validator = new TemperatureValidator();

        public bool CelsiusToFahrenheit(double celsius, out double fahrenheit)
        {
            fahrenheit = (celsius * 9 / 5) + 32;
            return validator.isValidTemperature(celsius);
             
        }

        public bool FahrenheitToCelsius(double fahrenheit,out double celsius)
        {
            celsius = (fahrenheit - 32) * 5 / 9;
            
            return validator.isValidTemperature(celsius);

        }

    }
}
