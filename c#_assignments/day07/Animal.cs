using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Animal
    {
        public virtual void speak()
        {
            Console.WriteLine("Animal Sound");
        }
    }

    public class Dog : Animal
    {
        public override void speak()
        {
            Console.WriteLine("Dog bark Sound");
        }
    }
    public class Cat : Animal
    {
        public override void speak()
        {
            Console.WriteLine("cat meow Sound");
        }
    }
}
