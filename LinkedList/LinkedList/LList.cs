using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class LList
    {
        public Item firstItem;
        public Item lastItem;
        public int length;

        public LList(Item firstItem)
        {
            this.firstItem = firstItem;
            this.lastItem = firstItem;
            length = 0;
        }

        public void Append(Item item)
        {
            lastItem.next = item;
            lastItem = item;
            lastItem.next = null;
            length++;
        }

        public override string ToString()
        {
            string text = "";

            Item item = firstItem;

            while (item != null)
            {
                text += item.name;
                item = item.next;
            }

            return text;
        }

    }
}
