using System;
using System.Linq;
using System.Text;


namespace FinalExamRetake
{
    class Program
    {
        static void Main(string[] args)
        {
            string messege = Console.ReadLine();

            string comand = Console.ReadLine();

            while (comand != "Reveal")
            {
                string[] cmdArgs = comand.Split(":|:");
                string cmd = cmdArgs[0];
                if (cmd == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);
                    messege = messege.Insert(index, " ");
                    Console.WriteLine(messege);

                }
                else if (cmd == "Reverse")
                {
                    string substring = cmdArgs[1];
                    if (messege.Contains(substring))
                    {
                        var cut = messege.IndexOf(substring);
                        var reversed = "";
                        messege = messege.Remove(cut, substring.Length);
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversed += substring[i];
                        }
                        messege = messege.Insert(messege.Length, reversed);
                        Console.WriteLine(messege);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacment = cmdArgs[2];

                    messege = messege.Replace(substring, replacment);
                    Console.WriteLine(messege);
                }


                comand = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {messege}");
        }
    }
}
