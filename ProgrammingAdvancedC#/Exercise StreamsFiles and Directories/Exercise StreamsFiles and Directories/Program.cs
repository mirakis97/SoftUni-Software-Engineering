using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_StreamsFiles_and_Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../text.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                string chars = "-,.!?";
                int counter = 0;

                while (line != null)
                {
                    if (counter++ % 2 == 0)
                    {

                        foreach (var item in chars)
                        {
                            line = line.Replace(item, '@');
                        }
                        string[] splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", splittedLine));
                    }
                    line = reader.ReadLine();
                }

            }
        }
    }
}

