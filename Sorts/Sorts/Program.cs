using System;
using System.Collections.Generic;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] numbers = new int[10];
            int[] usedIndexes = new int[10];
            int[] sorted = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                Random n = new Random();
                numbers[i] = n.Next(0, 10);
            }

            Console.WriteLine();

            foreach (int i in numbers)
                Console.Write(i + ", ");

            Console.WriteLine();

            for(int i = 0; i < numbers.Length; i++)
            {
                int minIndex = GetMinIndex(numbers);

            }


            Console.WriteLine();

            foreach (int i in numbers)
                Console.Write(i + ", ");

            Console.WriteLine();
        }

        private static int GetMinIndex(int[] numbers)
        {
            int min = int.MaxValue;
            int index = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                    index = i;
                }
            }

            return index;
        }

        
        
    }
}
