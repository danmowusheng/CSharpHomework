using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OrderManager2._0
{
    public class OrderService
    {
        //用list存储订单数据
        public List<Order> Orders { get; set; }

        //用于测试序列化与反序列化
        XmlSerializer xmlSerializer;

        public OrderService()
        {
            Orders = new List<Order>();
            try
            {
                xmlSerializer = new XmlSerializer(typeof(List<Order>));
            }
            catch (Exception e)
            {
                Console.WriteLine("发生未知错误" + e.Message);
            }

        }


        //添加订单
        public void AddOrder(Order od)
        {
            Orders.Add(od);
        }

        //以订单号来删除订单
        public void DeleteOrder(int orderNo)
        {
            //首先查询到该订单
            Order order = QueryByOrderNo(orderNo);

            if (order == null)
            {
                //若未查询到，则抛出异常
                throw new OrderException("该订单不存在");
            }
            else
            {
                //在订单信息中删除该条订单
                Orders.Remove(order);
            }
        }


        //根据订单直接删除
        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
        }

        //根据订单号和类型修改订单
        //type用于控制订单修改的信息
        public void ModifyOrder(int orderNo, int type, string modifyInformation)
        {
            //首先查询到该订单
            Order order = QueryByOrderNo(orderNo);
            if (order == null)
            {
                throw new OrderException("该订单不存在,无法修改");
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
        public Order QueryByOrderNo(int orderNo)
        {
            var query = Orders.Where(x => x.OrderNo == orderNo).OrderBy
                (s => s.TotalPrice);

            return query.FirstOrDefault();
        }

        //根据商品名称查询订单
        public List<Order> QueryByGoodsName(string queryContent)
        {
            var query = Orders.Where(x => x.OrderItems.Exists(y => y.Name.Contains(queryContent))).OrderBy
                (s => s.TotalPrice);

            return query.ToList();
        }

        //根据客户名查询订单
        public List<Order> QueryByCustomer(string customerName)
        {
            var query = Orders.Where(x => x.CustomerName == customerName).OrderBy
                (s => s.TotalPrice);
            return query.ToList();
        }

        //默认排序方法，按照订单号排序
        public void SortOrderList()
        {
            Orders.Sort((x, y) => (int)(x.OrderNo - y.OrderNo));
        }

        //使用Lambda表达式进行自定义排序
        public void SortOrderList(Func<Order, Order, int> sortAction)
        {
            Orders.Sort((x, y) => sortAction(x, y));
        }


        //添加Export方法和Impor方法

        //可以将所有的订单序列化为XML文件
        public void Export(string fileName)
        {
            try
            {              
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, Orders);
                }
                Console.WriteLine("成功生成XML文件！ 序列化为XML文件后如下： \n");
                Console.WriteLine(File.ReadAllText(fileName));
            }
            catch (Exception)
            {
                Console.WriteLine("生成XML文件出错!");
            }


        }


        //Import方法可以从XML文件中载入订单
        public void Import(string fileName)
        {
            String fileName = "orders.xml";
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                List<Order> orderList = (List<Order>)xmlSerializer.Deserialize(fs);
                Console.WriteLine("\n 反序列化为orders列表");

                foreach (Order order in orderList)
                {
                    Orders.Add(order);
                }
            }

        }
    }
}
