﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P07Tuple
{
    public class MyTuple<T1, T2>
    {
        public MyTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> { this.Item2}";
        }
    }
}
