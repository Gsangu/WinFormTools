using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Player
{
    public partial class about : Form
    {
        Form1 f = new Form1();
        private Point offset;
        public about()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://gsanweb.cn");
        }

        private void about_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void about_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void about_Load(object sender, EventArgs e)
        {
            //Segoe Script
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            string a = "Design by Gsan.";
            //string b = "版本号：1.0";
            //string c = "本程序是基于WMP制作而成";
            Graphics g = pictureBox1.CreateGraphics();
            
            for (int i = 0; i < a.Length; i++)
            {
                Point p = new Point(i * 20, 0);
                Color[] colors = { Color.Yellow, Color.Blue, Color.Black, Color.Green, Color.Red };
                g.DrawString(a[i].ToString(), new Font("Segoe Script", 20, FontStyle.Bold), new SolidBrush(colors[r.Next(0, 5)]), p);
            }
            //for (int i = 0; i < b.Length; i++)
            //{
            //    Point p = new Point(i * 22, 40);
            //    g.DrawString(b[i].ToString(), new Font("楷体", 18, FontStyle.Regular), Brushes.White, p);
            //}
            //for (int i = 0; i < c.Length; i++)
            //{
            //    Point p = new Point(i * 18, 70);
            //    g.DrawString(c[i].ToString(), new Font("楷体", 15, FontStyle.Regular), Brushes.White, p);
            //}
        }

    }
}
