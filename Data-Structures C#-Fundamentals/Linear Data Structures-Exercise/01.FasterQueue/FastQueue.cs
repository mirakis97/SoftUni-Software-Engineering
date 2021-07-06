namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this.head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var oldhead = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldhead.Item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }
            this.tail.Next = newNode;
            this.tail = this.tail.Next;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

    }
}