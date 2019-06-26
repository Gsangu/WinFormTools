using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
//作者：小红帽   QQ：761716178  论坛：http://bbs.cskin.net/
using Un4seen.Bass;

namespace GsanPlayer
{
    /// <summary>
    /// 歌曲标签信息
    /// </summary>
    public class MusicTags
    {
        /// <summary>
        /// 风格流派集合
        /// </summary>
        public static readonly string[] ID3v1Genre = new string[] { 
            "Blues", "Classic Rock", "Country", "Dance", "Disco", "Funk", "Grunge", "Hip-Hop", "Jazz", "Metal", "New Age", "Oldies", "Other", "Pop", "R&B", "Rap", 
            "Reggae", "Rock", "Techno", "Industrial", "Alternative", "Ska", "Death Metal", "Pranks", "Soundtrack", "Euro-Techno", "Ambient", "Trip-Hop", "Vocal", "Jazz+Funk", "Fusion", "Trance", 
            "Classical", "Instrumental", "Acid", "House", "Game", "Sound Clip", "Gospel", "Noise", "Alternative Rock", "Bass", "Soul", "Punk", "Space", "Meditative", "Instrumental Pop", "Instrumental Rock", 
            "Ethnic", "Gothic", "Darkwave", "Techno-Industrial", "Electronic", "Pop-Folk", "Eurodance", "Dream", "Southern Rock", "Comedy", "Cult", "Gangsta", "Top 40", "Christian Rap", "Pop/Funk", "Jungle", 
            "Native American", "Cabaret", "New Wave", "Psychedelic", "Rave", "Showtunes", "Trailer", "Lo-Fi", "Tribal", "Acid Punk", "Acid Jazz", "Polka", "Retro", "Musical", "Rock & Roll", "Hard Rock", 
            "Folk", "Folk/Rock", "National Folk", "Swing", "Fusion", "Bebob", "Latin", "Revival", "Celtic", "Bluegrass", "Avantgarde", "Gothic Rock", "Progressive Rock", "Psychedelic Rock", "Symphonic Rock", "Slow Rock", 
            "Big Band", "Chorus", "Easy Listening", "Acoustic", "Humour", "Speech", "Chanson", "Opera", "Chamber Music", "Sonata", "Symphony", "Booty Bass", "Primus", "Porn Groove", "Satire", "Slow Jam", 
            "Club", "Tango", "Samba", "Folklore", "Ballad", "Power Ballad", "Rhythmic Soul", "Freestyle", "Duet", "Punk Rock", "Drum Solo", "A Cappella", "Euro-House", "Dance Hall", "Goa", "Drum & Bass", 
            "Club-House", "Hardcore", "Terror", "Indie", "BritPop", "Negerpunk", "Polsk Punk", "Beat", "Christian Gangsta Rap", "Heavy Metal", "Black Metal", "Crossover", "Contemporary Christian", "Christian Rock", "Merengue", "Salsa", 
            "Thrash Metal", "Anime", "Jpop", "Synthpop"
         };

        string fileName = string.Empty;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        string title = string.Empty;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        string artist = string.Empty;
        /// <summary>
        /// 艺术家
        /// </summary>
        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        string album = string.Empty;
        /// <summary>
        /// 唱片集
        /// </summary>
        public string Album
        {
            get { return album; }
            set { album = value; }
        }

        string year = string.Empty;
        /// <summary>
        /// 年份
        /// </summary>
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        string genre = string.Empty;
        /// <summary>
        /// 流派
        /// </summary>
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        string comment = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        string bitRate = string.Empty;
        /// <summary>
        /// 比特率
        /// </summary>
        public string BitRate
        {
            get { return bitRate; }
            set { bitRate = value; }
        }

        string digitalisation = string.Empty;
        /// <summary>
        /// 采样率
        /// </summary>
        public string Digitalisation
        {
            get { return digitalisation; }
            set { digitalisation = value; }
        }

