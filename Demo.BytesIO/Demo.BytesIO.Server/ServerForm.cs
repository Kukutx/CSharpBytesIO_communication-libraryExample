using STTech.BytesIO.Tcp;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Demo.BytesIO.Server
{
    public partial class ServerForm : Form
    {
        private TcpServer server;
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            server = new TcpServer();
            server.Port = int.Parse(tbPort.Text);

            server.Started += Server_Started;
            server.Closed += Server_Closed;
            server.ClientConnected += Server_ClientConnected;
            // 限制客户端登入人数
            server.ClientDisconnected += Server_ClientDisconnected;
            server.ClientConnectionAcceptedHandle = (s, e) =>
            {
                if (server.Clients.Count() < 3)
                {
                    return true;
                }
                else 
                {
                    Print($"服务器已满，关闭客户端[{e.ClientSocket.RemoteEndPoint}]的连接");
                    return false;
                }
            };
        }

        private void Server_ClientDisconnected(object sender, STTech.BytesIO.Tcp.Entity.ClientDisconnectedEventArgs e)
        {
            Print($"客户端[{e.Client.Host}:{e.Client.Port}]断开连接");
        }

        private void Server_ClientConnected(object sender, STTech.BytesIO.Tcp.Entity.ClientConnectedEventArgs e)
        {
            Print($"客户端[{e.Client.Host}:{e.Client.Port}]连接成功");
            e.Client.OnDataReceived += Client_OnDataReceived;
            //e.Client.UseHeartbeatTimeout(3000);  // 设置超时值,心跳超时检测
        }

        private void Client_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            TcpClient tcpClient = (TcpClient)sender;
            //Print($"来自客户端[{tcpClient.RemoteEndPoint}]的消息：{e.Data.EncodeToString("UTF-16")}");
            foreach (TcpClient client in server.Clients) 
            {
                if (client != tcpClient)
                {
                    client.SendAsync(e.Data);
                }
            }
        }

        private void Server_Closed(object sender, EventArgs e)
        {
            Print("停止监听");
        }

        private void Server_Started(object sender, EventArgs e)
        {
            Print("开始监听");
        }

        private void tsmiStart_Click(object sender, EventArgs e)
        {
            server.StartAsync();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            server.CloseAsync();
        }

        private void Print(string msg)
        {
            tbLog.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }
    }
}
