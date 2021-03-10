using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Custom_Exception
{
    public class InvalidEmailAddress : Exception
    {
        public InvalidEmailAddress()
        {
        }

        public InvalidEmailAddress(string message)
            : base(message)
        {
        }
    }
}
