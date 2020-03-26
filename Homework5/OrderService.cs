using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderManager
{
    class OrderService
    {
        //用list存储订单数据
        public List<Order> orders = new List<Order>();


        public void AddOrder(Order od)
        {
            orders.Add(od);     
        }

        //以订单号来删除订单
        public void DelOrder(int orderNo)
        {
            Order order = QueryByOrderNo(orderNo);
            if (order == null)
            {
                throw new OrderException("Error: No such order");
            }
            else
            {
                orders.Remove(order);
            }
        }

        //根据订单号和类型修改订单
        //type用于控制订单修改的信息
        public void ModifyOrder(int orderNo, int type, string modifyInformation)
        {
            Order order = QueryByOrderNo(orderNo);
            if (order == null)
            {
                throw new OrderException("Error: No such order");
            }

            switch (type)
            {
                case 1:
                    order.CustomerName = modifyInformation;
                    break;
                case 2:
                    order.Address = modifyInformation;
                    break;
            }
        }

        //根据订单号查询订单
        public Order QueryByOrderNo(int orderID)
        {         
            var query = orders.Where(x => x.OrderNo == orderID).OrderBy(s => s.TotalPrice);

            return query.FirstOrDefault();
        }

        //根据商品名称查询订单
        public List<Order> QueryByProductName(string queryContent)
        {
            var query = orders.Where(x => x.orderItems.Exists(y => y.Name.Contains(queryContent))).OrderBy(s => s.TotalPrice);

            return query.ToList();
        }

        //默认排序方法，按照订单号排序
        public void SortOrderList()
        {
            orders.Sort((x, y) => (int)(x.OrderNo - y.OrderNo));
        }

        //使用Lambda表达式进行自定义排序
        public void SortOrderList(Func<Order, Order, int> sortAction)
        {
            orders.Sort((x, y) => sortAction(x, y));
        }
    }
}
