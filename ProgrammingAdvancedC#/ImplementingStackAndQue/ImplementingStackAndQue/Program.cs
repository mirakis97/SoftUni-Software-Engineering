using System;

namespace ImplementingStackAndQue
{
   public class Program
    {
        public static void Main(string[] args)
        {
            CustomStructures myStack = new CustomStructures();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(40);
            myStack.Push(50);

            Console.WriteLine(myStack);
        }
    }
}
