namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;
        private int size;
        
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            
            return true;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.top.Element;
        }

        public T Pop()
        {
            this.EnsureNonEmpty();
            T element = this.top.Element;
            Node<T> temp = this.top.Next;
            this.top.Next = null;
            this.top = temp;
            this.size--;
            return element;

        }

        private void EnsureNonEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
            this.size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}