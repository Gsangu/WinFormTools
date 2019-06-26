using System;
using System.Collections.Generic;
using System.Text;
//作者：小红帽   QQ：761716178  论坛：http://bbs.cskin.net/
using Un4seen.Bass;

namespace GsanPlayer
{
    /// <summary>
    /// Bass插件
    /// </summary>
    public class BassPlugin
    {
        int handle = 0;
        /// <summary>
        /// 插件句柄
        /// </summary>
        public int Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        string fileName = string.Empty;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// 插件信息
        /// </summary>
        public BASS_PLUGININFO PluginInfo
        {
            get { return Bass.BASS_PluginGetInfo(handle); }
        }

        /// <summary>
        /// Bass插件
        /// </summary>
        /// <param name="fileName">文件名</param>
        public BassPlugin(string fileName)
        {
            this.fileName = fileName;
        }

        bool isLoaded = false;
        /// <summary>
        /// 是否已经成功加载
        /// </summary>
        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        /// <summary>
        /// 加载插件
        /// </summary>
        public void Load()
        {
            handle = Bass.BASS_PluginLoad(fileName);
            if (handle != 0)
            {
                isLoaded = true;
            }
        }

        /// <summary>
        /// 释放插件
        /// </summary>
        public void Free()
        {
            if (Bass.BASS_PluginFree(handle))
            {
                isLoaded = false;
            }
        }
    }
}
