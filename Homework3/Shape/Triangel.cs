using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Triangel:Shape
    {
        private double mya = 0;
        private double myb = 0;
        private double myc = 0;

        public Triangel(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double a
        {
            get { return mya; }
            set { mya = value; }
        }

        public double b
        {
            get { return myb; }
            set { myb = value; }
        }

        public double c
        {
            get { return myc; }
            set { myc = value; }
        }
        override public double Area()
        {
            //用海伦公式来求面积
            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        override public bool isLegal()
        {
            //用三边关系来判断三角形是否合理
            if ( c < (a + b)  &&  a < (b + c)  && b < (a + c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
