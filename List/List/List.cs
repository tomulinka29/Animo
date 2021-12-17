using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class List
    {
        int[] items;
        int count = 0;

        public List()
        {
            items = new int[0];
        }

        public void Reinit(int size)
        {
            //realloc
            Array.Resize(ref items, size);
        }

        public void Add(int newItem)
        {
            if (count >= items.Length)
            {
                Reinit(count + 5);
            }

            items[count] = newItem; 
            count++;
        }

        public void RemoveLast()
        {
            Reinit(count - 1);
            count--;         
        }


        public bool Contains(int item)
        {
            for (int i = 0; i < count; i++)
                if (items[i] == item)
                    return true;
            return false;
        }

        public void Reverse()
        {
            int a = 0;       // first element to swap
            int b = count-1; // with this element
            int temp = 0;
            int i = 0; // we only want to go to the half of the array

            while(i < count)
            {
                temp = items[a];
                items[a] = items[b];
                items[b] = temp;
                b--;
                a++;
                i += 2;
            }
        }

   

        public int this[int index] => items[index];

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < count; i++)
                text += items[i].ToString();
            return text;
        }
    }
}
