using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class SoftUniLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public void AddHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;

        }
        public void AddLast (Node node)
        {
            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public Node RemoveHead()
        {
            var nodeToReturn = Head;
            if (Head.Next != null)
            {
                
            }
        }
    }
}
