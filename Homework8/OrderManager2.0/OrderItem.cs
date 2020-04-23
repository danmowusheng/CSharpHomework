using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager2._0
{
    public class OrderItem
    {
        //订单明细项包括数量，商品名称和金额
        public String Name { get; set; }
        public int num { get; set; }
        public double price { get; set; }

        //运行程序时，报错“There was an error reflecting type ”
        //怀疑原因为OrderItem类没有构造函数
        //添加构造函数后，程序运行通过,XML序列化时，与之有关的类都必须拥有无参构造函数
        public OrderItem()
        {

        }

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
            var hashCode = -900244421;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + num.GetHashCode();
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            return hashCode;
        }
    }

}
