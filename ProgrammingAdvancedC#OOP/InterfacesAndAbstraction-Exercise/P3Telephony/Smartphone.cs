using System.Linq;

namespace P3Telephony
{
    public class Smartphone : ICallable,IBrowseable
    {
        public string Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }

        public string Browse(string url)
        {
            if (url.Any(char.IsNumber))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }
    }
}