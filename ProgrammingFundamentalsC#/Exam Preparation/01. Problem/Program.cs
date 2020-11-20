using System;
using System.Linq;
using System.Text;
namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string comand = Console.ReadLine();

            while (comand != "Finish")
            {
                string[] cmdArgs = comand.Split();
                string cmd = cmdArgs[0];

                if (cmd == "Replace")
                {
                    var currChar = cmdArgs[1];
                    var newChar = cmdArgs[2];

                    text = text.Replace(currChar, newChar);
                    Console.WriteLine(text);
                }
                else if (cmd == "Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    if (startIndex <= 0 && endIndex <= 0 && endIndex > text.Length)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        string temp = text[0].ToString();
                        text = text.Remove(0, 1);
                        text += temp;
                    }
                    
                    Console.WriteLine(text);
                }
                else if (cmd == "Make")
                {
                    string cmd2 = cmdArgs[1];
                    if (cmd2 == "Upper")
                    {
                        text = text.ToUpper();
                        Console.WriteLine(text);
                    }
                    else
                    {
                        text = text.ToLower();
                        Console.WriteLine(text);
                    }
                }
                else if (cmd =="Check")
                {
                    string check = cmdArgs[1];
                    if (text.Contains(check))
                    {
                        Console.WriteLine($"Message contains {check}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {check}");
                    }
                }
                else if (cmd == "Sum")
                {
                    var startIndex = int.Parse(cmdArgs[1]);
                    var endIndex = int.Parse(cmdArgs[2]);
                    if (startIndex <= 0 && endIndex <= 0 && endIndex > text.Length)
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    text = text.Substring(startIndex,endIndex);
                    string value = text;
                    int sum = 0;
                    byte[] ascciBytes = Encoding.ASCII.GetBytes(value);
                    foreach (byte b in ascciBytes)
                    {

                        sum += b;
                        
                    }
                    Console.WriteLine(sum);
                }

                comand = Console.ReadLine();
            }

        }
    }
}
