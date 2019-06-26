using CCWin;
using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 网易云音乐歌单歌曲下载
{
    public partial class Form1 : CCSkinMain
    {
        string target = Environment.CurrentDirectory + "\\Download\\";
        private void Form1_Load(object sender, System.EventArgs e)
        {
            downloadSite.Text = target;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private IntPtr a;
        XL.DownTaskInfo info = new XL.DownTaskInfo();
        //调用迅雷下载
        private delegate void FlushClient(object html); //代理
        Thread thread = null;
        //跨线程访问控件
        static List<DownList> IDlist = new List<DownList>();
        private void search_Click(object sender, EventArgs e)
        {
            if(thread!=null)
                thread.Suspend();
            skinListBox1.Items.Clear();
            IDlist.Clear();
            WebClient web = new WebClient();
            string webSite = "http://localhost:84/NeteaseAPI/playlist.php?id="+txtID.Text;
            byte[] buffer = web.DownloadData(webSite);
            string html = Encoding.UTF8.GetString(buffer);
            thread = new Thread(new ParameterizedThreadStart(CrossThreadAdd));
            thread.IsBackground = true;
            thread.Start(html);
        }
        private void CrossThreadAdd(object html)
        {
            AddItem(html);
        }
        public void AddItem(object html)
        {
            if (this.skinListBox1.InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(AddItem);
                this.Invoke(fc, new object[1] { html }); //通过代理调用刷新方法
            }
            else
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(html.ToString());
                XmlNodeList list = xml.SelectSingleNode("Document").ChildNodes;
                foreach (XmlNode node in list[0].ChildNodes[3].ChildNodes)
                {
                    XmlElement xe = (XmlElement)node;
                    XmlNodeList firList = xe.ChildNodes;
                    string name = firList[0].InnerText;
                    XmlNodeList singers = firList[4].ChildNodes;
                    string[] artist = new string[singers.Count];
                    for (int i = 0; i < artist.Length; i++)
                    {
                        artist[i] = singers[i].ChildNodes[1].InnerText;
                    }
                    string ar = string.Join("/", artist);
                    string al = firList[13].ChildNodes[1].InnerText;
                    string l = firList[17].ChildNodes[0].InnerText;
                    string m = "", h = "";
                    h = firList[15].HasChildNodes ? firList[15].ChildNodes[0].InnerText : l;
                    m = firList[16].HasChildNodes ? firList[16].ChildNodes[0].InnerText : l;
                    DownList dl = new DownList(firList[1].InnerText, h, m, l);
                    IDlist.Add(dl);
                    SkinListBoxItem lb = new SkinListBoxItem(ar + " - " + name);
                    skinListBox1.Items.Add(lb);
                }
            }
        }
        
        public void DownLown(string id,string br,string name)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Interval = 500;
                var initSuccess = XL.XL_Init();
                if (initSuccess)
                {
                    XL.DownTaskParam p = new XL.DownTaskParam()
                    {
                        IsResume = 0,
                        szTaskUrl = GetUrl(id,br),//下载地址
                        szFilename = name + ".mp3",//保存文件名
                        szSavePath = target //下载目录
                    };
                    a = XL.XL_CreateTask(p);
                    var startSuccess = XL.XL_StartTask(a);
                }
                else
                {
                    MessageBox.Show("迅雷初始化失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string GetUrl(string id,string br)
        {
            WebClient web = new WebClient();
            string webSite = "http://localhost:84/NeteaseAPI/download.php?id=" + id + "&br=" + br;
            byte[] buffer = web.DownloadData(webSite);
            string html = Encoding.UTF8.GetString(buffer);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(html);
            XmlNodeList list = xml.SelectSingleNode("Document").ChildNodes;
            return list[0].ChildNodes[0].ChildNodes[1].InnerText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                downloadSite.Text = ofd.SelectedPath;
                target = downloadSite.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始下载")
            {
                sum = 0;
                if (comboBox1.Text == "普通")
                {
                    br = 0;
                }
                else if (comboBox1.Text == "较高") { br = 1; } else if (comboBox1.Text == "极高") { br = 2; }
                string sbr = "";
                if (br == 0) sbr = IDlist[sum].less; else if (br == 1) sbr = IDlist[sum].middle; else sbr = IDlist[sum].high;
                DownLown(IDlist[sum].id, sbr, skinListBox1.Items[sum].Text);
                button1.Text = "暂停下载";
            }
            else if(button1.Text=="暂停下载")
            {
                XL.XL_StopTask(a);
                button1.Text = "继续下载";
            }else
            {
                XL.XL_StartTask(a);
                button1.Text = "暂停下载";
            }

        }
        int sum = 0;
        int br = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            var qq = XL.XL_QueryTaskInfoEx(a, info);
            skinProgressBar1.Value = sum / skinListBox1.Items.Count * 100;
            var aa = string.Format("正在下载第"+(sum+1)+"首，进度{0}%", (info.fPercent*100).ToString("f2"));
            label3.Text = aa;
            if (info.stat == XL.DOWN_TASK_STATUS.TSC_COMPLETE)
            {
                skinListBox1.Items[sum].Image = Properties.Resources.green2;
                sum++;
                string sbr = "";
                if (br == 0) sbr = IDlist[sum].less; else if (br == 1) sbr = IDlist[sum].middle; else sbr = IDlist[sum].high;
                DownLown(IDlist[sum].id, sbr, skinListBox1.Items[sum].Text);
                if (sum == skinListBox1.Items.Count)
                {
                    skinProgressBar1.Value = 0;
                    button1.Text = "开始下载";
                    skinListBox1.Items.Clear();
                    IDlist.Clear();
                    timer1.Enabled = false;
                }
            }
        }
    }
}
