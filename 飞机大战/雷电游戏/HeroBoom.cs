using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 雷电游戏.Properties;

namespace 雷电游戏
{
    class HeroBoom:Boom
    {
        private Image[] imgs =
        {
            Resources.hero_blowup_n1,
            Resources.hero_blowup_n2,
            Resources.hero_blowup_n3,
            Resources.hero_blowup_n4
        };
        public HeroBoom(int x,int y) : base(x, y)
        {

        }
        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length; i++)
            {
                g.DrawImage(imgs[i], this.X, this.Y);
            }
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
