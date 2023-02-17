using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        IPAddress ServerAddress;
        int ServerPort;
        TcpClient MyClient;
        NetworkStream NStream;
        StreamReader SR;
        StreamWriter SW;
        public ClientForm()
        {
            InitializeComponent();
            ServerAddress = IPAddress.Parse("127.0.0.1");
            ServerPort = 6666;
            MyClient = null;
            NStream = null; 
            SR = null;
            SW = null;
        }

        async private void ReceiveMessage()
        {
            
            while (true)
            {
                string msg = await SR.ReadLineAsync();
                ChatHistoryListBox.Items.Add($"Server: {msg}");
            }
        }

        async private void ConnectBtn_Click(object sender, EventArgs e)
        {
            MyClient = new TcpClient();
            await MyClient.ConnectAsync(ServerAddress, ServerPort);
            NStream = MyClient.GetStream();
            SR = new StreamReader(NStream);
            ReceiveMessage();

        }

        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            if(MessageTextBox.Text != "")
            {
                SW = new StreamWriter(NStream);
                SW.AutoFlush= true;
                SW.WriteLine(MessageTextBox.Text);
                ChatHistoryListBox.Items.Add($"You: {MessageTextBox.Text}");
                MessageTextBox.Clear();
            }
        }
    }
}
