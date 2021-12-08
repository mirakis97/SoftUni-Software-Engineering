using System;

namespace _03._Variations_without_Repetition
{
    public class Program
    {
        private static string[] elements;
        private static int lengths;
        private static string[] variations;
        private static bool[] used;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            lengths = int.Parse(Console.ReadLine());
            variations = new string[lengths];
            used = new bool[elements.Length];

            Variations(0);
        }

        private static void Variations(int permutationsIndex)
        {
            if (permutationsIndex >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int index = 0; index < elements.Length; index++)
            {
                if (!used[index])
                {
                    used[index] = true;
                    variations[permutationsIndex] = elements[index];
                    Variations(permutationsIndex + 1);
                    used[index] = false;
                }
            }
        }
    }
}
