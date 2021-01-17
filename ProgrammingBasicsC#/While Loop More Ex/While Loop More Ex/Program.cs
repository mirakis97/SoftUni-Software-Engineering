using System;

namespace While_Loop_More_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int botles = int.Parse(Console.ReadLine());

            int soap = botles * 750;
            while (true)
            {
                string cmd = Console.ReadLine();
                int dishes = int.Parse(cmd);
                soap -= dishes;
                if (cmd == "End")
                {
                    Console.WriteLine();
                    break;
                }
                

            }
        }
    }
}
