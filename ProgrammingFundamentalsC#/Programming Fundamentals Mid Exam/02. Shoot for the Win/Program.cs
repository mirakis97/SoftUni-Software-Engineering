using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targers = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToArray();

            int lastPosition = 0;
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                int index = int.Parse(cmd);
                
                if (index < 0 || index >= targers.Length || targers[index] == -1)
                {
                    cmd = Console.ReadLine();

                    continue;
                }
                int shotTarget = targers[index];
                targers[index] = -1;
                lastPosition++;
                for (int i = 0; i < targers.Length; i++)
                {
                    if (targers[i] == -1)
                    {
                        continue;
                    }
                    if (targers[i] > shotTarget)
                    {
                        targers[i] -= shotTarget;
                    }
                    else
                    {
                        targers[i] += shotTarget;
                    }
                }
                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {lastPosition} -> {string.Join(" ", targers)} ");
        }
    }
}
