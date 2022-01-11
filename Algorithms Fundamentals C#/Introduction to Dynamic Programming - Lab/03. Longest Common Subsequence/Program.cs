using System;

namespace _03._Longest_Common_Subsequence
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
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (wordOne[r - 1] == wordTwo[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r,c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            Console.WriteLine(lcs[wordOne.Length,wordTwo.Length]);
        }
    }
}
