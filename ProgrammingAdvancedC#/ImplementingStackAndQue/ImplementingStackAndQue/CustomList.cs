using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackAndQue
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] array;

        public CustomList()
        {
            this.array = new int[InitialCapacity];
        }
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.array[index];
            }
            set
            {
                ValidateIndex(index);
                this.array[index] = value;
            }
        }
        public void Add(int number)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[this.Count] = number;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);
            int number = this.array[index];
            this.array[index] = default;
            this.Shift(index);
            this.Count--;
            if (this.Count == this.array.Length / 4)
            {
                this.Shrink();
            }
            return number;
        }
        public void Insert(int index, int number)
        {
            if (index > this.array.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid index");

                if (this.Count == this.array.Length)
                {
                    this.Resize();
                }
                this.ShiftRight(index);
                this.array[index] = number;
                this.Count++;
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }
        public bool Contains (int number)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i] == number)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap (int index,int secondIndex)
        {
            this.ValidateIndex(index);
            this.ValidateIndex(secondIndex);

            int firstNum = this.array[index];
            this.array[index] = this.array[secondIndex];
            this.array[secondIndex] = this.array[index];
        }
        private void Shrink()
        {
            int[] copy = new int[this.array.Length / 2];
            Array.Copy(this.array,copy,this.Count);

            this.array = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.array[this.Count - 1] = 0;
        }

        private void ValidateIndex(int index)
        {

            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }
        }
        private void Resize()
        {
            int[] copy = new int[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                copy[i] = this.array[0];
            }

            this.array = copy;
        }
    }
}
