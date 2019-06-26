using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 雷电游戏.Properties;

namespace 雷电游戏
{
    class PlaneEnemy : PlaneFather
    {
        private static Image img1 = Resources.enemy0;//小
        private static Image img2 = Resources.enemy1;//中
        private static Image img3 = Resources.enemy2;//大
        static Random r = new Random();

        public PlaneEnemy(int x,int y,int type ) : base(x, y,GetImage(type),GetSpeed(type),GetLife(type),Diretion.Down)
        {
            this.EnemyType = type;
        }
        public int EnemyType
        {
            get;
            set;
        }
        //飞机每一架飞机大小生命值速度都不一样
        public static Image GetImage(int type)
        {
            switch (type)
            {
                case 0:return img1;
                case 1:return img2;
                case 2:return img3;
            }
            return null;
        }
        public static int GetLife(int type)
        {
            switch (type)
            {
                case 0:return 1;
                case 1:return 2;
                case 2:return 3;
            }
            return 0;
        }
        public static int GetSpeed(int type)
        {
            switch (type)
            {
                case 0: return 5;
                case 1: return 6;
                case 2: return 7;
            }
            return 0;
        }
        public override void Draw(Graphics g)
        {
            this.Move();
            switch (this.EnemyType)
            {
                case 0:g.DrawImage(img1, this.X, this.Y);break;
                case 1:g.DrawImage(img2, this.X, this.Y);break;
                case 2:g.DrawImage(img3, this.X, this.Y);break;
            }
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
                case Diretion.Left:
                    this.X -= this.Speed;
                    break;
                case Diretion.Right:
                    this.X += this.Speed;
                    break;
            }
            if (this.X <= 0)
            {
                this.X = 0;
            }
            if (this.X >= 400)
            {
                this.X = 400;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.Y >= 700)
            {
                this.Y = 1400;//到达窗体底端  离开窗体
                SingleObject.GetSingle().RemoveGameObject(this);
            }
            //敌人飞机类型为0
            if (this.EnemyType == 0 && this.Y >= 200)
            {
                if (this.X >= 0 && this.X <= 220)
                {
                    //飞机在左边
                    this.X+=r.Next(0,50);
                }else
                {
                    this.X -= r.Next(0, 50);
                }
            }else
            {
                //如果是大飞机
                this.Speed += 1;
            }
            if (r.Next(0, 100) > 90)
            {//随机飞机发射子弹
                Fire();
            }
        }
        public void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyZiDan(this,20,1));
        }
        public override void IsOver()
        {
            if (this.Life <= 0)
            {
                //敌人飞机坠毁
                SingleObject.GetSingle().RemoveGameObject(this);
                SingleObject.GetSingle().AddGameObject(new EnemyBoom(this.X, this.Y,EnemyType));
                //给玩家加分
                switch (this.EnemyType)
                {
                    case 0:
                        SingleObject.GetSingle().Score += 100;
                        break;
                    case 1:
                        SingleObject.GetSingle().Score += 200; break;
                    case 2:
                        SingleObject.GetSingle().Score += 300; break;
                }
            }
        }

    }
}
