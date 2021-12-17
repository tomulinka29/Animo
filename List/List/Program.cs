using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();

            list.Add(6);
            list.Add(6);
            list.Add(6);
            list.Add(5);
            list.Add(4);
            list.Add(3);

            Console.WriteLine(list.ToString());
            list.Reverse();
            Console.WriteLine(list.ToString());
        }
    }
}
