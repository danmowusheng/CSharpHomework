using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            Factory f = new Factory();
            Shape[] shapes = new Shape[10];
            double totalArea = 0;

            //将工厂产生的形状放入shapes中
            for(int i = 0; i < 10; i++)
            {
                shapes[i] = f.GetShape(rd.Next(0, 3));
                //以下一行为测试代码
                Console.WriteLine("第"+(i+1)+"个形状的面积为："+shapes[i].Area());
                totalArea += shapes[i].Area();
            }

            Console.WriteLine(totalArea);

        }
    }
}
