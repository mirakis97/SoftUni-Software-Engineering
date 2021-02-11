using System;

namespace P03Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> mySteck = new MyStack<int>();
            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                string[] commandData = commandInput.Split(new string[] { " ", ", "},StringSplitOptions.RemoveEmptyEntries);
                string cmd = commandData[0];

                if (cmd == "Push")
                {
                    for (int i = 1; i < commandData.Length; i++)
                    {
                        int item = int.Parse(commandData[i]);
                        mySteck.Push(item);
                    }
                }
                else if (cmd == "Pop")
                {
                    mySteck.Pop();
                }
                commandInput = Console.ReadLine();
            }

            foreach (int item in mySteck)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine,mySteck));
        }
    }
}