        //string bit = string.Empty;
        ///// <summary>
        ///// 比特
        ///// </summary>
        //public string Bit
        //{
        //    get { return bit; }
        //    set { bit = value; }
        //}

        string duration = string.Empty;
        /// <summary>
        /// 持续时间00:00格式
        /// </summary>
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        double length = 0;
        /// <summary>
        /// 持续时间单位秒
        /// </summary>
        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        Image albumArt;
        /// <summary>
        /// 专辑封面
        /// </summary>
        public Image AlbumArt
        {
            get { return albumArt; }
            set { albumArt = value; }
        }

        int stream = 0;

        string extension = string.Empty;
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        long fileSize = 0;
        /// <summary>
        /// 文件大小 字节
        /// </summary>
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        string[] tags;//标签数组
        string frameId;
        string value;

        /// <summary>
        /// 初始化歌曲标签
        /// </summary>
        /// <param name="fileName">文件名</param>
        public MusicTags(string fileName)
            : this(fileName, true)
        {

        }

        /// <summary>
        /// 初始化歌曲标签，是否加载歌曲专辑封面
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="getPic"></param>
        public MusicTags(string fileName, bool getPic)
        {
            this.fileName = fileName;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                extension = Path.GetExtension(fileName).ToLower();
                stream = Bass.BASS_StreamCreateFile(fileName, 0L, 0L, BASSFlag.BASS_MUSIC_NOSAMPLE);
                if (stream != 0)
                {
                    switch (extension)
                    {
                        #region mp3
                        case ".mp3":
                            if (!GetAPETags(stream))
                            {
                                if (!GetID3V2Tags(stream))
                                {
                                    GetID3V1Tags(stream);
                                }
                            }
                            break;
                        #endregion

                        #region wma
                        case ".wma":
                            GetWMATags(stream);

                            break;
                        #endregion

                        #region aac m4a mp4
                        case ".aac":
                        case ".m4a":
                        case ".mp4":

                            if (!GetMP4Tags(stream))
                            {
                                GetAPETags(stream);
                            }

                            break;
                        #endregion

                        #region ape wav
                        case ".ape":
                        case ".wav":
                            GetAPETags(stream);
                            break;
                        #endregion

                        #region flac ogg
                        case ".flac":
                        case ".ogg":
                            GetOGGTags(stream);
                            break;
                        #endregion

                    }

                    if (getPic)
                    {
                        GetPicture();
                    }

                }

                if (string.IsNullOrEmpty(title))
                {
                    title = Path.GetFileNameWithoutExtension(fileName);
                }

                BASS_CHANNELINFO channelInfo = Bass.BASS_ChannelGetInfo(stream);
                //bit = channelInfo.origres.ToString() + " Bits";
                digitalisation = channelInfo.freq.ToString();

                long len = Bass.BASS_ChannelGetLength(stream);
                double time = Bass.BASS_ChannelBytes2Seconds(stream, len);
                if (time < 0)
                {
                    time = 0;
                }
                int temp = (int)time / 60;
                duration = string.Format("{0:00}", temp) + ":" + string.Format("{0:00}", time - temp * 60);
                length = time;

                long num4 = Un4seen.Bass.Bass.BASS_StreamGetFilePosition(stream, BASSStreamFilePosition.BASS_FILEPOS_END);
                bitRate = ((int)((((double)num4) / (125.0 * time)) + 0.5)).ToString();

                FileInfo fi = new FileInfo(fileName);
                fileSize = fi.Length;

                Bass.BASS_StreamFree(stream);
            }
        }

        public MusicTags()
        { }

        private bool GetOGGTags(int stream)
        {
            tags = Bass.BASS_ChannelGetTagsOGG(stream);
            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    frameId = tags[i].Split('=')[0];
                    value = tags[i].Split('=')[1];
                    switch (frameId)
                    {
                        case "Title":
                            title = value;
                            break;
                        case "Artist":
                            artist = value;
                            break;
                        case "Album":
                            album = value;
                            break;
                        case "Comment":
                            comment = value;
                            break;
                        case "Year":
                            year = value;
                            break;
                        case "Genre":
                            genre = value;
                            break;
                    }

                }

