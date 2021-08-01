namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private Node<ILink> head;
        private Node<ILink> _tail;



        public int Size { get; private set; }

        public void Clear()
        {
            this.head = this._tail = null;
            this.Size = 0;
        }

        public bool Contains(ILink link)
        {
            return this.GetByUrl(link.Url) != null;
        }

        public ILink DeleteFirst()
        {
            this.IsEmpty();

            var firstElement = this._tail;
            if (this.Size == 1)
            {
                this.head = this._tail = null;
            }
            else
            {
                this._tail = this._tail.PreviouseChild;
                this._tail.NextChild = null;
            }
            this.Size--;
            return firstElement.Value;
        }

        public ILink DeleteLast()
        {
            this.IsEmpty();

            var lastElement = this.head;
            if (this.Size == 1)
            {
                this.head = this._tail = null;
            }
            else
            {
                this.head = this.head.NextChild;
                this.head.PreviouseChild = null;
            }
            this.Size--;
            return lastElement.Value;
        }

        public ILink GetByUrl(string url)
        {
            var currElement = this.head;
            while (currElement != null)
            {
                if (currElement.Value.Url == url)
                {
                    return currElement.Value;
                }
                currElement = currElement.NextChild;
            }
            return null;
        }

        public ILink LastVisited()
        {
            this.IsEmpty();
            return this.head.Value;
        }

        public void Open(ILink link)
        {
            var linkToPut = new Node<ILink>(link);
            if (this.Size == 0)
            {
                this.head = this._tail = linkToPut;
            }
            else
            {
                this.head.PreviouseChild = linkToPut;
                linkToPut.NextChild = this.head;
                this.head = linkToPut;
            }
            this.Size++;
        }

        public int RemoveLinks(string url)
        {
            var currElement = this.head;
            int count = 0;
            while (currElement != null)
            {
                if (currElement.Value.Url.Contains(url))
                {
                    var previousElement = currElement.PreviouseChild;
                    var nextElement = currElement.NextChild;

                    if (previousElement != null)
                    {
                        previousElement.NextChild = nextElement;
                    }
                    else
                    {
                        this.head = this.head.NextChild;
                    }

                    if (nextElement != null)
                    {
                        nextElement.PreviouseChild = previousElement;
                    }
                    else
                    {
                        this._tail = this._tail.PreviouseChild;
                    }

                    count++;
                    this.Size--;
                }
                currElement = currElement.NextChild;
            }

            if (count == 0)
            {
                throw new InvalidOperationException("No links with the given url!");
            }
            return count;
        }

        public ILink[] ToArray()
        {
            ILink[] result = new ILink[this.Size];

            int index = 0;
            var currentElement = this.head;

            while (currentElement != null)
            {
                result[index++] = currentElement.Value;
                currentElement = currentElement.NextChild;
            }
            return result;
        }

        public List<ILink> ToList()
        {
            List<ILink> result = new List<ILink>(this.Size);

            var currentElement = this.head;

            while (currentElement != null)
            {
                result.Add(currentElement.Value);
                currentElement = currentElement.NextChild;
            }
            return result;
        }

        public string ViewHistory()
        {
            if (this.Size == 0)
            {
                return "Browser history is empty!";
            }
            StringBuilder sb = new StringBuilder();
            var currentElement = this.head;

            while (currentElement != null)
            {
                sb.AppendLine(currentElement.Value.ToString());
                currentElement = currentElement.NextChild;
            }

            return sb.ToString();
        }


        private void IsEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Browser history is empty!");
            }
        }
    }
}
