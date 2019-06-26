namespace Player
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.listSong = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labeltime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.lblLrc = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择歌词文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnadd = new System.Windows.Forms.PictureBox();
            this.btnnext = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.PictureBox();
            this.btn = new System.Windows.Forms.PictureBox();
            this.pmusicdown = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.sound = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pname = new System.Windows.Forms.Panel();
            this.labelname = new System.Windows.Forms.Label();
            this.titles = new System.Windows.Forms.Timer(this.components);
            this.titles2 = new System.Windows.Forms.Timer(this.components);
            this.sd = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnP = new System.Windows.Forms.PictureBox();
            this.sound1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnadd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnnext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).BeginInit();
            this.pmusicdown.SuspendLayout();
            this.pname.SuspendLayout();
            this.sd.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnP)).BeginInit();
            this.SuspendLayout();
            // 
            // axPlayer
            // 
            this.axPlayer.Enabled = true;
            this.axPlayer.Location = new System.Drawing.Point(462, 403);
            this.axPlayer.Name = "axPlayer";
            this.axPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer.OcxState")));
            this.axPlayer.Size = new System.Drawing.Size(10, 10);
            this.axPlayer.TabIndex = 0;
            // 
            // listSong
            // 
            this.listSong.BackColor = System.Drawing.Color.GhostWhite;
            this.listSong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSong.ContextMenuStrip = this.contextMenuStrip1;
            this.listSong.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listSong.ForeColor = System.Drawing.Color.White;
            this.listSong.FormattingEnabled = true;
            this.listSong.ItemHeight = 27;
            this.listSong.Location = new System.Drawing.Point(23, 457);
            this.listSong.Name = "listSong";
            this.listSong.Size = new System.Drawing.Size(554, 162);
            this.listSong.TabIndex = 5;
            this.listSong.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSong_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 56);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.clearToolStripMenuItem.Text = "清空";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labeltime
            // 
            this.labeltime.AutoSize = true;
            this.labeltime.BackColor = System.Drawing.Color.Transparent;
            this.labeltime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labeltime.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labeltime.Location = new System.Drawing.Point(12, 361);
            this.labeltime.Name = "labeltime";
            this.labeltime.Size = new System.Drawing.Size(52, 15);
            this.labeltime.TabIndex = 15;
            this.labeltime.Text = "00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(538, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "00:00";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(554, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 27);
            this.button1.TabIndex = 27;
            this.button1.Text = "X";
            this.toolTip1.SetToolTip(this.button1, "关闭");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(506, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 27);
            this.button2.TabIndex = 28;
            this.button2.Text = "__";
            this.toolTip1.SetToolTip(this.button2, "最小化");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // lblLrc
            // 
            this.lblLrc.BackColor = System.Drawing.Color.Transparent;
            this.lblLrc.ContextMenuStrip = this.contextMenuStrip2;
            this.lblLrc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLrc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLrc.Location = new System.Drawing.Point(151, 214);
            this.lblLrc.Name = "lblLrc";
            this.lblLrc.Size = new System.Drawing.Size(301, 24);
            this.lblLrc.TabIndex = 33;
            this.lblLrc.Text = "歌词";
            this.lblLrc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblLrc, "右键选择歌词文件");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择歌词文件ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(175, 30);
            // 
            // 选择歌词文件ToolStripMenuItem
            // 
            this.选择歌词文件ToolStripMenuItem.Name = "选择歌词文件ToolStripMenuItem";
            this.选择歌词文件ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.选择歌词文件ToolStripMenuItem.Text = "选择歌词文件";
            this.选择歌词文件ToolStripMenuItem.Click += new System.EventHandler(this.选择歌词文件ToolStripMenuItem_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Transparent;
            this.btnadd.Image = global::Player.Properties.Resources.list;
            this.btnadd.Location = new System.Drawing.Point(13, 282);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(61, 54);
            this.btnadd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnadd.TabIndex = 26;
            this.btnadd.TabStop = false;
            this.toolTip1.SetToolTip(this.btnadd, "添加歌曲");
            this.btnadd.Click += new System.EventHandler(this.button2_Click);
            this.btnadd.MouseLeave += new System.EventHandler(this.btnadd_MouseLeave);
            this.btnadd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnadd_MouseMove);
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.Transparent;
            this.btnnext.Image = global::Player.Properties.Resources.next;
            this.btnnext.Location = new System.Drawing.Point(405, 273);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(64, 73);
            this.btnnext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnnext.TabIndex = 24;
            this.btnnext.TabStop = false;
            this.toolTip1.SetToolTip(this.btnnext, "下一首");
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            this.btnnext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnnext_MouseDown);
            this.btnnext.MouseLeave += new System.EventHandler(this.btnnext_MouseLeave);
            this.btnnext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnnext_MouseMove);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Transparent;
            this.btnback.Image = global::Player.Properties.Resources.preview;
            this.btnback.Location = new System.Drawing.Point(134, 273);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(64, 73);
            this.btnback.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnback.TabIndex = 23;
            this.btnback.TabStop = false;
            this.toolTip1.SetToolTip(this.btnback, "上一首");
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            this.btnback.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnback_MouseDown);
            this.btnback.MouseLeave += new System.EventHandler(this.btnback_MouseLeave);
            this.btnback.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnback_MouseMove);
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.Transparent;
            this.btn.Image = global::Player.Properties.Resources.play;
            this.btn.Location = new System.Drawing.Point(255, 261);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(93, 96);
            this.btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn.TabIndex = 22;
            this.btn.TabStop = false;
            this.toolTip1.SetToolTip(this.btn, "播放/暂停");
            this.btn.Click += new System.EventHandler(this.btn_Click);
            this.btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // pmusicdown
            // 
            this.pmusicdown.BackColor = System.Drawing.Color.Silver;
            this.pmusicdown.Controls.Add(this.panel4);
            this.pmusicdown.Enabled = false;
            this.pmusicdown.Location = new System.Drawing.Point(81, 368);
            this.pmusicdown.Name = "pmusicdown";
            this.pmusicdown.Size = new System.Drawing.Size(440, 6);
            this.pmusicdown.TabIndex = 32;
            this.pmusicdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pmusicdown_MouseDown);
            this.pmusicdown.MouseEnter += new System.EventHandler(this.pmusicdown_MouseEnter);
            this.pmusicdown.MouseLeave += new System.EventHandler(this.pmusicdown_MouseLeave);
            this.pmusicdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pmusicdown_MouseMove);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 6);
            this.panel4.TabIndex = 33;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            this.panel4.MouseEnter += new System.EventHandler(this.panel4_MouseEnter);
            this.panel4.MouseLeave += new System.EventHandler(this.panel4_MouseLeave);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // sound
            // 
            this.sound.AutoSize = true;
            this.sound.BackColor = System.Drawing.Color.Transparent;
            this.sound.ForeColor = System.Drawing.SystemColors.Control;
            this.sound.Location = new System.Drawing.Point(417, 271);
            this.sound.Name = "sound";
            this.sound.Size = new System.Drawing.Size(55, 15);
            this.sound.TabIndex = 31;
            this.sound.Text = "label3";
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // pname
            // 
            this.pname.BackColor = System.Drawing.Color.Transparent;
            this.pname.Controls.Add(this.labelname);
            this.pname.Location = new System.Drawing.Point(213, 35);
            this.pname.Margin = new System.Windows.Forms.Padding(4);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(177, 36);
            this.pname.TabIndex = 34;
            // 
            // labelname
            // 
            this.labelname.AutoSize = true;
            this.labelname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelname.ForeColor = System.Drawing.Color.White;
            this.labelname.Location = new System.Drawing.Point(6, 0);
            this.labelname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelname.Name = "labelname";
            this.labelname.Size = new System.Drawing.Size(165, 27);
            this.labelname.TabIndex = 0;
            this.labelname.Text = "Welcome to use";
            // 
            // titles
            // 
            this.titles.Enabled = true;
            this.titles.Interval = 48;
            this.titles.Tick += new System.EventHandler(this.titles_Tick);
            // 
            // titles2
            // 
            this.titles2.Interval = 48;
            this.titles2.Tick += new System.EventHandler(this.titles2_Tick);
            // 
            // sd
            // 
            this.sd.BackColor = System.Drawing.Color.LightGray;
            this.sd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sd.BackgroundImage")));
            this.sd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sd.Controls.Add(this.panel1);
            this.sd.Location = new System.Drawing.Point(543, 120);
            this.sd.Name = "sd";
            this.sd.Size = new System.Drawing.Size(36, 161);
            this.sd.TabIndex = 35;
            this.sd.Visible = false;
            this.sd.MouseLeave += new System.EventHandler(this.sd_MouseLeave);
            this.sd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 120);
            this.panel1.TabIndex = 29;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 100);
            this.panel2.TabIndex = 30;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // btnP
            // 
            this.btnP.BackColor = System.Drawing.Color.Transparent;
            this.btnP.Image = ((System.Drawing.Image)(resources.GetObject("btnP.Image")));
            this.btnP.Location = new System.Drawing.Point(526, 282);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(61, 54);
            this.btnP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnP.TabIndex = 30;
            this.btnP.TabStop = false;
            this.btnP.Click += new System.EventHandler(this.btnP_Click);
            this.btnP.MouseLeave += new System.EventHandler(this.btnP_MouseLeave);
            this.btnP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // sound1
            // 
            this.sound1.AutoSize = true;
            this.sound1.BackColor = System.Drawing.Color.Transparent;
            this.sound1.ForeColor = System.Drawing.Color.Gray;
            this.sound1.Location = new System.Drawing.Point(532, 341);
            this.sound1.Name = "sound1";
            this.sound1.Size = new System.Drawing.Size(55, 15);
            this.sound1.TabIndex = 36;
            this.sound1.Text = "label1";
            this.sound1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sound1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::Player.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(602, 389);
            this.Controls.Add(this.sound1);
            this.Controls.Add(this.sd);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.lblLrc);
            this.Controls.Add(this.pmusicdown);
            this.Controls.Add(this.btnP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labeltime);
            this.Controls.Add(this.listSong);
            this.Controls.Add(this.axPlayer);
            this.Controls.Add(this.sound);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音乐播放器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnadd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnnext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).EndInit();
            this.pmusicdown.ResumeLayout(false);
            this.pname.ResumeLayout(false);
            this.pname.PerformLayout();
            this.sd.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axPlayer;
        private System.Windows.Forms.ListBox listSong;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labeltime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btn;
        private System.Windows.Forms.PictureBox btnback;
        private System.Windows.Forms.PictureBox btnnext;
        private System.Windows.Forms.PictureBox btnadd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnP;
        private System.Windows.Forms.Panel pmusicdown;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label sound;
        private System.Windows.Forms.Label lblLrc;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel pname;
        private System.Windows.Forms.Label labelname;
        private System.Windows.Forms.Timer titles;
        private System.Windows.Forms.Timer titles2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 选择歌词文件ToolStripMenuItem;
        private System.Windows.Forms.Panel sd;
        private System.Windows.Forms.Label sound1;
    }
}

