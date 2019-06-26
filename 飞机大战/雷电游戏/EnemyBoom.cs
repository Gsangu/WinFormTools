using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 雷电游戏.Properties;

namespace 雷电游戏
{
    class EnemyBoom : Boom
    {
        //爆炸时的图片
        private Image[] imgs1 = {
            Resources.enemy0_down11,
            Resources.enemy0_down2,
            Resources.enemy0_down3,
            Resources.enemy0_down4, };
        private Image[] imgs2 = {
            Resources.enemy1_down11,
            Resources.enemy1_down2,
            Resources.enemy1_down3,
            Resources.enemy1_down4, };
        private Image[] imgs3 = {
            Resources.enemy2_down11,
            Resources.enemy2_down2,
            Resources.enemy2_down3,
            Resources.enemy2_down4, };

        //根据敌人类型播放爆炸图片
        public int Type
        {
            get;
            set;
        }
        public EnemyBoom(int x,int y,int type) : base(x, y)
        {
            this.Type = type;
        }
        public override void Draw(Graphics g)
        {
            switch (this.Type)
            {
                case 0:
                    for (int i = 0; i < imgs1.Length; i++)
                    {
                        g.DrawImage(imgs1[i], this.X, this.Y);
                    }
                    break;
                case 1:
                    for (int i = 0; i < imgs2.Length; i++)
                    {
                        g.DrawImage(imgs2[i], this.X, this.Y);
                    }
                    break;
                case 2:
                    for (int i = 0; i < imgs3.Length; i++)
                    {
                        g.DrawImage(imgs3[i], this.X, this.Y);
                    }
                    break;
            }
            //爆炸后销毁
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
