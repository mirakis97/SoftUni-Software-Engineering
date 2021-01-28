using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> chekName = ((string n, int x) =>
            {
                int sum = 0;

                for (int i = 0; i < n.Length; i++)
                {
                    sum += n[i];
                }

                bool nameIsValid;

                if (sum >= x)
                {
                    nameIsValid = true;
                }
                else
                {
                    nameIsValid = false;
                }
                return nameIsValid;
            });

            Func<int, string[], Func<string, int, bool>, string> findFirstName = (x, arr, del) =>
               {
                   string result = null;
                   foreach (string name in arr)
                   {
                       if (del(name, x))
                       {
                           result = name;
                           break;
                       }
                   }

                   return result;
               };

            int x = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split()
                .ToArray();
            var reslut = names.Where(n => chekName(n,x)).ToArray();

            Console.WriteLine(findFirstName(x,names,chekName));
        }
    }
}
