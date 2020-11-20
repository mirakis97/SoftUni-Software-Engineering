using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfGrades = new Dictionary<string, List<double>>();
            int pairOfRow = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairOfRow; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!listOfGrades.ContainsKey(studentName))
                {
                    listOfGrades.Add(studentName, new List<double>());
                }
                listOfGrades[studentName].Add(grade);
            }
            
            foreach (var eachStudent in listOfGrades.OrderByDescending(x => x.Value.Average()))
            {

                if (eachStudent.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{eachStudent.Key} -> {eachStudent.Value.Average():f2}");
                }
            }
        
        }
    }
}
