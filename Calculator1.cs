using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // 声明变量，初始化为0
            float num1 = 0; float num2 = 0;

            // 展示标题
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            //让用户输入第一个数
            Console.WriteLine("输入一个数字, 然后回车");
            num1 = Convert.ToInt32(Console.ReadLine());

            // Ask the user to type the second number.
            Console.WriteLine("输入另一个数字, 然后回车");
            num2 = Convert.ToInt32(Console.ReadLine());

            // Ask the user to choose an option.
            Console.WriteLine("选择如下运算:");
            Console.WriteLine("\ta - 加法");
            Console.WriteLine("\ts - 减法");
            Console.WriteLine("\tm - 乘法");
            Console.WriteLine("\td - 除法");
           

            
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"结果为: {num1} + {num2} = " + (num1 + num2));
                    break;
                case "s":
                    Console.WriteLine($"结果为: {num1} - {num2} = " + (num1 - num2));
                    break;
                case "m":
                    Console.WriteLine($"结果为: {num1} * {num2} = " + (num1 * num2));
                    break;
                case "d":
                    Console.WriteLine($"结果为: {num1} / {num2} = " + (num1 / num2));
                    break;
            }
            // 等待用户响应
            Console.Write("按下任意键退出...");
            Console.ReadKey();
        }
    }
}
