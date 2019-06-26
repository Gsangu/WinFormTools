namespace GetResource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.targetTxt = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerNumTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.targetBtn = new System.Windows.Forms.Button();
            this.startPageTxt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endPageTxt = new System.Windows.Forms.NumericUpDown();
            this.tagsTxt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxHeightTxt = new System.Windows.Forms.NumericUpDown();
            this.maxWidthTxt = new System.Windows.Forms.NumericUpDown();
            this.minHeightTxt = new System.Windows.Forms.NumericUpDown();
            this.minWidthTxt = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.isProxyCb = new System.Windows.Forms.CheckBox();
            this.isCreateCb = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startPageTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPageTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHeightTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWidthTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.startBtn.Location = new System.Drawing.Point(169, 391);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(195, 42);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Go!";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "下载路径";
            // 
            // targetTxt
            // 
            this.targetTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetTxt.Location = new System.Drawing.Point(137, 334);
            this.targetTxt.Name = "targetTxt";
            this.targetTxt.ReadOnly = true;
            this.targetTxt.Size = new System.Drawing.Size(296, 25);
            this.targetTxt.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLab,
            this.timerNumTxt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(532, 25);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLab
            // 
            this.statusLab.Name = "statusLab";
            this.statusLab.Size = new System.Drawing.Size(39, 20);
            this.statusLab.Text = "就绪";
            // 
            // timerNumTxt
            // 
            this.timerNumTxt.Name = "timerNumTxt";
            this.timerNumTxt.Size = new System.Drawing.Size(0, 20);
            // 
            // targetBtn
            // 
            this.targetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.targetBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.targetBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.targetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetBtn.Location = new System.Drawing.Point(432, 334);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(25, 25);
            this.targetBtn.TabIndex = 8;
            this.targetBtn.Text = "+";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.targetBtn_Click);
            // 
            // startPageTxt
            // 
            this.startPageTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startPageTxt.Location = new System.Drawing.Point(140, 32);
            this.startPageTxt.Name = "startPageTxt";
            this.startPageTxt.Size = new System.Drawing.Size(322, 25);
            this.startPageTxt.TabIndex = 10;
            this.startPageTxt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "开始页码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 30);
            this.label5.TabIndex = 13;
            this.label5.Text = "结束页码\r\n(0表示全部)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // endPageTxt
            // 
            this.endPageTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endPageTxt.Location = new System.Drawing.Point(139, 82);
            this.endPageTxt.Name = "endPageTxt";
            this.endPageTxt.Size = new System.Drawing.Size(323, 25);
            this.endPageTxt.TabIndex = 12;
            // 
            // tagsTxt
            // 
            this.tagsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsTxt.Location = new System.Drawing.Point(138, 128);
            this.tagsTxt.MaximumSize = new System.Drawing.Size(324, 128);
            this.tagsTxt.Name = "tagsTxt";
            this.tagsTxt.Size = new System.Drawing.Size(324, 128);
            this.tagsTxt.TabIndex = 14;
            this.tagsTxt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tags\r\n(多个换行)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maxHeightTxt
            // 
            this.maxHeightTxt.Location = new System.Drawing.Point(392, 286);
            this.maxHeightTxt.Name = "maxHeightTxt";
            this.maxHeightTxt.Size = new System.Drawing.Size(64, 25);
            this.maxHeightTxt.TabIndex = 19;
            // 
            // maxWidthTxt
            // 
            this.maxWidthTxt.Location = new System.Drawing.Point(316, 286);
            this.maxWidthTxt.Name = "maxWidthTxt";
            this.maxWidthTxt.Size = new System.Drawing.Size(63, 25);
            this.maxWidthTxt.TabIndex = 18;
            // 
            // minHeightTxt
            // 
            this.minHeightTxt.Location = new System.Drawing.Point(213, 286);
            this.minHeightTxt.Name = "minHeightTxt";
            this.minHeightTxt.Size = new System.Drawing.Size(64, 25);
            this.minHeightTxt.TabIndex = 21;
            // 
            // minWidthTxt
            // 
            this.minWidthTxt.Location = new System.Drawing.Point(137, 286);
            this.minWidthTxt.Name = "minWidthTxt";
            this.minWidthTxt.Size = new System.Drawing.Size(63, 25);
            this.minWidthTxt.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 30);
            this.label6.TabIndex = 23;
            this.label6.Text = "限制图片尺寸\r\n(0不限制,宽高)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // isProxyCb
            // 
            this.isProxyCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.isProxyCb.AutoSize = true;
            this.isProxyCb.Location = new System.Drawing.Point(380, 391);
            this.isProxyCb.Name = "isProxyCb";
            this.isProxyCb.Size = new System.Drawing.Size(120, 19);
            this.isProxyCb.TabIndex = 24;
            this.isProxyCb.Text = "开启代理(慢)";
            this.isProxyCb.UseVisualStyleBackColor = true;
            // 
            // isCreateCb
            // 
            this.isCreateCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.isCreateCb.AutoSize = true;
            this.isCreateCb.Checked = true;
            this.isCreateCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isCreateCb.Location = new System.Drawing.Point(380, 416);
            this.isCreateCb.Name = "isCreateCb";
            this.isCreateCb.Size = new System.Drawing.Size(128, 19);
            this.isCreateCb.TabIndex = 25;
            this.isCreateCb.Text = "Tag创建文件夹";
            this.isCreateCb.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(532, 478);
            this.Controls.Add(this.isCreateCb);
            this.Controls.Add(this.isProxyCb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minHeightTxt);
            this.Controls.Add(this.minWidthTxt);
            this.Controls.Add(this.maxHeightTxt);
            this.Controls.Add(this.maxWidthTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagsTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endPageTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startPageTxt);
            this.Controls.Add(this.targetBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.targetTxt);
            this.Controls.Add(this.startBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yandere下载器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startPageTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPageTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHeightTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWidthTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox targetTxt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLab;
        private System.Windows.Forms.Button targetBtn;
        private System.Windows.Forms.NumericUpDown startPageTxt;
        private System.Windows.Forms.ToolStripStatusLabel timerNumTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown endPageTxt;
        private System.Windows.Forms.RichTextBox tagsTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxHeightTxt;
        private System.Windows.Forms.NumericUpDown maxWidthTxt;
        private System.Windows.Forms.NumericUpDown minHeightTxt;
        private System.Windows.Forms.NumericUpDown minWidthTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox isProxyCb;
        private System.Windows.Forms.CheckBox isCreateCb;
    }
}

