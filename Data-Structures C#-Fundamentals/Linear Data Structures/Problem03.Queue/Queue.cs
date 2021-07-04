namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private int size;
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }


        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T value = this.head.Value;
            this.head = this.head.NextNode;

            this.Count--;

            return value;
        }

        public void Enqueue(T item)
        {
            if (this.head == null)
            {
                this.head = new Node<T>(item);
                this.head.Value = item;
                this.tail = this.head;
            }
            else
            {
                var newNode = new Node<T>(item);
                newNode.Value = item;

                this.tail.NextNode = newNode;
                //newNode.Prev = this.tail;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotImplementedException();
    }
}