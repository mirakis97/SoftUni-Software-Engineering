using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var elf = new Elf("Gogi", 100);
            Console.WriteLine(elf);
        }
    }
}