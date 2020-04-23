using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace SimpleCrawler
{
    public partial class Form1 : Form
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
            httpInf.Multiline = true;
           
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string strHtml = @"(http|HTTP)[s]?://";  // 模式为  http//../
            string strWWW = @"(w|W){3}.{2,}";       //相对地址模式   www.  .

            string startUrl = txtHtml.Text;
            //若输入地址不合适，则提示
            if(!Regex.IsMatch(startUrl, strWWW))
            {
                MessageBox.Show("填入的地址无效！");
                return;
            }
            else
            {
                urls.Add(startUrl, false);    //加入初始地址
                httpInf.Text += "开始爬取网页地址....";
                while (true)
                {
                    string current = null;
                    foreach (string url in urls.Keys)
                    {
                        //如果url对应的值为true，那么跳出直接执行下一次循环
                        //如果值为true，那么该url已被爬取过
                        if ((bool)urls[url]) continue;
                        current = url;
                    }

                    if (current == null || count > 10)
                    {
                        //退出时将哈希表清空
                        urls.Clear();
                        break;
                    }
                        


                    //只有当爬取的为html文本时，才爬取下一级URL
                    //html文本的定义也可能是相对地址,必定能读取到相对地址
                    //所以先检查相对地址
                    if (Regex.IsMatch(current, strWWW))
                    {
                        //若不为绝对地址，则进行转换
                        if (!Regex.IsMatch(current, strHtml))
                        {
                            httpChange(current);
                        }
                        httpInf.Text += "\n 爬行" + current + "页面!";
                        string html = DownLoad(current); // 下载
                        urls[current] = true;
                        count++;
                        Parse(html);//解析,并加入新的链接
                        httpInf.Text += "\n 爬行结束";                       
                    }
                    else
                    {
                        httpInf.Text += "\n 下一级不为html文本，停止爬取";
                        urls.Clear();
                        break;
                    }

                }
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html)
        {

            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }

        //相对地址转换成绝对地址
        private string httpChange(string current)
        {
            string strHTML = "https://";
            current = strHTML + current;
            return current;
        }
    }
}
