using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class Item
    {
        public string name;
        public Item next;

        public Item(string name, Item next)
        {
            this.name = name;
            this.next = next;
        }
    }
}
