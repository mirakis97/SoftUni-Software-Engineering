namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root = new HtmlElement(
                ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body)
                    )
            );
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currElement = queue.Dequeue();

                if (currElement.Type == type)
                {
                    return currElement;
                }

                foreach (var child in currElement.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var result = new List<IHtmlElement>();
            this.FindElementByTypeDfs(this.Root, type, result);
            return result;
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.FindHTML(htmlElement) != null;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            this.CheckIfElementExist(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            this.CheckIfElementExist(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            this.CheckIfElementExist(htmlElement);
            this.RemoveReferences(htmlElement, htmlElement.Parent);
        }

        public void RemoveAll(ElementType elementType)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentEl = queue.Dequeue();

                if (currentEl.Type == elementType)
                {
                    var parent = currentEl.Parent;

                    this.RemoveReferences(currentEl, parent);
                }
                else
                {
                    foreach (var child in currentEl.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            this.CheckIfElementExist(htmlElement);
            if (!htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Add(attrKey, attrValue);
                return true;
            }
            return false;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            this.CheckIfElementExist(htmlElement);
            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Remove(attrKey);
                return true;
            }
            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currElement = queue.Dequeue();
                var attributes = currElement.Attributes;

                if (attributes.ContainsKey("id"))
                {
                    if (attributes["id"] == idValue)
                    {
                        return currElement;
                    }
                }

                foreach (var child in currElement.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.CreateTextDfs(this.Root, sb, 0);
            return sb.ToString();
        }



        private void CreateTextDfs(IHtmlElement currEl,StringBuilder sb , int depth)
        {
            sb.AppendLine($"{new string(' ', depth)}{currEl.Type.ToString()}");

            foreach (var child in currEl.Children)
            {
                this.CreateTextDfs(child, sb, depth + 2);
            }
        }
        private void FindElementByTypeDfs(IHtmlElement currentElement, ElementType type,List<IHtmlElement> result)
        {
            foreach (var child in currentElement.Children)
            {
                this.FindElementByTypeDfs(child, type, result);
            }
            if (currentElement.Type == type)
            {
                result.Add(currentElement);
            }
        }
        private IHtmlElement FindHTML(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();
                if (currentElement == htmlElement)
                {
                    return currentElement;
                }

                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }
        private void CheckIfElementExist(IHtmlElement element)
        {
            var found = this.FindHTML(element);
            if (found == null)
            {
                throw new InvalidOperationException("Html element not found in DOM tree!");
            }
        }
        private void RemoveReferences(IHtmlElement currentElement, IHtmlElement parent)
        {
            parent.Children.Remove(currentElement);
            currentElement.Parent = null;
            currentElement.Children.Clear();
        }
    }
}
