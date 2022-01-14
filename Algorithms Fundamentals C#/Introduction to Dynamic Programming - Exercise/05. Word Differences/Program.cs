using System;

namespace _05._Word_Differences
{
    public class Program
    {
        static void Main(string[] args)
        {
            var wordOne = Console.ReadLine();
            var wordTwo = Console.ReadLine();

            var lcs = new int[wordOne.Length + 1, wordTwo.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                lcs[r,0] = r;
               
            }
            for (int c = 1; c < lcs.GetLength(1); c++)
            {
                lcs[0, c] = c;
              
            }
            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (wordOne[r - 1] == wordTwo[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1];
                    }
                    else
                    {
                        lcs[r, c] = Math.Min(lcs[r - 1, c] + 1, lcs[r, c - 1] + 1);
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {lcs[wordOne.Length, wordTwo.Length]}");
        }
    }
}
