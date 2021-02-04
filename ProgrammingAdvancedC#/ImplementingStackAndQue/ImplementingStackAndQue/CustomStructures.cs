using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackAndQue
{
    public class CustomStructures
    {
        private const int InitialCapacity = 4;
        private int[] array;

        public CustomStructures()
        {
            this.array = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[this.Count] = element;
            this.Count++;
        }
        public int Pop()
        {

            this.Validate();
            int element = this.array[this.Count - 1];
            this.array[this.Count - 1] = default;
            this.Count--;
            if (this.Count == this.array.Length / 4)
            {
                this.Shrink();
            }
            return element;
        }
        public int Peek()
        {
            this.Validate();

            return this.array[this.Count - 1];
        }
        public void ForEach(Action<int> action)
        {
            foreach (int num in this.array)
            {
                action(num);
            }
        }
        private void Validate()
        {
            if (this.array.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }
        private void Shrink()
        {
            int[] copy = new int[this.array.Length / 2];
            Array.Copy(this.array, copy, this.Count);
            this.array = copy;
        }

        private void Resize()
        {
            int[] copy = new int[this.array.Length * 2];
            Array.Copy(this.array,copy,this.Count);
            this.array = copy;
        }
    }
}
