using System;

namespace practise1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num;
                Console.WriteLine("请输入一个数：");
                num = Convert.ToInt32(Console.ReadLine());

                //接下来求出这个数的所有素数因子
                //求出所有因子
                Console.WriteLine("这个数的所有素数因子为：");
                for (int i = 2; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                            //设置标签，记录是否为素数
                            int tag = 0;
                            for (int j = 1; j < i; j++)
                            {
                                if (i % j == 0)
                                {
                                    tag++;
                                }
                            }
                            if (tag == 1)
                            {
                                Console.Write(i + " ");
                            }
                        }

                    }
                
            }
            catch (FormatException e)
            {
                Console.WriteLine("请输入正整数：");
            }

        }
    }
}
