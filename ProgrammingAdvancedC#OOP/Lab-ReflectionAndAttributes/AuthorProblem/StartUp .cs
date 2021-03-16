using System;

namespace AuthorProblem
{
    [Author("Miro")]
    public class StartUp
    {
        [Author("Mirko")]
        public static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
