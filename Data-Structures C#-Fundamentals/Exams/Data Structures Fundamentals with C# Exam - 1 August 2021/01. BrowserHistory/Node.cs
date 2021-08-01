using System;
using System.Collections.Generic;
using System.Text;

namespace _01._BrowserHistory
{
    public class Node<ILink>
    {
        public Node(ILink value,Node<ILink> nextChild = null,Node<ILink> prevChild = null)
        {
            this.Value = value;
            this.NextChild = nextChild;
            this.PreviouseChild = prevChild;
        }
        public ILink Value { get; set; }
        public Node<ILink> NextChild { get; set; }
        public Node<ILink> PreviouseChild { get; set; }
    }
}
