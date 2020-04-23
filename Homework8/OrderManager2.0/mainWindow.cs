using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager2._0
{
    public partial class mainWindow : Form
    {
        public OrderService os = new OrderService();
        public Order currentOrder;
        public mainWindow()
        {
            
            InitializeComponent();
            //Order order1 = new Order("LJ","hunan");
            //OrderItem orderItem1 = new OrderItem("apple", 5, 2);
            //order1.AddOrderItem(orderItem1);
            //os.AddOrder(order1);


            //currentOrder = orderBindingSource.Current as Order;
            //this.itemsBindingSource.DataSource = currentOrder.OrderItems;
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            //初始化，绑定数据源
            orderBindingSource.DataSource = os.Orders;
        }

        //新建订单
        private void button_add_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder(new Order());
            if (addOrder.ShowDialog() == DialogResult.OK)
            {
                os.AddOrder(addOrder.CurrentOrder);
                             
                orderBindingSource.ResetBindings(false);
            }
            SortAll();
        }

        //删除订单
        private void button_delete_Click(object sender, EventArgs e)
        {
            os.DeleteOrder(orderBindingSource.Current as Order);
            orderBindingSource.ResetBindings(false);
            SortAll();
        }

        //修改订单
        private void button_modify_Click(object sender, EventArgs e)
        {
            //传入当前订单
            currentOrder = orderBindingSource.Current as Order;

            AddOrder addOrder = new AddOrder(currentOrder);
            if (addOrder.ShowDialog() == DialogResult.OK)
            {               
                orderBindingSource.ResetBindings(false);
            }
            SortAll();
        }

        //排序
        public void SortAll()
        {
            orderBindingSource.DataSource = os.Orders;
            orderBindingSource.ResetBindings(false);
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyWord.Text;
            switch (queryWay.SelectedIndex) 
            {
                //按订单号查询
                case 0:
                    int orderID;
                    if(int.TryParse(keyword,out orderID))
                    {
                        if (os.QueryByOrderNo(orderID) != null)
                        {
                            currentOrder = os.QueryByOrderNo(orderID);
                            orderBindingSource.DataSource = currentOrder;
                        }
                        else
                        {
                            MessageBox.Show("该订单号不存在!");
                        }
                    }                   
                    else
                    {
                        MessageBox.Show("输入订单号格式有误!");
                        return;
                    }
                    break;
                //按客户名查询
                case 1:
                    if (os.QueryByCustomer(keyword).Count!=0)
                    {
                        os.Orders = os.QueryByCustomer(keyword);
                        orderBindingSource.DataSource = os.Orders;
                    }
                    else
                    {
                        MessageBox.Show("未查找到该用户!");
                        return;
                    }

                    break;
                //按商品名查询
                case 2:
                    if (os.QueryByGoodsName(keyword).Count != 0)
                    {
                        os.Orders = os.QueryByCustomer(keyword);
                        orderBindingSource.DataSource = os.Orders;
                    }
                    else
                    {
                        MessageBox.Show("未查找到该商品!");
                        return;
                    }
                    break;
            }

        }

        private void button_import_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                os.Import(fileName);
                SortAll();
            }
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                os.Export(fileName);
            }
        }
    }
}
