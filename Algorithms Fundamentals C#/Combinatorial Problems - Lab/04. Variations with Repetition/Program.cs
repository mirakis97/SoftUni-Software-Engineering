using System;

namespace _04._Variations_with_Repetition
{
    public class Program
    {
        private static string[] elements;
        private static int lengths;
        private static string[] variations;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            lengths = int.Parse(Console.ReadLine());
            variations = new string[lengths];

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
                variations[permutationsIndex] = elements[index];
                Variations(permutationsIndex + 1);
            }
        }
    }
}
