using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    class Order
    {
       
        //该订单类包含客户，商品列表，总金额，订单号，商家,下单时间等属性
        public int OrderNo { get; set; }
        public double TotalPrice { get; set; }
        public String CustomerName { get; set; }
        public String Address { get; set; }
        public List<OrderItem> orderItems;
        private DateTime OrderTime { get; set; }       

        //构造方法中生成订单号
        public Order()
        {
            OrderTime = DateTime.Now;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            OrderNo = Convert.ToInt32(ts.TotalSeconds);     //使用时间戳作为订单号
            orderItems = new List<OrderItem>();
            TotalPrice = 0;
        }

        //添加订单明细项
        public void AddOrderItem(OrderItem orderItem)
        {
            foreach (OrderItem item in orderItems)
            {
                if (item.Equals(orderItem))
                {
                    throw new OrderException("请勿重复添加订单");
                }
            }

            orderItems.Add(orderItem);
            TotalPrice += orderItem.price * orderItem.num;
        }

        //删除订单明细项
        public void DelOrderItem(OrderItem orderItem)
        {
            foreach (OrderItem item in orderItems)
            {
                if (item.Equals(orderItem))
                {
                    throw new OrderException("不能删除不存在的订单");
                }
            }

            orderItems.Remove(orderItem);
            TotalPrice -= orderItem.price * orderItem.num;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("************************\n");
            stringBuilder.Append($"订单号: \t{OrderNo}\n");
            stringBuilder.Append($"下单时间: \t{OrderTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            stringBuilder.Append("************************\n");
            stringBuilder.Append("订单详情\n");
            foreach (OrderItem item in orderItems)
            {
                stringBuilder.Append("************************\n");
                stringBuilder.Append($"{item}\n");
            }
            stringBuilder.Append("************************\n");
            stringBuilder.Append($"总价: \tCNY￥{TotalPrice}\n");
            stringBuilder.Append("************************");
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            Order od = obj as Order;
            return od != null && od.OrderNo == OrderNo;
        }

        
    }
}
