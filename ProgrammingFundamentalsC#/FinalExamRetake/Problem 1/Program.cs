using System;
using System.Text;
using System.Linq;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string cmd = Console.ReadLine();

            while (cmd != "For Azeroth")
            {
                string[] cmdArgs = cmd.Split();
                string comand = cmdArgs[0];

                if (comand == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }
                else if (comand == "DefensiveStance")
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }
                else if (comand == "Dispel")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string letter = cmdArgs[2];
                    if (index < 0 && index < letter.Length - 1)
                    {
                        Console.WriteLine("Dispel too weak");
                        continue;
                    }
                    else
                    {
                        skill = skill.Replace(index.ToString(), letter);
                        
                         
                        Console.WriteLine("Success!");
                    }
                }
                else if (comand == "Target" && cmdArgs[1] == "Change")
                {
                    string substring = cmdArgs[2];
                    string newSubstring = cmdArgs[3];

                    skill = skill.Replace(substring, newSubstring);
                    Console.WriteLine(skill);
                }
                else if (comand == "Target" && cmdArgs[1] == "Remove")
                {
                    string substring = cmdArgs[2];

                    int index = skill.IndexOf(substring);
                    skill = (index < 0) ? skill : skill.Remove(index, substring.Length);
                    Console.WriteLine(skill);
                    
                }
                else
                {
                    Console.WriteLine("Command doesen't exist");
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
