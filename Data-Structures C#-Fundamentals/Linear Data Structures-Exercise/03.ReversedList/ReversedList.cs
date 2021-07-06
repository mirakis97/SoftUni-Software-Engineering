namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;
        private int index = 0;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this._items[index++] = item;
            this.Count++;
            this.GrowIfNecessary();
        }

        private void GrowIfNecessary()
        {
            if (index == this._items.Length)
            {
                this._items = this.Grow();
            }
        }
        private T[] Grow()
        {
            var newArray = new T[index * 2];
            Array.Copy(this._items, newArray, this._items.Length);
            return newArray;
        }
        public bool Contains(T item)
        {
            if (this._items.Contains(item))
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
                if (this._items[i].Equals(item))
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
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.index++;
        }

        public bool Remove(T item)
        {
            if (this._items.Contains(item))
            {
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Count; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.index + 1] = default;
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
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}