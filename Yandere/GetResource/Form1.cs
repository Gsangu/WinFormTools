using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandere;

namespace GetResource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string target = Environment.CurrentDirectory + "\\";
        private System.Timers.Timer timer = null;
        private int timerNum = 0; // 下载次数
        private int inTimer = 0;// 判断线程是否执行完毕
        private string[] ips = null; // 代理ip列表
        private string[] ports = null; // 代理ip 端口列表
        private int porxyPage = 1; // 代理服务器页码
        private int ip = 0; // 当前代理ip 下标
        private int port = 0; // 当前代理端口 下标
        private int tagIndex = 0; // 遍历到第几个tag
        private int page = 1; // 遍历到第几页
        Yande yande;
        WebClient downloadClient;

        private void Form1_Load(object sender, EventArgs e)
        {
            targetTxt.Text = target;
            CheckForIllegalCrossThreadCalls = false;
            tagsTxt.Text = "rating:safe";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (timer != null && timer.Enabled)
            {
                // 停止循环
                Stop();
            }
            else
            {
                downloadClient = new WebClient();
                // 开启循环
                timer = new System.Timers.Timer(1);
                timerNumTxt.Text = "";
                startBtn.Text = "Stop";
                timer.Enabled = true;
                timer.AutoReset = true;
                timer.Elapsed += StartTimer;
                timerNum = 0;
                if(tagsTxt.Lines.Length <= 0)
                {
                    tagsTxt.Text = " ";
                }
                yande = new Yande(tagsTxt.Lines[tagIndex], (int)minWidthTxt.Value, (int)minHeightTxt.Value, (int)maxWidthTxt.Value, (int)maxHeightTxt.Value);
                page = (int)startPageTxt.Value;
                tagIndex = 0;
            }
        }

        private void StartTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Interlocked.Exchange(ref inTimer, 1) == 0)
            {
                // 等待上一个线程执行完毕
                if (timer.Interval == 1)
                {
                    timer.Interval = (int)startPageTxt.Value * 1000;
                }
                Start();
                Interlocked.Exchange(ref inTimer, 0);
            }
        }
        private void Stop()
        {
            timer.Elapsed -= StartTimer;
            timer.Stop();
            timer.Close();
            timer.Dispose();
            timer.EndInit();
            timer = null;
            if(downloadClient != null)
            {
                downloadClient.Dispose();
            }
            AllControlStatus(true);
            startBtn.Text = "Go!";
            ChangeStatus("停止");
        }

        private void Start()
        {
            if (isProxyCb.Checked && ips == null)
            {
                // 需要获取代理访问
                GetProxy();
            }
            AllControlStatus(false);
            string[,] matches = null;
            try
            {
                WebProxy proxy = isProxyCb.Checked ? new WebProxy(this.ips[this.ip], String2Port(ports[this.port])) : null;
                ChangeStatus("正在请求...");
                matches = yande.GetPageImage(page, proxy);
            }
            catch(Exception ex)
            {
                if (!isProxyCb.Checked) Stop();
                ip++; port++;
                ChangeStatus("请求错误：" + ex.Message);
            }
            if (matches != null)
            {
                timerNum++;

                if ((endPageTxt.Value != 0 && page >= (int)endPageTxt.Value) || matches.Length == 0)
                {
                    // 执行到最后一页
                    if ((tagIndex + 1) >= tagsTxt.Lines.Length)
                    {
                        // 执行到最后tag，结束任务
                        Stop();
                    }
                    else
                    {
                        tagIndex++;
                        yande.ChangeTag(tagsTxt.Lines[tagIndex]);
                    }
                }
                for (int i = 0; i < matches.Length / 4; i++)
                {
                    if (timer == null) break;
                    ChangeStatus("正在下载" + tagsTxt.Lines[tagIndex] + (i + 1) + "/" + matches.Length/4);
                    DownloadFile(matches[i, 1]);
                }
                page++;
                startBtn.Enabled = true;
                AllControlStatus(true);
            }
        }
    
        

        private void targetBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                targetTxt.Text = ofd.SelectedPath + "\\";
                target = targetTxt.Text;
            }
        }

        #region 帮助方法

        public void AllControlStatus(bool status)
        {
            startPageTxt.Enabled = status;
            endPageTxt.Enabled = status;
            tagsTxt.ReadOnly = !status;
            minWidthTxt.Enabled = status;
            minHeightTxt.Enabled = status;
            maxWidthTxt.Enabled = status;
            maxHeightTxt.Enabled = status;
            targetBtn.Enabled = status;
            isProxyCb.Enabled = status;
            isCreateCb.Enabled = status;
        }

        private void ChangeStatus(string txt)
        {
            statusLab.Text = txt;
        }

        public void DownloadFile(string fileUrl)
        {
            string name = Uri.UnescapeDataString(fileUrl);
            name = name.Split(' ')[1] + name.Substring(name.LastIndexOf('.'));
            this.DownloadFile(fileUrl, name);
        }

        public void DownloadFile(string fileUrl, string name)
        {
            if (isProxyCb.Checked)
            {
                WebProxy proxy = new WebProxy(this.ips[this.ip], String2Port(ports[this.port]));
                downloadClient.Proxy = proxy;
            }
            string tagName = ReplaceBadFilename(tagsTxt.Lines[tagIndex]);
            string paths = target;
            if (isCreateCb.Checked)
            {
                if (tagName == "") tagName = "index";
                paths = target + tagName + "\\";
            }
            if (!Directory.Exists(paths))
            { Directory.CreateDirectory(paths); }
            if (!File.Exists(paths + name))
            {
                {
                    try
                    {
                        ChangeStatus("正在下载...");
                        downloadClient.DownloadFile(fileUrl, paths + name);
                    }
                    catch (Exception ex)
                    {
                        this.ChangeStatus("下载错误：" + ex.Message + "，正在尝试重新下载...");
                        this.ip++;
                        this.port++;
                        this.DownloadFile(fileUrl, name);
                    }
                }
            }
        }


        public bool GetProxy()
        {
            ChangeStatus("正在获取代理服务器...");
            string html = HttpHelper.GetHtml("https://proxy.mimvp.com/free.php?proxy=in_tp&sort=p_checkdtime&page=" + porxyPage, null);
            string match = "(?<ip>(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d))(.|\\n)*?src=.+?port=(?<port>.+?)/";
            MatchCollection mc = Regex.Matches(html, match);
            if (ips != null && ports != null)
            {
                if (ips[0] == mc[0].Groups["ip"].Value)
                {
                    porxyPage++;
                    return GetProxy();
                }
            }
            porxyPage = 0;
            ips = new string[mc.Count];
            ports = new string[mc.Count];
            for (int i = 0; i < mc.Count; i++)
            {
                ips[i] = mc[i].Groups["ip"].Value;
                ports[i] = mc[i].Groups["port"].Value;
            }
            return true;
        }

        public int String2Port(string str)
        {
            ChangeStatus("正在获取代理服务器端口...");
            string temp = "0";
            try
            {
                temp = HttpHelper.SougouOCR("https://proxy.mimvp.com/common/ygrandimg.php?port=" + str);
            }
            catch (Exception e)
            {
                ChangeStatus("获取代理端口失败：" + e.Message + "，正在重新尝试...");
                return String2Port(str);
            }
            int data = int.Parse(temp);
            return data;
        }

        public string[] GetImages(string content, string match)
        {
            MatchCollection mc = Regex.Matches(content, match);
            string[] array = new string[mc.Count];
            for (int i = 0; i < mc.Count; i++)
            {
                array[i] = mc[i].Value;
            }
            return array;
        }
        public string ReplaceBadFilename(string filename)
        {
            string str = filename;
            str = str.Replace("\\", "_")
                .Replace("/", "_")
                .Replace(":", "_")
                .Replace("*", "_")
                .Replace("?", "_")
                .Replace("\"", "_")
                .Replace("<", "_")
                .Replace(">", "_")
                .Replace("|", "_").Trim();
            return str;
        }
        #endregion

    }
}
