using System;
using System.Linq;
namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(" ");

            int numberOfRotaion = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotaion; i++)
            {
                string elementOfRotation = arr1[0];

                for (int j = 1; j < arr1.Length; j++)
                {
                    string currentElemen = arr1[j];
                    arr1[j - 1] = currentElemen;
                }
                arr1[arr1.Length - 1] = elementOfRotation;
            }
            Console.WriteLine(string.Join(" ", arr1));
        }
    }
}
 