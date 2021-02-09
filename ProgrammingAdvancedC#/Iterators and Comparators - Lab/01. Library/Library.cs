using System.Collections;
using System.Collections.Generic;


namespace IteratorsAndComparators
{
    public class Library<T> : IEnumerable<Book>
    {

        public Library(params Book[] books)
        {
            this.Books = new SortedSet<Book>(books, new BookComparator());
        }


        public SortedSet<Book> Books { get; set; }



        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in this.Books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }




        //private class LibraryIterator : IEnumerator<Book>
        //{         

        //    public LibraryIterator(IEnumerable<Book> books)
        //    {
        //        this.Reset();

        //        this.Books = new List<Book>(books);

        //    }



        //    public List<Book> Books { get; set; }

        //    public int CurrentIndex { get; set; }





        //    public Book Current => this.Books[CurrentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose() { }

        //    public bool MoveNext() => ++this.CurrentIndex < Books.Count;

        //    public void Reset() => this.CurrentIndex = -1;
        //}
    }
}