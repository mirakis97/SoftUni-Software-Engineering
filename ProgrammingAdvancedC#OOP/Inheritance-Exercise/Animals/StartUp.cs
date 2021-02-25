using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Beast!")
                {
                    break;
                }
                var data = Console.ReadLine().Split();
                var name = data[0];
                var age = int.Parse(data[1]);
                var gender = data[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (line == "Cat")
                {
                    var cat = new Cat(name, age, gender);

                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (line == "Dog")
                {
                    var dog = new Dog(name, age, gender);

                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (line == "Frog")
                {
                    var frog = new Frog(name, age, gender);

                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (line == "Tomcat")
                {
                    var tomcat = new Tomcat(name,age);

                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
                else if (line == "Kitten")
                {
                    var kitten = new Kitten(name, age);

                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
            }
        }
    }
}
