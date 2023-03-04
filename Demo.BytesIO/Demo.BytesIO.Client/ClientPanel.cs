using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo.BytesIO.ChatProtocol;
using Newtonsoft.Json;
using STTech.BytesIO.Core;

namespace Demo.BytesIO.Client
{
    public partial class ClientPanel : UserControl
    {
        private BytesClient client;     // 串口通信

        private Dictionary<string, FileStream> dictFileStream = new Dictionary<string, FileStream>();
        private ClientPanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ClientPanel(BytesClient client) : this()
        {
            this.client = client;
            propertyGrid.SelectedObject = client;
            // 事件触发
            client.OnDataReceived += Client_OnDataReceived;
            client.OnConnectedSuccessfully += Client_OnConnectedSuccessfully;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnDataSent += Client_OnDataSent;
            client.OnExceptionOccurs += Client_OnExceptionOccurs;
        }

        private void Client_OnExceptionOccurs(object sender, ExceptionOccursEventArgs e)
        {
            Print($"发生了一个异常：{e.Exception.Message}");
        }

        private void Client_OnDataSent(object sender, DataSentEventArgs e)
        {
            ChatMessageResponse resp = new ChatMessageResponse(e.Data);
            if (resp.Type == ChatMessageType.Text) Print($"发送消息：{resp.Data.EncodeToString()}");
        }

        private void Client_OnDisconnected(object sender, DisconnectedEventArgs e)
        {
            Print($"已断开({e.ReasonCode})");
        }

        private void Client_OnConnectedSuccessfully(object sender, ConnectedSuccessfullyEventArgs e)
        {
            Print("连接成功");
        }

        private void Client_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            ChatMessageResponse resp = new ChatMessageResponse(e.Data);

            switch (resp.Type)
            {
                case ChatMessageType.Text:
                    Print($"收到消息：{resp.Data.EncodeToString()}");
                    break;
                case ChatMessageType.FileInfo:
                case ChatMessageType.FileContent:
                case ChatMessageType.FileEnd:
                    var fileName = resp.Args.EncodeToString();
                    var filePath = Path.Combine(tbSavePath.Text, fileName);

                    if (resp.Type == ChatMessageType.FileInfo)
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        Directory.CreateDirectory(tbSavePath.Text);
                        Print($"正在接收文件：{fileName}");

                        dictFileStream[filePath] = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                    }
                    else if (resp.Type == ChatMessageType.FileContent)
                    {
                        FileStream fileStream = dictFileStream[filePath];
                        lock (fileStream)
                        {
                            fileStream.Write(resp.Data, 0, resp.Data.Length);
                        }
                    }
                    else if (resp.Type == ChatMessageType.FileEnd)
                    {
                        FileStream fileStream = dictFileStream[filePath];
                        fileStream.Close();
                        fileStream.Dispose();

                        Process.Start("Explorer.exe", $"/select,{filePath}");
                        Print($"完成接收文件：{filePath}");
                    }
                    break;
                case ChatMessageType.Shake:
                    this.ParentForm.Shake();
                    Print("收到一个窗口抖动");
                    break;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect();
            btnSend.Enabled = true;
            btnSendShake.Enabled = true;
            btnSendFile.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            btnSend.Enabled = false;
            btnSendShake.Enabled = false;
            btnSendFile.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatMessageRequest message = new ChatMessageRequest()
            {
                Type = ChatMessageType.Text,
                Data = tbSend.Text.GetBytes(),
            };
            client.SendAsync(message.GetBytes());
        }

        private void Print(string msg)
        {
            tbRecv.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    Task.Run(() => SendFile(filePath));
                }
            }
        }
        /// <summary>
        /// 发送文件，解决大型文件问题
        /// </summary>
        /// <param name="filePath"></param>
        private void SendFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var fileSize = new FileInfo(filePath).Length;

            ChatMessageRequest req1 = new ChatMessageRequest()
            {
                Type = ChatMessageType.FileInfo,
                Args = fileName.GetBytes(),
            };
            client.SendAsync(req1.GetBytes());
            Print($"准备发送文件: {fileName}, 总大小: {fileSize}字节");

            int sentCount = 0;
            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[10000];
                int len = 0;
                while ((len = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Thread.Sleep(50);

                    ChatMessageRequest req2 = new ChatMessageRequest()
                    {
                        Type = ChatMessageType.FileContent,
                        Data = len == buffer.Length ? buffer : buffer.Take(len).ToArray(),
                        Args = fileName.GetBytes(),
                    };
                    client.SendAsync(req2.GetBytes());

                    sentCount += len;
                    tbProgressBar.Value = (int)(sentCount * 100.0 / fileSize);
                    tbProgressBarText.AppendText($"发送文件:{fileName} ({(int)(sentCount * 100.0 / fileSize)}%)");
                    Print($"发送文件:{fileName} ({(int)(sentCount * 100.0 / fileSize)}%)");
                }
            }
            // 延时避免粘包问题
            Thread.Sleep(50);
            // 优化收发过程
            ChatMessageRequest req3 = new ChatMessageRequest()
            {
                Type = ChatMessageType.FileEnd,
                Args = fileName.GetBytes(),
            };
            client.SendAsync(req3.GetBytes());

            Print($"文件发送完毕：{fileName}");
        }
        /// <summary>
        /// 发送窗口抖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendShake_Click(object sender, EventArgs e)
        {
            ChatMessageRequest message = new ChatMessageRequest()
            {
                Type = ChatMessageType.Shake,  //用文件属性的数据包
            };
            client.SendAsync(message.GetBytes());
            Print("发送一个窗口抖动");
        }
    }
}
