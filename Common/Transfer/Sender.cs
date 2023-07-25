using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    public class Sender
    {

        private NetworkStream tok;
        private BinaryFormatter formatter;


        public Sender(Socket soket)
        {
            tok = new NetworkStream(soket);
            formatter = new BinaryFormatter();
        }

        public void Posalji(object poruka)
        {
            formatter.Serialize(tok, poruka);
        }
    }
}
