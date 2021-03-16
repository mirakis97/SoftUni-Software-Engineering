using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t == typeof(StartUp)).ToArray();

            foreach (var type in allTypes)
            {
                PrintAllMethodsAuthors(type);
                continue;
                if (!type.GetCustomAttributes().Any(t=> t.GetType() == typeof(AuthorAttribute)))
                {
                    continue;
                }
                AuthorAttribute[] attributes = type.GetCustomAttributes().Where(t=>t.GetType() == typeof(AuthorAttribute)).Select(t=> (AuthorAttribute)t).ToArray();

                foreach (var attr in attributes)
                {
                    Console.WriteLine($"{type.Name} created by {attr.Name}");
                }
            }
        }

        private void PrintAllMethodsAuthors(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            foreach (var method in methods)
            {
                if (!method.GetCustomAttributes().Any(a=>a.GetType() == typeof (AuthorAttribute)))
                {
                    continue;
                }

                Attribute[] attributes = method.GetCustomAttributes().ToArray();

                foreach (var attr in attributes)
                {
                    if (attr is AuthorAttribute)
                    {
                        AuthorAttribute author = (AuthorAttribute)attr;
                    }
                }
            }
        }

    }
}
