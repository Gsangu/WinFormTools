using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Player
{

    public partial class Form1 : Form
    {
        //存放歌曲的集合
        List<string> lsong = new List<string>();
        int voice;//音量
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            axPlayer.settings.autoStart = false;
            btn.Enabled = true;
            this.axPlayer.settings.volume = 100;
            panel2.Size = new Size(10, 0);
            voice = 100;
            sound1.Text = axPlayer.settings.volume.ToString();
            contextMenuStrip2.Enabled = false;
        }
        /// <summary>
        ///播放与暂停切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            //axPlayer.Ctlcontrols.play();
            if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying )
            {
                axPlayer.Ctlcontrols.pause();
                btn.Image = Properties.Resources.play_down;
                timer3.Enabled = true;
            }
            else if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || axPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                axPlayer.Ctlcontrols.play();
                btn.Image = Properties.Resources.pause_down;
                timer3.Enabled = false;
            }
        }
        #region 静音按钮
        /// <summary>
        /// 静音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnP_Click(object sender, EventArgs e)
        {
            if (axPlayer.settings.mute == false)
            {
                axPlayer.settings.mute = true;
                btnP.Image = Properties.Resources.sound_down;
                panel2.Size = new Size(10, 130);
            }
            else
            {
                axPlayer.settings.mute = false;
                btnP.Image = Properties.Resources.mute_down;
                panel2.Size = new Size(10, panel1.Height- voice);
            }
        }
        #endregion
        private void btnT_Click(object sender, EventArgs e)
        {
            axPlayer.Ctlcontrols.stop();
            btn.Image = Properties.Resources.play_on;
        }
        public void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"F:\KuGou .MP3";
            ofd.Filter = "音乐文件|*.mp3;*.wma";
            ofd.Title = "请选择文件";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    lsong.Add(ofd.FileNames[i]);
                    string[] temp = ofd.FileNames[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    listSong.Items.Add(temp[temp.Length - 1].Split('.')[0]);
                    for (int j = 0; j < lsong.Count - 1; j++)
                    {
                        if (ofd.FileNames[i] == lsong[j])
                        {
                            lsong.RemoveAt(j);
                            listSong.Items.RemoveAt(j);
                        }
                    }
                }
                MyPlay(lsong.Count - 1);
                pmusicdown.Enabled = true;
                contextMenuStrip2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        #region 播放
        private void MyPlay(int i)
        {
            try
            {
                axPlayer.URL = lsong[i];
                listSong.SelectedIndex = i;
                axPlayer.Ctlcontrols.play();
                getmusicTime();
                btn.Image = Properties.Resources.pause_on;
                //加载歌词
                LoadLrc();
                timer3.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("播放失败！");
            }
        }

        private void MyPlay()
        {
            MyPlay(0);
        }
        #endregion

       
        private void btnnext_Click(object sender, EventArgs e)
        {
            //得到当前的索引
            if (listSong.Items.Count > 0)
            {
                int index = listSong.SelectedIndex;
                index++;
                if (index > lsong.Count - 1)
                {
                    MyPlay(0);
                }
                else
                {
                    MyPlay(index);
                }
            }
        }   //下一首

      
        private void btnback_Click(object sender, EventArgs e)
        {
            if (listSong.Items.Count > 0)
            {
                int index = listSong.SelectedIndex;
                index--;
                if (index < 0)
                {
                    MyPlay(lsong.Count - 1);
                }
                else
                {
                    MyPlay(index);
                }
            }
        }   //上一首
        /// <summary>
        /// 双击播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyPlay(listSong.SelectedIndex);
        }
        #region 右键
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSong.SelectedIndex != -1)
            {
                lsong.RemoveAt(listSong.SelectedIndex);
                listSong.Items.RemoveAt(listSong.SelectedIndex);
                if (lsong.Count <= 0)
                {
                    contextMenuStrip2.Enabled = false;
                }
                btnT_Click(null, null);
                lblLrc.Text = "";
            }
        }
        /// <summary>
        /// 清空列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSong.SelectedIndex != -1)
            {
                lsong.Clear();
                listSong.Items.Clear();
                btnT_Click(null, null);
                lblLrc.Text = "";
                
            }
        }
        #endregion
        #region 歌曲播放状态
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axPlayer.currentMedia != null)
            {
                getmusicTime();
                string temp = "等待中";
                if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    temp = axPlayer.currentMedia.name.ToString();

                }
                if (lsong.Count > 0 && axPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying)
                {
                    temp = axPlayer.currentMedia.name.ToString();
                }
                //        temp = temp.Substring(0) + temp[0];
                //        temp = temp.Substring(0, 15);
                labelname.Text = temp;
                //        if (axPlayer.settings.mute == true)
                //        {
                //            labelvol.Text = "静音";
                //        }
                //        else
                //        {
                //            labelvol.Text = "音量：" + axPlayer.settings.volume.ToString();
                //        }声音状态
                label2.Text = axPlayer.currentMedia.durationString;
                labeltime.Text = axPlayer.Ctlcontrols.currentPositionString;
                if (axPlayer.playState == WMPLib.WMPPlayState.wmppsStopped) { labeltime.Text = "00:00"; }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (axPlayer.currentMedia.duration - axPlayer.Ctlcontrols.currentPosition <= 0.5)
                {
                    btnnext_Click(null, null);
                }
            }
        }//自动下一首
        #endregion
        #region 任意位置拖动移动窗体
        private Point offset;//当前窗口坐标
        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            sd.Visible = false;
            if (axPlayer.settings.mute == false) { btnP.Image = Properties.Resources.sound_on_; }
            else { btnP.Image = Properties.Resources.mute_on; }
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        #endregion
        #region 按钮变化

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                btn.Image = Properties.Resources.pause_on;
            }
            else
            {
                btn.Image = Properties.Resources.play_on;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                btn.Image = Properties.Resources.pause;
            }
            else
            {
                btn.Image = Properties.Resources.play;
            }
        }

        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.Image = Properties.Resources.preview_on;
        }

        private void btnback_MouseLeave(object sender, EventArgs e)
        {
            btnback.Image = Properties.Resources.preview;
        }
        
        private void btnadd_MouseMove(object sender, MouseEventArgs e)
        {
            btnadd.Image = Properties.Resources.list_on;
        }

        private void btnadd_MouseLeave(object sender, EventArgs e)
        {
            btnadd.Image = Properties.Resources.list;
        }

        private void btnnext_MouseMove(object sender, MouseEventArgs e)
        {
            btnnext.Image = Properties.Resources.next_on;
        }

        private void btnnext_MouseLeave(object sender, EventArgs e)
        {
            btnnext.Image = Properties.Resources.next;
        }
        #endregion

        private void title_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.ShowDialog();
        }//关于窗口

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }//最小化窗口
        #region 调整声音大小
        public void setVoice(int voice)
        {
            this.axPlayer.settings.volume = voice;
        }//调节声音大小
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }//鼠标状态变成手指

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }//鼠标状态变成默认

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            voice = panel1.Height- e.Location.Y;
            setVoice(voice);
            panel2.Size = new Size(10, e.Location.Y);
            sound1.Text = axPlayer.settings.volume.ToString();
            if (axPlayer.settings.mute == false) { btnP.Image = Properties.Resources.sound_down; }
            else { btnP.Image = Properties.Resources.mute_down; }
        }//按下进度条变化

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }//鼠标状态变成手指

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }//鼠标状态变成默认

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
                voice = panel1.Height - e.Location.Y;
                setVoice(voice);
                panel2.Size = new Size( 10,e.Location.Y);
                sound1.Text = axPlayer.settings.volume.ToString();
            if (axPlayer.settings.mute == false) { btnP.Image = Properties.Resources.sound_down; }
            else { btnP.Image = Properties.Resources.mute_down; }
        }//拖动改变大小
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region 进度条
        int panleX;
        //获取当前进度
        double Alltime;
        double thisTime;
        double alltime;//全部时间
        double thistime;//当前时间
        double bfb;//百分比
        double thisX;
        //改变进度条长度
        Double b;
        private void pmusicdown_MouseDown(object sender, MouseEventArgs e)
        {
            panel4.Size = new Size(e.Location.X, 3);
            panleX = e.Location.X;
            changeTime(330, panleX);
        }

        private void pmusicdown_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pmusicdown_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            panel4.Size = new Size(e.Location.X, 3);
            panleX = e.Location.X;
            changeTime(330, panleX);
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        public void changeTime(double all, double thisp)
        {
            try
            {
                b = thisp / all;
                Alltime = this.axPlayer.currentMedia.duration;
                thisTime = Alltime * b;
                this.axPlayer.Ctlcontrols.currentPosition = thisTime;
            }
            catch (Exception)
            {

            }
        }
        public void getmusicTime()
        {
            thistime = this.axPlayer.Ctlcontrols.currentPosition;
            alltime = this.axPlayer.currentMedia.duration;
            bfb = thistime / alltime;
            thisX = 330 * bfb;
            panel4.Size = new Size((int)thisX, 3);
        }
        private void pmusicdown_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            panel4.Size = new Size(e.Location.X, 3);
            panleX = e.Location.X;
            changeTime(330, panleX);
        }
        #endregion
        #region 歌词显示
        void LoadLrc()
        {
            string songPath = lsong[listSong.SelectedIndex].Split('.')[0];
            songPath += ".lrc";
            if (File.Exists(songPath))
            {
                //如果存在 通过路径读取歌词文件
                string[] lrcText = File.ReadAllLines(songPath, Encoding.Default);
                lblLrc.Text = "已加载歌词";
                FormatLrc(lrcText);
            }
            else
            {
                lblLrc.Text = "----歌词未找到----";
            }
        }
        List<double> listTime = new List<double>();
        //存储歌词
        List<string> listLrc = new List<string>();
        //截取字符串
        void FormatLrc(string[] lrcText)
        {
            for (int i = 0; i < lrcText.Length; i++)
            {
                //lrcTemp[0]  00:00.00 时间
                //lrcTemp[1]  歌词
                string[] lrcTemp = lrcText[i].Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

                //将歌词存储到集合中
                listLrc.Add(lrcTemp[1]);
                string[] lrcNewTemp = lrcTemp[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                //00.00
                double time = double.Parse(lrcNewTemp[0]) * 60 + double.Parse(lrcNewTemp[1]);
                //将最终截取到的时间 扔到listTime中
                listTime.Add(time);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            double currentTime = axPlayer.Ctlcontrols.currentPosition;
            for (int i = 0; i < listTime.Count - 1; i++)
            {
                if (currentTime >= listTime[i] && currentTime < listTime[i + 1])
                {
                    lblLrc.Text = listLrc[i];
                }
            }
        }
        #endregion
        #region 歌名超出长度时 左右移动变换
        //int lefti=0;//设置移动次数
        int y = 0;
        int lx;
        int bl;
        //获得移动次数
        public void getNum()
        {
            bl = 0;
            lx = 0;
            labelname.Location = new Point(57, 13);
            if (labelname.Size.Width > 150)
            {
                bl = lx = labelname.Location.X + 100;
                y = labelname.Location.Y;
                titles.Enabled = true;
            }
            else
            {
                titles.Enabled = false;
            }
        }

        private void titles_Tick(object sender, EventArgs e)
        {
            if (lx >= -50)
            {
                labelname.Location = new Point(bl - 1, y);
                bl--;
                lx--;
            }
            else
            {
                titles.Enabled = false;
                titles2.Enabled = true;
            }
        }//向左移动
        private void titles2_Tick(object sender, EventArgs e)
        {
            if (lx < 57)
            {
                labelname.Location = new Point(bl + 1, y);
                bl++;
                lx++;
            }
            else
            {
                titles2.Enabled = false;
                titles.Enabled = true;
            }
        }//向右移动
        #endregion
        #region 绘制圆角
        private void Type(Control sender, int p_1, double p_2)
        {
            GraphicsPath oPath = new GraphicsPath();
            oPath.AddClosedCurve(
                new Point[] {
            new Point(0, sender.Height / p_1),
            new Point(sender.Width / p_1, 0),
            new Point(sender.Width - sender.Width / p_1, 0),
            new Point(sender.Width, sender.Height / p_1),
            new Point(sender.Width, sender.Height - sender.Height / p_1),
            new Point(sender.Width - sender.Width / p_1, sender.Height),
            new Point(sender.Width / p_1, sender.Height),
            new Point(0, sender.Height - sender.Height / p_1) },
                (float)p_2);
            sender.Region = new Region(oPath);
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Type(this, 15, 0.23);
        }
        #endregion

        private void 选择歌词文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "歌词文件|*.lrc";
            ofd.Title = "请选择文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string songPath = ofd.FileNames[0];
                string[] lrcText = File.ReadAllLines(songPath, Encoding.Default);
                lblLrc.Text = "已加载歌词";
                FormatLrc(lrcText);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            sd.Visible = true;
            if(axPlayer.settings.mute == false) { btnP.Image = Properties.Resources.sound_down; }
            else { btnP.Image = Properties.Resources.mute_down; }
        }
        

        private void btnP_MouseLeave(object sender, EventArgs e)
        {
            if (axPlayer.settings.mute == false) { btnP.Image = Properties.Resources.sound_on_; }
            else { btnP.Image = Properties.Resources.mute_on; }
        }

        private void sd_MouseLeave(object sender, EventArgs e)
        {
            if (axPlayer.settings.mute == false) { btnP.Image = Properties.Resources.sound_down; }
            else { btnP.Image = Properties.Resources.mute_down; }
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (axPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                btn.Image = Properties.Resources.pause_down;
            }
            else { btn.Image = Properties.Resources.play_down; }
        }

        private void btnnext_MouseDown(object sender, MouseEventArgs e)
        {
            btnnext.Image = Properties.Resources.next_down;
        }

        private void btnback_MouseDown(object sender, MouseEventArgs e)
        {
            btnback.Image = Properties.Resources.preview_down;
        }
    }
}
