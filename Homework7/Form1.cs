using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        //创建画笔
        private Graphics graphics;
        double th1 = 20 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int n = 10;
        int length = 200;
        int x0 = 240;
        int y0 = 100;
        Color color;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            //为控件选择默认值,方便测试
            this.newn.SelectedIndex = 9;
            this.newLength.SelectedIndex = 2;
            this.newPer1.SelectedIndex = 5;
            this.newPer2.SelectedIndex = 6;
            this.newTh1.Text = "45";
            this.newTh2.Text = "45";
            x0 = (int)((0.7) * this.Width);
            y0 = (int)((0.15) * this.Height);
        }
       

        private void start_Click(object sender, EventArgs e)
        {
            //按下生成按钮时,参数发生改变

            //在按下按钮时获得窗体的高和宽属性
           
            n = Convert.ToInt32(newn.Text);
            length = Convert.ToInt32(newLength.Text);
            per1 = Convert.ToDouble(newPer1.Text);
            per2 = Convert.ToDouble(newPer2.Text);
            //角度转化
            th1 = stringToInt(th1, newTh1);
            th2 = stringToInt(th2, newTh2);
            //测试转化

            if (graphics == null) graphics = this.CreateGraphics();
            else
            {
                graphics.Clear(BackColor);
            }
            drawCayleyTree(n, length, x0, y0, -Math.PI / 2);
        }

        public void drawCayleyTree(int n, double x0, double y0, double length, double th)
        {
            if (color != null)
            {
                pen = new Pen(color);
            }
            else
            {
                pen = new Pen(Color.Black);
            }
            
            if (n == 0) return;
            //画完一次后调用clear函数

            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);

            graphics.DrawLine(pen, (float)x0, (float)y0, (float)x1, (float)y1);

            drawCayleyTree(n - 1, x1, y1, per1 * length, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * length, th - th2);
        }

        //处理文本与整形转化的函数
        public double stringToInt(double x, TextBox textBox)
        {
            if (!double.TryParse(textBox.Text,out x))
            {
                textBox.Clear();
                WrongMessage1.Visible = true;
                return 0;
            }
            else
            {
                x = x * Math.PI / 180;
                WrongMessage1.Visible = false;
                return x;
            }
           
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            //控制画笔颜色的按钮
            colorDialog1.ShowDialog();
            color = this.colorDialog1.Color;
        }
          
    }
}
