using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _06._Students_2
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
                if (IsStudentExist(students, firstName, lastNme))
                {
                    Student student = GetStudent(students, firstName, lastNme);

                    student.FirstName = firstName;
                    student.LastName = lastNme;
                    student.Age = age;
                    student.City = city;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastNme,
                        Age = age,
                        City = city

                    };

                    students.Add(student);
                }
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
        static public bool IsStudentExist(List<Student> students, string fistName, string lastName)
        {
            foreach (Student studnet in students)
            {
                if (studnet.FirstName == fistName && studnet.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student studen in students)
            {
                if (studen.FirstName == firstName && studen.LastName == lastName)
                {
                    existingStudent = studen;
                }
            }

            return existingStudent;
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
