using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 雷电游戏
{

    enum Diretion
    {
        Up,
        Down,
        Left,
        Right
    }
    /// <summary>
    /// 所有游戏对象的父类，封装所有子类共有成员
    /// </summary>
    abstract class GameObject
    {
        #region 横纵坐标高度宽度速度生命值方向
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }
        public Diretion Dir
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="speed"></param>
        /// <param name="life"></param>
        /// <param name="dir"></param>
        public GameObject (int x,int y,int width,int height,int speed,int life,Diretion dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }
        
        public abstract void Draw(Graphics g);

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
        public GameObject(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        /// <summary>
        /// 移动的虚方法
        /// </summary>
        public virtual void Move()
        {
            //根据游戏对象方向进行移动
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
            //移动完成后 判断一下对象是否超出窗体
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
                this.Y = 700;
            }

        }

    }
    
}
