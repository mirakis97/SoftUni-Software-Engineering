using System;

namespace Shapes
{
    public abstract class Circle : Shape
    {
        private double radius;

        protected Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius
        {
            get { return this.radius; }
            private set
            {
                this.radius = value;
            }
        }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}