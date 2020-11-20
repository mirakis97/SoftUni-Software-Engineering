using System;
using System.Text;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            string password = string.Empty;
            for (int i = name.Length -1; i >= 0; i--)
            {
                password += name[i];
            }
            int count = 0;
            while (true)
            {
                string currentUser = Console.ReadLine();

                if (currentUser != password)
                {
                    count++;

                    if (count == 4)
                    {
                        Console.WriteLine($"User {name} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {name} logged in");
                    break;
                }
            }
        }
    }
}
