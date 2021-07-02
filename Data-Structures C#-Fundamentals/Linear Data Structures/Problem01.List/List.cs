namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
        private int index = 0;

        public T[] items { get; private set; }

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this._items = new T[capacity];
            this.items = this._items;
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get { return index; } }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            this.items[index++] = item;
        }

        private void GrowIfNecessary()
        {
            if (index == this.items.Length)
            {
                this.items = this.Grow();
            }
        }
        private T[] Grow()
        {
            var newArray = new T[index * 2];
            Array.Copy(this.items, newArray, this.items.Length);
            return newArray;
        }
        public bool Contains(T item)
        {
            if (this.items.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.index++;
        }

        public bool Remove(T item)
        {
            if (this.items.Contains(item))
            {
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.index; i++)
            {
                this.items[this.index - 1] = this.items[i + 1];
            }

            this.items[this.index + 1] = default;
            this.index--;
        }
        public void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.index)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.index; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}