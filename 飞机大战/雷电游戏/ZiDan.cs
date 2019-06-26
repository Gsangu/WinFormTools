using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 雷电游戏
{
    //子弹
    class ZiDan:GameObject
    {
        private Image imgZiDan;
        //记录子弹威力
        public int Power
        {
            get;
            set;
        }
        public ZiDan(PlaneFather pf,Image img,int speed,int power) : base(pf.X + pf.Width/2-28, pf.Y + pf.Height/2-60, img.Width, img.Height, speed, 0, pf.Dir)
        {
            this.imgZiDan = img;
            this.Power = power;
        }

        //
        public override void Draw(Graphics g)
        {
            this.Move();
            g.DrawImage(imgZiDan, this.X, this.Y,this.Width/2,this.Height/2);
        }

        public override void Move()
        {
            switch (this.Dir)
            {
                case Diretion.Up:
                    this.Y -= this.Speed;
                    break;
                case Diretion.Down:
                    this.Y += this.Speed;
                    break;
            }
            //子弹发出后  控制子弹坐标
            if (this.Y <= 0)
            {
                this.Y = -100;
                //移除
            }
            if (this.Y >= 700)
            {
                this.Y = 1000;
            }
        }
    }
}
