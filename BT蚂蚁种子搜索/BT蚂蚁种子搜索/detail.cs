using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BT蚂蚁种子搜索
{
    public partial class detail : Form
    {
        private string html;
        WebClient web = new WebClient();
        public string Html
        {
            get { return html; }
            set { html = value; }
        }
        public detail()
        {
            InitializeComponent();
        }

        private void detail_Load(object sender, EventArgs e)
        {
            byte[] buffer = web.DownloadData(html);
            string code = Encoding.UTF8.GetString(buffer);
            string[] find = new string[] { "收录时间：", "活跃热度：", "最后活跃：", "文件大小：", "magnet.+?\"", "thunder://.+?==", "<ol>.+?</ol>" };
            string[] str = new string[7];
            string names = Regex.Matches(code, "res-title.+?<")[0].Value.Replace("res-title'>", "").Replace("<", "");
            for (int i = 0; i < find.Length - 1; i++)
            {
                if (i < 4)
                {
                    MatchCollection mc = Regex.Matches(code, find[i] + ".+?</p>");
                    str[i] = mc[0].Value.Replace(find[i], "").Replace("</p>","").Trim();
                }
                else { MatchCollection mc = Regex.Matches(code, find[i]); str[i] = mc[0].Value; }
            }
            MatchCollection file = Regex.Matches(code, "<li>(?<name>.+?)</li>");
            foreach(Match item in file)
            {
                if (item.Success)
                {
                    string name = item.Groups["name"].Value.Replace("<span class=\"cpill blue-pill\">","————").Replace("</span>", "");
                    int flag = name.IndexOf("<a class");
                    if (flag > 0)
                    {
                        string name1 = "";
                        for (int i = 0; i < flag; i++) { name1 += name[i]; }
                        name = name1;
                    }
                    if (flag == 0)
                    {
                        int final = name.IndexOf("</script>");
                        name = name.Remove(0, final);
                        name = name.Replace("</script>", "");
                    }
                    richTextBox1.Text += name;
                    //int a = name.IndexOf("<span class=\"cpill blue - pill\">");
                    //int b = name.IndexOf("</span> ");
                    //for(int i = 0; i < a; i++)
                    //{
                    //    richTextBox1.Text += name[i];
                    //}
                    richTextBox1.Text += "\n";
                }
            }
            name.Text = names;
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4].Replace("\"","");
            textBox6.Text = str[5];
        }
        private Point offset;//记录当前窗口坐标

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void ESCBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
