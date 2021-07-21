namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var result = new List<T>();
            this.TakeLeft(this, result);
            result.Add(this.Value);
            this.TakeRight(this, result);

            return result;
        }
        private void TakeLeft(BinaryTree<T> current,List<T> result)
        {
            while (current.LeftChild != null)
            {
                current = current.LeftChild;
                result.Add(current.Value);
            }
        }
        private void TakeRight(BinaryTree<T> current, List<T> result)
        {
            while (current.RightChild != null)
            {
                current = current.RightChild;
                result.Add(current.Value);
            }
        }
    }
}
