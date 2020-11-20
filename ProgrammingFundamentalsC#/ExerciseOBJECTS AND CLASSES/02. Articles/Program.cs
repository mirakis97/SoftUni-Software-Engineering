using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(", ");
            Article article = new Article(tokens[0],tokens[1],tokens[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");
                string comand = cmd[0];
                string argument = cmd[1];
                switch (comand)
                {
                    case "Edit":
                        article.Edit(argument);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(argument);
                        break;

                    case "Rename":
                        article.Rename(argument);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Tittle = title;
            Content = content;
            Author = author;
        }

        public string Tittle { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void Rename(string title)
        {
            Tittle = title;
        }

        public override string ToString()
        {
            return $"{Tittle} - {Content}: {Author}"; 
        }
    }
}
