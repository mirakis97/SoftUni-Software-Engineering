using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght,double width,double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get => lenght;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                lenght = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public double GetVolume()
        {
            return lenght * width * height;
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * lenght * height + 2 * width * height;
        }

        public double GetSurfaceArea()
        {
            return 2 * lenght * width + 2 * lenght * height + 2 * width * height;
        }
    }

}
