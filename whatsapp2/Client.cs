using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whatsapp2
{
    internal class Client                           //diffrent from client obj in client side
    {
        public int _ID { get; set; }
        public string _userName { get; set; }
        public string _password { get; set; }
        public Boolean _active { get; set; }
        public Session _session { get; set; }


        public Client(TcpClient tcpClient) {
            _session=new Session(tcpClient);
            MessageListener();
        }

        public void EndClient()             //work in progress
        {
            _session.Stop();
            
        }

        

        private async void MessageListener()
        {
            while (true)
            {
                
                string msg = await _session._streamReader.ReadLineAsync();      //لما الstreamReader هيرمي exception علشان شغال هنا
                MessageBox.Show(msg);
            }
        }




    }
}
