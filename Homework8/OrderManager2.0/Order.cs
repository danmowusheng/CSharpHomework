using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManager2._0
{
    //添加public访问符号，order可被序列化
    [Serializable]
    public class Order
    {
        //该订单类包含客户，商品列表，总金额，订单号，商家,下单时间等属性
        public int OrderNo { get; set; }
        public double TotalPrice { get; set; }
        public String CustomerName { get; set; }
        public String Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        private DateTime OrderTime { get; set; }

        public Order() { OrderItems = new List<OrderItem>(); }

        //构造方法中生成订单号
        public Order(string customer,string address)
        {
            OrderTime = DateTime.Now;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            OrderNo = Convert.ToInt32(ts.TotalSeconds);     //使用时间戳作为订单号
            TotalPrice = 0;
            CustomerName = customer;                  
            Address = address;         
        }

        //添加订单明细项
        public void AddOrderItem(OrderItem orderItem)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (item.Equals(orderItem))
                {
                    throw new OrderException("请勿重复添加订单");
                }
            }

            OrderItems.Add(orderItem);
            TotalPrice += orderItem.price * orderItem.num;
        }

        //删除订单明细项
        public void DeleteOrderItem(OrderItem orderItem)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (!item.Equals(orderItem))
                {
                    throw new OrderException("不能删除不存在的订单");
                }
            }

            OrderItems.Remove(orderItem);
            TotalPrice -= orderItem.price * orderItem.num;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("************************\n");
            stringBuilder.Append($"订单号: \t{OrderNo}\n");
            stringBuilder.Append($"下单时间: \t{OrderTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            stringBuilder.Append($"下单客户：\t{CustomerName}\n");
            stringBuilder.Append($"地址：\t{Address}\n");
            stringBuilder.Append("************************\n");
            stringBuilder.Append("订单详情\n");
            foreach (OrderItem item in OrderItems)
            {
                stringBuilder.Append("************************\n");
                stringBuilder.Append($"{item}\n");
            }
            stringBuilder.Append("************************\n");
            stringBuilder.Append($"总价: \t￥{TotalPrice}\n");
            stringBuilder.Append("************************");
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            Order od = obj as Order;
            return od != null && od.OrderNo == OrderNo;
        }

        public override int GetHashCode()
        {
            var hashCode = -30792662;
            hashCode = hashCode * -1521134295 + OrderNo.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            hashCode = hashCode * -1521134295 + OrderTime.GetHashCode();
            return hashCode;
        }
    }
}
