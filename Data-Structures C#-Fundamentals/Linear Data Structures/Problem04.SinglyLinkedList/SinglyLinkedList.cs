namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;

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
                newTail.PrevNode = this.tail;
                this.tail.NextNode = newTail;
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
            return head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            Node<T> currentNode = head;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            return currentNode.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var firstelement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PrevNode = null;
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
            var lastElement = this.tail.Value;
            this.tail = this.tail.PrevNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
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
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}