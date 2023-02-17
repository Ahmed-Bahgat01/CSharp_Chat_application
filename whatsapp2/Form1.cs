using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    
    public partial class Form1 : Form
    {
        private Server server;
        public Form1()
        {
            InitializeComponent();
            EndBtn.Enabled= false;
            button1.Enabled= false;
            server=new Server();                //give me IP,port
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            EndBtn.Enabled = true;
            button1.Enabled = true;
            server.Start();
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = true;
            EndBtn.Enabled = false;
            button1.Enabled = false;
            server.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Broadcast("welcome");
        }
    }
}
