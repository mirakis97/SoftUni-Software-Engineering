using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] token = line.Split();

                string firstName = token[0];
                string lastNme = token[1];
                int age = int.Parse(token[2]);
                string city = token[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastNme,
                    Age = age,
                    City = city

                };

                students.Add(student);
                line = Console.ReadLine();
            }
            string filterCity = Console.ReadLine();

            List<Student> filterStudnets = students
                .Where(s => s.City == filterCity)
                .ToList();

            foreach (Student student in filterStudnets)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}
