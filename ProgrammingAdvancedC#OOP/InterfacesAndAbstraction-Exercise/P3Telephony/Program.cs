using System;

namespace P3Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Length == 7)
                {
                    ICallable stPhone = new StationaryPhone();
                    Console.WriteLine(stPhone.Call(numbers[i]));
                }
                else
                {
                    ICallable smPhone = new Smartphone();
                    Console.WriteLine(smPhone.Call(numbers[i]));
                }
            }
            for (int i = 0; i < urls.Length; i++)
            {
                IBrowseable smPhone = new Smartphone();
                Console.WriteLine(smPhone.Browse(urls[i]));
            }
        }
    }
}
