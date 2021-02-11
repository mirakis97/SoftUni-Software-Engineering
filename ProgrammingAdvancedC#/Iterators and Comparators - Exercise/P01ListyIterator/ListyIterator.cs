using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01ListyIterator
{
   public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(params T[] list)
        {
            this.list = new List<T>(list);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index + 1 < this.list.Count)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.index + 1 < this.list.Count;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.list[this.index]);

            }
        }
        public void PrintAll()
        {
            var sb = new StringBuilder();

            foreach (var item in this.list)
            {
                sb.Append(item + " ");
            }

            Console.WriteLine(sb.ToString());
        }



        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;

            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
