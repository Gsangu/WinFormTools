using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace GsanPlayer
{
    public class Lyric
    {
        /// <summary>
        /// 写入lrc文件
        /// </summary>
        /// <param name="lrcs">内容</param>
        /// <param name="name">文件名</param>
        private static void WriteFile(string lrcs, string path,string name)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream fs = File.Create(path + name);
            fs.Close();
            StreamWriter sw = new StreamWriter(path + name);
            sw.Write(lrcs);
            sw.Flush();
            sw.Close();
        }
        #region 读取lrc内容
        /// <summary>
        /// 解析歌词文件
        /// </summary>
        /// <param name="name">歌名</param>
        /// <param name="singer">歌手</param>
        /// <param name="id">是否为id</param>

        public static Dictionary<double, string> ReadLrc(string name,string singer,bool id)
        {
            singer = singer.Replace("/", ",");
            string names = "";
            if (singer != null)
            {
                names = singer + " - " + name;
            }
            string filepath = Environment.CurrentDirectory + "\\Lyrics\\";
            string path = filepath + names + ".lrc";
            Dictionary<double, string> lrcDic = new Dictionary<double, string>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string lrc = sr.ReadToEnd();
                    string reg = @"((?:\[\d+:\d+(?:.\d+)?\])+)(.*)";    //匹配时间和歌词
                    MatchCollection mc = Regex.Matches(lrc, reg);
                    foreach (var item in mc)
                    {
                        string timeReg = @"\[(\d+):(\d+)(?:.(\d+))?\]";     //匹配时间
                        MatchCollection mcMatch = Regex.Matches(item.ToString(), timeReg);
                        foreach (var mcTime in mcMatch)
                        {
                            string lrcReg = @"\][^\]]*$";
                            Match lrcMatch = Regex.Match(item.ToString(), lrcReg);
                            string[] lrcNewTemp = mcTime.ToString().Substring(1, mcTime.ToString().Length - 2).Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            double time = double.Parse(lrcNewTemp[0]) * 60 + double.Parse(lrcNewTemp[1]);
                            lrcDic.Add(time, lrcMatch.Value.Substring(1, lrcMatch.Length - 1));
                        }
                    }
                }
            }
            else
            {
                WebClient web = new WebClient();
                try
                {
                    string webSite = "";
                    if (id)
                        webSite = "http://api.gsanweb.cn/Netease/lyric?id=" + name;
                    else
                        webSite = "http://api.gsanweb.cn/Netease/lyric?word=" + name;
                    byte[] b = web.DownloadData(webSite);
                    string xml = Encoding.UTF8.GetString(b);
                    XMLHelper xh = new XMLHelper(xml, "Netease");
                    string lyric = xh.XmlList[0].ParentNode.SelectNodes("lrc")[0].SelectNodes("lyric")[0].InnerText;
                    WriteFile(lyric, filepath, names + ".lrc");
                    lrcDic = ReadLrc(name, singer, false);
                }
                catch
                {
                    return null;
                }
            }
            return lrcDic;
        }
        #endregion

    }
}