using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 雷电游戏
{
    abstract class Boom:GameObject
    {
        //爆炸检测
        public Boom(int x,int y) : base(x, y)
        {

        }
    }
}
