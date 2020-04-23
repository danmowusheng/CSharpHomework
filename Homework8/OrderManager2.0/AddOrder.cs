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
        }

        private void btnadditem_Click(object sender, EventArgs e)
        {
            //这个窗口需要新建一个orderItem，实现窗口间的传值 
            itemForm itemForm = new itemForm(new OrderItem());
            if(itemForm.ShowDialog() == DialogResult.OK)
            {
                CurrentOrder.AddOrderItem(itemForm.OrderItem);
                itemBindingSource.ResetBindings(false);
            }
        }

        private void btndeleteitem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = itemBindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            try
            {
                CurrentOrder.DeleteOrderItem(orderItem);
                itemBindingSource.ResetBindings(false);
            }
            catch (OrderException e2)
            {
                MessageBox.Show(e2.Message);
            }

        }

        
        private void btnmodifyitem_Click(object sender, EventArgs e)
        {
            //首先读取当前订单项
            OrderItem orderItem = itemBindingSource.Current as OrderItem;

            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            itemForm modifyForm = new itemForm(orderItem);
            if (modifyForm.ShowDialog() == DialogResult.OK)
            {
                //修改该订单项信息
                itemBindingSource.ResetBindings(true);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            CurrentOrder.CustomerName = CustomerName;
            CurrentOrder.Address = Address;
            this.DialogResult = DialogResult.OK;
        }

    }
}
