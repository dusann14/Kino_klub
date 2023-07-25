using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    public class Receiver
    {
        private NetworkStream tok;
        private BinaryFormatter formatter;

        public Receiver(Socket soket)
        {
            tok = new NetworkStream(soket);
            formatter = new BinaryFormatter();
        }

        public object Primi()
        {
            return formatter.Deserialize(tok);
        }
    }
}
