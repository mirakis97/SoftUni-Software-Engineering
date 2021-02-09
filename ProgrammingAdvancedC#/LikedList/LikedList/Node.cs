using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class Node
    {
        public Node (int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }
    }
}
