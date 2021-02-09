using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(1);
            Node nodeTwo = new Node(2);
            Node nodeThree = new Node(3);
            Node nodeFour= new Node(4);

            head.Next = nodeTwo;
            nodeTwo.Next = nodeThree;
            nodeThree.Next = nodeFour;
        }
    }
}
