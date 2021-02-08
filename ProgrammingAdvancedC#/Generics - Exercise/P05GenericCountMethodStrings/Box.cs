using System;
using System.Collections.Generic;
using System.Text;

namespace P05GenericCountMethodStrings
{
    public class Box<T>
        where T: IComparable
    {
        public Box (T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            string valueTypeFullName = valueType.FullName;
            return $"{valueTypeFullName}: {this.Value}";
        }
    }
} 
