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

    public partial class itemForm : Form
    {
        public OrderItem OrderItem { get; set; }
        public string name;
        public double price;
        public int num;
        
        public itemForm()
        {
            InitializeComponent();
            
        }

        //下面这个构造函数用于AddOrder窗口给itemOrder窗口传递orderItem对象
        public itemForm(OrderItem orderItem) : this()
        {
            
            this.OrderItem = orderItem;
            txtName.DataBindings.Add("Text", OrderItem, "name");
            txtNum.DataBindings.Add("Text", OrderItem, "num");
            txtPrice.DataBindings.Add("Text", OrderItem, "price");
        }

        

        private void btnok_Click(object sender, EventArgs e)
        {
            //对输入进行处理
            if(txtName.Text == "")
            {
                MessageBox.Show("商品名不能为空!");
                return;
            }
            //可以不用解析了
            if (txtPrice.Text == "")              
            {
                MessageBox.Show("价格信息出错!");
                return;
            }
            if(txtNum.Text == "")                      //!int.TryParse(txtNum.Text,out num)
            {
                MessageBox.Show("数量信息出错!");
                return;
            }

           
            //关闭窗口
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
