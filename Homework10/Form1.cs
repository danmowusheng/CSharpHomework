using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace CrawlerPlus
{
    public partial class Form1 : Form
    {
        DateTime startTime;
        BindingSource resultBindingSource = new BindingSource();
        Crawler crawler = new Crawler();
        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            dgvResult.DataSource = resultBindingSource;

            //委托事件
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.CrawlerStopped += Crawler_CrawlerStopped;
        }

        private void Crawler_CrawlerStopped(Crawler obj)
        {
            DateTime endTime = DateTime.Now;
            Action action = () => labstatus.Text = "爬虫已停止,用时：" + (endTime - startTime);
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void Crawler_PageDownloaded(Crawler crawler, int index, string url, string info)
        {
            var pageInfo = new { Index = index, URL = url, Status = info };
            Action action = () => { resultBindingSource.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            resultBindingSource.Clear();
            crawler.StartURL = txtURL.Text;

            Match match = Regex.Match(crawler.StartURL, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = ".html?$";

            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(crawler.Start);
            thread.Start();
            labstatus.Text = "爬虫已启动....";
        }
    }
}
