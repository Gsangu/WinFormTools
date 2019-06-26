namespace 网易云音乐歌单歌曲下载
{
    class DownList
    {
      
        public DownList(string id,string h,string m,string l)
        {
            this.id = id;this.high = h;this.middle = m;this.less = l;
        }
        public string id { get; set; }
        public string high { get; set; }
        public string middle { get; set; }
        public string less { get; set; }
    }
}
