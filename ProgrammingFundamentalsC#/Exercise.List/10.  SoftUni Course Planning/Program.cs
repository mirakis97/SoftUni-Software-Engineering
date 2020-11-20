using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.__SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lesons = Console.ReadLine()
                           .Split(", ")
                           .ToList();

            string comand = Console.ReadLine();

            while (comand != "course start")
            {
                string[] cmdArgs = comand.Split(":").ToArray();
                string firstComand = cmdArgs[0];
                string lessonTitle = cmdArgs[1];

                if (firstComand == "Add")
                {
                    if (!lesons.Contains(lessonTitle))
                    {
                        lesons.Add(lessonTitle);
                    }
                }
                else if (firstComand == "Insert")
                {
                    int index = int.Parse(cmdArgs[2]);
                    if (!lesons.Contains(lessonTitle))
                    {
                        lesons.Insert(index, lessonTitle);
                    }
                }
                else if (firstComand == "Remove")
                {
                    lesons.Remove(lessonTitle);
                }
                else if (firstComand == "Swap")
                {
                    string secondLessonTitle = cmdArgs[2];

                    int indexOfLesson = lesons.IndexOf(lessonTitle);
                    int indexOfSecondLesson = lesons.IndexOf(secondLessonTitle);

                    if (indexOfLesson != -1 & indexOfSecondLesson != -1)
                    {
                        lesons[indexOfLesson] = secondLessonTitle;
                        lesons[indexOfSecondLesson] = lessonTitle;

                        string firstLesseonExercise = $"{lessonTitle}-Exercise";
                        int indexOfFirstExs = indexOfLesson + 1;
                        if (indexOfLesson < lesons.Count && 
                            lesons[indexOfFirstExs] == firstLesseonExercise)
                        {
                            lesons.RemoveAt(indexOfFirstExs);
                            indexOfFirstExs = lesons.IndexOf(lessonTitle);
                            lesons.Insert(indexOfLesson, firstLesseonExercise);
                        }
                        string secondLessonsExs = $"{secondLessonTitle}-Exercise";
                        int indexOfSecondExs = indexOfSecondLesson + 1;
                        if (indexOfSecondExs < lesons.Count &&
                            lesons[indexOfSecondExs] == secondLessonsExs)
                        {
                            lesons.RemoveAt(indexOfSecondLesson + 1);
                            indexOfSecondLesson = lesons.IndexOf(secondLessonTitle);
                            lesons.Insert(indexOfSecondLesson + 1, secondLessonsExs);
                        }
                    }
                }
                else if (firstComand == "Exercise")
                {
                    int index = lesons.IndexOf(lessonTitle);
                    string exercise = $"{lessonTitle}-Exercise";

                    bool isLessonContains = lesons.Contains(lessonTitle);
                    bool isThereExs = lesons.Contains(exercise);

                    if (isLessonContains && !isThereExs)
                    {
                        lesons.Insert(index + 1, exercise);
                    }
                    else if (!isLessonContains)
                    {
                        lesons.Add(lessonTitle);
                        lesons.Add(exercise);
                    }
                }
                comand = Console.ReadLine();
            }

            for (int i = 0; i < lesons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lesons[i]}");
            }
        }
    }
}
