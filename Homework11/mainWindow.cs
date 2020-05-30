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
            orderBindingSource.DataSource = os.GetAllOrders();
            queryWay.SelectedIndex = 0;
            txtKeyWord.DataBindings.Add("Text", this, "Keyword");
        }

        //新建订单
        private void button_add_Click(object sender, EventArgs e)
        {
            AddOrder form2 = new AddOrder(new Order());
            if (form2.ShowDialog() == DialogResult.OK)
            {
                os.AddOrder(form2.CurrentOrder);
                SortAll();
            }
        }

        //删除订单
        private void button_delete_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            os.DeleteOrder(order.OrderNo);
            SortAll();
        }

        //修改订单
        private void button_modify_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            order = os.GetOrder(order.OrderNo); //查询出最新的订单信息
            AddOrder form2 = new AddOrder(new Order());
            if (form2.ShowDialog() == DialogResult.OK)
            {
                os.ModifyOrder(form2.CurrentOrder.OrderNo);
                SortAll();
            }

        }

        //排序
        public void SortAll()
        {
            orderBindingSource.DataSource = os.GetAllOrders();
            orderBindingSource.ResetBindings(false);
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyWord.Text;
            switch (queryWay.SelectedIndex) 
            {
                case 0://所有订单
                    orderBindingSource.DataSource = os.GetAllOrders();
                    break;
                case 1://根据ID查询
                    int orderNo;
                    int.TryParse(keyword, out orderNo);
                    Order order = os.GetOrder(orderNo);
                    List<Order> result = new List<Order>();
                    if (order != null) result.Add(order);
                    orderBindingSource.DataSource = result;
                    break;
                case 2://根据客户查询
                    orderBindingSource.DataSource = os.QueryOrdersByCustomerName(keyword);
                    break;
                case 3://根据货物查询
                    orderBindingSource.DataSource = os.QueryOrdersByGoodsName(keyword);
                    break;
                case 4://根据总价格查询
                    float.TryParse(keyword, out float totalPrice);
                    orderBindingSource.DataSource =os.QueryByTotalAmount(totalPrice);
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
