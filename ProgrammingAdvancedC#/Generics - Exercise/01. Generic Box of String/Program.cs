using System;

namespace P01GenericBoxOfString
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
               // Box<string> box = new Box<string>(Console.ReadLine());
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));

                Console.WriteLine(box);
            }
        }
    }
}
