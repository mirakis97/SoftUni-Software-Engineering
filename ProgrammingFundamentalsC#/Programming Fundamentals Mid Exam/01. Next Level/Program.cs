using System;

namespace _01._Next_Level
{
    class Program
    {
        static void Main(string[] args)
        {
            double expirience = double.Parse(Console.ReadLine());
            int countOFBattels = int.Parse(Console.ReadLine());
            double totalExp = 0;
            int count = 0;

            string cmd = Console.ReadLine();
            while (true)
            {
                count++;
                double expPerBattle = double.Parse(cmd);
                
                if (count % 3 == 0)
                {
                    expPerBattle += expPerBattle * 0.15;
                }
                else if (count % 5 == 0)
                {
                    expPerBattle -= expPerBattle * 0.10;
                }
                else if (count % 15 == 0)
                {
                    expPerBattle += expPerBattle * 0.05;
                }
                totalExp += expPerBattle;
                if (totalExp > expirience)
                {
                    break;
                }
                else if (totalExp < expirience && count == countOFBattels)
                {
                    break;
                }

                cmd = Console.ReadLine();
            }

            if (totalExp > expirience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {count} battles.");
                
            }
            else
            {
                double neededExp = expirience - totalExp;
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExp:f2} more needed.");

                
            }
        }
    }
}
