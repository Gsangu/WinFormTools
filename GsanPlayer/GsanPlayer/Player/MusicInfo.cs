using GsanPlayer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GsanPlayer.Player
{
    class MusicInfo
    {
        private string url = string.Empty;
        /// <summary>
        /// 歌曲播放路径
        /// </summary>
        public string Url { get => url; set => url = value; }

        private Image img = Resources.file;
        /// <summary>
        /// 歌曲头像
        /// </summary>
        public Image Img {  get => img; set => img = value; }

        public string title = string.Empty;
        /// <summary>
        /// 歌曲标题
        /// </summary>
        public string Title { get => title; set => title = value; }

        public string artist = string.Empty;
        /// <summary>
        /// 歌曲艺术家
        /// </summary>
        public string Artist { get => artist; set => artist = value; }

        private string fullName = string.Empty;
        /// <summary>
        /// 歌曲全名
        /// </summary>
        public string FullName
        {
            get => fullName; set
            {
                fullName = value.Remove(value.LastIndexOf('.'), value.Length - value.LastIndexOf('.'));
            }
        }
    }
}
