using System;

namespace _6._Valid_Person
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", "Peshev", 24);
            try
            {
                Person noName = new Person(string.Empty, "Goshev", 31);

            }
            catch (ArgumentNullException ex )
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            try
            {
                Person noLastName = new Person("Ivan", null, 63);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            try
            {
                Person negativeAge = new Person("Gogi", "Kolev", -1);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            try
            {
                Person tooOldForThisProgram = new Person("Divan", "Zvezdev", 121);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);

            }
        }
    }
}
