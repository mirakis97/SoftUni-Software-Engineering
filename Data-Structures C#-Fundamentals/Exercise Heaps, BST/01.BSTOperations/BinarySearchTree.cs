namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Copy(root);
        }

        public Node<T> Root { get; private set; }
        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }
        public void Copy(Node<T> current)
        {
            if (current != null)
            {
                this.Insert(current.Value);
                this.Copy(current.LeftChild);
                this.Copy(current.RightChild);
            }
        }
        public int Count => this.Root.Count;


        public bool Contains(T element)
        {
            Node<T> currentNode = this.Root;

            while (currentNode != null)
            {
                if (this.IsLess(element, currentNode.Value))
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (this.IsGreater(element, currentNode.Value))
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(T element)
        {
            var itemToInsert = new Node<T>(element, null, null);
            if (Root == null)
            {
                this.Root = itemToInsert;
            }
            else
            {
                var current = this.Root;
                Node<T> prev = null;
                Root.Count++;
                while (current != null)
                {
                    prev = current;
                    if (this.IsLess(element, current.Value))
                    {
                        current = current.LeftChild;

                    }
                    else if (this.IsGreater(element, current.Value))
                    {
                        current = current.RightChild;
                    }
                    else
                    {
                        return;
                    }
                }

                if (IsLess(element, prev.Value))
                {
                    prev.LeftChild = itemToInsert;
                    if (this.LeftChild == null)
                    {
                        this.LeftChild = itemToInsert;
                    }
                }
                else
                {
                    prev.RightChild = itemToInsert;
                    if (this.RightChild == null)
                    {
                        this.RightChild = itemToInsert;
                    }
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            Node<T> current = this.Root;
            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }
            return new BinarySearchTree<T>(current);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderDfs(this.Root, action);
        }
        private void EachInOrderDfs(Node<T> current,Action<T> action)
        {
            if (current != null)
            {
                this.EachInOrderDfs(current.LeftChild, action);
                action.Invoke(current.Value);
                this.EachInOrderDfs(current.RightChild, action);
            }
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();
            var nodes = new Queue<Node<T>>();
            nodes.Enqueue(Root);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();
                if (this.IsLess(lower,current.Value)&& this.IsGreater(upper,current.Value))
                {
                    result.Add(current.Value);
                }
                else if (this.AreEqual(lower,current.Value) || this.AreEqual(upper,current.Value))
                {
                    result.Add(current.Value);
                }

                if (current.LeftChild != null)
                {
                    nodes.Enqueue(current.LeftChild);   
                }

                if (current.RightChild != null)
                {
                    nodes.Enqueue(current.RightChild);
                }
            }
            return result;
        }

        public void DeleteMin()
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }
            Node<T> current = Root;
            Node<T> previous = null;

            if (this.Root.LeftChild == null)
            {
                this.Root = this.RightChild;
            }
            else
            {
                while (current.LeftChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.LeftChild;
                }

                previous.LeftChild = current.RightChild;
            }
        }

        public void DeleteMax()
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }
            Node<T> current = Root;
            Node<T> previous = null;

            if (this.Root.RightChild == null)
            {
                this.Root = this.LeftChild;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.RightChild;
                }

                previous.RightChild = current.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return this.GetRankDfs(Root, element);
        }
        private int GetRankDfs(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (this.IsLess(element,current.Value))
            {
                return this.GetRankDfs(current.LeftChild, element);
            }
            else if (this.AreEqual(element, current.Value))
            {
                return this.GetNodeCount(current);
            }
            return this.GetNodeCount(current.LeftChild) + 2 + this.GetRankDfs(current.RightChild, element);
        }
        private int GetNodeCount(Node<T> current) => current?.Count ?? 0;

        private bool IsGreater(T element, T currentValue)
         => element.CompareTo(currentValue) > 0;

        private bool IsLess(T element, T currentValue)
            => element.CompareTo(currentValue) < 0;
        private bool AreEqual(T element, T currentValue)
            => element.CompareTo(currentValue) == 0;
    }
}
