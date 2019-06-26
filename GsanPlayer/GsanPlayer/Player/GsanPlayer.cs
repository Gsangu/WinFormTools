using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;

namespace GsanPlayer
{
    class GsanPlayer
    {
        private MusicKernel music = new MusicKernel(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, IntPtr.Zero);
        public MusicKernel Music { get => music; set => music = value; }


        private List<MusicList> playList = new List<MusicList>();
        /// <summary>
        /// 播放列表
        /// </summary>
        public List<MusicList> PlayList
        {
            get => playList; set
            {
                playList = value;
            }
        }

        private int playIndex = 0;
        /// <summary>
        /// 播放索引
        /// </summary>
        public int PlayIndex
        {
            get => playIndex;
            set
            {
                playIndex = value;
                MusicList ml = playList[playIndex];
                Music.FileName = ml.url;
                Music.Play(true);
            }
        }

        

        private PlayStates playStatus = PlayStates.Stopped;
        /// <summary>
        /// 播放状态
        /// </summary>
        public PlayStates PlayStatus { get => playStatus; set => playStatus = value; }

        private int playTurn = 0;
        /// <summary>
        /// 播放顺序
        /// </summary>
        public int PlayTurn { get => playTurn; set => playTurn = value; }

        private int soundStatus;
        /// <summary>
        /// 播放声音状态
        /// </summary>
        public int SoundStatus { get => soundStatus; set => soundStatus = value; }
    }
}
