using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Gogi");
            list.Add("Ivan");
            list.Add("Dori");
            list.Add("2");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
