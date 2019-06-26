using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GsanPlayer
{
    class Kugou
    {
        public static List<MusicList> Search(string word)
        {
            List<MusicList> list = new List<MusicList>();
            WebClient web = new WebClient();
            string xml = Encoding.UTF8.GetString(web.DownloadData(""));
            XMLHelper xh = new XMLHelper(xml,"Kugou");
            return list;
        }
    }
}