                return true;
            }
            return false;

        }


        private bool GetAPETags(int stream)
        {
            tags = Bass.BASS_ChannelGetTagsAPE(stream);
            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    frameId = tags[i].Split('=')[0];
                    value = tags[i].Split('=')[1];
                    switch (frameId)
                    {
                        case "Title":
                            title = value;
                            break;
                        case "Artist":
                            artist = value;
                            break;
                        case "Album":
                            album = value;
                            break;
                        case "Comment":
                            comment = value;
                            break;
                        case "Year":
                            year = value;
                            break;
                        case "Genre":
                            genre = value;
                            break;
                    }

                }
                BASS_TAG_APE_BINARY[] temp = Bass.BASS_ChannelGetTagsAPEBinary(stream);
                return true;
            }
            return false;
        }


        private bool GetMP4Tags(int stream)
        {
            tags = Bass.BASS_ChannelGetTagsMP4(stream);
            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    frameId = tags[i].Split('=')[0];
                    value = tags[i].Split('=')[1];
                    switch (frameId)
                    {
                        case "title":
                            title = value;
                            break;
                        case "artist":
                            artist = value;
                            break;
                        case "album":
                            album = value;
                            break;
                        case "comment":
                            comment = value;
                            break;
                        case "year":
                            year = value;
                            break;
                        case "genre":
                            genre = value;
                            break;
                    }

                }
                return true;
            }
            return false;
        }


        private bool GetID3V2Tags(int stream)
        {
            tags = BASS_ChannelGetTagsID3V2(stream);
            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    frameId = tags[i].Split('=')[0];
                    value = tags[i].Split('=')[1];
                    switch (frameId)
                    {
                        case "TIT2":
                            title = value;
                            break;
                        case "TPE1":
                            artist = value;
                            break;
                        case "TALB":
                            album = value;
                            break;
                        case "COMM":
                            comment = value;
                            break;
                        case "TYER":
                            year = value;
                            break;
                        case "TCON":
                            if (!string.IsNullOrEmpty(value))
                            {
                                int gId = 12;
                                if (int.TryParse(value, out gId))
                                {
                                    if (gId < 0 || gId >= ID3v1Genre.Length)
                                    {
                                        gId = 12;
                                    }
                                    genre = ID3v1Genre[gId];
                                }
                                else
                                {
                                    genre = value;
                                }
                            }
                            break;
                    }

                }

                return true;
            }
            return false;
        }


        private bool GetID3V1Tags(int stream)
        {
            tags = Bass.BASS_ChannelGetTagsID3V1(stream);
            if (tags != null)
            {
                title = tags[0];
                artist = tags[1];
                album = tags[2];
                year = tags[3];
                comment = tags[4];
                if (!string.IsNullOrEmpty(tags[5]))
                {
                    int gId = 12;
                    int.TryParse(tags[5], out gId);
                    if (gId < 0 || gId >= ID3v1Genre.Length)
                    {
                        gId = 12;
                    }
                    genre = ID3v1Genre[gId];
                }
                return true;
            }
            return false;
        }


        private bool GetWMATags(int stream)
        {
            tags = Bass.BASS_ChannelGetTagsMF(stream);

            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    frameId = tags[i].Split('=')[0];
                    value = tags[i].Split('=')[1];
                    switch (frameId)
                    {
                        case "Title":
                            title = value;
                            break;
                        case "Author":
                            artist = value;
                            break;
                        case "WM/AlbumTitle":
                            album = value;
                            break;
                        case "Description":
                            comment = value;
                            break;
                        case "WM/Year":
                            year = value;
                            break;
                        case "WM/Genre":
                            genre = value;
                            break;
                    }
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// 返回字符串表达形式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return title + "，" + artist + "，" + album + "，" + duration + "，" + (Convert.ToDouble( fileSize) / 1024 / 1024).ToString("f1") + "MB";
        }


        private string[] BASS_ChannelGetTagsID3V2(int handle)
        {
            IntPtr ptr = Bass.BASS_ChannelGetTags(handle, BASSTag.BASS_TAG_ID3V2);
            if (ptr != IntPtr.Zero)
            {
                try
                {
                    List<string> list = new List<string>();
                    ID3V2 ID3V2Tag = new ID3V2(ptr);
                    int num = 0;
                    while (ID3V2Tag.k())
                    {
                        string str = ID3V2Tag.m();
                        object obj2 = ID3V2Tag.j();
                        short num2 = ID3V2Tag.i();

                        if (string.IsNullOrEmpty(str))
                        {//可能会有问题
                            break;
                        }

                        if ((str.Length > 0) && (obj2 is string))
                        {
                            list.Add(string.Format("{0}={1}", str, obj2));
                        }
                        else if (((str == "POPM") || (str == "POP")) && (obj2 is byte))
                        {
                            if (num == 0)
                            {
                                list.Add(string.Format("POPM={0}", obj2));
                            }
                            num++;
                            continue;
                        }

                    }
                    ID3V2Tag.Dispose();
                    if (list.Count > 0)
                    {
                        return list.ToArray();
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }


        private byte[] GetBytes(byte[] bytes, int start, int end)
        {
            byte[] tByte = new byte[end + 1 - start];
            int index = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                if (i >= start && i <= end)
                {
                    tByte[index] = bytes[i];
                    index++;
                }
            }
            return tByte;
        }


        private void GetPicture()
        {
            //先尝试从ID3V2中查找图片
            if (!GetPictureFromID3V2())
            {

            }

        }


        private bool bytesToImage(byte[] bystes)
        {
            byte[] imageBytes;
            int start = 0;
            int end = 0;
            ImageConverter converter;
            //获取jpg图片数据开始与结尾
            for (int i = 0; i < bystes.Length; i++)
            {
                if (bystes[i] == 0xFF && bystes[i + 1] == 0xd8)
                {
                    start = i;
                    break;
                }
            }
            try
            {//尝试从尾部开始查找
                for (int i = bystes.Length - 2; i > 0; i--)
                {
                    if (bystes[i] == 0xFF && bystes[i + 1] == 0xd9)
                    {
                        end = i + 1;
                        break;
                    }
                }

                imageBytes = GetBytes(bystes, start, end);
                MemoryStream ms = new MemoryStream(imageBytes);
                albumArt = Image.FromStream(ms);
                ms.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                try
                {//尝试从前面开始查找
                    for (int i = start; i < bystes.Length; i++)
                    {
                        if (bystes[i] == 0xFF && bystes[i + 1] == 0xd9)
                        {
                            end = i + 1;
                            break;
                        }
                    }

                    imageBytes = GetBytes(bystes, start, end);
                    converter = new ImageConverter();
                    albumArt = (converter.ConvertFrom(imageBytes) as Image);
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }


        }


        private bool GetPictureFromID3V2()
        {
            IntPtr ptr = Bass.BASS_ChannelGetTags(stream, BASSTag.BASS_TAG_ID3V2);
            if (ptr != IntPtr.Zero)
            {
                try
                {
                    List<string> list = new List<string>();
                    ID3V2 ID3V2Tag = new ID3V2(ptr);

                    while (ID3V2Tag.k())
                    {
                        string str = ID3V2Tag.m();
                        object obj2 = ID3V2Tag.j();
                        short num2 = ID3V2Tag.i();
                        if (string.IsNullOrEmpty(str))
                        {
                            break;
                        }
                        //读取图片
                        if (((str == "APIC") || (str == "PIC")) && (obj2 is byte[]))
                        {
                            if (bytesToImage(obj2 as byte[]))
                            {
                                return true;
                            }
                        }
                    }
                    ID3V2Tag.Dispose();
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

    }

}
