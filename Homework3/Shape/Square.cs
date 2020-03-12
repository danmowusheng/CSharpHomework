using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Square:Shape
    {
        private double mylen = 0;

        public Square(double l)
        {
            this.len = l;
        }

        public double len
        {
            get { return mylen; }
            set { mylen = value; }
        }
        override public  double Area()
        {
            if(isLegal())
            return len * len;
            throw new Exception ("该矩形不存在");
        }

        override public bool isLegal()
        {
            return (len > 0);   
        }
    }
}
