using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Vehicle
    {
        public void ShowType()
        {
            Console.WriteLine("This is a vehicle");
        }
    }
    public class Car : Vehicle
    {
        public new void ShowType()
        {
            Console.WriteLine("This is a car");
        }
    }
}
