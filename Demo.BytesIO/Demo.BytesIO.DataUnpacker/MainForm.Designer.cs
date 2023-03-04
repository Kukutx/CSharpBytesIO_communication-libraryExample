namespace Demo.BytesIO.DataUnpacker
{
    partial class MainForm
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
            this.tbInput = new System.Windows.Forms.RichTextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbResult = new System.Windows.Forms.RichTextBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.timer = new System.Windows.Forms.Timer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Location = new System.Drawing.Point(12, 24);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(647, 82);
            this.tbInput.TabIndex = 5;
            this.tbInput.Text = "";
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Location = new System.Drawing.Point(584, 112);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 6;
            this.btnInput.Text = "传入";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "模拟数据(十六进制)：";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(12, 112);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 8;
            this.btnAuto.Text = "自动模拟";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbResult);
            this.groupBox1.Controls.Add(this.propertyGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 284);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实时数据显示";
            // 
            // tbResult
            // 
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.Location = new System.Drawing.Point(202, 17);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(442, 264);
            this.tbResult.TabIndex = 5;
            this.tbResult.Text = "";
            this.tbResult.WordWrap = false;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.propertyGrid.Location = new System.Drawing.Point(3, 17);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(199, 264);
            this.propertyGrid.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 437);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.tbInput);
            this.Name = "MainForm";
            this.Text = "协议解包器";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbInput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox tbResult;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Timer timer;
    }
}

