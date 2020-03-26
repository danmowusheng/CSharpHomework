using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    class OrderItem
    {

        //订单明细项包括数量，商品名称和金额
        public String Name { get; set; }
        public int num { get; set; }
        public double price { get; set; }

        public OrderItem(string name, double price, int num)
        {
            Name = name;
            this.num = num;
            this.price = price;
        }




        //重写toString方法
        public override string ToString()
        {
            return "goods Name：" + Name + "\n" + "num:" + num + "\n" + "price:" + price;
        }

        //确保物品不重复
        public override bool Equals(object obj)
        {
            OrderItem odi = obj as OrderItem;
            return odi != null && odi.Name == Name && odi.price == price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, num, price);
        }
    }
}
