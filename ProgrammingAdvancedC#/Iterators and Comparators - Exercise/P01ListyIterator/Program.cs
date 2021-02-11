using System;
using System.Collections.Generic;
using System.Linq;

namespace P01ListyIterator
{
   public class Program
    {
        static void Main(string[] args)
        {

            string[] items = Console.ReadLine().Split(" ").Skip(1).ToArray();
            ListyIterator<string> list = new ListyIterator<string>(items);


            string comand = Console.ReadLine();

            while (comand != "END")
            {
                switch (comand)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "PrintAll":
                        list.PrintAll();
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                        
                        break;
                }
                comand = Console.ReadLine();
            }
        }
    }
}
