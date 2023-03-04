using STTech.BytesIO.Serial;
using STTech.BytesIO.Tcp;
using System;
using System.Windows.Forms;

namespace Demo.BytesIO.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiCreateTcpClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("TCP客户端", new ClientPanel(new TcpClient() { Port = 6000}));
        }

        private void tsmiCreateSerialClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("串口客户端", new ClientPanel(new SerialClient() { ReceiveBufferSize = 65536, SendBufferSize = 65536 }));
        }
    }
}
