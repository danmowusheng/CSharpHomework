using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jisuanji
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            symbol.Text = add.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            symbol.Text = sub.Text;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            symbol.Text = multi.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            symbol.Text = div.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double a = Convert.ToDouble(num1.Text);
            //double b = Convert.ToDouble(num2.Text);
            double a, b;
            //需要对num1和num2进行异常检查，检查是否为数字，是否为null等情况
            //在做除法时，若num2为0，也无法正常进行
            try
            {
                a = Convert.ToDouble(num1.Text);
                b = Convert.ToDouble(num2.Text);
                //剔除除法时除数为0的异常情况
                if (b == 0 && symbol.Text == "/")
                {
                    result.Text = "除数不能为0";
                    return;
                }

                switch (symbol.Text)
                {
                    case "+":
                        result.Text = $"{a + b }";
                        break;
                    case "-":
                        result.Text = $"{a - b }";
                        break;
                    case "*":
                        result.Text = $"{a * b }";
                        break;
                    case "/":
                        result.Text = $"{a / b }";
                        break;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("请输入数字");
            }
            

            
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
