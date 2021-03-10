using System;
using System.Runtime.Serialization;

namespace _7._Custom_Exception
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string message)
            : base(message)
        {
        }
    }
}