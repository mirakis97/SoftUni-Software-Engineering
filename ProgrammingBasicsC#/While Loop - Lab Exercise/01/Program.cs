using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();

            int numberOfCheck = 0;
            bool isBookFound = false;
            string nextBook = Console.ReadLine();
            while (nextBook != "No More Books")
            {
                if (nextBook == book )
                {
                    isBookFound = true;
                    break;
                }
                nextBook = Console.ReadLine();
                numberOfCheck++;
            }

            if (isBookFound)
            {
                Console.WriteLine($"You checked {numberOfCheck} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {numberOfCheck} books.");
            }
        }
    }
}
