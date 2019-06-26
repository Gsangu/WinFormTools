using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetResource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string target = Environment.CurrentDirectory + "\\";
        private bool isStartTimer = false;
        private System.Timers.Timer timer;
        private int timerNum = 0;
        private int inTimer = 0;// 判断线程是否执行完毕
        private string[] ips = null;
        private int[] ports = null;
        private int porxyPage = 1;
        private int ip = 0;
        private int port = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            urlTxt.Text = "https://www.mygalgame.com/guanyujieyadexiangguanshuoming.html";
            matchTxt.Text = "https://ws.+?sinaimg.*?(\\.jpg|\\.png)";
            targetTxt.Text = target;
            CheckForIllegalCrossThreadCalls = false;
            GetProxy();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (isStartTimer)
            {
                // 停止循环
                timer.Enabled = false;
                isStartTimer = false;
                AllControlStatus(true);
                startBtn.Text = "Go!";
            }
            else if (isTimer.Checked)
            {
                // 开启循环
                timer = new System.Timers.Timer(1);
                timerNumTxt.Text = "";
                startBtn.Text = "Stop";
                timer.Enabled = true;
                timer.AutoReset = true;
                timer.Elapsed += StartTimer;
                isStartTimer = true;
                timerNum = 0;
            }
            else
            {
                timerNumTxt.Text = "";
                startBtn.Enabled = false;
                Thread searchs = new Thread(new ThreadStart(start));
                searchs.Start();
            }
        }

        private void StartTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Interlocked.Exchange(ref inTimer, 1) == 0)
            {
                // 等待上一个线程执行完毕
                if (timer.Interval == 1)
                {
                    timer.Interval = (int)timerTxt.Value * 1000;
                }
                start();
                Interlocked.Exchange(ref inTimer, 0);
            }
        }

        private void start()
        {
            ChangeStatus("正在请求");
            AllControlStatus(false);
            string html = GetHtml(urlTxt.Text);
            string[] matches = GetImages(html, matchTxt.Text);
            for (int i = 0; i < matches.Length; i++)
            {
                ChangeStatus("正在添加" + (i+1) + "/" + matches.Length);
                DownloadFile(matches[i]);
            }
            if (!isStartTimer)
            {
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
            urlTxt.Enabled = status;
            matchTxt.Enabled = status;
            targetBtn.Enabled = status;
            timerTxt.Enabled = status;
            isTimer.Enabled = status;
        }

        private void ChangeStatus(string txt)
        {
            statusLab.Text = txt;
        }

        public void DownloadFile(string fileUrl)
        {
            int num = fileUrl.LastIndexOf('/');
            num = ((num == -1) ? fileUrl.LastIndexOf('\\') : num);
            string name = fileUrl.Substring(num + 1);
            this.DownloadFile(fileUrl, name);
        }
        
        public void DownloadFile(string fileUrl, string name)
        {
            WebClient webClient = new WebClient();
            WebProxy proxy = new WebProxy(this.ips[this.ip], this.ports[this.port]);
            webClient.Proxy = proxy;
            if (!File.Exists(this.target + name))
            {
                try
                {
                    webClient.DownloadFile(fileUrl, this.target + name);
                }
                catch (Exception ex)
                {
                    this.ChangeStatus("下载错误：" + ex.Message + "，正在尝试重新连接...");
                    this.ip++;
                    this.port++;
                    this.DownloadFile(fileUrl, name);
                }
            }
        }
        public string GetHtml(string url)
        {
            CookieContainer cookie = new CookieContainer();
            cookie.Add(new Uri(url), new Cookie("PHPSESSID", "p3l65qoa1a90ps0sds1m751un0"));
            cookie.Add(new Uri(url), new Cookie("yunsuo_session_verify", "4f3096e53349b07a82837afc47b6dbee"));
            return GetHtml(url, cookie, false);
        }

        public string GetHtml(string url, CookieContainer cookie, bool isProxy)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = GetUserAgent();
            request.Timeout = 60000;
            // 添加cookie
            if (cookie != null)
            {
                request.CookieContainer = cookie;
            }

            if (isProxy)
            {
                WebProxy proxy = new WebProxy(ips[ip], ports[port]);
                request.Proxy = proxy;
            }

            string retString = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception e)
            {
                //startBtn_Click(null, null);
                ChangeStatus("请求错误：" + e.Message + "，正在尝试重新连接...");
                ip++; port++;
                if (ip >= ips.Length || port >= ports.Length)
                {
                    GetProxy(); ip = 0; port = 0;
                }
                return GetHtml(url, cookie, isProxy);
            }

            return retString;
        }


        public void GetProxy()
        {
            string html = GetHtml("http://www.xicidaili.com/nt/" + porxyPage, null, false);
            string match = "(?<ip>(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d))(.|\\n)*?<td>(?<port>\\d{0,9})</td>";
            MatchCollection mc = Regex.Matches(html, match);
            if (ips != null && ports != null)
            {
                ChangeStatus("正在更换代理服务器...");
                if (ips[0] == mc[0].Groups["ip"].Value)
                {
                    porxyPage++; GetProxy();
                }
            }
            porxyPage = 0;
            ips = new string[mc.Count];
            ports = new int[mc.Count];
            for (int i = 0; i < mc.Count; i++)
            {
                ips[i] = mc[i].Groups["ip"].Value;
                ports[i] = int.Parse(mc[i].Groups["port"].Value);
            }
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

        public string GetUserAgent()
        {
            string[] userAgents = {
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1",
                "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Mobile Safari/537.36",
                "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Mobile Safari/537.36",
                "Mozilla/5.0 (Linux; Android 5.1.1; Nexus 6 Build/LYZ28E) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Mobile Safari/537.36",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_2 like Mac OS X) AppleWebKit/603.2.4 (KHTML, like Gecko) Mobile/14F89;GameHelper",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_5) AppleWebKit/603.2.4 (KHTML, like Gecko) Version/10.1.1 Safari/603.2.4",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0 like Mac OS X) AppleWebKit/602.1.38 (KHTML, like Gecko) Version/10.0 Mobile/14A300 Safari/602.1",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.12; rv:46.0) Gecko/20100101 Firefox/46.0",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:46.0) Gecko/20100101 Firefox/46.0",
                "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)",
                "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)",
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0)",
                "Mozilla/5.0 (Windows NT 6.3; Win64, x64; Trident/7.0; rv:11.0) like Gecko",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/13.10586",
                "Mozilla/5.0 (iPad; CPU OS 10_0 like Mac OS X) AppleWebKit/602.1.38 (KHTML, like Gecko) Version/10.0 Mobile/14A300 Safari/602.1"
            };
            Random r = new Random();
            return userAgents[r.Next(0, userAgents.Length)];
        }
        #endregion

    }
}
