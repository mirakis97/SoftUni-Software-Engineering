using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable
    {
        public List<Book> books;
        public Library (params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        
    }
    //public class LibraryIterator : IEnumerator<Book>
    //{
    //    private readonly List<Book> books;
    //    public int currentIndex;
    //    public LibraryIterator(IEnumerable<Book> books)
    //    {
    //        this.Reset();
    //        this.books = new List<Book>(books);
    //    }

    //    public void Dispose()
    //    {

    //    }
    //    public bool MoveNext() => ++this.currentIndex < this.books.Count;
    //    public void Reset() => this.currentIndex = -1;
    //    public Book Current => this.books[this.currentIndex];
    //    object IEnumerator.Current => this.Current;
    //}
}
