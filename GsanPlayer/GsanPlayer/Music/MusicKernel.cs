using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;
//作者：小红帽   QQ：761716178  论坛：http://bbs.cskin.net/
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Tags;

namespace GsanPlayer
{
    /// <summary>
    /// 音乐内核
    /// </summary>
    public class MusicKernel : IDisposable
    {
        string fileName = String.Empty;//路径
        /// <summary>
        /// 歌曲路径，或者Url
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value.Trim().ToLower();
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (fileName.StartsWith("http://") || fileName.StartsWith("https://") || fileName.StartsWith("ftp://"))
                        {
                            musicFromFile = false;
                        }
                        else
                        {
                            musicFromFile = true;
                        }
                    }
                    musicTags = new MusicTags(fileName);
                    isNeedCreateStream = true;
                }
            }
        }

        /// <summary>
        /// 是否需要重新创建流
        /// </summary>
        bool isNeedCreateStream = true;

        int stream = 0;
        /// <summary>
        /// 音频流句柄
        /// </summary>
        public int Stream
        {
            get { return stream; }
            set { stream = value; }
        }

        /// <summary>
        /// 获取或设置当前歌曲时间，单位秒
        /// </summary>
        public double MusicTime
        {
            get
            {
                return Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream));

            }
            set { Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, value)); }
        }
        int oldVolume = 100;//原来的音量
        int volume = 100;//音量
        /// <summary>
        /// 音量0—100
        /// </summary>
        public int Volume
        {
            get
            {
                volume = Bass.BASS_GetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM) / 100;
                return volume;
            }
            set
            {
                if (volume != value)
                {
                    volume = value;
                    if (value > 100)
                    {
                        volume = 100;
                    }
                    if (value < 0)
                    {
                        volume = 0;
                    }
                    oldVolume = volume;
                    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, volume * 100);
                    OnVolumeChanged(new MusicEventArgs(PlayState, volume, Schedule, false));
                }
            }
        }

        bool silence = false;
        /// <summary>
        /// 是否静音
        /// </summary>
        public bool Silence
        {
            get { return silence; }
            set
            {
                if (silence != value)
                {
                    silence = value;
                    if (silence)
                    {
                        volume = 0;
                        Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, volume * 100);
                    }
                    else
                    {
                        volume = oldVolume;
                        Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, volume * 100);
                    }
                    OnVolumeChanged(new MusicEventArgs(PlayState, volume, Schedule, false));
                }

            }
        }

        private MusicTags musicTags = new MusicTags();
        /// <summary>
        /// 歌曲信息
        /// </summary>
        public MusicTags TagsInfo
        {
            get { return musicTags; }
            set { musicTags = value; }
        }

        /// <summary>
        /// 音乐持续长度（秒）
        /// </summary>
        public double Length
        {
            get
            {
                return Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
            }
        }

        double schedule = 0;//播放进度
        /// <summary>
        /// 播放进度0—1
        /// </summary>
        public double Schedule
        {
            get
            {
                if (stream == 0 || Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream)) == -1)
                {
                    schedule = 0;
                }
                else
                {
                    schedule = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream)) / Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
                }
                return schedule;
            }
            set
            {
                schedule = value;
                double temp = schedule * Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, temp));
            }
        }

        private BASS_DX8_ECHO echo = new BASS_DX8_ECHO(90f, 50f, 500f, 500f, false);//初始化回音音效参数
        private int[] fxEQ = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//EQ参数
        /// <summary>
        /// EQ参数10段， 80、170、370、600、1k、3k、6k、12k、14k、15k
        /// </summary>
        public float[] MyEQ = new float[10];

        
        /// <summary>
        /// VST插件集合
        /// </summary>
        public List<VST> VSTs = new List<VST>();
        /// <summary>
        /// Bass插件和解码器集合
        /// </summary>
        public List<BassPlugin> BassPlugins = new List<BassPlugin>();

        bool musicFromFile = true;
        /// <summary>
        /// 歌曲文件是否来自本地文件，否则为网络流媒体
        /// </summary>
        public bool MusicFromFile
        {
            get { return musicFromFile; }
        }

        /// <summary>
        /// 音乐停止时候的回调
        /// </summary>
        SYNCPROC PlayEndSync;
        /// <summary>
        /// 音乐延迟时候的回调
        /// </summary>
        SYNCPROC StalledSync;

        /// <summary>
        /// 歌曲缓冲进度 0-1 （通过互联网加载的歌曲）
        /// </summary>
        public double LoadProgress
        {
            get
            {
                if (stream != 0)
                {
                    if (musicFromFile)
                    {
                        return 1;
                    }
                    else
                    {
                        double len = Bass.BASS_StreamGetFilePosition(stream, BASSStreamFilePosition.BASS_FILEPOS_END);
                        return (Bass.BASS_StreamGetFilePosition(stream, BASSStreamFilePosition.BASS_FILEPOS_DOWNLOAD)) / len;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="deviceId">输出设备ID</param>
        /// <param name="rate">输出采样率</param>
        /// <param name="bassInit">初始化模式</param>
        /// <param name="intPtr">窗体句柄</param>
        public MusicKernel(int deviceId, int rate, BASSInit bassInit, IntPtr intPtr)
        {
            BassNet.Registration("gozhushi@qq.com", "2X152429150022");//注册bass音频库
            string path = Environment.CurrentDirectory + "\\Codes\\";
            string[] allSound = new string[] { "aac", "ac3", "alac", "ape", "cd", "flac", "mpc", "tta", "wma", "wv" };
            for (int i = 0; i < allSound.Length; i++)
            {
                BassPlugin bp = new BassPlugin(path + "bass_" + allSound[i] + ".dll");
                BassPlugins.Add(bp);
            }
            if (!Bass.BASS_Init(deviceId, rate, bassInit, intPtr))
            {
                MessageBox.Show("bass初始化出错" + Bass.BASS_ErrorGetCode().ToString());
            }
            

            PlayEndSync = new SYNCPROC(PlayEnd);
            StalledSync = new SYNCPROC(Stalled);

            controlObject.CreateControl();
        }

        private bool disposed = false;

        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器） 
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) { return; }


            if (VSTs.Count > 0)//释放所有VST插件
            {
                for (int i = 0; i < VSTs.Count; i++)
                {
                    VSTs[i].Dispose();
                }
            }


            if (BassPlugins.Count > 0)
            {
                foreach (BassPlugin item in BassPlugins)
                {
                    item.Free();
                }
            }

            VST.Free();
            Bass.BASS_StreamFree(stream);
            Bass.BASS_Stop();    //停止
            Bass.BASS_Free();    //释放
            disposed = true;
        }

        ~MusicKernel()
        {
            Dispose(false);
        }

        /// <summary>
        /// 创建音频流
        /// </summary>
        internal bool CreateStream()
        {
            if (stream != 0)
            {
                if (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING || Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PAUSED)
                {
                    Bass.BASS_ChannelStop(stream);
                }

                Bass.BASS_StreamFree(stream);
            }
            if (musicFromFile)
            {
                if (!string.IsNullOrEmpty(fileName) && System.IO.File.Exists(fileName))
                {
                    stream = Bass.BASS_StreamCreateFile(fileName, 0L, 0L, BASSFlag.BASS_MUSIC_FLOAT);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    stream = Bass.BASS_StreamCreateURL(fileName, 0, BASSFlag.BASS_STREAM_STATUS, null, IntPtr.Zero);
                }
            }
            if (stream != 0)
            {
                InitializeEQ();//初始化EQ

                if (VSTs.Count > 0)//设置VST
                {
                    for (int i = 0; i < VSTs.Count; i++)
                    {
                        if (VSTs[i].IsActive)
                        {
                            VSTs[i].SetVSTChannel(stream);
                        }
                    }
                }

                //设置回调函数
                Bass.BASS_ChannelSetSync(stream, BASSSync.BASS_SYNC_END, 0, PlayEndSync, IntPtr.Zero);
                Bass.BASS_ChannelSetSync(stream, BASSSync.BASS_SYNC_STALL, 0, StalledSync, IntPtr.Zero);
                isNeedCreateStream = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 创建流，播放（异步）
        /// </summary>
        /// <param name="restart">是否重新播放</param>
        public void Play(bool restart)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(MusicPlay));
            thread.Start(restart);
        }
        /// <summary>
        /// 创建流，播放（异步）
        /// </summary>
        /// <param name="restart">是否重新播放</param>
        private void MusicPlay(object restart)
        {
            lock (this)
            {
                if (stream != 0 && !isNeedCreateStream)
                {
                    if ((bool)restart)
                    {
                        // 播放
                        Bass.BASS_ChannelPlay(stream, true);

                    }
                    else
                    {
                        Bass.BASS_ChannelPlay(stream, false);
                    }
                    OnStateChangedEvent(new MusicEventArgs(PlayState, Volume, Schedule, false));//触发状态改变事件
                }
                else
                {
                    if (CreateStream())
                    {
                        MusicPlay(true);
                    }
                }
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            if (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(stream);
                OnStateChangedEvent(new MusicEventArgs(PlayState, Volume, Schedule, false));
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (stream != 0 && PlayState != PlayStates.Stopped)
            {
                Bass.BASS_ChannelStop(stream);
                //Bass.BASS_StreamFree(stream);
                OnStateChangedEvent(new MusicEventArgs(PlayState, Volume, Schedule, true));
            }
        }

        /// <summary>
        /// 音乐停止之后的回调方法
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="channel"></param>
        /// <param name="data"></param>
        /// <param name="user"></param>
        private void PlayEnd(int handle, int channel, int data, IntPtr user)
        {
            OnStateChangedEvent(new MusicEventArgs(PlayStates.Stopped, Volume, Schedule, false));
        }

        /// <summary>
        /// 音乐延迟之后的回调方法
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="channel"></param>
        /// <param name="data"></param>
        /// <param name="user"></param>
        private void Stalled(int handle, int channel, int data, IntPtr user)
        {
            OnStateChangedEvent(new MusicEventArgs(PlayStates.Stalled, Volume, Schedule, false));
        }

        /// <summary>
        /// 获取当前歌曲播放进度的时间00:00格式
        /// </summary>
        /// <returns>00:00格式时间</returns>
        public string GetFormatTime()
        {
            return FormatMusicTime(MusicTime);
        }

        /// <summary>
        /// 格式化歌曲时间 00:00
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string FormatMusicTime(double time)
        {
            StringBuilder sb = new StringBuilder();
            int temp = (int)time / 60;
            if (time < 0)
            {
                time = 0;
            }
            sb.Remove(0, sb.Length);
            sb.AppendFormat("{0:00}", temp);
            sb.Append(':');
            sb.AppendFormat("{0:00}", time - temp * 60);
            return sb.ToString();
        }

        /// <summary>
        /// 播放状态改变事件
        /// </summary>
        public event EventHandler<MusicEventArgs> StateChanged;

        private PlayStates OldState = PlayStates.Stopped;
        PlayStates state;
        /// <summary>
        /// 当前播放状态
        /// </summary>
        public PlayStates PlayState
        {
            get
            {
                switch (Bass.BASS_ChannelIsActive(stream))
                {
                    case BASSActive.BASS_ACTIVE_PAUSED:
                        state = PlayStates.Pause;
                        break;
                    case BASSActive.BASS_ACTIVE_PLAYING:
                        state = PlayStates.Play;
                        break;
                    case BASSActive.BASS_ACTIVE_STALLED:
                        state = PlayStates.Stalled;
                        break;
                    case BASSActive.BASS_ACTIVE_STOPPED:
                        state = PlayStates.Stopped;
                        break;
                }
                return state;
            }
        }

        /// <summary>
        /// 用于将播放改变事件改成主线程调用方法
        /// </summary>
        Control controlObject = new Control();

        /// <summary>
        /// 触发事件
        /// </summary>
        protected virtual void OnStateChangedEvent(MusicEventArgs e)
        {
            if (StateChanged != null)
            {
                OldState = PlayState;
                //StateChanged(this, e);//执行事件
                controlObject.Invoke(StateChanged, this, e);
            }
        }

        /// <summary>
        /// 音量改变事件
        /// </summary>
        public event EventHandler<MusicEventArgs> VolumeChanged;
        /// <summary>
        /// 触发音量改变事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnVolumeChanged(MusicEventArgs e)
        {
            if (VolumeChanged != null)
            {
                VolumeChanged(this, e);
            }
        }

        /// <summary>
        ///初始化EQ
        /// </summary>
        private void InitializeEQ()
        {
            // 10段 EQ
            BASS_DX8_PARAMEQ eq = new BASS_DX8_PARAMEQ();
            fxEQ[0] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[1] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[2] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[3] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[4] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[5] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[6] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[7] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[8] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            fxEQ[9] = Bass.BASS_ChannelSetFX(stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);
            eq.fBandwidth = 18f;

            eq.fCenter = 80f;//80Hz
            eq.fGain = MyEQ[0];
            Bass.BASS_FXSetParameters(fxEQ[0], eq);
            eq.fCenter = 170f;//170Hz
            eq.fGain = MyEQ[1];
            Bass.BASS_FXSetParameters(fxEQ[1], eq);
            eq.fCenter = 370f;//370Hz
            eq.fGain = MyEQ[2];
            Bass.BASS_FXSetParameters(fxEQ[2], eq);
            eq.fCenter = 600f;//600Hz
            eq.fGain = MyEQ[3];
            Bass.BASS_FXSetParameters(fxEQ[3], eq);
            eq.fCenter = 1000f;//1000Hz
            eq.fGain = MyEQ[4];
            Bass.BASS_FXSetParameters(fxEQ[4], eq);
            eq.fCenter = 3000f;//3000Hz
            eq.fGain = MyEQ[5];
            Bass.BASS_FXSetParameters(fxEQ[5], eq);
            eq.fCenter = 6000f;//6000Hz
            eq.fGain = MyEQ[6];
            Bass.BASS_FXSetParameters(fxEQ[6], eq);
            eq.fCenter = 12000f;//12000Hz
            eq.fGain = MyEQ[7];
            Bass.BASS_FXSetParameters(fxEQ[7], eq);
            eq.fCenter = 14000f;//14000Hz
            eq.fGain = MyEQ[8];
            Bass.BASS_FXSetParameters(fxEQ[8], eq);
            eq.fCenter = 15000f;//15000Hz
            eq.fGain = MyEQ[9];
            Bass.BASS_FXSetParameters(fxEQ[9], eq);
        }

        /// <summary>
        /// 更新EQ，使EQ设置生效
        /// </summary>
        /// <returns></returns>
        public bool UpdateEQ()
        {
            BASS_DX8_PARAMEQ eq = new BASS_DX8_PARAMEQ();


            for (int i = 0; i < 10; i++)
            {
                if (Bass.BASS_FXGetParameters(fxEQ[i], eq))
                {
                    eq.fGain = MyEQ[i];
                    if (!Bass.BASS_FXSetParameters(fxEQ[i], eq))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        /// <summary>
        /// 获取FFT采样数据，返回512个浮点采样数据
        /// </summary>
        /// <returns></returns>
        public float[] GetFFTData()
        {
            float[] fft = new float[512];
            Bass.BASS_ChannelGetData(stream, fft, (int)BASSData.BASS_DATA_FFT1024);
            return fft;
        }

        /// <summary>
        /// 获取音频设备信息
        /// </summary>
        /// <returns></returns>
        public BASS_DEVICEINFO[] GetDeviceInfo()
        {
            return Bass.BASS_GetDeviceInfos();
        }

        /// <summary>
        /// 设置音频输出设备
        /// </summary>
        /// <param name="index">设备索引编号(默认是1)</param>
        /// <returns></returns>
        public bool SetDevice(int index)
        {
            return Bass.BASS_SetDevice(index);
        }

        /// <summary>
        /// 获取音乐文件持续时间 单位秒
        /// </summary>
        /// <param name="fileName">歌曲路径</param>
        /// <returns></returns>
        public static double GetMusicLength(string fileName)
        {
            int stream = Bass.BASS_StreamCreateFile(fileName, 0L, 0L, BASSFlag.BASS_MUSIC_NOSAMPLE);
            long len = Bass.BASS_ChannelGetLength(stream);
            double time = Bass.BASS_ChannelBytes2Seconds(stream, len);
            Bass.BASS_StreamFree(stream);
            return time;
        }

    }
    /// <summary>
    /// 播放状态枚举
    /// </summary>
    public enum PlayStates
    {
        /// <summary>
        /// 正在播放
        /// </summary>
        Play = BASSActive.BASS_ACTIVE_PLAYING,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause = BASSActive.BASS_ACTIVE_PAUSED,
        /// <summary>
        /// 停止
        /// </summary>
        Stopped = BASSActive.BASS_ACTIVE_STOPPED,
        /// <summary>
        /// 延迟
        /// </summary>
        Stalled = BASSActive.BASS_ACTIVE_STALLED,
    }


    /// <summary>
    /// 音乐内核事件数据类
    /// </summary>
    public class MusicEventArgs : EventArgs
    {
        bool isStopMethodToStop = false;
        /// <summary>
        /// 当播放状态为停止时，是否是因为调用Stop方法导致停止的，否则是播放结束后停止的
        /// </summary>
        public bool IsStopMethodToStop
        {
            get { return isStopMethodToStop; }
            set { isStopMethodToStop = value; }
        }

        PlayStates playState;
        /// <summary>
        /// 当前播放状态
        /// </summary>
        public PlayStates PlayState
        {
            get { return playState; }
        }

        int volume;
        /// <summary>
        /// 音量1-100
        /// </summary>
        public int Volume
        {
            get { return volume; }
        }

        double schedule;
        /// <summary>
        /// 播放进度0-1
        /// </summary>
        public double Schedule
        {
            get { return schedule; }
        }
        /// <summary>
        /// 初始化音乐数据类
        /// </summary>
        /// <param name="state">播放状态</param>
        /// <param name="volume">音量</param>
        /// <param name="schedule">播放进度</param>
        /// <param name="isStop">是否是执行STOP方法触发的，否则为播放结束后自动触发</param>
        public MusicEventArgs(PlayStates state, int volume, double schedule, bool isStop)
        {
            playState = state;
            this.volume = volume;
            this.schedule = schedule;
            isStopMethodToStop = isStop;
        }
    }

}
