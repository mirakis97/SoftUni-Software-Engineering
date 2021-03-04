using System.Linq;

namespace P3Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Dialing... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}