using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Factory
    {
        //随机创建10个形状对象，计算这些对象的面积之和。 
        //尝试使用简单工厂设计模式来创建对象。
        Random r = new Random();

        public Shape GetShape(int type)
        {
                switch (type) 
                {
                    case 0:
                        return new Rec(10*r.NextDouble(), 10 * r.NextDouble());

                    case 1:
                        return new Square(10 * r.NextDouble());
                       
                    case 2:
                    //三角形的生成还需要判断
                        Triangel t =  new Triangel(10 * r.NextDouble(), 10 * r.NextDouble(),10 * r.NextDouble());
                    while (!t.isLegal())
                    {
                        t = new Triangel(10 * r.NextDouble(), 10 * r.NextDouble(), 10 * r.NextDouble());
                    }
                        return t;
                    default:
                        return null;
                }  
            

        }



    }
}
