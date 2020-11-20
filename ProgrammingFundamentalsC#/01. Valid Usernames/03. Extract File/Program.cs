using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(@"\");

            var file = input[input.Length - 1];
            var lastFile = file.Split(".");

            var name = lastFile[0];
            var extention = lastFile[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}
