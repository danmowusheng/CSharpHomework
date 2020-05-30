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
    public partial class AddOrder : Form
    {
        public Order CurrentOrder { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public AddOrder()
        {
            InitializeComponent();
            CustomerName = txtCustomer.Text;
            Address = txtAddress.Text;  
        }

        public AddOrder(Order order) : this()
        {
            //数据绑定,窗口传值
            CurrentOrder = order;
            itemBindingSource.DataSource = CurrentOrder.OrderItems;
            List<Customer> customers = new List<Customer>();
            Customer customer1 = new Customer("LJ");
            Customer customer2 = new Customer("LJM");
            customers.Add(customer1);
            customers.Add(customer2);
            customerBindingSource.DataSource = customers;
        }

        //添加订单项
        private void btnadditem_Click(object sender, EventArgs e)
        {
            //这个窗口需要新建一个orderItem，实现窗口间的传值 
            itemForm itemF = new itemForm(new OrderItem());
            try
            {
                if (itemF.ShowDialog() == DialogResult.OK)
                {                   
                    CurrentOrder.AddOrderItem(itemF.OrderItem);
                    itemBindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }
        
        //删除订单项
        private void btndeleteitem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = itemBindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.DeleteOrderItem(orderItem);
            itemBindingSource.ResetBindings(false);
        }    

        //修改订单项
        private void btnmodifyitem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = itemBindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            itemForm itemF = new itemForm(new OrderItem());
            if (itemF.ShowDialog() == DialogResult.OK)
            {
                itemBindingSource.ResetBindings(false);
            }
        }

        //保存信息
        private void btnsave_Click(object sender, EventArgs e)
        {
            CurrentOrder.CustomerID = CurrentOrder.Customer.CustomerID;
            CurrentOrder.Customer = null;
            CurrentOrder.OrderItems.ForEach(item => {
                item.GoodsItemId = item.GoodsItem.ID;
                item.GoodsItem = null;
                item.OrderNo = CurrentOrder.OrderNo;
            });

            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
