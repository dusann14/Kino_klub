using Common.Domen;
using Common.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instance;

        private Socket soket;
        private Receiver receiver;
        private Sender sender;

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }

        private Komunikacija()
        {

        }

        public void PoveziSe()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soket.Connect("127.0.0.1", 9000);
            receiver = new Receiver(soket);
            sender = new Sender(soket);
        }

        internal void OdjaviSe()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.Odjava
            };
            sender.Posalji(zahtev);
            soket.Close();
            soket = null;
        }

        internal Odgovor PrijaviSe(Korisnik korisnik)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = korisnik,
                Operacija = Operacije.Prijava
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiUloge()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiUloge
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiZanrove()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiZanrove
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiReditelje()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiReditelje
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor ZapamtiFilm(Film film)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.ZapamtiFilm,
                Objekat = film              
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiFilmove()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiFilmove,
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }
        internal Odgovor VratiFilmovePoNazivu(Film film)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiFilmovePoNazivu,
                Objekat = film
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor ZapamtiIznajmljivanje(Iznajmljivanje iznajmljivanje)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.ZapamtiIznajmljivanje,
                Objekat = iznajmljivanje
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiIznajmljivanja()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiIznajmlijvanja,
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiIznajmljivanjaPoImenuKorisnika(Iznajmljivanje iznajmljivanje)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiIznajmlijvanjaPoImenuKorisnika,
                Objekat = iznajmljivanje
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor ZapamtiRacun(Racun racun)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.ZapamtiRacun,
                Objekat = racun
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiOcene()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.VratiOcene,
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor OceniFilm(Ocena ocena)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.OceniFilm,
                Objekat = ocena
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor ZapamtiKorisnika(Korisnik korisnik)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacije.ZapamtiKorisnika,
                Objekat = korisnik
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }
    }
}
