using System;
using System.Collections.Generic;

namespace SampleObjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var chryzogon = new Human("Chryzogon", 799);
            var metuzalem = new GermanMan("Metuzalem", 999);
            var zaphod = new CzechMan("Zaphod Bieblebrox", 135);

            var people = new List<Human> { chryzogon, metuzalem, zaphod };

            foreach(var human in people)
            {
                human.SayGreetings();

            }
        }

        class Human {
            public string name { get; private set;  }
            public int age { get; private set; }

            public Human(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public virtual void SayName()
            {
                if (this.age >= 2)
                    Console.WriteLine(this.name);
                else
                    Console.WriteLine("blablabla, neumim mluvit, jeste mi nejsou dva!");
            }

            public virtual void SayGreetings()
            {
                Console.WriteLine("Hi!");
            }
        }

        class CzechMan : Human {
            public CzechMan(string name, int age) : base(name, age) { }

            public override void SayGreetings()
            {
                Console.WriteLine("Nazdar!");
            }

        }

        class GermanMan : Human
        {
            public GermanMan(string name, int age) : base(name, age) { }

            public override void SayGreetings()
            {
                Console.WriteLine("Hallo!");
            }

        }
    }
}
