﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    abstract class Shape
    {
        //编写面向对象程序实现长方形、正方形、三角形等形状的类。
        //每个形状类都能计算面积、判断形状是否合法。
        //请尝试合理使用接口/抽象类、属性来实现。


        //随机创建10个形状对象，计算这些对象的面积之和。 
        //尝试使用简单工厂设计模式来创建对象。
        public abstract double Area();

        public abstract bool isLegal();
        

        
        
    }
}