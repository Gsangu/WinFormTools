using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace GsanPlayer
{
    class Netease
    {
        /// <summary>
        /// 搜索歌曲
        /// </summary>
        /// <param name="word">搜索关键字</param>
        /// <param name="limit">数量</param>
        /// <param name="offset">偏移</param>
        /// <returns></returns>
        public static List<MusicList> SearchMusic(string word,int limit = 10, int offset = 0)
        {
            List<MusicList> list = new List<MusicList>();
            WebClient web = new WebClient();
            string url = string.Format("http://api.gsanweb.cn/Netease/search?word={0}&limit={1}&offset={2}&type={3}", word, limit, offset, 1);
            string xml = Encoding.UTF8.GetString(web.DownloadData(url));
            XMLHelper xh = new XMLHelper(xml, "Netease");
            XmlNodeList xmlist = xh.XmlList;
            for (int i = 0; i < xmlist[0].SelectNodes("songs")[0].ChildNodes.Count; i++)
            {

            }
            return list;
        }
        public static List<Banner> GetBanner()
        {
            List<Banner> list = new List<Banner>();
            WebClient web = new WebClient();
            string url = string.Format("http://api.gsanweb.cn/Netease/batch");
            string xml = Encoding.UTF8.GetString(web.DownloadData(url));
            XMLHelper xh = new XMLHelper(xml, "Netease");
            XmlNodeList xmlist = xh.XmlList;
            foreach (XmlNode node in xmlist[0].SelectNodes("banners")[0].ChildNodes)
            {
                try
                {
                    string title = node.SelectNodes("typeTitle")[0].InnerText;
                    string id = node.SelectNodes("targetId")[0].InnerText;
                    string type = node.SelectNodes("targetType")[0].InnerText;
                    string imgUrl = node.SelectNodes("imageUrl")[0].InnerText;
                    Banner b = new Banner(title, id, type, imgUrl);
                    if (type == "1005")
                    {
                        string turl = node.SelectNodes("url")[0].InnerText;
                        b = new Banner(title, id, type, imgUrl, turl);
                    }
                    list.Add(b);
                }
                catch { continue; }
            }
            return list;
        }
    }
}
