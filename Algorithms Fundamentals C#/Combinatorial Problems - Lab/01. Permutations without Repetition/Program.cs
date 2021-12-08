using System;

namespace _01._Permutations_without_Repetition
{
    public class Program
    {
        private static string[] elements;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }
            Permute(permutationsIndex + 1);

            for (int i = permutationsIndex + 1; i < elements.Length; i++)
            {
                Swap(permutationsIndex, i);
                Permute(permutationsIndex + 1);
                Swap(permutationsIndex, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
