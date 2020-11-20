using System;
using System.Text;
using System.Linq;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string messege = Console.ReadLine();

            string comand = Console.ReadLine();

            while (comand != "Decode")
            {
                string[] cmdArgs = comand.Split("|");
                string cmd = cmdArgs[0];

                if (cmd == "Move")
                {
                    int n = int.Parse(cmdArgs[1]);
                    
                    for (int i = 0; i < n; i++)
                    {
                        string temp = messege[0].ToString();

                        messege = messege.Remove(0,1);
                        messege += temp;
                    }
                    

                }
                else if (cmd == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    messege = messege.Insert(index, value);
                }
                else if (cmd == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacment = cmdArgs[2];

                    messege = messege.Replace(substring, replacment);
                }

                comand = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {messege}");
        }
    }
}
