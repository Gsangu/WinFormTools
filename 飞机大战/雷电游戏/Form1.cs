using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 雷电游戏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }
        static Random r = new Random();
        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitialGame()
        {
            //初始化背景
            SingleObject.GetSingle().AddGameObject(new BackGround(0, -850, 5));
            
            //初始化玩家飞机
            SingleObject.GetSingle().AddGameObject(new PlaneHero(100, 100, 5, 3, Diretion.Up));
            InitialPlaneEnemy();
        }
        //增加敌人飞机
        void InitialPlaneEnemy()
        {
            for (int i = 0; i < 4; i++)
            {
                //初始化敌人飞机
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -400, r.Next(0, 1)));
            }
            if (r.Next(0, 100) > 80)
            {
                //大飞机出现概率
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -400, 1));
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //窗体重新绘制，重新绘制背景
            SingleObject.GetSingle().Draw(e.Graphics);
            //显示分数
            string score = SingleObject.GetSingle().Score.ToString();
            e.Graphics.DrawString(score, new Font("宋体", 20, FontStyle.Bold), Brushes.Red, new Point(0, 0));
            //绘制到缓存区
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void timerBG_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            //判断敌人飞机数量
            int count = SingleObject.GetSingle().listPlaneEnemy.Count;
            if(count < 1)
            {
                //重新初始化敌人飞机
                InitialPlaneEnemy();
            }
            //碰撞检测
            SingleObject.GetSingle().PZJC();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //移动飞机
            SingleObject.GetSingle().PH.MouseMove(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            SingleObject.GetSingle().PH.Fire();
        }
    }
}
