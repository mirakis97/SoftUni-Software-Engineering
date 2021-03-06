﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01GenericBoxOfString
{
    public class Box<T>
    {
        public Box (T value)
        {
            this.Value = value;
        }
        private T Value { get; set; }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            string valueTypeFullName = valueType.FullName;
            return $"{valueTypeFullName}: {this.Value}";
        }
    }
} 
