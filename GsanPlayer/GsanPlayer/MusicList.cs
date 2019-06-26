using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GsanPlayer
{
    class MusicList
    {
        public MusicList(string url, Image imgUrl, string fullName)
        {
            this.url = url; this.imgUrl = imgUrl; this.fullName = fullName.Remove(fullName.LastIndexOf('.'), fullName.Length - fullName.LastIndexOf('.'));
        }
        public MusicList(string location, string imgLocation, string artist,string name)
        {
            url = location;imgUrl = ImageHelper.GetImg(imgLocation);fullName = artist + " - " + name;
        }
        public string url { get; set; }
        public Image imgUrl { get; set; }
        public string fullName { get; set; }
    }
}
