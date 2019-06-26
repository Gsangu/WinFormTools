using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Un4seen.Bass.AddOn.Vst;
using Un4seen.Bass;

namespace GsanPlayer
{
    /// <summary>
    /// VST插件
    /// </summary>
    public class VST : Form
    {
        /// <summary>
        /// VST句柄
        /// </summary>
        int vstHandle = 0;

        private string fileName = String.Empty;
        /// <summary>
        /// VST插件路径
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        int stream;
        /// <summary>
        /// 音频流句柄
        /// </summary>
        public int Stream
        {
            get { return stream; }
            set { stream = value; }
        }

        BASS_VST_INFO vstInfo = new BASS_VST_INFO();
        /// <summary>
        /// VST插件相关信息
        /// </summary>
        public BASS_VST_INFO VSTInfo
        {
            get { return vstInfo; }
            set { vstInfo = value; }
        }

        bool isActive = false;
        /// <summary>
        /// 是否处于激活状态
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        private VSTPROC myVstProc;
        /// <summary>
        /// 用于显示和设置参数的VST
        /// </summary>
        int vstDummy;


        // VST插件回调方法
        private int VSTEditorCallback(int vstDummy, BASSVSTAction action, int param1, int param2, IntPtr user)
        {
            if (action == BASSVSTAction.BASS_VST_PARAM_CHANGED)
            {
                // the user has changed some slider in the unchanneled editor 
                // copy the changes to the 'real' channels
                BassVst.BASS_VST_SetParamCopyParams(vstDummy, vstHandle);
            }
            return 0;
        }

        /// <summary>
        /// 初始化VST
        /// </summary>
        /// <param name="fileName">VST插件完整路径</param>
        public VST(string fileName)
        {
            this.fileName = fileName;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Icon = global::LYPlayer.Properties.Resources.项目1;
        }

        /// <summary>
        /// 设置VST信道,启动VST插件
        /// </summary>
        /// <param name="stream">音频流句柄</param>
        public void StartVST(int stream)
        {
            this.stream = stream;
            //先释放原来的VST
            BassVst.BASS_VST_ChannelFree(vstHandle);
            BassVst.BASS_VST_ChannelFree(vstDummy);


            vstHandle = BassVst.BASS_VST_ChannelSetDSP(stream, fileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            vstDummy = BassVst.BASS_VST_ChannelSetDSP(0, fileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);

            //设置回调函数
            myVstProc = new VSTPROC(VSTEditorCallback);
            BassVst.BASS_VST_SetCallback(vstDummy, myVstProc, IntPtr.Zero);

            BassVst.BASS_VST_GetInfo(vstDummy, vstInfo);
            Text = vstInfo.effectName;
            isActive = true;


            BassVst.BASS_VST_EmbedEditor(vstDummy, this.Handle);
            Width = vstInfo.editorWidth + 10;
            Height = vstInfo.editorHeight + 35;
        }

        /// <summary>
        /// 设置VST信道
        /// </summary>
        /// <param name="stream">音频流句柄</param>
        public void SetVSTChannel(int stream)
        {
            this.stream = stream;
            BassVst.BASS_VST_ChannelFree(vstHandle);
            vstHandle = BassVst.BASS_VST_ChannelSetDSP(stream, fileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            VSTEditorCallback(vstDummy, BASSVSTAction.BASS_VST_PARAM_CHANGED, 0, 0, IntPtr.Zero);
        }

        /// <summary>
        /// 关闭VST插件
        /// </summary>
        public void RemoveVSTChannel()
        {
            BassVst.BASS_VST_ChannelRemoveDSP(stream, vstHandle);
            isActive = false;
            Hide();
            BassVst.BASS_VST_ChannelFree(vstHandle);
            BassVst.BASS_VST_ChannelFree(vstDummy);
        }

        /// <summary>
        /// （如果有）显示VST插件界面
        /// </summary>
        public new void Show()
        {
            if (vstInfo.hasEditor)
            {
                base.Show();
            }
        }

        /// <summary>
        /// 触发FormClosing事件
        /// </summary>
        /// <param name="e">事件数据</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.OnFormClosing(e);
            Hide();
        }

        /// <summary>
        /// 触发DestroyHandle事件
        /// </summary>
        protected override void DestroyHandle()
        {
            BassVst.BASS_VST_ChannelRemoveDSP(stream, vstHandle);
            BassVst.BASS_VST_ChannelFree(vstHandle);
            BassVst.BASS_VST_ChannelFree(vstDummy);
            base.DestroyHandle();
        }

        /// <summary>
        /// 释放VST支持模块
        /// </summary>
        public static void Free()
        {
            BassVst.FreeMe();
        }
    }
}
