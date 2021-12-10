using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cinema
{
    public class Program
    {
        private static HashSet<int> locekedSeats;
        private static List<string> names;
        private static string[] seats;
        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ")
                .ToList();
            seats = new string[names.Count];
            locekedSeats = new HashSet<int>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                seats[position] = name;
                locekedSeats.Add(position);

                names.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                var namesIndex = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (locekedSeats.Contains(i))
                    {
                        continue;
                    }
                    seats[i] = names[namesIndex];
                    namesIndex += 1;
                }
                Console.WriteLine(string.Join(" ",seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
