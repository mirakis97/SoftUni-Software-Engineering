namespace Problem03.Queue
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node<T> NextNode { get; set; }

        public Node<T> PrevNode { get; set; }

        public T Value { get; set; }
    }
}