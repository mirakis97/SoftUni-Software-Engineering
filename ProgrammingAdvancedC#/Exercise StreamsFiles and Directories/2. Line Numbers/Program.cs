using System;
using System.Collections.Generic;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            List<char> punctuationMarks = new List<char>() { '-', ',', '.', '!', '?', '\'' };

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = 0;
                int puctuationMarksCount = 0;

                foreach (char ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        lettersCount++;
                    }
                    else if (punctuationMarks.Contains(ch))
                    {
                        puctuationMarksCount++;
                    }
                }
                string newLine =
                $"Line {i + 1}:{line} ({lettersCount})({puctuationMarksCount})";
                Console.WriteLine(newLine);
                File.AppendAllText("output.txt", newLine + Environment.NewLine);
            }
            
        }
    }
}
