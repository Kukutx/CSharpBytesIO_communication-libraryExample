using STTech.BytesIO.Core;
using STTech.BytesIO.Tcp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.SyncDemo
{
    public partial class DemoForm : Form
    {
        /// <summary>
        /// 同步消息Demo，连接服务器，按同步消息，如果在五秒内服务器没有回复报超时如果回复 BB01 报回复
        /// </summary>
        
        private BytesClient client = new TcpClient() { Port = 6000 };
        public DemoForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            client.OnConnectedSuccessfully += (s, e) => Print("连接成功");
            client.OnConnectionFailed += (s, e) => Print("连接失败");
            client.OnDisconnected += (s, e) => Print("断开连接");
            client.OnDataReceived += (s, e) => Print($"收到数据：{e.Data.ToHexString()}");
            client.OnDataSent += (s, e) => Print($"发送数据：{e.Data.ToHexString()}");
            client.Connect();
        }

        private void Print(string msg)
        {
            tbRecv.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }

        private void PrintTime()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffffff"));
        }

        private void tsmiTest_Click(object sender, EventArgs e)
        {
            PrintTime();

            var task = client.SendAsync(new byte[] { 0xAA, 0x01, 0xFF, 0xFF, 0xFF }, 5000, (sd, rd) => {  // 5000是定时五秒，超过五秒为超时
                return rd[0] == 0xBB && sd[1] == rd[1];
            });

            PrintTime();

            task.WaitResult((status, reply) => {
                if(status == TaskStatus.RanToCompletion)
                {
                    if (reply.Status == STTech.BytesIO.Core.ReplyStatus.Completed)
                    {
                        Print($"收到回复，内容是：{reply.GetBytes().ToHexString()}");
                    }
                    else
                    {
                        Print($"未收到回复，原因是：{reply.Status}");
                    }
                }
            });
            PrintTime();
        }
    }
}
