using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;
        private int capacity;
        public int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Student>(Capacity);
        }


        public int Count { get => this.data.Count; }

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName,string lastName)
        {
            Student studentToBeRemoved = this.data.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (studentToBeRemoved == default(Student))
            {
                return "Student not found";
            }
            else
            {
                this.data.Remove(studentToBeRemoved);
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (this.data.Exists(s => s.Subject == subject) == false)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                var result = new StringBuilder();
                result.AppendLine($"Subject: {subject}");
                result.AppendLine("Students:");
                foreach (var student in this.data.Where(s=>s.Subject == subject))
                {
                    result.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return result.ToString().TrimEnd();
            }
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName,string lastName)
        {
            return this.data.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
