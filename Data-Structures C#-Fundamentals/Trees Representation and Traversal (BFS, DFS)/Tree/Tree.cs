namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }
        public bool IsRootDeleted { get; private set; }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                Tree<T> subtree = queue.Dequeue();

                result.Add(subtree.Value);

                foreach (Tree<T> child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();
            this.Dfs(this, result);
            return result;
        }
        public void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }
            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            //DFS
            var parentSubTree = this.FindDfs(parentKey,this);

            //BFS
            //var parentSubTree = this.FindBfs(parentKey);
            this.CheckEmptyNode(parentSubTree);
            parentSubTree._children.Add(child);
        }
        public Tree<T> FindDfs(T value, Tree<T> subtree)
        {
            foreach (var subtreeChild in subtree.Children)
            {
                Tree<T> curr = this.FindDfs(value, subtreeChild);
                if (curr != null && curr.Value.Equals(value))
                {
                    return curr;
                }
            }
            if (subtree.Value.Equals(value))
            {
                return subtree;
            }
            return null;
        }
        public Tree<T> FindBfs(T value)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.Value.Equals(value))
                {
                    return subtree;
                }
                foreach (var subtreeChild in subtree.Children)
                {
                    queue.Enqueue(subtreeChild);
                }
            }
            
            return null;
        }
        public void CheckEmptyNode(Tree<T> parentTree)
        {
            if (parentTree == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void RemoveNode(T nodeKey)
        {
            var currentNode = this.FindBfs(nodeKey);
            this.CheckEmptyNode(currentNode);
            foreach (var child in currentNode.Children)
            {
                child.Parent = null;
            }
            currentNode._children.Clear();
            var parentNode = currentNode.Parent;

            if (parentNode == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(currentNode);
                currentNode.Parent = null;
            }

            currentNode.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);
            this.CheckEmptyNode(firstNode);
            this.CheckEmptyNode(secondNode);
            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                this.SwapRoot(secondNode);
                return;
            }

            if (secondParent == null)
            {
                this.SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent._children.IndexOf(firstNode);
            int indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> node)
        {
            this.Value = node.Value;
            this._children.Clear();
            foreach (var secondNodeChild in node.Children)
            {
                this._children.Add(secondNodeChild);
            }
        }
    }
}
