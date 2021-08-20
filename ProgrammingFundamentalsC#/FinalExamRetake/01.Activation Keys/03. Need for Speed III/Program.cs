using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"[A-Za-z\d\@]{6,}";
            Regex mail = new Regex(pattern);
            string email = Console.ReadLine();

            string cmd = Console.ReadLine();

            while (cmd != "Valid")
            {
                var cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Validation")
                {
                    var isMatch = mail.Match(email);
                    if (email.Length <= 6)
                    {
                        Console.WriteLine("Email must be at least 6 characters long!");
                    }
                    if (!isMatch.Success)
                    {
                        Console.WriteLine("Email must consist only of letters, digits and @!");
                    }
                    if (isMatch.Success)
                    {
                        string text = isMatch.Value;
                        
                        if (!text.Any(x => char.IsUpper(x)))
                        {
                            Console.WriteLine("Email must consist at least one uppercase letter!");
                        }
                        if (!text.Any(x => char.IsLower(x)))
                        {
                            Console.WriteLine("Email must consist at least one lowercase letter!");
                        }
                        if (!text.Any(x => char.IsDigit(x)))
                        {
                            Console.WriteLine("Email must consist at least one digit!");
                        }
                    }

                }
                else if (cmdArgs[0] == "Upper")
                {
                    StringBuilder sb = new StringBuilder();
                    int index = int.Parse(cmdArgs[1]);

                    for (int i = 0; i < email.Length; i++)
                    {
                        if (i == index)
                        {
                            sb.Append(email[i].ToString().ToUpper());
                        }
                        else
                        {
                            sb.Append(email[i]);
                        }
                    }

                    email = sb.ToString();

                    Console.WriteLine(email);
                }
                else if (cmdArgs[0] == "Lower")
                {
                    StringBuilder sb = new StringBuilder();
                    int index = int.Parse(cmdArgs[1]);

                    for (int i = 0; i < email.Length; i++)
                    {
                        if (i == index)
                        {
                            sb.Append(email[i].ToString().ToLower());
                        }
                        else
                        {
                            sb.Append(email[i]);
                        }
                    }

                    email = sb.ToString();

                    Console.WriteLine(email);
                }
                else if (cmdArgs[0] == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string charecter = cmdArgs[2];

                    email = email.Insert(index, charecter);
                    Console.WriteLine(email);

                }
                else if (cmdArgs[0] == "Change")
                {
                    char character = char.Parse(cmdArgs[1]);
                    int value = int.Parse(cmdArgs[2]);

                    if (!email.Contains(character))
                    {
                        Console.WriteLine(email);
                        continue;
                    }
                    else
                    {

                        value += character;

                        char newCharacter = (char)value;

                        email = email.Replace(character, newCharacter);

                        Console.WriteLine(email);
                    }
                }
                cmd = Console.ReadLine();
            }
        }
        private static bool IsValidIndex(int startIndex)
        {
            return startIndex >= 0;
        }
    }
}
