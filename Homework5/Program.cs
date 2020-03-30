using System;
using System.Collections.Generic;

namespace OrderManager
{
    class Program
    {
        public OrderService os;

        static void Main(string[] args)
        {          
            Program p = new Program();
            p.ShowMenu();
        }

        public void ShowMenu()
        {
            os = new OrderService();
            
            int opInt=0;           
            Console.WriteLine("********欢迎来到商城********");
            while (opInt != 6)
            {
                Console.WriteLine("请输入你的操作：1,添加订单 2,删除订单 3,修改订单 4,查询订单 5,查看所有订单 6,退出");
                if(!int.TryParse(Console.ReadLine(),out opInt))
                {
                    Console.WriteLine("您输入的操作数违法,请重新输入!");
                    continue;
                }
                

                if (opInt < 1 || opInt > 6)
                {
                    Console.WriteLine("您输入的操作数违法,请重新输入!");
                    continue;
                }

                switch (opInt)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("请输入您想购买的商品名称:");
                            string goodsName = Console.ReadLine();
                            while (goodsName=="")
                            {
                                Console.WriteLine("输入的商品不能为空！请重新输入！ \n");
                                Console.WriteLine("请输入您想购买的商品名称:");
                                goodsName = Console.ReadLine();
                            }
                            Console.WriteLine("请输入该商品的价格:");
                            int price;
                            while (!int.TryParse(Console.ReadLine(), out price))
                            {
                                Console.WriteLine("商品价格格式出错！请重新输入价格! \n");
                                Console.WriteLine("请输入该商品的价格:");
                            }
                            Console.WriteLine("请输入您想购买的商品数量:");

                            int num ;
                            while (!int.TryParse(Console.ReadLine(), out num))
                            {
                                Console.WriteLine("商品数量格式出错！请重新输入! \n");
                                Console.WriteLine("请输入您想购买的商品数量:");
                            }
                            //用获得信息生成订单明细
                            OrderItem orderItem = new OrderItem(goodsName, price, num);

                            //然后生成该订单
                            Order order = new Order();

                            order.AddOrderItem(orderItem);      //AddOrderItem方法避免了添加重复订单项
                            os.AddOrder(order);

                            Console.WriteLine("添加订单成功!");
                        }
                        catch (OrderException)
                        {
                            Console.WriteLine("您输入的数据不符合格式！");
                        }
                        
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("请输入您想删除的订单号:");

                            int orderNo1;

                            while (!int.TryParse(Console.ReadLine(), out orderNo1))
                            {
                                Console.WriteLine("订单格式不正确,请重新输入!");
                                Console.WriteLine("请输入您想删除的订单号:");
                            }
                            //DeleteOrder会抛出OrderException异常
                            os.DeleteOrder(orderNo1);
                            Console.WriteLine("删除订单成功!");
                        }
                        catch (OrderException)
                        {
                            Console.WriteLine("订单格式不正确 或 订单号错误，请检查！\n");
                        }                        
                        

                        break;
                    case 3:
                        Console.WriteLine("请输入您想修改的订单号:");
                        try
                        {
                            int orderNo2;

                            while (!int.TryParse(Console.ReadLine(), out orderNo2))
                            {               
                                Console.WriteLine("您输入的订单号格式不正确，请重新输入! \n");
                                Console.WriteLine("请输入您想修改的订单号:");
                            }

                            //若该订单未被查询到
                            while (os.QueryByOrderNo(orderNo2) == null)
                            {
                                Console.WriteLine("您输入的订单号不存在，请重新输入! \n");
                                Console.WriteLine("请输入您想修改的订单号:");
                                while (!int.TryParse(Console.ReadLine(), out orderNo2))
                                {
                                    Console.WriteLine("您输入的订单号格式不正确，请重新输入! \n");
                                    Console.WriteLine("请输入您想修改的订单号:");
                                }
                            }

                            Console.WriteLine("请输入您想修改的信息:1,客户 2，地址");

                            int type;

                            while (!int.TryParse(Console.ReadLine(), out type))
                            {
                                Console.WriteLine("您输入的信息类型不匹配，请重新输入！ \n");
                                Console.WriteLine("请输入您想修改的信息:1,客户 2，地址");
                            }

                            Console.WriteLine("请您填入修改的内容：");
                            string modifyInformation = Console.ReadLine();
                            os.ModifyOrder(orderNo2, type, modifyInformation);
                            Console.WriteLine("修改信息成功!");
                        }
                        catch (OrderException)
                        {
                            Console.WriteLine("订单格式不正确 或 订单号错误，请检查！\n");
                        }
                        
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("请输入您想查询的依据:1，订单号 2，客户名 3，商品名称 4,取消查询");
                            int key ;

                            if (!int.TryParse(Console.ReadLine(),out key))
                            {
                                throw new OrderException("查询操作数违法！");
                            }
                            if (key < 1 || key > 4)
                            {
                                throw new OrderException("查询操作数违法！");
                            }
                            else
                            {
                                QueryOrder(key);
                            }                           
                        }catch (OrderException)
                        {
                            Console.WriteLine("请输入正确的查询操作! \n");
                        }
                        break;                   
                    case 5:                        
                        if (os.orders.Count==0)
                        {
                            Console.WriteLine("暂无订单信息，请添加一笔订单！\n");
                        }
                        else
                        {
                            foreach (Order od in os.orders)
                            {
                                Console.WriteLine(od.ToString());
                            }
                        }
                       
                        break;
                    case 6:                        
                        return;
                }    
            }           
        }

        //查询操作,根据key值来进行查询
        public void QueryOrder(int key)
        {
            switch (key)
            {
                case 1:
                    Console.WriteLine("请输入查询的订单号：");
                    int orderNo3;
                    if(!int.TryParse(Console.ReadLine(), out orderNo3))
                    {
                        throw new OrderException("订单号格式错误");
                    }
                    Order order = os.QueryByOrderNo(orderNo3);
                    if (order == null)
                    {
                        throw new OrderException("订单号不存在");
                    }
                    else
                    {
                        Console.WriteLine(os.QueryByOrderNo(orderNo3).ToString());
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("请输入查询的客户名：");
                    string customerName = Console.ReadLine();
                    //获取订单列表
                    List<Order> orderByCustomer = os.QueryByCustomer(customerName);

                    foreach (Order od in orderByCustomer)
                    {
                        Console.WriteLine(od.ToString());
                    }

                    break;
                case 3:
                    Console.WriteLine("请输入查询的商品名：");
                    string goodsName = Console.ReadLine();
                    //获取订单列表
                    List<Order> orderByGoodsName = os.QueryByGoodsName(goodsName); 

                    foreach (Order od in orderByGoodsName)
                    {
                        Console.WriteLine(od.ToString());
                    } 
                    
                    break;
                case 4:
                    break;
                default:                    
                    break;
            }
        }

        
    }  
}
