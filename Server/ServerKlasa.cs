using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Server.Obrada;
using Common.Transfer;
using Common.Domen;
using System.Threading;
using System.Configuration;

namespace Server
{
    public class ServerKlasa
    {
        private Socket osluskujuciSoket;
        private Sender sender;
        private Receiver receiver;
        private List<KlijentObrada> prijavljeniKorisnici = new List<KlijentObrada>();
        private bool kraj;

        public ServerKlasa()
        {
            osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        internal void Osluskuj()
        {
            try
            {
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"])));
                osluskujuciSoket.Listen(10);
                kraj = false;
                while (!kraj)
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    sender = new Sender(klijentskiSoket);
                    receiver = new Receiver(klijentskiSoket);
                    KlijentObrada obrada = new KlijentObrada(klijentskiSoket, sender, receiver);
                    prijavljeniKorisnici.Add(obrada);
                    Thread nitObrada = new Thread(obrada.Obradi);
                    nitObrada.IsBackground = true;
                    nitObrada.Start();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("<<<<<" + e.Message);
            }
        }

        internal void Stop()
        {
            kraj = true;

            foreach (KlijentObrada korisnik in prijavljeniKorisnici)
            {
                korisnik.Stop();
            }

            prijavljeniKorisnici.Clear();

            osluskujuciSoket.Close();
        }
    }
}
