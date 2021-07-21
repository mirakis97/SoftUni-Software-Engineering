namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public T Dequeue()
        {
            var firstElement = this.Peek();
            this.Swap(0, this.Size - 1);
            this._elements.RemoveAt(this.Size - 1);
            this.HeapifyDown();
            return firstElement;
        }

        public void Add(T element)
        {
            this._elements.Add(element);
            this.HeapifyUp();
        }

        public T Peek()
        {

            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
            return this._elements[0];
        }
        private void HeapifyUp()
        {
            int currentIndex = this.Size - 1;
            int parentIndex = this.GetParentIndex(currentIndex);

            while (this.ValidateIndex(currentIndex) && this.IsLess(currentIndex, parentIndex))
            {
                var temp = this._elements[currentIndex];
                this._elements[currentIndex] = this._elements[parentIndex];
                this._elements[parentIndex] = temp;
                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(currentIndex);
            }
        }
        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = this._elements[currentIndex];
            this._elements[currentIndex] = this._elements[parentIndex];
            this._elements[parentIndex] = temp;
        }
        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = GetLeftChildIndex(index);
            while (this.ValidateIndex(leftChildIndex) && this.IsGreater(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);

                if (this.ValidateIndex(rightChildIndex) && this.IsGreater(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }
                this.Swap(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = GetLeftChildIndex(index);
            }
        }

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

        private bool IsGreater(int currentIndex, int parentIndex)
            => this._elements[currentIndex].CompareTo(this._elements[parentIndex]) > 0;

        private bool IsLess(int currentIndex, int parentIndex)
            => this._elements[currentIndex].CompareTo(this._elements[parentIndex]) < 0;

        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool ValidateIndex(int index) => index > 0 && index < Size;
    }
}
