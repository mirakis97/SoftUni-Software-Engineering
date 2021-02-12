﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03Stack
{
   public class MyStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public MyStack()
        {
            this.items = new List<T>();
        }
        public MyStack(List<T> items)
        {
            this.items = items;
        }

        public void Push(T item)
        {
            this.items.Add(item);
        }

        public T Pop()
        {
            if (this.items.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            int index = this.items.Count - 1;
            T item = this.items[index];
            this.items.RemoveAt(index);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
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
