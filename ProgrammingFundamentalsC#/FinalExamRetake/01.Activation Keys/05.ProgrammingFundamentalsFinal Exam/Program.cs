using System;
using System.Text;

namespace _05.ProgrammingFundamentalsFinal_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var input = Console.ReadLine();

            while (input != "Generate")
            {
                StringBuilder sb = new StringBuilder();
                var commands = input.Split(">>>",StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Contains")
                {
                    var text = commands[1];
                    if (line.Contains(text))
                    {
                        Console.WriteLine($"{line} contains {text}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (commands[0] == "Flip")
                {
                    var text = commands[1];
                    var startIndex = int.Parse(commands[2]);
                    var endIndex = int.Parse(commands[3]);
                    if (text == "Upper")
                    {
                        line =line.Substring(0,startIndex) + line.Substring(startIndex, endIndex - startIndex).ToUpper() + line.Substring(endIndex);
                        Console.WriteLine(line);
                    }
                    else if(text == "Lower")
                    {
                        line = line.Substring(0, startIndex) + line.Substring(startIndex, endIndex - startIndex).ToLower() + line.Substring(endIndex);

                        Console.WriteLine(line);
                    }
                }
                else if (commands[0] == "Slice")
                {
                    var startIndex = int.Parse(commands[1]);
                    var endIndex = int.Parse(commands[2]);
                    line = line.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(line);

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {line}");

        }
    }
}
