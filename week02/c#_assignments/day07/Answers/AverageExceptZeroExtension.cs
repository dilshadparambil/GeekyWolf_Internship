using System;
using System.Collections.Generic;
using System.Linq;


namespace Day7
{
    public static class AverageExceptZeroExtension
    {
        public static double AverageExceptZero(this List<int> numbers) 
        {
            if (numbers == null)
            {
                return 0;
            }

            var zeroRemovedList = numbers.Where(num => num != 0);

            if (!zeroRemovedList.Any() )
            {
                return 0;
            }

            return zeroRemovedList.Average();

        }
    }
}
