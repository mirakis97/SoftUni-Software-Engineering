using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (comand != "end")
            {
                string[] cmdArgs = comand.Split(" : ");
                string courcesName = cmdArgs[0];
                string studentName = cmdArgs[1];

                if (!courses.ContainsKey(courcesName))
                {
                    courses.Add(courcesName, new List<string>());
                }
                courses[courcesName].Add(studentName);

                comand = Console.ReadLine();
            }

            foreach (var currCourse in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{currCourse.Key}: {currCourse.Value.Count}");

                foreach (var item in currCourse.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }

            
        }
    }
}
