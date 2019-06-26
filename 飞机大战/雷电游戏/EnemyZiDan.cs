using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 雷电游戏.Properties;

namespace 雷电游戏
{
    class EnemyZiDan :ZiDan
    {
        private static Image imgHero = Resources.bullet11;
        public EnemyZiDan(PlaneFather pf, int speed, int power) : base(pf, imgHero, speed, power)
        {

        }
    }
}
