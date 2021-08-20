using System;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string line = Console.ReadLine();
            while (line != "Reveal")
            {
                var command = line.Split(":|:",StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "InsertSpace")
                {
                    int index = int.Parse(command[1]);

                    text = text.Insert(index, " ");
                    Console.WriteLine(text);
                }
                else if (command[0] == "Reverse")
                {
                    var substring = command[1];
                    if (text.Contains(substring))
                    {
                        int substringIndex = text.IndexOf(substring);
                        text = text.Remove(substringIndex, substring.Length);

                        for (int i = substring.Length - 1; i >= 0 ; i--)
                        {
                            text += substring[i];
                        }
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "ChangeAll")
                {
                    var substring = command[1];
                    var replacement = command[2];

                    text = text.Replace(substring, replacement);
                    Console.WriteLine(text);

                }

                line = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}
