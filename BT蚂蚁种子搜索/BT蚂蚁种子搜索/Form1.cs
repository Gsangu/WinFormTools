using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT蚂蚁种子搜索
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count = 0;//记录总页数
        static int pages = 1;//记录页数
        string html;//记录网页地址
        string code;//记录网页源码
        string str;//记录输入的内容
        string sort = "-first-asc-";//记录排序
        WebClient web = new WebClient();
        private void button1_Click(object sender, EventArgs e)
        {
            Results.Items.Clear();
            pages = 1;
            if (textBox1.Text == "") { count = 0; page.Text = "未进行搜索"; return; }
            str = textBox1.Text;
            if (radioButton1.Checked) { sort = "-first-asc-"; }
            else if (radioButton2.Checked) { sort = "-hot-desc-"; }
            else if (radioButton4.Checked) { sort = "-last-asc-"; }
            else { sort = "-size-desc-"; }
            try
            {
                html = @"http://www.btany.com/search/" + str + sort + pages;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
            }
            catch (Exception)
            {
                Results.Items.Add("网络似乎丢失了...");
                return;
            }
            page.Text = "正在搜索...";
            AddResult(code);
            count = 0;
            pageCount(code); 
            label2.Text = "" + pages;
        }
        private void pageCount(string code)
        {
            try
            {
                MatchCollection mc = Regex.Matches(code, "<a href=.+?末页");
                string temp;
                if (mc.Count == 0) { mc = Regex.Matches(code, str + ".+?>(?<count>.+?)</a>"); temp = mc[mc.Count - 1].Groups["count"].Value;count = int.Parse(temp); }
                else
                {
                    temp = mc[0].Value;
                    int b = 1;
                    int a = 0;
                    for (int i = temp.Length - 2; i >= temp.Length - 10; i--)
                    {
                        if (int.TryParse(temp[i].ToString(), out a))
                        {
                            a = int.Parse(temp[i].ToString());
                            count += a * b;
                            b *= 10;
                        }
                    }
                }
                page.Text = "此次搜索共搜到 " + count + " 页";
            }
            catch { page.Text = "此次搜索共搜到共 " + 1 + " 页"; }
        }
        private void AddResult(string code)
        {
            MatchCollection mc = Regex.Matches(code, "<p>(?<name>.+?)<span>(?<size>.+?)</p.+?");
            if (mc.Count <= 0) { Results.Items.Add("未找到结果..."); return; }
            foreach (Match item in mc)
            {
                if (item.Success)
                {
                    try
                    {
                        string[] span = { "<span class=\"highlight\">", "</span>" };
                        string name = item.Groups["name"].Value;
                        for (int i = 0; i < span.Length; i++)
                        {
                            name = name.Replace(span[i], "");
                        }
                        AddItems(name, item.Groups["size"].Value.Replace("</span>", ""));
                        page.Text = "正在搜索...";
                    }
                    catch
                    {

                    }
                }
            }
            page.Text = "此次搜索共搜到 " + count + " 页";
        }

        private void AddItems(string name , string size)
        {
            int flag = name.IndexOf("<a class");
            if (flag > 0)
            {
                string name1 = "";
                for(int i = 0; i < flag; i++) { name1 += name[i]; }
                name = name1;
            }
            if (flag == 0)
            {
                int final=name.IndexOf("</script>");
                name = name.Remove(0, final);
                name = name.Replace("</script>", "");
            }
            ListViewItem res = new ListViewItem(name);
            res.SubItems.Add(size);
            Results.Items.Add(res);
        }//把结果输出到ListView中

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }//按回车调用按钮
        }

        private void Results_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;// 取消掉正在调整的事件 
            e.NewWidth = this.Results.Columns[e.ColumnIndex].Width;// 把新宽度恢复到之前的宽度 
        }//锁定列宽度

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Results.Columns.Add("名字", 450, HorizontalAlignment.Left);
            this.Results.Columns.Add("大小", 100, HorizontalAlignment.Right);
        }

        private void 复制磁力链接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (code == null) return;
            MatchCollection mc = Regex.Matches(code, "magnet.+?\"");
            if (mc.Count > 0)
            {
                Clipboard.SetDataObject(mc[Results.SelectedIndices[0]].Value.Replace("\"", ""));
            }
        }

        private void 复制迅雷链接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (code == null) return;
            MatchCollection mc = Regex.Matches(code, "thunder://.+?==");
            if (mc.Count > 0)
            {
                Clipboard.SetDataObject(mc[Results.SelectedIndices[0]].Value);
            }
        }
        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (code == null) return;
            MatchCollection mc = Regex.Matches(code, "detail/.+?\"");
            if (mc.Count > 0)
            {
               // MessageBox.Show(mc[Results.SelectedIndices[0]].Value);
                detail de = new detail();
                de.Html = @"http://www.btany.com/" + mc[Results.SelectedIndices[0]].Value.Replace("\"","");
                de.ShowDialog();
            }
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            try { 
                pages++;
                html = @"http://www.btany.com/search/" + str + sort + pages;
                textBox1.Text = str;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
                Results.Items.Clear();
                AddResult(code);
                label2.Text = "" + pages;
            }
            catch { }
        }

        private void lastPage_Click(object sender, EventArgs e)
        {
            try
            {
                pages--;
                html = @"http://www.btany.com/search/" + str + sort + pages;
                textBox1.Text = str;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
                Results.Items.Clear();
                AddResult(code);
                label2.Text = "" + pages;
            }
            catch { }
        }

        private void ESCBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 拖动窗口移动
        private Point offset;//记录当前窗口坐标
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        #endregion

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            searchbtn.Image = Properties.Resources.search_move;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            searchbtn.Image = Properties.Resources.search;
        }

        private void Results_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (Results.Columns[e.Column].Text == "大小" && str != null)
            {
                //MessageBox.Show("enen");
                if (sort == "-size-asc-")
                {
                    sort = "-size-desc-";
                    pages = 1;
                    html = @"http://www.btany.com/search/" + str + sort + pages;
                    textBox1.Text = str;
                    byte[] buffer = web.DownloadData(html);
                    code = Encoding.UTF8.GetString(buffer);
                    Results.Items.Clear();
                    AddResult(code);
                    label2.Text = "" + pages;
                }
                else
                {
                    sort = "-size-asc-";
                    pages = 1;
                    html = @"http://www.btany.com/search/" + str + sort + pages;
                    textBox1.Text = str;
                    byte[] buffer = web.DownloadData(html);
                    code = Encoding.UTF8.GetString(buffer);
                    Results.Items.Clear();
                    AddResult(code);
                    label2.Text = "" + pages;
                }
            }
        }
        #region 选择排序方式
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (str != null && Results.Items.Count > 1)
            {
                sort = "-first-asc-";
                pages = 1;
                html = @"http://www.btany.com/search/" + str + sort + pages;
                textBox1.Text = str;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
                Results.Items.Clear();
                AddResult(code);
                label2.Text = "" + pages;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (str != null && Results.Items.Count > 1)
            {
                sort = "-hot-desc-";
                pages = 1;
                html = @"http://www.btany.com/search/" + str + sort + pages;
                textBox1.Text = str;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
                Results.Items.Clear();
                AddResult(code);
                label2.Text = "" + pages;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (str != null && Results.Items.Count > 1)
            {
                sort = "-last-asc-";
                pages = 1;
                html = @"http://www.btany.com/search/" + str + sort + pages;
                textBox1.Text = str;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
                Results.Items.Clear();
                AddResult(code);
                label2.Text = "" + pages;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (str != null && Results.Items.Count > 1)
            {
                sort = "-size-desc-";
                pages = 1;
                html = @"http://www.btany.com/search/" + str + sort + pages;
                textBox1.Text = str;
                byte[] buffer = web.DownloadData(html);
                code = Encoding.UTF8.GetString(buffer);
                Results.Items.Clear();
                AddResult(code);
                label2.Text = "" + pages;
            }
        }
        #endregion

        private void Results_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (e.Item != null)
            {
                ListViewItem item = this.Results.GetItemAt(e.Item.Position.X, e.Item.Position.Y);
                if (item != null)
                {
                    toolTip1.Show(item.Text, Results, new Point(e.Item.Position.X + 15, e.Item.Position.Y + 15), 1000);
                    toolTip1.Active = true;
                }
                else
                {
                    toolTip1.Active = false;
                }
            }
        }
        
    
    }
}
