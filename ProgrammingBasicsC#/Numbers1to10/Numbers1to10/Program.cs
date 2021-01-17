using System;
using System.Reflection.Metadata.Ecma335;

namespace Numbers1to10
{
    class Program
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());
            int area = side * side;

            Console.WriteLine(area);
        }
           
    }
}
