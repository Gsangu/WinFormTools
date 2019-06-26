using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsanPlayer
{
    class Banner
    {
        public Banner(string title,string id , string type,string imgUrl)
        {
            this.title = title;this.id = id;this.type = type;this.imgUrl = imgUrl;
        }
        public Banner(string title,string id ,string type,string imgUrl,string url):this(title,id,type,imgUrl)
        {
            this.url = url;
        }
        public string title { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string imgUrl { get; set; }
        public string url { get; set; }
    }
}
