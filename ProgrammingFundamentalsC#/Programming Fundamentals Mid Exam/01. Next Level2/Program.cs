using System;

namespace _01._Next_Level2
{
    class Program
    {
        static void Main(string[] args)
        {
            double expirience = double.Parse(Console.ReadLine());
            int countOFBattels = int.Parse(Console.ReadLine());
            double totalExp = 0;
            int count = 0;
            bool IsUnlock = false;

            for (int i = 0; i < countOFBattels; i++)
            {
                count++;

                double expPerBattle = double.Parse(Console.ReadLine());

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

                if (totalExp >= expirience)
                {
                    IsUnlock = true;
                    break;
                }
            }

            double expLeft = expirience - totalExp;

            if (IsUnlock || totalExp >= expirience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {count} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {expLeft:f2} more needed.");
            }
        }
    }
}
