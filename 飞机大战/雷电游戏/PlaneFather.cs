using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 雷电游戏
{
    /// <summary>
    /// 飞机父类
    /// </summary>
    abstract class PlaneFather : GameObject
    {
        private Image imgPlane;
        public PlaneFather(int x,int y,Image img ,int speed,int life,Diretion dir) : base(x, y, img.Width, img.Height, speed, life, dir)
        {
            this.imgPlane = img;
        }
        public abstract void IsOver();

    }
}
