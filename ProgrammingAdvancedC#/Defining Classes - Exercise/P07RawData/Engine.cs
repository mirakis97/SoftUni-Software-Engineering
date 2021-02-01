using System;
using System.Collections.Generic;
using System.Text;

namespace P07RawData
{
    public class Engine
    {
        private int speed;
        private int power;

        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine (int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}
