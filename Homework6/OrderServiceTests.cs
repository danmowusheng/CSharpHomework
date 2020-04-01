using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OrderManager.Tests
{
    //orderService的单元测试
    [TestClass()]
    public class OrderServiceTests
    {
        //生成对象调用测试方法
        OrderService os = new OrderService();

        //没有构造方法的测试

        [TestMethod()]
        public void AddOrderTest()
        {
            //检验订单为空时，是否会出错
            os.AddOrder(null);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Order order = new Order();
            os.AddOrder(order);
            //deleteOrder按照订单号删除订单
            os.DeleteOrder(order.OrderNo);
            Assert.IsTrue(os.orders.Count == 0);
        }

        [TestMethod()]
        public void ModifyOrderTest1()
        {
            //订单默认的客户为 LJ，  默认地址为 Wuhan University
            Order order = new Order();
            int type1 = 1;
            string customer = "LJM";
            os.AddOrder(order);

            //修改客户名，检查是否出错
            os.ModifyOrder(order.OrderNo, 1, customer);
            Assert.AreEqual(os.orders[0].CustomerName, customer);
        }

        [TestMethod()]
        public void ModifyOrderTest2()
        {
            //订单默认的客户为 LJ，  默认地址为 Wuhan University
            Order order = new Order();
            int type1 = 2;
            string address = "hunan";
            os.AddOrder(order);

            //修改地址，检查是否出错
            os.ModifyOrder(order.OrderNo, 1, address);
            Assert.AreEqual(os.orders[0].CustomerName, address);
        }

        [TestMethod()]
        public void QueryByOrderNoTest()
        {
            Order order = new Order();
            os.AddOrder(order);
            Assert.AreEqual(order, os.QueryByOrderNo(order.OrderNo));
        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Order order = new Order();
            os.AddOrder(order);
            Assert.AreEqual(order, os.QueryByGoodsName(order.orderItems[0].Name));
        }

        [TestMethod()]
        public void QueryByCustomerTest()
        {
            Order order = new Order();
            os.AddOrder(order);
            Assert.AreEqual(order, os.QueryByCustomer(order.CustomerName));
        }

        [TestMethod()]
        public void SortOrderListTest()
        {
            //排序后的结果应为order1, order2, order3
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();
            os.AddOrder(order2);
            os.AddOrder(order1);
            os.AddOrder(order3);
            os.SortOrderList();
            //构造一个顺序排列的列表
            List<Order> sortList = new List<Order>();
            sortList.Add(order1);
            sortList.Add(order2);
            sortList.Add(order3);

            Assert.AreEqual(sortList, os.orders);
        }

        [TestMethod()]
        public void SortOrderListTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            //产生XML文件的输出路径
            string filepath = "C:/Users/LJ/source/repos/OrderManager/OrderManager/bin/Debug/netcoreapp3.1/orders.xml";
            //检测依据为是否检测出对应的XML文件
           
            Order order1 = new Order();

            //生成订单
            OrderItem orderItem = new OrderItem("apple",5,10);
            order1.AddOrderItem(orderItem);

            //产生序列化为XML文件
            os.Export();
                        
            //判断成功依据为是否产生了该XML文件
            FileInfo file = new FileInfo(filepath);
            Assert.IsTrue(file.Exists);
        }

        [TestMethod()]
        public void ImportTest()
        {
            //用XML文件生成orderlist
            os.Import();
            Assert.IsTrue(os.orders.Count!=0);
        }
    }
}
