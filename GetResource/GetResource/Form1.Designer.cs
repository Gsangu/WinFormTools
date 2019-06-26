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
            this.startBtn = new System.Windows.Forms.Button();
            this.urlTxt = new System.Windows.Forms.TextBox();
            this.matchTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.targetTxt = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerNumTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.targetBtn = new System.Windows.Forms.Button();
            this.isTimer = new System.Windows.Forms.CheckBox();
            this.timerTxt = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.startBtn.Location = new System.Drawing.Point(143, 227);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(128, 42);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Go!";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // urlTxt
            // 
            this.urlTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTxt.Location = new System.Drawing.Point(131, 27);
            this.urlTxt.Name = "urlTxt";
            this.urlTxt.Size = new System.Drawing.Size(205, 25);
            this.urlTxt.TabIndex = 1;
            // 
            // matchTxt
            // 
            this.matchTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchTxt.Location = new System.Drawing.Point(131, 77);
            this.matchTxt.Name = "matchTxt";
            this.matchTxt.Size = new System.Drawing.Size(205, 25);
            this.matchTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "地址/URL";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "匹配表达式";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 129);
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
            this.targetTxt.Location = new System.Drawing.Point(131, 126);
            this.targetTxt.Name = "targetTxt";
            this.targetTxt.ReadOnly = true;
            this.targetTxt.Size = new System.Drawing.Size(179, 25);
            this.targetTxt.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLab,
            this.timerNumTxt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 281);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(415, 25);
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
            this.targetBtn.Location = new System.Drawing.Point(309, 126);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(27, 26);
            this.targetBtn.TabIndex = 8;
            this.targetBtn.Text = "+";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.targetBtn_Click);
            // 
            // isTimer
            // 
            this.isTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.isTimer.AutoSize = true;
            this.isTimer.Location = new System.Drawing.Point(49, 180);
            this.isTimer.Name = "isTimer";
            this.isTimer.Size = new System.Drawing.Size(75, 19);
            this.isTimer.TabIndex = 9;
            this.isTimer.Text = "循环/s";
            this.isTimer.UseVisualStyleBackColor = true;
            // 
            // timerTxt
            // 
            this.timerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerTxt.Location = new System.Drawing.Point(131, 178);
            this.timerTxt.Name = "timerTxt";
            this.timerTxt.Size = new System.Drawing.Size(205, 25);
            this.timerTxt.TabIndex = 10;
            this.timerTxt.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 306);
            this.Controls.Add(this.timerTxt);
            this.Controls.Add(this.isTimer);
            this.Controls.Add(this.targetBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.targetTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matchTxt);
            this.Controls.Add(this.urlTxt);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "图片下载器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox urlTxt;
        private System.Windows.Forms.TextBox matchTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox targetTxt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLab;
        private System.Windows.Forms.Button targetBtn;
        private System.Windows.Forms.CheckBox isTimer;
        private System.Windows.Forms.NumericUpDown timerTxt;
        private System.Windows.Forms.ToolStripStatusLabel timerNumTxt;
    }
}

