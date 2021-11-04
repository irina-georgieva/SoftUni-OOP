using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set 
            {
                ValidateStat(nameof(Length), value);
                length = value; 
            }
        }

        public double Width
        {
            get { return width; }
            private set 
            {
                ValidateStat(nameof(Width), value);
                width = value; 
            }
        }

        public double Height
        {
            get { return height; }
            private set 
            {
                ValidateStat(nameof(Height), value);
                height = value; 
            }
        }

        private void ValidateStat(string varName, double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{varName} cannot be zero or negative.");
            }
        }

        public double SurfaceArea()
            => 2 * (Length * Width + Length * Height + Width * Height);

        public double LateralSurfaceArea()
            => 2 * (Length * Height + Width * Height);

        public double Volume()
            => Length * Width * Height;
    }
}
