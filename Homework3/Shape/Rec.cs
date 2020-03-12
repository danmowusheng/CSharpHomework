using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Rec:Shape
    {
        private double mywidth = 0;
        private double myheight = 0;

        public Rec(double w, double h)
        {
            this.Height = h;
            this.Width = w;
        }
        public double Width
        {
            get { return mywidth; }
            set { mywidth = value; }
        }

        public double Height
        {
            get { return myheight; }
            set { myheight = value; }
        }

        

        override public double Area()
        {
            if(isLegal())
            return (Width * Height);
            throw new Exception("该正方形不存在");
        }

        override public bool isLegal()
        {
            return (Width>0 && Height>0);
        }
    }
}
