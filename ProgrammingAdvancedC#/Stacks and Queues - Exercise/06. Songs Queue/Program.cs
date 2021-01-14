using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ").ToList();

            Queue<string> songsQue = new Queue<string>();
            foreach (var song in songs)
            {
                songsQue.Enqueue(song);
            }
            

            while (songsQue.Any())
            {
                var cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    songsQue.Dequeue();
                }
                else if (cmd.StartsWith("Add"))
                {
                    var song = cmd.Substring(4);

                    if (songsQue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songsQue.Enqueue(song);
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQue));
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
