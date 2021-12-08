using System;

namespace _05._Combinations_without_Repetition
{
    public class Program
    {
        private static string[] elements;
        private static int lengths;
        private static string[] combinations;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            lengths = int.Parse(Console.ReadLine());
            combinations = new string[lengths];

            Combinations(0,0);
        }

        private static void Combinations(int index,int startindex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = startindex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combinations(index + 1,i + 1);     
            }
        }
    }
}
