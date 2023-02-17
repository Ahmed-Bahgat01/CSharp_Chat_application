using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal class Client                           //diffrent from client obj in client side
    {
        public event Action<object,RecievedMessageEventData> _recievedMessageEvent;
        public int _ID { get; set; }
        public string _userName { get; set; }
        public string _password { get; set; }
        public Boolean _active { get; set; }
        public Session _session { get; set; }


        public Client(TcpClient tcpClient) {
            _session=new Session(tcpClient);
            MessageListener();
            _active= true;
        }

        public void EndClient()             //work in progress
        {
            _session.Stop();
            
        }

        

        private async void MessageListener()
        {
            while (true)
            {
                try
                {
                    string msg = await _session._streamReader.ReadLineAsync();      //لما الstreamReader هيرمي exception علشان شغال هنا
                    MessageBox.Show(msg);
                    // firing event when message recieved
                    if (_recievedMessageEvent != null)
                    {
                        _recievedMessageEvent(this, new RecievedMessageEventData(msg));
                    }

                }
                catch(Exception ex)
                {
                    //MessageBox.Show($"(Cannot read message from socket server client) ERROR 1:{ex.Message}");
                    _session.Stop();
                    _active= false;
                    // TODO: fire an event that this client has been terminated for the server to delete it from alive clients
                    
                    
                    break;
                }
                
            }
        }




    }
}
