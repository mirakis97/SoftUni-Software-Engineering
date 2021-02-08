using System;
using System.Collections.Generic;
using System.Linq;

namespace P04GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] index = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapIndexes(boxes, index[0], index[1]);
            foreach (Box<int> currBox in boxes)
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

