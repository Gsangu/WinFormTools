using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 雷电游戏.Properties;

namespace 雷电游戏
{
     class PlaneHero:PlaneFather
    {
        //导入玩家飞机
        private static Image imgPlane = Resources.hero1;
        public PlaneHero(int x,int y,int speed,int life,Diretion dir) : base(x, y, imgPlane, speed, life, dir)
        {
            
        }
        //重写GameObject Draw
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgPlane, this.X, this.Y, this.Width / 2, this.Height / 2);
        }
        //飞机移动
        public void MouseMove(MouseEventArgs e)
        {
            this.X = e.X - 20;
            this.Y = e.Y - 20;
        }
        //提供一个开炮的函数
        public void Fire()
        {
            //初始化玩家子弹到游戏中
            SingleObject.GetSingle().AddGameObject(new HeroZiDan(this, 10, 1));
        }
        public override void IsOver()
        {
            SingleObject.GetSingle().AddGameObject(new HeroBoom(this.X, this.Y));
        }

    }
}
