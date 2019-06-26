namespace BT蚂蚁种子搜索
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制磁力链接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制迅雷链接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.page = new System.Windows.Forms.Label();
            this.Results = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.ESCBtn = new System.Windows.Forms.Button();
            this.searchbtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(36, 65);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(469, 36);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制磁力链接ToolStripMenuItem,
            this.复制迅雷链接ToolStripMenuItem,
            this.详细信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 82);
            // 
            // 复制磁力链接ToolStripMenuItem
            // 
            this.复制磁力链接ToolStripMenuItem.Name = "复制磁力链接ToolStripMenuItem";
            this.复制磁力链接ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.复制磁力链接ToolStripMenuItem.Text = "复制磁力链接";
            this.复制磁力链接ToolStripMenuItem.Click += new System.EventHandler(this.复制磁力链接ToolStripMenuItem_Click);
            // 
            // 复制迅雷链接ToolStripMenuItem
            // 
            this.复制迅雷链接ToolStripMenuItem.Name = "复制迅雷链接ToolStripMenuItem";
            this.复制迅雷链接ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.复制迅雷链接ToolStripMenuItem.Text = "复制迅雷链接";
            this.复制迅雷链接ToolStripMenuItem.Click += new System.EventHandler(this.复制迅雷链接ToolStripMenuItem_Click);
            // 
            // 详细信息ToolStripMenuItem
            // 
            this.详细信息ToolStripMenuItem.Name = "详细信息ToolStripMenuItem";
            this.详细信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.详细信息ToolStripMenuItem.Text = "详细信息";
            this.详细信息ToolStripMenuItem.Click += new System.EventHandler(this.详细信息ToolStripMenuItem_Click);
            // 
            // lastPage
            // 
            this.lastPage.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lastPage.FlatAppearance.BorderSize = 0;
            this.lastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastPage.ForeColor = System.Drawing.Color.White;
            this.lastPage.Location = new System.Drawing.Point(520, 604);
            this.lastPage.Name = "lastPage";
            this.lastPage.Size = new System.Drawing.Size(75, 32);
            this.lastPage.TabIndex = 5;
            this.lastPage.Text = "上一页";
            this.lastPage.UseVisualStyleBackColor = false;
            this.lastPage.Click += new System.EventHandler(this.lastPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.nextPage.FlatAppearance.BorderSize = 0;
            this.nextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPage.ForeColor = System.Drawing.Color.White;
            this.nextPage.Location = new System.Drawing.Point(678, 604);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(75, 32);
            this.nextPage.TabIndex = 6;
            this.nextPage.Text = "下一页";
            this.nextPage.UseVisualStyleBackColor = false;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // page
            // 
            this.page.AutoSize = true;
            this.page.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.page.Location = new System.Drawing.Point(23, 614);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(82, 15);
            this.page.TabIndex = 7;
            this.page.Text = "未进行搜索";
            // 
            // Results
            // 
            this.Results.ContextMenuStrip = this.contextMenuStrip1;
            this.Results.FullRowSelect = true;
            this.Results.Location = new System.Drawing.Point(25, 143);
            this.Results.MultiSelect = false;
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(750, 437);
            this.Results.TabIndex = 8;
            this.Results.UseCompatibleStateImageBehavior = false;
            this.Results.View = System.Windows.Forms.View.Details;
            this.Results.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Results_ColumnClick);
            this.Results.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.Results_ColumnWidthChanging);
            this.Results.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.Results_ItemMouseHover);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(606, 604);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ESCBtn
            // 
            this.ESCBtn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ESCBtn.FlatAppearance.BorderSize = 0;
            this.ESCBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ESCBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ESCBtn.ForeColor = System.Drawing.Color.White;
            this.ESCBtn.Location = new System.Drawing.Point(767, -5);
            this.ESCBtn.Name = "ESCBtn";
            this.ESCBtn.Size = new System.Drawing.Size(35, 35);
            this.ESCBtn.TabIndex = 11;
            this.ESCBtn.Text = "×";
            this.ESCBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ESCBtn.UseVisualStyleBackColor = false;
            this.ESCBtn.Click += new System.EventHandler(this.ESCBtn_Click);
            // 
            // searchbtn
            // 
            this.searchbtn.Image = global::BT蚂蚁种子搜索.Properties.Resources.search;
            this.searchbtn.Location = new System.Drawing.Point(522, 63);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(40, 40);
            this.searchbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchbtn.TabIndex = 12;
            this.searchbtn.TabStop = false;
            this.searchbtn.Click += new System.EventHandler(this.button1_Click);
            this.searchbtn.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.searchbtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BT蚂蚁种子搜索.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(582, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(-4, -6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(805, 38);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "BT种子搜索器——by Gsan.";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(124, 113);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 19);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "收录时间";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "排序方式：";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(224, 113);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 19);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.Text = "活跃热度";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(424, 113);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 19);
            this.radioButton3.TabIndex = 19;
            this.radioButton3.Text = "文件大小";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(324, 113);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(88, 19);
            this.radioButton4.TabIndex = 18;
            this.radioButton4.Text = "最后活跃";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 655);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.ESCBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.page);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.lastPage);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BT种子搜索";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button lastPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Label page;
        private System.Windows.Forms.ListView Results;
        private System.Windows.Forms.ToolStripMenuItem 复制磁力链接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制迅雷链接ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ESCBtn;
        private System.Windows.Forms.PictureBox searchbtn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ToolStripMenuItem 详细信息ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

