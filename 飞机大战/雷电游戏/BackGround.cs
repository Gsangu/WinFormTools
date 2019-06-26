using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 雷电游戏.Properties;

namespace 雷电游戏
{
    class BackGround : GameObject
    {
        //背景图片
        private static Image imgBG = Resources.background;
        //调用父类函数
        public BackGround(int x,int y,int speed):base(x, y, imgBG.Width, imgBG.Height, speed, 0, Diretion.Down)
        {

        }
        public override void Draw(Graphics g)
        {
            this.Y += this.Speed;
            if (this.Y == 0)
            {
                this.Y = -850;
            }
            //坐标改变完成，将背景不停绘制到窗体
            g.DrawImage(imgBG, this.X, this.Y);
        }
    }
}
