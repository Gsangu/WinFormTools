using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 雷电游戏
{
    class SingleObject
    {
        //单例设计模式

        private SingleObject()
        {

        }
        private static SingleObject _singte = null;
    
        public static SingleObject GetSingle()
        {
            if (_singte == null)
            {
                _singte = new SingleObject();
            }
            return _singte;
        }
        //存储游戏背景
        public BackGround Bg
        {
            get;
            set;
        }
        //存储玩家飞机
        public PlaneHero PH
        {
            get;
            set;
        }

        //玩家子弹
        List<HeroZiDan> listHeroZidan = new List<HeroZiDan>();

        //敌人飞机
        public List<PlaneEnemy> listPlaneEnemy = new List<PlaneEnemy>();
        //敌人爆炸
        List<EnemyBoom> listenemyBoom = new List<EnemyBoom>();
        //敌人子弹
        List<EnemyZiDan> listEnemyZidan = new List<EnemyZiDan>();
        //玩家爆炸
        List<HeroBoom> listHeroBoom = new List<HeroBoom>();
        //将游戏对象添加到窗体
        public void AddGameObject(GameObject go)
        {
            if(go is BackGround)
            {
                this.Bg = go as BackGround;
            }
            else if(go is PlaneHero)
            {
                this.PH = go as PlaneHero;
            }else if(go is HeroZiDan)
            {
                listHeroZidan.Add(go as HeroZiDan);
            }
            else if(go is PlaneEnemy)
            {
                listPlaneEnemy.Add(go as PlaneEnemy);
            }else if(go is EnemyBoom)
            {
                listenemyBoom.Add(go as EnemyBoom);
            }else if(go is EnemyZiDan)
            {
                listEnemyZidan.Add(go as EnemyZiDan);
            }else if(go is HeroBoom)
            {
                listHeroBoom.Add(go as HeroBoom);
            }
        }
        //将游戏对象从游戏移除
        public void RemoveGameObject(GameObject go)
        {
            if(go is PlaneEnemy)
            {
                listPlaneEnemy.Remove(go as PlaneEnemy);
            }
            else if(go is HeroZiDan)
            {
                listHeroZidan.Remove(go as HeroZiDan);
            }else if(go is EnemyBoom)
            {
                listenemyBoom.Remove(go as EnemyBoom);
            }else if(go is EnemyZiDan)
            {
                listEnemyZidan.Remove(go as EnemyZiDan);
            }else if(go is HeroBoom)
            {
                listHeroBoom.Remove(go as HeroBoom);
            }
        }

        public void Draw(Graphics g)
        {
            this.Bg.Draw(g);//绘制背景
            this.PH.Draw(g);//绘制玩家飞机
            for (int i = 0; i < listHeroZidan.Count; i++)
            {
                listHeroZidan[i].Draw(g);
            }
            for (int i = 0; i < listPlaneEnemy.Count; i++)
            {
                listPlaneEnemy[i].Draw(g);
            }
            for (int i = 0; i < listenemyBoom.Count; i++)
            {
                listenemyBoom[i].Draw(g);
            }
            for (int i = 0; i < listEnemyZidan.Count; i++)
            {
                listEnemyZidan[i].Draw(g);
            }
            for (int i = 0; i < listHeroBoom.Count; i++)
            {
                listHeroBoom[i].Draw(g);
            }
        }
        //记录玩家分数
        public int Score
        {
            get;
            set;
        }
        public void PZJC()
        {
            #region 判断子弹是否打到敌人
            for (int i = 0; i < listHeroZidan.Count; i++)
            {
                for (int j = 0; j < listPlaneEnemy.Count; j++)
                {
                    //判断是否相交
                    if (listHeroZidan[i].GetRectangle().IntersectsWith(listPlaneEnemy[j].GetRectangle()))
                    {
                        listPlaneEnemy[j].Life -= listHeroZidan[i].Power;
                        listPlaneEnemy[j].IsOver();//判断是否被击毁
                        listHeroZidan.Remove(listHeroZidan[i]);
                        break;
                    }

                }
            }
            #endregion

            #region 判断敌人子弹是否打到玩家
            for (int i = 0; i < listEnemyZidan.Count; i++)
            {
                if (listEnemyZidan[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    //玩家发生爆炸 但不死亡
                    this.PH.IsOver();
                    break;
                }
            }
            #endregion

            #region 判断玩家是否和敌人飞机相撞
            for (int i = 0; i < listPlaneEnemy.Count; i++)
            {
                if(listPlaneEnemy[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    listPlaneEnemy[i].Life = 0;
                    listPlaneEnemy[i].IsOver();
                    break;
                }
            }
            #endregion

        }
    }
}
