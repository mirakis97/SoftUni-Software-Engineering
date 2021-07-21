namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.RightChild = rightChild;
            this.LeftChild = leftChild;
            if (this.RightChild != null)
            {
                rightChild.Parent = this;
            }
            if (this.LeftChild != null)
            {
                leftChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstList = null;
            BinaryTree<T> secondList =  null;
            this.FindNodeDfs(this, first,ref firstList);
            this.FindNodeDfs(this, second,ref secondList);

            List<T> firstTreeParents = this.FindParents(firstList);
            List<T> secondTreeParents = this.FindParents(secondList);

            for (int i = 0; i < firstTreeParents.Count; i++)
            {
                for (int j = 0; j < secondTreeParents.Count; j++)
                {
                    if (firstTreeParents[i].Equals(secondTreeParents[j]))
                    {
                        return firstTreeParents[i];
                    }
                }
            }

            return default;
        }
        private List<T> FindParents(BinaryTree<T> current)
        {
            var result = new List<T>();

            while (current.Parent != null)
            {
                current = current.Parent;
                result.Add(current.Value);
            }

            return result;
        }
        private void FindNodeDfs(BinaryTree<T> current, T lookupValu, ref BinaryTree<T> list)
        {
            if (current == null)
            {
                return;
            }

            if (current.Value.Equals(lookupValu))
            {
                list = current;
                return;
            }
            this.FindNodeDfs(current.LeftChild, lookupValu,ref list);
            this.FindNodeDfs(current.RightChild, lookupValu,ref list);
        }
    }
}
