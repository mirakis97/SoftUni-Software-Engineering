using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var firstText = Console.ReadLine();
            var secondText = Console.ReadLine();
            var result = GetMax(type, firstText, secondText);
            Console.WriteLine(result);
        }   
            
        private static string GetMax(string type, string firstText, string secondText)
        {
            var result1 = 0;
            var result2 = 0;
            if (type == "int")
            {
                result1 = int.Parse(firstText);
                result2 = int.Parse(secondText);
            }
            else if (type == "char")
            {
                result1 = char.Parse(firstText);
                result2 = char.Parse(secondText);
            }
            else if (type == "string")
            {
                int comparison = firstText.CompareTo(secondText);    
                if (comparison > 0)                            
                {
                    return firstText;
                }
                else
                {
                    return secondText;
                }
            }
            if (result1 > result2)
            {
                return firstText;
            }
            else
            {
                return secondText;
            }
        }
    }
}
