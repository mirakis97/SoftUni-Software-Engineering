 using System;

namespace Data_Types_and_Variables___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInteger = int.Parse(Console.ReadLine());
            int secondInteger = int.Parse(Console.ReadLine());
            int thirdInteger = int.Parse(Console.ReadLine());
            int fourthInteger = int.Parse(Console.ReadLine());

            int addFirstToSecond = firstInteger + secondInteger;
            int dividedByThird = addFirstToSecond / thirdInteger;
            int multiplyByFourth = dividedByThird * fourthInteger;

            Console.WriteLine(multiplyByFourth);
        }
    }
}
