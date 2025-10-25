using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    internal class TemperatureValidator
    {
        public bool isValidTemperature(double celsius)
        {
            if (celsius >= -273.15 && celsius <= 5500)
            {
                return true;
            }
            return false;
        }
    }
}
