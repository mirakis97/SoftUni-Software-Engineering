using System;
using System.Xml.Schema;

namespace _04._Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOne = Console.ReadLine();
            string nameTwo = Console.ReadLine();

            int playerOnePoints = 0;
            int playerTwoPoints = 0;

            while (true)
            {
                string cmd = Console.ReadLine();

                int cardPlayrOne = int.Parse(Console.ReadLine());
                int cardPlayerTwo = int.Parse(Console.ReadLine());
                if (cmd == "End of game")
                {
                    Console.WriteLine($"{nameOne} has {playerOnePoints} points");
                    Console.WriteLine($"{nameTwo} has {playerTwoPoints} points");
                   Environment.Exit(0);
                }
                if (cardPlayrOne > cardPlayerTwo )
                {
                    playerOnePoints = cardPlayrOne - cardPlayerTwo;
                }
                if (playerTwoPoints > playerOnePoints)
                {
                    playerTwoPoints = cardPlayerTwo - cardPlayrOne;


                }


                if (cardPlayrOne == cardPlayerTwo)
                {
                    Console.WriteLine($"Number wars!");
                    cardPlayrOne = Console.Read();
                    cardPlayerTwo = Console.Read();
                    if (cardPlayrOne > cardPlayerTwo)
                    {
                        Console.WriteLine($"{nameOne} is winner with {playerOnePoints} points");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"{nameTwo} is winner with {playerTwoPoints} points");
                        Environment.Exit(0);
                    }
                }
            }
            
        }
    }
}
