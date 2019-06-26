using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GsanPlayer
{
    public partial class KtvLrc : Form
    {
        public KtvLrc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            fadeTimer.Enabled = true;
            this.TopMost = true;
            DrawSongWords("传播好音乐");
            this.Location = new Point(SystemInformation.WorkingArea.Width / 2 - pictureBox1.Width / 2, 680);
        }
        public int add = 0;
        public int width = 1024;//控制矩形宽度
        public void DrawSongWords(string SongWord)
        {
            width += add;
            Rectangle rec = new Rectangle(0, 0, width, 50);//0,0坐标,长width高32的矩形
            Bitmap bmp = new Bitmap(this.Width, this.Height);//申请图片
            Graphics myGraphics = Graphics.FromImage(bmp);
            GraphicsPath myGraphicsPath = new GraphicsPath();//声明路径myGraphicsPath
            FontFamily myFontFamily = new FontFamily("微软雅黑");
            int center = pictureBox1.Width / 2 - SongWord.Length * 40 / 2;
            if (center < 0) center = 0;
            Point myPoint = new Point(center, 0);
            StringFormat myStringFormat = new StringFormat();
            myGraphicsPath.AddString(SongWord, myFontFamily, 1, 40, myPoint, myStringFormat);

            LinearGradientBrush GrBrush = new LinearGradientBrush(this.ClientRectangle, Color.Aqua, Color.RosyBrown,LinearGradientMode.Vertical);//渐变颜色

            Pen myPen = new Pen(GrBrush, 1); //未播放字体的颜色

            myGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//反锯齿
            myGraphics.DrawPath(myPen, myGraphicsPath); //绘制路径myGraphicsPath
            Region re = new Region(rec);//声明Region对象
            re.Intersect(myGraphicsPath);
            myGraphics.FillRegion(GrBrush, re); ////用myBrash填充re的内部
            pictureBox1.Image = bmp;
        }
        Point formPoint;
        Point mousePoint;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 获取窗体的屏幕坐标(x,y)  
            formPoint = this.Location;
            // 获取鼠标光标的位置（屏幕坐标）  
            mousePoint = Control.MousePosition;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取鼠标移动时的屏幕坐标  
                Point mousePos = Control.MousePosition;
                //改变窗体位置  
                this.Location = new Point(formPoint.X + mousePos.X - mousePoint.X, formPoint.Y + mousePos.Y - mousePoint.Y);
            }
        }

        private void KtvLrc_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult drt = MessageBox.Show("歌词不能退出O(∩_∩)O~!", "提示", MessageBoxButtons.OK,MessageBoxIcon.Information);
            //if (drt == DialogResult.OK)
            //{
                e.Cancel = true;
            //}
        }
        private bool showing = true;
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            double d = 0.10;
            if (showing)
            {
                if (Opacity + d >= 1.0)
                {
                    Opacity = 1.0;
                    fadeTimer.Stop();
                }
                else
                {
                    Opacity += d;
                }
            }
            else
            {
                if (Opacity - d <= 0.0)
                {
                    Opacity = 0.0;
                    fadeTimer.Stop();
                }
                else
                {
                    Opacity -= d;
                }
            }
        }
    }
}
