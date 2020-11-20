using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            int peopleOnTheCurrentWagon = 0;

            int peopleOnTheLift = 0;
            bool NoMorePeople = false;
            for (int i = 0; i < lift.Length; i++)
            {
                while (lift[i] < 4)
                {
                    lift[i]++;
                    peopleOnTheCurrentWagon++;
                    if (peopleOnTheLift + peopleOnTheCurrentWagon == people)
                    {
                        NoMorePeople = true;
                        break;
                    }

                }

                peopleOnTheLift += peopleOnTheCurrentWagon;

                if (NoMorePeople)
                {
                    break;
                }

                peopleOnTheCurrentWagon = 0;

            }

            if (people > peopleOnTheLift)
            {
                Console.WriteLine($"There isn't enough space! {people - peopleOnTheLift} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (peopleOnTheLift < lift.Length * 4 && lift.Any(l => l < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (lift.All(l => l == 4) && NoMorePeople == true)
            {
                Console.WriteLine(string.Join(" ", lift));
            }
        }
    }
}
