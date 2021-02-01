using System;
using System.Collections.Generic;
using System.Text;

namespace P08CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacemnt;
        private int efficiency;
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacment { get; set; }
        public string Efficiency { get; set; }

        public Engine (string model,int power)
        {
            this.Model = model;
            this.Power = power;
           
        }
        public Engine(string model, int power, int displacemnt)
            :this(model,power)
        {
            this.Displacment = displacemnt;
        }
        public Engine(string model, int power,string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacemnt,string efficiency)
            : this(model, power,displacemnt)
        {
            this.Efficiency = efficiency;
        }

        public static Engine CreateEngine (string[] engineInfo)
        {
            Engine engine = null;
            string model = engineInfo[0];
            int power = int.Parse(engineInfo[1]);

            if (engineInfo.Length == 2)
            {
                engine = new Engine(model, power);
            }
            else if (engineInfo.Length == 3)
            {
                if (char.IsDigit(engineInfo[2][0]))
                {
                    int displacemnt = int.Parse(engineInfo[2]);
                    engine = new Engine(model, power, displacemnt);
                }
                else
                {
                    string efficiency = engineInfo[2];
                    engine = new Engine(model, power, efficiency);
                }
            }

            else if (engineInfo.Length == 4)
            {
                int displacemnt = int.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];
                engine = new Engine(model,power,displacemnt,efficiency);
            }

            return engine;
        }
    }
}
