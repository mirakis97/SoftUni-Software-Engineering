namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        public Node<T> Head { get { return _head; } set { } }
        public Node<T> Last { get; set; }
        

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);
            newHead.Next = Head;
            if (Head == null)
            {
                Last = newHead;
            }
            Head = newHead;
            Count++;
        }

        public void AddLast(T item)
        {
            if (Head == null)
            {
                Head = new Node<T>(item);
                Head.Next = null;
            }
            else
            {
                Node<T> toAdd = new Node<T>(item);

                Node<T> current = Head;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = toAdd;
            }
            Count++;
        }

        public T GetFirst()
        {
            T temp = default(T);

            Node<T> curr = Head;

            while (curr != null)
            {
                temp = curr.Value;
                curr = curr.Next;
            }

            return temp;
        }

        public T GetLast()
        {
            T lastElement = default(T);
            Node<T> curr = Last;
            while (curr != null)
            {
                lastElement = curr.Value;
                curr = curr.Next;
            }

            return lastElement;
        }

        public T RemoveFirst()
        {
            T oldHead = Head.Value;
            Head = Head.Next;
            if (Head == null)
            {
                Last = null;
            }
            return oldHead;
        }

        public T RemoveLast()
        {
            T oldHead = Last.Value;
            Last = Last.Next;
            if (Head == null)
            {
                Last = null;
            }
            return oldHead;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}