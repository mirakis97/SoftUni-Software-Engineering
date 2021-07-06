namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T>(item);
            }
            else
            {
                var newHead = new Node<T>(item);
                newHead.Next = this.head;
                this.head.PreviousNode = newHead;

                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T>(item);
            }
            else
            {
                var newTail = new Node<T>(item);
                newTail.PreviousNode = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            return head.Item;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            Node<T> currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Item;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var firstelement = this.head.Item;
            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstelement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            var lastElement = this.tail.Item;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}