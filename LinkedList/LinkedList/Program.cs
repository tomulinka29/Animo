using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Item c = new Item("c", null);
              Item b = new Item("b", c);
              Item a = new Item("a", b);
            */

            Item a = new Item("a", null);
            LList llist = new LList(a);

            Item b = new Item("b", null);
            llist.Append(b);
            Console.WriteLine(llist.ToString());
        }
    }
}
