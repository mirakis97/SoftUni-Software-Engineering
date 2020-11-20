using System;
using System.Text;
using System.Linq;
namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string cmd = Console.ReadLine();

            while (cmd != "Decode")
            {
                string[] cmdArgs = cmd.Split("|");
                string comand = cmdArgs[0];
                if (comand == "Move")
                {
                    int n = int.Parse(cmdArgs[1]);
                    for (int i = 0; i < n; i++)
                    {
                        var temp = message[0].ToString();
                        message = message.Remove(0, 1);
                        message += temp;
                    }
                }
                else if (comand == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    message = message.Insert(index, value);

                }
                else if (comand == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacment = cmdArgs[2];

                    message = message.Replace(substring, replacment);
                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
