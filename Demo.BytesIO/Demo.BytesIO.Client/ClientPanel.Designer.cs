using System.Windows.Forms;

namespace Demo.BytesIO.Client
{
    partial class ClientPanel
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


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientPanel));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbRecv = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSend = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSendShake = new System.Windows.Forms.ToolStripButton();
            this.btnSendFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.SaveFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSavePath = new System.Windows.Forms.ToolStripTextBox();
            this.tbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tbProgressBarText = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertyGrid);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(249, 360);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接信息";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(3, 41);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(243, 317);
            this.propertyGrid.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(243, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(37, 22);
            this.btnConnect.Text = "连接";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(37, 22);
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbRecv);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(249, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(437, 360);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // tbRecv
            // 
            this.tbRecv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRecv.Location = new System.Drawing.Point(3, 16);
            this.tbRecv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRecv.Name = "tbRecv";
            this.tbRecv.ReadOnly = true;
            this.tbRecv.Size = new System.Drawing.Size(431, 226);
            this.tbRecv.TabIndex = 0;
            this.tbRecv.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbSend);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.toolStrip2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 242);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(431, 116);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输入区";
            // 
            // tbSend
            // 
            this.tbSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSend.Location = new System.Drawing.Point(3, 41);
            this.tbSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(353, 73);
            this.tbSend.TabIndex = 1;
            this.tbSend.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(356, 41);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(72, 73);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendShake,
            this.btnSendFile,
            this.toolStripDropDownButton1,
            this.tbProgressBar,
            this.tbProgressBarText});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(425, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSendShake
            // 
            this.btnSendShake.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSendShake.Enabled = false;
            this.btnSendShake.Image = ((System.Drawing.Image)(resources.GetObject("btnSendShake.Image")));
            this.btnSendShake.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendShake.Name = "btnSendShake";
            this.btnSendShake.Size = new System.Drawing.Size(63, 22);
            this.btnSendShake.Text = "窗口抖动";
            this.btnSendShake.Click += new System.EventHandler(this.btnSendShake_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSendFile.Enabled = false;
            this.btnSendFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSendFile.Image")));
            this.btnSendFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(63, 22);
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFilePath,
            this.tbSavePath});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(46, 22);
            this.toolStripDropDownButton1.Text = "设置";
            // 
            // SaveFilePath
            // 
            this.SaveFilePath.Enabled = false;
            this.SaveFilePath.Name = "SaveFilePath";
            this.SaveFilePath.Size = new System.Drawing.Size(240, 22);
            this.SaveFilePath.Text = "文件保存路径";
            // 
            // tbSavePath
            // 
            this.tbSavePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(180, 23);
            this.tbSavePath.Text = ".\\RecvFile";
            // 
            // tbProgressBar
            // 
            this.tbProgressBar.Name = "tbProgressBar";
            this.tbProgressBar.Size = new System.Drawing.Size(100, 22);
            // 
            // tbProgressBarText
            // 
            this.tbProgressBarText.Enabled = false;
            this.tbProgressBarText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbProgressBarText.Name = "tbProgressBarText";
            this.tbProgressBarText.Size = new System.Drawing.Size(100, 25);
            // 
            // ClientPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientPanel";
            this.Size = new System.Drawing.Size(686, 360);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private PropertyGrid propertyGrid;
        private ToolStrip toolStrip1;
        private ToolStripButton btnConnect;
        private ToolStripButton btnDisconnect;
        private GroupBox groupBox2;
        private RichTextBox tbRecv;
        private GroupBox groupBox3;
        private RichTextBox tbSend;
        private Button btnSend;
        private ToolStrip toolStrip2;
        private ToolStripButton btnSendFile;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem SaveFilePath;
        private ToolStripButton btnSendShake;
        private ToolStripTextBox tbSavePath;
        private ToolStripProgressBar tbProgressBar;
        private ToolStripTextBox tbProgressBarText;
    }
}

