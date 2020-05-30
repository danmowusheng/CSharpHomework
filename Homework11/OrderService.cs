using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //获取订单
        public Order GetOrder(int orderNo)
        {
            using (var db = new OrderContext())
            {
                return AllOrders(db).FirstOrDefault(o => o.OrderNo == orderNo);
            }
        }

        //获取所有订单
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderContext())
            {
                return AllOrders(db).ToList();
            }
        }

        //添加订单
        public  Order AddOrder(Order order)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                return order;
            }
            catch (Exception e)
            {

                Console.WriteLine("添加失败"+e.Message);
                return null;
            }
        }

        //以订单号来删除订单
        public void DeleteOrder(int orderNo)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.Include("Items").Where(o => o.OrderNo == orderNo).FirstOrDefault();
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("删除失败" + e.Message);
            }
        }


        //根据订单直接删除
        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
        }


        //修改订单
        public void ModifyOrder(int orderNo)
        {
            RemoveItems(orderNo);
            using (var db = new OrderContext())
            {
                db.Entry(GetOrder(orderNo)).State = EntityState.Modified;
                db.OrderItems.AddRange(GetOrder(orderNo).OrderItems);
                db.SaveChanges();
            }
        }

        //删除订单项
        private void RemoveItems(int orderNo)
        {
            using (var db = new OrderContext())
            {
                var oldItems = db.OrderItems.Where(item => item.OrderNo == orderNo);
                db.OrderItems.RemoveRange(oldItems);
                db.SaveChanges();
            }
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            using (var db = new OrderContext())
            {
                var query = AllOrders(db)
                  .Where(o => o.OrderItems.Count(i => i.GoodsItem.Name == goodsName) > 0);
                return query.ToList();
            }
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            using (var db = new OrderContext())
            {
                var query = AllOrders(db)
                  .Where(o => o.Customer.CustomerName == customerName);
                return query.ToList();
            }
        }

        public object QueryByTotalAmount(float amout)
        {
            using (var db = new OrderContext())
            {
                return AllOrders(db)
                  .Where(o => o.OrderItems.Sum(item => item.GoodsItem.Price * item.num) > amout)
                  .ToList();
            }
        }

        private IQueryable<Order> AllOrders(OrderContext db)
        {
            return db.Orders.Include(o => o.OrderItems.Select(i => i.GoodsItem))
                      .Include("Customer");
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
            //string fileName = "orders.xml";
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
