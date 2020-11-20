using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] tokens = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Contains":
                        if (activationKey.IndexOf(tokens[1]) != -1)
                        {
                            Console.WriteLine($"{activationKey} contains {tokens[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }

                        break;
                    case "Flip":
                        int startIndex = int.Parse(tokens[2]);
                        int endIndex = int.Parse(tokens[3]);

                        if (tokens[1].ToUpper() == "UPPER")
                        {
                            activationKey = activationKey.Substring(0,startIndex) +
                                activationKey.Substring(startIndex, endIndex - startIndex).ToUpper() +
                                activationKey.Substring(endIndex);

                        }
                        else
                        {
                            activationKey = activationKey.Substring(0, startIndex) +
                                activationKey.Substring(startIndex, endIndex - startIndex).ToLower() +
                                activationKey.Substring(endIndex);
                        }
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(tokens[1]);
                        endIndex = int.Parse(tokens[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                }


                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
