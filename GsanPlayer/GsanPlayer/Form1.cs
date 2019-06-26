using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Un4seen.Bass;

namespace GsanPlayer
{
    public partial class Form1 : CCSkinMain
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<MusicList> Locallist = new List<MusicList>();
        int playIndex;
        int playTurn = 0;//播放顺序
        int playSound = 4;//声音状态
        #region 初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            kl = new KtvLrc();
            kl.Show();
            Application.DoEvents();
            kl.Visible = false;
            Music.Volume = 50;
            comboBox1.SelectedIndex = 0;
            ChangePic(btnSound, Properties.Resources.btnSound, playSound);
            InitAll();
        }

        void InitAll()
        {
            btnPlay.NormlBack = Properties.Resources.btnPlay;
            labelname.Text = "Wecome to use";
            labelname2.Text = "Wecome to use";
            labelname.Location = new Point(0, 0);
            labelname2.Location= new Point(pname.Width + labelname.Width/y, 0);
            kl.DrawSongWords("传播好音乐");
            runningTime.Text = "00:00";
            duration.Text = "00:00";
            HeadImg.Image = null;
            PlayingTime.Enabled = false;
            tbTime.Value = 0;
            
            LrcTime.Enabled = false;
        }
        #endregion
        #region 歌名移动变换
        //int lefti=0;//设置移动次数
        int y = 8;//移动因子
        private void titles_Tick(object sender, EventArgs e)
        {
            if (labelname.Location.X >= -labelname.Width/y)
            {
                if(labelname2.Location.X >= -labelname2.Width)
                {
                    int x2 = labelname2.Location.X - 1;
                    labelname2.Location = new Point(x2, 0);
                }
                else
                {
                    labelname2.Location = new Point(pname.Width + labelname.Width, 0);
                }
                int x = labelname.Location.X - 1;
                labelname.Location = new Point(x, 0);
            }
            else
            {
                titles.Enabled = false;
                titles2.Enabled = true;
            }
        }//第一个label移动
        private void titles2_Tick(object sender, EventArgs e)
        {
            if (labelname2.Location.X >= -labelname2.Width/y)
            {
                if (labelname.Location.X >= -labelname.Width)
                {
                    int x2 = labelname.Location.X - 1;
                    labelname.Location = new Point(x2, 0);
                }
                else
                {
                    labelname.Location = new Point(pname.Width + labelname.Width, 0);
                }
                int x = labelname2.Location.X - 1;
                labelname2.Location = new Point(x, 0);
            }
            else
            {
                titles2.Enabled = false;
                titles.Enabled = true;
            }
        }//第二个label移动
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有支持文件|*.flac;*.ape;*.mp3;*.ogg;*.wav;*.m4a;*.aac;*.fla";
            ofd.Title = "请选择文件";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                thread = new Thread(new ParameterizedThreadStart(CrossThreadAddFile));
                thread.IsBackground = true;
                thread.Start(ofd.FileNames);
            }
        }
        List<double> lrcTime = new List<double>();
        List<string> lrcList = new List<string>();
         void PlayMusic(int index)
        {
            if (Locallist.Count < 1 || index > Locallist.Count) return;
            playIndex = index;
            MusicList ml = Locallist[playIndex];
            Music.FileName = ml.url;
            Music.Play(true);
            Dictionary<double, string> lrc = Lyric.ReadLrc(Music.TagsInfo.Title, Music.TagsInfo.Artist, false);
            if (lrc != null && lrc.Count != 0)
            {
                foreach (double key in lrc.Keys)
                {
                    lrcTime.Add(key);
                }
                foreach (string s in lrc.Values)
                {
                    lrcList.Add(s);
                }
                kl.DrawSongWords("已加载歌词");
            }
            else
            {
                kl.DrawSongWords("未找到歌词...");
            }
            labelname.Text = labelname2.Text = ml.fullName;
            labelname.Location = new Point(0, 0);
            labelname2.Location = new Point(pname.Width + labelname.Width / y, 0);
            HeadImg.Image = ml.imgUrl;
            PlayingTime.Enabled = true;
            LrcTime.Enabled = true;
            tbTime.Enabled = true;
            btnPlay.Enabled = true;
            btnNext.Enabled = true;
            btnPrex.Enabled = true;
            btnPlay.NormlBack = Properties.Resources.btnPause;
            btnPlay.MouseBack = Properties.Resources.ptnPause_hover;
        }
        private void skinDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PlayMusic(e.RowIndex);
        }

        MusicKernel Music = new MusicKernel(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, IntPtr.Zero);
        private void AddFolder(object filePath)
        {
            DirectoryInfo dir = new DirectoryInfo(filePath.ToString());
            string[] type = ("*.flac;*.ape;*.mp3;*.ogg;*.wav;*.m4a;*.aac;*.fla").Split(';');
            for (int i = 0; i < type.Length; i++)
            {
                FileInfo[] files = dir.GetFiles(type[i]);
                foreach (FileInfo s in files)
                {
                    Music.FileName = s.FullName;
                    if (!EqualsRe(s.FullName))
                    {
                        string path = s.FullName;
                        int start = path.LastIndexOf('\\') + 1;
                        string fileName = path.Substring(start, path.Length - start);
                        Locallist.Add(new MusicList(s.FullName, Music.TagsInfo.AlbumArt, fileName));
                        string info = Music.TagsInfo.ToString();
                        AddItem(info);
                    }
                }
            }
        }
        bool EqualsRe(string fullName)
        {
            int sum = 0;
            foreach (MusicList paths in Locallist)
                if (paths.url == fullName)
                    sum++;
            if (sum > 0) return true;
            else return false;
        }
        private delegate void FlushClient(object html); //代理
        Thread thread = null;
        public void AddItem(object infos)
        {
            if (this.LocalMusic.InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(AddItem);
                this.Invoke(fc, new object[1] { infos }); //通过代理调用刷新方法
            }
            else
            {
                string[] info = infos.ToString().Split('，');
                DataGridViewRow row = new DataGridViewRow();
                for (int i = 0; i < info.Length; i++)
                {
                    DataGridViewTextBoxCell txt = new DataGridViewTextBoxCell();
                    txt.Value = info[i];
                    row.Cells.Add(txt);
                }
                LocalMusic.Rows.Add(row);
            }
        }
        private void CrossThreadAddFile(object file)
        {
            string[] files = (string[])file;
            for (int i = 0; i < files.Length; i++)
            {
                string path = files[i];
                Music.FileName = path;
                if (!EqualsRe(path))
                {
                    int start = path.LastIndexOf('\\') + 1;
                    string fileName = path.Substring(start, path.Length - start);
                    Locallist.Add(new MusicList(path, Music.TagsInfo.AlbumArt, fileName));
                    string info = Music.TagsInfo.ToString();
                    AddItem(info);
                }
            }

        }
        private void CrossThreadAddFolder(object path)
        {
            AddFolder(path);
        }
        private void AddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                thread = new Thread(new ParameterizedThreadStart(CrossThreadAddFolder));
                thread.IsBackground = true;
                thread.Start(ofd.SelectedPath);
            }
        }
        #region 歌词显示
        public KtvLrc kl;
        public bool pbLrcflag = false;
        private void txtLrc_Click(object sender, EventArgs e)
        {
            pbLrcflag = !pbLrcflag;
            if (pbLrcflag)
            {
                kl.fadeTimer.Start();
                kl.Visible = true;
            }
            else
            {
                kl.fadeTimer.Start();
                kl.Visible = false;
            }
        }
        /// <summary>
        /// 歌词
        /// </summary>
        string lrc = string.Empty;
        string testBelow = string.Empty;
        private void LrcTime_Tick(object sender, EventArgs e)
        {
            runningTime.Text = Music.GetFormatTime();
            duration.Text = Music.TagsInfo.Duration;
            double currentTime = Music.MusicTime;
            if (Music.MusicTime >= Music.Length)
            {
                ChangePlay(playIndex, false);
            }
            try
            {
                double time = Music.MusicTime;
                int s = (int)time % 60;
                int mi = (int)time / 60;
                int hm = (int)time;
                
                int lrclength = 0;
                string st = GetTxt(time);
                if (st != null)
                {
                    if (!testBelow.Equals(st))
                    {
                        kl.width = 0;
                    }
                    testBelow = st;

                    lrc = st;
                    lrclength = lrc.Length;
                    string lrc2 = null;

                    int ad = s;
                    int ap = 0;
                    for (int i = 1; i <= 15; i++)
                    {
                        lrc2 = GetTxt(time + 1);
                        if (lrc2 != null)
                        {
                            ap = s + i;
                            break;
                        }
                    }
                    int width = 0;
                    if (lrclength != 0)
                    {
                        if (ap < ad)
                        {
                            ap = 60 + ap;
                        }
                        string adcName = lrc;
                        int dp = ap - ad; //第一句歌词和下一句歌词的差值
                        int size = 50; //歌词大小   
                        int sumWidth = lrclength * size; //显示歌词的长度
                        width = sumWidth / dp / 10; //每豪秒增加的width
                        if (width != 0)
                        {
                            kl.add = width;
                        }


                    }
                    kl.DrawSongWords(lrc);
                }

            }
            catch
            {
                
            }
        }
        string GetTxt(double time)
        {
            for (int i = 0; i < lrcTime.Count - 1; i++)
            {
                if (time >= lrcTime[i] && time < lrcTime[i + 1])
                {
                    return (lrcList[i]);
                }
            }
            return null;
        }
        #endregion
        private void PlayingTime_Tick(object sender, EventArgs e)
        {
            tbTime.Value= Music.Schedule;
        }
        
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(Music.PlayState == PlayStates.Play)
            {
                Music.Pause();
                btnPlay.NormlBack = Properties.Resources.btnPlay;
                btnPlay.MouseBack = Properties.Resources.btnPlay_hover;
            }
            else if(Music.PlayState==PlayStates.Pause)
            {
                Music.Play(false); ;
                btnPlay.NormlBack = Properties.Resources.btnPause;
                btnPlay.MouseBack = Properties.Resources.ptnPause_hover;
            }
        }
        public void ChangePlay(int i,bool p)//是否是人为改变
        {
            int PlaySum = LocalMusic.Rows.Count;
            switch (playTurn)
            {
                case 0://单曲播放
                case 2://顺序播放
                    if(p || playTurn==2) playIndex += i;//
                    if ((playIndex >= PlaySum || playTurn == 0) && !p)
                    {
                        Music.Stop();
                        InitAll();
                        return;
                    }
                    else if (playIndex >= PlaySum)
                    {
                        playIndex = 0;
                    }
                    else if (playIndex < 0)
                        playIndex = PlaySum - 1;
                    break;
                case 1://单曲循环
                case 3://列表循环
                    if (playTurn != 1 || p) playIndex += i;
                    if (playIndex >= PlaySum)
                        playIndex = 0;
                    else if (playIndex < 0)
                        playIndex = PlaySum - 1;
                    break;
                case 4: playIndex = new Random().Next(0, PlaySum); break;
            }
            PlayMusic(playIndex);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangePlay(1,true);
        }

        private void btnPrex_Click(object sender, EventArgs e)
        {
            ChangePlay(-1,true);
        }
        

        private void tbTime_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            Music.Schedule = tbTime.Value;
        }

        private void tbTime_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            PlayingTime.Enabled = false;
        }

        private void tbTime_MouseUp(object sender, MouseEventArgs e)
        {
            Music.Schedule = tbTime.Value;
            PlayingTime.Enabled = true;
        }

        private void skinPictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, Properties.Resources.changeTurn_hover, playTurn + 1);
        }

        private void skinPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, Properties.Resources.changeTurn, playTurn + 1);
        }
        void ChangePic(PictureBox pic, Image img, int status)
        {
            pic.Image = ImageHelper.GetImageByAverageIndex(img, 5, status);
        }
        string[] playTurnString = new string[] { "单曲播放", "单曲循环","顺序播放","列表循环","随机播放" };
        private void skinPictureBox1_Click(object sender, EventArgs e)
        {
            playTurn++;
            if (playTurn > 4) playTurn = 0;
            skinToolTip1.SetToolTip(skinPictureBox1, playTurnString[playTurn]);
            ChangePic((PictureBox)sender,Properties.Resources.changeTurn_hover, playTurn + 1);
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            Music.Silence = !Music.Silence;
            if (Music.Silence)
            {
                playSound = 5;
                ChangePic((PictureBox)sender, Properties.Resources.btnSound_hover, playSound);
            }
            else
            {
                SetBtnSound(Music.Volume);
            }
        }
        void SetBtnSound(int value)
        {
            if (value >= 40)
                playSound = 4;
            else if (value > 10)
                playSound = 2;
            else if(value > 0)
                playSound = 1;
            else
                playSound = 5;
            ChangePic(btnSound, Properties.Resources.btnSound, playSound);
        }
        private void btnSound_MouseEnter(object sender, EventArgs e)
        {
            plSound.Visible = true;
            ChangePic((PictureBox)sender, Properties.Resources.btnSound_hover, playSound);
        }

        private void btnSound_MouseLeave(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, Properties.Resources.btnSound, playSound);
        }
        

        private void plSound_MouseLeave(object sender, EventArgs e)
        {
            plSound.Visible = false;
        }

        private void plSound_MouseMove(object sender, MouseEventArgs e)
        {
            plSound.Visible = true;
        }

        private void layeredTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            Music.Volume = (int)(layeredTrackBar1.Value * 100);
            SetBtnSound(Music.Volume);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection drc = LocalMusic.SelectedRows;
            for (int i = 0; i < drc.Count; i++)
            {
                if (playIndex == drc[i].Index)
                {
                    Music.Stop(); InitAll();
                }
                Locallist.RemoveAt(drc[i].Index);
                LocalMusic.Rows.RemoveAt(drc[i].Index);
            }
            
        
        }
        private void skinComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //获取要在其上绘制项的图形表面
            Graphics g = e.Graphics;
            //获取表示所绘制项的边界的矩形
            Rectangle rect = e.Bounds;
            //定义要绘制到控件中的图标图像
            Image ico = null;
            //定义字体对象
            Font font = new Font(new FontFamily("宋体"), 9F);
            if (e.Index >= 0)
            {
                switch (e.Index)
                {
                    case 0:
                        ico = ImageHelper.MakeThumbnail(Properties.Resources.wangyi, 15, 15, "HW"); break;
                    case 1:
                        ico = ImageHelper.MakeThumbnail(Properties.Resources.kugou, 15, 15, "HW"); break;
                    case 2:
                        ico = ImageHelper.MakeThumbnail(Properties.Resources.baidu, 15, 15, "HW"); break;
                }
                //获得当前Item的文本
                string tempString = comboBox1.Items[e.Index].ToString();
                //在当前项图形表面上划一个矩形
                g.FillRectangle(new SolidBrush(Color.FromArgb(10, 250, 250, 250)), rect);
                //在当前项图形表面上划上图标
                g.DrawImage(ico, new Point(rect.Left, rect.Top));
                //在当前项图形表面上划上当前Item的文本
                g.DrawString(tempString, font, new SolidBrush(Color.FromArgb(64, 64, 64)), rect.Left + ico.Size.Width, rect.Top);
                //将绘制聚焦框
                
                e.DrawFocusRectangle();
            }
        }

        private void skinComboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
        }

        private void LocalMusic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PlayMusic(LocalMusic.SelectedRows[0].Index);
            }
        }
        
        private void layeredTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void CrossThreadAddImgItem()
        {
            AddImgItem("");
        }
        private void AddImgItem(object img)
        {

        }

        private void skinHotKey1_HotKeyTrigger(object sender, CCWin.SkinControl.HotKeyEventArgs e)
        {
            btnPlay_Click(null, null);
        }
    }
}
