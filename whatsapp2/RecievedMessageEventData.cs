using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsapp2
{
    internal class RecievedMessageEventData:EventArgs
    {
        public string _msg { get; set; }

        public RecievedMessageEventData(string msg)
        {
            this._msg = msg;
        }
    }
}
