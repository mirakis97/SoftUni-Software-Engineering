using System;
using System.Collections.Generic;

namespace _06._Word_Cruncher
{
    public class Program
    {
        private static string target;
        private static string current;
        private static Dictionary<int, List<string>> wordsByLen;
        private static Dictionary<string, int> counter;
        private static List<string> selectedWords;

        private static HashSet<string> currentWords = new HashSet<string>();
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target= Console.ReadLine();
            
            wordsByLen = new Dictionary<int ,List<string>>();
            counter = new Dictionary<string, int>();
            selectedWords = new List<string>();

            foreach (var word in words)
            {
                if (!target.Contains(word))
                {
                    continue;
                }
                
                var len = word.Length;

                if (!wordsByLen.ContainsKey(len))
                {
                    wordsByLen.Add(len, new List<string>());
                }

                if (counter.ContainsKey(word))
                {
                    counter[word] += 1;
                }
                else
                {
                    counter.Add(word,1);
                }

                wordsByLen[len].Add(word);
            }
            current = String.Empty;
            GenSolution(target.Length);
            Console.WriteLine(string.Join(Environment.NewLine,currentWords));
        }

        private static void GenSolution(int length)
        {
            if (length == 0)
            {
                if (current == target)
                {
                    currentWords.Add(string.Join(" ", selectedWords));
                }
                return;
            }

            foreach (var kvp in wordsByLen)
            {
                if (kvp.Key > length)
                {
                    continue;
                }

                foreach (var word in kvp.Value)
                {
                    if (counter[word] > 0)
                    {

                        current += word;
                        if (IsMatching(target, current))
                        {
                            counter[word] -= 1;
                            selectedWords.Add(word);
                            GenSolution(length - word.Length);
                            counter[word] += 1;
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                        }
                        current = current.Remove(current.Length - word.Length, word.Length);
                    }
                }
            }
        }

        private static bool IsMatching(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
