namespace Demo.BytesIO.Server
{
    partial class ServerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.setting = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPort = new System.Windows.Forms.ToolStripTextBox();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStart,
            this.tsmiClose,
            this.setting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(519, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiStart
            // 
            this.tsmiStart.Name = "tsmiStart";
            this.tsmiStart.Size = new System.Drawing.Size(71, 20);
            this.tsmiStart.Text = "开始监听";
            this.tsmiStart.Click += new System.EventHandler(this.tsmiStart_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(71, 20);
            this.tsmiClose.Text = "停止监听";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // setting
            // 
            this.setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPort});
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(45, 20);
            this.setting.Text = "设置";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 23);
            this.tbPort.Text = "6000";
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 24);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(519, 260);
            this.tbLog.TabIndex = 1;
            this.tbLog.Text = "";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 284);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerForm";
            this.Text = "TCP/串口通讯服务端";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStart;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem setting;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.ToolStripTextBox tbPort;
    }
}

