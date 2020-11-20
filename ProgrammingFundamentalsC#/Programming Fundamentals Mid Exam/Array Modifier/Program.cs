using System;
using System.Linq;

namespace Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string cmd = Console.ReadLine();

            while (cmd != "end")
            {
                string[] comands = cmd.Split(" "); ;
                string token = comands[0];

                switch (token)
                {
                    case "swap":
                        int idnex1 = int.Parse(comands[1]);
                        int idnex2 = int.Parse(comands[2]);
                        if (idnex1 >= 0 && idnex1 < numbers.Length &&
                            idnex2 >= 0 && idnex2 < numbers.Length)
                        {
                            int temp = numbers[idnex1];
                            numbers[idnex1] = numbers[idnex2];
                            numbers[idnex2] = temp;
                        }
                        break;
                    case "multiply":
                        idnex1 = int.Parse(comands[1]);
                        idnex2 = int.Parse(comands[2]);
                        if (idnex1 >= 0 && idnex1 < numbers.Length &&
                            idnex2 >= 0 && idnex2 < numbers.Length)
                        {
                            int temp = numbers[1] * numbers[2];
                            numbers[idnex1] = temp;
                        }
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            int temp = numbers[i] - 1;
                            numbers[i] = temp;
                        }
                        break;

                }

                cmd = Console.ReadLine();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length - 1)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
