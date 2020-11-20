using System;
using System.Text;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string messege = Console.ReadLine();

            string comand = Console.ReadLine();

            while (comand != "Reveal")
            {
                string[] cmdArg = comand.Split(":|:");
                string cmd = cmdArg[0];
                if (cmd == "InsertSpace")
                {
                    int index = int.Parse(cmdArg[1]);
                    var space = messege.Length;
                    var line1 = messege.Substring(0, index);
                    var line2 = messege.Substring(index);
                    messege = line1 + " " + line2;
                    Console.WriteLine(messege);
                }
                else if (cmd == "Reverse")
                {
                    string substring = cmdArg[1];

                    if (messege.Contains(substring))
                    {
                        var reverse = string.Empty;
                        var index = messege.IndexOf(substring);

                        messege = messege.Remove(index, substring.Length);

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reverse += substring[i];
                            
                        }


                        messege = messege.Insert(messege.Length, reverse);
                        Console.WriteLine(messege);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "ChangeAll")
                {
                    string substring = cmdArg[1];
                    string replacment = cmdArg[2];

                     messege = messege.Replace(substring, replacment);
                    Console.WriteLine(messege);
                }


                comand = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {messege}");
        }
    }
}
