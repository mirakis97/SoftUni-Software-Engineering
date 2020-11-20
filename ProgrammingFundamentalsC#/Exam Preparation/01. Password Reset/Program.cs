using System;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string comand = Console.ReadLine();

            while (comand != "Done")
            {
                string[] cmdArg = comand
                    .Split();
                string cmd = cmdArg[0];

                if (cmd == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            sb.Append(password[i]);
                        }
                    }

                    password = sb.ToString();
                    Console.WriteLine(password);
                }
                else if (cmd == "Cut")
                {
                    int index = int.Parse(cmdArg[1]);
                    int lenght = int.Parse(cmdArg[2]);
                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (cmd == "Substitute")
                {
                    string substring = cmdArg[1];
                    string substitute = cmdArg[2];
                    if (password.Contains(substring))
                    {
                       password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
