namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            int depth = 0;
            this.OrderDfsForString(depth, sb, this);
            return sb.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var leafNodes = this.OrderBfsNodes().Where(node => node.IsLeaf(node));
            int deepestNoteDepth = 0;

            Tree<T> deepestNode = null;

            foreach (var leafNode in leafNodes)
            {
                int currentDepth = this.GetDepthFromLeafToParent(leafNode);
                if (currentDepth > deepestNoteDepth)
                {
                    deepestNoteDepth = currentDepth;
                    deepestNode = leafNode;
                }
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            Func<Tree<T>, bool> leafKeyPrdicate = (node) => this.IsLeaf(node);

            return this.OrderBfs(leafKeyPrdicate);

        }

        public List<T> GetMiddleKeys()
        {
            bool MiddleKeyPredicate(Tree<T> node) => this.IsMiddle(node);
            return this.OrderBfs(MiddleKeyPredicate);
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestLeftomostNode();
            var result = new Stack<T>();
            var current = deepestNode;
            while (current != null)
            {
                result.Push(current.Key);
                current = current.Parent;
            }

            return new List<T>(result);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            var currentPath = new List<T>();
            currentPath.Add(this.Key);
            int curentSum = Convert.ToInt32(this.Key);
            this.GetPathsWithsSumDfs(this, result, currentPath, ref curentSum, sum);
            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            GetSubTreesWithGivenSum(this, sum, 0, result);
            return result;
        }


        public void OrderDfsForString(int depth, StringBuilder sb, Tree<T> subTree)
        {
            sb.Append(new string(' ', depth)).Append(subTree.Key).Append(Environment.NewLine);
            foreach (var subTreehild in subTree.Children)
            {
                this.OrderDfsForString(depth + 2, sb, subTreehild);
            }
        }
        private bool HasGivenSum(Tree<T> currentNode,int sum)
        {
            int actualSum = this.GetSubTreeSumDfs(currentNode);
            return actualSum == sum;
        }
        private int GetSubTreeSumDfs(Tree<T> currentNode)
        {
            int currentSum = Convert.ToInt32(currentNode.Key);
            int childSum = 0;
            foreach (var currentNodeChild in currentNode.Children)
            {
                childSum += this.GetSubTreeSumDfs(currentNodeChild);
            }
            return childSum + currentSum;
        }
        private int GetDepthFromLeafToParent(Tree<T> leafNode)
        {
            int depth = 0;
            var curNode = leafNode;
            while (curNode.Parent != null)
            {
                depth++;
                curNode = curNode.Parent;
            }

            return depth;
        }
        private List<T> OrderBfs(Func<Tree<T>, bool> predicate)
        {
            var result = new List<T>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();
                if (predicate.Invoke(currentNode))
                {
                    result.Add(currentNode.Key);
                }

                foreach (var currentNodeChild in currentNode.Children)
                {
                    nodes.Enqueue(currentNodeChild);
                }
            }
            return result;
        }
        private int GetSubTreesWithGivenSum(Tree<T> tree, int target, int sum, List<Tree<T>> result)
        {
            sum = Convert.ToInt32(tree.Key);
            foreach (var child in tree.Children)
            {
                sum += GetSubTreesWithGivenSum(child, target, sum, result);
            }

            if (sum == target)
            {
                result.Add(tree);
            }

            return sum;
        }

        private List<Tree<T>> OrderBfsNodes(Func<Tree<T>, int, bool> predicate, int sum)
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();
                if (predicate.Invoke(currentNode, sum))
                {
                    result.Add(currentNode);
                }

                foreach (var currentNodeChild in currentNode.Children)
                {
                    nodes.Enqueue(currentNodeChild);
                }
            }
            return result;
        }
        private List<Tree<T>> OrderBfsNodes()
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                result.Add(currentNode);

                foreach (var currentNodeChild in currentNode.Children)
                {
                    nodes.Enqueue(currentNodeChild);
                }
            }
            return result;
        }
        private void GetPathsWithsSumDfs(Tree<T> current, List<List<T>> result, List<T> curentPath, ref int currentSum, int sum)
        {
            foreach (var child in current.Children)
            {
                curentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                this.GetPathsWithsSumDfs(child, result, curentPath, ref currentSum, sum);
            }

            if (currentSum == sum)
            {
                result.Add(new List<T>(curentPath));
            }

            currentSum -= Convert.ToInt32(current.Key);
            curentPath.RemoveAt(curentPath.Count - 1);
        }
        private bool IsLeaf(Tree<T> node) => node.Children.Count == 0;
        private bool IsRoot(Tree<T> node) => node.Parent == null;
        private bool IsMiddle(Tree<T> node) => node.Parent != null && node.Children.Count > 0;

    
    }
}
