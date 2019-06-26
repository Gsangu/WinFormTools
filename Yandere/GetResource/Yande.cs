using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Yandere
{
    class Yande
    {
        private string tag;
        private int minWidth;
        private int minHeight;
        private int maxWidth;
        private int maxHeight;

        public Yande(string tag = "", int minWidth = 0, int minHeight = 0, int maxWidth = 0, int maxHeight = 0)
        {
            this.tag = tag;
            this.minWidth = minWidth;
            this.minHeight = minHeight;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;

        }

        public void ChangeTag(string tag)
        {
            this.tag = tag;
        }
        
        public string[,] GetPageImage(int page, WebProxy proxy = null)
        {
            string match = "id=\"p(?<id>\\d+)\" class=\".+?img\" href=\"(?<url>.+?)\">.+?directlink-res\">(?<width>\\d+) x (?<height>\\d+)</span>";
            string content = HttpHelper.GetHtml(string.Format("https://yande.re/post?tags={0}&page={1}",tag,page),null, proxy);
            MatchCollection mc = Regex.Matches(content, match);
            string[,] array = new string[mc.Count,4];
            for (int i = 0; i < mc.Count; i++)
            {
                if (IsDownload(int.Parse(mc[i].Groups["width"].Value), int.Parse(mc[i].Groups["height"].Value)))
                {
                    array[i, 0] = mc[i].Groups["id"].Value;
                    array[i, 1] = mc[i].Groups["url"].Value;
                    array[i, 2] = mc[i].Groups["width"].Value;
                    array[i, 3] = mc[i].Groups["height"].Value;
                }
            }
            return array;
        }

        private bool IsDownload(int width,int height)
        {
            return !((maxWidth != 0 && width > maxWidth) || (minWidth != 0 && width < minWidth) || (maxHeight != 0 && height > maxHeight) || (minHeight != 0 && height < minHeight));
        }
    }
}
