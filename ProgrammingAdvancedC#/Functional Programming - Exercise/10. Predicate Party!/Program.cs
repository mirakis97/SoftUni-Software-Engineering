using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleComing = Console.ReadLine()
                .Split()
                .ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] comand = input.Split();

                Predicate<string> checkName = CheckIfNameIsValid(comand);

                if (comand[0] == "Double")
                {
                    for (int n = 0; n < peopleComing.Count; n++)
                    {
                        string currGuest = peopleComing[n];

                        if (checkName(currGuest))
                        {
                            peopleComing.Insert(n + 1, currGuest);
                            n++;
                        }
                    }
                }
                else if (comand[0] == "Remove")
                {
                    for (int n = 0; n < peopleComing.Count; n++)
                    {
                        string currGuest = peopleComing[n];

                        if (checkName(currGuest))
                        {
                            peopleComing.Remove(currGuest);
                            n--;
                        }
                    }
                }

            }
            Action<List<string>> print = ((list) =>
            {
                string result;
                if (list.Count == 0)
                {
                    result = "Nobody is going to the party!";
                }
                else
                {
                    result = $"{string.Join(", ",list)} are going to the party!";
                }
                Console.WriteLine((result));
            });

            print(peopleComing);
        }

        static Predicate<string> CheckIfNameIsValid(string[] command)
        {
            Predicate<string> checkName = null;

            {
                bool nameIsValid = false;

                if (command[1] == "StartsWith")
                {
                    checkName = new Predicate<string>(n =>
                    {
                        if (n.StartsWith(command[2]))
                        {
                            nameIsValid = true;
                        }
                        else
                        {
                            nameIsValid = false;
                        }

                        return nameIsValid;
                    });


                }
                else if (command[1] == "EndsWith")
                {
                    checkName = new Predicate<string>(n =>
                    {
                        if (n.EndsWith(command[2]))
                        {
                            nameIsValid = true;
                        }
                        else
                        {
                            nameIsValid = false;
                        }

                        return nameIsValid;
                    });

                }
                else if (command[1] == "Length")
                {
                    checkName = new Predicate<string>(n =>
                    {
                        if (n.Length == int.Parse(command[2]))
                        {
                            nameIsValid = true;
                        }
                        else
                        {
                            nameIsValid = false;
                        }
                        return nameIsValid;
                    });

                };
            }

            return checkName;
        }
    }
}
