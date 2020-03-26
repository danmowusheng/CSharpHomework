using System;

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
            Console.WriteLine("请输入你的操作：1,添加订单 2,删除订单 3,修改订单 4,查询订单 5,查看所有订单 6,退出");
            int opInt=0;

            while (opInt != 5)
            {
                opInt = Convert.ToInt32(Console.ReadLine());
                if (opInt<1&&opInt>6)
                {
                    Console.WriteLine("请输入你的操作：1,添加订单 2,删除订单 3,修改订单 4,查询订单 5,查看所有订单 6,退出");
                    continue;
                }

                switch (opInt) 
                {
                    case 1:
                        int orderNo;
                        if (AddOrderByUser(out orderNo))
                        {
                            Console.WriteLine($"添加订单 #{orderNo} 成功");
                        }
                        else
                        {
                            Console.WriteLine("添加订单失败");
                        }

                        break;
                    case 2:
                        if (RemoveOrderByUser())
                        {
                            Console.WriteLine("删除订单成功");
                        }
                        else
                        {
                            Console.WriteLine("删除订单失败");
                        }

                        break;
                    case 3:
                        if (ModifyOrderByUser())
                        {
                            Console.WriteLine("修改订单成功");
                        }
                        else
                        {
                            Console.WriteLine("修改订单失败");
                        }

                        break;
                    case 4:
                        if (QueryOrderByUser())
                        {
                            Console.WriteLine("查询成功");
                        }
                        else
                        {
                            Console.WriteLine("查询失败");
                        }

                        break;
                    case 5:
                        os.orders.ForEach(x => Console.WriteLine(x));
                        break;
                    case 6:
                        return;
                }
                Console.WriteLine();
                Console.WriteLine("请输入你的操作：1,添加订单 2,删除订单 3,修改订单 4,查询订单 5,查看所有订单 6,退出");
            }
            

            
        }

        private bool QueryOrderByUser()
        {
            return false;
        }

        private bool ModifyOrderByUser()
        {
            return false;
        }

        private bool RemoveOrderByUser()
        {
            return false;
        }

        private bool AddOrderByUser(out int orderNo)
        {
            orderNo = 0;
            Order order = new Order();
            //保存输入的内容
            string enteredContent;
            Console.WriteLine("请按要求输入信息(按下'q' 退出):");

            Console.Write("客户名: ");
            while ((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("请重新输入一遍");
            }
            if (enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }
            order.CustomerName = enteredContent;

            Console.Write("地址: ");
            while ((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("请重新输入一遍");
            }
            if (enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }
            order.Address = enteredContent;

            //记录添加的订单明细数目
            int changeNum;
            AddOrderItemByUser(order, out changeNum);
            Console.WriteLine($"{changeNum} {(changeNum > 1 ? "订单中有" : "订单中有")} 被添加");

            os.AddOrder(order);
            orderNo = order.OrderNo;
            return true;
        }

        private void AddOrderItemByUser(Order order, out int changeNum)
        {
            changeNum = 0;
            string[] itemContent;
            string enteredContent;
            double tmpPrice;
            int tmpAmount;
            Console.WriteLine("添加订单 [  用户名 |  商品价格 | 购买数量  ]: ");
            //循环添加订单明细
            while ((enteredContent = Console.ReadLine().Trim()) != "q" && enteredContent != "Q")
            {
                if (enteredContent == "")
                {
                    Console.WriteLine("请重新输入一遍");
                    continue;
                }

                itemContent = enteredContent.Split('|');
                //确保订单明细由三项组成
                if (itemContent.Length != 3)
                {
                    Console.WriteLine("非法输入，请重新再输入一遍");
                    continue;
                }

                Array.ForEach(itemContent, x => x.Trim());

                if (itemContent[0] == "")
                {
                    Console.WriteLine("非法数据，请重新输入");
                    continue;
                }

                //单价要大于等于零
                if (itemContent[1] == "" || !Double.TryParse(itemContent[1], out tmpPrice) || tmpPrice < 0)
                {
                    Console.WriteLine("非法数据，请重新输入");
                    continue;
                }

                //数量要大于零
                if (itemContent[2] == "" || !Int32.TryParse(itemContent[2], out tmpAmount) || tmpAmount <= 0)
                {
                    Console.WriteLine("非法数据，请重新输入");
                    continue;
                }

                OrderItem orderItem = new OrderItem(itemContent[0], tmpPrice, tmpAmount);              

                try
                {
                    order.AddOrderItem(orderItem);
                    changeNum++;
                }
                catch (OrderException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

   
}
