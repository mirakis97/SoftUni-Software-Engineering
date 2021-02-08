using System;
using System.Collections.Generic;
using System.Linq;

namespace P03GenericSwapMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
          int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            int[] index = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapIndexes(boxes, index[0], index[1]);
            foreach (Box<string> currBox in boxes)
            {
                Console.WriteLine(currBox);
            }
        }
        private static void SwapIndexes<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> temp = boxes[firstIndex];

            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }

    
}

 
